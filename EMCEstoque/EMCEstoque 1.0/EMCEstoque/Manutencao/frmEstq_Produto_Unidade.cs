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
    public partial class frmEstq_Produto_Unidade : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Produto_Unidade";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_Produto_Unidade(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Produto_Unidade()
        {
            InitializeComponent();
        }

        private void frmEstq_Produto_Unidade_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Produto_Unidade_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Produto_Unidade";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Estq_Produto_Unidade montaEstq_Produto_Unidade()
        {
            Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
            oEstq_Produto_Unidade.unidade_descricao = txtUnidade_Descricao.Text;
            oEstq_Produto_Unidade.unidade_abreviatura = txtUnidade_Abreviatura.Text;

            return oEstq_Produto_Unidade;
        }
        private void montaTela(Estq_Produto_Unidade oEstq_Produto_Unidade)
        {
            txtidEstq_Produto_Unidade.Text = oEstq_Produto_Unidade.idestq_produto_unidade.ToString();
            txtUnidade_Descricao.Text = oEstq_Produto_Unidade.unidade_descricao;
            txtUnidade_Abreviatura.Text = oEstq_Produto_Unidade.unidade_abreviatura;
            

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Produto_Unidade.idestq_produto_unidade.ToString();
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
            txtUnidade_Descricao.Focus();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidEstq_Produto_Unidade.Enabled = true;
            txtidEstq_Produto_Unidade.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqProduto_Unidade ofrm = new psqProduto_Unidade(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_Produto_Unidade.Enabled = true;
                    txtidEstq_Produto_Unidade.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_Produto_Unidade.Focus();
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

                Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                Estq_Produto_UnidadeRN oEstq_Produto_UnidadeBLL = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Unidade = montaEstq_Produto_Unidade();

                oEstq_Produto_UnidadeBLL.Salvar(oEstq_Produto_Unidade);
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
                Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                Estq_Produto_UnidadeRN oEstq_Produto_UnidadeBLL = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Unidade = montaEstq_Produto_Unidade();
                oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(txtidEstq_Produto_Unidade.Text);

                oEstq_Produto_UnidadeBLL.Atualizar(oEstq_Produto_Unidade);
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
                Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                Estq_Produto_UnidadeRN oEstq_Produto_UnidadeBLL = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Unidade = montaEstq_Produto_Unidade();
                oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(txtidEstq_Produto_Unidade.Text);

                oEstq_Produto_UnidadeBLL.Excluir(oEstq_Produto_Unidade);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaProdutoUnidade()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Produto_Unidade.Text))
            {

                Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
                try
                {
                    Estq_Produto_UnidadeRN Estq_Produto_UnidadeBLL = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Produto_Unidade = montaEstq_Produto_Unidade();
                    oEstq_Produto_Unidade.idestq_produto_unidade = Convert.ToInt32(txtidEstq_Produto_Unidade.Text);

                    oEstq_Produto_Unidade = Estq_Produto_UnidadeBLL.ObterPor(oEstq_Produto_Unidade);

                    if (String.IsNullOrEmpty(oEstq_Produto_Unidade.unidade_descricao))
                    {
                        DialogResult result = MessageBox.Show("Unidade de Produto não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Produto_Unidade);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto_Unidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Porduto_Unidade_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_Produto_Unidade.Text = grdEstq_Produto_Unidade.Rows[grdEstq_Produto_Unidade.CurrentRow.Index].Cells["idEstq_Produto_Unidade"].Value.ToString();
            txtidEstq_Produto_Unidade.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Estq_Produto_UnidadeRN objEstq_Produto_Unidade = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Produto_Unidade.DataSource = objEstq_Produto_Unidade.ListaEstq_Produto_Unidade();
        }


        #endregion


        private void txtidEstq_Produto_Unidade_Validating(object sender, CancelEventArgs e)
        {
            BuscaProdutoUnidade();
        }


    }
}
