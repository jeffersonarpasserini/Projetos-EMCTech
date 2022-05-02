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
    public partial class frmUsuario : EMCLibrary.EMCForm
    {
        private const string descricao = "frmUsuario";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmUsuario()
        {
            InitializeComponent();
        }

        public frmUsuario(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Usuario";

            //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("0 - Administrador", "0"));
            arr.Add(new popCombo("1 - Diretor", "1"));
            arr.Add(new popCombo("2 - Gerente", "2"));
            arr.Add(new popCombo("3 - Encarregado", "3"));
            arr.Add(new popCombo("4 - Líder", "4"));
            arr.Add(new popCombo("5 - Operador", "5"));            
            cboNivelUsuario.DataSource = arr;
            cboNivelUsuario.DisplayMember = "nome";
            cboNivelUsuario.ValueMember = "valor";


            AtualizaGrid();
            this.ActiveControl = txtNome;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaUsuario(Usuario oUsuario)
        {
            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
            try
            {
                oUsuarioRN.VerificaDados(oUsuario);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Usuário: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Usuario montaUsuario()
        {

            Usuario oUsuario = new Usuario();

            if(txtConfirmaSenha.Text == txtSenha.Text)
            {
                oUsuario.nome = txtNome.Text;
                oUsuario.nomeCompleto = txtNomeCompleto.Text;

                Criptografia oCripto = new Criptografia();
                oUsuario.senha = oCripto.Encrypt(txtSenha.Text);

                oUsuario.nivelUsuario = EmcResources.cInt(cboNivelUsuario.SelectedValue.ToString());
                oUsuario.nivelacesso = "A";
            }
            else
            {
                MessageBox.Show("Senhas não conferem");
            }
                        

            return oUsuario;
        }

        private void montaTela(Usuario oUsuario)
        {
            
            txtIdUsuario.Text = oUsuario.idUsuario.ToString();
            txtNome.Text = oUsuario.nome;
            txtNomeCompleto.Text = oUsuario.nomeCompleto;
            txtSenha.Text = oUsuario.senha;
            cboNivelUsuario.SelectedValue = oUsuario.nivelUsuario.ToString();

           

            objOcorrencia.chaveidentificacao = oUsuario.idUsuario.ToString();


            txtNome.Enabled = true;
            txtNome.Focus();


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

            txtNome.Enabled = true;
            txtNome.Focus();

        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtNome.Enabled = true;
            objOcorrencia.chaveidentificacao = "";

            txtNome.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {/*
               // psqHistorico ofrm = new psqHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoCobranca.Text = "";

                }
                else
                {
                    txtIdHistorico.Enabled = true;
                    txtIdHistorico.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdHistorico.Focus();
                    SendKeys.Send("{TAB}");
                }*/
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Usuário: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaUsuario()
        {
            if (!String.IsNullOrEmpty(txtNome.Text))
            {
                Usuario oUsuario = new Usuario();
                oUsuario.nome = txtNome.Text;
                try
                {
                    UsuarioBLL usuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
                    oUsuario = usuarioRN.ObterPor(oUsuario);

                    if (oUsuario.idUsuario == 0)
                    {
                        DialogResult result = MessageBox.Show("Usuário não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtNome.Enabled = false;
                        txtNomeCompleto.Focus();
                    }
                    else
                    {
                        montaTela(oUsuario);
                        AtivaEdicao();
                        txtNomeCompleto.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Usuário: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            cboNivelUsuario.SelectedIndex = -1;
        }

        public override void SalvaObjeto()
        {
            try
            {
                Usuario oUsuario = new Usuario();
                UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);

                oUsuario = montaUsuario();

                if (verificaUsuario(oUsuario))
                {
                    oUsuarioRN.Salvar(oUsuario);

                    montaTela(oUsuario);
                    LimpaCampos();
                    txtNome.Focus();
                    AtualizaGrid();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Usuario oUsuario = new Usuario();
                UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);

                oUsuario = montaUsuario();
                oUsuario.idUsuario = EmcResources.cInt(txtIdUsuario.Text);


                if (verificaUsuario(oUsuario))
                {

                    oUsuarioRN.Atualizar(oUsuario);

                    LimpaCampos();
                    //MessageBox.Show("Historico atualizado com sucesso");
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oUsuario);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Usuario oUsuario = new Usuario();
                UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
                oUsuario = montaUsuario();
                oUsuario.idUsuario = EmcResources.cInt(txtIdUsuario.Text);

                if (verificaUsuario(oUsuario))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Usuário ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oUsuarioRN.Excluir(oUsuario);

                        LimpaCampos();
                        MessageBox.Show("Usuário excluido!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relHistorico ofrm = new Relatorios.relHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Usuário: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        #region "Tratamentos para buttons e texts**************************************************************************************"
        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            BuscaUsuario();
        }


        #endregion

        #region "metodos da dbgrid*******************************************************************************************"

        private void grdUsuario_DoubleClick(object sender, EventArgs e)
        {
            txtNome.Enabled = true;
            txtNome.Text = grdUsuario.Rows[grdUsuario.CurrentRow.Index].Cells["nome"].Value.ToString();
            txtNome.Focus();
            SendKeys.Send("{TAB}");
        }
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
            Usuario oUsuario = new Usuario();
            grdUsuario.DataSource = oUsuarioRN.ListaUsuario();

        }


        #endregion



    }
}
