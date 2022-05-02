using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiroModel;
using EMCLibrary;
using EMCFinanceiroRN;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;


namespace EMCFinanceiro
{
    public partial class frmMovimentoBancario : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmMovimentoBancario";
        private const string nomeAplicativo = "EMCFinanceiro";
        
        private Decimal valorMovimento = 0; 
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        public frmMovimentoBancario(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"
        public frmMovimentoBancario()
        {
            InitializeComponent();
        }
        private void frmMovimentoBancario_Activated(object sender, EventArgs e)
        {


        }
        private void frmMovimentoBancario_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "movimentobancario";


            cboTipoMovimento.Items.Add("Crédito");
            cboTipoMovimento.Items.Add("Débito");

            CtaBancaria oCta = new CtaBancaria();
            //TODO: colocar verificação de empmaster de acordo com o parametro na cta bancaria
            oCta.codEmpresa = codempresa;
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idctabancaria";

            Pessoa oPessoa = new Pessoa();
            PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
            cboIdPessoa.DataSource = oPessoaRN.Listar();
            cboIdPessoa.DisplayMember = "nome";
            cboIdPessoa.ValueMember = "idpessoa";

            AtivaInsercao();
            
        }
#endregion

#region "metodos para tratamento das informacoes"
        private MovimentoBancario montaMovimentoBancario()
        {
            MovimentoBancario oMovimentoBancario = new MovimentoBancario();
            oMovimentoBancario.cadastro_datahora = DateTime.Now;
            oMovimentoBancario.cadastro_idusuario = Convert.ToInt32(usuario);
            oMovimentoBancario.codEmpresa = codempresa;
            oMovimentoBancario.documento = txtDocumento.Text;
            oMovimentoBancario.documentoorigem = txtDocumentoOrigem.Text;
            oMovimentoBancario.dataMovimento = Convert.ToDateTime(txtDataMovimento.Text);
            oMovimentoBancario.valorDocumento = Convert.ToDecimal(txtValorMovimento.Text);
            oMovimentoBancario.valorJuros = 0;
            oMovimentoBancario.valorDesconto = 0;
            oMovimentoBancario.valorMovimento = Convert.ToDecimal(txtValorMovimento.Text);
            oMovimentoBancario.valorMovimentoAnterior = valorMovimento;

            CtaBancaria oCta = new CtaBancaria();
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta.codEmpresa = codempresa;
            oCta.idCtaBancaria = Convert.ToInt32(cboIdContaBancaria.SelectedValue);
            oMovimentoBancario.contaBancaria = oCtaRN.ObterPor(oCta);

            if (cboTipoMovimento.Text == "Crédito")
            {
                oMovimentoBancario.tipoMovimento = "C";
            }
            else
                oMovimentoBancario.tipoMovimento = "D";

            if (!String.IsNullOrEmpty(cboIdPessoa.SelectedValue.ToString()))
            {
                Pessoa oPessoa = new Pessoa();
                PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
                oPessoa.codEmpresa = empMaster;
                oPessoa.idPessoa = Convert.ToInt32(cboIdPessoa.SelectedValue);
                oMovimentoBancario.pessoa = oPessoaRN.ObterPor(oPessoa);
            }

            oMovimentoBancario.historico = txtHistorico.Text;
            oMovimentoBancario.nominal = txtNominal.Text;
            oMovimentoBancario.situacao = "A";
            oMovimentoBancario.nroCheque = "";
            return oMovimentoBancario;
        }
        private void montaTela(MovimentoBancario oMovimentoBancario)
        {
            txtDocumento.Text = oMovimentoBancario.documento.ToString();
            txtDocumentoOrigem.Text = oMovimentoBancario.documentoorigem.ToString();
            txtDataMovimento.Text = oMovimentoBancario.dataMovimento.ToString();
            cboIdContaBancaria.SelectedValue = oMovimentoBancario.contaBancaria.idCtaBancaria.ToString();
            cboIdPessoa.SelectedValue = oMovimentoBancario.pessoa.idPessoa.ToString();

            if (oMovimentoBancario.tipoMovimento == "C")
                cboTipoMovimento.Text = "Crédito";
            else cboTipoMovimento.Text = "Débito";

            txtValorMovimento.Text = oMovimentoBancario.valorMovimento.ToString();
            valorMovimento = Convert.ToDecimal(oMovimentoBancario.valorMovimento.ToString());
            txtHistorico.Text = oMovimentoBancario.historico;
            txtIdMovimentoBancario.Text = oMovimentoBancario.idMovimentoBancario.ToString();
            txtNominal.Text = oMovimentoBancario.nominal.ToString();

            objOcorrencia.chaveidentificacao = oMovimentoBancario.idMovimentoBancario.ToString();
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
        }
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            
            if (!String.IsNullOrEmpty(txtDocumento.Text) || !String.IsNullOrEmpty(txtIdMovimentoBancario.Text))
            {
               
                MovimentoBancario oMovimentoBancario = new MovimentoBancario();
                try
                {
                    MovimentoBancarioRN MovimentoBancarioBLL = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);

                    //oMovimentoBancario = montaMovimentoBancario();
                    oMovimentoBancario.idMovimentoBancario = EmcResources.cInt(txtIdMovimentoBancario.Text);
                    oMovimentoBancario.documento = txtDocumento.Text.ToString();

                    oMovimentoBancario = MovimentoBancarioBLL.ObterPor(oMovimentoBancario);

                    if (String.IsNullOrEmpty(oMovimentoBancario.historico))
                    {
                        DialogResult result = MessageBox.Show("MovimentoBancario não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        //txtidMovimentoBancario.Text = oMovimentoBancario.idMovimentoBancario;
                        montaTela(oMovimentoBancario);
                       
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro MovimentoBancario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtSaldo.Text = "0";
            txtValorMovimento.Text = "0";
            objOcorrencia.chaveidentificacao = "";
        }
        public override void SalvaObjeto()
        {
            try
            {
                
                MovimentoBancario oMovimentoBancario = new MovimentoBancario();
                MovimentoBancarioRN oMovimentoBancarioBLL = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                oMovimentoBancario = montaMovimentoBancario();

                oMovimentoBancarioBLL.Salvar(oMovimentoBancario);

                buscaSaldo();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.SalvaObjeto();
        }
        public override void AtualizaObjeto()
        {
            try
            {
                MovimentoBancario oMovimentoBancario = new MovimentoBancario();
                MovimentoBancarioRN oMovimentoBancarioBLL = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                oMovimentoBancario = montaMovimentoBancario();
                oMovimentoBancario.idMovimentoBancario = Convert.ToInt32(txtIdMovimentoBancario.Text);

                oMovimentoBancarioBLL.Atualizar(oMovimentoBancario);
                
                buscaSaldo();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {
                MovimentoBancario oMovimentoBancario = new MovimentoBancario();
                MovimentoBancarioRN oMovimentoBancarioBLL = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                oMovimentoBancario = montaMovimentoBancario();
                oMovimentoBancario.idMovimentoBancario = Convert.ToInt32(txtIdMovimentoBancario.Text);

                oMovimentoBancarioBLL.Excluir(oMovimentoBancario);
                
                buscaSaldo();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
#endregion

#region "metodos da dbgrid"
        private void grdMovimentoBancario_DoubleClick(object sender, EventArgs e)
        {
            txtIdMovimentoBancario.Text = grdMovimentoBancario.Rows[grdMovimentoBancario.CurrentRow.Index].Cells["idmovimento"].Value.ToString();
            txtIdMovimentoBancario.Focus();
            SendKeys.Send("{TAB}");
        }

        private void AtualizaGrid()
        {
            //grdMovimentoBancario.Rows.Clear();

            CtaBancaria oCta = new CtaBancaria();
            oCta.idCtaBancaria = Convert.ToInt32(cboIdContaBancaria.SelectedValue);

            //carrega a grid com os ceps cadastrados
            MovimentoBancarioRN objMovimentoRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
            grdMovimentoBancario.DataSource = objMovimentoRN.extratoPeriodo(oCta, Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text));
            buscaSaldo();
        }
#endregion

#region [Texts e buttons]

        private void txtDocumento_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            AtualizaGrid();
        }

        private void txtIdMovimentoBancario_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdPessoa.Text))
            {
                cboIdPessoa.Focus();
            }
            else
            {
                cboIdPessoa.SelectedValue = Convert.ToInt32(txtIdPessoa.Text);
                txtNominal.Focus();
            }
        }

        private void cboIdPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            txtIdPessoa.Text = Convert.ToString(cboIdPessoa.SelectedValue);
            txtNominal.Focus();
        }

        private void cboIdContaBancaria_SelectedValueChanged(object sender, EventArgs e)
        {


            if (grdMovimentoBancario.DataSource != null)
                AtualizaGrid();
            else
                grdMovimentoBancario.Rows.Clear();

            if (!String.IsNullOrEmpty(cboIdContaBancaria.SelectedValue.ToString()) && (cboIdContaBancaria.SelectedValue.ToString()!="System.Data.DataRowView"))
            {
                buscaSaldo();
            }
        }

        private void buscaSaldo()
        {
            CtaBancaria oCta = new CtaBancaria();
            oCta.idCtaBancaria = EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString());
            oCta.codEmpresa = codempresa;

            CtaBancariaRN oRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta = oRN.ObterPor(oCta);

            txtSaldo.Text = oCta.saldoAtual.ToString();
        }
#endregion


    }
}
