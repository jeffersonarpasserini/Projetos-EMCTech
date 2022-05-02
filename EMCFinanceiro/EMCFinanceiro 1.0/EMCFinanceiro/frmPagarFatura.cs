using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiro.Pesquisa;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastro;

namespace EMCFinanceiro
{
    public partial class frmPagarFatura : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPagarFatura";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        DataTable dtParcelas = new DataTable();
        int idMoedaCorrente = 0;

        #region [Metodos para configuração do formulário]
        public frmPagarFatura()
        {
            InitializeComponent();
        }
        public frmPagarFatura(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmPagarFatura_Load(object sender, EventArgs e)
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


            /* Identifica o codigo do indexador da moeda corrente no pais */
            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
            idMoedaCorrente = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "GERAL", "MOEDA_CORRENTE"));

            //Periodicidade
            cboPeriodicidade.Items.Add("Quinzenal");
            cboPeriodicidade.Items.Add("Mensal");
            cboPeriodicidade.Items.Add("Bimestral");
            cboPeriodicidade.Items.Add("Semestral");
            cboPeriodicidade.Items.Add("Anual");

            //Carregamento de Combobox do formulário
            TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
            cboTipoCobranca.DataSource = oCobrRN.ListaTipoCobranca();
            cboTipoCobranca.DisplayMember = "descricao";
            cboTipoCobranca.ValueMember = "idtipocobranca";

            IndexadorRN oIndexRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
            cboIdIndexador.DataSource = oIndexRN.ListaIndexador();
            cboIdIndexador.DisplayMember = "descricao";
            cboIdIndexador.ValueMember = "idindexador";

            cboIdIndexador.SelectedValue = idMoedaCorrente;

            txtIdIndexador.Text = Convert.ToString(cboIdIndexador.SelectedValue);

            CancelaOperacao();

            this.ActiveControl = txtIdFornecedor;

        }
        #endregion

        #region [metodos para tratamento das informacoes]
        private Boolean verificaPagarFatura(PagarFatura oPgdoc)
        {
            PagarFaturaRN oPagarRN = new PagarFaturaRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oPagarRN.VerificaDados(oPgdoc);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        private PagarDocumento montaPagarDocumento()
        {
            PagarDocumento oPagarDocumento = new PagarDocumento();

            oPagarDocumento.codEmpresa = codempresa;
            oPagarDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());

            // se for alteracao executa
            flagInclusao = false;
            if (!flagInclusao)
            {
                oPagarDocumento.cadastro_idusuario = Convert.ToInt32(usuario);
                oPagarDocumento.cadastro_datahora = DateTime.Now;

                oPagarDocumento.dataEmissao = EmcResources.cDate(txtDataEmissao.Text.ToString());
                oPagarDocumento.dataEntrada = EmcResources.cDate(txtDataEntrada.Text.ToString());
                oPagarDocumento.valorDocumento = Convert.ToDecimal(txtValorDocumento.Text);
                oPagarDocumento.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
                oPagarDocumento.situacao = "A";
                oPagarDocumento.valorIndice = 1;
                oPagarDocumento.dataUltimaCorrecao = DateTime.Now;
                oPagarDocumento.valorIndexado = EmcResources.cDouble(txtValorDocumento.Text);


                if (cboPeriodicidade.Text == "Quinzenal")
                    oPagarDocumento.periodicidade = "Q";
                else if (cboPeriodicidade.Text == "Mensal")
                    oPagarDocumento.periodicidade = "M";
                else if (cboPeriodicidade.Text == "Bimestral")
                    oPagarDocumento.periodicidade = "B";
                else if (cboPeriodicidade.Text == "Semestral")
                    oPagarDocumento.periodicidade = "S";
                else if (cboPeriodicidade.Text == "Anual")
                    oPagarDocumento.periodicidade = "A";
                else
                    oPagarDocumento.periodicidade = "M";


                oPagarDocumento.diaFixo = EmcResources.cStr(txtDiaFixo.Text);
                oPagarDocumento.origemDocumento = "CTAPAGAR";
                oPagarDocumento.descricao = EmcResources.cStr(txtDescricao.Text);
                

                TipoDocumento oTipo = new TipoDocumento();
                TipoDocumentoRN oTipoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                //Tipo documento Fatura
                oTipo.idTipoDocumento = Convert.ToInt32("2");
                oTipo = oTipoRN.ObterPor(oTipo);
                oPagarDocumento.tipoDocumento = oTipo;



                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
                oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);
                oIndexador = oIndexadorRN.ObterPor(oIndexador);
                oPagarDocumento.indexador = oIndexador;


                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = Convert.ToInt32(txtIdFornecedor.Text);
                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);
                oPagarDocumento.fornecedor = oFornecedor;


                List<PagarParcela> lstParcelas = new List<PagarParcela>();
                PagarParcela oParcela;
                PagarDocumento oDoc = new PagarDocumento();

                oDoc.idPagarDocumento = 0;


                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdFaturaParcelas.Rows)
                {

                    oParcela = new PagarParcela();
                    oParcela.cadastro_idusuario = Convert.ToInt32(usuario);
                    oParcela.cadastro_datahora = DateTime.Now;
                    oParcela.codEmpresa = codempresa;
                    oParcela.codigoBarras = dataGridViewRow.Cells["codbarras"].Value.ToString();
                    oParcela.dataVencimento = EmcResources.cDate(dataGridViewRow.Cells["vencimento"].Value.ToString());
                    oParcela.idPagarParcela = EmcResources.cInt(dataGridViewRow.Cells["idparc"].Value.ToString());
                    oParcela.nossoNumero = dataGridViewRow.Cells["nsonumero"].Value.ToString();
                    oParcela.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["numeroparcela"].Value.ToString());
                    oParcela.pagarDocumento = oDoc;
                    oParcela.saldoPagar = Convert.ToDecimal(dataGridViewRow.Cells["sdopagar"].Value.ToString());
                    oParcela.saldoPago = Convert.ToDecimal(dataGridViewRow.Cells["sdopago"].Value.ToString());
                    oParcela.situacao = dataGridViewRow.Cells["sit"].Value.ToString();
                    oParcela.valorDesconto = Convert.ToDecimal(dataGridViewRow.Cells["vlrdesconto"].Value.ToString());
                    oParcela.valorJuros = Convert.ToDecimal(dataGridViewRow.Cells["vlrjuros"].Value.ToString());
                    oParcela.valorParcela = Convert.ToDecimal(dataGridViewRow.Cells["vlrparcela"].Value.ToString());
                    oParcela.status = dataGridViewRow.Cells["st"].Value.ToString();
                    oParcela.dataUltimaCorrecao = DateTime.Now;
                    oParcela.valorCorrecaoMonetaria = 0;
                    oParcela.valorCMPago = 0;
                    oParcela.valorIndexado = EmcResources.cDouble(oParcela.valorParcela.ToString());

                    TipoCobranca oCobr = new TipoCobranca();
                    TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                    oCobr.idTipoCobranca = EmcResources.cInt(dataGridViewRow.Cells["idtpcobranca"].Value.ToString());
                    oCobr = oCobrRN.ObterPor(oCobr);
                    oParcela.tipoCobranca = oCobr;

                    List<PagarBaixa> lstPagarBaixa = new List<PagarBaixa>();
                    oParcela.baixas = lstPagarBaixa;

                    lstParcelas.Add(oParcela);
                }


                oPagarDocumento.parcelas = lstParcelas;
            }

            return oPagarDocumento;
        }
        private PagarFatura montaPagarFatura()
        {
            PagarFatura oFatura = new PagarFatura();

            try
            {

                oFatura.cadastro_datahora = DateTime.Now;
                oFatura.cadastro_idusuario = EmcResources.cInt(usuario.ToString());
                oFatura.codEmpresa = codempresa;
                oFatura.dataFatura = Convert.ToDateTime(txtDataEmissao.Text);
                
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;
                oFatura.fornecedor = oFornRN.ObterPor(oFornecedor);

                oFatura.numeroDocumento = txtNroDocumento.Text;
                oFatura.situacao = "A";
                oFatura.valorFatura = EmcResources.cCur(txtValorDocumento.Text);
                oFatura.pagarDocumento = montaPagarDocumento();
                
                List<PagarParcela> lstParcelas = new List<PagarParcela>();
                PagarParcelaRN oParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);

                foreach (DataGridViewRow row in grdPagarParcelas.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell) row.Cells[0];
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        PagarParcela oPagarParcela = new PagarParcela();

                        oPagarParcela.idPagarParcela = EmcResources.cInt(row.Cells["idpagarparcelas"].Value.ToString());
                        oPagarParcela = oParcelaRN.ObterPor(oPagarParcela);

                        lstParcelas.Add(oPagarParcela);
                    }
                }

                oFatura.lstParcelas = lstParcelas;
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return oFatura;

        }
        private void montaTela(PagarFatura oPagarFatura)
        {
            //Mostra documento gerado 
            PagarDocumento oPagarDocumento = new PagarDocumento();
            oPagarDocumento = oPagarFatura.pagarDocumento;

            txtIdPagarDocumento.Text = oPagarDocumento.idPagarDocumento.ToString();
            txtNroDocumento.Text = oPagarDocumento.nroDocumento;
            txtDataEmissao.Text = oPagarDocumento.dataEmissao.ToString();
            txtDataEntrada.Text = oPagarDocumento.dataEntrada.ToString();

            txtIdFornecedor.Text = oPagarDocumento.fornecedor.idPessoa.ToString();
            txtFornecedor.Text = oPagarDocumento.fornecedor.pessoa.nome.ToString();

            txtIdIndexador.Text = oPagarDocumento.indexador.idIndexador.ToString();
            cboIdIndexador.SelectedValue = oPagarDocumento.indexador.idIndexador.ToString();


            txtDescricao.Text = oPagarDocumento.descricao.ToString();
            if (oPagarDocumento.periodicidade == "Q")
                cboPeriodicidade.Text = "Quinzenal";
            else if (oPagarDocumento.periodicidade == "M")
                cboPeriodicidade.Text = "Mensal";
            else if (oPagarDocumento.periodicidade == "B")
                cboPeriodicidade.Text = "Bimestral";
            else if (oPagarDocumento.periodicidade == "S")
                cboPeriodicidade.Text = "Semestral";
            else if (oPagarDocumento.periodicidade == "A")
                cboPeriodicidade.Text = "Anual";

            txtDiaFixo.Text = oPagarDocumento.diaFixo.ToString();
            txtValorDocumento.Text = oPagarDocumento.valorDocumento.ToString();
            txtNroParcelas.Text = oPagarDocumento.nroParcelas.ToString();


            AtualizaGrid(oPagarDocumento);

           
            //mostra dados da fatura
            txtSituacao.Text = oPagarFatura.situacao;
            txtIdPagarFatura.Text = oPagarFatura.idPagarFatura.ToString();
            txtValorDocumento.Text = oPagarFatura.valorFatura.ToString();
            txtSomaParcelas.Text = "0";


            foreach (PagarParcela oParcela in oPagarFatura.lstParcelas)
            {
             
                grdPagarParcelas.Rows.Add(true, oParcela.pagarDocumento.nroDocumento,
                                              oParcela.nroParcela,
                                              oParcela.dataVencimento,
                                              oParcela.dataQuitacao,
                                              oParcela.valorParcela,
                                              oParcela.saldoPago,
                                              oParcela.valorDesconto,
                                              oParcela.valorJuros,
                                              oParcela.saldoPagar,
                                              oParcela.situacao,
                                              oParcela.nossoNumero,
                                              oParcela.codigoBarras,
                                              oParcela.idPagarParcela,
                                              oParcela.tipoCobranca.descricao,
                                              oParcela.tipoCobranca.idTipoCobranca
                                              );   
            }


            objOcorrencia.chaveidentificacao = oPagarDocumento.idPagarDocumento.ToString();

            grdPagarParcelas.Enabled = false;
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
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
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            btnGeraParcelas.Enabled = false;
            if (txtSituacao.Text == "P")
            {
                travaBotao("btnExcluir");
                travaBotao("btnAtualizar");
            }
            else
            {
                liberaBotao("btnExcluir");
                liberaBotao("btnAtualizar");
            }

        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            btnGeraParcelas.Enabled = true;
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            
            objOcorrencia.chaveidentificacao = "";

            grdPagarParcelas.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
        }
        public override void BuscaObjeto()
        {
            try
            {

                psqPagarFatura oPsq = new psqPagarFatura(usuario,
                                                             login,
                                                             codempresa.ToString(),
                                                             empMaster.ToString(),
                                                             Conexao,
                                                             objOcorrencia);
                oPsq.ShowDialog();

                oPsq.Dispose();

                txtNroDocumento.Text = retPesquisa.chavebusca;
                txtIdPagarFatura.Text = retPesquisa.chaveinterna.ToString();

                pesquisaFatura();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtNroDocumento.Focus();
            flagInclusao = true;
            grdFaturaParcelas.Rows.Clear();
            grdPagarParcelas.Rows.Clear();
            txtValorDocumento.Text = "0";

            objOcorrencia.chaveidentificacao = "";
        }
        public override void SalvaObjeto()
        {

            try
            {
                if (EmcResources.cCur(txtSomaParcelas.Text) != EmcResources.cCur(txtValorDocumento.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSituacao.Text == "P")
                {

                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PagarFatura oPagarFatura = new PagarFatura();
                    PagarFaturaRN oPagarFaturaRN = new PagarFaturaRN(Conexao, objOcorrencia, codempresa);

                    oPagarFatura = montaPagarFatura();


                    if (verificaPagarFatura(oPagarFatura))
                    {
                        oPagarFaturaRN.Salvar(oPagarFatura);
                        LimpaCampos();
                    }
                    base.SalvaObjeto();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " - " + erro.StackTrace);
            }

        }
        public override void AtualizaObjeto()
        {
            try
            {
                if (EmcResources.cCur(txtValorDocumento.Text) != EmcResources.cCur(txtValorDocumento.Text))
                {
                    MessageBox.Show("Valor do documento não fecha com as parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSituacao.Text == "P")
                {
                    MessageBox.Show("Documento está quitado, alteração não permitida", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificaSequenciaParcelas())
                {
                    MessageBox.Show("Verifique a sequencia das parcelas, Operação Cancelada!", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    PagarFatura oPagarFatura = new PagarFatura();
                    PagarFaturaRN oPagarFaturaRN = new PagarFaturaRN(Conexao, objOcorrencia, codempresa);

                    oPagarFatura = montaPagarFatura();
                    oPagarFatura.idPagarFatura = Convert.ToInt32(txtIdPagarFatura.Text);

                    if (verificaPagarFatura(oPagarFatura))
                    {
                        //oPagarFaturaRN.Atualizar(oPagarFatura);

                        //LimpaCampos();

                        MessageBox.Show("Documento atualizado com sucesso");
                    }
                    else MessageBox.Show("Atualização cancelada");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
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
        public void pesquisaDocumento()
        {
            try
            {
                List<PagarParcela> lstPagarParcela = new List<PagarParcela>();
                PagarParcelaRN oPagarParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                lstPagarParcela = oPagarParcelaRN.listaPagarFatura(EmcResources.cInt(usuario),
                                                                   codempresa, 
                                                                   EmcResources.cInt(txtIdFornecedor.Text), 
                                                                   Convert.ToDateTime(txtDataInicio.Text), 
                                                                   Convert.ToDateTime(txtDataFinal.Text), 
                                                                   chkTodasContas.Checked);

                if (lstPagarParcela.Count>0)
                {
                    //Monta grid de parcelas em aberto e sem autorização existentes
                    foreach(PagarParcela oParcela in lstPagarParcela)
                    {
                        grdPagarParcelas.Rows.Add(false, oParcela.pagarDocumento.nroDocumento, oParcela.nroParcela, oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela,
                                                oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar,
                                                oParcela.situacao, oParcela.nossoNumero, oParcela.codigoBarras, oParcela.idPagarParcela,
                                                oParcela.tipoCobranca.descricao, oParcela.tipoCobranca.idTipoCobranca);

                    }

                }
                else
                {
                    MessageBox.Show("Não foram encontradas parcelas em aberto para o fornecedor", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void pesquisaFatura()
        {
            try
            {
                PagarFaturaRN oFatRN = new PagarFaturaRN(Conexao, objOcorrencia, codempresa);
                PagarFatura oFat = new PagarFatura();
                oFat.idPagarFatura = EmcResources.cInt(txtIdPagarFatura.Text);

                oFat = oFatRN.ObterPor(oFat);

                montaTela(oFat);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region [Metodos Buttons, Texts]
        private void btnPsqParcelas_Click(object sender, EventArgs e)
        {
            pesquisaDocumento();
        }
        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdFornecedor.Text))
                {
                    Fornecedor oFornecedor = new Fornecedor();
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    txtFornecedor.Text = oFornecedor.pessoa.nome;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message, "EMC", MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        //Indexador
        private void cboIdIndexador_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtIdIndexador.Text = Convert.ToString(cboIdIndexador.SelectedValue);
            txtDescricao.Focus();
        }
        private void txtIdIndexador_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdIndexador.Text))
            {
                cboIdIndexador.Focus();
            }
            else
            {
                cboIdIndexador.SelectedValue = Convert.ToInt32(txtIdIndexador.Text);
                txtDescricao.Focus();
            }
        }

       
      
        #endregion

        #region [metodos para controle da grid - grdFaturaParcelas]
        public void AtualizaGrid(PagarDocumento oPagarDocumento)
        {

            //foreach (DataRow row in dtPAgamento)

            //adquiri lista de parcelas do objeto documento
            List<PagarParcela> lstPagarParcela = oPagarDocumento.parcelas;

            grdFaturaParcelas.Rows.Clear();
            Decimal somaParcelas = 0;

            foreach (PagarParcela oParcela in lstPagarParcela)
            {
                grdFaturaParcelas.Rows.Add("", oParcela.nroParcela, oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela,
                                          oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar,
                                          oParcela.situacao, oParcela.nossoNumero, oParcela.codigoBarras, oParcela.idPagarParcela,
                                          oParcela.tipoCobranca.descricao, oParcela.tipoCobranca.idTipoCobranca);
                somaParcelas = somaParcelas + oParcela.valorParcela;
            }

            txtSomaParcelas.Text = somaParcelas.ToString();

            grdFaturaParcelas.ScrollBars = ScrollBars.Both;

        }
        public void atualizaSomaGrid()
        {
            Decimal somaParcelas = 0;
            foreach (DataGridViewRow row in grdFaturaParcelas.Rows)
            {
                if (row.Cells["st"].Value.ToString() != "E")
                {
                    somaParcelas = somaParcelas + Convert.ToDecimal(row.Cells["vlrparcela"].Value.ToString());
                }
            }
            txtSomaParcelas.Text = somaParcelas.ToString();

            if (somaParcelas != Convert.ToDecimal(txtValorDocumento.Text))
            {
                txtSomaParcelas.BackColor = Color.Red;
            }
            else
                txtSomaParcelas.BackColor = Color.Yellow;
        }
        #endregion

        #region [metodos para gerir alteracoes no parcelamento - grdFaturaParcelas]
        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            if (grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sit"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["st"].Value.ToString() == "E")
                    grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["st"].Value = "";
                else
                    grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["st"].Value = "E";

                atualizaSomaGrid();
            }
        }
        private void btnIncluiParcela_Click(object sender, EventArgs e)
        {
            limpaGlobalParcela();
            frmEditaParcelas ofrm = new frmEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
            if (gPagarParcela.nroParcela > 0)
                gravaAltParcela();
        }
        private void grdFaturaParcelas_DoubleClick(object sender, EventArgs e)
        {
            if (grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sit"].Value.ToString() != "A")
            {
                MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                montaGlobalParcela();
                frmEditaParcelas ofrm = new frmEditaParcelas(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();
                gravaAltParcela();
            }
        }
        private void montaGlobalParcela()
        {
            gPagarParcela.nroLinha = grdFaturaParcelas.CurrentRow.Index;
            gPagarParcela.idPagarParcela = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["idparc"].Value.ToString());
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["numeroparcela"].Value.ToString());
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdPagarFatura.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vencimento"].Value.ToString());
            //if (String.IsNullOrEmpty(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

            gPagarParcela.valorParcela = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrparcela"].Value.ToString());
            gPagarParcela.valorDesconto = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrdesconto"].Value.ToString());
            gPagarParcela.valorJuros = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrjuros"].Value.ToString());
            gPagarParcela.saldoPagar = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sdopagar"].Value.ToString());
            gPagarParcela.saldoPago = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sdopago"].Value.ToString());
            gPagarParcela.situacao = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sit"].Value.ToString();
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["idtpcobranca"].Value.ToString());
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.codigoBarras = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["codbarras"].Value.ToString();
            gPagarParcela.nossoNumero = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["nsonumero"].Value.ToString();
            gPagarParcela.status = "";

        }
        private void limpaGlobalParcela()
        {
            gPagarParcela.nroLinha = -1;
            gPagarParcela.idPagarParcela = 0;
            gPagarParcela.codEmpresa = codempresa;
            gPagarParcela.nroParcela = 0;
            PagarDocumento oPagardoc = new PagarDocumento();
            oPagardoc.idPagarDocumento = EmcResources.cInt(txtIdPagarFatura.Text);
            gPagarParcela.pagarDocumento = oPagardoc;
            gPagarParcela.dataVencimento = DateTime.Now;
            //if (String.IsNullOrEmpty(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gPagarParcela.dataQuitacao = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

            gPagarParcela.valorParcela = 0;
            gPagarParcela.valorDesconto = 0;
            gPagarParcela.valorJuros = 0;
            gPagarParcela.saldoPagar = 0;
            gPagarParcela.saldoPago = 0;
            gPagarParcela.situacao = "A";
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = 1;
            gPagarParcela.tipoCobranca = oCobr;
            gPagarParcela.codigoBarras = "";
            gPagarParcela.nossoNumero = "";

        }
        private bool verificaSequenciaParcelas()
        {
            bool bErro = false;
            try
            {

                int contaParcela = 1;
                List<Int32> lstParcela = new List<Int32>();
                foreach (DataGridViewRow row in grdFaturaParcelas.Rows)
                {
                    lstParcela.Add(EmcResources.cInt(row.Cells["numeroparcela"].Value.ToString()));
                }

                lstParcela.Sort();

                foreach (Int32 nroParcela in lstParcela)
                {
                    if (nroParcela != contaParcela)
                    {
                        bErro = true;
                    }
                    contaParcela++;

                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC");
            }
            return bErro;
        }
        public void gravaAltParcela()
        {
            if (gPagarParcela.nroLinha > -1)
            {
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["codbarras"].Value = gPagarParcela.codigoBarras;
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["nsonumero"].Value = gPagarParcela.nossoNumero;

                TipoCobranca oCobr = new TipoCobranca();
                TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                oCobr = oCobrRN.ObterPor(gPagarParcela.tipoCobranca);
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["idtpcobranca"].Value = oCobr.idTipoCobranca.ToString();
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["desctipocobranca"].Value = oCobr.descricao;

                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["vlrparcela"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString());
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["sdopagar"].Value = Convert.ToDecimal(gPagarParcela.valorParcela.ToString()) - Convert.ToDecimal(gPagarParcela.saldoPago.ToString());
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["vencimento"].Value = EmcResources.cDate(gPagarParcela.dataVencimento.ToString());
                grdFaturaParcelas.Rows[gPagarParcela.nroLinha].Cells["st"].Value = EmcResources.cStr(gPagarParcela.status.ToString());
            }
            else
            {

                bool bErro = false;
                foreach (DataGridViewRow row in grdFaturaParcelas.Rows)
                {
                    if (EmcResources.cInt(row.Cells["numeroparcela"].Value.ToString()) == gPagarParcela.nroParcela)
                    {
                        bErro = true;
                    }
                }

                if (bErro)
                {
                    MessageBox.Show("Nova parcela nro " + gPagarParcela.nroParcela + " cancelada, Parcela já existe", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    grdFaturaParcelas.Rows.Add("I", gPagarParcela.nroParcela.ToString(), Convert.ToDateTime(gPagarParcela.dataVencimento.ToString()),
                                              "", Convert.ToDecimal(gPagarParcela.valorParcela.ToString()), 0, 0, 0, Convert.ToDecimal(gPagarParcela.saldoPagar.ToString()),
                                              "A", gPagarParcela.nossoNumero, gPagarParcela.codigoBarras, "",
                                              gPagarParcela.tipoCobranca.descricao, gPagarParcela.tipoCobranca.idTipoCobranca.ToString());
                }
            }



            atualizaSomaGrid();
        }
        #endregion 

        #region [Calculos do parcelamento]
        private void btnGeraParcelas_Click(object sender, EventArgs e)
        {

            //verifica as informações necessárias
            if (Convert.ToDecimal(txtValorDocumento.Text) == 0)
                MessageBox.Show("Valor do documento deve ser informado!");
            else if (Convert.ToInt32(txtNroParcelas.Text) == 0)
                MessageBox.Show("Número de Parcelas deve ser informado!");
            else
            {
                calculaParcelamento();
            }


        }
        private void calculaParcelamento()
        {
            //Limpa a grid
            grdFaturaParcelas.Rows.Clear();

            //Atribui valores
            Decimal valorDocumento = Convert.ToDecimal(txtValorDocumento.Text);
            int nroParcelas = Convert.ToInt32(txtNroParcelas.Text);

            //Calcula parcela e diferencas
            Decimal vlrParcela = Decimal.Round((valorDocumento / nroParcelas), 2);
            Decimal vlrDiferenca = valorDocumento - (vlrParcela * nroParcelas);

            //Geração de Parcelas
            int xParc = 1;
            DateTime xDataVenc = Convert.ToDateTime(txtDataEmissao.Text);

            while (xParc <= nroParcelas)
            {
                //ser for a ultima parcela joga a diferença
                if (xParc == nroParcelas)
                    vlrParcela = (vlrParcela + vlrDiferenca);

                //atribui o numero de dias de acordo com a periodicidade escolhida
                if (cboPeriodicidade.Text == "Mensal")
                    xDataVenc = xDataVenc.AddDays(30);
                else if (cboPeriodicidade.Text == "Quinzenal")
                    xDataVenc = xDataVenc.AddDays(15);
                else if (cboPeriodicidade.Text == "Bimestral")
                    xDataVenc = xDataVenc.AddDays(60);
                else if (cboPeriodicidade.Text == "Semestral")
                    xDataVenc = xDataVenc.AddDays(180);
                else if (cboPeriodicidade.Text == "Anual")
                    xDataVenc = xDataVenc.AddDays(360);

                //Verifica dia fixo
                DateTime dataGravar = xDataVenc;
                if (!String.IsNullOrEmpty(txtDiaFixo.Text))
                {
                    String dtDiafixo = "";
                    String diaFixo = txtDiaFixo.Text;

                    if (txtDiaFixo.Text == "30" || txtDiaFixo.Text == "31")
                    {
                        //verifica dia fixo se é o ultimo dia do mes
                        if (dataGravar.Month == 2)
                            diaFixo = "28";
                        else if (dataGravar.Month == 1 || dataGravar.Month == 3 || dataGravar.Month == 5
                              || dataGravar.Month == 7 || dataGravar.Month == 8 || dataGravar.Month == 10
                              || dataGravar.Month == 12)
                            diaFixo = "31";
                        else diaFixo = "30";
                    }

                    dtDiafixo = diaFixo + "/" + xDataVenc.Month.ToString() + "/" + xDataVenc.Year.ToString();

                    dataGravar = Convert.ToDateTime(dtDiafixo);
                }

                ParametroRN oParametroRN = new ParametroRN(Conexao,objOcorrencia,codempresa);
                //verifica o parametro considera data valida para vencimento de parcelas.
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTAPAGAR", "VENCIMENTO_DIA_UTIL") == "S")
                {
                    // colocar if de acordo com parametro
                    FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                    dataGravar = oFeriadoRN.diaUtil(dataGravar);
                }

                TipoCobrancaRN oTpCobRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                TipoCobranca otpCob = new TipoCobranca();
                otpCob.idTipoCobranca = EmcResources.cInt(cboTipoCobranca.SelectedValue.ToString());
                otpCob = oTpCobRN.ObterPor(otpCob);

                grdFaturaParcelas.Rows.Add("", xParc, dataGravar, "", vlrParcela, 0, 0, 0, vlrParcela, "A", "", "", "", otpCob.descricao, otpCob.idTipoCobranca.ToString());

                xParc++;
            }

            atualizaSomaGrid();
        }
        #endregion 

        #region [Metodos para controle da grid grdPagarParcelas]
        private void grdPagarParcelas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (grdPagarParcelas.Rows.Count > 0)
            {

                if (e.ColumnIndex == grdPagarParcelas.Columns["status"].Index)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grdPagarParcelas.Rows[grdPagarParcelas.CurrentRow.Index].Cells[0];
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) + Convert.ToDecimal(grdPagarParcelas.Rows[e.RowIndex].Cells["valorparcela"].Value.ToString()));
                    }
                    else
                    {
                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) - Convert.ToDecimal(grdPagarParcelas.Rows[e.RowIndex].Cells["valorparcela"].Value.ToString()));
                    }
                }

            }

            if (EmcResources.cCur(txtValorDocumento.Text) > 0)
            {
                AtivaInsercao();
            }
            else CancelaOperacao();
        }
        private void grdPagarParcelas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdPagarParcelas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion


    }
}
