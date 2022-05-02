using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCSecurityModel;
using EMCSecurityRN;
using EMCLibrary;

namespace EMCSecurity

{
    public partial class frmAplicativo : EMCLibrary.EMCForm
    {

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public frmAplicativo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql parConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = parConexao;
            InitializeComponent();
        }

        #region "metodos do form"


        private void frmAplicativo_Activated(object sender, EventArgs e)
        {


        }
        private void frmAplicativo_Load(object sender, EventArgs e)
        {

            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = "EMCSecurity";
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmAplicativo";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "sect_aplicativo";

            AtualizaGrid();
            CancelaOperacao();
            
        }
        #endregion
        
        #region "metodos para tratamento das informacoes"
        private Aplicativo montaAplicativo()
        {
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = txtNome.Text;
            oAplicativo.descricao = txtDescricao.Text;
                        
            return oAplicativo;
        }
        private void montaTela(Aplicativo oAplicativo)
        {
            txtDescricao.Text = oAplicativo.descricao;
            txtNome.Text = oAplicativo.nome;
            
            objOcorrencia.chaveidentificacao = oAplicativo.nome.ToString();
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
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }
        public override void BuscaObjeto()
        {
            if (txtNome.Text.Trim().Length > 0)
            {
                Aplicativo oAplicativo = new Aplicativo();
                try
                {

                    AplicativoRN aplicativoBLL = new AplicativoRN(Conexao, objOcorrencia, codempresa);
                    oAplicativo.nome = txtNome.Text.ToUpper();
                    oAplicativo = aplicativoBLL.ObterPor(oAplicativo);


                    if (String.IsNullOrEmpty(oAplicativo.descricao))
                    {

                        DialogResult result = MessageBox.Show("Aplicação não Cadastrada, deseja incluir?", "EMCSecurity", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        
                       
                    }
                    else
                    {
                        montaTela(oAplicativo);
                        AtivaEdicao();
                    }

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Aplicativo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtNome.Focus();

            }
            AtualizaGrid();


        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtNome.Focus();
            objOcorrencia.chaveidentificacao = "";

        }

        public override void SalvaObjeto()
        {
            try
            {

                Aplicativo oAplicativo = new Aplicativo();
                AplicativoRN oAplicativoBLL = new AplicativoRN(Conexao, objOcorrencia, codempresa);
                oAplicativo = montaAplicativo();

                oAplicativoBLL.Salvar(oAplicativo);
                AtualizaGrid();
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
                Aplicativo oAplicativo = new Aplicativo();
                AplicativoRN oAplicativoBLL = new AplicativoRN(Conexao, objOcorrencia, codempresa);
                oAplicativo = montaAplicativo();
                

                oAplicativoBLL.Atualizar(oAplicativo);
                AtualizaGrid();
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
                Aplicativo oAplicativo = new Aplicativo();
                AplicativoRN oAplicativoBLL = new AplicativoRN(Conexao, objOcorrencia, codempresa);
                
                oAplicativo = montaAplicativo();
                

                oAplicativoBLL.Excluir(oAplicativo);
                AtualizaGrid();
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

        private void grdAplicativo_DoubleClick(object sender, EventArgs e)
        {
            txtNome.Text = grdAplicativo.Rows[grdAplicativo.CurrentRow.Index].Cells["modulo"].Value.ToString();

            BuscaObjeto();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Aplicativos cadastrados
            AplicativoRN objAplicativo = new AplicativoRN(Conexao, objOcorrencia, codempresa);
            grdAplicativo.DataSource = objAplicativo.ListaAplicativo();
        }


        #endregion

        #region "Eventos"

        private void txtNome_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text))
            {
                //MessageBox.Show("Código da Empresa deve ser preenchido", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                BuscaObjeto();
            }
        }
         #endregion
           
    }
}
