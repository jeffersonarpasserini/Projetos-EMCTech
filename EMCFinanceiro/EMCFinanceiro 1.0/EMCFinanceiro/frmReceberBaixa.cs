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
    public partial class frmReceberBaixa : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmReceberBaixa";
        private const string nomeAplicativo = "EMCFinanceiro";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        //id utilizado para selecionar o cliente que será o nominal do sistema.
        int id_cliente = 0;
        Boolean cliente_diferente = false;
        //flag de situação da baixa
        string situacaoBaixa = "";
        //Lista de Cheques
        List<ChequeRecebido> lstChequeRecebido = new List<ChequeRecebido>();

        private string tipoJuros = "S";

        public frmReceberBaixa()
        {
            InitializeComponent();
        }

          
        public frmReceberBaixa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        private void frmReceberBaixa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "receberdocumento";

            HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);
            Historico oHistorico = new Historico();
            cboHistorico.DataSource = oHistRN.ListaHistorico(oHistorico);
            cboHistorico.ValueMember = "idhistorico";
            cboHistorico.DisplayMember = "descricao";

            FormaPagamentoRN oCobrRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
            cboIdFormaPagamento.DataSource = oCobrRN.ListaFormaPagamento();
            cboIdFormaPagamento.DisplayMember = "descricao";
            cboIdFormaPagamento.ValueMember = "idformapagamento";
            cboIdFormaPagamento.SelectedValue = 1;


            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            CtaBancaria oCta = new CtaBancaria();
            // TODO: colocar verificacao de parametro para cta bancaria
            oCta.codEmpresa = codempresa;
            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idCtaBancaria";

    
            //cboCheque.Items.Add("1-Não emite cheque pelo software");
            //cboCheque.Items.Add("1-Emite Cheque Individual para cada pagamento");
            //cboCheque.Items.Add("2-Emite Cheque Unico para todos pagamentos");

            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
            tipoJuros = oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "TIPO_JUROS");

            CancelaOperacao();

            this.ActiveControl = txtIdCliente;

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

        private ReceberBaixa montaReceberBaixa()
        {
            ReceberBaixa oReceberBaixa = new ReceberBaixa();
            return oReceberBaixa;
        }

        private void montaTela(ReceberBaixa oReceberBaixa)
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
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            try
            {
                ReceberParcelaRN oReceberBaixaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                List<ReceberParcela> lstReceberParcela = new List<ReceberParcela>();

                lstReceberParcela = oReceberBaixaRN.listaParcelaBaixa(codempresa, empMaster,EmcResources.cInt(txtIdCliente.Text), EmcResources.cDate(txtDataInicio.Text), EmcResources.cDate(txtDataFinal.Text), chkTodasContas.Checked, EmcResources.cStr(txtNroDocumento.Text),EmcResources.cInt(txtIdAcordo.Text));

                LimpaCampos();
                grdReceberBaixa.Rows.Clear();

                Decimal totalParcela = 0;

                foreach (ReceberParcela oReceberBaixa in lstReceberParcela)
                {
                    totalParcela = 0;

                    if (oReceberBaixa.idAcordo > 0)
                    {
                        if (oReceberBaixa.situacaoAcordo == "A" && oReceberBaixa.dataLimiteAcordo >= DateTime.Now.Date)
                        {
                            oReceberBaixa.valorJuros = oReceberBaixa.jurosAcordo + oReceberBaixa.multaAcordo;
                            oReceberBaixa.valorDesconto = oReceberBaixa.descontoAcordo;
                        }
                        else
                        {
                            oReceberBaixa.valorJuros = oReceberBaixa.jurosPrevisto + oReceberBaixa.multaPrevisto;
                            oReceberBaixa.valorDesconto = 0;
                        }
                    }
                    else
                    {
                        oReceberBaixa.valorJuros = oReceberBaixa.jurosPrevisto + oReceberBaixa.multaPrevisto;
                        oReceberBaixa.valorDesconto = 0;
                    }

                    totalParcela = (oReceberBaixa.saldoPagar + oReceberBaixa.valorJuros) - oReceberBaixa.valorDesconto;

                    grdReceberBaixa.Rows.Add(0, oReceberBaixa.dataVencimento.ToString(),oReceberBaixa.receberDocumento.nroDocumento, oReceberBaixa.nroParcela,EmcResources.cCur(oReceberBaixa.saldoPagar.ToString()), 0,
                                           oReceberBaixa.valorDesconto, oReceberBaixa.valorJuros, totalParcela, oReceberBaixa.receberDocumento.cliente.pessoa.nome, oReceberBaixa.idReceberParcela, oReceberBaixa.receberDocumento.cliente.idPessoa);
                }
                grdReceberBaixa.ScrollBars = ScrollBars.Both;

                if (EmcResources.cCur(txtTotalPagar.Text) > 0)
                {
                    AtivaInsercao();
                }
                else CancelaOperacao();
            }
            catch (Exception erro)
            {
                 MessageBox.Show("Erro ReceberBaixa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtValorDocumento.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtJuros.Text = "0,00";
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
                else
                {
                    CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                    CtaBancaria oConta = new CtaBancaria();

                    oConta.codEmpresa = codempresa;
                    oConta.idCtaBancaria = Convert.ToInt32(cboIdContaBancaria.SelectedValue);
                    oConta.codEmpresa = codempresa;
                    oConta = oContaRN.ObterPor(oConta);

                    // verifica se for conta caixa se ela possui abertura no dia do pagamento
                    ControleCaixaRN oCaixa = new ControleCaixaRN(Conexao, objOcorrencia, codempresa);
                    oCaixa.verificaCaixa(oConta, Convert.ToDateTime(txtDataPagamento.Text), EmcResources.cInt(usuario));

                }



                ReceberBaixaRN oReceberBaixaBLL = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                List<ReceberBaixa> lstReceberBaixa = new List<ReceberBaixa>();
                String tipoLancamento = "";

                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdReceberBaixa.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];
                    if (ch1.Value == ch1.TrueValue)
                    {
                        ReceberBaixa oReceberBaixa = new ReceberBaixa();
                        oReceberBaixa.cadastro_datahora = DateTime.Now;
                        oReceberBaixa.cadastro_idusuario = Convert.ToInt32(usuario);
                        oReceberBaixa.codEmpresa = codempresa;
                        oReceberBaixa.dataPagamento = Convert.ToDateTime(txtDataPagamento.Text);
                        oReceberBaixa.situacaoBaixa = situacaoBaixa;

                        ReceberParcelaRN oParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                        ReceberParcela oParcela = new ReceberParcela();
                        oParcela.idReceberParcela = EmcResources.cInt(dataGridViewRow.Cells["idparcela"].Value.ToString());
                        oParcela = oParcelaRN.ObterPor(oParcela);

                        oReceberBaixa.receberParcela = oParcela;

                        oReceberBaixa.totalDocumento = Convert.ToDecimal(txtValorDocumento.Text);
                        oReceberBaixa.totalDesconto = Convert.ToDecimal(txtDesconto.Text);
                        oReceberBaixa.totalJuros = Convert.ToDecimal(txtJuros.Text);
                        oReceberBaixa.totalPagamento = Convert.ToDecimal(txtTotalPagar.Text);

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
                        oReceberBaixa.contaCorrente = oConta;


                        HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);
                        Historico oHistorico = new Historico();
                        oHistorico.idHistorico = EmcResources.cInt(cboHistorico.SelectedValue.ToString());
                        oHistorico = oHistRN.ObterPor(oHistorico);
                        oReceberBaixa.idHistorico = oHistorico;

                        oReceberBaixa.historico = txtHistorico.Text;

                        FormaPagamentoRN oFormaPagtoRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
                        FormaPagamento oFormaPagto = new FormaPagamento();
                        oFormaPagto.idFormaPagamento = Convert.ToInt32(cboIdFormaPagamento.SelectedValue.ToString());
                        oFormaPagto = oFormaPagtoRN.ObterPor(oFormaPagto);
                        oReceberBaixa.formaPagamento = oFormaPagto;

                        oReceberBaixa.valorBaixa = Convert.ToDecimal(dataGridViewRow.Cells["valorpagar"].Value.ToString());
                        oReceberBaixa.valorDesconto = Convert.ToDecimal(dataGridViewRow.Cells["desconto"].Value.ToString());
                        oReceberBaixa.valorJuros = Convert.ToDecimal(dataGridViewRow.Cells["juros"].Value.ToString());
                        oReceberBaixa.valorTotal = Convert.ToDecimal(dataGridViewRow.Cells["valortotal"].Value.ToString());

                        if (oReceberBaixa.receberParcela.receberDocumento.tipoDocumento.idTipoDocumento == 3)
                        {
                            //Se o tipo de documento pago for do tipo 3-Adiantamento gera um saldo a amortizar futuro
                            oReceberBaixa.sdoAmortizacao = Convert.ToDecimal(dataGridViewRow.Cells["valorpagar"].Value.ToString());
                        }
                        else
                            oReceberBaixa.sdoAmortizacao = 0;

                        PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
                        Pessoa oPessoa = new Pessoa();
                        oPessoa.codEmpresa = empMaster;
                        oPessoa.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                        oReceberBaixa.pessoa = oPessoaRN.ObterPor(oPessoa);
                        oReceberBaixa.nominal = txtNominal.Text;
                        oReceberBaixa.documentoBaixa = txtDocumento.Text;

                        oReceberBaixa.dataPreDatado = null;

                        tipoLancamento = "0";

                        //se forma de pagamento for igual a 2-Cheque ou 3-Cheque Pre 
                        if (oReceberBaixa.formaPagamento.idFormaPagamento == 2 ||
                            oReceberBaixa.formaPagamento.idFormaPagamento == 3)
                        {
                            
                            //Pegar uma list de cheques para gravar na tabela de Cheques Recebidos
                            oReceberBaixa.lstCheque = lstChequeRecebido;       
                   

                            //oPessoa.idPessoa = Convert.ToInt32(dataGridViewRow.Cells["idcliente"].Value.ToString());
                            //oReceberBaixa.pessoa = oPessoaRN.ObterPor(oPessoa);
                            //oReceberBaixa.nominal = dataGridViewRow.Cells["cliente"].Value.ToString();
                            //oReceberBaixa.documentoBaixa = dataGridViewRow.Cells["documento"].Value.ToString();
                            //tipoLancamento = "1";
                            
                        }
                        else if (oReceberBaixa.formaPagamento.idFormaPagamento == 5)
                        {
                            //Se forma pagamento for igual a Amortização de Adiantamento
                            ReceberBaixa oAmortizacao = new ReceberBaixa();
                            oAmortizacao.idReceberBaixa = EmcResources.cInt(txtIdParcelaAmortizar.Text);

                            ReceberBaixaRN oAmortRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                            oAmortizacao = oAmortRN.ObterPor(oAmortizacao);

                            oReceberBaixa.idAmortizacao = oAmortizacao;

                        }
                        lstReceberBaixa.Add(oReceberBaixa);
                    }
                }

                oReceberBaixaBLL.Salvar(lstReceberBaixa,tipoLancamento);

                LimpaCampos();
                txtValorAdiantamento.Text = "";
                txtSdoCompensar.Text = "";
                grdReceberBaixa.Rows.Clear();

                if (EmcResources.cCur(txtTotalPagar.Text) > 0)
                {
                    AtivaInsercao();
                }
                else CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.SalvaObjeto();
        }

