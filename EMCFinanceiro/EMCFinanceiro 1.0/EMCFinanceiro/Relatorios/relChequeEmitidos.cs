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
using EMCFinanceiroModel;
using System.Collections;

namespace EMCFinanceiro
{
    public partial class relChequeEmitidos : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relChequeEmiditos";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        int id_chequeemitir = 0;
        Boolean chequeemitir_diferente = false;

        public relChequeEmitidos(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relChequeEmitidos_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "chequeemitir";



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

            if (cboRelatorioEmitir.SelectedValue.ToString() == "1")
                listaChequeEmitidos();
            else if (cboRelatorioEmitir.SelectedValue.ToString() == "4")
                listaChequeNaoEmitido();
            else if (cboRelatorioEmitir.SelectedValue.ToString() == "3")
                listaChequeDetalhado();
            else
                listaCopiaCheque();
        }

        #endregion

        #region "Métodos Overrides"

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            try
            {
                //Monta período a emitir com base nos 30 últimos dias
                txtDtaInicial.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
                txtDtaFinal.Text = DateTime.Today.ToShortDateString();

                foreach (DataGridViewRow row in grdCheques.Rows)
                {
                    if (row.Cells[0].ReadOnly == false)
                    {
                        row.Cells[0].Value = false;
                    }
                }

                //inicializa combo de ordenação
                ArrayList arr = new ArrayList();
                arr.Add(new popCombo("Relação de Cheques", "1"));
                arr.Add(new popCombo("Relação de Cheques Detalhada", "3"));
                arr.Add(new popCombo("Cópia de Cheques", "2"));
                arr.Add(new popCombo("Relação de Cheques pendentes de emissão", "4"));
                cboRelatorioEmitir.DataSource = arr;
                cboRelatorioEmitir.DisplayMember = "nome";
                cboRelatorioEmitir.ValueMember = "valor";

                CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                CtaBancaria oConta = new CtaBancaria();
                oConta.codEmpresa = codempresa;
                cboContaBancaria.DataSource = oCtaBancariaRN.ListaCtaBancaria(oConta);
                cboContaBancaria.DisplayMember = "descricao";
                cboContaBancaria.ValueMember = "idctabancaria";

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region "Métodos Privados"

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

        private void AtualizaGrid()
        {

            ChequeEmitirRN oChequeEmitirRN = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
            grdCheques.DataSource = oChequeEmitirRN.PesquisaChequeEmitir(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

        }

        private void verificaIdChequeEmitir()
        {
            int id = 0;
            //id_fornecedor = EmcResources.cInt(txtIdPessoa.Text);
            id_chequeemitir = 0;
            chequeemitir_diferente = false;

            foreach (DataGridViewRow row in grdCheques.Rows)
            {
                if (!chequeemitir_diferente)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)row.Cells[0];

                    if (ch1.Value == ch1.TrueValue)
                    {
                        id = Convert.ToInt32(EmcResources.cInt(row.Cells["idchequeemitir"].Value.ToString()));

                        if (id != id_chequeemitir && id_chequeemitir > 0)
                        {
                            chequeemitir_diferente = true;
                        }
                        else
                            id_chequeemitir = id;
                    }
                }
            }
        }

        private void listaChequeEmitidos()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ChequeEmitir oCheque = new ChequeEmitir();
                ChequeEmitirRN oBLL = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;
                string drpDetalhe;


                drpRelatorio = oBLL.rptRelacaoCheque(Convert.ToDateTime(txtDtaInicial.Text),Convert.ToDateTime(txtDtaFinal.Text),EmcResources.cInt(cboContaBancaria.SelectedValue.ToString()));

                DataTable dtCheques = oBLL.Listar(drpRelatorio);

                string lstMovBancario = "";
                foreach (DataRow oRow in dtCheques.Rows)
                {
                    if (lstMovBancario.Length > 0)
                        lstMovBancario += ", ";

                    lstMovBancario += oRow["idmovimentobancario"].ToString();
                }

                drpDetalhe = oBLL.rptDetalheCheque(lstMovBancario);
                
                /* carrega o dataset com informações */
                this.dstCheques.Tables["pagamentos"].Clear();
                this.dstCheques.Tables["cheque"].Clear();

                this.dstCheques.Tables["cheque"].Load(dtCheques.CreateDataReader());
                this.dstCheques.Tables["pagamentos"].Load(oBLL.Listar(drpDetalhe).CreateDataReader());

                /* seta parametros do relatorio */
                rptRelCheque.SetParameterValue("periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                rptRelCheque.SetParameterValue("empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);

                if (chkPDF.Checked)
                {
                    rptRelCheque.Prepare();
                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                    if (export.ShowDialog())
                        rptRelCheque.Export(export, Application.UserAppDataPath + "\\cheque_emitidos.pdf");
                }
                else
                    rptRelCheque.Show();

            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaChequeNaoEmitido()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ChequeEmitir oCheque = new ChequeEmitir();
                ChequeEmitirRN oBLL = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;


                drpRelatorio = oBLL.rptRelacaoChequeNaoEmitido(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(cboContaBancaria.SelectedValue.ToString()));

