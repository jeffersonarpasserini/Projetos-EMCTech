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
using EMCCadastro;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCFinanceiro.Pesquisa;

namespace EMCFinanceiro
{
    public partial class frmPagarBaixa : EMCLibrary.EMCForm
    {

        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPagarBaixa";
        private const string nomeAplicativo = "EMCFinanceiro";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        //id utilizado para selecionar o fornecedor que será o nominal do sistema.
        int id_fornecedor = 0;
        Boolean fornecedor_diferente = false;
        string situacaoBaixa = "";
        private int controleCaixa = 0;
        int idMoedaCorrente = 0;
        Boolean utilizaIndexador = false;

        public frmPagarBaixa()
        {
            InitializeComponent();
        }

        public frmPagarBaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        private void frmPagarBaixa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "pagardocumento";


            CancelaOperacao();

            cboPreDatado.Text = "Não";
            cboCheque.Text = "1-Não emite cheque pelo software";

            this.ActiveControl = txtCNPJCPF;


        }
#endregion
        
#region "metodos para tratamento das informacoes"
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }

        private PagarBaixa montaPagarBaixa()
        {
            PagarBaixa oPagarBaixa = new PagarBaixa();
            return oPagarBaixa;
        }

        private void montaTela(PagarBaixa oPagarBaixa)
        {
           
            
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

            /* Identifica o codigo do indexador da moeda corrente no pais */
            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
            idMoedaCorrente = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));

            if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "UTILIZA_INDEXADOR") == "S")
                utilizaIndexador = true;
            else
                utilizaIndexador = false;

            HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);
            Historico oHistorico = new Historico();
            cboHistorico.DataSource = oHistRN.ListaHistorico(oHistorico);
            cboHistorico.ValueMember = "idhistorico";
            cboHistorico.DisplayMember = "descricao";

            cboHistorico.SelectedValue = -1;

            FormaPagamentoRN oCobrRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
            cboIdFormaPagamento.DataSource = oCobrRN.ListaFormaPagamento();
            cboIdFormaPagamento.DisplayMember = "descricao";
            cboIdFormaPagamento.ValueMember = "idformapagamento";
            cboIdFormaPagamento.SelectedValue = 1;

            cboIdFormaPagamento.SelectedValue = -1;

            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            CtaBancaria oCta = new CtaBancaria();
            // TODO: colocar verificacao de parametro para cta bancaria
            oCta.codEmpresa = codempresa;
            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idCtaBancaria";

            cboIdContaBancaria.SelectedValue = -1;

            cboPreDatado.Items.Clear();
            cboPreDatado.Items.Add("Não");
            cboPreDatado.Items.Add("Sim");

            cboCheque.Items.Clear();
            //cboCheque.Items.Add("1-Não emite cheque pelo software");
            cboCheque.Items.Add("1-Emite Cheque Individual para cada pagamento");
            cboCheque.Items.Add("2-Emite Cheque Unico para todos pagamentos");

        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            try
            {
                PagarParcelaRN oPagarBaixaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                List<PagarParcela> lstPagarParcela = new List<PagarParcela>();

                lstPagarParcela = oPagarBaixaRN.listaParcelaBaixa(empMaster,EmcResources.cInt(txtIdFornecedor.Text), EmcResources.cDate(txtDataInicio.Text), EmcResources.cDate(txtDataFinal.Text), chkTodasContas.Checked, EmcResources.cStr(txtNroDocumento.Text));
                
                grdPagarBaixa.Rows.Clear();

                foreach (PagarParcela oPagarBaixa in lstPagarParcela)
                {
                    grdPagarBaixa.Rows.Add(0, oPagarBaixa.dataVencimento.ToString(),oPagarBaixa.pagarDocumento.nroDocumento, oPagarBaixa.nroParcela,EmcResources.cCur(oPagarBaixa.saldoPagar.ToString()), 0, oPagarBaixa.valorCorrecaoMonetaria,
                                           0, 0, 0, oPagarBaixa.pagarDocumento.fornecedor.pessoa.nome, oPagarBaixa.idPagarParcela, oPagarBaixa.pagarDocumento.fornecedor.idPessoa);
                }
                grdPagarBaixa.ScrollBars = ScrollBars.Both;

                if (EmcResources.cCur(txtTotalPagar.Text) > 0)
                {
                    AtivaInsercao();
                }
                else
                {
                    travaBotao("btnSalvar");
                }
            }
            catch (Exception erro)
            {
                 MessageBox.Show("Erro PagarBaixa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            grdPagarBaixa.Rows.Clear();
            txtValorAdiantamento.Text = "0,00";
            txtSdoCompensar.Text = "0,00";
            txtJuros.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtValorDocumento.Text = "0,00";
            txtTotalPagar.Text = "0,00";

            limpaInfoCarteira();
        }

        public override void SalvaObjeto()
        {
            try
            {
                if (cboIdFormaPagamento.SelectedValue.ToString() == "5")
                {
                    if (EmcResources.cInt(txtIdParcelaAmortizar.Text) == 0)
                    {
                        Exception oErro = new Exception("Selecione um documento para compensar o pagamento");
                        throw oErro;
                    }
                    if (EmcResources.cCur(txtSdoCompensar.Text) < EmcResources.cCur(txtValorDocumento.Text))
                    {
                        Exception oErro = new Exception("Valor Pagamento é maior que saldo a compensar");
                        throw oErro;
                    }
                }
                else if (cboCheque.Text == "2-Emite Cheque Unico para todos pagamentos" 
                      && (String.IsNullOrEmpty(txtIdPessoa.Text) || String.IsNullOrEmpty(txtNominal.Text)))
                {
                    txtIdFornecedor.Focus();
                    Exception oErro = new Exception("Preencher o fornecedor e o nominal do cheque para pagamento de fornecedores");
                    throw oErro;
                }
                else
                {
                    CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                    CtaBancaria oConta = new CtaBancaria();
                        
                    oConta.codEmpresa = codempresa;
                    oConta.idCtaBancaria = Convert.ToInt32(cboIdContaBancaria.SelectedValue);
                    oConta.codEmpresa = codempresa;
                    oConta = oContaRN.ObterPor(oConta);
                        
                    // verifica se for conta caixa se ela possui abertura no dia do pagamento
                    ControleCaixaRN oCaixa = new ControleCaixaRN(Conexao,objOcorrencia,codempresa);
                    oCaixa.verificaCaixa(oConta, Convert.ToDateTime(txtDataPagamento.Text), EmcResources.cInt(usuario));

                }
                PagarBaixaRN oPagarBaixaBLL = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();
                String tipoLancamento = "";

                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdPagarBaixa.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];
                    if (ch1.Value == ch1.TrueValue)
                    {
                        PagarBaixa oPagarBaixa = new PagarBaixa();
                        oPagarBaixa.cadastro_datahora = DateTime.Now;
                        oPagarBaixa.cadastro_idusuario = Convert.ToInt32(usuario);
                        oPagarBaixa.codEmpresa = codempresa;
                        oPagarBaixa.dataPagamento = Convert.ToDateTime(txtDataPagamento.Text);
                        oPagarBaixa.situacaoBaixa = situacaoBaixa;

                        PagarParcelaRN oParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                        PagarParcela oParcela = new PagarParcela();
                        oParcela.idPagarParcela = EmcResources.cInt(dataGridViewRow.Cells["idparcela"].Value.ToString());
                        oParcela = oParcelaRN.ObterPor(oParcela);

                        oPagarBaixa.pagarParcela = oParcela;

                        oPagarBaixa.totalDocumento = EmcResources.cCur(txtValorDocumento.Text);
                        oPagarBaixa.totalDesconto = EmcResources.cCur(txtDesconto.Text);
                        oPagarBaixa.totalJuros = EmcResources.cCur(txtJuros.Text);
                        oPagarBaixa.totalPagamento = EmcResources.cCur(txtTotalPagar.Text);
                        oPagarBaixa.totalCorrecao = EmcResources.cCur(txtCorrecaoMonetaria.Text);

                        

                        CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                        CtaBancaria oConta = new CtaBancaria();
                        // TODO: colocar verificação de parametro para cta bancaria
                        if (cboIdFormaPagamento.SelectedValue.ToString() == "5")
                        {
                            oConta.codEmpresa = codempresa;
                            oConta.idCtaBancaria = 0;
                        }
                        else
                        {
                            oConta.codEmpresa = codempresa;
                            oConta.idCtaBancaria = Convert.ToInt32(cboIdContaBancaria.SelectedValue);
                            oConta.codEmpresa = codempresa;
                            oConta = oContaRN.ObterPor(oConta);
                        }
                        oPagarBaixa.contaCorrente = oConta;


                        HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);
                        Historico oHistorico = new Historico();
                        oHistorico.idHistorico = EmcResources.cInt(cboHistorico.SelectedValue.ToString());
                        oHistorico = oHistRN.ObterPor(oHistorico);
                        oPagarBaixa.idHistorico = oHistorico;

                        oPagarBaixa.historico = txtHistorico.Text;

                        FormaPagamentoRN oFormaPagtoRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
                        FormaPagamento oFormaPagto = new FormaPagamento();
                        oFormaPagto.idFormaPagamento = Convert.ToInt32(cboIdFormaPagamento.SelectedValue.ToString());
                        oFormaPagto = oFormaPagtoRN.ObterPor(oFormaPagto);
                        oPagarBaixa.formaPagamento = oFormaPagto;

                        oPagarBaixa.valorBaixa = EmcResources.cCur(dataGridViewRow.Cells["valorpagar"].Value.ToString());
                        oPagarBaixa.valorDesconto = EmcResources.cCur(dataGridViewRow.Cells["desconto"].Value.ToString());
                        oPagarBaixa.valorJuros = EmcResources.cCur(dataGridViewRow.Cells["juros"].Value.ToString());
                        oPagarBaixa.valorTotal = EmcResources.cCur(dataGridViewRow.Cells["valortotal"].Value.ToString());
                        oPagarBaixa.valorCorrecaoMonetaria = EmcResources.cCur(dataGridViewRow.Cells["valorcorrecaomonetaria"].Value.ToString());

                        oPagarBaixa.valorIndiceAjuste = oParcela.valorIndice;

                        if (oParcela.valorParcela.Equals(oPagarBaixa.valorBaixa))
                        {
                            oPagarBaixa.valorBaixaIndexado = oParcela.valorIndexado;
                        }
                        else
                        {
                            oPagarBaixa.valorBaixaIndexado = Math.Round((EmcResources.cDouble(oPagarBaixa.valorBaixa.ToString())/oPagarBaixa.valorIndiceAjuste),4);
                        }
                        

                        if (oPagarBaixa.pagarParcela.pagarDocumento.tipoDocumento.idTipoDocumento == 3)
                        {
                            //Se o tipo de documento pago for do tipo 3-Adiantamento gera um saldo a amortizar futuro
                            oPagarBaixa.sdoAmortizacao = Convert.ToDecimal(dataGridViewRow.Cells["valorpagar"].Value.ToString());
                        }
                        else
                            oPagarBaixa.sdoAmortizacao = 0;

                        PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
                        Pessoa oPessoa = new Pessoa();
                        oPessoa.codEmpresa = empMaster;
                        oPessoa.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                        oPagarBaixa.pessoa = oPessoaRN.ObterPor(oPessoa);
                        oPagarBaixa.nominal = txtNominal.Text;
                        oPagarBaixa.documentoBaixa = txtDocumento.Text;

                        if (txtPreDatado.Enabled)
                            oPagarBaixa.dataPreDatado = Convert.ToDateTime(txtPreDatado.Text);
                        else
                            oPagarBaixa.dataPreDatado = null;

                        tipoLancamento = "0";

                        //se forma de pagamento for igual a 2-Cheque ou 3-Cheque Pre 
                        if (oPagarBaixa.formaPagamento.idFormaPagamento == 2 ||
                            oPagarBaixa.formaPagamento.idFormaPagamento == 3)
                        {
                            
                            if (cboCheque.Text == "1-Emite Cheque Individual para cada pagamento")
                            {
                                oPessoa.idPessoa = Convert.ToInt32(dataGridViewRow.Cells["idfornecedor"].Value.ToString());
                                oPagarBaixa.pessoa = oPessoaRN.ObterPor(oPessoa);
                                oPagarBaixa.nominal = dataGridViewRow.Cells["fornecedor"].Value.ToString();
                                oPagarBaixa.documentoBaixa = dataGridViewRow.Cells["documento"].Value.ToString();
                                tipoLancamento = "1";
                            }
                            else if (cboCheque.Text == "2-Emite Cheque Unico para todos pagamentos")
                            {
                                tipoLancamento = "2";
                            }
                        }
                        else if (oPagarBaixa.formaPagamento.idFormaPagamento == 5)
                        {
                            //Se forma pagamento for igual a Amortização de Adiantamento
                            PagarBaixa oAmortizacao = new PagarBaixa();
                            oAmortizacao.idPagarBaixa = EmcResources.cInt(txtIdParcelaAmortizar.Text);

                            PagarBaixaRN oAmortRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                            oAmortizacao = oAmortRN.ObterPor(oAmortizacao);

                            oPagarBaixa.idAmortizacao = oAmortizacao;

                        }
                        lstPagarBaixa.Add(oPagarBaixa);
                    }
                }

                oPagarBaixaBLL.Salvar(lstPagarBaixa,tipoLancamento);

                LimpaCampos();

                if (EmcResources.cCur(txtTotalPagar.Text) > 0)
                {
                    AtivaInsercao();
                }
                else
                {
                    travaBotao("btnSalvar");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.SalvaObjeto();
        }

  

