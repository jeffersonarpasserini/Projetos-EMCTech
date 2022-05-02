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

//*** O codigo principal da tabela idEstq_Descricao esta oculto atras da imagem do código de barras ***//

namespace EMCEstoque
{
    public partial class frmEstq_Descricao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Descricao";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
        Estq_Produto oProduto = new Estq_Produto();

        public frmEstq_Descricao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Estq_Produto oEstq_Produto)
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

        public frmEstq_Descricao()
        {
            InitializeComponent();
        }

        private void frmEstq_Descricao_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Descricao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Descricao";

            //carregando o nome do produto na label da tela
            lblProduto.Text = "PRODUTO: " + oProduto.idestq_produto + "-" + oProduto.descricao;

            //carregando as combos na entrada da tela
            //Cliente
            ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia,codempresa);
            Cliente oCliente = new Cliente();
            oCliente.codEmpresa = empMaster;
            cboCliente_IdPessoa.DataSource = oClienteRN.ListaCliente(oCliente);
            cboCliente_IdPessoa.DisplayMember = "nome";
            cboCliente_IdPessoa.ValueMember = "idpessoa";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_Descricao montaEstq_Descricao()
        {
            Estq_Descricao oEstq_Descricao = new Estq_Descricao();
            oEstq_Descricao.descricao = txtDescricao.Text;
            //Produto
            oEstq_Descricao.Estq_Produto = oProduto; //recebeu o objeto produto do form principal do cadastro de produtos
            //Cliente
            Cliente oCliente = new Cliente();
            oCliente.codEmpresa = empMaster;
            oCliente.idPessoa = EmcResources.cInt(txtCliente_IdPessoa.Text);
            ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia,codempresa);
            oEstq_Descricao.Cliente = oClienteRN.ObterPor(oCliente);

            return oEstq_Descricao;
        }
        private void montaTela(Estq_Descricao oEstq_Descricao)
        {
            txtidEstq_Descricao.Text = oEstq_Descricao.idestq_descricao.ToString();
            txtDescricao.Text = oEstq_Descricao.descricao.ToString();
            //Cliente
            txtCliente_IdPessoa.Text = oEstq_Descricao.Cliente.idPessoa.ToString();
            cboCliente_IdPessoa.SelectedValue = oEstq_Descricao.Cliente.idPessoa.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Descricao.idestq_descricao.ToString();
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
            txtCliente_IdPessoa.Enabled = false;
            cboCliente_IdPessoa.Enabled = false;
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtCliente_IdPessoa.Enabled = true;
            cboCliente_IdPessoa.Enabled = true;
            LimpaCampos();
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
            if (!String.IsNullOrEmpty(txtidEstq_Descricao.Text))
            {

                Estq_Descricao oEstq_Descricao = new Estq_Descricao();
                try
                {
                    Estq_DescricaoRN Estq_DescricaoBLL = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Descricao = montaEstq_Descricao();
                    oEstq_Descricao.idestq_descricao = Convert.ToInt32(txtidEstq_Descricao.Text);

                    oEstq_Descricao = Estq_DescricaoBLL.ObterPor(oEstq_Descricao);

                    if (String.IsNullOrEmpty(oEstq_Descricao.idestq_descricao.ToString()))
                    {
                        DialogResult result = MessageBox.Show("Descrição Personalizada do Cliente não Cadastrado, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Descricao);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Descricao: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuscaObjeto(int pCliente)
        {
            if (pCliente > 0)
            {

                Estq_Descricao oEstq_Descricao = new Estq_Descricao();
                try
                {
                    Estq_DescricaoRN Estq_DescricaoBLL = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Descricao = montaEstq_Descricao();
                    oEstq_Descricao.idestq_descricao = 0;

                    oEstq_Descricao = Estq_DescricaoBLL.ObterPor(oEstq_Descricao);

                    if (String.IsNullOrEmpty(oEstq_Descricao.idestq_descricao.ToString()) || oEstq_Descricao.idestq_descricao == 0)
                    {
                        AtivaInsercao();
                    }
                    else
                    {
                        montaTela(oEstq_Descricao);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Descricao: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtCliente_IdPessoa.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                Estq_Descricao oEstq_Descricao = new Estq_Descricao();
                Estq_DescricaoRN oEstq_DescricaoBLL = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Descricao = montaEstq_Descricao();

                oEstq_DescricaoBLL.Salvar(oEstq_Descricao);
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
                Estq_Descricao oEstq_Descricao = new Estq_Descricao();
                Estq_DescricaoRN oEstq_DescricaoBLL = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Descricao = montaEstq_Descricao();
                oEstq_Descricao.idestq_descricao = Convert.ToInt32(txtidEstq_Descricao.Text);

                oEstq_DescricaoBLL.Atualizar(oEstq_Descricao);
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
                Estq_Descricao oEstq_Descricao = new Estq_Descricao();
                Estq_DescricaoRN oEstq_DescricaoBLL = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Descricao = montaEstq_Descricao();
                oEstq_Descricao.idestq_descricao = Convert.ToInt32(txtidEstq_Descricao.Text);

                oEstq_DescricaoBLL.Excluir(oEstq_Descricao);
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

        private void grdEstq_Descricao_DoubleClick(object sender, EventArgs e)
        {
            if (grdEstq_Descricao.Rows.Count > 0)
            {
                txtidEstq_Descricao.Text = grdEstq_Descricao.Rows[grdEstq_Descricao.CurrentRow.Index].Cells["idEstq_Descricao"].Value.ToString();
                txtidEstq_Descricao.Focus();
                SendKeys.Send("{TAB}");
                AtivaEdicao();
            }
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Estq_DescricaoRN objEstq_Descricao = new Estq_DescricaoRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Descricao.DataSource = objEstq_Descricao.ListaEstq_Descricao();
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_Descricao_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        private void cboCliente_IdPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtCliente_IdPessoa.Text = Convert.ToString(cboCliente_IdPessoa.SelectedValue);

            txtCliente_IdPessoa.Focus();
            SendKeys.Send("{ENTER}");
        }

        private void txtCliente_IdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtCliente_IdPessoa.Text))
            {
                cboCliente_IdPessoa.Focus();
            }
            else
            {
                //verificando se o fornecedor existe
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia,codempresa);
                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtCliente_IdPessoa.Text);
                oCliente = oClienteRN.ObterPor(oCliente);
                if (oCliente.pessoa == null)
                    MessageBox.Show("Cliente não Cadastrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    //verificando se já existe codigo interno cadastrado para o produto e o fornecedor digitados
                    BuscaObjeto(Convert.ToInt32(txtCliente_IdPessoa.Text));
            }
        }


        #endregion
    }
}
