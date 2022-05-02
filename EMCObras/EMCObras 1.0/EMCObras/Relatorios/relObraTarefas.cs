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
using EMCObrasRN;
using EMCCadastro;
using EMCCadastroRN;
using EMCObrasModel;
using EMCCadastroModel;
using System.Collections;


namespace EMCObras.Relatorios
{
    public partial class relObraTarefas : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relObraCronograma";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relObraTarefas(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
            InitializeComponent();
        }

        private void relObraTarefas_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_tarefas";

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        private void relObraTarefas_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();

            //inicializa combo de ordenação
            //cboOrdenar.Items.Clear();
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Código Tarefa", "1"));
            arr.Add(new popCombo("Tarefa", "2"));
            cboOrdenar.DataSource = arr;
            cboOrdenar.DisplayMember = "nome";
            cboOrdenar.ValueMember = "valor";
        }

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

                Obra_TarefaRN oBLL = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (cboOrdenar.SelectedValue == "1")
                {

                    drpRelatorio = oBLL.DataReport();
                    this.dstTarefas.Tables["MyTable"].Clear();
                    this.dstTarefas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstTarefas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    tarefas.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    tarefas.Show();
                }
                else
                {
                    drpRelatorio = oBLL.DataReport1();
                    this.dstTarefas.Tables["MyTable"].Clear();
                    this.dstTarefas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstTarefas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    tarefas.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    tarefas.Show();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }


    }
}
