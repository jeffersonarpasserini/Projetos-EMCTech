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
    public partial class relCtasPagar : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relCtasPagar";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relCtasPagar(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relCtasPagar_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "pagarparcelas";

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

                PagarParcelaRN oBLL = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (ckFornecedores.Checked && ckSintetico.Checked)
                {
                    drpRelatorio = oBLL.DataReport5(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
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
                            report3.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report3.Show();
                }
                else

                if (!String.IsNullOrEmpty(txtIdFornecedor.Text) && ckSintetico.Checked)
                {
                    drpRelatorio = oBLL.DataReport4( EmcResources.cInt(txtIdFornecedor.Text), Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
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
                            report3.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report3.Show();
                }
                else

                if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text) && ckFornecedores.Checked)
                {
                    drpRelatorio = oBLL.DataReport6(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(txtIdTipoDocumento.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período e Tipo Documento Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString() + " Tipo Documento " + txtTipoDocumento.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report2.Show();
                }
                else

                if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text) && !String.IsNullOrEmpty(txtIdFornecedor.Text))
                {
                    drpRelatorio = oBLL.DataReport7(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(txtIdTipoDocumento.Text), EmcResources.cInt(txtIdFornecedor.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para Período, Tipo Documento e Fornecedor Informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString() + " Tipo Documento " + txtTipoDocumento.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report2.Show();
                }
                else

                if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
                {
                    drpRelatorio = oBLL.DataReport6(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text),EmcResources.cInt(txtIdTipoDocumento.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período e Tipo Documento Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report1.SetParameterValue("Periodo", "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString() +" Tipo Documento "+txtTipoDocumento.Text.ToString());
                    report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report1.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report1.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report1.Show();
                }
                else
                if(ckFornecedores.Checked)
                {
                    drpRelatorio = oBLL.DataReport5(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "por Fornecedores no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report2.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtIdFornecedor.Text))
                {
                    drpRelatorio = oBLL.DataReport4(EmcResources.cInt(txtIdFornecedor.Text), Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));
                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para o fornecedor informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    report2.SetParameterValue("Periodo", "para o " +txtFornecedor.Text.ToString() + " no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    report2.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    if (chkPDF.Checked)
                    {
                        report2.Prepare();
                        FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                        if (export.ShowDialog())
                            report2.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report2.Show();
                }
                else if (ckatevencimento.Checked)
                {
                    drpRelatorio = oBLL.DataReport3(Convert.ToDateTime(txtDataVencimento.Text));
                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
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
                            report1.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report1.Show();
                }
                else if (ckdatavencimento.Checked)
                {
                    drpRelatorio = oBLL.DataReport2(Convert.ToDateTime(txtDataVencimento.Text));
                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
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
                            report1.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
                    }
                    else
                        report1.Show();
                }       
                else
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasPagar.Tables["MyTable"].Clear();
                    this.dstCtasPagar.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasPagar.Tables["MyTable"].Rows.Count) == 0)
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
                            report1.Export(export, Application.UserAppDataPath + "\\ctapagar.pdf");
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
            ckFornecedores.Checked = false;
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

        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdFornecedor.Text))
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);

                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                txtFornecedor.Text = oFornecedor.pessoa.nome;
                
                if (txtIdFornecedor == null)
                {

                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
             //   txtIdFornecedor.Text = "";
            }
            else
                txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdFornecedor.Focus();
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

        private void relCtasPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
                     
        }
       
        
    }
}