#endregion

#region "metodos da dbgrid"

        private void verificaNominal()
        {
             int id=0;
             //id_fornecedor = EmcResources.cInt(txtIdPessoa.Text);
             id_fornecedor = 0;
             fornecedor_diferente = false;

             foreach (DataGridViewRow row in grdPagarBaixa.Rows)
             {
                 if (!fornecedor_diferente)
                 {
                     DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                     ch1 = (DataGridViewCheckBoxCell)row.Cells[0];

                     if (ch1.Value == ch1.TrueValue)
                     {
                         id = Convert.ToInt32(EmcResources.cInt(row.Cells["idfornecedor"].Value.ToString()));

                         if (id != id_fornecedor && id_fornecedor > 0)
                         {
                             fornecedor_diferente = true;
                         }
                         else
                             id_fornecedor = id;
                     }
                 }
             }

             if (!fornecedor_diferente)
             {
                 txtIdPessoa.Text = id_fornecedor.ToString();
                 txtIdPessoa_Validating(null, null);
             }
             else
             {

                 Empresa oEmpresa = new Empresa();
                 EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                 oEmpresa.idEmpresa = codempresa;
                 oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                 txtIdPessoa.Text = oEmpresa.pessoa.idPessoa.ToString();
                 txtIdPessoa_Validating(null, null);
                 txtNominal.Text = oEmpresa.pessoa.nome;

                 if (cboIdFormaPagamento.SelectedValue.ToString() == "3")
                     MessageBox.Show("CH Pré Datado para fornecedores diferentes, atenção!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }

        }

        private void grdPagarBaixa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (grdPagarBaixa.Rows.Count > 0)
            {

                if (e.ColumnIndex == grdPagarBaixa.Columns["paga"].Index)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells[0];
                    if (ch1.Value == ch1.TrueValue)
                    {
                        grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value = grdPagarBaixa.Rows[e.RowIndex].Cells["valordocumento"].Value;
                        grdPagarBaixa.Rows[e.RowIndex].Cells["valortotal"].Value = EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()) +
                                                                         EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()) -
                                                                         EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString());

                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) + Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()));
                        txtCorrecaoMonetaria.Text = Convert.ToString(EmcResources.cCur(txtCorrecaoMonetaria.Text) + Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valorcorrecaomonetaria"].Value.ToString()));
                        txtJuros.Text = Convert.ToString(EmcResources.cCur(txtJuros.Text) + Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()));
                        txtDesconto.Text = Convert.ToString(EmcResources.cCur(txtDesconto.Text) + Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString()));
                        txtTotalPagar.Text = Convert.ToString(EmcResources.cCur(txtTotalPagar.Text) + Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valortotal"].Value.ToString()));

                    }
                    else
                    {

                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) - Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()));
                        txtCorrecaoMonetaria.Text = Convert.ToString(EmcResources.cCur(txtCorrecaoMonetaria.Text) - Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valorcorrecaomonetaria"].Value.ToString()));
                        txtJuros.Text = Convert.ToString(EmcResources.cCur(txtJuros.Text) - Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()));
                        txtDesconto.Text = Convert.ToString(EmcResources.cCur(txtDesconto.Text) - Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString()));
                        txtTotalPagar.Text = Convert.ToString(EmcResources.cCur(txtTotalPagar.Text) - Convert.ToDecimal(grdPagarBaixa.Rows[e.RowIndex].Cells["valortotal"].Value.ToString()));

                        grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value = 0;
                        grdPagarBaixa.Rows[e.RowIndex].Cells["desconto"].Value = 0;
                        grdPagarBaixa.Rows[e.RowIndex].Cells["juros"].Value = 0;
                        grdPagarBaixa.Rows[e.RowIndex].Cells["valortotal"].Value = EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()) + 
                                                                         EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["valorcorrecaomonetaria"].Value.ToString()) +
                                                                         EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()) -
                                                                         EmcResources.cCur(grdPagarBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString());
                    }
                }

            }

            if (EmcResources.cCur(txtTotalPagar.Text) > 0)
            {
                AtivaInsercao();
            }
            else
            {
                travaBotao("btnSalvar");
            }
        }

        private void grdPagarBaixa_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdPagarBaixa.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void grdPagarBaixa_DoubleClick(object sender, EventArgs e)
        {
            if (grdPagarBaixa.Rows.Count > 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells[0];
                if (ch1.Value == ch1.TrueValue)
                {
                    montaGlobalParcela();
                    frmEditaParcelasPagar ofrm = new frmEditaParcelasPagar(usuario, login, codempresa.ToString(), empMaster.ToString(),Conexao);
                    ofrm.ShowDialog();
                    gravaAltParcela();
                }
                else
                {
                    MessageBox.Show("Documento não pode ser editado pois não foi marcado para pagamento", "EMCtech", MessageBoxButtons.OK);
                }
            }
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os PagarBaixas cadastrados
            //PagarBaixaRN objPagarBaixa = new PagarBaixaRN();
            //grdPagarBaixa.DataSource = objPagarBaixa.ListaPagarBaixa();
        }

        private void grdPagarBaixa_Click(object sender, EventArgs e)
        {
            if (grdPagarBaixa.Rows.Count > 0)
            {
                int idPessoa =EmcResources.cInt(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["idfornecedor"].Value.ToString());
                exibeInfoCarteira(idPessoa);
            }
        }

        private void limpaInfoCarteira()
        {
            txtClienteSdoDevedor.Text = "0,00";
            txtClienteSdoAtraso.Text = "0,00";
            txtClienteSdo30D.Text = "0,00";
            txtClienteSdoUp30D.Text = "0,00";

            txtFornSdoDevedor.Text = "0,00";
            txtFornSdoAtraso.Text ="0,00";
            txtFornSdo30D.Text = "0,00";
            txtFornSdoUp30D.Text = "0,00";

            txtFornSdoAdto.Text = "0,00";

            txtClienteSdoAdto.Text = "0,00";

        }
        private void exibeInfoCarteira(int idPessoa)
        {
            if (idPessoa>0)
            {

                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = idPessoa;

                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = idPessoa;

                //Receber
                ReceberParcelaRN oRcParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                txtClienteSdoDevedor.Text = oRcParcelaRN.calculaSaldoDevedor(idPessoa).ToString();
                txtClienteSdoAtraso.Text = oRcParcelaRN.calculaSaldoAtraso(idPessoa).ToString();
                txtClienteSdo30D.Text = oRcParcelaRN.calculaVencimento30Dias(idPessoa).ToString();
                txtClienteSdoUp30D.Text = oRcParcelaRN.calculaSdoVencimentoUp30Dias(idPessoa).ToString();

                //Pagar
                PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                txtFornSdoDevedor.Text = oPgParcelaRN.calculaSaldoDevedor(idPessoa).ToString();
                txtFornSdoAtraso.Text = oPgParcelaRN.calculaSaldoAtraso(idPessoa).ToString();
                txtFornSdo30D.Text = oPgParcelaRN.calculaVencimento30Dias(idPessoa).ToString();
                txtFornSdoUp30D.Text = oPgParcelaRN.calculaSdoVencimentoUp30Dias(idPessoa).ToString();

                //dados adiantamentos - Fornecedor
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                txtFornSdoAdto.Text = oPgBaixaRN.calculaSdoAdiantamento(oFornecedor).ToString();

                //dados adiantamentos - Cliente
                ReceberBaixaRN oRcBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                txtClienteSdoAdto.Text = oRcBaixaRN.calculaSdoAdiantamento(oCliente).ToString();
            }
        }

