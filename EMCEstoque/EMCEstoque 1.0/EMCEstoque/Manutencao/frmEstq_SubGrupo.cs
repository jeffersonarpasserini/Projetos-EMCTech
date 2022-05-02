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
    public partial class frmEstq_SubGrupo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_SubGrupo";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_SubGrupo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_SubGrupo()
        {
            InitializeComponent();
        }

        private void frmEstq_SubGrupo_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_SubGrupo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_SubGrupo";

            //carregando as combos na entrada da tela
            //Grupo de Produtos
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
            cboEstq_Grupo.DataSource = oEstq_GrupoRN.ListaEstq_Grupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Grupo.ValueMember = "idestq_grupo";
            cboEstq_Grupo.DisplayMember = "descricao";
            //
            //Menor Unidade de Controle e Unidade Padrão
            Estq_Produto_UnidadeRN oEstq_Produto_UnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            cboMenor_UnidadeControle.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboMenor_UnidadeControle.ValueMember = "idestq_produto_unidade";
            cboMenor_UnidadeControle.DisplayMember = "unidade_descricao";

            cboUnidadePadrao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadePadrao.ValueMember = "idestq_produto_unidade";
            cboUnidadePadrao.DisplayMember = "unidade_descricao";

            cboUnidadeVenda.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeVenda.ValueMember = "idestq_produto_unidade";
            cboUnidadeVenda.DisplayMember = "unidade_descricao";

            cboUnidadeRequisicao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeRequisicao.ValueMember = "idestq_produto_unidade";
            cboUnidadeRequisicao.DisplayMember = "unidade_descricao";

            cboUnidadeSolicitacao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeSolicitacao.ValueMember = "idestq_produto_unidade";
            cboUnidadeSolicitacao.DisplayMember = "unidade_descricao";

            cboUnidadeRecebimento.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeRecebimento.ValueMember = "idestq_produto_unidade";
            cboUnidadeRecebimento.DisplayMember = "unidade_descricao";

            cboUnidadeIndustria.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeIndustria.ValueMember = "idestq_produto_unidade";
            cboUnidadeIndustria.DisplayMember = "unidade_descricao";

            this.ActiveControl = txtidEstq_Grupo;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_SubGrupo montaEstq_SubGrupo()
        {
            Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
            oEstq_SubGrupo.descricao = txtDescricao.Text;
            //Grupo de Produtos
            Estq_Grupo oEstq_Grupo = new Estq_Grupo();
            oEstq_Grupo.idestq_grupo = EmcResources.cInt(txtidEstq_Grupo.Text);
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
            oEstq_SubGrupo.Estq_Grupo = oEstq_GrupoRN.ObterPor(oEstq_Grupo);
            //Menor Unidade de Controle
            Estq_Produto_Unidade oEstq_Produto_Unidade_Menor_UnidadeControle = new Estq_Produto_Unidade();
            oEstq_Produto_Unidade_Menor_UnidadeControle.idestq_produto_unidade = EmcResources.cInt(txtMenor_UnidadeControle.Text);
            Estq_Produto_UnidadeRN oEstq_Produto_Unidade_Menor_UnidadeControleRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            oEstq_SubGrupo.Unidade_MenorControle = oEstq_Produto_Unidade_Menor_UnidadeControleRN.ObterPor(oEstq_Produto_Unidade_Menor_UnidadeControle);
            //Unidade Padrão
            Estq_Produto_Unidade oEstq_Produto_Unidade_UnidadePadrao = new Estq_Produto_Unidade();
            oEstq_Produto_Unidade_UnidadePadrao.idestq_produto_unidade = EmcResources.cInt(txtUnidadePadrao.Text);
            Estq_Produto_UnidadeRN oEstq_Produto_Unidade_UnidadePadraoRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            oEstq_SubGrupo.UnidadePadrao = oEstq_Produto_Unidade_UnidadePadraoRN.ObterPor(oEstq_Produto_Unidade_UnidadePadrao);

            //Unidade  Venda
            Estq_Produto_Unidade oUnVenda = new Estq_Produto_Unidade();
            oUnVenda.idestq_produto_unidade = EmcResources.cInt(txtUnidadeVenda.Text);
            Estq_Produto_UnidadeRN oUnVendaRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_SubGrupo.UnidadeVenda = oUnVendaRN.ObterPor(oUnVenda);

            //Unidade   Requisicao
            Estq_Produto_Unidade oUnRequisicao = new Estq_Produto_Unidade();
            oUnRequisicao.idestq_produto_unidade = EmcResources.cInt(txtUnidadeRequisicao.Text);
            Estq_Produto_UnidadeRN oUnRequisicaoRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_SubGrupo.UnidadeRequisicao = oUnRequisicaoRN.ObterPor(oUnRequisicao);

            //Unidade  Solicitacao
            Estq_Produto_Unidade oUnSolicitacao = new Estq_Produto_Unidade();
            oUnSolicitacao.idestq_produto_unidade = EmcResources.cInt(txtUnidadeSolicitacao.Text);
            Estq_Produto_UnidadeRN oUnSolicitacaoRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_SubGrupo.UnidadeSolicitacao = oUnSolicitacaoRN.ObterPor(oUnSolicitacao);

            //Unidade  Recebimento
            Estq_Produto_Unidade oUnRecebimento = new Estq_Produto_Unidade();
            oUnRecebimento.idestq_produto_unidade = EmcResources.cInt(txtUnidadeRecebimento.Text);
            Estq_Produto_UnidadeRN oUnRecebimentoRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_SubGrupo.UnidadeRecebimento = oUnRecebimentoRN.ObterPor(oUnRecebimento);

            //Unidade Industria
            Estq_Produto_Unidade oUnIndustria = new Estq_Produto_Unidade();
            oUnIndustria.idestq_produto_unidade = EmcResources.cInt(txtUnidadeIndustria.Text);
            Estq_Produto_UnidadeRN oUnIndustriaRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_SubGrupo.UnidadeIndustria = oUnIndustriaRN.ObterPor(oUnIndustria);

            return oEstq_SubGrupo;
        }
      
        private void montaTela(Estq_SubGrupo oEstq_SubGrupo)
        {
            txtidEstq_SubGrupo.Text = oEstq_SubGrupo.idestq_subgrupo.ToString();
            txtDescricao.Text = oEstq_SubGrupo.descricao;
            //Grupo de Produtos
            txtidEstq_Grupo.Text = oEstq_SubGrupo.Estq_Grupo.idestq_grupo.ToString();
            cboEstq_Grupo.SelectedValue = oEstq_SubGrupo.Estq_Grupo.idestq_grupo.ToString();
            //Menor Unidade de Controle
            txtMenor_UnidadeControle.Text = oEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade.ToString();
            cboMenor_UnidadeControle.SelectedValue = oEstq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade.ToString();
            //Unidade Padrão
            txtUnidadePadrao.Text = oEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();
            cboUnidadePadrao.SelectedValue = oEstq_SubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();

            //Unidade venda
            txtUnidadeVenda.Text = oEstq_SubGrupo.UnidadeVenda.idestq_produto_unidade.ToString();
            cboUnidadeVenda.SelectedValue = oEstq_SubGrupo.UnidadeVenda.idestq_produto_unidade.ToString();

            //Unidade Requisicao
            txtUnidadeRequisicao.Text = oEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade.ToString();
            cboUnidadeRequisicao.SelectedValue = oEstq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade.ToString();

            //Unidade Solicitacao
            txtUnidadeSolicitacao.Text = oEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade.ToString();
            cboUnidadeSolicitacao.SelectedValue = oEstq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade.ToString();

            //Unidade Recebimento
            txtUnidadeRecebimento.Text = oEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade.ToString();
            cboUnidadeRecebimento.SelectedValue = oEstq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade.ToString();

            //Unidade Industria
            txtUnidadeIndustria.Text = oEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade.ToString();
            cboUnidadeIndustria.SelectedValue = oEstq_SubGrupo.UnidadeIndustria.idestq_produto_unidade.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_SubGrupo.idestq_subgrupo.ToString();
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
                psqSubGrupo ofrm = new psqSubGrupo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_SubGrupo.Enabled = true;
                    txtidEstq_SubGrupo.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_SubGrupo.Focus();
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

            //carregando as combos na entrada da tela
            //Grupo de Produtos
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia, codempresa);
            cboEstq_Grupo.DataSource = oEstq_GrupoRN.ListaEstq_Grupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Grupo.ValueMember = "idestq_grupo";
            cboEstq_Grupo.DisplayMember = "descricao";
            //
            //Menor Unidade de Controle e Unidade Padrão
            Estq_Produto_UnidadeRN oEstq_Produto_UnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            cboMenor_UnidadeControle.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboMenor_UnidadeControle.ValueMember = "idestq_produto_unidade";
            cboMenor_UnidadeControle.DisplayMember = "unidade_descricao";

            cboUnidadePadrao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadePadrao.ValueMember = "idestq_produto_unidade";
            cboUnidadePadrao.DisplayMember = "unidade_descricao";

            cboUnidadeVenda.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeVenda.ValueMember = "idestq_produto_unidade";
            cboUnidadeVenda.DisplayMember = "unidade_descricao";

            cboUnidadeRequisicao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeRequisicao.ValueMember = "idestq_produto_unidade";
            cboUnidadeRequisicao.DisplayMember = "unidade_descricao";

            cboUnidadeSolicitacao.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeSolicitacao.ValueMember = "idestq_produto_unidade";
            cboUnidadeSolicitacao.DisplayMember = "unidade_descricao";

            cboUnidadeRecebimento.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeRecebimento.ValueMember = "idestq_produto_unidade";
            cboUnidadeRecebimento.DisplayMember = "unidade_descricao";

            cboUnidadeIndustria.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidadeIndustria.ValueMember = "idestq_produto_unidade";
            cboUnidadeIndustria.DisplayMember = "unidade_descricao";

            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                Estq_SubGrupoRN oEstq_SubGrupoBLL = new Estq_SubGrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_SubGrupo = montaEstq_SubGrupo();

                oEstq_SubGrupoBLL.Salvar(oEstq_SubGrupo);
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
                Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                Estq_SubGrupoRN oEstq_SubGrupoBLL = new Estq_SubGrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_SubGrupo = montaEstq_SubGrupo();
                oEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(txtidEstq_SubGrupo.Text);

                oEstq_SubGrupoBLL.Atualizar(oEstq_SubGrupo);
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
                Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                Estq_SubGrupoRN oEstq_SubGrupoBLL = new Estq_SubGrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_SubGrupo = montaEstq_SubGrupo();
                oEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(txtidEstq_SubGrupo.Text);

                oEstq_SubGrupoBLL.Excluir(oEstq_SubGrupo);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void buscaSubgrupo()
        {
            if (!String.IsNullOrEmpty(txtidEstq_SubGrupo.Text))
            {

                Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                try
                {
                    Estq_SubGrupoRN Estq_SubGrupoBLL = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);

                    oEstq_SubGrupo = montaEstq_SubGrupo();
                    oEstq_SubGrupo.idestq_subgrupo = Convert.ToInt32(txtidEstq_SubGrupo.Text);

                    oEstq_SubGrupo = Estq_SubGrupoBLL.ObterPor(oEstq_SubGrupo);

                    if (String.IsNullOrEmpty(oEstq_SubGrupo.descricao))
                    {
                        DialogResult result = MessageBox.Show("Subgrupo não Cadastrada, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_SubGrupo);
                        //AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_SubGrupo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_SubGrupo_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_SubGrupo.Text = grdEstq_SubGrupo.Rows[grdEstq_SubGrupo.CurrentRow.Index].Cells["idestq_subgrupo"].Value.ToString();
            txtidEstq_SubGrupo.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Estq_SubGrupoRN objEstq_SubGrupo = new Estq_SubGrupoRN(Conexao, objOcorrencia,codempresa);
            grdEstq_SubGrupo.DataSource = objEstq_SubGrupo.ListaEstq_SubGrupo();
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_SubGrupo_Validating(object sender, CancelEventArgs e)
        {
            buscaSubgrupo();
        }

        private void cboEstq_Grupo_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidEstq_Grupo.Text = Convert.ToString(cboEstq_Grupo.SelectedValue);

        }

        private void txtidEstq_Grupo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidEstq_Grupo.Text))
            {
                cboEstq_Grupo.Focus();
            }
            else
            {
                cboEstq_Grupo.SelectedValue = Convert.ToInt32(txtidEstq_Grupo.Text);
            }
        }

        private void cboMenor_UnidadeControle_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtMenor_UnidadeControle.Text = Convert.ToString(cboMenor_UnidadeControle.SelectedValue);

        }

        private void txtMenor_UnidadeControle_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMenor_UnidadeControle.Text))
            {
                cboMenor_UnidadeControle.Focus();
            }
            else
            {
                cboMenor_UnidadeControle.SelectedValue = Convert.ToInt32(txtMenor_UnidadeControle.Text);
            }
        }

        private void cboUnidadePadrao_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadePadrao.Text = Convert.ToString(cboUnidadePadrao.SelectedValue);

        }

        private void txtUnidadePadrao_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadePadrao.Text))
            {
                cboUnidadeRequisicao.Focus();
            }
            else
            {
                cboUnidadePadrao.SelectedValue = Convert.ToInt32(txtUnidadePadrao.Text);
            }
        }

        private void cboUnidadeRequisicao_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadeRequisicao.Text = Convert.ToString(cboUnidadeRequisicao.SelectedValue);

        }

        private void txtUnidadeRequisicao_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadeRequisicao.Text))
            {
                cboUnidadeSolicitacao.Focus();
            }
            else
            {
                cboUnidadeRequisicao.SelectedValue = Convert.ToInt32(txtUnidadeRequisicao.Text);
            }
        }
      
        private void cboUnidadeSolicitacao_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadeSolicitacao.Text = Convert.ToString(cboUnidadeSolicitacao.SelectedValue);

        }

        private void txtUnidadeSolicitacao_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadeSolicitacao.Text))
            {
                cboUnidadeRecebimento.Focus();
            }
            else
            {
                cboUnidadeSolicitacao.SelectedValue = Convert.ToInt32(txtUnidadeSolicitacao.Text);
            }
        }
      
        private void cboUnidadeRecebimento_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadeRecebimento.Text = Convert.ToString(cboUnidadeRecebimento.SelectedValue);

        }

        private void txtUnidadeRecebimento_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadeRecebimento.Text))
            {
                cboUnidadeIndustria.Focus();
            }
            else
            {
                cboUnidadeRecebimento.SelectedValue = Convert.ToInt32(txtUnidadeRecebimento.Text);
            }
        }
      
        private void cboUnidadeIndustria_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadeIndustria.Text = Convert.ToString(cboUnidadeIndustria.SelectedValue);

        }

        private void txtUnidadeIndustria_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadeIndustria.Text))
            {
                cboUnidadeVenda.Focus();
            }
            else
            {
                cboUnidadeIndustria.SelectedValue = Convert.ToInt32(txtUnidadeIndustria.Text);
            }
        }
      
        private void cboUnidadeVenda_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtUnidadeVenda.Text = Convert.ToString(cboUnidadeVenda.SelectedValue);

        }

        private void txtUnidadeVenda_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtUnidadeVenda.Text))
            {
                cboUnidadeVenda.Focus();
            }
            else
            {
                cboUnidadeVenda.SelectedValue = Convert.ToInt32(txtUnidadeVenda.Text);
            }
        }
        #endregion


    }
}
