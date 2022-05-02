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
using EMCCadastroModel;
using EMCCadastroRN;

//*** O codigo principal da tabela idestq_produto_fornecedor esta oculto atras da imagem do código de barras ***//

namespace EMCEstoque
{
    public partial class frmEstq_Produto_Fornecedor : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Produto_Fornecedor";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
        Estq_Produto oProduto = new Estq_Produto();

        public frmEstq_Produto_Fornecedor(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Estq_Produto oEstq_Produto)
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

        public frmEstq_Produto_Fornecedor()
        {
            InitializeComponent();
        }

        private void frmEstq_Produto_Fornecedor_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Produto_Fornecedor_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Produto_Fornecedor";

            //carregando o nome do produto na label da tela
            lblProduto.Text = "PRODUTO: " + oProduto.idestq_produto + "-" + oProduto.descricao;

            //carregando as combos na entrada da tela
            //Fornecedor
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia,codempresa);
            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;
            cboFornecedor_IdPessoa.DataSource = oFornecedorRN.ListaFornecedor(oFornecedor);
            cboFornecedor_IdPessoa.DisplayMember = "nome";
            cboFornecedor_IdPessoa.ValueMember = "idpessoa";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_Produto_Fornecedor montaEstq_Produto_Fornecedor()
        {
            Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
            oEstq_Produto_Fornecedor.idproduto_fornecedor = txtIdProduto_Fornecedor.Text;
            //Produto
            oEstq_Produto_Fornecedor.Estq_Produto = oProduto; //recebeu o objeto produto do form principal do cadastro de produtos
            //Fornecedor
            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;
            oFornecedor.idPessoa = EmcResources.cInt(txtFornecedor_IdPessoa.Text);
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia,codempresa);
            oEstq_Produto_Fornecedor.Fornecedor = oFornecedorRN.ObterPor(oFornecedor);

            return oEstq_Produto_Fornecedor;
        }
        private void montaTela(Estq_Produto_Fornecedor oEstq_Produto_Fornecedor)
        {
            txtidEstq_Produto_Fornecedor.Text = oEstq_Produto_Fornecedor.idestq_produto_fornecedor.ToString();
            txtIdProduto_Fornecedor.Text = oEstq_Produto_Fornecedor.idproduto_fornecedor.ToString();
            //Fornecedor
            txtFornecedor_IdPessoa.Text = oEstq_Produto_Fornecedor.Fornecedor.idPessoa.ToString();
            cboFornecedor_IdPessoa.SelectedValue = oEstq_Produto_Fornecedor.Fornecedor.idPessoa.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Produto_Fornecedor.idestq_produto_fornecedor.ToString();
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
            txtFornecedor_IdPessoa.Enabled = false;
            cboFornecedor_IdPessoa.Enabled = false;
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            LimpaCampos();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            LimpaCampos();
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Produto_Fornecedor.Text))
            {

                Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
                try
                {
                    Estq_Produto_FornecedorRN Estq_Produto_FornecedorBLL = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Produto_Fornecedor = montaEstq_Produto_Fornecedor();
                    oEstq_Produto_Fornecedor.idestq_produto_fornecedor = Convert.ToInt32(txtidEstq_Produto_Fornecedor.Text);

                    oEstq_Produto_Fornecedor = Estq_Produto_FornecedorBLL.ObterPor(oEstq_Produto_Fornecedor);

                    if (String.IsNullOrEmpty(oEstq_Produto_Fornecedor.idestq_produto_fornecedor.ToString()))
                    {
                        DialogResult result = MessageBox.Show("Código Interno de Fornecedor não Cadastrado, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Produto_Fornecedor);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto_Fornecedor: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscaObjeto(int pFornecedor)
        {
            if (pFornecedor > 0)
            {

                Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
                try
                {
                    Estq_Produto_FornecedorRN Estq_Produto_FornecedorBLL = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Produto_Fornecedor = montaEstq_Produto_Fornecedor();
                    oEstq_Produto_Fornecedor.idestq_produto_fornecedor = 0;

                    oEstq_Produto_Fornecedor = Estq_Produto_FornecedorBLL.ObterPor(oEstq_Produto_Fornecedor);

                    if (String.IsNullOrEmpty(oEstq_Produto_Fornecedor.idestq_produto_fornecedor.ToString()) || oEstq_Produto_Fornecedor.idestq_produto_fornecedor == 0)
                    {
                        cboFornecedor_IdPessoa.SelectedValue = Convert.ToInt32(txtFornecedor_IdPessoa.Text);
                    }
                    else
                    {
                        montaTela(oEstq_Produto_Fornecedor);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto_Fornecedor: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtFornecedor_IdPessoa.Focus();
            txtFornecedor_IdPessoa.Enabled = true;
            cboFornecedor_IdPessoa.Enabled = true;
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
                Estq_Produto_FornecedorRN oEstq_Produto_FornecedorBLL = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Fornecedor = montaEstq_Produto_Fornecedor();

                oEstq_Produto_FornecedorBLL.Salvar(oEstq_Produto_Fornecedor);
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
                Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
                Estq_Produto_FornecedorRN oEstq_Produto_FornecedorBLL = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Fornecedor = montaEstq_Produto_Fornecedor();
                oEstq_Produto_Fornecedor.idestq_produto_fornecedor = Convert.ToInt32(txtidEstq_Produto_Fornecedor.Text);

                oEstq_Produto_FornecedorBLL.Atualizar(oEstq_Produto_Fornecedor);
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
                Estq_Produto_Fornecedor oEstq_Produto_Fornecedor = new Estq_Produto_Fornecedor();
                Estq_Produto_FornecedorRN oEstq_Produto_FornecedorBLL = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Fornecedor = montaEstq_Produto_Fornecedor();
                oEstq_Produto_Fornecedor.idestq_produto_fornecedor = Convert.ToInt32(txtidEstq_Produto_Fornecedor.Text);

                oEstq_Produto_FornecedorBLL.Excluir(oEstq_Produto_Fornecedor);
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

        private void grdEstq_Produto_Fornecedor_DoubleClick(object sender, EventArgs e)
        {
            if (grdEstq_Produto_Fornecedor.Rows.Count > 0)
            {
                txtidEstq_Produto_Fornecedor.Text = grdEstq_Produto_Fornecedor.Rows[grdEstq_Produto_Fornecedor.CurrentRow.Index].Cells["idEstq_Produto_Fornecedor"].Value.ToString();
                txtidEstq_Produto_Fornecedor.Focus();
                SendKeys.Send("{TAB}");
                AtivaEdicao();
            }
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Estq_Produto_FornecedorRN objEstq_Produto_Fornecedor = new Estq_Produto_FornecedorRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Produto_Fornecedor.DataSource = objEstq_Produto_Fornecedor.ListaEstq_Produto_Fornecedor(oProduto);
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_Produto_Fornecedor_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        private void cboFornecedor_IdPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtFornecedor_IdPessoa.Text = Convert.ToString(cboFornecedor_IdPessoa.SelectedValue);

            txtFornecedor_IdPessoa.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void txtFornecedor_IdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtFornecedor_IdPessoa.Text))
            {
                cboFornecedor_IdPessoa.Focus();
            }
            else
            {
                //verificando se o fornecedor existe
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia,codempresa);
                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = EmcResources.cInt(txtFornecedor_IdPessoa.Text);
                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);
                if (oFornecedor.pessoa == null)
                    MessageBox.Show("Fornecedor não Cadastrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    //verificando se já existe codigo interno cadastrado para o produto e o fornecedor digitados
                    BuscaObjeto(Convert.ToInt32(txtFornecedor_IdPessoa.Text));
            }
        }

        
        #endregion
    }
}
