using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCFinanceiroModel;
using EMCFinanceiroRN;

namespace EMCFinanceiro
{
    public partial class frmGrdMovBancario : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmGrdMovBancario";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        //private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        Decimal vSdoFinalConciliado_geral = 0;


        public frmGrdMovBancario()
        {
            InitializeComponent();
        }
        public frmGrdMovBancario(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmGrdMovBanario_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "movimentobancario";


            CtaBancaria oCta = new CtaBancaria();
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta.codEmpresa = codempresa;

            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idctabancaria";

            //AtualizaGrid();
            CancelaOperacao();

            this.ActiveControl = cboIdContaBancaria;

            travaBotao("btnSalvar");
            travaBotao("btnExcluir");

        }


        #region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaGrdMovBancario(Formulario oGrdMovBancario)
        {
            FormularioRN oGrdMovBancarioRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oGrdMovBancarioRN.VerificaDados(oGrdMovBancario);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        private List<MovimentoBancario> montaGrdMovBancario()
        {
            List<MovimentoBancario> lstMovimentoBancario = new List<MovimentoBancario>();
            


            return lstMovimentoBancario;
        }
        private void montaTela(Formulario oFormulario)
        {
            
            objOcorrencia.chaveidentificacao = oFormulario.idFormulario.ToString();

        }
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

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
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();

            cboIdContaBancaria.Focus();


        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            travaBotao("btnSalvar");
            travaBotao("btnExcluir");
            objOcorrencia.chaveidentificacao = "";
            vSdoFinalConciliado_geral = 0;
        }
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            
            try
            {
                lblSdoFinal.Text = "0,00";
                lblSdoFinalConciliado.Text = "0,00";
                lblSdoInicial.Text = "0,00";
                lblSdoInicialConciliado.Text = "0,00";
                vSdoFinalConciliado_geral = 0;

                if (cboIdContaBancaria.SelectedIndex > -1)
                    AtualizaGrid();
                else
                    MessageBox.Show("Escolher conta para conciliação.", "EMCFinanceiro", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro GrdMovBancario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public override void LimpaCampos()
        {
            base.LimpaCampos();

            travaBotao("btnSalvar");
            travaBotao("btnExcluir");

            vSdoFinalConciliado_geral = 0;

            lblSdoFinal.Text = "0,00";
            lblSdoFinalConciliado.Text = "0,00";
            lblSdoInicial.Text = "0,00";
            lblSdoInicialConciliado.Text = "0,00";

            objOcorrencia.chaveidentificacao = "";
        }
        public override void ImprimeObjeto()
        {
            Decimal sdoInicial=0;

            try
            {
                if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
                {
                    MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (cboIdContaBancaria.SelectedIndex > -1)
                    {
                        Empresa oEmpresa = new Empresa();
                        oEmpresa.idEmpresa = codempresa;
                        EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                        oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                        CtaBancaria oCtaBancaria = new CtaBancaria();
                        oCtaBancaria.idCtaBancaria = EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString());
                        oCtaBancaria.codEmpresa = codempresa;

                        CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                        oCtaBancaria = oCtaRN.ObterPor(oCtaBancaria);

                        string descr_conta = "Bco : " + oCtaBancaria.Banco.idBanco + " Ag.: " + oCtaBancaria.agencia + "-" + oCtaBancaria.agenciaDigito +
                                                     " Conta : " + oCtaBancaria.conta + "-" + oCtaBancaria.contaDigito;

                        MovimentoBancarioRN oMovBancoRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);

                        DataTable datMovBancario = new DataTable();
                        datMovBancario = oMovBancoRN.ListaExtratoBancario(codempresa, empMaster,
                                                                             EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString()),
                                                                             Convert.ToDateTime(txtDataInicio.Text),
                                                                             Convert.ToDateTime(txtDataFinal.Text),
                                                                             chkMovimentoConciliado.Checked
                                                                             );
                        this.dtMovBancario.Tables["Extrato"].Clear();
                        this.dtMovBancario.Tables["Extrato"].Load(datMovBancario.CreateDataReader());

                        calculaSaldos();

                        if (Convert.ToInt32(this.dtMovBancario.Tables["Extrato"].Rows.Count) > 0)
                        {

                            if (chkMovimentoConciliado.Checked)
                            {
                                /* Imprime extrato conciliado */
                                sdoInicial = EmcResources.cCur(lblSdoInicialConciliado.Text);

                                rptExtratoConciliado.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                                rptExtratoConciliado.SetParameterValue("contaBancaria", descr_conta);
                                rptExtratoConciliado.SetParameterValue("Periodo", "Período " + txtDataInicio.Text.ToString() + " a " + txtDataFinal.Text.ToString());
                                rptExtratoConciliado.SetParameterValue("saldoInicial", sdoInicial.ToString());
                                rptExtratoConciliado.SetParameterValue("saldo", sdoInicial);

                                if (chkPDF.Checked)
                                {
                                    rptExtratoConciliado.Prepare();
                                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                    if (export.ShowDialog())
                                        rptExtratoConciliado.Export(export, Application.UserAppDataPath + "\\extratoconciliado.pdf");
                                }
                                else
                                    rptExtratoConciliado.Show();
                            }
                            else
                            {

                                /* imprime extrato normal */
                                
                                sdoInicial = EmcResources.cCur(lblSdoInicial.Text);
                                

                                rptExtrato.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                                rptExtrato.SetParameterValue("contaBancaria", descr_conta);
                                rptExtrato.SetParameterValue("Periodo", "Período " + txtDataInicio.Text.ToString() + " a " + txtDataFinal.Text.ToString());
                                rptExtrato.SetParameterValue("saldoinicial", sdoInicial);
                                if (chkPDF.Checked)
                                {
                                    rptExtrato.Prepare();
                                    FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                    if (export.ShowDialog())
                                        rptExtrato.Export(export, Application.UserAppDataPath + "\\extrato.pdf");
                                }
                                else
                                    rptExtrato.Show();
                            }
                        }
                        else
                            MessageBox.Show("Não foram encontrados lançamentos para a conta no período.");

                    }
                    else
                        MessageBox.Show("Escolher conta para conciliação.", "EMCFinanceiro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public override void SalvaObjeto()
        {
            try
            {

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        public override void AtualizaObjeto()
        {
            try
            {
                int vCodCtaBancaria = EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString());
                DateTime vDataInicio = Convert.ToDateTime(txtDataInicio.Text);
                DateTime vDataFinal = Convert.ToDateTime(txtDataFinal.Text);

                List<MovimentoBancario> lstMovBanco = new List<MovimentoBancario>();
                foreach (DataGridViewRow row in grdMovBanco.Rows)
                {

                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (ch1.Value.ToString() == "True")
                    {
                        MovimentoBancario oMovBanco = new MovimentoBancario();
                        MovimentoBancarioRN oMovBancoDAO = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);

                        oMovBanco.idMovimentoBancario = EmcResources.cInt(row.Cells["idmovimentobancario"].Value.ToString());
                        oMovBanco = oMovBancoDAO.ObterPor(oMovBanco);
                        
                        oMovBanco.dataConciliacao = Convert.ToDateTime(row.Cells["vdataconciliacao"].Value.ToString());
                        oMovBanco.situacao = "C";
                        oMovBanco.codEmpresa = codempresa;

                        lstMovBanco.Add(oMovBanco);

                    }

                }
                MovimentoBancarioRN oMovRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                oMovRN.conciliaMovimento(lstMovBanco);

                vSdoFinalConciliado_geral = 0;

                lblSdoFinal.Text = "0,00";
                lblSdoFinalConciliado.Text = "0,00";
                lblSdoInicial.Text = "0,00";
                lblSdoInicialConciliado.Text = "0,00";

                cboIdContaBancaria.SelectedValue = vCodCtaBancaria;
                txtDataInicio.Text = vDataInicio.ToString();
                txtDataFinal.Text = vDataFinal.ToString();

                AtualizaGrid();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            //base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
        #endregion
        #region "Tratamentos para buttons e texts**************************************************************************************"

       
        #endregion
        #region "metodos da dbgrid*******************************************************************************************"
        private void grdMovBanco_DoubleClick(object sender, EventArgs e)
        {
            
        }

        private void AtualizaGrid()
        {
            if (EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString()) > 0)
            {
                //carrega a grid com os ceps cadastrados
                MovimentoBancarioRN oMovBancoRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);

                DataTable dtMovBancario = oMovBancoRN.ListaExtratoBancario(codempresa, empMaster,
                                                                         EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString()),
                                                                         Convert.ToDateTime(txtDataInicio.Text),
                                                                         Convert.ToDateTime(txtDataFinal.Text),
                                                                         chkMovimentoConciliado.Checked
                                                                         );
       
                calculaSaldos();

                decimal calcSaldo = EmcResources.cCur(lblSdoInicial.Text);
                decimal calcSaldoConc = EmcResources.cCur(lblSdoInicialConciliado.Text);

                decimal ?valorDebito = 0;
                decimal ?valorCredito = 0;

                
                foreach (DataRow row in dtMovBancario.Rows)
                {
                    //inicializa todos os campos vdataconciliação com espacao e a check com false

                    calcSaldo = (calcSaldo + EmcResources.cCur(row["valorcredito"].ToString())) - EmcResources.cCur(row["valordebito"].ToString());



                    grdMovBanco.Rows.Add(0, row["historico"].ToString(), "", row["datamovimento"].ToString(),
                                         row["dataconciliacao"].ToString(), row["valorcredito"],
                                         row["valordebito"], calcSaldo, "", row["documento"].ToString(), 
                                         row["chequeemitido"].ToString(), row["nominal"].ToString(), row["historicoagrupado"].ToString(),
                                         row["idmovimentobancario"].ToString(), row["codempresa"].ToString(), row["codempresa_pessoa"].ToString(),
                                         row["idpessoa"].ToString(), row["ctabancaria_idempresa"].ToString(), row["ctabancaria_idctabancaria"].ToString(),
                                         row["situacao"].ToString());

                }
                
                foreach (DataGridViewRow rowGrd in grdMovBanco.Rows)
                {
                    
                    if (rowGrd.Cells["situacao"].Value.ToString() == "C")
                    {
                        calcSaldoConc = (calcSaldoConc + EmcResources.cCur(rowGrd.Cells["vlrcredito"].Value.ToString())) - EmcResources.cCur(rowGrd.Cells["vlrdebito"].Value.ToString());
                        rowGrd.Cells["saldoconciliado"].Value = calcSaldoConc;
                    }
                    
                    //verifica se o movimento já está conciliado e trava a edição no campo vdataconcilicao nesta row
                    if (!String.IsNullOrEmpty(rowGrd.Cells["dataconciliacao"].Value.ToString()))
                    {
                        rowGrd.Cells[0].ReadOnly = true;
                        rowGrd.Cells["vdataconciliacao"].ReadOnly = true;
                    }
                }

                if (grdMovBanco.Rows.Count > 0)
                    liberaBotao("btnAtualizar");
                else
                    travaBotao("btnAtualizar");

                mudaCorSaldos();

            }
        }

        private void grdMovBanco_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 1)
                {

                    if (!String.IsNullOrEmpty(grdMovBanco.CurrentCell.Value.ToString()) &&
                        !String.IsNullOrWhiteSpace(grdMovBanco.CurrentCell.Value.ToString()))
                    {
                        Double datagrid = Convert.ToDouble(grdMovBanco.CurrentCell.Value);
                        string vdata = String.Format(@"{0:00\/00\/0000}", datagrid);
                        DateTime dt = Convert.ToDateTime(vdata);

                        DateTime dtMovimento = Convert.ToDateTime(grdMovBanco.CurrentRow.Cells["datamovimento"].Value.ToString());

                        //verifica se a data de conciliação é menor do que a data do movimento
                        if (dt < dtMovimento)
                        {
                            Exception oDataMov = new Exception("Data Conciliação é menor do que a data do movimento");
                            throw oDataMov;
                        }

                        grdMovBanco.CurrentCell.Value = dt.ToShortDateString();
                        grdMovBanco.CurrentRow.Cells[0].Value = true;

                    }
                    else
                    {
                        grdMovBanco.CurrentCell.Value = "";
                        grdMovBanco.CurrentRow.Cells[0].Value = false;
                    }
                    
                }
                else if (e.ColumnIndex == 0)
                {
                   

                }
            }
            catch (Exception erro)
            {
                if (e.ColumnIndex == grdMovBanco.Columns["vdataconciliacao"].Index)
                {
                    MessageBox.Show("Data Inválida : " + erro.Message );
                    grdMovBanco.CurrentCell.Value = "";
                    grdMovBanco.CurrentRow.Cells[0].Value = false;
                }
                else
                    MessageBox.Show(erro.Message);
            }
        }

        private void grdMovBanco_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdMovBanco.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void grdMovBanco_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grdMovBanco.Rows[grdMovBanco.CurrentRow.Index].Cells[0];
                    if (ch1.Value.ToString() == "True")
                    {
                        if (String.IsNullOrEmpty(grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value.ToString()) ||
                            String.IsNullOrWhiteSpace(grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value.ToString()) ||
                            grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value.ToString() == "null")
                        {
                            grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value = txtDtaConciliacao.Text;

                            //verifica se a data de conciliação é menor do que a data do movimento
                            DateTime dt = Convert.ToDateTime(txtDtaConciliacao.Text);
                            DateTime dtMovimento = Convert.ToDateTime(grdMovBanco.CurrentRow.Cells["datamovimento"].Value.ToString());
                            if (dt < dtMovimento)
                            {
                                Exception oDataMov = new Exception("Data Conciliação é menor do que a data do movimento");
                                throw oDataMov;
                            }


                            //se o movimento estiver conciliado não mexe em saldos conciliados
                            if (String.IsNullOrEmpty(grdMovBanco.CurrentRow.Cells["dataconciliacao"].Value.ToString()))
                            {
                                if (EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrcredito"].Value.ToString()) > 0)
                                {                                    
                                    vSdoFinalConciliado_geral = vSdoFinalConciliado_geral + EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrcredito"].Value.ToString());
                                    grdMovBanco.CurrentRow.Cells["saldoconciliado"].Value = vSdoFinalConciliado_geral;
                                }
                                else
                                {
                                    vSdoFinalConciliado_geral = vSdoFinalConciliado_geral + (EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrdebito"].Value.ToString())*-1);
                                    grdMovBanco.CurrentRow.Cells["saldoconciliado"].Value = vSdoFinalConciliado_geral;
                                }
                            }
                         }
                    }
                    else
                    {
                        //se o movimento estiver conciliado não mexe em saldos conciliados
                        if (!String.IsNullOrEmpty(grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value.ToString()) && grdMovBanco.CurrentRow.Cells["situacao"].Value.ToString() != "C")
                        {
                            if (EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrcredito"].Value.ToString()) > 0)
                            {
                                vSdoFinalConciliado_geral = vSdoFinalConciliado_geral - EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrcredito"].Value.ToString());
                                grdMovBanco.CurrentRow.Cells["saldoconciliado"].Value = "";
                            }
                            else
                            {
                                vSdoFinalConciliado_geral = vSdoFinalConciliado_geral + EmcResources.cCur(grdMovBanco.CurrentRow.Cells["vlrdebito"].Value.ToString());
                                grdMovBanco.CurrentRow.Cells["saldoconciliado"].Value = "";
                            }
                        }
                        grdMovBanco.CurrentRow.Cells["vdataconciliacao"].Value = "";
                    }
                    lblSdoFinalConciliado.Text = vSdoFinalConciliado_geral.ToString();
                    
                }
                mudaCorSaldos();
            }
            catch (Exception erro)
            {
                if ( erro.Message != "Referência de objeto não definida para uma instância de um objeto.")
                    MessageBox.Show(erro.Message);
            }
        }

        private void grdMovBanco_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.grdMovBanco.Columns[e.ColumnIndex].Name == "saldo")
            {
                    //checa se o saldo é negativo
                    if (EmcResources.cCur(grdMovBanco.Rows[e.RowIndex].Cells["saldo"].Value.ToString()) < 0 )
                    {
                        grdMovBanco.Rows[e.RowIndex].Cells["saldo"].Style.ForeColor = Color.Red;
                    }
                    if (EmcResources.cCur(grdMovBanco.Rows[e.RowIndex].Cells["saldoconciliado"].Value.ToString()) < 0)
                    {
                        grdMovBanco.Rows[e.RowIndex].Cells["saldoconciliado"].Style.ForeColor = Color.Red;
                    }
            }

        }

        #endregion

        private void cboIdContaBancaria_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboIdContaBancaria.SelectedValue != null)
                {
                    calculaSaldos();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void calculaSaldos()
        {
            try
            {
               
                decimal vSdoInicial = 0;
                decimal vSdoInicialConciliado = 0;
                decimal vCredito = 0;
                decimal vDebito = 0;
                decimal vSomaDebMovimento = 0;
                decimal vSomaCreMovimento = 0;
                decimal vSdoFinal = 0;
                decimal vSdoFinalConciliado = 0;

                CtaBancaria oConta = new CtaBancaria();
                CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);

                oConta.codEmpresa = codempresa;
                oConta.idCtaBancaria = EmcResources.cInt(cboIdContaBancaria.SelectedValue.ToString());

                oConta = oCtaRN.ObterPor(oConta);

                DateTime vDtaInicio = DateTime.Parse("01/01/0001");
                DateTime vDtaFinal = Convert.ToDateTime(txtDataInicio.Text).AddDays(-1);

                bool vConciliado = false;
                if (chkMovimentoConciliado.Checked)
                    vConciliado = true;

                //Calcula Saldo Inicial
                MovimentoBancarioRN oMovRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                vCredito = EmcResources.cCur(oMovRN.calculaCredito(codempresa, vDtaInicio, vDtaFinal, oConta, false).ToString());
                vDebito = EmcResources.cCur(oMovRN.calculaDebito(codempresa, vDtaInicio, vDtaFinal, oConta, false).ToString());
                vSdoInicial = vSdoInicial + vCredito - vDebito;

                vCredito = EmcResources.cCur(oMovRN.calculaCredito(codempresa, vDtaInicio, vDtaFinal, oConta, true).ToString());
                vDebito = EmcResources.cCur(oMovRN.calculaDebito(codempresa, vDtaInicio, vDtaFinal, oConta, true).ToString());
                vSdoInicialConciliado = vSdoInicialConciliado + vCredito - vDebito;


                //txtSdoInicial.Text = String.Format("{0:c}", vSdoInicial);
                lblSdoInicial.Text = vSdoInicial.ToString();
                lblSdoInicialConciliado.Text = vSdoInicialConciliado.ToString();


                //calcula movimento no período solicitado
                vSomaCreMovimento = EmcResources.cCur(oMovRN.calculaCredito(codempresa, Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text), oConta, false).ToString());
                vSomaDebMovimento = EmcResources.cCur(oMovRN.calculaDebito(codempresa, Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text), oConta, false).ToString());
                vSdoFinal = vSdoInicial + vSomaCreMovimento - vSomaDebMovimento;

                vSomaCreMovimento = EmcResources.cCur(oMovRN.calculaCredito(codempresa, Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text), oConta, true).ToString());
                vSomaDebMovimento = EmcResources.cCur(oMovRN.calculaDebito(codempresa, Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text), oConta, true).ToString());
                vSdoFinalConciliado = vSdoInicialConciliado + vSomaCreMovimento - vSomaDebMovimento;


                lblSdoFinal.Text = vSdoFinal.ToString();
                lblSdoFinalConciliado.Text = vSdoFinalConciliado.ToString();

                if (vSdoFinalConciliado_geral == 0)
                {
                    vSdoFinalConciliado_geral = EmcResources.cCur(lblSdoFinalConciliado.Text);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }


        private void txtSdoFinal_TextChanged(object sender, EventArgs e)
        {
            decimal valor = EmcResources.cCur(lblSdoFinal.Text);
            if (valor < 0)
                lblSdoFinal.ForeColor = Color.Red;
            else
                lblSdoFinal.ForeColor = Color.Black;
            
        }

        private void mudaCorSaldos()
        {
            //txtSdoFinal.Enabled = true;
            //txtSdoFinalConciliado.Enabled = true;

            //muda cores de saldos iniciais
            decimal calcSaldo = EmcResources.cCur(lblSdoInicial.Text);
            decimal calcSaldoConc = EmcResources.cCur(lblSdoInicialConciliado.Text);
            
            if (calcSaldo < 0)
                lblSdoInicial.ForeColor = Color.Red;
            else
                lblSdoInicial.ForeColor = Color.Black;

            if (calcSaldoConc < 0)
                lblSdoInicialConciliado.ForeColor = Color.Red;
            else
                lblSdoInicialConciliado.ForeColor = Color.Black;

            //muda cores de saldos finais
            calcSaldo = EmcResources.cCur(lblSdoFinal.Text);
            calcSaldoConc = EmcResources.cCur(lblSdoFinalConciliado.Text);

            if (calcSaldo < 0)
            {
                lblSdoFinal.ForeColor = Color.Red;
            }
            else
                lblSdoFinal.ForeColor = Color.Black;

            if (calcSaldoConc < 0)
                lblSdoFinalConciliado.ForeColor = Color.Red;
            else
                lblSdoFinalConciliado.ForeColor = Color.Black;

            //txtSdoFinalConciliado.Enabled = false;
            //txtSdoFinal.Enabled = false;
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdMovBanco.Rows)
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
                foreach (DataGridViewRow row in grdMovBanco.Rows)
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

    }
}
