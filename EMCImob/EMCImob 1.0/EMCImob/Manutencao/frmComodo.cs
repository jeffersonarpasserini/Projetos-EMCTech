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
using EMCSecurityModel;
using EMCSecurity;

namespace EMCImob
{
    public partial class frmComodo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmComodo";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmComodo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmComodo()
        {
            InitializeComponent();
        }

        private void frmComodo_Activated(object sender, EventArgs e)
        {

        }
        private void frmComodo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "comodos";

            AtualizaGrid();
            this.ActiveControl = txtIdComodo;
            CancelaOperacao();
        }
        #endregion
        #region "metodos para tratamento das informacoes"

        private Boolean verificaComodo(Comodo oComodo)
        {
            ComodoRN oComodoRN = new ComodoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oComodoRN.VerificaDados(oComodo);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Comodo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Comodo montaComodo()
        {
            Comodo oComodo = new Comodo();
            oComodo.descricao = txtDescricao.Text;

            return oComodo;
        }

        private void montaTela(Comodo oComodo)
        {
            txtDescricao.Text = oComodo.descricao;
            txtIdComodo.Text = oComodo.idComodos.ToString();
            txtDescricao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oComodo.idComodos.ToString();
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
            txtIdComodo.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdComodo.Enabled = false;
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
            //base.BuscaObjeto();
            try
            {
                psqComodo ofrm = new psqComodo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdComodo.Enabled = true;
                    txtIdComodo.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtIdComodo.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaComodo()
        {
            if (!String.IsNullOrEmpty(txtIdComodo.Text))
            {

                Comodo oComodo = new Comodo();
                try
                {
                    ComodoRN ComodoBLL = new ComodoRN(Conexao, objOcorrencia, codempresa);

                    oComodo = montaComodo();
                    oComodo.idComodos = Convert.ToInt32(txtIdComodo.Text);

                    oComodo = ComodoBLL.ObterPor(oComodo);

                    if (String.IsNullOrEmpty(oComodo.descricao))
                    {
                        DialogResult result = MessageBox.Show("Comodo não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        //txtidComodo.Text = oComodo.idComodo;
                        montaTela(oComodo);
                        AtivaEdicao();
                        txtDescricao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Comodo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Comodo oComodo = new Comodo();
                ComodoRN oComodoBLL = new ComodoRN(Conexao, objOcorrencia, codempresa);
                oComodo = montaComodo();

                oComodoBLL.Salvar(oComodo);
                AtualizaGrid();
                CancelaOperacao();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Comodo oComodo = new Comodo();
                ComodoRN oComodoBLL = new ComodoRN(Conexao, objOcorrencia, codempresa);
                oComodo = montaComodo();
                oComodo.idComodos = Convert.ToInt32(txtIdComodo.Text);

                oComodoBLL.Atualizar(oComodo);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }

        }

        public override void ExcluiObjeto()
        {
            try
            {
                Comodo oComodo = new Comodo();
                ComodoRN oComodoBLL = new ComodoRN(Conexao, objOcorrencia, codempresa);
                oComodo = montaComodo();
                oComodo.idComodos = Convert.ToInt32(txtIdComodo.Text);

                oComodoBLL.Excluir(oComodo);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }

        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relComodo ofrm = new Relatorios.relComodo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdComodo_DoubleClick(object sender, EventArgs e)
        {
            txtIdComodo.Text = grdComodo.Rows[grdComodo.CurrentRow.Index].Cells["idcomodos"].Value.ToString();
            BuscaComodo();
            //BuscaObjeto();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Comodos cadastrados
            ComodoRN objComodo = new ComodoRN(Conexao, objOcorrencia, codempresa);
            grdComodo.DataSource = objComodo.ListaComodo();
            txtDescricao.Focus();
        }


        #endregion


        private void txtIdComodo_Validating(object sender, CancelEventArgs e)
        {
            BuscaComodo();
            //   BuscaObjeto();
        }

    }
}
