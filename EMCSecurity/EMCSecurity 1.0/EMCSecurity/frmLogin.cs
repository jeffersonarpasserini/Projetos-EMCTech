using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;

namespace EMCSecurity
{
    public partial class frmLogin : Form
    {
        public ConectaBancoMySql Conexao;
        private string[] Resposta = new string[7];
        public virtual string[] frmParametros { get; set; }
        
        public frmLogin()
        {
            InitializeComponent();
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            btnCancela.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            Usuario oUser = new Usuario();
            UsuarioBLL oUserBLL = new UsuarioBLL(Conexao);

            oUser.nome = txtUsuario.Text.Trim();
            oUser = oUserBLL.ObterPor(oUser);
           
            UsuarioEmpresaRN oUserEmp = new UsuarioEmpresaRN(Conexao);
            cboEmpresas.DataSource = oUserEmp.ListaUsuarioEmpresa(oUser.idUsuario);
            cboEmpresas.DisplayMember = "razaosocial";
            cboEmpresas.ValueMember = "idempresa";

            txtSenha.Focus();

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            
            Usuario oUser = new Usuario();
            UsuarioBLL oUserBLL = new UsuarioBLL(Conexao);
            ControleLoginRN oCtrLoginRN = new ControleLoginRN(Conexao);
            Login oLogin = new Login();

            oUser.nome = txtUsuario.Text.Trim();
            Criptografia oCripto = new Criptografia();
            oUser.senha = oCripto.Encrypt(txtSenha.Text.Trim());

            oUser = oUserBLL.ValidaSenha(oUser);
            if (oUser.validado)
            {
                oLogin.idUsuario = oUser.idUsuario;
                oLogin.nivelAcesso = oUser.nivelacesso;
                oLogin.nome = oUser.nome;
                oLogin.dtaLogin = DateTime.Now;
                oLogin.macAddress = "";

                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa= Convert.ToInt32(cboEmpresas.SelectedValue);

                Ocorrencia oOcorrencia = new Ocorrencia();
                EmpresaRN oEmpRN = new EmpresaRN(Conexao,oOcorrencia, oEmpresa.idEmpresa);
                oEmpresa = oEmpRN.ObterPor(oEmpresa);

                oLogin.idEmpresa = oEmpresa.idEmpresa;
                oLogin.empMaster = oEmpresa.empMaster.idEmpresa;
                oLogin.nomeEmpresa = oEmpresa.razaoSocial;

                oLogin = oCtrLoginRN.gravaLogin(oLogin);

                if (oLogin.seqLogin > 0)
                {
                    btnLogar.DialogResult = DialogResult.OK;

                    Resposta[0] = oLogin.seqLogin.ToString();
                    Resposta[1] = oLogin.idUsuario.ToString();
                    Resposta[2] = oLogin.nome;
                    Resposta[3] = oLogin.nivelAcesso;
                    Resposta[4] = oLogin.idEmpresa.ToString();
                    Resposta[5] = oEmpresa.razaoSocial;
                    Resposta[6] = oEmpresa.empMaster.idEmpresa.ToString();

                    this.frmParametros = Resposta;
                    this.Hide();
                    
                }
            }
            else
            {
                MessageBox.Show("Usuário ou senha invalida", "EMCLogin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnCancela.DialogResult = DialogResult.Cancel;
                this.frmParametros = Resposta;
            }

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Conexao.fechar();
        }
    }
}
