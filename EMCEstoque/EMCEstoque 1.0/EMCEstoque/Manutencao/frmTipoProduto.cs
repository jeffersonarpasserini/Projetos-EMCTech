using System;
using System.Collections;
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
    public partial class frmEstq_TipoProduto : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_TipoProduto";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_TipoProduto(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_TipoProduto()
        {
            InitializeComponent();
        }

        private void frmEstq_TipoProduto_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_TipoProduto_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_TipoProduto";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
     
        private Estq_TipoProduto montaEstq_TipoProduto()
        {
            Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
            oEstq_TipoProduto.descricao = txtDescricao.Text;
            oEstq_TipoProduto.controlaestoqueminimo = cboControlaEstoqueMinimo.SelectedValue.ToString();
            oEstq_TipoProduto.prestacaoservico = cboPrestacaoServico.SelectedValue.ToString();
            oEstq_TipoProduto.familiaobrigatoria = cboFamiliaObrigatoria.SelectedValue.ToString();

            return oEstq_TipoProduto;
        }
        private void montaTela(Estq_TipoProduto oEstq_TipoProduto)
        {
            txtidEstq_TipoProduto.Text = oEstq_TipoProduto.idestq_tipoproduto.ToString();
            txtDescricao.Text = oEstq_TipoProduto.descricao;
            cboControlaEstoqueMinimo.SelectedValue = oEstq_TipoProduto.controlaestoqueminimo;
            cboPrestacaoServico.SelectedValue = oEstq_TipoProduto.prestacaoservico;
            cboFamiliaObrigatoria.SelectedValue = oEstq_TipoProduto.familiaobrigatoria;


            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_TipoProduto.idestq_tipoproduto.ToString();
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
                psqTipoProduto ofrm = new psqTipoProduto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_TipoProduto.Enabled = true;
                    txtidEstq_TipoProduto.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_TipoProduto.Focus();
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

            //montando combo's
            ArrayList arrControlaEstoqueMinimo = new ArrayList();
            arrControlaEstoqueMinimo.Add(new popCombo("Sim", "S"));
            arrControlaEstoqueMinimo.Add(new popCombo("Não", "N"));
            cboControlaEstoqueMinimo.DataSource = arrControlaEstoqueMinimo;
            cboControlaEstoqueMinimo.DisplayMember = "nome";
            cboControlaEstoqueMinimo.ValueMember = "valor";

            ArrayList arrPrestacaoServico = new ArrayList();
            arrPrestacaoServico.Add(new popCombo("Sim", "S"));
            arrPrestacaoServico.Add(new popCombo("Não", "N"));
            cboPrestacaoServico.DataSource = arrPrestacaoServico;
            cboPrestacaoServico.DisplayMember = "nome";
            cboPrestacaoServico.ValueMember = "valor";

            ArrayList arrFamiliaObrigatoria = new ArrayList();
            arrFamiliaObrigatoria.Add(new popCombo("Sim", "S"));
            arrFamiliaObrigatoria.Add(new popCombo("Não", "N"));
            cboFamiliaObrigatoria.DataSource = arrFamiliaObrigatoria;
            cboFamiliaObrigatoria.DisplayMember = "nome";
            cboFamiliaObrigatoria.ValueMember = "valor";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                Estq_TipoProdutoRN oEstq_TipoProdutoBLL = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
                oEstq_TipoProduto = montaEstq_TipoProduto();

                oEstq_TipoProdutoBLL.Salvar(oEstq_TipoProduto);
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
                Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                Estq_TipoProdutoRN oEstq_TipoProdutoBLL = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
                oEstq_TipoProduto = montaEstq_TipoProduto();
                oEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(txtidEstq_TipoProduto.Text);

                oEstq_TipoProdutoBLL.Atualizar(oEstq_TipoProduto);
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
                Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                Estq_TipoProdutoRN oEstq_TipoProdutoBLL = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
                oEstq_TipoProduto = montaEstq_TipoProduto();
                oEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(txtidEstq_TipoProduto.Text);

                oEstq_TipoProdutoBLL.Excluir(oEstq_TipoProduto);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaTipoProduto()
        {
            if (!String.IsNullOrEmpty(txtidEstq_TipoProduto.Text))
            {

                Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
                try
                {
                    Estq_TipoProdutoRN Estq_TipoProdutoBLL = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);

                    oEstq_TipoProduto = montaEstq_TipoProduto();
                    oEstq_TipoProduto.idestq_tipoproduto = Convert.ToInt32(txtidEstq_TipoProduto.Text);

                    oEstq_TipoProduto = Estq_TipoProdutoBLL.ObterPor(oEstq_TipoProduto);

                    if (String.IsNullOrEmpty(oEstq_TipoProduto.descricao))
                    {
                        DialogResult result = MessageBox.Show("Tipo de Produto não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_TipoProduto);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_TipoProduto: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_TipoProduto_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_TipoProduto.Text = grdEstq_TipoProduto.Rows[grdEstq_TipoProduto.CurrentRow.Index].Cells["idEstq_TipoProduto"].Value.ToString();
            txtidEstq_TipoProduto.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Estq_TipoProdutoRN objEstq_TipoProduto = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
            grdEstq_TipoProduto.DataSource = objEstq_TipoProduto.ListaEstq_TipoProduto();
        }


        #endregion


        private void txtidEstq_TipoProduto_Validating(object sender, CancelEventArgs e)
        {
            BuscaTipoProduto();
        }



    }
}
