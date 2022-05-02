using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCEstoque
{
    public partial class frmEstq_Familia : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Familia";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_Familia(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Familia()
        {
            InitializeComponent();
        }

        private void frmEstq_Familia_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Familia_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Familia";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
        private Estq_Familia montaEstq_Familia()
        {
            Estq_Familia oEstq_Familia = new Estq_Familia();
            oEstq_Familia.descricao = txtDescricao.Text;

            return oEstq_Familia;
        }
        private void montaTela(Estq_Familia oEstq_Familia)
        {
            txtidEstq_Familia.Text = oEstq_Familia.idestq_familia.ToString();
            txtDescricao.Text = oEstq_Familia.descricao;
            

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Familia.idestq_familia.ToString();
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
            txtDescricao.Focus();
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
            try
            {
                psqFamilia ofrm = new psqFamilia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_Familia.Enabled = true;
                    txtidEstq_Familia.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_Familia.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                Estq_Familia oEstq_Familia = new Estq_Familia();
                Estq_FamiliaRN oEstq_FamiliaBLL = new Estq_FamiliaRN(Conexao, objOcorrencia,codempresa);
                oEstq_Familia = montaEstq_Familia();

                oEstq_FamiliaBLL.Salvar(oEstq_Familia);
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
                Estq_Familia oEstq_Familia = new Estq_Familia();
                Estq_FamiliaRN oEstq_FamiliaBLL = new Estq_FamiliaRN(Conexao, objOcorrencia,codempresa);
                oEstq_Familia = montaEstq_Familia();
                oEstq_Familia.idestq_familia = Convert.ToInt32(txtidEstq_Familia.Text);

                oEstq_FamiliaBLL.Atualizar(oEstq_Familia);
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
                Estq_Familia oEstq_Familia = new Estq_Familia();
                Estq_FamiliaRN oEstq_FamiliaBLL = new Estq_FamiliaRN(Conexao, objOcorrencia,codempresa);
                oEstq_Familia = montaEstq_Familia();
                oEstq_Familia.idestq_familia = Convert.ToInt32(txtidEstq_Familia.Text);

                oEstq_FamiliaBLL.Excluir(oEstq_Familia);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }


        public void BuscaFamilia()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Familia.Text))
            {

                Estq_Familia oEstq_Familia = new Estq_Familia();
                try
                {
                    Estq_FamiliaRN Estq_FamiliaBLL = new Estq_FamiliaRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Familia = montaEstq_Familia();
                    oEstq_Familia.idestq_familia = Convert.ToInt32(txtidEstq_Familia.Text);

                    oEstq_Familia = Estq_FamiliaBLL.ObterPor(oEstq_Familia);

                    if (String.IsNullOrEmpty(oEstq_Familia.descricao))
                    {
                        DialogResult result = MessageBox.Show("Família de Produto não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Familia);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Familia: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Familia_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_Familia.Text = grdEstq_Familia.Rows[grdEstq_Familia.CurrentRow.Index].Cells["idEstq_Familia"].Value.ToString();
            txtidEstq_Familia.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Estq_FamiliaRN objEstq_Familia = new Estq_FamiliaRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Familia.DataSource = objEstq_Familia.ListaEstq_Familia();
        }


        #endregion


        private void txtidEstq_Familia_Validating(object sender, CancelEventArgs e)
        {
            BuscaFamilia();
        }



    }
}
