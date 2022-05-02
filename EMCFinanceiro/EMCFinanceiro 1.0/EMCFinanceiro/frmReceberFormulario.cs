using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCFinanceiroModel;
using EMCFinanceiroRN;

namespace EMCFinanceiro
{
    public partial class frmReceberFormulario : EMCLibrary.EMCForm
    {

        private const string nomeFormulario = "frmReceberFormulario";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        //private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public frmReceberFormulario()
        {
            InitializeComponent();
        }
        public frmReceberFormulario(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmReceberFormulario_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Formulario";


            CtaBancaria oCta = new CtaBancaria();
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta.codEmpresa = codempresa;

            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idctabancaria";

            LayoutChequeRN oChRN = new LayoutChequeRN(Conexao, objOcorrencia, codempresa);
            LayoutCheque oCh = new LayoutCheque();

            cboIdLayoutCheque.DataSource = oChRN.ListaLayoutCheque(oCta);
            cboIdLayoutCheque.DisplayMember = "descricao";
            cboIdLayoutCheque.ValueMember = "idlayoutcheque";

            cboTipoFormulario.Items.Add("1-Cheque");
            cboTipoFormulario.Items.Add("2-Bloqueto pre impresso");
            cboTipoFormulario.Items.Add("3-Boleto");


            AtualizaGrid();
            CancelaOperacao();
            this.ActiveControl = txtIdFormulario;
        }


#region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaReceberFormulario(Formulario oReceberFormulario)
        {
            FormularioRN oReceberFormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oReceberFormularioRN.VerificaDados(oReceberFormulario);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        private Formulario montaReceberFormulario()
        {

            Formulario oFormulario = new Formulario();
            oFormulario.carteiraCobranca = txtCarteiraCobranca.Text;

            CtaBancaria oCta = new CtaBancaria();
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta.codEmpresa = codempresa;
            oCta.idCtaBancaria = EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString());
            oCta = oCtaRN.ObterPor(oCta);

            oFormulario.contaBancaria = oCta;           
            oFormulario.descricaoFormulario = txtDescricao.Text;
            oFormulario.dtaFinal = Convert.ToDateTime(txtDataFinal.Text);
            oFormulario.dtaInicio = Convert.ToDateTime(txtDataInicio.Text);
            oFormulario.idFormulario = EmcResources.cInt(txtIdFormulario.Text);
            oFormulario.nroAtual = txtNroAtual.Text;
            oFormulario.nroFinal = txtNroFinal.Text;
            oFormulario.nroInicial = txtNroInicial.Text;
            //oFormulario.tipoFormulario = cboTipoFormulario.SelectedValue.ToString();
            oFormulario.situacao = "A";

            if (cboTipoFormulario.Text == "1-Cheque")
            {
                oFormulario.tipoFormulario = "1";
            }
            else if (cboTipoFormulario.Text == "2-Bloqueto pre impresso")
            {
                oFormulario.tipoFormulario = "2";
            }
            else if (cboTipoFormulario.Text == "3-Boleto")
            {
                oFormulario.tipoFormulario = "3";
            }

            LayoutChequeRN oChRN = new LayoutChequeRN(Conexao, objOcorrencia, codempresa);
            LayoutCheque oCh = new LayoutCheque();

            oCh.idLayoutCheque = EmcResources.cInt(cboIdLayoutCheque.SelectedValue.ToString());
            oCh = oChRN.ObterPor(oCh);

            oFormulario.layoutCheque = oCh;

            return oFormulario;
        }
        private void montaTela(Formulario oFormulario)
        {
            //CtaBancaria oCta = new CtaBancaria();
            //CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao,objOcorrencia);

            cboIdContaBancaria.SelectedValue = oFormulario.contaBancaria.idCtaBancaria;
            
            //cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            //cboIdContaBancaria.DisplayMember = "descricao";
            //cboIdContaBancaria.ValueMember = "idctabancaria";

            
            txtIdFormulario.Text = oFormulario.idFormulario.ToString();
            txtDescricao.Text = oFormulario.descricaoFormulario;
            cboIdContaBancaria.SelectedValue = oFormulario.contaBancaria.idCtaBancaria;
            txtDataInicio.Text = oFormulario.dtaInicio.ToString();
            txtDataFinal.Text = oFormulario.dtaFinal.ToString();
            txtNroInicial.Text = oFormulario.nroInicial;
            txtNroFinal.Text = oFormulario.nroFinal;
            txtNroAtual.Text = oFormulario.nroAtual;
            txtCarteiraCobranca.Text = oFormulario.carteiraCobranca;

            if (oFormulario.tipoFormulario == "1")
            {
                cboTipoFormulario.Text = "1-Cheque";
            }
            else if (oFormulario.tipoFormulario == "2")
            {
                cboTipoFormulario.Text = "2-Bloqueto pre impresso";
            }
            else if (oFormulario.tipoFormulario == "3")
            {
                cboTipoFormulario.Text = "3-Boleto";
            }

            cboIdLayoutCheque.SelectedValue = EmcResources.cInt(oFormulario.layoutCheque.idLayoutCheque.ToString());

            objOcorrencia.chaveidentificacao = oFormulario.idFormulario.ToString();

        }
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

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
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();

