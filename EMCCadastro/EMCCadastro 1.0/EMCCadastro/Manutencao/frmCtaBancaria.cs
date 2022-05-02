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
using System.Collections;

namespace EMCCadastro
{
    public partial class frmCtaBancaria : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCtaBancaria";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmCtaBancaria()
        {
            InitializeComponent();
        }
        public frmCtaBancaria(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        
        private void frmCtaBancaria_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "ctabancaria";


            Banco bco = new Banco();
            BancoRN bcoRN = new BancoRN(Conexao,objOcorrencia,codempresa);

            cboBanco.DataSource = bcoRN.ListaBanco(bco);
            cboBanco.DisplayMember = "descricao";
            cboBanco.ValueMember = "idbanco";

            ArrayList arrSituacao = new ArrayList();
            arrSituacao.Add(new popCombo("Não", "N"));
            arrSituacao.Add(new popCombo("Sim", "S"));
            cboContaCaixa.DataSource = arrSituacao;
            cboContaCaixa.DisplayMember = "nome";
            cboContaCaixa.ValueMember = "valor";

            AtualizaGrid();
            this.ActiveControl = txtidCtaBancaria;
            CancelaOperacao();

        }


#region "metodos para tratamento das informacoes*********************************************************************"
       
        private Boolean verificaCtaBancaria(CtaBancaria oCtaBancaria)
        {
            CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oCtaBancariaRN.VerificaDados(oCtaBancaria);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        
        private CtaBancaria montaCtaBancaria()
        {
            CtaBancaria oCtaBancaria = new CtaBancaria();
            oCtaBancaria.codEmpresa = codempresa;
            oCtaBancaria.idCtaBancaria = Convert.ToInt32(txtidCtaBancaria.Text);
            oCtaBancaria.descricao = txtDescricao.Text;
            oCtaBancaria.agencia = txtAgencia.Text;
            oCtaBancaria.agenciaDigito = txtAgenciaDigito.Text;
            oCtaBancaria.conta = txtConta.Text;
            oCtaBancaria.contaDigito = txtContaDigito.Text;
            oCtaBancaria.cedente = txtCedente.Text;
            oCtaBancaria.cedenteDigito = txtCedenteDigito.Text;
            oCtaBancaria.saldoAtual = Convert.ToDouble(txtSaldoAtual.Text);
            oCtaBancaria.limite = Convert.ToDouble(txtLimite.Text);
            oCtaBancaria.VencLimite = Convert.ToDateTime(txtVencLimite.Text);
            oCtaBancaria.contaCaixa = cboContaCaixa.SelectedValue.ToString();

            if (txtDtaFechamento.Text.Trim().Length == 0 || String.IsNullOrEmpty(txtDtaFechamento.Text))
            {
                oCtaBancaria.dataFechamento = null;
            }
            else
                oCtaBancaria.dataFechamento = Convert.ToDateTime(txtDtaFechamento.Text);

            oCtaBancaria.sdoFechamento = Convert.ToDouble(txtSdoFechamento.Text);

            Banco bco = new Banco();
            bco.idBanco = Convert.ToInt32(cboBanco.SelectedValue);

            BancoRN bcoRN = new BancoRN(Conexao,objOcorrencia,codempresa);
            oCtaBancaria.Banco = bcoRN.ObterPor(bco);


            return oCtaBancaria;
        }
       
        private void montaTela(CtaBancaria oCtaBancaria)
        {
            Banco bco = new Banco();
            BancoRN bcoRN = new BancoRN(Conexao,objOcorrencia,codempresa);

            cboBanco.DataSource = bcoRN.ListaBanco(bco);
            cboBanco.DisplayMember = "descricao";
            cboBanco.ValueMember = "idbanco";

            cboContaCaixa.SelectedValue = oCtaBancaria.contaCaixa;

            txtidCtaBancaria.Text = oCtaBancaria.idCtaBancaria.ToString();
            txtDescricao.Text = oCtaBancaria.descricao;
            txtAgencia.Text = oCtaBancaria.agencia;
            txtAgenciaDigito.Text = oCtaBancaria.agenciaDigito;
            txtConta.Text = oCtaBancaria.conta;
            txtContaDigito.Text = oCtaBancaria.contaDigito;
            txtCedente.Text = oCtaBancaria.cedente;
            txtCedenteDigito.Text = oCtaBancaria.cedenteDigito;
            cboBanco.SelectedValue = oCtaBancaria.Banco.idBanco;
            txtSaldoAtual.Text = oCtaBancaria.saldoAtual.ToString();
           
            txtLimite.Text = oCtaBancaria.limite.ToString();
            
            txtVencLimite.Text = oCtaBancaria.VencLimite.ToString();

           
            //Convert.ToString(oCtaBancaria.dataFechamento) == "01/01/0001 00:00:00" ||
            if (oCtaBancaria.dataFechamento == null)
            {
                txtDtaFechamento.Text = "";
            }
            else
            {
                txtDtaFechamento.Text = Convert.ToString(oCtaBancaria.dataFechamento);
            }

            objOcorrencia.chaveidentificacao = oCtaBancaria.idCtaBancaria.ToString();
            txtidCtaBancaria.Focus();


        }
        
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtidCtaBancaria.Enabled = false;

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

        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidCtaBancaria.Enabled = true;
            txtidCtaBancaria.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
               CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);

