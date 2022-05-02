using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiro.Pesquisa;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastro;

namespace EMCFinanceiro
{
    public partial class frmPagarLiberacao : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPagarLiberacao";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        #region [Metodos para configuração do formulário]
        public frmPagarLiberacao()
        {
            InitializeComponent();
        }
        public frmPagarLiberacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmPagarLiberacao_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmPagarDocumento";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "pagardocumento";

            CancelaOperacao();

            this.ActiveControl = txtNumeroDocumento;

        }
        #endregion 

        #region [metodos para tratamento das informacoes]

        private List<PagarParcela> montaPagarParcela()
        {
            PagarParcela oParcela = null;
            PagarParcelaRN oParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);

            List<PagarParcela> lstParcelas = new List<PagarParcela>();

            //monta uma lista de parcelas
            foreach (DataGridViewRow dataGridViewRow in grdLiberacao.Rows)
            {
                

                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];
                if (ch1.Value.ToString().ToUpper() == "TRUE" )
                {
                    oParcela = new PagarParcela();
                    oParcela.idPagarParcela = EmcResources.cInt(dataGridViewRow.Cells["idpagarparcelas"].Value.ToString());
                    oParcela = oParcelaRN.ObterPor(oParcela);

                    if (oParcela.autorizador_idUsuario > 0)
                    {
                        oParcela.autorizador2_idUsuario = EmcResources.cInt(usuario);
                    }
                    else
                        oParcela.autorizador_idUsuario = EmcResources.cInt(usuario);


                    lstParcelas.Add(oParcela);
                }
            }

            return lstParcelas;
        }
        private void montaTela(PagarDocumento oPagarDocumento)
        {
            objOcorrencia.chaveidentificacao = oPagarDocumento.idPagarDocumento.ToString();
        }
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            liberaBotao("btnAtualizar");
        }
        public override void travaBotao(string Botao)
        {
            base.travaBotao(Botao);
        }
        public override void liberaBotao(string Botao)
        {
            base.liberaBotao(Botao);
        }
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            AtualizaGrid();
        }
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtNroDocumento.Focus();
            flagInclusao = true;

            objOcorrencia.chaveidentificacao = "";

            grdLiberacao.Rows.Clear();
            grdRateio.Rows.Clear();

            liberaBotao("btnAtualizar");
            travaBotao("btnSalvar");
        }
        public override void SalvaObjeto()
        {

            try
            {


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " - " + erro.StackTrace);
            }

        }
        public override void AtualizaObjeto()
        {
            try
            {

                PagarParcelaRN oParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                List<PagarParcela> lstParcelas = new List<PagarParcela>();

                lstParcelas = montaPagarParcela();
                oParcelaRN.liberacaoPagamento(lstParcelas, codempresa);

                LimpaCampos();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
        public void pesquisaDocumento()
        {
    

        }
        #endregion

        #region [metodos para tratamento da grid]
        public void AtualizaGrid()
        {

            //foreach (DataRow row in dtPAgamento)

            //adquiri lista de parcelas do objeto documento
            PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
            List<PagarParcela> lstPagarParcela = oPgParcelaRN.listaPagarLiberacao( EmcResources.cInt(usuario), 
                                                                                  codempresa,
                                                                                  EmcResources.cInt(txtCodigoFornecedor.Text),
                                                                                  Convert.ToDateTime(txtDataInicio.Text),
                                                                                  Convert.ToDateTime(txtDataFinal.Text),
                                                                                  chkTodasContas.Checked,
                                                                                  txtNumeroDocumento.Text,
                                                                                  EmcResources.cCur(txtValorInicio.Text),
                                                                                  EmcResources.cCur(txtValorFinal.Text),
                                                                                  chkValorDocumento.Checked);

            grdLiberacao.Rows.Clear();

            foreach (PagarParcela oParcela in lstPagarParcela)
            {
                grdLiberacao.Rows.Add(false, oParcela.pagarDocumento.idPagarDocumento, oParcela.idPagarParcela,
                                          oParcela.pagarDocumento.nroDocumento, oParcela.nroParcela,
                                          oParcela.dataVencimento, oParcela.saldoPagar,
                                          oParcela.pagarDocumento.fornecedor.pessoa.nome);
            }

            grdLiberacao.ScrollBars = ScrollBars.Both;

            liberaBotao("btnAtualizar");

        }

        #endregion

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdLiberacao.Rows)
            {
                row.Cells[0].Value = true;
            }
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdLiberacao.Rows)
            {
                row.Cells[0].Value = false;
            }
        }

        private void grdLiberacao_Click(object sender, EventArgs e)
        {
            if (grdLiberacao.Rows.Count > 0)
            {
                PagarDocumento oPgDoc = new PagarDocumento();
                oPgDoc.idPagarDocumento = Convert.ToInt32(grdLiberacao.Rows[grdLiberacao.CurrentRow.Index].Cells["idpagardocumento"].Value.ToString());

                PagarDocumentoRN oPgDocRN = new PagarDocumentoRN(Conexao, objOcorrencia, codempresa);
                oPgDoc = oPgDocRN.ObterPor(oPgDoc);

                txtNroDocumento.Text = oPgDoc.nroDocumento;
                txtDataEmissao.Text = oPgDoc.dataEmissao.ToString();

                txtTipoDocumento.Text = oPgDoc.tipoDocumento.descricao;
                txtFornecedor.Text = oPgDoc.fornecedor.pessoa.nome;
                txtCNPJCPF.Text = oPgDoc.fornecedor.pessoa.cnpjCpf;
                txtIndexador.Text = oPgDoc.indexador.descricao;
                txtValorParcela.Text = oPgDoc.descricao;
                txtDataEntrada.Text = oPgDoc.dataEntrada.ToString();
                txtValorDocumento.Text = oPgDoc.valorDocumento.ToString();
                

                grdRateio.Rows.Clear();
                foreach(PagarBaseRateio oRat in oPgDoc.baseRateio)
                {
                    grdRateio.Rows.Add(oRat.aplicacao.idAplicacao, oRat.contaCusto.idContaCusto, oRat.contaCusto.codigoConta,
                                       oRat.contaCusto.descricao, oRat.aplicacao.descricao, oRat.valorRateio, oRat.percentualRateio);

                }
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtCodigoFornecedor.Text = "";
            else
                txtCodigoFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtCodigoFornecedor.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtCodigoFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);

                oFornecedor.idPessoa = EmcResources.cInt(txtCodigoFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                txtNomeFornecedor.Text = oFornecedor.pessoa.nome;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

    }
}
