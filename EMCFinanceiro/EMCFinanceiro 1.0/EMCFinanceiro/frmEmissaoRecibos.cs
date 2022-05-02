using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCFinanceiroModel;
using EMCFinanceiroRN;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;
using System.Collections;
using FastReport;

namespace EMCFinanceiro
{
    public partial class frmEmissaoRecibos : EMCLibrary.EMCForm
    {
        private const string descricao = "frmEmissaoRecibos";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEmissaoRecibos()
        {
            InitializeComponent();
        }

         public frmEmissaoRecibos(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = EmcResources.cInt(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

         private void frmEmissaoRecibos_Load(object sender, EventArgs e)
         {
             objOcorrencia = new Ocorrencia();
             Aplicativo oAplicativo = new Aplicativo();
             oAplicativo.nome = nomeAplicativo;
             objOcorrencia.aplicativo = oAplicativo;
             objOcorrencia.formulario = descricao;
             objOcorrencia.seqLogin = EmcResources.cInt(login);
             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario = EmcResources.cInt(usuario);
             objOcorrencia.usuario = oUsuario;
             objOcorrencia.tabela = "caixacontrole";

             this.ActiveControl = cboContaBancaria;
             CancelaOperacao();

         }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaRecibos(Recibo oRecibo)
        {
            /*
            ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oControleCaixaRN.VerificaDados(oCaixa);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Caixa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
             */
            return true;
        }

        private  Recibo montaRecibos()
        {
            Recibo oRecibo = new Recibo();
            /*
            CtaBancaria oConta = new CtaBancaria();
            oConta.codEmpresa = codempresa;
            oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
            CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oConta = oContaRN.ObterPor(oConta);

            oControleCaixa.contaBancaria = oConta;
            oControleCaixa.conferido = "N";
            oControleCaixa.dtHoraAbertura = Convert.ToDateTime(txtDtHoraAbertura.Text);
            oControleCaixa.saldoAbertura = EmcResources.cCur(txtSdoAbertura.Value.ToString());
            oControleCaixa.usuarioResponsavel = objOcorrencia.usuario.idUsuario;
            oControleCaixa.fechado = "N";
            */
            return oRecibo;
        }

        private void montaTela(ControleCaixa oControleCaixa)
        {

            

        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, descricao, btnFlag))
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
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();

            CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            CtaBancaria oConta = new CtaBancaria();
            oConta.codEmpresa = codempresa;
            cboContaBancaria.DataSource = oCtaBancariaRN.ListaCtaCaixa(oConta);
            cboContaBancaria.DisplayMember = "descricao";
            cboContaBancaria.ValueMember = "idctabancaria";


            //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), "EMCFinanceiro", "frmPagarBaixa", EmcResources.operacaoSeguranca.execucao))
                arr.Add(new popCombo("Pagamentos", "D"));
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), "EMCFinanceiro", "frmReceberBaixa", EmcResources.operacaoSeguranca.execucao))
                arr.Add(new popCombo("Recebimentos", "C"));
            cboTipoRecibo.DataSource = arr;
            cboTipoRecibo.DisplayMember = "nome";
            cboTipoRecibo.ValueMember = "valor";
            


            //inicializa combo de ordenação
            ArrayList arr2 = new ArrayList();
            arr2.Add(new popCombo("Recibo c/Rel.Pagamentos", "P"));
            arr2.Add(new popCombo("Recibo Simples", "S"));
            cboModeloRecibo.DataSource = arr2;
            cboModeloRecibo.DisplayMember = "nome";
            cboModeloRecibo.ValueMember = "valor";
            
            objOcorrencia.chaveidentificacao = "";
            AtivaEdicao();
            travaBotao("btnExcluir");
            travaBotao("btnAtualizar");

        }

        public override void BuscaObjeto()
        {
            try
            {
                grdRecibo.Rows.Clear();

                MovimentoBancarioRN oMovBancoRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                List<MovimentoBancario> lstMovBanco = new List<MovimentoBancario>();
                lstMovBanco = oMovBancoRN.lstEmissaoRecibo(cboTipoRecibo.SelectedValue.ToString(),Convert.ToDateTime(txtInicioPeriodo.Text), Convert.ToDateTime(txtFinalPeriodo.Text) );

                foreach (MovimentoBancario oMov in lstMovBanco)
                {
                    grdRecibo.Rows.Add(false, oMov.idRecibo, oMov.dataMovimento, oMov.valorMovimento, oMov.contaBancaria.descricao, oMov.nroCheque, oMov.pessoa.nome, oMov.idMovimentoBancario, oMov.pessoa.idPessoa);
                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Histórico: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public void BuscaControleCaixa()
        {
            /*
            if (!String.IsNullOrEmpty(txtIdControleCaixa.Text))
            {

                ControleCaixa oControleCaixa = new ControleCaixa();
                oControleCaixa.idControleCaixa = EmcResources.cInt(txtIdControleCaixa.Text);
                try
                {
                    ControleCaixaRN ControleCaixaBLL = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                    oControleCaixa = ControleCaixaBLL.ObterPor(oControleCaixa);

                    if (oControleCaixa.idControleCaixa == 0)
                    {
                        DialogResult result = MessageBox.Show("Controle Caixa não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                    }
                    else
                    {
                        montaTela(oControleCaixa);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
             */ 
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            grdRecibo.Rows.Clear();
            objOcorrencia.chaveidentificacao = "";

        }

        public override void SalvaObjeto()
        {
            try
            {
                Recibo oRecibo = new Recibo();
                //ControleCaixaRN oControleCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                

                oRecibo = montaRecibos();

                if (verificaRecibos(oRecibo))
                {
                    //oControleCaixaRN.Salvar(oRecibo);

                    LimpaCampos();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void AtualizaObjeto(){}

        public override void ExcluiObjeto(){}

        public override void ImprimeObjeto()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                MovimentoBancarioRN oMovRN = new MovimentoBancarioRN(Conexao, objOcorrencia, codempresa);
                PagarBaixaRN oPgRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                ReceberBaixaRN oRcRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                ReciboRN oReciboRN = new ReciboRN(Conexao, objOcorrencia, codempresa);

                int idRecibo = 0;

                //Verifica a necessidade de gravação de recibos
                foreach (DataGridViewRow oRow in grdRecibo.Rows)
                {
                    DataGridViewCheckBoxCell ch = new DataGridViewCheckBoxCell();
                    ch = (DataGridViewCheckBoxCell)oRow.Cells[0];

                    if (ch.Value.ToString() == "True")
                    {
                        //Busca o Movimento Bancario
                        MovimentoBancario oMov = new MovimentoBancario();
                        oMov.idMovimentoBancario = EmcResources.cInt(oRow.Cells["idmovimentobancario"].Value.ToString());

                        oMov = oMovRN.ObterPor(oMov);


                        //Grava os recibos dos movimentos ainda não gerados
                        if (EmcResources.cInt(oRow.Cells["idrecibo"].Value.ToString()) == 0)
                        {
                            Recibo oRecibo = new Recibo();
                            oRecibo.idMovimentoBancario = oMov.idMovimentoBancario;
                            oRecibo.dataEmissao = DateTime.Now;
                            oRecibo.dataRecibo = oMov.dataMovimento;
                            
                            Empresa oEmp = new Empresa();
                            oEmp.idEmpresa = codempresa;
                            oRecibo.empresa = oEmp;

                            oRecibo.idUsuario = EmcResources.cInt(usuario);
                            oRecibo.valorRecibo = oMov.valorMovimento;

                            oRecibo.descricao = oMov.idHistorico.descricao + " - " + oMov.historico;

                            idRecibo = oReciboRN.Salvar(oRecibo);

                            oRow.Cells["idrecibo"].Value = idRecibo;

                        }
                    }

                }

                String listMovBancario = "";
                String listRecibo = "";
                int entrou = 0;

                /* Prepara a Impressão do Recibo 
                 
                    - Gera o filtro para idrecibo
                    - Gera o filtro para idmovimentobancario
                 */

                foreach (DataGridViewRow oRow2 in grdRecibo.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)oRow2.Cells[0];

                    if (ch1.Value.ToString() == "True")
                    {
                        if (entrou>0)
                        {
                            listMovBancario=listMovBancario+", ";
                            listRecibo = listRecibo + ", ";
                        }
                        listMovBancario =listMovBancario+oRow2.Cells["idmovimentobancario"].Value.ToString();
                        listRecibo = listRecibo + oRow2.Cells["idrecibo"].Value.ToString();
                        entrou++;
                    }
                }

                /* Monta DATATABLE´s com os dados do relatorio */
                DataTable dtRecibo = new DataTable();
                dtRecibo = oReciboRN.dstReciboSimples(listRecibo);

                /* Monta os DATASET´s */
                this.dstRecibo.Tables["movimento"].Clear();
                this.dstRecibo.Tables["recibo"].Clear();

                this.dstRecibo.Tables["recibo"].Load(dtRecibo.CreateDataReader());

                DataTable dtMovimento = new DataTable();
                if (cboTipoRecibo.SelectedValue.ToString() == "D")
                {
                    dtMovimento = oPgRN.listaBaixaRecibo(listMovBancario);   
                    this.dstRecibo.Tables["movimento"].Load(dtMovimento.CreateDataReader());
                }
                else
                {
                    dtMovimento = oRcRN.listaBaixaRecibo(listMovBancario);
                    this.dstRecibo.Tables["movimento"].Load(dtMovimento.CreateDataReader());
                }

                /* verifica o tipo de recibo a ser impresso 
                 * Monta o recibo de acordo com o modelo escolhido pelo usuario
                 */

                if (Convert.ToInt32(this.dstRecibo.Tables["recibo"].Rows.Count) > 0)
                {
                    if (cboModeloRecibo.SelectedValue.ToString() == "S")
                    {
                        if (cboTipoRecibo.SelectedValue.ToString() == "D")
                        {
                            reciboPGSimples.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                            if (chkPDF.Checked)
                            {
                                reciboPGSimples.Prepare();
                                FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                if (export.ShowDialog())
                                    reciboPGSimples.Export(export, Application.UserAppDataPath+"\\recibo.pdf");
                            }
                            else
                                reciboPGSimples.Show();
                        }
                        else
                        {
                            reciboRCSimples.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                            if (chkPDF.Checked)
                            {
                                reciboRCSimples.Prepare();
                                FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                if (export.ShowDialog())
                                    reciboRCSimples.Export(export, Application.UserAppDataPath+"\\recibo.pdf");
                            }
                            else
                                reciboRCSimples.Show();
                        }
                    }
                    else if (cboModeloRecibo.SelectedValue.ToString() == "P")
                    {
                        if (cboTipoRecibo.SelectedValue.ToString() == "D")
                        {
                            reciboPGCompleto.SetParameterValue("Empresa", oEmpresa.razaoSocial);
                            reciboPGCompleto.SetParameterValue("RG", oEmpresa.inscrEstadual);
                            reciboPGCompleto.SetParameterValue("Cnpj", oEmpresa.cnpjcpf);
                            reciboPGCompleto.SetParameterValue("Endereco", oEmpresa.endereco.Trim() + "," + oEmpresa.numero.Trim() + "-" + oEmpresa.cidade.Trim() + "-" + oEmpresa.estado.Trim());

                            if (chkPDF.Checked)
                            {
                                reciboPGCompleto.Prepare();
                                FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                if (export.ShowDialog())
                                    reciboPGCompleto.Export(export, Application.UserAppDataPath+"\\recibo.pdf");
                            }
                            else
                                reciboPGCompleto.Show();
                        }
                        else
                        {
                            reciboRCCompleto.SetParameterValue("Empresa", oEmpresa.razaoSocial);

                            if (chkPDF.Checked)
                            {
                                reciboRCCompleto.Prepare();
                                FastReport.Export.Pdf.PDFExport export = new FastReport.Export.Pdf.PDFExport();
                                if (export.ShowDialog())
                                    reciboRCCompleto.Export(export, Application.UserAppDataPath + "\\recibo.pdf");
                            }
                            else
                                reciboRCCompleto.Show();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Não foram encontrados lançamentos para emissão de recibo.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Recibos : "+ e.Message + " - " +  e.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        #region "Tratamentos para buttons e texts**************************************************************************************"

       

        #endregion

        #region "metodos da dbgrid*******************************************************************************************"
        private void grdRecibo_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdRecibo.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void grdCaixa_DoubleClick(object sender, EventArgs e)
        {
            /*
            txtIdControleCaixa.Enabled = true;
            txtIdControleCaixa.Text = grdCaixa.Rows[grdCaixa.CurrentRow.Index].Cells["idCaixacontrole"].Value.ToString();
            txtIdControleCaixa.Focus();
            SendKeys.Send("{TAB}");
             */ 
        }
        private void AtualizaGrid()
        {
            /*
            CtaBancaria oConta = new CtaBancaria();
            CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oConta.codEmpresa = codempresa;
            oConta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
            oConta = oContaRN.ObterPor(oConta);

            ControleCaixaRN oCtrCaixaRN = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);

            grdCaixa.DataSource = oCtrCaixaRN.ListaControleCaixa(oConta);
             */ 

        }


        #endregion

        private void cboContaBancaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboContaBancaria.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    //buscar saldo na conta bancaria
                    CtaBancariaRN oCtaBancariaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                    CtaBancaria oConta = new CtaBancaria();
                    oConta.codEmpresa = codempresa;
                    oConta.idCtaBancaria = EmcResources.cInt(cboContaBancaria.SelectedValue.ToString());
                    oConta = oCtaBancariaRN.ObterPor(oConta);
                    AtualizaGrid();
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Abertura Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMarcarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdRecibo.Rows)
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
                foreach (DataGridViewRow row in grdRecibo.Rows)
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
