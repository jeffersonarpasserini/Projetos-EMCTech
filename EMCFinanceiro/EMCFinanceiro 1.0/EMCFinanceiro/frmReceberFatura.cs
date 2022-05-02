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
    public partial class frmReceberFatura : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmReceberFatura";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        DataTable dtParcelas = new DataTable();

        #region [Metodos para configuração do formulário]
        public frmReceberFatura()
        {
            InitializeComponent();
        }
        public frmReceberFatura(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmReceberFatura_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "receberfatura";

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

            txtIdIndexador.Text = Convert.ToString(cboIdIndexador.SelectedValue);

            CancelaOperacao();
            this.ActiveControl = txtIdCliente;

        }
        #endregion

        #region [metodos para tratamento das informacoes]
        private Boolean verificaReceberFatura(ReceberFatura oPgdoc)
        {
            ReceberFaturaRN oReceberRN = new ReceberFaturaRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oReceberRN.VerificaDados(oPgdoc);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        private ReceberDocumento montaReceberDocumento()
        {
            ReceberDocumento oReceberDocumento = new ReceberDocumento();

            oReceberDocumento.codEmpresa = codempresa;
            oReceberDocumento.nroDocumento = EmcResources.cStr(txtNroDocumento.Text.Trim());

            // se for alteracao executa
            flagInclusao = false;
            if (!flagInclusao)
            {
                oReceberDocumento.cadastro_idusuario = Convert.ToInt32(usuario);
                oReceberDocumento.cadastro_datahora = DateTime.Now;

                oReceberDocumento.dataEmissao = EmcResources.cDate(txtDataEmissao.Text.ToString());
                oReceberDocumento.dataEntrada = EmcResources.cDate(txtDataEntrada.Text.ToString());
                oReceberDocumento.valorDocumento = Convert.ToDecimal(txtValorDocumento.Text);
                oReceberDocumento.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
                oReceberDocumento.situacao = "A";

                if (cboPeriodicidade.Text == "Quinzenal")
                    oReceberDocumento.periodicidade = "Q";
                else if (cboPeriodicidade.Text == "Mensal")
                    oReceberDocumento.periodicidade = "M";
                else if (cboPeriodicidade.Text == "Bimestral")
                    oReceberDocumento.periodicidade = "B";
                else if (cboPeriodicidade.Text == "Semestral")
                    oReceberDocumento.periodicidade = "S";
                else if (cboPeriodicidade.Text == "Anual")
                    oReceberDocumento.periodicidade = "A";
                else
                    oReceberDocumento.periodicidade = "M";


                oReceberDocumento.diaFixo = EmcResources.cStr(txtDiaFixo.Text);
                oReceberDocumento.origemDocumento = "CTARECEBER";
                oReceberDocumento.descricao = EmcResources.cStr(txtDescricao.Text);

                TipoDocumento oTipo = new TipoDocumento();
                TipoDocumentoRN oTipoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);
                //Tipo documento Fatura
                oTipo.idTipoDocumento = Convert.ToInt32("2");
                oTipo = oTipoRN.ObterPor(oTipo);
                oReceberDocumento.tipoDocumento = oTipo;



                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);
                oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);
                oIndexador = oIndexadorRN.ObterPor(oIndexador);
                oReceberDocumento.indexador = oIndexador;


                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);
                oCliente.codEmpresa = codempresa;
                oCliente.idPessoa = Convert.ToInt32(txtIdCliente.Text);
                oCliente = oClienteRN.ObterPor(oCliente);
                oReceberDocumento.cliente = oCliente;


                List<ReceberParcela> lstParcelas = new List<ReceberParcela>();
                ReceberParcela oParcela;
                ReceberDocumento oDoc = new ReceberDocumento();

                oDoc.idReceberDocumento = 0;


                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdFaturaParcelas.Rows)
                {

                    oParcela = new ReceberParcela();
                    oParcela.cadastro_idusuario = Convert.ToInt32(usuario);
                    oParcela.cadastro_datahora = DateTime.Now;
                    oParcela.codEmpresa = codempresa;
//                    oParcela.codigoBarras = dataGridViewRow.Cells["codbarras"].Value.ToString();
                    oParcela.dataVencimento = EmcResources.cDate(dataGridViewRow.Cells["vencimento"].Value.ToString());
                    oParcela.idReceberParcela = EmcResources.cInt(dataGridViewRow.Cells["idparc"].Value.ToString());
                    //oParcela.nossoNumero = dataGridViewRow.Cells["nsonumero"].Value.ToString();
                    oParcela.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["numeroparcela"].Value.ToString());
                    oParcela.receberDocumento = oDoc;
                    oParcela.saldoPagar = Convert.ToDecimal(dataGridViewRow.Cells["sdopagar"].Value.ToString());
                    oParcela.saldoPago = Convert.ToDecimal(dataGridViewRow.Cells["sdopago"].Value.ToString());
                    oParcela.situacao = dataGridViewRow.Cells["sit"].Value.ToString();
                    oParcela.valorDesconto = Convert.ToDecimal(dataGridViewRow.Cells["vlrdesconto"].Value.ToString());
                    oParcela.valorJuros = Convert.ToDecimal(dataGridViewRow.Cells["vlrjuros"].Value.ToString());
                    oParcela.valorParcela = Convert.ToDecimal(dataGridViewRow.Cells["vlrparcela"].Value.ToString());
                    oParcela.status = dataGridViewRow.Cells["st"].Value.ToString();

                    TipoCobranca oCobr = new TipoCobranca();
                    TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                    oCobr.idTipoCobranca = EmcResources.cInt(dataGridViewRow.Cells["idtpcobranca"].Value.ToString());
                    oCobr = oCobrRN.ObterPor(oCobr);
                    oParcela.tipoCobranca = oCobr;

                    Formulario oFormulario = new Formulario();

                    oParcela.formulario = oFormulario;

                    List<ReceberBaixa> lstReceberBaixa = new List<ReceberBaixa>();
                    oParcela.baixas = lstReceberBaixa;

                    lstParcelas.Add(oParcela);
                }


                oReceberDocumento.parcelas = lstParcelas;
            }

            return oReceberDocumento;
        }
        private ReceberFatura montaReceberFatura()
        {
            ReceberFatura oFatura = new ReceberFatura();

            try
            {

                oFatura.cadastro_datahora = DateTime.Now;
                oFatura.cadastro_idusuario = EmcResources.cInt(usuario.ToString());
                oFatura.codEmpresa = codempresa;
                oFatura.dataFatura = Convert.ToDateTime(txtDataEmissao.Text);
                
                Cliente oCliente = new Cliente();
                ClienteRN oFornRN = new ClienteRN(Conexao, objOcorrencia, codempresa);
                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente.codEmpresa = empMaster;
                oFatura.cliente = oFornRN.ObterPor(oCliente);

                oFatura.numeroDocumento = txtNroDocumento.Text;
                oFatura.situacao = "A";
                oFatura.valorFatura = EmcResources.cCur(txtValorDocumento.Text);
                oFatura.receberDocumento = montaReceberDocumento();
                
                List<ReceberParcela> lstParcelas = new List<ReceberParcela>();
                ReceberParcelaRN oParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);

                foreach (DataGridViewRow row in grdReceberParcelas.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell) row.Cells[0];
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        ReceberParcela oReceberParcela = new ReceberParcela();

                        oReceberParcela.idReceberParcela = EmcResources.cInt(row.Cells["idreceberparcela"].Value.ToString());
                        oReceberParcela = oParcelaRN.ObterPor(oReceberParcela);

                        lstParcelas.Add(oReceberParcela);
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
        private void montaTela(ReceberFatura oReceberFatura)
        {
            //Mostra documento gerado 
            ReceberDocumento oReceberDocumento = new ReceberDocumento();
            oReceberDocumento = oReceberFatura.receberDocumento;

            txtIdReceberDocumento.Text = oReceberDocumento.idReceberDocumento.ToString();
            txtNroDocumento.Text = oReceberDocumento.nroDocumento;
            txtDataEmissao.Text = oReceberDocumento.dataEmissao.ToString();
            txtDataEntrada.Text = oReceberDocumento.dataEntrada.ToString();

            txtIdCliente.Text = oReceberDocumento.cliente.idPessoa.ToString();
            txtCliente.Text = oReceberDocumento.cliente.pessoa.nome.ToString();

            txtIdIndexador.Text = oReceberDocumento.indexador.idIndexador.ToString();
            cboIdIndexador.SelectedValue = oReceberDocumento.indexador.idIndexador.ToString();


            txtDescricao.Text = oReceberDocumento.descricao.ToString();
            if (oReceberDocumento.periodicidade == "Q")
                cboPeriodicidade.Text = "Quinzenal";
            else if (oReceberDocumento.periodicidade == "M")
                cboPeriodicidade.Text = "Mensal";
            else if (oReceberDocumento.periodicidade == "B")
                cboPeriodicidade.Text = "Bimestral";
            else if (oReceberDocumento.periodicidade == "S")
                cboPeriodicidade.Text = "Semestral";
            else if (oReceberDocumento.periodicidade == "A")
                cboPeriodicidade.Text = "Anual";

            txtDiaFixo.Text = oReceberDocumento.diaFixo.ToString();
            txtValorDocumento.Text = oReceberDocumento.valorDocumento.ToString();
            txtNroParcelas.Text = oReceberDocumento.nroParcelas.ToString();


            AtualizaGrid(oReceberDocumento);

           
            //mostra dados da fatura
            txtSituacao.Text = oReceberFatura.situacao;
            txtIdReceberFatura.Text = oReceberFatura.idReceberFatura.ToString();
            txtValorDocumento.Text = oReceberFatura.valorFatura.ToString();
            txtSomaParcelas.Text = "0";


            grdReceberParcelas.Rows.Clear();

            foreach (ReceberParcela oParcela in oReceberFatura.lstParcelas)
            {
             
                grdReceberParcelas.Rows.Add(true, oParcela.receberDocumento.nroDocumento,
                                              oParcela.nroParcela,
                                              oParcela.dataVencimento,
                                              oParcela.dataQuitacao,
                                              oParcela.valorParcela,
                                              oParcela.saldoPago,
                                              oParcela.valorDesconto,
                                              oParcela.valorJuros,
                                              oParcela.saldoPagar,
                                              oParcela.situacao,
                                              "",
                                              "",
                                              oParcela.idReceberParcela,
                                              oParcela.tipoCobranca.descricao,
                                              oParcela.tipoCobranca.idTipoCobranca
                                              );   
            }


            objOcorrencia.chaveidentificacao = oReceberDocumento.idReceberDocumento.ToString();

            grdReceberParcelas.Enabled = false;
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

            grdReceberParcelas.Enabled = true;
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
        }
        public override void BuscaObjeto()
        {
            try
            {

                psqReceberFatura oPsq = new psqReceberFatura(usuario,
                                                             login,
                                                             codempresa.ToString(),
                                                             empMaster.ToString(),
                                                             Conexao,
                                                             objOcorrencia);
                oPsq.ShowDialog();

                oPsq.Dispose();

                txtNroDocumento.Text = retPesquisa.chavebusca;
                txtIdReceberFatura.Text = retPesquisa.chaveinterna.ToString();

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
            grdReceberParcelas.Rows.Clear();
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
                    ReceberFatura oReceberFatura = new ReceberFatura();
                    ReceberFaturaRN oReceberFaturaRN = new ReceberFaturaRN(Conexao, objOcorrencia, codempresa);

                    oReceberFatura = montaReceberFatura();


                    if (verificaReceberFatura(oReceberFatura))
                    {
                        oReceberFaturaRN.Salvar(oReceberFatura);
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

                    ReceberFatura oReceberFatura = new ReceberFatura();
                    ReceberFaturaRN oReceberFaturaRN = new ReceberFaturaRN(Conexao, objOcorrencia, codempresa);

                    oReceberFatura = montaReceberFatura();
                    oReceberFatura.idReceberFatura = Convert.ToInt32(txtIdReceberFatura.Text);

                    if (verificaReceberFatura(oReceberFatura))
                    {
                        //oReceberFaturaRN.Atualizar(oReceberFatura);

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
                List<ReceberParcela> lstReceberParcela = new List<ReceberParcela>();
                ReceberParcelaRN oReceberParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                lstReceberParcela = oReceberParcelaRN.listaReceberFatura(EmcResources.cInt(usuario),
                                                                   codempresa, 
                                                                   empMaster,
                                                                   EmcResources.cInt(txtIdCliente.Text), 
                                                                   Convert.ToDateTime(txtDataInicio.Text), 
                                                                   Convert.ToDateTime(txtDataFinal.Text), 
                                                                   chkTodasContas.Checked);

                if (lstReceberParcela.Count>0)
                {
                    //Monta grid de parcelas em aberto e sem autorização existentes
                    foreach(ReceberParcela oParcela in lstReceberParcela)
                    {
                        grdReceberParcelas.Rows.Add(false, oParcela.receberDocumento.nroDocumento, oParcela.nroParcela, oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela,
                                                oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar,
                                                oParcela.situacao, "", "", oParcela.idReceberParcela,
                                                oParcela.tipoCobranca.descricao, oParcela.tipoCobranca.idTipoCobranca);

                    }

                }
                else
                {
                    MessageBox.Show("Não foram encontradas parcelas em aberto para o cliente", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ReceberDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void pesquisaFatura()
        {
            try
            {
                ReceberFaturaRN oFatRN = new ReceberFaturaRN(Conexao, objOcorrencia, codempresa);
                ReceberFatura oFat = new ReceberFatura();
                oFat.idReceberFatura = EmcResources.cInt(txtIdReceberFatura.Text);

                oFat = oFatRN.ObterPor(oFat);

                montaTela(oFat);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ReceberDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region [Metodos Buttons, Texts]
        private void btnPsqParcelas_Click(object sender, EventArgs e)
        {
            pesquisaDocumento();
        }
        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    Cliente oCliente = new Cliente();
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);

                    oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    txtCliente.Text = oCliente.pessoa.nome;
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message, "EMC", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void btnCliente_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                txtIdCliente.Focus();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdCliente.Text = "";
                else
                {
                    txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    SendKeys.Send("{TAB}");
                }

                
                
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
        public void AtualizaGrid(ReceberDocumento oReceberDocumento)
        {

            //foreach (DataRow row in dtPAgamento)

            //adquiri lista de parcelas do objeto documento
            List<ReceberParcela> lstReceberParcela = oReceberDocumento.parcelas;

            grdFaturaParcelas.Rows.Clear();
            Decimal somaParcelas = 0;

            foreach (ReceberParcela oParcela in lstReceberParcela)
            {
                grdFaturaParcelas.Rows.Add("", oParcela.nroParcela, oParcela.dataVencimento, oParcela.dataQuitacao, oParcela.valorParcela,
                                          oParcela.saldoPago, oParcela.valorDesconto, oParcela.valorJuros, oParcela.saldoPagar,
                                          oParcela.situacao, "", "", oParcela.idReceberParcela,
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
            if (gReceberParcela.nroParcela > 0)
                gravaAltParcela();
        }
        private void grdFaturaParcelas_DoubleClick(object sender, EventArgs e)
        {

        }
        private void montaGlobalParcela()
        {
            gReceberParcela.nroLinha = grdFaturaParcelas.CurrentRow.Index;
            gReceberParcela.idReceberParcela = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["idparc"].Value.ToString());
            gReceberParcela.codEmpresa = codempresa;
            gReceberParcela.nroParcela = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["numeroparcela"].Value.ToString());
            ReceberDocumento oReceberdoc = new ReceberDocumento();
            oReceberdoc.idReceberDocumento = EmcResources.cInt(txtIdReceberFatura.Text);
            gReceberParcela.receberDocumento = oReceberdoc;
            gReceberParcela.dataVencimento = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vencimento"].Value.ToString());
            //if (String.IsNullOrEmpty(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gReceberParcela.dataQuitacao = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

            gReceberParcela.valorParcela = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrparcela"].Value.ToString());
            gReceberParcela.valorDesconto = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrdesconto"].Value.ToString());
            gReceberParcela.valorJuros = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["vlrjuros"].Value.ToString());
            gReceberParcela.saldoPagar = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sdopagar"].Value.ToString());
            gReceberParcela.saldoPago = Convert.ToDecimal(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sdopago"].Value.ToString());
            gReceberParcela.situacao = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["sit"].Value.ToString();
            TipoCobranca oCobr = new TipoCobranca();
            oCobr.idTipoCobranca = EmcResources.cInt(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["idtpcobranca"].Value.ToString());
            gReceberParcela.tipoCobranca = oCobr;
            gReceberParcela.codigoBarras = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["codbarras"].Value.ToString();
            gReceberParcela.nossoNumero = grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["nsonumero"].Value.ToString();
            gReceberParcela.status = "";

        }
        private void limpaGlobalParcela()
        {
            gReceberParcela.nroLinha = -1;
            gReceberParcela.idReceberParcela = 0;
            gReceberParcela.codEmpresa = codempresa;
            gReceberParcela.nroParcela = 0;
            ReceberDocumento oReceberdoc = new ReceberDocumento();
            oReceberdoc.idReceberDocumento = EmcResources.cInt(txtIdReceberFatura.Text);
            gReceberParcela.receberDocumento = oReceberdoc;
            gReceberParcela.dataVencimento = DateTime.Now;
            //if (String.IsNullOrEmpty(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString()))
            //{
            //}
            //else gReceberParcela.dataQuitacao = EmcResources.cDate(grdFaturaParcelas.Rows[grdFaturaParcelas.CurrentRow.Index].Cells["dataquitacao"].Value.ToString());

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
            if (gReceberParcela.nroLinha > -1)
            {
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["codbarras"].Value = gReceberParcela.codigoBarras;
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["nsonumero"].Value = gReceberParcela.nossoNumero;

                TipoCobranca oCobr = new TipoCobranca();
                TipoCobrancaRN oCobrRN = new TipoCobrancaRN(Conexao, objOcorrencia, codempresa);
                oCobr = oCobrRN.ObterPor(gReceberParcela.tipoCobranca);
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["idtpcobranca"].Value = oCobr.idTipoCobranca.ToString();
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["desctipocobranca"].Value = oCobr.descricao;

                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["vlrparcela"].Value = Convert.ToDecimal(gReceberParcela.valorParcela.ToString());
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["sdoreceber"].Value = Convert.ToDecimal(gReceberParcela.valorParcela.ToString()) - Convert.ToDecimal(gReceberParcela.saldoPago.ToString());
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["vencimento"].Value = EmcResources.cDate(gReceberParcela.dataVencimento.ToString());
                grdFaturaParcelas.Rows[gReceberParcela.nroLinha].Cells["st"].Value = EmcResources.cStr(gReceberParcela.status.ToString());
            }
            else
            {

                bool bErro = false;
                foreach (DataGridViewRow row in grdFaturaParcelas.Rows)
                {
                    if (EmcResources.cInt(row.Cells["numeroparcela"].Value.ToString()) == gReceberParcela.nroParcela)
                    {
                        bErro = true;
                    }
                }

                if (bErro)
                {
                    MessageBox.Show("Nova parcela nro " + gReceberParcela.nroParcela + " cancelada, Parcela já existe", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    grdFaturaParcelas.Rows.Add("I", gReceberParcela.nroParcela.ToString(), Convert.ToDateTime(gReceberParcela.dataVencimento.ToString()),
                                              "", Convert.ToDecimal(gReceberParcela.valorParcela.ToString()), 0, 0, 0, Convert.ToDecimal(gReceberParcela.saldoPagar.ToString()),
                                              "A", gReceberParcela.nossoNumero, gReceberParcela.codigoBarras, "",
                                              gReceberParcela.tipoCobranca.descricao, gReceberParcela.tipoCobranca.idTipoCobranca.ToString());
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
                if (oParametroRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "VENCIMENTO_DIA_UTIL") == "S")
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

        #region [Metodos para controle da grid grdReceberParcelas]
        private void grdReceberParcelas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (grdReceberParcelas.Rows.Count > 0)
            {

                if (e.ColumnIndex == grdReceberParcelas.Columns["status"].Index)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)grdReceberParcelas.Rows[grdReceberParcelas.CurrentRow.Index].Cells[0];
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) + Convert.ToDecimal(grdReceberParcelas.Rows[e.RowIndex].Cells["valorparcela"].Value.ToString()));
                    }
                    else
                    {
                        txtValorDocumento.Text = Convert.ToString(EmcResources.cCur(txtValorDocumento.Text) - Convert.ToDecimal(grdReceberParcelas.Rows[e.RowIndex].Cells["valorparcela"].Value.ToString()));
                    }
                }

            }

            if (EmcResources.cCur(txtValorDocumento.Text) > 0)
            {
                AtivaInsercao();
            }
            else CancelaOperacao();
        }
        private void grdReceberParcelas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdReceberParcelas.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        #endregion





    }
}