#endregion

#region [Controle de Alteração de Parcelas]

        private void montaGlobalParcela()
        {
            gPagarParcela.nroLinha = grdPagarBaixa.CurrentRow.Index;
            gPagarParcela.idPagarParcela = EmcResources.cInt(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["idparcela"].Value.ToString());
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = EmcResources.cInt(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["nroparcela"].Value.ToString());
            //PagarDocumento oPagardoc = new PagarDocumento();
            //oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);
            //gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = EmcResources.cDate(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["datavencimento"].Value.ToString());
            gPagarParcela.valorParcela = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["valordocumento"].Value.ToString());
            gPagarParcela.valorPagar = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["valordocumento"].Value.ToString());
            gPagarParcela.valorCM = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["valorcorrecaomonetaria"].Value.ToString());
            gPagarParcela.valorDesconto = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["desconto"].Value.ToString());
            gPagarParcela.valorJuros = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["juros"].Value.ToString());
            gPagarParcela.valorTotalPagar = Convert.ToDecimal(grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["valortotal"].Value.ToString());
            gPagarParcela.documento = grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["documento"].Value.ToString();
            gPagarParcela.nominal = grdPagarBaixa.Rows[grdPagarBaixa.CurrentRow.Index].Cells["fornecedor"].Value.ToString();
        }

        private void limpaGlobalParcela()
        {
            gPagarParcela.nroLinha = -1;
            gPagarParcela.idPagarParcela = 0;
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = 0;
            PagarDocumento oPagardoc = new PagarDocumento();
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = DateTime.Now;
            gPagarParcela.valorParcela = 0;
            gPagarParcela.valorDesconto = 0;
            gPagarParcela.valorCM = 0;
            gPagarParcela.valorJuros = 0;
            gPagarParcela.saldoPagar = 0;
            gPagarParcela.saldoPago = 0;
            gPagarParcela.situacao = "A";
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = 1;
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.codigoBarras = "";
            gPagarParcela.nossoNumero = "";
            gPagarParcela.nominal = "";
            gPagarParcela.documento = "";

        }

        public void gravaAltParcela()
        {
            if (gPagarParcela.nroLinha > -1)
            {
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["valorpagar"].Value = gPagarParcela.valorPagar;
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["valorcorrecaomonetaria"].Value = gPagarParcela.valorCM;
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["desconto"].Value = gPagarParcela.valorDesconto;
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["juros"].Value = gPagarParcela.valorJuros;
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["valortotal"].Value = Convert.ToDecimal(gPagarParcela.valorTotalPagar.ToString());
                grdPagarBaixa.Rows[gPagarParcela.nroLinha].Cells["fornecedor"].Value = gPagarParcela.nominal;
            }
            atualizaSomaGrid();
        }

        public void atualizaSomaGrid()
        {
            Decimal somaValorPagar = 0;
            Decimal somaCorrecao = 0;
            Decimal somaDesconto = 0;
            Decimal somaJuros = 0;
            Decimal somaTotal = 0;

            foreach (DataGridViewRow row in grdPagarBaixa.Rows)
            {
                    somaValorPagar = somaValorPagar + Convert.ToDecimal(row.Cells["valorpagar"].Value.ToString());
                    somaCorrecao = somaCorrecao + Convert.ToDecimal(row.Cells["valorcorrecaomonetaria"].Value.ToString());
                    somaDesconto = somaDesconto + Convert.ToDecimal(row.Cells["desconto"].Value.ToString());
                    somaJuros = somaJuros + Convert.ToDecimal(row.Cells["juros"].Value.ToString());
                    somaTotal = somaTotal + Convert.ToDecimal(row.Cells["valortotal"].Value.ToString());

            }
            txtValorDocumento.Text = somaValorPagar.ToString();
            txtCorrecaoMonetaria.Text = somaCorrecao.ToString();
            txtJuros.Text = somaJuros.ToString();
            txtDesconto.Text = somaDesconto.ToString();
            txtTotalPagar.Text = somaTotal.ToString();
        }

