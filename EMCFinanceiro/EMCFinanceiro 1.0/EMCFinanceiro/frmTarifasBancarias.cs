using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCCadastro;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCSecurityRN;
using EMCFinanceiroModel;
using EMCFinanceiroRN;

namespace EMCFinanceiro
{
    public partial class frmTarifasBancarias : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmTarifasBancarias";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        //private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        Boolean digitaCtaCusto = false;
        Boolean tarifaConciliada = false;
        int idMoedaCorrente = 0;

        public frmTarifasBancarias()
        {
            InitializeComponent();
        }
        public frmTarifasBancarias(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmTarifasBancarias_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tarifabancaria";

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;

            AtualizaGrid();
            CancelaOperacao();
            this.ActiveControl = txtCNPJCPF;

            lblSituacao.Text = "";
        }


#region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaTarifaBancaria(TarifaBancaria oTarifaBancaria)
        {
            TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oTarifaBancariaRN.VerificaDados(oTarifaBancaria);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }

        private TarifaBancaria montaTarifaBancaria(string status)
        {
            TarifaBancaria oTarifaBancaria = new TarifaBancaria();
            try
            {

                Indexador oIndex = new Indexador();
                IndexadorRN oIndexRN = new IndexadorRN(Conexao,objOcorrencia,codempresa);
                oIndex.idIndexador = idMoedaCorrente;
                oIndex = oIndexRN.ObterPor(oIndex);

                TipoDocumento oTipoDocumento = new TipoDocumento();
                TipoDocumentoRN oTpDocRN = new TipoDocumentoRN(Conexao,objOcorrencia,codempresa);
                oTipoDocumento.idTipoDocumento = EmcResources.cInt(cboIdTipoDocumento.SelectedValue.ToString());
                oTipoDocumento = oTpDocRN.ObterPor(oTipoDocumento);
                
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;
                oFornecedor = oFornRN.ObterPor(oFornecedor);

                Aplicacao oApl = new Aplicacao();
                AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);
                oApl.idAplicacao = EmcResources.cInt(txtIdAplicacao.Text);
                oApl = oAplRN.ObterPor(oApl);

                ContaCusto oCusto = new ContaCusto();
                ContaCustoRN oCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
                oCusto.idContaCusto = EmcResources.cInt(txtIdContaCusto.Text);
                oCusto = oCustoRN.ObterPor(oCusto);

                CtaBancaria oCta = new CtaBancaria();
                CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                oCta.idCtaBancaria = EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString());
                oCta.codEmpresa = codempresa;
                oCta = oCtaRN.ObterPor(oCta);

                /* Monta Documento Contas a Pagar */
                PagarDocumento oPgDoc = new PagarDocumento();

                
                PagarBaseRateio oPgBaseRateio = new PagarBaseRateio();
                oPgBaseRateio.idPagarBaseRateio = EmcResources.cInt(txtIdPagarBaseRateio.Text);
                oPgBaseRateio.aplicacao = oApl;
                oPgBaseRateio.contaCusto = oCusto;
                oPgBaseRateio.codEmpresa = codempresa;
                oPgBaseRateio.percentualRateio = 100;
                oPgBaseRateio.status = status;
                oPgBaseRateio.valorRateio = EmcResources.cCur(txtValorTarifa.Value.ToString());
                List<PagarBaseRateio> lstBaseRateio = new List<PagarBaseRateio>();
                lstBaseRateio.Add(oPgBaseRateio);

