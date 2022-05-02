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
using EMCSecurityRN;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCCadastro;
using EMCFinanceiroModel;
using EMCFinanceiroRN;

namespace EMCFinanceiro
{
    public partial class relCtasPagarBaixa : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relCtasPagarBaixa";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


         public relCtasPagarBaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void relCtasPagarBaixa_Load(object sender, EventArgs e)
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
             objOcorrencia.tabela = "pagarrateio";

             this.LimpaCampos();

             CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
             CtaBancaria oCta = new CtaBancaria();
             oCta.codEmpresa = codempresa;
             cboCtaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
             cboCtaBancaria.ValueMember = "idctabancaria";
             cboCtaBancaria.DisplayMember = "descricao";


             FormaPagamentoRN oFormaRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
             FormaPagamento oForma = new FormaPagamento();
             cboFormaPagamento.DataSource = oFormaRN.ListaFormaPagamento();
             cboFormaPagamento.ValueMember = "idformapagamento";
             cboFormaPagamento.DisplayMember = "descricao";

         }

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
                     MessageBox.Show("Erro Pesquisa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 }
         }

         private void btnFornecedor_Click(object sender, EventArgs e)
         {
             psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
             ofrm.ShowDialog();

             if (EMCCadastro.retPesquisa.chaveinterna == 0)
             {
                 // txtIdFornecedor.Text = "";
             }
             else
                 txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

             txtIdFornecedor.Focus();
             SendKeys.Send("{TAB}");
         }

         public override void btnRelatorio_Click(object sender, EventArgs e)
         {
             try
             {
                 DataTable relatorio = new DataTable();
                 String descricaorelatorio = "";

                 if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
                 {
                     MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     return;
                 }
                 else
                 {
                     if (ValidaCampos() == true)
                     {
                         Empresa oEmpresa = new Empresa();
                         oEmpresa.idEmpresa = codempresa;
                         EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                         oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                         
                         PagarBaixaRN oBaixaRN = new PagarBaixaRN(Conexao,objOcorrencia,codempresa);

                         int idFormaPagto = 0;
                         descricaorelatorio = "Baixas : ";

                         if (chkFormaPagto.Checked == false && cboFormaPagamento.SelectedIndex >= 0)
                         {
                             idFormaPagto = EmcResources.cInt(cboFormaPagamento.SelectedValue.ToString());
                         }

                         if (chkFornecedor.Checked == true && chkTodasContas.Checked == true)
                         {

                             relatorio = oBaixaRN.relatorioBaixas(Convert.ToDateTime(txtDtaInicial.Text),
                                                                            Convert.ToDateTime(txtDtaFinal.Text),
                                                                            empMaster, 0, chkFornecedor.Checked, 0, chkTodasContas.Checked,
                                                                            idFormaPagto,chkFormaPagto.Checked);

                         }
                         else if (chkFornecedor.Checked == true && chkTodasContas.Checked == false)
                         {
                             relatorio = oBaixaRN.relatorioBaixas(Convert.ToDateTime(txtDtaInicial.Text),
                                                                            Convert.ToDateTime(txtDtaFinal.Text),
                                                                            empMaster, 0, chkFornecedor.Checked, 
                                                                            EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString()),
                                                                            chkTodasContas.Checked, idFormaPagto, chkFormaPagto.Checked);

                             descricaorelatorio = descricaorelatorio + " Cta Bancaria : " + cboCtaBancaria.SelectedText + " - ";

                         }
                         else if (chkFornecedor.Checked == false && chkTodasContas.Checked == true)
                         {
                             relatorio = oBaixaRN.relatorioBaixas(Convert.ToDateTime(txtDtaInicial.Text),
                                                                            Convert.ToDateTime(txtDtaFinal.Text),
                                                                            empMaster, 
                                                                            EmcResources.cInt(txtIdFornecedor.Text), 
                                                                            chkFornecedor.Checked, 0, chkTodasContas.Checked,
                                                                            idFormaPagto, chkFormaPagto.Checked);

                             descricaorelatorio = descricaorelatorio + " Fornecedor : " + txtFornecedor.Text + " - ";

                         }
                         else if (chkFornecedor.Checked == false && chkTodasContas.Checked == false)
                         {
                             relatorio = oBaixaRN.relatorioBaixas(Convert.ToDateTime(txtDtaInicial.Text),
                                                                            Convert.ToDateTime(txtDtaFinal.Text),
                                                                            empMaster,
                                                                            EmcResources.cInt(txtIdFornecedor.Text),
                                                                            chkFornecedor.Checked,
                                                                            EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString()),
                                                                            chkTodasContas.Checked, idFormaPagto, chkFormaPagto.Checked);

                             descricaorelatorio = descricaorelatorio + " Cta Bancaria : " + cboCtaBancaria.SelectedText + " - " +
                                                                       " Fornecedor : " + txtFornecedor.Text + " - ";

                         }

                         descricaorelatorio = descricaorelatorio + "Período " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString();

                         this.dstPagarBaixa.Tables["baixa"].Clear();
                         this.dstPagarBaixa.Tables["baixa"].Load(relatorio.CreateDataReader());

                         if (Convert.ToInt32(this.dstPagarBaixa.Tables["baixa"].Rows.Count) > 0)
                         {
                             rptBaixas.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                             rptBaixas.SetParameterValue("relatorio", descricaorelatorio);
                             
                             
                             if (chkPDF.Checked)
                             {
                                 rptBaixas.Prepare();
                                 FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                 if (export.ShowDialog())
                                     rptBaixas.Export(export, Application.UserAppDataPath + "\\baixaspagar.pdf");
                             }
                             else
                                 rptBaixas.Show();

                         }
                         else
                             MessageBox.Show("Não foram encontrados lançamentos para a conta no período.");



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
