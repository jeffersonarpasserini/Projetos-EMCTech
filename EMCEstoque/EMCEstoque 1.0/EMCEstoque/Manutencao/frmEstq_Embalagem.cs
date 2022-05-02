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
    public partial class frmEstq_Embalagem : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Embalagem";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_Embalagem(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Embalagem()
        {
            InitializeComponent();
        }

       
        private void frmEstq_Embalagem_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Embalagem";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
        private Estq_Embalagem montaEstq_Embalagem()
        {
            Estq_Embalagem oEstq_Embalagem = new Estq_Embalagem();
            oEstq_Embalagem.descricao = txtDescricao.Text;
            oEstq_Embalagem.quantidade = EmcResources.cDouble(txtQuantidade.Value.ToString());

            Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
            oUnidade.idestq_produto_unidade = EmcResources.cInt(cboIdUnidade.SelectedValue.ToString());

            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oUnidade = oUnidadeRN.ObterPor(oUnidade);

            oEstq_Embalagem.unidade = oUnidade;

            return oEstq_Embalagem;
        }
        private void montaTela(Estq_Embalagem oEstq_Embalagem)
        {
            txtIdEstq_Embalagem.Text = oEstq_Embalagem.idEstq_Embalagem.ToString();
            txtDescricao.Text = oEstq_Embalagem.descricao;
            txtQuantidade.Text = oEstq_Embalagem.quantidade.ToString();
            cboIdUnidade.SelectedValue = oEstq_Embalagem.unidade.idestq_produto_unidade.ToString();
            
            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Embalagem.idEstq_Embalagem.ToString();
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
                psqEmbalagem ofrm = new psqEmbalagem(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdEstq_Embalagem.Enabled = true;
                    txtIdEstq_Embalagem.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtIdEstq_Embalagem.Focus();
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

            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            cboIdUnidade.DataSource = oUnidadeRN.ListaEstq_Produto_Unidade();
            cboIdUnidade.ValueMember = "idestq_produto_unidade";
            cboIdUnidade.DisplayMember = "unidade_abreviatura";

            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_Embalagem oEstq_Embalagem = new Estq_Embalagem();
                Estq_EmbalagemRN oEstq_EmbalagemBLL = new Estq_EmbalagemRN(Conexao, objOcorrencia,codempresa);
                oEstq_Embalagem = montaEstq_Embalagem();

                oEstq_EmbalagemBLL.Salvar(oEstq_Embalagem);
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
                Estq_Embalagem oEstq_Embalagem = new Estq_Embalagem();
                Estq_EmbalagemRN oEstq_EmbalagemBLL = new Estq_EmbalagemRN(Conexao, objOcorrencia,codempresa);
                oEstq_Embalagem = montaEstq_Embalagem();
                oEstq_Embalagem.idEstq_Embalagem = EmcResources.cInt(txtIdEstq_Embalagem.Text);

                oEstq_EmbalagemBLL.Atualizar(oEstq_Embalagem);
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
                Estq_Embalagem oEstq_Embalagem = new Estq_Embalagem();
                Estq_EmbalagemRN oEstq_EmbalagemBLL = new Estq_EmbalagemRN(Conexao, objOcorrencia,codempresa);
                oEstq_Embalagem = montaEstq_Embalagem();
                oEstq_Embalagem.idEstq_Embalagem = EmcResources.cInt(txtIdEstq_Embalagem.Text);

                oEstq_EmbalagemBLL.Excluir(oEstq_Embalagem);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaEmbalagem()
        {
            if (!String.IsNullOrEmpty(txtIdEstq_Embalagem.Text))
            {

                Estq_Embalagem oEstq_Embalagem = new Estq_Embalagem();
                try
                {
                    Estq_EmbalagemRN Estq_EmbalagemBLL = new Estq_EmbalagemRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Embalagem = montaEstq_Embalagem();
                    oEstq_Embalagem.idEstq_Embalagem = EmcResources.cInt(txtIdEstq_Embalagem.Text);

                    oEstq_Embalagem = Estq_EmbalagemBLL.ObterPor(oEstq_Embalagem);

                    if (String.IsNullOrEmpty(oEstq_Embalagem.descricao))
                    {
                        DialogResult result = MessageBox.Show("Embalagem não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Embalagem);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Embalagem: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
 
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Embalagem_DoubleClick(object sender, EventArgs e)
        {
            txtIdEstq_Embalagem.Text = grdEstq_Embalagem.Rows[grdEstq_Embalagem.CurrentRow.Index].Cells["idEstq_Embalagem"].Value.ToString();
            txtIdEstq_Embalagem.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            try
            {

                //carrega a grid com os ceps cadastrados
                Estq_EmbalagemRN objEstq_Embalagem = new Estq_EmbalagemRN(Conexao, objOcorrencia, codempresa);
                grdEstq_Embalagem.DataSource = objEstq_Embalagem.ListaEstq_Embalagem();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMCEstoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion


        private void txtIdEstq_Embalagem_Validating(object sender, CancelEventArgs e)
        {
            BuscaEmbalagem();
        }


    }
}
