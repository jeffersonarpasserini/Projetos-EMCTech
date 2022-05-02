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
using System.Collections;

namespace EMCObras
{
    public partial class frmGerenciaTarefa : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmGerenciaTarefa";
        private const string nomeAplicativo = "EMCObras";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        #region "metodos do form"
        
        public frmGerenciaTarefa()
        {
            InitializeComponent();
        }

        public frmGerenciaTarefa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;

            InitializeComponent();
        }

        private void frmGerenciaTarefa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_cronogramaitem";

            this.ActiveControl = txtAbreviacao;

            //this.ActiveControl = txtAbreviacao;
            CancelaOperacao();

        }

        #endregion

        #region [ metodos para tratamento das informacoes ]

        private Obra_Cronograma montaCronograma(string Situacao)
        {
            Obra_Cronograma oCronograma = new Obra_Cronograma();

            oCronograma.idObra_CronogramaItem = EmcResources.cInt(txtIdObra_CronogramaItem.Text);

            Obra oObra = new Obra();
            ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
            oObra.codEmpresa = codempresa;
            oObra.abreviacao = txtAbreviacao.Text;
            oObra = oObraRN.obterPor(oObra);
            oCronograma.idObra_Cronograma = oObra;

            Obra_Tarefa oTarefa = new Obra_Tarefa();
            Obra_TarefaRN oTarefaRN = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
            oTarefa.idobra_tarefas = EmcResources.cInt(txtIdObra_Tarefa.Text);
            oTarefa = oTarefaRN.ObterPor(oTarefa);

            oCronograma.obra_tarefa = oTarefa;

            oCronograma.situacao = Situacao;
            if (Situacao == "E")
            {
                oCronograma.dtaInicio = EmcResources.cDate(txtDtaInicio.Text);
                oCronograma.dtaFinal = null;
            }
            else
            {
                oCronograma.dtaInicio = EmcResources.cDate(txtDtaInicio.Text);
                oCronograma.dtaFinal = EmcResources.cDate(txtDtaFinal.Text);
            }


            return oCronograma;
        }

        private void montaTela(Obra_Cronograma oCronograma)
        {

            txtIdObra_Tarefa.Text = oCronograma.obra_tarefa.idobra_tarefas.ToString();
            txtObra_Tarefa.Text = oCronograma.obra_tarefa.descricao;

            txtIdObra_CronogramaItem.Text = oCronograma.idObra_CronogramaItem.ToString();

            txtDtaFinalPrevista.Text = oCronograma.dtaFinalPreveisto.ToShortDateString();
            txtDtaInicioPrevisto.Text = oCronograma.dtaInicioPrevisto.ToShortDateString();

            if (oCronograma.dtaInicio != null)
            {
                txtDtaInicio.Text = oCronograma.dtaInicio.ToString();
            }

            if (oCronograma.dtaFinal != null)
            {
                txtDtaFinal.Text = oCronograma.dtaFinal.ToString();
            }

            txtSituacao.Text = oCronograma.situacao;

           
            objOcorrencia.chaveidentificacao = oCronograma.idObra_CronogramaItem.ToString();
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
            txtAbreviacao.Enabled = true;
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
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
                    // CancelaOperacao();
                }
                else
                {
                    txtAbreviacao.Enabled = true;
                    txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                    txtAbreviacao.Focus();
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
            txtAbreviacao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {

                Obra_Cronograma oCronograma = new Obra_Cronograma();
                Obra_CronogramaRN oCronogramaBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                //monta cronograma alterando o status para em execução
                oCronograma = montaCronograma("E");

                if (oCronograma.idObra_Cronograma.situacao == "A")
                {
                    oCronogramaBLL.salvar(oCronograma);
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                atualizaObra();

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
                Obra_Cronograma oCronograma = new Obra_Cronograma();
                Obra_CronogramaRN oCronogramaBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                oCronograma = montaCronograma("");
                oCronograma.idObra_CronogramaItem = Convert.ToInt32(txtIdObra_CronogramaItem.Text);

                if (oCronograma.situacao == "P")
                {

                    if (oCronograma.idObra_Cronograma.situacao == "A")
                    {
                        oCronogramaBLL.atualizar(oCronograma);
                    }
                    else
                    {
                        MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    atualizaObra();
                }
                else
                {
                    MessageBox.Show("Cronograma já está em  execução ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                Obra_Cronograma oObra = new Obra_Cronograma();
                Obra_CronogramaRN oObraBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                oObra = montaCronograma("");
                oObra.idObra_CronogramaItem = Convert.ToInt32(txtIdObra_CronogramaItem.Text);

                if (oObra.idObra_Cronograma.situacao == "A")
                {
                    oObraBLL.excluir(oObra);
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


                atualizaObra();


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
            
            txtIdObra_CronogramaItem.Text = "";
            txtIdObra_Tarefa.Text = "";
            txtObra_Tarefa.Text = "";
            txtSituacao.Text = "P";
            txtSituacaoDesc.Text = "";
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

                            grpLibera.Enabled = true;
                            grpEncerra.Enabled = false;

                        }
                        else if (oCronograma.situacao == "E")
                        {
                            txtSituacaoDesc.Text = "Execução";
                            txtSituacao.Text = "E";

                            grpLibera.Enabled = false;
                            grpEncerra.Enabled = true;
                        }
                        else if (oCronograma.situacao == "F")
                        {
                            txtSituacaoDesc.Text = "Finalizado";
                            txtSituacao.Text = "F";

                            grpLibera.Enabled = false;
                            grpEncerra.Enabled = false;
                        }

                        montaTela(oCronograma);

                       
                    }
                    else
                    {
                        MessageBox.Show("Tarefa não foi planejada para esta obra.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

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



        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAbreviacao.Text))
            {
                try
                {
                    ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
                    Obra oObra = new Obra();
                    oObra.codEmpresa = codempresa;
                    oObra.abreviacao = txtAbreviacao.Text;

                    oObra = oObraRN.obterPor(oObra);

                    if (String.IsNullOrEmpty(oObra.descricao))
                    {
                        MessageBox.Show("Obra não Encontrada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtDescricaoObra.Text = oObra.descricao;
                        montaTreeView(oObra);
                    }

                }
                catch (Exception oErro)
                {
                    MessageBox.Show("Erro Cronograma: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLibera_Click(object sender, EventArgs e)
        {
            try
            {

                Obra_Cronograma oCronograma = new Obra_Cronograma();
                Obra_CronogramaRN oCronogramaBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                //monta cronograma alterando o status para em execução
                oCronograma = montaCronograma("E");

                if (oCronograma.idObra_Cronograma.situacao == "A")
                {
                    oCronogramaBLL.atualizarSituacao(oCronograma);
                    txtAbreviacao_Validating(null, null);
                    grpEncerra.Enabled = false;
                    grpLibera.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                atualizaObra();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEncerra_Click(object sender, EventArgs e)
        {
            try
            {

                Obra_Cronograma oCronograma = new Obra_Cronograma();
                Obra_CronogramaRN oCronogramaBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                //monta cronograma alterando o status para em execução
                oCronograma = montaCronograma("F");

                if (oCronograma.idObra_Cronograma.situacao == "A")
                {
                    oCronogramaBLL.atualizarSituacao(oCronograma);
                    txtAbreviacao_Validating(null, null);
                    grpEncerra.Enabled = false;
                    grpLibera.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                atualizaObra();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
