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
    public partial class relObraEtapa : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relObraCronograma";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relObraEtapa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relObraEtapa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_etapa";

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();

            //inicializa combo de ordenação
            //cboOrdenar.Items.Clear();
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Código Etapa", "1"));
            arr.Add(new popCombo("Etapa", "2"));
            cboOrdenar.DataSource = arr;
            cboOrdenar.DisplayMember = "nome";
            cboOrdenar.ValueMember = "valor";
        }

        private void relObraEtapa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
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

                Obra_EtapaRN oBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (cboOrdenar.SelectedValue == "1")
                {

                    drpRelatorio = oBLL.DataReport();
                    this.dstEtapas.Tables["MyTable"].Clear();
                    this.dstEtapas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstEtapas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    etapas.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    etapas.Show();
                }
                else
                {
                    drpRelatorio = oBLL.DataReport1();
                    this.dstEtapas.Tables["MyTable"].Clear();
                    this.dstEtapas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstEtapas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    etapas.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    etapas.Show();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
         }

     }
}