            txtIdFormulario.Enabled = false;
            txtDescricao.Focus();

        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtIdFormulario.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
        }
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            Formulario oFormulario = new Formulario();
            oFormulario.idFormulario = EmcResources.cInt(txtIdFormulario.Text);
            
            try
            {
                FormularioRN FormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
                oFormulario = FormularioRN.ObterPor(oFormulario);
                
                if (oFormulario.idFormulario == 0)
                {
                    DialogResult result = MessageBox.Show("Formulário não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        AtivaInsercao();
                    }

                }
                else
                {
                    montaTela(oFormulario);
                    AtivaEdicao();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ReceberFormulario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
        }
        public override void SalvaObjeto()
        {
            try
            {
                Formulario oFormulario = new Formulario();
                FormularioRN oFormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);

                
                oFormulario = montaReceberFormulario();
                
                if (verificaReceberFormulario(oFormulario))
                {
                    oFormularioRN.Salvar(oFormulario);

                    LimpaCampos();
                    montaTela(oFormulario);
                    AtualizaGrid();
                }

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
                Formulario oFormulario = new Formulario();
                FormularioRN oFormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);

                oFormulario = montaReceberFormulario();


                if (verificaReceberFormulario(oFormulario))
                {

                    oFormularioRN.Atualizar(oFormulario);

                    LimpaCampos();
                    MessageBox.Show("ReceberFormulario atualizado com sucesso");
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oFormulario);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {
                Formulario oFormulario = new Formulario();
                FormularioRN oFormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
                oFormulario = montaReceberFormulario();

                if (verificaReceberFormulario(oFormulario))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Formulário ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oFormularioRN.Excluir(oFormulario);

                        LimpaCampos();
                        MessageBox.Show("Formulário excluido!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
#endregion
#region "Tratamentos para buttons e texts**************************************************************************************"
        
        private void txtIdFormulario_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }
#endregion
#region "metodos da dbgrid*******************************************************************************************"
        private void grdFormulario_DoubleClick(object sender, EventArgs e)
        {
            txtIdFormulario.Text = grdFormulario.Rows[grdFormulario.CurrentRow.Index].Cells["idFormulario"].Value.ToString();
            txtIdFormulario.Focus();
            SendKeys.Send("{TAB}");
        }
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            FormularioRN oFormularioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
            Formulario oFormulario = new Formulario();

            CtaBancaria oConta = new CtaBancaria();
            CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oConta.codEmpresa = codempresa;
   
            oFormulario.contaBancaria = oConta;
            oFormulario.tipoFormulario = "";

            grdFormulario.DataSource = oFormularioRN.ListaFormulario(oFormulario);

        }


#endregion

        

     
    }
}
