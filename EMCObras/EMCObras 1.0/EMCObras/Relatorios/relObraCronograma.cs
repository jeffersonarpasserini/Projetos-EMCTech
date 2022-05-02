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
    public partial class relObraCronograma : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relObraCronograma";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relObraCronograma(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

            ArrayList arrSituacao = new ArrayList();
            arrSituacao.Add(new popCombo("ABERTA", "A"));
            arrSituacao.Add(new popCombo("APROVADA", "L"));
            arrSituacao.Add(new popCombo("ENCERRADA", "E"));
            cboSituacao.DataSource = arrSituacao;
            cboSituacao.DisplayMember = "nome";
            cboSituacao.ValueMember = "valor";

         
                       
        }

        private void relObraCronograma_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_cronograma";

            LimpaCampos();
           
           
        }

        private void relObraCronograma_KeyDown(object sender, KeyEventArgs e)
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

                Obra_CronogramaRN oBLL = new Obra_CronogramaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (rdDtaInicio.Checked)
                {
                    drpRelatorio = oBLL.drDtaIncio(codempresa, cboSituacao.SelectedValue.ToString(), Convert.ToDateTime(txtDtaInicio.Text), Convert.ToDateTime(txtDtaFinal.Text));
                    this.dstObras.Tables["MyTable"].Clear();
                    this.dstObras.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstObras.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    obras.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    obras.Show();
                }
                else
                    if (rdDtaFinal.Checked)
                    {
                        drpRelatorio = oBLL.drDtaFinal(codempresa, cboSituacao.SelectedValue.ToString(), Convert.ToDateTime(txtDtaInicio.Text), Convert.ToDateTime(txtDtaFinal.Text));
                        this.dstObras.Tables["MyTable"].Clear();
                        this.dstObras.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        if (Convert.ToInt32(this.dstObras.Tables["MyTable"].Rows.Count) == 0)
                        {
                            MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        obras.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        obras.Show();
                    }
                    else
                    {
                        drpRelatorio = oBLL.drSituacao(codempresa, cboSituacao.SelectedValue.ToString());
                        this.dstObras.Tables["MyTable"].Clear();
                        this.dstObras.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        if (Convert.ToInt32(this.dstObras.Tables["MyTable"].Rows.Count) == 0)
                        {
                            MessageBox.Show("Registros não encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        obras.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        obras.Show();
                    }
            }
            

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

            
     
    }
}