#endregion

#region [Texts, combos]

        private void cboIdFormaPagamento_Validating(object sender, CancelEventArgs e)
        {
            //verifica o nominal
            verificaNominal();

            if (cboIdFormaPagamento.SelectedIndex == -1)
            {

            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "1")
            {
                //Pagamento em Dinheiro
                cboIdContaBancaria.Enabled = true;
                cboCheque.Enabled = false;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Não";
                txtPreDatado.Enabled = false;
                situacaoBaixa = "P";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "2")
            {
                //Pagamento em Cheque
                cboIdContaBancaria.Enabled = true;
                cboCheque.Enabled = true;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Não";
                txtPreDatado.Enabled = false;
                situacaoBaixa = "B";

            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "3")
            {
                //Pagamento CH Pre datado
                cboIdContaBancaria.Enabled = true;
                cboCheque.Enabled = true;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Sim";
                txtPreDatado.Enabled = true;
                situacaoBaixa = "B";

            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "4")
            {
                //Pagamento Remessa Eletronica
                cboIdContaBancaria.Enabled = true;
                cboCheque.Enabled = false;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Não";
                txtPreDatado.Enabled = false;
                situacaoBaixa = "R";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "5")
            {
                //Amortização de Adiantamento
                cboIdContaBancaria.Enabled = false;
                cboCheque.Enabled = false;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Não";
                txtPreDatado.Enabled = false;
                situacaoBaixa = "A";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "6")
            {
                //Debito/Credito em conta corrente
                cboIdContaBancaria.Enabled = true;
                cboCheque.Enabled = false;
                cboPreDatado.Enabled = false;
                cboPreDatado.Text = "Não";
                txtPreDatado.Enabled = false;
                situacaoBaixa = "P";
            }

        }

        private void cboHistorico_Validating(object sender, CancelEventArgs e)
        {
            if (cboHistorico.SelectedIndex >= 0)
            {
                Historico oHistorico = new Historico();
                HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);

                oHistorico.idHistorico = EmcResources.cInt(cboHistorico.SelectedValue.ToString());

                oHistorico = oHistRN.ObterPor(oHistorico);

                if (oHistorico.exigecomplemento == "N")
                    txtHistorico.Enabled = false;
                else
                    txtHistorico.Enabled = true;

            }
        }
        
        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCNPJCPF.Text))
                {
                    txtIdFornecedor.ReadOnly = false;
                    txtIdFornecedor.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCNPJCPF.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCNPJCPF.Text.Trim().Length == 11)
                    {
                        txtCNPJCPF.Mask = "000.000.000-00";
                        lblCNPJ.Text = "CPF";
                        txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCNPJCPF.Text.Trim().Length == 14)
                    {
                        txtCNPJCPF.Mask = "00.000.000/0000-00";
                        lblCNPJ.Text = "CNPJ";
                        txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCNPJ.Text = "CNPJ/CPF";
                    }

                    if (txtCNPJCPF.Text.Trim().Length > 0)
                    {
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCNPJCPF.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdFornecedor.ReadOnly = false;
                            txtIdFornecedor.Focus();
                        }
                        else
                        {
                            txtIdFornecedor.Text = oFornecedor.idPessoa.ToString();
                            txtRazaoSocial.Text = oFornecedor.pessoa.nome;
                            txtIdFornecedor.ReadOnly = true;
                            txtNroDocumento.Focus();
                        }


                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message, "Erro", MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            }
        }

        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdFornecedor.Text))
            {
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                Fornecedor oFornecedor = new Fornecedor();

                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtIdFornecedor.Text = oFornecedor.idPessoa.ToString();
                    txtCNPJCPF.Text = oFornecedor.pessoa.cnpjCpf;
                    txtRazaoSocial.Text = oFornecedor.pessoa.nome;

                    if (txtCNPJCPF.Text.Trim().Length == 11)
                    {
                        txtCNPJCPF.Mask = "000.000.000-00";
                        lblCNPJ.Text = "CPF";
                    }
                    else if (txtCNPJCPF.Text.Trim().Length == 14)
                    {
                        txtCNPJCPF.Mask = "00.000.000/0000-00";
                        lblCNPJ.Text = "CNPJ";
                    }
                    txtNroDocumento.Focus();
                }

            }

        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdFornecedor.Text = "";
                else
                    txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdFornecedor_Validating(null, null);

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdPessoa.Text = "";
                else
                    txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdPessoa_Validating(null, null);

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdPessoa.Text))
            {
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                Fornecedor oFornecedor = new Fornecedor();

                oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtNomePessoa.Text = oFornecedor.pessoa.nome;
                    txtNominal.Text = oFornecedor.pessoa.nome;

                }

            }
        }

        private void txtIdPagarBaixa_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            BuscaObjeto();
        }

        private void btnAdiantamento_Click(object sender, EventArgs e)
        {
            psqAdCompensar oPsq = new psqAdCompensar(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);

            oPsq.ShowDialog();

            oPsq.Dispose();

            txtNroDocCompensar.Text = retPesquisa.chavebusca;
            txtIdParcelaAmortizar.Text = retPesquisa.chaveinterna.ToString();

            if (EmcResources.cInt(txtIdParcelaAmortizar.Text) > 0)
            {
                PagarBaixa oBaixa = new PagarBaixa();
                PagarBaixaRN oBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);

                oBaixa.idPagarBaixa = EmcResources.cInt(txtIdParcelaAmortizar.Text);

                oBaixa = oBaixaRN.ObterPor(oBaixa);

                txtNroDocCompensar.Text = oBaixa.pagarParcela.pagarDocumento.nroDocumento;
                txtNroParcela.Text = oBaixa.pagarParcela.nroParcela.ToString();
                txtDataBaixa.Text = oBaixa.dataPagamento.ToString();
                txtFornecedor.Text = oBaixa.pagarParcela.pagarDocumento.fornecedor.pessoa.nome;
                txtValorAdiantamento.Text = oBaixa.valorBaixa.ToString();
                txtSdoCompensar.Text = oBaixa.sdoAmortizacao.ToString();
            }
        }

        private void cboCheque_SelectedValueChanged(object sender, EventArgs e)
        {
            
            if (cboCheque.Text == "1-Emite Cheque Individual para cada pagamento")
            {
                txtDocumento.Text = "";
                txtDocumento.Enabled = false;
                txtNominal.Enabled = false;
                //verifica o nominal
                verificaNominal();
            }
            else if (cboCheque.Text == "2-Emite Cheque Unico para todos pagamentos")
            {
                txtDocumento.Enabled = true;
                txtNominal.Enabled = true;
                //verifica o nominal
                verificaNominal();
            }
        }

        private void cboPreDatado_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboPreDatado.Text == "Não")
            {
                txtPreDatado.Enabled = false;
            }
            else if (cboPreDatado.Text == "Sim")
            {
                txtPreDatado.Enabled = true;
            }
            else
            {
                txtPreDatado.Enabled = false;
            }
        }

#endregion 

        

       

       

       



      


    }
}
