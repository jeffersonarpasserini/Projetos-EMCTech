using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCObrasModel;
using EMCObrasRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCObras
{
    public partial class frmObra_Tarefa : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmObra_Tarefa";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmObra_Tarefa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmObra_Tarefa()
        {
            InitializeComponent();
        }

        private void frmObra_Tarefa_Activated(object sender, EventArgs e)
        {


        }

        private void frmObra_Tarefa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_tarefa";

            //carregando as combos na entrada da tela
            Obra_ModuloRN oObra_ModuloRN = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
            cboObra_Modulo.DataSource = oObra_ModuloRN.ListaObra_Modulo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboObra_Modulo.ValueMember = "idobra_modulo";
            cboObra_Modulo.DisplayMember = "descricao";

            this.ActiveControl = txtidObra_Tarefas;

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"
        
        private Obra_Tarefa montaObra_Tarefa()
        {
            Obra_Tarefa oObra_Tarefa = new Obra_Tarefa();
            oObra_Tarefa.descricao = txtDescricao.Text;
            
            Obra_Modulo oObra_Modulo = new Obra_Modulo();
            oObra_Modulo.idobra_modulo = EmcResources.cInt(txtidObra_Modulo.Text);
            oObra_Tarefa.obra_modulo = oObra_Modulo;

            Obra_Etapa oObra_Etapa = new Obra_Etapa();
            oObra_Etapa.idobra_etapa = EmcResources.cInt(txtidObra_Etapa.Text);
            oObra_Tarefa.obra_etapa = oObra_Etapa;

            return oObra_Tarefa;
        }
     
        private void montaTela(Obra_Tarefa oObra_Tarefa)
        {
            txtidObra_Tarefas.Text = oObra_Tarefa.idobra_tarefas.ToString();
            txtDescricao.Text = oObra_Tarefa.descricao;

            txtidObra_Modulo.Text = oObra_Tarefa.obra_modulo.idobra_modulo.ToString();
            cboObra_Modulo.SelectedValue = oObra_Tarefa.obra_modulo.idobra_modulo.ToString();

            txtidObra_Etapa.Text = oObra_Tarefa.obra_etapa.idobra_etapa.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oObra_Tarefa.idobra_tarefas.ToString();
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
        }
   
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidObra_Tarefas.Enabled = true;
            txtidObra_Tarefas.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqObraTarefa ofrm = new psqObraTarefa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCObras.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Tarefas.Enabled = true;
                    txtidObra_Tarefas.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Tarefas.Focus();
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

                Obra_Tarefa oObra_Tarefa = new Obra_Tarefa();
                Obra_TarefaRN oObra_TarefaBLL = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
                oObra_Tarefa = montaObra_Tarefa();

                oObra_TarefaBLL.Salvar(oObra_Tarefa);
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
                Obra_Tarefa oObra_Tarefa = new Obra_Tarefa();
                Obra_TarefaRN oObra_TarefaBLL = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
                oObra_Tarefa = montaObra_Tarefa();
                oObra_Tarefa.idobra_tarefas = Convert.ToInt32(txtidObra_Tarefas.Text);

                oObra_TarefaBLL.Atualizar(oObra_Tarefa);
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
                Obra_Tarefa oObra_Tarefa = new Obra_Tarefa();
                Obra_TarefaRN oObra_TarefaBLL = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
                oObra_Tarefa = montaObra_Tarefa();
                oObra_Tarefa.idobra_tarefas = Convert.ToInt32(txtidObra_Tarefas.Text);

                oObra_TarefaBLL.Excluir(oObra_Tarefa);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaTarefa()
        {
            if (!String.IsNullOrEmpty(txtidObra_Tarefas.Text))
            {

                Obra_Tarefa oObra_Tarefa = new Obra_Tarefa();
                try
                {
                    Obra_TarefaRN Obra_TarefaBLL = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);

                    oObra_Tarefa = montaObra_Tarefa();
                    oObra_Tarefa.idobra_tarefas = Convert.ToInt32(txtidObra_Tarefas.Text);

                    oObra_Tarefa = Obra_TarefaBLL.ObterPor(oObra_Tarefa);

                    if (String.IsNullOrEmpty(oObra_Tarefa.descricao))
                    {
                        DialogResult result = MessageBox.Show("Tarefa não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oObra_Tarefa);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Obra_Tarefa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdObra_Tarefa_DoubleClick(object sender, EventArgs e)
        {
            txtidObra_Tarefas.Text = grdObra_Tarefa.Rows[grdObra_Tarefa.CurrentRow.Index].Cells["idobra_tarefa"].Value.ToString();
            txtidObra_Tarefas.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Obra_TarefaRN objObra_Tarefa = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
            grdObra_Tarefa.DataSource = objObra_Tarefa.ListaObra_Tarefa();
        }

        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidObra_Tarefas_Validating(object sender, CancelEventArgs e)
        {
            BuscaTarefa();
        }

        private void cboObra_Modulo_SelectedValueChanged(object sender, EventArgs e)
        {
            txtidObra_Modulo.Text = Convert.ToString(cboObra_Modulo.SelectedValue);

            if (cboObra_Modulo.SelectedValue != null && cboObra_Modulo.SelectedValue.ToString().Trim() != "System.Data.DataRowView")
            {
                Obra_ModuloRN oObra_ModuloRN = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
                Obra_Modulo oObra_Modulo = new Obra_Modulo();
                oObra_Modulo.idobra_modulo = EmcResources.cInt(txtidObra_Modulo.Text);
                oObra_Modulo = oObra_ModuloRN.ObterPor(oObra_Modulo);
                txtidObra_Etapa.Text = Convert.ToString(oObra_Modulo.obra_etapa.idobra_etapa);
                txtObra_EtapaDescricao.Text = Convert.ToString(oObra_Modulo.obra_etapa.descricao);
            }
        }
        
        private void txtidObra_Modulo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Modulo.Text))
            {
                cboObra_Modulo.Focus();
            }
            else
            {
                cboObra_Modulo.SelectedValue = Convert.ToInt32(txtidObra_Modulo.Text);
            }
        }

        #endregion

    }
}