                oPgDoc.baseRateio = lstBaseRateio;
                oPgDoc.idPagarDocumento = EmcResources.cInt(txtIdPagarDocumento.Text);
                oPgDoc.cadastro_datahora = DateTime.Now;
                oPgDoc.cadastro_idusuario = EmcResources.cInt(usuario);
                oPgDoc.codEmpresa = codempresa;
                oPgDoc.dataEmissao = Convert.ToDateTime(txtDataTarifa.Text);
                oPgDoc.dataEntrada = Convert.ToDateTime(txtDataTarifa.Text);
                oPgDoc.descricao = txtDescricao.Text;
                oPgDoc.diaFixo = "";
                oPgDoc.fornecedor = oFornecedor;
                oPgDoc.indexador = oIndex;
                oPgDoc.nroDocumento = txtNroDocumento.Text;
                oPgDoc.nroParcelas = 1;
                oPgDoc.origemDocumento = "TARIFA";
                oPgDoc.periodicidade = "P";
                oPgDoc.situacao = "A";
                oPgDoc.tipoDocumento = oTipoDocumento;
                oPgDoc.valorDocumento = EmcResources.cCur(txtValorTarifa.Value.ToString());
                oPgDoc.valorIndexado = EmcResources.cDouble(txtValorTarifa.Value.ToString());
                oPgDoc.valorIndice = 1;
                oPgDoc.dataUltimaCorrecao = DateTime.Now;

                
                List<PagarParcela> lstParcelas = new List<PagarParcela>();
                PagarParcela oParcela = new PagarParcela();
                oParcela.idPagarParcela = EmcResources.cInt(txtIdPagarParcela.Text);
                oParcela.autorizado ="N";
                oParcela.cadastro_datahora = DateTime.Now;
                oParcela.cadastro_idusuario = EmcResources.cInt(usuario);
                oParcela.codEmpresa = codempresa;
                oParcela.codigoBarras ="";
                oParcela.dataQuitacao = null;
                oParcela.dataVencimento = Convert.ToDateTime(txtDataTarifa.Text);
                oParcela.nossoNumero ="";
                oParcela.nroParcela=1;
                oParcela.saldoPagar = EmcResources.cCur(txtValorTarifa.Value.ToString());
                oParcela.saldoPago = 0;
                oParcela.situacao ="A";
                oParcela.status = status;
                TipoCobranca otpCobranca = new TipoCobranca();
                otpCobranca.idTipoCobranca = 3;
                oParcela.tipoCobranca = otpCobranca;
                oParcela.valorParcela = EmcResources.cCur(txtValorTarifa.Value.ToString());
                oParcela.valorIndice = 1;
                oParcela.valorIndexado = EmcResources.cDouble(txtValorTarifa.Value.ToString());
                oParcela.valorCorrecaoMonetaria = 0;
                oParcela.pagarDocumento = oPgDoc;
                List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();
                oParcela.baixas = lstPagarBaixa;

                lstParcelas.Add(oParcela);

                oPgDoc.parcelas = lstParcelas;

