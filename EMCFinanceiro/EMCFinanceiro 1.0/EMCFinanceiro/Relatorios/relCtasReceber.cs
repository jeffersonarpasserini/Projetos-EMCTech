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
using EMCFinanceiroRN;
using EMCCadastro;
using EMCCadastroRN;
using EMCCadastroModel;

namespace EMCFinanceiro
{
    public partial class relCtasReceber : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relCtasPagar";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relCtasReceber(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relCtasReceber_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "receberparcela";

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

            if (ValidaCampos() == false)
            {
                return;
            }

            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ReceberParcelaRN oBLL = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (ckClientes.Checked && ckSintetico.Checked)
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período e Tipo Documento Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report3.SetParameterValue("Periodo", "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report3.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report3.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report3.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report3.Show();
                }
                else

                    if (!String.IsNullOrEmpty(txtIdCliente.Text) && ckSintetico.Checked)
                    {
                        drpRelatorio = oBLL.DataReport4(EmcResources.cInt(txtIdCliente.Text), Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                        this.dstCtasReceber.Tables["MyTable"].Clear();
                        this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                        {
                            MessageBox.Show("Não foram encontrados registros no Período e Tipo Documento Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        report3.SetParameterValue("Periodo", "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                        report3.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        if (chkPDF.Checked)
                        {
                            report3.Prepare();
                            FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                            if (export.ShowDialog())
                                report3.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                        }
                        else
                            report3.Show();
                    }
                    else

                if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
                {
                    drpRelatorio = oBLL.DataReport5(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(txtIdTipoDocumento.Text));

                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "de Clientes no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report2.Show();
                }
                else

                if (ckClientes.Checked)
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "de Clientes no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report2.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    drpRelatorio = oBLL.DataReport4(EmcResources.cInt(txtIdCliente.Text), Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));
                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para o cliente e período informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "Cliente " + txtCliente.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report2.Show();
                }
                else
                if (ckatevencimento.Checked)
                {
                    drpRelatorio = oBLL.DataReport3(Convert.ToDateTime(txtDataVencimento.Text));
                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report1.SetParameterValue("Periodo", "Período até " + txtDataVencimento.Text.ToString());
                    report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report1.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report1.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report1.Show();
                }
                else 
                if (ckdatavencimento.Checked)
                {
                    drpRelatorio = oBLL.DataReport2(Convert.ToDateTime(txtDataVencimento.Text));
                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report1.SetParameterValue("Periodo", "Período de " + txtDataVencimento.Text.ToString());
                    report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report1.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report1.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report1.Show();
                }

                else
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasReceber.Tables["MyTable"].Clear();
                    this.dstCtasReceber.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasReceber.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report1.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report1.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report1.Export(export, Application.UserAppDataPath + "\\ctareceber.pdf");
                    }
                    else
                        report1.Show();

                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        #endregion

        #region "Métodos Overrides"

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            //Monta período a emitir com base nos 30 últimos dias
            txtDtaInicial.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
            txtDtaFinal.Text = DateTime.Today.ToShortDateString();

            ckatevencimento.Checked = false;
            ckdatavencimento.Checked = false;
            ckClientes.Checked = false;
            ckSintetico.Checked = false;

        }

        #endregion

        private Boolean ValidaCampos()
        {
            if (String.IsNullOrEmpty(txtDtaInicial.Text.ToString()))
            {
                MessageBox.Show("A Data Inicial deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (String.IsNullOrEmpty(txtDtaFinal.Text.ToString()))
            {
                MessageBox.Show("A Data Final deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDtaFinal.Value < txtDtaInicial.Value)
            {
                MessageBox.Show("A Data Final deve ser Maior que a Data Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text))
            try
            {
                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);

                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                txtCliente.Text = oCliente.pessoa.nome;

                if (txtIdCliente == null)
                {

                }
            }
             
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                // txtIdCliente.Text = "";
            }
            else
                txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdCliente.Focus();
            SendKeys.Send("{TAB}");
        }

        private void relCtasReceber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
                     
        }

        private void txtIdTipoDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
                try
                {
                    TipoDocumento oTipoDocumento = new TipoDocumento();

                    TipoDocumentoRN oTipoDocumentoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oTipoDocumento.idTipoDocumento = EmcResources.cInt(txtIdTipoDocumento.Text);

                    oTipoDocumento = oTipoDocumentoRN.ObterPor(oTipoDocumento);

                    txtTipoDocumento.Text = oTipoDocumento.descricao;

                    if (txtIdTipoDocumento == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnTipoDocumento_Click(object sender, EventArgs e)
        {
            psqTipoDocumento ofrm = new psqTipoDocumento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdTipoDocumento.Text = "";
            }
            else
                txtIdTipoDocumento.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdTipoDocumento.Focus();
            SendKeys.Send("{TAB}");
        }

              
    }
}
