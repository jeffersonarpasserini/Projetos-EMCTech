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

//*** O codigo principal da tabela idestq_produto_lote esta oculto atras da imagem do código de barras ***//
namespace EMCEstoque
{
    public partial class frmEstq_Produto_Lote : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Produto_Lote";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
        Estq_Produto oProduto = new Estq_Produto();

        private string sitOperacao = "C";

        public frmEstq_Produto_Lote(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Estq_Produto oEstq_Produto)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            //recebendo o produto como parâmetro
            oProduto = oEstq_Produto;

            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Produto_Lote()
        {
            InitializeComponent();
        }


        private void frmEstq_Produto_Lote_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Produto_Lote";

            //carregando o nome do produto na label da tela
            lblProduto.Text = "PRODUTO: " + oProduto.idestq_produto + "-" + oProduto.descricao;


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_Produto_Lote montaEstq_Produto_Lote()
        {
            Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
            oEstq_Produto_Lote.loteproduto = txtLoteProduto.Text;
            oEstq_Produto_Lote.datavalidade = Convert.ToDateTime(txtDataValidade.Text);
            oEstq_Produto_Lote.descricao = txtDescricao.Text;

            Estq_Embalagem oEmbalagem = new Estq_Embalagem();
            Estq_EmbalagemRN oEmbalagemRN = new Estq_EmbalagemRN(Conexao, objOcorrencia, codempresa);

            oEmbalagem.idEstq_Embalagem = EmcResources.cInt(cboEmbalagem.SelectedValue.ToString());
            oEmbalagem = oEmbalagemRN.ObterPor(oEmbalagem);

            oEstq_Produto_Lote.embalagem = oEmbalagem;

            //Produto
            oEstq_Produto_Lote.Estq_Produto = oProduto;

            return oEstq_Produto_Lote;
        }
        private void montaTela(Estq_Produto_Lote oEstq_Produto_Lote)
        {
            txtidEstq_Produto_Lote.Text = oEstq_Produto_Lote.idEstq_Produto_lote.ToString();
            txtLoteProduto.Text = oEstq_Produto_Lote.loteproduto;
            txtDataValidade.Text = oEstq_Produto_Lote.datavalidade.ToString();
            txtDescricao.Text = oEstq_Produto_Lote.descricao;

            cboEmbalagem.SelectedValue = oEstq_Produto_Lote.embalagem.idEstq_Embalagem;
            txtUnidade.Text = oEstq_Produto_Lote.embalagem.unidade.unidade_abreviatura;
            txtQuantidade.Text = oEstq_Produto_Lote.embalagem.quantidade.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Produto_Lote.idEstq_Produto_lote.ToString();
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
            txtLoteProduto.Enabled = false;
            sitOperacao = "A";
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            if (sitOperacao != "I")
            {
            
                sitOperacao = "I";
                txtLoteProduto.Enabled = true;
                LimpaCampos();
            }
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            sitOperacao = "C";
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Produto_Lote.Text))
            {

                Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
                try
                {
                    Estq_Produto_LoteRN Estq_Produto_LoteBLL = new Estq_Produto_LoteRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Produto_Lote = montaEstq_Produto_Lote();
                    oEstq_Produto_Lote.idEstq_Produto_lote = Convert.ToInt32(txtidEstq_Produto_Lote.Text);

                    oEstq_Produto_Lote = Estq_Produto_LoteBLL.ObterPor(oEstq_Produto_Lote);

                    if (String.IsNullOrEmpty(oEstq_Produto_Lote.idEstq_Produto_lote.ToString()))
                    {
                        DialogResult result = MessageBox.Show("Lote de Produto não Cadastrado, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            sitOperacao = "I";
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Produto_Lote);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto_Lote: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscaObjeto(string pLoteProduto)
        {
            if  (!String.IsNullOrEmpty(pLoteProduto))
            {
                Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
                try
                {
                    Estq_Produto_LoteRN Estq_Produto_LoteBLL = new Estq_Produto_LoteRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Produto_Lote = montaEstq_Produto_Lote();
                    oEstq_Produto_Lote.idEstq_Produto_lote = 0;

                    oEstq_Produto_Lote = Estq_Produto_LoteBLL.ObterPor(oEstq_Produto_Lote);

                    if (String.IsNullOrEmpty(oEstq_Produto_Lote.ToString()) || oEstq_Produto_Lote.idEstq_Produto_lote == 0)
                    {
                        sitOperacao = "I";
                        AtivaInsercao();
                    }
                    else
                    {
                        montaTela(oEstq_Produto_Lote);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_LoteProduto: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            Estq_EmbalagemRN oEmbalagemRN = new Estq_EmbalagemRN(Conexao,objOcorrencia,codempresa);
            cboEmbalagem.DataSource = oEmbalagemRN.ListaEstq_Embalagem();
            cboEmbalagem.DisplayMember = "descricao";
            cboEmbalagem.ValueMember = "idestq_embalagem";

            objOcorrencia.chaveidentificacao = "";
            txtLoteProduto.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
                Estq_Produto_LoteRN oEstq_Produto_LoteBLL = new Estq_Produto_LoteRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Lote = montaEstq_Produto_Lote();

                oEstq_Produto_LoteBLL.Salvar(oEstq_Produto_Lote);
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
                Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
                Estq_Produto_LoteRN oEstq_Produto_LoteBLL = new Estq_Produto_LoteRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Lote = montaEstq_Produto_Lote();
                oEstq_Produto_Lote.idEstq_Produto_lote = Convert.ToInt32(txtidEstq_Produto_Lote.Text);

                oEstq_Produto_LoteBLL.Atualizar(oEstq_Produto_Lote);
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
                Estq_Produto_Lote oEstq_Produto_Lote = new Estq_Produto_Lote();
                Estq_Produto_LoteRN oEstq_Produto_LoteBLL = new Estq_Produto_LoteRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Lote = montaEstq_Produto_Lote();
                oEstq_Produto_Lote.idEstq_Produto_lote = Convert.ToInt32(txtidEstq_Produto_Lote.Text);

                oEstq_Produto_LoteBLL.Excluir(oEstq_Produto_Lote);
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

        private void grdEstq_Produto_Lote_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtidEstq_Produto_Lote.Text = grdEstq_Produto_Lote.Rows[grdEstq_Produto_Lote.CurrentRow.Index].Cells["idestq_produto_lote"].Value.ToString();
                BuscaObjeto();
                AtivaEdicao();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizaGrid()
        {
            try
            {

                //carrega a grid
                Estq_Produto_LoteRN objEstq_Produto_Lote = new Estq_Produto_LoteRN(Conexao, objOcorrencia, codempresa);
                grdEstq_Produto_Lote.DataSource = objEstq_Produto_Lote.ListaEstq_Produto_Lote(oProduto);
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_Produto_Lote_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        private void txtLoteProduto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtLoteProduto.Text))
                {
                    //verificando se já existe codigo interno cadastrado para o produto e o fornecedor digitados
                    BuscaObjeto(txtLoteProduto.Text);
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        private void cboEmbalagem_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboEmbalagem.SelectedIndex != -1 && cboEmbalagem.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Estq_Embalagem oEmbalagem = new Estq_Embalagem();
                    oEmbalagem.idEstq_Embalagem = EmcResources.cInt(cboEmbalagem.SelectedValue.ToString());

                    Estq_EmbalagemRN oEmbalagemRN = new Estq_EmbalagemRN(Conexao, objOcorrencia, codempresa);
                    oEmbalagem = oEmbalagemRN.ObterPor(oEmbalagem);

                    if (!String.IsNullOrEmpty(oEmbalagem.descricao))
                    {
                        txtQuantidade.Text = oEmbalagem.quantidade.ToString();
                        txtUnidade.Text = oEmbalagem.unidade.unidade_abreviatura;
                    }
                    else
                    {
                        MessageBox.Show("Erro, embalagem não encontrada", "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
