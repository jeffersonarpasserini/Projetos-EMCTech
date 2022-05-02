using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurityModel;
using EMCSecurityRN;
using System.Collections;

namespace EMCSecurity
{
    public partial class frmTrocaSenha : EMCLibrary.EMCForm
    {
       private const string descricao = "frmTrocaSenha";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmTrocaSenha()
        {
            InitializeComponent();
        }

        public frmTrocaSenha(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmTrocaSenha_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = descricao;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "usuario";

            this.ActiveControl = txtSenhaAtual;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaUsuario(Usuario oUsuario)
        {
            UsuarioBLL oUsuarioBLL = new UsuarioBLL(Conexao);
            try
            {
                oUsuarioBLL.VerificaDados(oUsuario);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Usuario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Usuario montaUsuario()
        {
            Criptografia oCripto = new Criptografia();
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(txtIdUsuario.Text);
            oUsuario.nome = txtNome.Text;
            oUsuario.senha = oCripto.Encrypt(txtSenhaAtual.Text);

            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao,objOcorrencia,codempresa);
            oUsuario = oUsuarioRN.ValidaSenha(oUsuario);

            if (oUsuario.validado)
            {
                if (txtConfirmaSenha.Text == txtNovaSenha.Text)
                {
                    //atualiza senha encriptada
                    oUsuario.senha = oCripto.Encrypt(txtNovaSenha.Text);
                }
                else
                {
                    Exception erro = new Exception("Nova Senha não confere");
                    throw(erro);
                }
            }
            else
            {
                Exception erro = new Exception("Usuario atual não validado");
                throw (erro);
            }


            return oUsuario;
        }

        private void montaTela()
        {
            try
            {
                Usuario oUsuarioTela = new Usuario();
                oUsuarioTela.idUsuario = EmcResources.cInt(usuario);

                UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao,objOcorrencia,codempresa);
                oUsuarioTela = oUsuarioRN.ObterPor(oUsuarioTela);

                txtIdUsuario.Text = oUsuarioTela.idUsuario.ToString();
                txtNome.Text = oUsuarioTela.nome;
                txtNomeCompleto.Text = oUsuarioTela.nomeCompleto;

                objOcorrencia.chaveidentificacao = oUsuarioTela.idUsuario.ToString();

                AtivaEdicao();
                travaBotao("btnExcluir");
                txtSenhaAtual.Focus();

            }
            catch(Exception oErro) 
            {
                MessageBox.Show("Erro :" + oErro.Message);
            }

          
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            //txtIdHistorico.Enabled = false;
        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, descricao, btnFlag))
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

            montaTela();         

        }

        public override void BuscaObjeto()
        {

        }

        public void BuscaUsuario()
        {
         
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

        }

        public override void SalvaObjeto()
        {
          
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Usuario oUsuario = new Usuario();
                UsuarioBLL oUsuarioBLL = new UsuarioBLL(Conexao, objOcorrencia, codempresa);

                oUsuario = montaUsuario();

                if (verificaUsuario(oUsuario))
                {

                    oUsuarioBLL.Atualizar(oUsuario);

                    LimpaCampos();

                }
                else MessageBox.Show("Atualização cancelada");
                montaTela();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message );
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
           
        }

        #endregion

        private void txtSenhaAtual_Validating(object sender, CancelEventArgs e)
        {
            txtNovaSenha.Focus();
        }

        private void txtNovaSenha_Validating(object sender, CancelEventArgs e)
        {
            txtConfirmaSenha.Focus();
        }


        #region "metodos da dbgrid*******************************************************************************************"



        #endregion

    }
}