                DataTable dtCon;

                if (cboBanco.SelectedValue == null)
                {

                    dtCon = oCtaBancariaRN.pesquisaCtaBancaria(empMaster, EmcResources.cInt(txtidCtaBancaria.Text), EmcResources.cInt(txtConta.Text), EmcResources.cInt(txtAgencia.Text), 0);
                    grdConta.DataSource = dtCon;

                }
                else
                {
                    dtCon = oCtaBancariaRN.pesquisaCtaBancaria(empMaster, EmcResources.cInt(txtidCtaBancaria.Text), EmcResources.cInt(txtConta.Text), EmcResources.cInt(txtAgencia.Text), EmcResources.cInt(cboBanco.SelectedValue.ToString()));
                    grdConta.DataSource = dtCon;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cta Bancária: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaCtaBancaria()
        {
            if (!String.IsNullOrEmpty(txtidCtaBancaria.Text))
            {

                base.BuscaObjeto();

                CtaBancaria oCtaBancaria = new CtaBancaria();
                oCtaBancaria.idCtaBancaria = EmcResources.cInt(txtidCtaBancaria.Text);
                oCtaBancaria.codEmpresa = codempresa;

                try
                {
                    CtaBancariaRN CtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                    oCtaBancaria = CtaBancariaRN.ObterPor(oCtaBancaria);

                    if (oCtaBancaria.idCtaBancaria == 0)
                    {
                        DialogResult result = MessageBox.Show("Conta Bancaria não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }

                    }
                    else
                    {
                        montaTela(oCtaBancaria);
                        AtivaEdicao();
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Conta Bancária: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
          
        }
       
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtidCtaBancaria.Enabled = true;
            txtidCtaBancaria.Focus();
        }
        
        public override void SalvaObjeto()
        {
            try
            {
                CtaBancaria oCtaBancaria = new CtaBancaria();
                CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia,codempresa);

                
                oCtaBancaria = montaCtaBancaria();
                
                oCtaBancaria.dataFechamento = DateTime.Parse("01/01/0001");
                //oCtaBancaria.dataFechamento = DateTime.Parse(null);
                if (verificaCtaBancaria(oCtaBancaria))
                {
                    oCtaBancariaRN.Salvar(oCtaBancaria);

                    LimpaCampos();
                    montaTela(oCtaBancaria);
                    AtualizaGrid();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Bancaria: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }
       
        public override void AtualizaObjeto()
        {
            try
            {
                CtaBancaria oCtaBancaria = new CtaBancaria();
                CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao,objOcorrencia,codempresa);

                oCtaBancaria = montaCtaBancaria();


                if (verificaCtaBancaria(oCtaBancaria))
                {

                    oCtaBancariaRN.Atualizar(oCtaBancaria);

                    AtualizaGrid();
                    LimpaCampos();
                    //MessageBox.Show("CtaBancaria atualizado com sucesso");
                    CancelaOperacao();

                }
                //else MessageBox.Show("Atualização cancelada");
                montaTela(oCtaBancaria);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Bancaria: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.AtualizaObjeto();
        }
       
        public override void ExcluiObjeto()
        {
            try
            {
                CtaBancaria oCtaBancaria = new CtaBancaria();
                CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao,objOcorrencia,codempresa);
                oCtaBancaria = montaCtaBancaria();

                if (verificaCtaBancaria(oCtaBancaria))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Conta Bancaria ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oCtaBancariaRN.Excluir(oCtaBancaria);

                        LimpaCampos();
                        MessageBox.Show("Conta Bancaria excluido!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Bancaria: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }
        
        public override void ImprimeObjeto()
        {
            //base.ImprimeObjeto();

            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCtaBancaria ofrm = new Relatorios.relCtaBancaria(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Cta Bancária : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

#endregion

#region "Tratamentos para buttons e texts**************************************************************************************"
        
        private void txtidCtaBancaria_Validating(object sender, CancelEventArgs e)
        {
            BuscaCtaBancaria();
        }
        
#endregion

#region "metodos da dbgrid*******************************************************************************************"
        
        private void grdConta_DoubleClick(object sender, EventArgs e)
        {
            txtidCtaBancaria.Text = grdConta.Rows[grdConta.CurrentRow.Index].Cells["idctabancaria"].Value.ToString();
            txtidCtaBancaria.Focus();
            SendKeys.Send("{TAB}");
            BuscaCtaBancaria();
            AtivaEdicao();
        }
       
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            CtaBancariaRN objConta = new CtaBancariaRN(Conexao,objOcorrencia,codempresa);
            CtaBancaria oConta = new CtaBancaria();
            oConta.codEmpresa = codempresa;

            grdConta.DataSource = objConta.ListaCtaBancaria(oConta);

        }


#endregion

     



    }
}