                /* monta tarifa bancaria */
                oTarifaBancaria.idTarifaBancaria = EmcResources.cInt(txtIdTarifaBancaria.Text);
                oTarifaBancaria.aplicacao = oApl;
                oTarifaBancaria.contaBancaria = oCta;
                oTarifaBancaria.contaCusto = oCusto;
                oTarifaBancaria.dataTarifa = Convert.ToDateTime(txtDataTarifa.Text);
                oTarifaBancaria.descricao = txtDescricao.Text;
                oTarifaBancaria.fornecedor = oFornecedor;
                oTarifaBancaria.idEmpresa = codempresa;
                oTarifaBancaria.nroDocumento = txtNroDocumento.Text;
                oTarifaBancaria.valorTarifa = EmcResources.cCur(txtValorTarifa.Value.ToString());
                oTarifaBancaria.pagarDocumento = oPgDoc;


            }
            catch(Exception erro)
            {
                throw erro;
            }

            return oTarifaBancaria;
        }

        private void montaTela(TarifaBancaria oTarifaBancaria)
        {

            if (oTarifaBancaria.autorizado == "S")
                lblSituacao.Text = "Autorizado Pagamento";

            if (oTarifaBancaria.situacao == "P")
                lblSituacao.Text = "Documento Quitado";

            
            txtIdPagarDocumento.Text = oTarifaBancaria.pagarDocumento.idPagarDocumento.ToString();
            txtIdTarifaBancaria.Text = oTarifaBancaria.idTarifaBancaria.ToString();

            txtIdFornecedor.Text = oTarifaBancaria.fornecedor.idPessoa.ToString();
            txtIdFornecedor_Validating(null, null);
            txtNroDocumento.Text = oTarifaBancaria.nroDocumento;
            txtIdContaCusto.Text = oTarifaBancaria.contaCusto.idContaCusto.ToString();
            txtCodigoConta.Text = oTarifaBancaria.contaCusto.codigoConta;
            txtCodigoConta_Validating(null,null);
            txtIdAplicacao.Text = oTarifaBancaria.aplicacao.idAplicacao.ToString();
            txtIdAplicacao_Validating(null, null);
            cboIdTipoDocumento.SelectedValue = oTarifaBancaria.pagarDocumento.tipoDocumento.idTipoDocumento;
            txtDataTarifa.Text = oTarifaBancaria.dataTarifa.ToShortDateString();
            txtValorTarifa.Text =oTarifaBancaria.valorTarifa.ToString();
            cboCtaBancaria.SelectedValue = EmcResources.cInt(oTarifaBancaria.contaBancaria.idCtaBancaria.ToString());
            txtDescricao.Text = oTarifaBancaria.descricao;


            foreach(PagarParcela oParc in oTarifaBancaria.pagarDocumento.parcelas)
            {
                txtIdPagarParcela.Text =oParc.idPagarParcela.ToString();
            }

            foreach(PagarBaseRateio oRat in oTarifaBancaria.pagarDocumento.baseRateio)
            {
                txtIdPagarBaseRateio.Text = oRat.idPagarBaseRateio.ToString();
            }

            objOcorrencia.chaveidentificacao = oTarifaBancaria.idTarifaBancaria.ToString();

            txtConciliado.Text = oTarifaBancaria.autorizado;
            txtSituacao.Text = oTarifaBancaria.situacao;

            AtivaEdicao();

            if (oTarifaBancaria.situacao == "P" || oTarifaBancaria.autorizado == "S")
            {
                /* se for autorizado ou pago trava botoes de edição */

                travaBotao("btnSalvar");
                travaBotao("btnAtualizar");
                travaBotao("btnExcluir");

            }


        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

            if (txtSituacao.Text == "P" || txtConciliado.Text == "S")
            {
                /* se for autorizado ou pago trava botoes de edição */

                travaBotao("btnSalvar");
                travaBotao("btnAtualizar");
                travaBotao("btnExcluir");

            }
            txtCNPJCPF.Enabled = false;
            txtIdFornecedor.Enabled = false;
            txtNroDocumento.Enabled = false;
            txtRazaoSocial.Enabled = false;


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

            txtIdTarifaBancaria.Enabled = false;

            txtCNPJCPF.Enabled = true;
            txtIdFornecedor.Enabled = true;
            txtNroDocumento.Enabled = true;
            txtRazaoSocial.Enabled = false;

           
            txtCNPJCPF.Focus();

        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();

            

            txtCNPJCPF.Focus();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            

        }

        public void pesquisaTarifa()
        {
            try
            {
                TarifaBancaria oTarifa = new TarifaBancaria();

                if (!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdFornecedor.Text))
                {
                    Fornecedor oForn = new Fornecedor();
                    oForn.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                    oForn.codEmpresa = empMaster;

                    oTarifa.idEmpresa = codempresa;
                    oTarifa.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());
                    oTarifa.fornecedor = oForn;
                }
                else if (!String.IsNullOrEmpty(txtIdTarifaBancaria.Text))
                {
                    oTarifa.idTarifaBancaria = EmcResources.cInt(txtIdTarifaBancaria.Text);
                    oTarifa.idEmpresa = codempresa;
                }

                if ((!String.IsNullOrEmpty(txtNroDocumento.Text) && !String.IsNullOrEmpty(txtIdFornecedor.Text)) || (!String.IsNullOrEmpty(txtIdTarifaBancaria.Text)))
                {
                    TarifaBancariaRN oTarifaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);
                    oTarifa = oTarifaRN.ObterPor(oTarifa);

                    if (!String.IsNullOrEmpty(oTarifa.descricao))
                    {
                        montaTela(oTarifa);
                        AtualizaGrid();
                        AtivaEdicao();
                        txtCodigoConta.Focus();
                    }
                    else
                    {
                        AtivaInsercao();
                        txtCodigoConta.Focus();
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            /* monta como conta bancaria */
            CtaBancaria oCta = new CtaBancaria();
            CtaBancariaRN oCtaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
            oCta.codEmpresa = codempresa;

            cboIdContaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboIdContaBancaria.DisplayMember = "descricao";
            cboIdContaBancaria.ValueMember = "idctabancaria";

            cboCtaBancaria.DataSource = oCtaRN.ListaCtaBancaria(oCta);
            cboCtaBancaria.DisplayMember = "descricao";
            cboCtaBancaria.ValueMember = "idctabancaria";

            /* Forma de Pagamento */
            FormaPagamento oForma = new FormaPagamento();
            FormaPagamentoRN oFormaRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);

            cboIdFormaPagamento.DataSource = oFormaRN.ListaFormaPagamento();
            cboIdFormaPagamento.DisplayMember = "descricao";
            cboIdFormaPagamento.ValueMember = "idformapagamento";

            cboIdFormaPagamento.SelectedValue = 6;

            cboIdFormaPagamento.Enabled = false;

            /* historico */
            Historico oHistorico = new Historico();
            HistoricoRN oHistoricoRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);

            cboHistorico.DataSource = oHistoricoRN.ListaHistorico(oHistorico);
            cboHistorico.DisplayMember = "descricao";
            cboHistorico.ValueMember = "idhistorico";

            /* Tipo Documento */
            TipoDocumento oTipoDoc = new TipoDocumento();
            TipoDocumentoRN oTipoDocRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);

            cboIdTipoDocumento.DataSource = oTipoDocRN.ListaTipoDocumento();
            cboIdTipoDocumento.ValueMember = "idtipodocumento";
            cboIdTipoDocumento.DisplayMember = "descricao";


            /* Identifica o codigo do indexador da moeda corrente no pais */
            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
            idMoedaCorrente = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));


            //verifica se a tarifa bancaria vai ser gravada no movimento bancaria já concialiada ou não
            if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "TARIFA_CONCILIADA") == "S")
            {
                tarifaConciliada = true;
            }
            else
                tarifaConciliada = false;

            //verifica se é permitido ao usuario digitar a conta custo na entrada de tarifas bancarias
            if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "TARIFA_DIGITA_CCUSTO") == "N")
            {
                digitaCtaCusto = false;
                txtCodigoConta.Enabled = false;
                txtContaCusto.Enabled = false;
                btnContaCusto.Enabled = false;

                ContaCusto oCusto = new ContaCusto();
                ContaCustoRN oCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                oCusto.codigoConta = oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "TARIFA_CTACUSTO");

                if (String.IsNullOrEmpty(oCusto.codigoConta))
                {
                    MessageBox.Show("Informar nos parametros de configuração a conta custo para digitação de tarifas bancarias.");
                }
                else
                {
                    oCusto = oCustoRN.ObterPor(oCusto);

                    if (oCusto.idContaCusto <= 0)
                    {
                        MessageBox.Show("Conta Custo informada nos parametros é invalida, corrigir.");
                    }
                    else
                    {
                        txtIdContaCusto.Text = oCusto.idContaCusto.ToString();
                        txtCodigoConta.Text = oCusto.codigoConta;
                        txtContaCusto.Text = oCusto.descricao;
                    }
                }


            }
            else
            {
                digitaCtaCusto = true;
            }

            txtIdTarifaBancaria.Enabled = false;

            lblSituacao.Text = "";

            txtIdPagarDocumento.Text = "";
            txtIdPagarBaseRateio.Text = "";
            txtIdPagarParcela.Text = "";
            txtIdTarifaBancaria.Text = "";

            txtIdFornecedor.Text = "";
            txtCNPJCPF.Text = "";
            txtNroDocumento.Text = "";

            txtCNPJCPF.Enabled = true;
            txtIdFornecedor.Enabled = true;
            txtNroDocumento.Enabled = true;
            txtRazaoSocial.Enabled = false;


            txtCNPJCPF.Focus();
            objOcorrencia.chaveidentificacao = "";

            AtualizaGrid();
        }

        public override void SalvaObjeto()
        {
            try
            {
                TarifaBancaria oTarifaBancaria = new TarifaBancaria();
                TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);

                
                oTarifaBancaria = montaTarifaBancaria("I");
                
                if (verificaTarifaBancaria(oTarifaBancaria))
                {
                    oTarifaBancariaRN.Salvar(oTarifaBancaria);

                    LimpaCampos();
                    
                    AtualizaGrid();

                    txtCNPJCPF.Focus();
                }

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
                TarifaBancaria oTarifaBancaria = new TarifaBancaria();
                TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);

                oTarifaBancaria = montaTarifaBancaria("A");


                if (verificaTarifaBancaria(oTarifaBancaria))
                {

                    oTarifaBancariaRN.Atualizar(oTarifaBancaria);

                    LimpaCampos();
                    MessageBox.Show("TarifaBancaria atualizado com sucesso");
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oTarifaBancaria);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }

        }

        public override void ExcluiObjeto()
        {
            try
            {
                TarifaBancaria oTarifaBancaria = new TarifaBancaria();
                TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);
                oTarifaBancaria = montaTarifaBancaria("E");

                if (verificaTarifaBancaria(oTarifaBancaria))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão da tarifa bancária ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oTarifaBancariaRN.Excluir(oTarifaBancaria);

                        LimpaCampos();
                        MessageBox.Show("Tarifa Bancaria excluida!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
#endregion
#region "Tratamentos para buttons e texts**************************************************************************************"
        private void txtNroDocumento_Validating(object sender, CancelEventArgs e)
        {
            pesquisaTarifa();
            if (digitaCtaCusto)
                txtCodigoConta.Focus();
            else
                txtIdAplicacao.Focus();

        }

        private void txtIdTarifaBancaria_Validating(object sender, CancelEventArgs e)
        {
            pesquisaTarifa();
        }

        private void btnContaCusto_Click(object sender, EventArgs e)
        {
            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, false);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdContaCusto.Text = "";
                // txtCodigoConta.Text = "";
            }
            else
            {
                txtIdContaCusto.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtCodigoConta.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
                txtCodigoConta.Focus();
                SendKeys.Send("{TAB}");
            }


        }

        private void btnAplicacao_Click(object sender, EventArgs e)
        {
            psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdAplicacao.Text = "0";
            }
            else
            {
                txtIdAplicacao.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtIdAplicacao.Focus();
                SendKeys.Send("{TAB}");
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

                txtIdFornecedor.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigoConta.Text))
                {
                    ContaCusto oContaCusto = new ContaCusto();
                    ContaCustoRN oCtaRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                    oContaCusto.codigoConta = txtCodigoConta.Text;
                    oContaCusto = oCtaRN.ObterPor(oContaCusto);

                    if (!String.IsNullOrEmpty(oContaCusto.descricao))
                        txtContaCusto.Text = oContaCusto.descricao;
                    else
                        MessageBox.Show("Conta Custo não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtIdAplicacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdAplicacao.Text))
                {
                    Aplicacao oAplicacao = new Aplicacao();
                    AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);

                    oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Value.ToString());
                    oAplicacao = oAplRN.ObterPor(oAplicacao);

                    if (!String.IsNullOrEmpty(oAplicacao.descricao))
                        txtAplicacao.Text = oAplicacao.descricao;
                    else
                        MessageBox.Show("Aplicação não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
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

        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            txtCNPJCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
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
            else
            {
                //txtCNPJCPF.Focus();
            }
        }

        private void txtDescricao_Validating(object sender, CancelEventArgs e)
        {
            
        }
#endregion
#region "metodos da dbgrid*******************************************************************************************"
       
        private void AtualizaGrid()
        {
            try
            {
                //carrega a grid com os ceps cadastrados
                TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);
                TarifaBancaria oTarifaBancaria = new TarifaBancaria();


                grdTarifa.DataSource = oTarifaBancariaRN.ListaTarifaBancaria();
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPsqTarifas_Click(object sender, EventArgs e)
        {
            try
            {
                //carrega a grid com os ceps cadastrados
                TarifaBancariaRN oTarifaBancariaRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);
                TarifaBancaria oTarifaBancaria = new TarifaBancaria();


                grdTarifa.DataSource = oTarifaBancariaRN.ListaTarifaBancariaBaixa(EmcResources.cInt(cboCtaBancaria.SelectedValue.ToString()));
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnBaixaTarifa_Click(object sender, EventArgs e)
        {
            try
            {
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();

                /* Percorre a grid para realizar a baixa das tarifas */
                foreach(DataGridViewRow oRow in grdTarifa.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                    ch1 = (DataGridViewCheckBoxCell)oRow.Cells[0];

                    if (ch1.Value == null)
                        ch1.Value = false;

                    //if (ch1.Value == ch1.TrueValue)
                    /* se a tarifa esitver marcada para a baixa, realiza */
                    if ( ch1.Value.ToString() == "True" && oRow.Cells["autorizado"].Value.ToString() == "S")
                    {
                        //(oRow.Cells[0].Value.ToString() == "True")
                        PagarBaixa oPgBaixa = new PagarBaixa();


                        TarifaBancaria oTarifa = new TarifaBancaria();
                        TarifaBancariaRN oTarRN = new TarifaBancariaRN(Conexao, objOcorrencia, codempresa);

                        oTarifa.idTarifaBancaria = EmcResources.cInt(oRow.Cells["idtarifabancaria"].Value.ToString());
                        oTarifa = oTarRN.ObterPor(oTarifa);

                        if(tarifaConciliada)
                            oPgBaixa.tarifaConciliada = true;

                        oPgBaixa.agrupadoMovBancario = false;

                        oPgBaixa.cadastro_datahora = DateTime.Now;
                        oPgBaixa.cadastro_idusuario = EmcResources.cInt(usuario);
                        oPgBaixa.codEmpresa = codempresa;
                        oPgBaixa.dataPagamento = oTarifa.dataTarifa;
                        oPgBaixa.situacaoBaixa = "P";
                        oPgBaixa.valorCorrecaoMonetaria = 0;
                        oPgBaixa.valorBaixaIndexado = EmcResources.cDouble(oTarifa.valorTarifa.ToString());
                        oPgBaixa.valorIndiceAjuste = 1;

                        
                        PagarParcelaRN oParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                        PagarParcela oParcela = new PagarParcela();
                        oParcela.idPagarParcela = EmcResources.cInt(oRow.Cells["idpagarparcelas"].Value.ToString());
                        oParcela = oParcelaRN.ObterPor(oParcela);

                        oPgBaixa.pagarParcela = oParcela;

                        oPgBaixa.totalDocumento = EmcResources.cCur(oTarifa.valorTarifa.ToString());
                        
                        CtaBancariaRN oContaRN = new CtaBancariaRN(Conexao, objOcorrencia, codempresa);
                        CtaBancaria oConta = new CtaBancaria();
                        
                        oConta.codEmpresa = codempresa;
                        oConta.idCtaBancaria = oTarifa.contaBancaria.idCtaBancaria;
                        oConta.codEmpresa = codempresa;
                        oConta = oContaRN.ObterPor(oConta);

                        oPgBaixa.contaCorrente = oConta;


                        HistoricoRN oHistRN = new HistoricoRN(Conexao, objOcorrencia, codempresa);
                        Historico oHistorico = new Historico();
                        oHistorico.idHistorico = EmcResources.cInt(cboHistorico.SelectedValue.ToString());
                        oHistorico = oHistRN.ObterPor(oHistorico);
                        oPgBaixa.idHistorico = oHistorico;

                        oPgBaixa.historico = oParcela.pagarDocumento.descricao;

                        FormaPagamentoRN oFormaPagtoRN = new FormaPagamentoRN(Conexao, objOcorrencia, codempresa);
                        FormaPagamento oFormaPagto = new FormaPagamento();
                        oFormaPagto.idFormaPagamento = EmcResources.cInt(cboIdFormaPagamento.SelectedValue.ToString());
                        oFormaPagto = oFormaPagtoRN.ObterPor(oFormaPagto);
                        oPgBaixa.formaPagamento = oFormaPagto;

                        oPgBaixa.valorBaixa = oTarifa.valorTarifa;
                        
                        oPgBaixa.sdoAmortizacao = 0;

                        PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
                        Pessoa oPessoa = new Pessoa();
                        oPessoa.codEmpresa = empMaster;
                        oPessoa.idPessoa = EmcResources.cInt(oParcela.pagarDocumento.fornecedor.idPessoa.ToString());
                        oPgBaixa.pessoa = oPessoaRN.ObterPor(oPessoa);


                        oPgBaixa.nominal = oPgBaixa.pessoa.nome;
                        oPgBaixa.documentoBaixa = oTarifa.nroDocumento;

                        oPgBaixa.dataPreDatado = null;

                        oPgBaixa.valorDesconto =0;
                        oPgBaixa.valorJuros = 0;
                        oPgBaixa.valorTotal = oTarifa.valorTarifa;

                        oPgBaixa.totalJuros =0;
                        oPgBaixa.totalDesconto =0;
                        oPgBaixa.totalPagamento = oTarifa.valorTarifa;

                        lstPagarBaixa.Add(oPgBaixa);

                    }
                }

                if (lstPagarBaixa.Count > 0)
                    oPgBaixaRN.Salvar(lstPagarBaixa,"0");

                LimpaCampos();

            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
#endregion

        

       

       

        




    }
}