#endregion

#region "metodos da dbgrid"

        private void verificaNominal()
        {
             int id=0;
             //id_cliente = EmcResources.cInt(txtIdPessoa.Text);
             id_cliente = 0;
             cliente_diferente = false;

             foreach (DataGridViewRow row in grdReceberBaixa.Rows)
             {
                 if (!cliente_diferente)
                 {
                     DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                     ch1 = (DataGridViewCheckBoxCell)row.Cells[0];

                     if (ch1.Value == ch1.TrueValue)
                     {
                         id = Convert.ToInt32(EmcResources.cInt(row.Cells["idcliente"].Value.ToString()));

                         if (id != id_cliente && id_cliente > 0)
                         {
                             cliente_diferente = true;
                         }
                         else
                             id_cliente = id;
                     }
                 }
             }

             if (!cliente_diferente)
             {
                 txtIdPessoa.Text = id_cliente.ToString();
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

                // if (cboIdFormaPagamento.SelectedValue.ToString() == "3")
                  //   MessageBox.Show("CH Pré Datado para fornecedores diferentes, atenção!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             }

        }

        private void grdReceberBaixa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            ReceberParcelaRN oRecParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
            Decimal totalParcela =0;

            if (grdReceberBaixa.Rows.Count > 0)
            {

                if (e.ColumnIndex == grdReceberBaixa.Columns["paga"].Index)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells[0];
                    if (ch1.Value == ch1.TrueValue)
                    {
                        grdReceberBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value = grdReceberBaixa.Rows[e.RowIndex].Cells["valordocumento"].Value;
                        grdReceberBaixa.Rows[e.RowIndex].Cells["valortotal"].Value = EmcResources.cCur(grdReceberBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()) +
                                                                         EmcResources.cCur(grdReceberBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()) -
                                                                         EmcResources.cCur(grdReceberBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString());

                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) + Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()));
                        txtJuros.Text = Convert.ToString(EmcResources.cCur(txtJuros.Text) + Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()));
                        txtDesconto.Text = Convert.ToString(EmcResources.cCur(txtDesconto.Text) + Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString()));
                        txtTotalPagar.Text = Convert.ToString(EmcResources.cCur(txtTotalPagar.Text) + Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["valortotal"].Value.ToString()));

                    }
                    else
                    {
                        /* busca dados originais da parcela */
                        ReceberParcela oParcela = new ReceberParcela();
                        oParcela.idReceberParcela = EmcResources.cInt(grdReceberBaixa.Rows[e.RowIndex].Cells["idparcela"].Value.ToString());

                        oParcela = oRecParcelaRN.ObterPor(oParcela);

                        totalParcela = 0;
                       

                        if (oParcela.idAcordo > 0)
                        {
                            if (oParcela.situacaoAcordo == "A" && oParcela.dataLimiteAcordo >= DateTime.Now.Date)
                            {
                                oParcela.valorJuros = oParcela.jurosAcordo + oParcela.multaAcordo;
                                oParcela.valorDesconto = oParcela.descontoAcordo;
                            }
                            else
                            {
                                oParcela.valorJuros = oParcela.jurosPrevisto + oParcela.multaPrevisto;
                                oParcela.valorDesconto = 0;
                            }
                        }
                        else
                        {
                            oParcela.valorJuros = oParcela.jurosPrevisto + oParcela.multaPrevisto;
                            oParcela.valorDesconto = 0;
                        }

                        totalParcela = (oParcela.saldoPagar + oParcela.valorJuros) - oParcela.valorDesconto;
                        
                        /* retira valores dos totais do recebimento */
                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) - Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value.ToString()));
                        txtJuros.Text = Convert.ToString(EmcResources.cCur(txtJuros.Text) - Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["juros"].Value.ToString()));
                        txtDesconto.Text = Convert.ToString(EmcResources.cCur(txtDesconto.Text) - Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["desconto"].Value.ToString()));
                        txtTotalPagar.Text = Convert.ToString(EmcResources.cCur(txtTotalPagar.Text) - Convert.ToDecimal(grdReceberBaixa.Rows[e.RowIndex].Cells["valortotal"].Value.ToString()));

                        /* retorna valores originais para a grid */
                        grdReceberBaixa.Rows[e.RowIndex].Cells["valorpagar"].Value = 0;
                        grdReceberBaixa.Rows[e.RowIndex].Cells["desconto"].Value = oParcela.valorDesconto;
                        grdReceberBaixa.Rows[e.RowIndex].Cells["juros"].Value = oParcela.valorJuros;
                        grdReceberBaixa.Rows[e.RowIndex].Cells["valortotal"].Value = totalParcela;
                    }
                }

            }

            if (EmcResources.cCur(txtTotalPagar.Text) > 0)
            {
                AtivaInsercao();
            }
            else CancelaOperacao();
        }

        private void grdReceberBaixa_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdReceberBaixa.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void grdReceberBaixa_DoubleClick(object sender, EventArgs e)
        {
            if (grdReceberBaixa.Rows.Count > 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells[0];
                if (ch1.Value == ch1.TrueValue)
                {
                    montaGlobalParcela();
                    frmReceberEditaParcelaBaixa ofrm = new frmReceberEditaParcelaBaixa(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao);
                    ofrm.ShowDialog();
                    gravaAltParcela();
                }
                else
                {
                    MessageBox.Show("Documento não pode ser editado pois não foi marcado para pagamento", "EMCtech", MessageBoxButtons.OK);
                }
            }
        }

        private void grdReceberBaixa_Click(object sender, EventArgs e)
        {
            if (grdReceberBaixa.Rows.Count > 0)
            {
                int idPessoa = EmcResources.cInt(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["idcliente"].Value.ToString());
                exibeInfoCarteira(idPessoa);
            }
        }

        private void limpaInfoCarteira()
        {
            txtClienteSdoDevedor.Text = "";
            txtClienteSdoAtraso.Text = "";
            txtClienteSdo30D.Text = "";
            txtClienteSdoUp30D.Text = "";

            txtFornSdoDevedor.Text = "";
            txtFornSdoAtraso.Text = "";
            txtFornSdo30D.Text = "";
            txtFornSdoUp30D.Text = "";

            txtFornSdoAdto.Text = "";

            txtClienteSdoAdto.Text = "";

        }

        private void exibeInfoCarteira(int idPessoa)
        {
            if (idPessoa > 0)
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

        private void AtualizaGrid()
        {
            //carrega a grid com os ReceberBaixas cadastrados
            //ReceberBaixaRN objReceberBaixa = new ReceberBaixaRN();
            //grdReceberBaixa.DataSource = objReceberBaixa.ListaReceberBaixa();
        }


#endregion

#region [Controle de Alteração de Parcelas]

        private void montaGlobalParcela()
        {
            ReceberParcelaRN oRecParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
            ReceberParcela oRecParcela = new ReceberParcela();
            oRecParcela.idReceberParcela = EmcResources.cInt(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["idparcela"].Value.ToString());

            oRecParcela = oRecParcelaRN.ObterPor(oRecParcela);

            gReceberParcela.nroLinha = grdReceberBaixa.CurrentRow.Index;
            gReceberParcela.idReceberParcela = EmcResources.cInt(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["idparcela"].Value.ToString());
            gReceberParcela.codEmpresa = codempresa;
            gReceberParcela.nroParcela = EmcResources.cInt(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["nroparcela"].Value.ToString());
            gReceberParcela.dataVencimento = EmcResources.cDate(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["datavencimento"].Value.ToString());
            gReceberParcela.valorParcela = Convert.ToDecimal(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["valordocumento"].Value.ToString());
            gReceberParcela.valorPagar = Convert.ToDecimal(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["valorpagar"].Value.ToString());
            gReceberParcela.valorDesconto = Convert.ToDecimal(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["desconto"].Value.ToString());
            gReceberParcela.valorJuros = Convert.ToDecimal(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["juros"].Value.ToString());
            gReceberParcela.valorTotalPagar = Convert.ToDecimal(grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["valortotal"].Value.ToString());
            gReceberParcela.documento = grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["documento"].Value.ToString();
            gReceberParcela.nominal = grdReceberBaixa.Rows[grdReceberBaixa.CurrentRow.Index].Cells["cliente"].Value.ToString();
            gReceberParcela.txajuros = oRecParcela.receberDocumento.taxaJuros;
            gReceberParcela.txamulta = oRecParcela.receberDocumento.taxaMulta;
            gReceberParcela.tipoJuros = tipoJuros;

        }

        private void limpaGlobalParcela()
        {
            gReceberParcela.nroLinha = -1;
            gReceberParcela.idReceberParcela = 0;
            gReceberParcela.codEmpresa = codempresa;
            gReceberParcela.nroParcela = 0;
            ReceberDocumento oPagardoc = new ReceberDocumento();
            gReceberParcela.receberDocumento = oPagardoc;
            gReceberParcela.dataVencimento = DateTime.Now;
            gReceberParcela.valorParcela = 0;
            gReceberParcela.valorDesconto = 0;
            gReceberParcela.valorJuros = 0;
            gReceberParcela.saldoPagar = 0;
            gReceberParcela.saldoPago = 0;
            gReceberParcela.situacao = "A";
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = 1;
            gReceberParcela.tipoCobranca = oCobr;
            gReceberParcela.codigoBarras = "";
            gReceberParcela.nossoNumero = "";
            gReceberParcela.nominal = "";
            gReceberParcela.documento = "";

        }

        public void gravaAltParcela()
        {
            if (gReceberParcela.nroLinha > -1)
            {
                grdReceberBaixa.Rows[gReceberParcela.nroLinha].Cells["valorpagar"].Value = gReceberParcela.valorPagar;
                grdReceberBaixa.Rows[gReceberParcela.nroLinha].Cells["desconto"].Value = gReceberParcela.valorDesconto;
                grdReceberBaixa.Rows[gReceberParcela.nroLinha].Cells["juros"].Value = gReceberParcela.valorJuros;
                grdReceberBaixa.Rows[gReceberParcela.nroLinha].Cells["valortotal"].Value = Convert.ToDecimal(gReceberParcela.valorTotalPagar.ToString());
                grdReceberBaixa.Rows[gReceberParcela.nroLinha].Cells["cliente"].Value = gReceberParcela.nominal;
            }
            atualizaSomaGrid();
        }

        public void atualizaSomaGrid()
        {
            Decimal somaValorPagar = 0;
            Decimal somaDesconto = 0;
            Decimal somaJuros = 0;
            Decimal somaTotal = 0;

            foreach (DataGridViewRow row in grdReceberBaixa.Rows)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)row.Cells[0];
                if (ch1.Value == ch1.TrueValue)
                {
                    somaValorPagar = somaValorPagar + Convert.ToDecimal(row.Cells["valorpagar"].Value.ToString());
                    somaDesconto = somaDesconto + Convert.ToDecimal(row.Cells["desconto"].Value.ToString());
                    somaJuros = somaJuros + Convert.ToDecimal(row.Cells["juros"].Value.ToString());
                    somaTotal = somaTotal + Convert.ToDecimal(row.Cells["valortotal"].Value.ToString());
                }
            }
            txtValorDocumento.Text = somaValorPagar.ToString();
            txtJuros.Text = somaJuros.ToString();
            txtDesconto.Text = somaDesconto.ToString();
            txtTotalPagar.Text = somaTotal.ToString();
        }

