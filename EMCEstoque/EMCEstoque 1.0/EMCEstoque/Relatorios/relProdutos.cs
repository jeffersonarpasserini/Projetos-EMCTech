using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;
using EMCLibrary;
using EMCEstoqueRN;
using EMCCadastro;
using EMCCadastroRN;
using EMCEstoqueModel;
using EMCCadastroModel;

namespace EMCEstoque
{
    public partial class relProdutos : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relProdutos";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relProdutos(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relProdutos_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "estq_produto";

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        #region "Botões Overrides"

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                Estq_ProdutoRN oBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (!String.IsNullOrEmpty(txtidEstq_Grupo.Text))
                {
                    drpRelatorio = oBLL.DataReport5(EmcResources.cInt(txtidEstq_Grupo.Text));
                    this.dstProdutos.Tables["MyTable"].Clear();
                    this.dstProdutos.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstProdutos.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados para o Grupo Produto Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    produtos.SetParameterValue("Periodo", "Consulta realizada por Grupo Produto");
                    produtos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    produtos.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtidEstq_SubGrupo.Text))
                {
                    drpRelatorio = oBLL.DataReport4(EmcResources.cInt(txtidEstq_SubGrupo.Text));
                    this.dstProdutos.Tables["MyTable"].Clear();
                    this.dstProdutos.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstProdutos.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados para o Subgrupo Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    produtos.SetParameterValue("Periodo", "Consulta realizada por Subgrupo Produto");
                    produtos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    produtos.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtidEstq_TipoProduto.Text))
                {
                    drpRelatorio = oBLL.DataReport3(EmcResources.cInt(txtidEstq_TipoProduto.Text));
                    this.dstProdutos.Tables["MyTable"].Clear();
                    this.dstProdutos.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstProdutos.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados para o Tipo Produto Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    produtos.SetParameterValue("Periodo", "Consulta realizada por Tipo Produto");
                    produtos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    produtos.Show();
                }

                else
                if (!String.IsNullOrEmpty(txtCodigoProduto.Text))
                {
                    drpRelatorio = oBLL.DataReport2(txtCodigoProduto.Text);
                    this.dstProdutos.Tables["MyTable"].Clear();
                    this.dstProdutos.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstProdutos.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Produto não encontrado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    produtos.SetParameterValue("Periodo", "Consulta realizada por Produto");
                   produto.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                   produto.Show();
                }
                else              
                {   drpRelatorio = oBLL.DataReport();
                    this.dstProdutos.Tables["MyTable"].Clear();
                    this.dstProdutos.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstProdutos.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                             return;
                    }
                    produtos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    produtos.Show();
                    }
                }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        #endregion

       private void relProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

       private void btnProduto_Click(object sender, EventArgs e)
       {
           psqProduto ofrm = new psqProduto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
           ofrm.ShowDialog();

           if (!String.IsNullOrEmpty(EMCEstoque.retPesquisa.chavebusca))
           {
               txtCodigoProduto.Enabled = true;
               txtCodigoProduto.Text = EMCEstoque.retPesquisa.chavebusca.ToString();
               txtCodigoProduto.Focus();
               SendKeys.Send("{TAB}");
           }
           
           
       }

       private void txtCodigoProduto_Validating(object sender, CancelEventArgs e)
       {
           if (!String.IsNullOrEmpty(txtCodigoProduto.Text))
               try
               {
                   Estq_Produto oProduto = new Estq_Produto();

                   Estq_ProdutoRN oProdutoRN = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

                   oProduto.codigoProduto = (txtCodigoProduto.Text);

                   oProduto = oProdutoRN.ObterPor(oProduto);

                   txtProduto.Text = oProduto.descricao;

                   if (txtCodigoProduto == null)
                   {

                   }
               }
               catch (Exception erro)
               {
                   MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
       }

       private void btnTipoProduto_Click(object sender, EventArgs e)
       {
           psqTipoProduto ofrm = new psqTipoProduto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
           ofrm.ShowDialog();

           if (EMCEstoque.retPesquisa.chaveinterna == 0)
           {
               //txtCodigoProduto.Text = "";
           }
           else               
           txtidEstq_TipoProduto.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
           txtidEstq_TipoProduto.Focus();
           SendKeys.Send("{TAB}");
       }

       private void txtidEstq_TipoProduto_Validating(object sender, CancelEventArgs e)
       {
           if (!String.IsNullOrEmpty(txtidEstq_TipoProduto.Text))
               try
               {
                   Estq_TipoProduto oTipoProduto = new Estq_TipoProduto();

                   Estq_TipoProdutoRN oTipoProdutoRN = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);

                   oTipoProduto.idestq_tipoproduto = EmcResources.cInt(txtidEstq_TipoProduto.Text);

                   oTipoProduto = oTipoProdutoRN.ObterPor(oTipoProduto);

                   txtTipoProduto.Text = oTipoProduto.descricao;

                   if (txtTipoProduto == null)
                   {

                   }
               }
               catch (Exception erro)
               {
                   MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
       }

       private void btnSubgrupo_Click(object sender, EventArgs e)
       {
           psqSubGrupo ofrm = new psqSubGrupo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
           ofrm.ShowDialog();

           if (EMCEstoque.retPesquisa.chaveinterna == 0)
           {
               //txtCodigoProduto.Text = "";
           }
           else
           txtidEstq_SubGrupo.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
           txtidEstq_SubGrupo.Focus();
           SendKeys.Send("{TAB}");
       }

       private void txtidEstq_SubGrupo_Validating(object sender, CancelEventArgs e)
       {
           if (!String.IsNullOrEmpty(txtidEstq_SubGrupo.Text))
               try
               {
                   Estq_SubGrupo oSubgrupo = new Estq_SubGrupo();

                   Estq_SubGrupoRN oSubgrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);

                   oSubgrupo.idestq_subgrupo = EmcResources.cInt(txtidEstq_SubGrupo.Text);

                   oSubgrupo = oSubgrupoRN.ObterPor(oSubgrupo);

                   txtSubGrupo.Text = oSubgrupo.descricao;

                   if (txtSubGrupo == null)
                   {

                   }
               }
               catch (Exception erro)
               {
                   MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
       }

       private void btnGrupo_Click(object sender, EventArgs e)
       {
           psqGrupoEstoque ofrm = new psqGrupoEstoque(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
           ofrm.ShowDialog();

           if (EMCEstoque.retPesquisa.chaveinterna == 0)
           {
               //txtCodigoProduto.Text = "";
           }
           else
           txtidEstq_Grupo.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
           txtidEstq_Grupo.Focus();
           SendKeys.Send("{TAB}");
       }

       private void txtidEstq_Grupo_Validating(object sender, CancelEventArgs e)
       {
           if (!String.IsNullOrEmpty(txtidEstq_Grupo.Text))
               try
               {
                   Estq_Grupo oGrupo = new Estq_Grupo();

                   Estq_GrupoRN oGrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia, codempresa);

                   oGrupo.idestq_grupo = EmcResources.cInt(txtidEstq_Grupo.Text);

                   oGrupo = oGrupoRN.ObterPor(oGrupo);

                   txtGrupo.Text = oGrupo.descricao;

                   if (txtSubGrupo == null)
                   {

                   }
               }
               catch (Exception erro)
               {
                   MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
       }
         
    }
}
