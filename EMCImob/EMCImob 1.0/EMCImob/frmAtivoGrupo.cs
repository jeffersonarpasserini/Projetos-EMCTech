using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCImob
{
    public partial class frmAtivoGrupo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmAtivoGrupo";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

         public frmAtivoGrupo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmAtivoGrupo()
        {
            InitializeComponent();
        }

        private void frmAtivoGrupo_Activated(object sender, EventArgs e)
        {

        }
        private void frmAtivoGrupo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "ativogrupo";

            AtualizaGrid();
            this.ActiveControl = txtCodAtivoGrupo;
            CancelaOperacao();

        }

        #endregion


        #region "metodos para tratamento das informacoes"
        private AtivoGrupo montaAtivoGrupo()
        {
            AtivoGrupo oAtivoGrupo = new AtivoGrupo();
            oAtivoGrupo.Descricao = txtDescricao.Text;

            return oAtivoGrupo;
        }
        private void montaTela(AtivoGrupo oAtivoGrupo)
        {
            txtDescricao.Text = oAtivoGrupo.Descricao;
            txtCodAtivoGrupo.Text = oAtivoGrupo.CodAtivoGrupo.ToString();
            txtDescricao.Focus();

            objOcorrencia.chaveidentificacao = oAtivoGrupo.CodAtivoGrupo.ToString();

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
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDescricao.Focus();
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

            if (!String.IsNullOrEmpty(txtCodAtivoGrupo.Text))
            {

                AtivoGrupo oAtivoGrupo = new AtivoGrupo();
                try
                {
                    AtivoGrupoRN AtivoGrupoBLL = new AtivoGrupoRN(Conexao, objOcorrencia, codempresa);

                    oAtivoGrupo = montaAtivoGrupo();
                    oAtivoGrupo.CodAtivoGrupo = Convert.ToInt32(txtCodAtivoGrupo.Text);

                    oAtivoGrupo = AtivoGrupoBLL.ObterPor(oAtivoGrupo);

                    if (String.IsNullOrEmpty(oAtivoGrupo.Descricao))
                    {
                        DialogResult result = MessageBox.Show("Grupo não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        //txtidAtivoGrupo.Text = oAtivoGrupo.idAtivoGrupo;
                        montaTela(oAtivoGrupo);
                        txtDescricao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro AtivoGrupo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {

                AtivoGrupo oAtivoGrupo = new AtivoGrupo();
                AtivoGrupoRN oAtivoGrupoBLL = new AtivoGrupoRN(Conexao, objOcorrencia, codempresa);
                oAtivoGrupo = montaAtivoGrupo();

                oAtivoGrupoBLL.Salvar(oAtivoGrupo);
                AtualizaGrid();
                LimpaCampos();
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
                AtivoGrupo oAtivoGrupo = new AtivoGrupo();
                AtivoGrupoRN oAtivoGrupoBLL = new AtivoGrupoRN(Conexao, objOcorrencia, codempresa);
                oAtivoGrupo = montaAtivoGrupo();
                oAtivoGrupo.CodAtivoGrupo = Convert.ToInt32(txtCodAtivoGrupo.Text);

                oAtivoGrupoBLL.Atualizar(oAtivoGrupo);
                AtualizaGrid();
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
                AtivoGrupo oAtivoGrupo = new AtivoGrupo();
                AtivoGrupoRN oAtivoGrupoBLL = new AtivoGrupoRN(Conexao, objOcorrencia, codempresa);
                oAtivoGrupo = montaAtivoGrupo();
                oAtivoGrupo.CodAtivoGrupo = Convert.ToInt32(txtCodAtivoGrupo.Text);

                oAtivoGrupoBLL.Excluir(oAtivoGrupo);
                AtualizaGrid();
                LimpaCampos();
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
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Feriado: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region "metodos da dbgrid"

        private void grdAtivoGrupo_DoubleClick(object sender, EventArgs e)
        {
            txtCodAtivoGrupo.Text = grdAtivoGrupo.Rows[grdAtivoGrupo.CurrentRow.Index].Cells["idAtivoGrupos"].Value.ToString();

            BuscaObjeto();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os AtivoGrupos cadastrados
            AtivoGrupoRN objAtivoGrupo = new AtivoGrupoRN(Conexao, objOcorrencia, codempresa);
            grdAtivoGrupo.DataSource = objAtivoGrupo.ListaAtivoGrupo();
            txtDescricao.Focus();
        }


        #endregion


        private void txtIdAtivoGrupo_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

    }
}