                /* carrega o dataset com informações */
                this.dstCheques.Tables["pagamentos"].Clear();
                this.dstCheques.Tables["cheque"].Clear();
                this.dstCheques.Tables["cheque"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());

                /* seta parametros do relatorio */
                rptChequeNaoEmitido.SetParameterValue("periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                rptChequeNaoEmitido.SetParameterValue("empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);

                if (chkPDF.Checked)
                {
                    rptChequeNaoEmitido.Prepare();
                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                    if (export.ShowDialog())
                        rptChequeNaoEmitido.Export(export, Application.UserAppDataPath + "\\cheque_naoemitidos.pdf");
                }
                else
                    rptChequeNaoEmitido.Show();

            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaChequeDetalhado()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ChequeEmitir oCheque = new ChequeEmitir();
                ChequeEmitirRN oBLL = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;
                string drpDetalhe;

                drpRelatorio = oBLL.rptRelacaoCheque(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(cboContaBancaria.SelectedValue.ToString()));

                DataTable dtCheques = oBLL.Listar(drpRelatorio);

                string lstMovBancario = "";
                foreach(DataRow oRow in dtCheques.Rows)
                {
                    if (lstMovBancario.Length > 0)
                        lstMovBancario += ", ";

                    lstMovBancario += oRow["idmovimentobancario"].ToString();
                }

                drpDetalhe = oBLL.rptDetalheCheque(lstMovBancario);

                /* carrega o dataset com informações */
                this.dstCheques.Tables["pagamentos"].Clear();
                this.dstCheques.Tables["cheque"].Clear();
                
                this.dstCheques.Tables["cheque"].Load(dtCheques.CreateDataReader());
                this.dstCheques.Tables["pagamentos"].Load(oBLL.Listar(drpDetalhe).CreateDataReader());

                /* seta parametros do relatorio */
                rptChequeDetalhado.SetParameterValue("periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                rptChequeDetalhado.SetParameterValue("empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);

                if (chkPDF.Checked)
                {
                    rptChequeDetalhado.Prepare();
                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                    if (export.ShowDialog())
                        rptChequeDetalhado.Export(export, Application.UserAppDataPath + "\\cheque_emitidos.pdf");
                }
                else
                    rptChequeDetalhado.Show();

            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaCopiaCheque()
        {
            try
            {
                string lstMovBancario = "";
                string lstCheque = "";
                /* monta string para filtrar cheques a serem impressos */
                foreach(DataGridViewRow oRow in grdCheques.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)oRow.Cells[0];

                    if ( ch1.Value != null && ch1.Value.ToString() == "1")
                    {
                        if (lstCheque.Length > 0)
                        {
                            lstCheque += ", ";
                            lstMovBancario += ", ";
                        }

                        lstCheque += oRow.Cells["idchequeemitir"].Value.ToString();
                        lstMovBancario += oRow.Cells["idmovimentobancario"].Value.ToString();
                    }

                }

                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ChequeEmitir oCheque = new ChequeEmitir();
                ChequeEmitirRN oBLL = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;
                string drpDetalhe;

                drpRelatorio = oBLL.rptCopiaCheque(lstCheque);
                drpDetalhe = oBLL.rptDetalheCheque(lstMovBancario);

                DataTable dtCheques = oBLL.Listar(drpRelatorio);
                DataTable dtMovimento = oBLL.Listar(drpDetalhe);

                /* carrega o dataset com informações */
                this.dstCheques.Tables["pagamentos"].Clear();
                this.dstCheques.Tables["cheque"].Clear();

                this.dstCheques.Tables["cheque"].Load(dtCheques.CreateDataReader());
                this.dstCheques.Tables["pagamentos"].Load(dtMovimento.CreateDataReader());

                /* seta parametros do relatorio */
                rptCopiaCheque.SetParameterValue("periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                rptCopiaCheque.SetParameterValue("empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);

                if (chkPDF.Checked)
                {
                    rptCopiaCheque.Prepare();
                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                    if (export.ShowDialog())
                        rptCopiaCheque.Export(export, Application.UserAppDataPath + "\\copia_cheque.pdf");
                }
                else
                    rptCopiaCheque.Show();

            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region "Botões"

      

        private void btnPesquisarCheques_Click(object sender, EventArgs e)
        {
            try
            {

                ChequeEmitirRN oChequeEmitirRN = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);

                String stringLstCheque = oChequeEmitirRN.listaCopiaCheque(EmcResources.cInt(cboContaBancaria.SelectedValue.ToString()),
                                                                          Convert.ToDateTime(txtDtaInicial.Text),
                                                                          Convert.ToDateTime(txtDtaFinal.Text) );

                DataTable dtCon = oChequeEmitirRN.Listar(stringLstCheque);

                grdCheques.DataSource = dtCon;

                if (grdCheques.Rows.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdCheques.Rows)
                {
                    if (row.Cells[0].ReadOnly == false)
                    {
                        row.Cells[0].Value = true;
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnDesmarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdCheques.Rows)
                {
                    if (row.Cells[0].ReadOnly == false)
                    {
                        row.Cells[0].Value = false;
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        #endregion

        #region "Eventos"

        private void relChequeEmitidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

        }


        #endregion

    }
}