#endregion

#region [Texts, combos]
        //cliente
        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text))
            {
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                Cliente oCliente = new Cliente();

                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtIdCliente.Text = oCliente.idPessoa.ToString();
                    txtCNPJCPF.Text = oCliente.pessoa.cnpjCpf;
                    txtRazaoSocial.Text = oCliente.pessoa.nome;

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

        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCNPJCPF.Text))
                {
                    txtIdCliente.ReadOnly = false;
                    txtIdCliente.Focus();
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
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCNPJCPF.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdCliente.ReadOnly = false;
                            txtIdCliente.Focus();
                        }
                        else
                        {
                            txtIdCliente.Text = oCliente.idPessoa.ToString();
                            txtRazaoSocial.Text = oCliente.pessoa.nome;
                            txtIdCliente.ReadOnly = true;
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

        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdCliente.Text = "";
                else
                    txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdCliente_Validating(null, null);

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
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                Cliente oCliente = new Cliente();

                oCliente.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                oCliente.codEmpresa = empMaster;

                oCliente = oClienteRN.ObterPor(oCliente);

                if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                {
                    MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtNomePessoa.Text = oCliente.pessoa.nome;
                    txtNominal.Text = oCliente.pessoa.nome;

                }

            }
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
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

        private void txtIdReceberBaixa_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            BuscaObjeto();
        }

        private void btnAdiantamento_Click(object sender, EventArgs e)
        {
            psqAdReceber oPsq = new psqAdReceber(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);

            oPsq.ShowDialog();

            oPsq.Dispose();

            txtNroDocCompensar.Text = retPesquisa.chavebusca;
            txtIdParcelaAmortizar.Text = retPesquisa.chaveinterna.ToString();

            if (EmcResources.cInt(txtIdParcelaAmortizar.Text) > 0)
            {
                ReceberBaixa oBaixa = new ReceberBaixa();
                ReceberBaixaRN oBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);

                oBaixa.idReceberBaixa = EmcResources.cInt(txtIdParcelaAmortizar.Text);

                oBaixa = oBaixaRN.ObterPor(oBaixa);

                txtNroDocCompensar.Text = oBaixa.receberParcela.receberDocumento.nroDocumento;
                txtNroParcela.Text = oBaixa.receberParcela.nroParcela.ToString();
                txtDataBaixa.Text = oBaixa.dataPagamento.ToString();
                txtFornecedor.Text = oBaixa.receberParcela.receberDocumento.cliente.pessoa.nome;
                txtValorAdiantamento.Text = oBaixa.valorBaixa.ToString();
                txtSdoCompensar.Text = oBaixa.sdoAmortizacao.ToString();
            }
        }

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
                btnCheques.Enabled = false;
                situacaoBaixa = "P";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "2")
            {
                //Pagamento em Cheque
                cboIdContaBancaria.Enabled = true;
                btnCheques.Enabled = true;
                situacaoBaixa = "P";

            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "3")
            {
                //Pagamento CH Pre datado
                cboIdContaBancaria.Enabled = true;
                btnCheques.Enabled = true;
                situacaoBaixa = "H";

            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "4")
            {
                //Pagamento Remessa Eletronica
                cboIdContaBancaria.Enabled = true;
                btnCheques.Enabled = false;
                situacaoBaixa = "R";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "5")
            {
                //Amortização de Adiantamento
                cboIdContaBancaria.Enabled = false;
                btnCheques.Enabled = false;
                situacaoBaixa = "A";
            }
            else if (cboIdFormaPagamento.SelectedValue.ToString() == "6")
            {
                //Debito/Credito em conta corrente
                cboIdContaBancaria.Enabled = true;
                btnCheques.Enabled = false;
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

        private void btnCheques_Click(object sender, EventArgs e)
        {
            try
            {
                string TipoCheque = "";
                if (EmcResources.cInt(cboIdFormaPagamento.SelectedValue.ToString()) == 3)
                    TipoCheque = "PRE";


                frmReceberCheque oFrm = new frmReceberCheque(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, TipoCheque);
                oFrm.ShowDialog();

                if (chequeRecebido.lstChequeRecebido.Count <= 0)
                    MessageBox.Show("É necessário o cadastramento do cheque recebido", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    lstChequeRecebido = chequeRecebido.lstChequeRecebido;

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

#endregion  

        private void txtIdAcordo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);

                if (!String.IsNullOrEmpty(txtIdAcordo.Text))
                {
                    ReceberAcordo oAcordo = new ReceberAcordo();
                    oAcordo.idAcordo = EmcResources.cInt(txtIdAcordo.Text);

                    oAcordo = oAcordoRN.ObterPor(oAcordo);

                    if (oAcordo.idGeradorAcordo > 0)
                    {
                        txtAcordo.Text = oAcordo.cliente.pessoa.nome;
                    }
                    else
                    {
                        AtivaInsercao();
                        MessageBox.Show("Acordo não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message);
            }
        }

    }
}
