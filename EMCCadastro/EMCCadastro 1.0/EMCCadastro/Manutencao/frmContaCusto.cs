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
using EMCSecurityRN;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmContaCusto : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmContaCusto";
        private const string nomeAplicativo = "EMCCadastro";       
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        //Variaveis de Configuração do Formato da Conta Custo
        int vTamMaximo = 0; //tamanho da conta custo no nivel 7
        int vNroNiveis = 0; // numero de niveis
        int vTamNV1 = 0; // tamanho no nivel 1
        int vTamNV2 = 0; // tamanho no nivel 2
        int vTamNV3 = 0; // tamanho no nivel 3
        int vTamNV4 = 0; // tamanho no nivel 4
        int vTamNV5 = 0; // tamanho no nivel 5
        int vTamNV6 = 0; // tamanho no nivel 6
        int vTamNV7 = 0; // tamanho no nivel 7
        string vMascara = "";


        public frmContaCusto()
        {
            InitializeComponent();
        }
        public frmContaCusto(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmContaCusto_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "contacusto";

            Parametro oParametro = new Parametro();
            ParametroRN oParametroRN = new ParametroRN(Conexao,objOcorrencia,codempresa);
            //verifica o parametro considera data valida para vencimento de parcelas.
            vTamMaximo = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAMANHO_CONTACUSTO"));
            vNroNiveis = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "NRONIVEIS_CONTACUSTO"));
            vTamNV1 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV1_CONTACUSTO"));
            vTamNV2 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV2_CONTACUSTO"));
            vTamNV3 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV3_CONTACUSTO"));
            vTamNV4 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV4_CONTACUSTO"));
            vTamNV5 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV5_CONTACUSTO"));
            vTamNV6 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV6_CONTACUSTO"));
            vTamNV7 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV7_CONTACUSTO"));

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia,codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;


            Empresa oEmpresa = new Empresa();
            EmpresaRN oEmpRN = new EmpresaRN(Conexao,objOcorrencia,codempresa);
            cboEmpresa.DataSource = oEmpRN.Lista();
            cboEmpresa.ValueMember = "idempresa";
            cboEmpresa.DisplayMember = "razaosocial";
            
            AtualizaGrid();
            //carrega os estados para a combo a partir de um enum

            this.ActiveControl = txtCodigoConta;
            CancelaOperacao();

        }


       #region "metodos para tratamento das informacoes*********************************************************************"
       
        private Boolean verificaContaCusto(ContaCusto oContaCusto)
        {
            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oContaCustoRN.VerificaDados(oContaCusto);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Custo: "+erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
       
        private ContaCusto montaContaCusto()
        {
            ContaCusto oContaCusto = new ContaCusto();
            try
            {
                oContaCusto.codigoConta = txtCodigoConta.Text.Trim();
                oContaCusto.descricao = txtDescricao.Text;
                

                if (txtCodigoConta.Text.Trim().Length == vTamMaximo)
                    oContaCusto.tipoConta = "A";
                else
                    oContaCusto.tipoConta = "S";
            
                ContaCusto oCtaAcima = new ContaCusto();
                ContaCustoRN oCtaAcimaRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
            
                //Só realiza a busca se codigo for diferente de nivel 1
                if (oContaCusto.codigoConta.Trim().Length>1)
                    oCtaAcima = oCtaAcimaRN.buscaContaAcima(oContaCusto);
            
                oContaCusto.contaAcima = oCtaAcima;
            
                Empresa oFilial = new Empresa();
                if (txtCodigoConta.Text.Trim().Length == vTamMaximo)
                {
                    if (cboEmpresa.SelectedValue != null)
                    {
                        EmpresaRN oEmp = new EmpresaRN(Conexao, objOcorrencia,codempresa);
                        oFilial.idEmpresa = EmcResources.cInt(cboEmpresa.SelectedValue.ToString());
                        oFilial = oEmp.ObterPor(oFilial);
                    }
                }
                else
                {
                    //Conta sintetica não precisa de filial
                }
                oContaCusto.filial = oFilial;
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message);
            }
            return oContaCusto;
        }
     
        private void montaTela(ContaCusto oContaCusto)
        {
           
            txtCodigoConta.Text = oContaCusto.codigoConta;
            txtDescricao.Text = oContaCusto.descricao;
            txtIdContaCusto.Text = oContaCusto.idContaCusto.ToString();

            cboEmpresa.SelectedValue = oContaCusto.filial.idEmpresa;

            objOcorrencia.chaveidentificacao = oContaCusto.idContaCusto.ToString();

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
            txtCodigoConta.Enabled = false;
        }
       
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
   
        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
      
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtCodigoConta.Enabled = true;
            txtCodigoConta.Focus();
        }
       
        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia,true);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtCodigoConta.Text = "";
                    //txtIdContaCusto.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtCodigoConta.Enabled = true;
                    txtCodigoConta.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
                    txtIdContaCusto.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtCodigoConta.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Conta Custo: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        
        public override void LimpaCampos()
        {
            base.LimpaCampos();
           
            objOcorrencia.chaveidentificacao = "";
            txtCodigoConta.Enabled = true;
            txtCodigoConta.Focus();

        }
      
        public override void SalvaObjeto()
        {
            try
            {
                ContaCusto oContaCusto = new ContaCusto();
                ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);

                oContaCusto = montaContaCusto();
               
                
                if (verificaContaCusto(oContaCusto))
                {
                    oContaCustoRN.Salvar(oContaCusto);
                    AtualizaGrid();
                    LimpaCampos();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Custo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }
       
        public override void AtualizaObjeto()
        {
            try
            {
                ContaCusto oContaCusto = new ContaCusto();
                ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
                oContaCusto = montaContaCusto();
                oContaCusto.idContaCusto = Convert.ToInt32(txtIdContaCusto.Text);

                if (verificaContaCusto(oContaCusto))
                {
                    oContaCustoRN.Atualizar(oContaCusto);
                    AtualizaGrid();
                    LimpaCampos();
                    MessageBox.Show("Conta Custo atualizada com sucesso");
                }
               // else MessageBox.Show("Atualização cancelada");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Custo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
        }
       
        public override void ExcluiObjeto()
        {
            try
            {
                ContaCusto oContaCusto = new ContaCusto();
                ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
                oContaCusto = montaContaCusto();
                oContaCusto.idContaCusto = Convert.ToInt32(txtIdContaCusto.Text);

                if (verificaContaCusto(oContaCusto))
                {
                    oContaCustoRN.Excluir(oContaCusto);
                    AtualizaGrid();
                    LimpaCampos();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Conta Custo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.ExcluiObjeto();
        }
       
        public void buscaContaCusto()
        {
             
            if (!String.IsNullOrEmpty(txtCodigoConta.Text))
            {
                ContaCusto oContaCusto = new ContaCusto();
                oContaCusto.codigoConta = txtCodigoConta.Text;

                try
                {
                    ContaCustoRN ContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                    oContaCusto = montaContaCusto();

                    oContaCusto = ContaCustoRN.ObterPor(oContaCusto);

                    if (oContaCusto.codigoConta == null)
                    {
                        DialogResult result = MessageBox.Show("Conta Custo não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                        montaTela(oContaCusto);
                        AtivaEdicao();

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Conta Custo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        public override void ImprimeObjeto()
        {

            try
            {
                //base.ImprimeObjeto();
                Relatorios.relContaCusto ofrm = new Relatorios.relContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Conta Custo: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

#endregion

#region "Tratamentos para texts**************************************************************************************"
       
        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            buscaContaCusto();
        }

#endregion
#region "metodos da dbgrid*******************************************************************************************"

        private void grdContaCusto_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoConta.Enabled = true;
            txtCodigoConta.Text = grdContaCusto.Rows[grdContaCusto.CurrentRow.Index].Cells["codigoConta"].Value.ToString();
            txtCodigoConta.Focus();
            SendKeys.Send("{TAB}");
        }
       
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            ContaCustoRN objContaCusto = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
            //ContaCusto oContaCusto = new ContaCusto();
            //oContaCusto = montaContaCusto();
          
            grdContaCusto.DataSource = objContaCusto.ListaContaCusto();
            
        }


#endregion
    }
}
