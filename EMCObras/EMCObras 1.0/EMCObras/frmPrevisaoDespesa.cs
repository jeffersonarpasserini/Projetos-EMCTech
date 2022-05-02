using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCCadastro;
using EMCObrasModel;
using EMCObrasRN;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCEstoque;
using System.Collections;

namespace EMCObras
{
    public partial class frmPrevisaoDespesa : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPrevisaoDespesa";
        private const string nomeAplicativo = "EMCObras";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

         #region "metodos do form"
        public frmPrevisaoDespesa()
        {
            InitializeComponent();
        }
        public frmPrevisaoDespesa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;

            InitializeComponent();
        }   

        private void frmPrevisaoDespesa_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmCronograma";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "obra_previsaodespesa";


            this.ActiveControl = txtAbreviacao;
            objOcorrencia.chaveidentificacao = "";
            CancelaOperacao();
            

        }
        #endregion

        #region [Controle treeview de Etapa modulo tarefa]
        private void montaTreeView(Obra oObra)
        {

            tvwTarefa.Nodes.Clear();

            // Cria o Nó Raiz (RootNode)
            TreeNode rootNode = tvwTarefa.Nodes.Add(oObra.descricao);
            rootNode.ImageIndex = 0;


            Obra_EtapaRN oEtapaRN = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);

            foreach (Obra_Etapa oEtapa in oEtapaRN.LstObra_Etapa())
            {
                TreeNode nivel2Node = new TreeNode(oEtapa.descricao);

                Obra_ModuloRN oModuloRN = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
                foreach (Obra_Modulo oModulo in oModuloRN.LstObra_Modulo(oEtapa))
                {


                    Obra_TarefaRN oTarefaRN = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);

                    List<Obra_Tarefa> lstTarefa = oTarefaRN.LstObra_Tarefa(oModulo);

                    int nIndice = lstTarefa.Count;
                    int i = 0;

                    TreeNode[] array = new TreeNode[nIndice];

                    foreach (Obra_Tarefa oTarefa in lstTarefa)
                    {
                        string descricao = oTarefa.descricao;

                        //Busca etapa no cronograma da obra
                        Obra_Cronograma oCronograma = new Obra_Cronograma();
                        Obra_CronogramaRN oCronogramaRN = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                        oCronograma.idObra_Cronograma = oObra;
                        oCronograma.obra_tarefa = oTarefa;

                        oCronograma = oCronogramaRN.obterPor(oCronograma);

                        if (oCronograma.idObra_CronogramaItem > 0)
                        {
                            if (oCronograma.situacao == "P")
                            {
                                descricao += " [ Planejado ]";
                            }
                            else if (oCronograma.situacao == "E")
                            {
                                descricao += " [ Execução ]";
                            }
                            else if (oCronograma.situacao == "F")
                            {
                                descricao += " [ Finalizado ]";
                            }
                        }
                        else
                        {
                            descricao += " [ Não Planejado ]";
                        }
                        array[i] = new TreeNode(descricao);
                        array[i].Tag = oTarefa.idobra_tarefas;
                        i++;
                    }

                    TreeNode nivel3Node = new TreeNode(oModulo.descricao, array);

                    nivel2Node.Nodes.Add(nivel3Node);
                }
                rootNode.Nodes.Add(nivel2Node);
            }

        }
        private void tvwTarefa_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Node.Tag != null)
                {
                    limpaTarefa();

                    //busca tarefa
                    Obra_Tarefa oTarefa = new Obra_Tarefa();
                    Obra_TarefaRN oTarefaRN = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
                    oTarefa.idobra_tarefas = EmcResources.cInt(e.Node.Tag.ToString());
                    oTarefa = oTarefaRN.ObterPor(oTarefa);


                    //busca obra
                    Obra oObra = new Obra();
                    ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
                    oObra.abreviacao = txtAbreviacao.Text;
                    oObra = oObraRN.obterPor(oObra);

                    //busca cronograma
                    Obra_Cronograma oCronograma = new Obra_Cronograma();
                    Obra_CronogramaRN oCronogramaRN = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                    oCronograma.idObra_Cronograma = oObra;
                    oCronograma.obra_tarefa = oTarefa;

                    oCronograma = oCronogramaRN.obterPor(oCronograma);

                    if (oCronograma.idObra_CronogramaItem > 0)
                    {
                        
                        txtObra_Tarefa.Text = oCronograma.obra_tarefa.descricao;
                        if (oCronograma.situacao == "P")
                        {
                            txtSituacaoDesc.Text = "Planejado";
                            txtSituacao.Text = "P";
                        }
                        else if (oCronograma.situacao == "E")
                        {
                            txtSituacaoDesc.Text = "Execução";
                            txtSituacao.Text = "E";
                        }
                        else if (oCronograma.situacao == "F")
                        {
                            txtSituacaoDesc.Text = "Finalizado";
                            txtSituacao.Text = "F";
                        }

                        
                        txtIdObra_Tarefa.Text = oCronograma.obra_tarefa.idobra_tarefas.ToString();
                        txtIdObra_CronogramaItem.Text = oCronograma.idObra_CronogramaItem.ToString();
                        txtObra_Tarefa.Text = oCronograma.obra_tarefa.descricao;
                        objOcorrencia.chaveidentificacao = oCronograma.idObra_CronogramaItem.ToString();
                        calculaTotalTarefa();

                        AtivaInsercao();

                        txtIdEstq_Produto.Enabled = true;
                        txtQtdePrevista.Enabled = true;
                        txtCustoPrevisto.Enabled = true;

                        AtualizaGrid();

                        txtIdEstq_Produto.Focus();
                        
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não foi planejada para esta obra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtIdEstq_Produto.Enabled = false;
                        txtQtdePrevista.Enabled = false;
                        txtCustoPrevisto.Enabled = false;
                        objOcorrencia.chaveidentificacao = "";
                                               
                    }

                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Cronograma: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #endregion

        #region [Texts, Combos, etc]
       
        private void txtIdEstq_Produto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdEstq_Produto.Text))
                {
                    Estq_Produto oProduto = new Estq_Produto();
                    Estq_ProdutoRN oProdutoRN = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

                    oProduto.codigoProduto = txtIdEstq_Produto.Text;
                    oProduto = oProdutoRN.ObterPor(oProduto);

                    if (oProduto.idestq_produto == 0)
                    {
                        MessageBox.Show("Produto não encontrado", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtDescricaoProduto.Text = oProduto.descricao;
                        cboUnidade.SelectedValue = oProduto.Estq_SubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();
                        txtIdUnidade.Text = oProduto.Estq_SubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();
                        txtIdProduto.Text = oProduto.idestq_produto.ToString();
                        txtQtdePrevista.Text = "0";
                        txtCustoPrevisto.Text = "0";

                        Obra_PrevisaoDespesa oDespesa = montaPrevisaoDespesa();
                        Obra_PrevisaoDespesaRN oDespesaRN = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);

                        oDespesa = oDespesaRN.obterPor(oDespesa);

                        if (oDespesa.idObra_PrevisaoDespesa > 0)
                        {
                            /* produto já conta na despesa desta tarefa */
                            txtVlrUnitario.Text = oDespesa.vlrUnitario.ToString();
                            txtCustoPrevisto.Text = oDespesa.vlrDespesa.ToString();
                            txtQtdePrevista.Text = oDespesa.quantidade.ToString();
                            cboUnidade.SelectedValue = oDespesa.idUnidade.idestq_produto_unidade.ToString();
                            txtIdUnidade.Text = oDespesa.idUnidade.idestq_produto_unidade.ToString();
                            txtIdObra_PrevisaoDespesa.Text = oDespesa.idObra_PrevisaoDespesa.ToString();
                            AtivaEdicao();
                        }
                        else
                        {
                            /*inclusão de uma nova despesa */
                            txtVlrUnitario.Text = "0";
                            txtCustoPrevisto.Text = "0";
                            txtQtdePrevista.Text = "0";
                            AtivaInsercao();
                        }
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Previsão Despesa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
      
        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAbreviacao.Text))
            {
                try
                {

                    ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
                    Obra oObra = new Obra();
                    oObra.abreviacao = txtAbreviacao.Text;

                    oObra = oObraRN.obterPor(oObra);

                    if (oObra.idObra_Cronograma > 0)
                    {
                        txtDescricaoObra.Text = oObra.descricao;
                        txtIdObra.Text = oObra.idObra_Cronograma.ToString();
                        
                        calculaTotalObra();

                        montaTreeView(oObra);

                        //AtualizaGrid();
                    }

                    else
                    {
                        MessageBox.Show("Obra não encontrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAbreviacao.Focus();
                    }
                }

                catch (Exception oErro)
                {
                    MessageBox.Show("Erro Cronograma: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
   
        private void txtQtdePrevista_Validating(object sender, CancelEventArgs e)
        {
            if (EmcResources.cDouble(txtQtdePrevista.Text) > 0)
            {
                txtCustoPrevisto.Text = (txtQtdePrevista.Value * txtVlrUnitario.Value).ToString();
            }
            else
            {
                MessageBox.Show("Informar a quantidade", "Previsão Despesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
   
        private void txtCustoPrevisto_Validating(object sender, CancelEventArgs e)
        {
            if (EmcResources.cDouble(txtQtdePrevista.Text) > 0)
            {
                txtVlrUnitario.Text = (txtCustoPrevisto.Value/txtQtdePrevista.Value).ToString();
            }
            else
            {
                MessageBox.Show("Informar a quantidade", "Previsão Despesa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    
        private void txtCustoUnitario_Validating(object sender, CancelEventArgs e)
        {
            txtCustoPrevisto.Text = (txtVlrUnitario.Value * txtQtdePrevista.Value).ToString();
        }


        #endregion

        #region [ metodos para tratamento das informacoes ]

        private Obra_PrevisaoDespesa montaPrevisaoDespesa()
        {
            Obra_PrevisaoDespesa oDespesa = new Obra_PrevisaoDespesa();

            Obra oObra = new Obra();
            ObraRN oObraRN = new ObraRN(Conexao,objOcorrencia,codempresa);
            oObra.idObra_Cronograma = EmcResources.cInt(txtIdObra.Text);
            oObra.codEmpresa = codempresa;
            oObra = oObraRN.obterPor(oObra);
            oDespesa.idObra_Cronograma = oObra;

            Obra_Cronograma oCronograma = new Obra_Cronograma();
            Obra_CronogramaRN oCronogramaRN = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
            oCronograma.idObra_CronogramaItem = EmcResources.cInt(txtIdObra_CronogramaItem.Text);
            oCronograma.idObra_Cronograma = oObra;
            oCronograma = oCronogramaRN.obterPor(oCronograma);
            oDespesa.idObra_CronogramaItem = oCronograma;

            Estq_Produto oProduto = new Estq_Produto();
            Estq_ProdutoRN oProdutoRN = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);
            oProduto.idestq_produto = EmcResources.cInt(txtIdProduto.Text);
            oProduto = oProdutoRN.ObterPor(oProduto);
            oDespesa.idEstq_Produto = oProduto;

            Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oUnidade.idestq_produto_unidade = EmcResources.cInt(cboUnidade.SelectedValue.ToString());
            oUnidade = oUnidadeRN.ObterPor(oUnidade);
            oDespesa.idUnidade = oUnidade;

            oDespesa.idCusto_Componente = oProduto.componenteCusto;
            oDespesa.idObra_Tarefa = oCronograma.obra_tarefa;
            oDespesa.quantidade = EmcResources.cDouble(txtQtdePrevista.Value.ToString());
            oDespesa.vlrDespesa = EmcResources.cCur(txtCustoPrevisto.Value.ToString());

            if (EmcResources.cDouble(txtCustoPrevisto.Value.ToString()) > 0)
                oDespesa.vlrUnitario = EmcResources.cCur((EmcResources.cDouble(txtCustoPrevisto.Value.ToString()) / EmcResources.cDouble(txtQtdePrevista.Value.ToString())).ToString());
            else
                oDespesa.vlrUnitario = 0;
            
            return oDespesa;
        }

        private void montaTela(Obra_PrevisaoDespesa oDespesa)
        {

            

            objOcorrencia.chaveidentificacao = oDespesa.idObra_CronogramaItem.ToString();
            AtivaEdicao();

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
            txtAbreviacao.Enabled = false;
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtAbreviacao.Enabled = false;
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtIdEstq_Produto.Enabled = false;
            txtQtdePrevista.Enabled = false;
            txtCustoPrevisto.Enabled = false;

            txtAbreviacao.ReadOnly = false;
            txtAbreviacao.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtAbreviacao.Focus();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relObra ofrm = new Relatorios.relObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Obra: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqObra ofrm = new psqObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtAbreviacao.Enabled = true;
                    txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                    txtAbreviacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            //Situação
            txtIdEstq_Produto.Text = "";
            txtDescricaoProduto.Text = "";
            txtQtdePrevista.Text = "0";
            txtVlrUnitario.Text = "0";
            txtCustoPrevisto.Text = "0";
            

            //*monta unidade 
            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            cboUnidade.DataSource = oUnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidade.DisplayMember = "unidade_descricao";
            cboUnidade.ValueMember = "idestq_produto_unidade";

            objOcorrencia.chaveidentificacao = "";
            txtAbreviacao.Focus();
        }
       
        public void limpaDepesa()
        {
            //Situação
            txtIdEstq_Produto.Text = "";
            txtDescricaoProduto.Text = "";
            txtQtdePrevista.Text = "0";
            txtVlrUnitario.Text = "0";
            txtCustoPrevisto.Text = "0";
            

            //*monta unidade 
            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            cboUnidade.DataSource = oUnidadeRN.ListaEstq_Produto_Unidade();
            cboUnidade.DisplayMember = "unidade_descricao";
            cboUnidade.ValueMember = "idestq_produto_unidade";

            txtIdEstq_Produto.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {

                Obra_PrevisaoDespesa oDespesa = new Obra_PrevisaoDespesa();
                Obra_PrevisaoDespesaRN oDespesaBLL = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                oDespesa = montaPrevisaoDespesa();

                if (oDespesa.idObra_Cronograma.situacao == "A")
                {
                    oDespesaBLL.salvar(oDespesa);
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //atualizaObra();
                calculaTotalTarefa();
                calculaTotalObra();
                AtualizaGrid();
                limpaDepesa();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Obra_PrevisaoDespesa oDespesa = new Obra_PrevisaoDespesa();
                Obra_PrevisaoDespesaRN oDespesaBLL = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                oDespesa = montaPrevisaoDespesa();
                oDespesa.idObra_PrevisaoDespesa = Convert.ToInt32(txtIdObra_PrevisaoDespesa.Text);

                if (oDespesa.idObra_Cronograma.situacao == "A")
                {
                    oDespesaBLL.atualizar(oDespesa);
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                

                //atualizaObra();
                calculaTotalTarefa();
                calculaTotalObra();
                AtualizaGrid();
                limpaDepesa();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Obra_PrevisaoDespesa oDespesa = new Obra_PrevisaoDespesa();
                Obra_PrevisaoDespesaRN oDespesaBLL = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                oDespesa = montaPrevisaoDespesa();
                oDespesa.idObra_PrevisaoDespesa = Convert.ToInt32(txtIdObra_PrevisaoDespesa.Text);

                if (oDespesa.idObra_Cronograma.situacao == "A")
                {
                    oDespesaBLL.excluir(oDespesa);
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                //atualizaObra();
                calculaTotalTarefa();
                calculaTotalObra();
                AtualizaGrid();
                limpaDepesa();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public void BuscaObra()
        {





        }

        public void atualizaObra()
        {
            //atualiza o status da obra na tela
            limpaTarefa();
            txtTotalObra.Text = "";

            Obra oObra = new Obra();
            ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
            oObra.codEmpresa = codempresa;
            oObra.abreviacao = txtAbreviacao.Text;
            oObra = oObraRN.obterPor(oObra);

            montaTreeView(oObra);

            tvwTarefa.ExpandAll();

        }

        public void limpaTarefa()
        {
            txtObra_Tarefa.Text = "";
            txtIdObra_Tarefa.Text = "";
            txtSituacaoDesc.Text = "";
            txtTotalTarefa.Text = "";
        }
        #endregion

        #region [ Calculos de Despesas ]
        public void calculaTotalObra()
        {
            try
            {
                Obra_PrevisaoDespesaRN oDespesaRN = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                txtTotalObra.Text = oDespesaRN.listaTotalDespesaObra(EmcResources.cInt(txtIdObra.Text)).ToString();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Previsao Despesa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void calculaTotalTarefa()
        {
            try
            {
                Obra_PrevisaoDespesaRN oDespesaRN = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                txtTotalTarefa.Text = oDespesaRN.listaTotalDespesaTarefa(EmcResources.cInt(txtIdObra_CronogramaItem.Text)).ToString();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Previsao Despesa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region "metodos da dbgrid"

        private void grdDespesa_DoubleClick(object sender, EventArgs e)
        {
            
            txtIdEstq_Produto.Text = grdDespesa.Rows[grdDespesa.CurrentRow.Index].Cells["codigoproduto"].Value.ToString();
            txtIdEstq_Produto.Focus();
            SendKeys.Send("{TAB}");

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Obras cadastrados
            Obra_PrevisaoDespesaRN oDespesaRN = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
            if (EmcResources.cInt(txtIdObra_Tarefa.Text) > 0)
                grdDespesa.DataSource = oDespesaRN.listaPrevisaoDespesa("T", EmcResources.cInt(txtIdObra_CronogramaItem.Text));
            else if (EmcResources.cInt(txtIdObra.Text) > 0 && EmcResources.cInt(txtIdObra_Tarefa.Text)==0)
                grdDespesa.DataSource = oDespesaRN.listaPrevisaoDespesa("O",EmcResources.cInt(txtIdObra.Text));

                
        }

        #endregion

        private void btnProduto_Click(object sender, EventArgs e)
        {
            try
            {
               if (String.IsNullOrEmpty(txtIdEstq_Produto.Text))
                {
                    psqProduto oFrm = new psqProduto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                    oFrm.ShowDialog();

                    if (String.IsNullOrEmpty(EMCEstoque.retPesquisa.chavebusca))
                    {
                        txtIdEstq_Produto.Text = "";
                        txtIdProduto.Text = "";
                    }
                    else
                        txtIdEstq_Produto.Text = EMCEstoque.retPesquisa.chavebusca.ToString();
                        txtIdEstq_Produto_Validating(null, null);
                        cboUnidade.Focus();
                        
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Depesas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscaObra_Click(object sender, EventArgs e)
        {
            try
            {
                psqObra ofrm = new psqObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtAbreviacao.Enabled = true;
                    txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                    txtAbreviacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
