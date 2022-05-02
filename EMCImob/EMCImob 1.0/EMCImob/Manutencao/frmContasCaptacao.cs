using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCImob
{
    public partial class frmContasCaptacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmContasCaptacao";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

         public frmContasCaptacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmContasCaptacao()
        {
            InitializeComponent();
        }

        private void frmContasCaptacao_Activated(object sender, EventArgs e)
        {

        }
        private void frmContasCaptacao_Load(object sender, EventArgs e)
        {

            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "contascaptacao";


            //Carregando a combo da tela com uma list de todos os dados da tabela
            TipoLanctoCaptacaoRN objTipoLanctoCaptacaoRN = new TipoLanctoCaptacaoRN(Conexao,objOcorrencia,codempresa);
            cboTipoLanctoCaptacao.DataSource = objTipoLanctoCaptacaoRN.ListaTipoLanctoCaptacao();
            //Campo que irá mostrar na tela
            cboTipoLanctoCaptacao.DisplayMember = "Descricao";
            //Campo que será a chave da combo
            cboTipoLanctoCaptacao.ValueMember = "idTipoLanctoCaptacao";

            //Carregando a combo de Vendedores
            VendedorRN oVendedorRN = new VendedorRN(Conexao, objOcorrencia, codempresa);
            Vendedor oVendedor = new Vendedor();
            oVendedor.codEmpresa = empMaster;
            cboIdVendedor.DataSource = oVendedorRN.ListaVendedor(oVendedor);
            cboIdVendedor.DisplayMember = "nome";
            cboIdVendedor.ValueMember = "idPessoa";
            //
            txtVendedor_IdPessoa.Text = Convert.ToString(cboIdVendedor.SelectedValue);

            AtualizaGrid();
            this.ActiveControl = txtVendedor_IdPessoa;
            CancelaOperacao();
        }

        #endregion


        #region "metodos para tratamento das informacoes"
        
        private ContasCaptacao montaContasCaptacao()
        {
            ContasCaptacao oContasCaptacao = new ContasCaptacao();
            oContasCaptacao.codEmpresa = codempresa;
            oContasCaptacao.dataLancamento = Convert.ToDateTime(txtDataLancamento.Text);
            //Carregando o objeto complento do Tipo de Lançamento
            TipoLanctoCaptacao oTipoLanctoCaptacao = new TipoLanctoCaptacao();
            TipoLanctoCaptacaoRN oTipoLanctoCaptacaoRN = new TipoLanctoCaptacaoRN(Conexao,objOcorrencia,codempresa);
            oTipoLanctoCaptacao.idTipoLanctoCaptacao = Convert.ToInt32(cboTipoLanctoCaptacao.SelectedValue.ToString());
            oContasCaptacao.tipoLanctoCaptacao = oTipoLanctoCaptacaoRN.ObterPor(oTipoLanctoCaptacao);
            //
            oContasCaptacao.descricao = txtDescricao.Text;
            oContasCaptacao.valorLancamento = Convert.ToDecimal(txtValorLancamento.Text);

            if (cboSituacao.Text == "Aberto")
            {
                oContasCaptacao.situacao = "A"; 
            }
            else
            {
                oContasCaptacao.situacao = "P"; 
            }
            //Carregando o objeto complento do Vendedor
            Vendedor oVendedor = new Vendedor();
            VendedorRN oVendedorRN = new VendedorRN(Conexao, objOcorrencia, codempresa);
            oVendedor.codEmpresa = empMaster;
            oVendedor.idPessoa = Convert.ToInt32(cboIdVendedor.SelectedValue.ToString());
            oContasCaptacao.vendedor = oVendedorRN.ObterPor(oVendedor);

            return oContasCaptacao;

        }
        private void montaTela(ContasCaptacao oContasCaptacao)
        {
            txtIdContasCaptacao.Text = oContasCaptacao.idContasCaptacao.ToString();
            txtDataLancamento.Text = oContasCaptacao.dataLancamento.ToString();
            cboTipoLanctoCaptacao.SelectedValue = oContasCaptacao.tipoLanctoCaptacao.idTipoLanctoCaptacao.ToString();
            txtDescricao.Text = oContasCaptacao.descricao;
            txtValorLancamento.Text = oContasCaptacao.valorLancamento.ToString();
            if (oContasCaptacao.situacao == "A")
                cboSituacao.Text = "Aberto";
            else
                cboSituacao.Text = "Pago";

            objOcorrencia.chaveidentificacao = oContasCaptacao.idContasCaptacao.ToString();
            txtDataLancamento.Focus();
            AtivaEdicao();

        }
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtDataLancamento.Focus();
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDataLancamento.Focus();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            if (!String.IsNullOrEmpty(txtIdContasCaptacao.Text))
            {

                ContasCaptacao oContasCaptacao = new ContasCaptacao();
                try
                {
                    ContasCaptacaoRN ContasCaptacaoBLL = new ContasCaptacaoRN(Conexao, objOcorrencia, codempresa);

                    //oContasCaptacao = montaContasCaptacao();
                    oContasCaptacao.idContasCaptacao = Convert.ToInt32(txtIdContasCaptacao.Text);

                    oContasCaptacao = ContasCaptacaoBLL.ObterPor(oContasCaptacao);

                    montaTela(oContasCaptacao);
                    AtivaEdicao();
                    txtDataLancamento.Focus();
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Contas Captação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                CancelaOperacao();
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtDescricao.Focus();
            cboSituacao.Text = "Aberto";
            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            
            try
            {

                ContasCaptacao oContasCaptacao = new ContasCaptacao();
                ContasCaptacaoRN oContasCaptacaoRN = new ContasCaptacaoRN(Conexao, objOcorrencia, codempresa);
                oContasCaptacao = montaContasCaptacao();

                oContasCaptacaoRN.VerificaDados(oContasCaptacao);


                oContasCaptacaoRN.Salvar(oContasCaptacao);
                AtualizaGrid();
                CancelaOperacao();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Contas Captação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CancelaOperacao();

            }

        }

        public override void AtualizaObjeto()
        {
            
            //try
            //{
            //    Comodo oComodo = new Comodo();
            //    ComodoRN oComodoBLL = new ComodoRN();
            //    oComodo = montaComodo();
            //    oComodo.idComodos = Convert.ToInt32(txtIdComodo.Text);

            //    oComodoBLL.Atualizar(oComodo);
            //    AtualizaGrid();
            //    CancelaOperacao();
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //    CancelaOperacao();
            //}
        }

        public override void ExcluiObjeto()
        {
            
            //try
            //{
            //    Comodo oComodo = new Comodo();
            //    ComodoRN oComodoBLL = new ComodoRN();
            //    oComodo = montaComodo();
            //    oComodo.idComodos = Convert.ToInt32(txtIdComodo.Text);

            //    oComodoBLL.Excluir(oComodo);
            //    AtualizaGrid();
            //    CancelaOperacao();
            //}
            //catch (Exception erro)
            //{
            //    MessageBox.Show(erro.Message);
            //    CancelaOperacao();
            //}

        }


        #endregion

        #region "metodos da dbgrid"

        private void grdContasCaptacao_DoubleClick(object sender, EventArgs e)
        {
            txtIdContasCaptacao.Text = grdContasCaptacao.Rows[grdContasCaptacao.CurrentRow.Index].Cells["idContasCaptacao"].Value.ToString();
            BuscaObjeto();

        }

        private void AtualizaGrid()
        {
            //carrega a grid
            ContasCaptacao oContasCaptacao = new ContasCaptacao();
            ContasCaptacaoRN oContasCaptacaoRN = new ContasCaptacaoRN(Conexao, objOcorrencia, codempresa);
            grdContasCaptacao.DataSource = oContasCaptacaoRN.ListaContasCaptacao(oContasCaptacao);
            txtDataLancamento.Focus();
        }


        #endregion


        #region [Tratamento de Texts, combos ]
        
        private void txtVendedor_IdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtVendedor_IdPessoa.Text))
            {
                cboIdVendedor.Focus();
            }
            else
            {
                cboIdVendedor.SelectedValue = Convert.ToInt32(txtVendedor_IdPessoa.Text);
                txtDataInicial.Focus();
            }
        }

        private void cboIdVendedor_SelectedValueChanged(object sender, EventArgs e)
        {
            txtVendedor_IdPessoa.Text = Convert.ToString(cboIdVendedor.SelectedValue);
            txtDataInicial.Focus();
        }

        
        private void txtIdContasCaptacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        #endregion
    }
}
