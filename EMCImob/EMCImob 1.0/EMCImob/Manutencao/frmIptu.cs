using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using System.Collections;

namespace EMCImob
{
    public partial class frmIptu : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmIptu";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public frmIptu(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmIptu()
        {
            InitializeComponent();
        }

        private void frmIptu_Activated(object sender, EventArgs e)
        {

        }

        private void frmIptu_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "iptu";

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;


            //AtualizaGrid();
            this.ActiveControl = txtCodigoImovel;
            CancelaOperacao();
        }
        #endregion

        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaIptu(Iptu oIptu)
        {
            IptuRN oIptuRN = new IptuRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oIptuRN.VerificaDados(oIptu);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Iptu: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private List<Iptu> montaIptu()
        {

            List<Iptu> lstIptu = new List<Iptu>();

            foreach (DataGridViewRow oRow in grdIptu.Rows)
            {
                Iptu oIptu = new Iptu();
                oIptu.idIptu = EmcResources.cInt(oRow.Cells["idiptu"].Value.ToString());
                oIptu.idEmpresa = codempresa;
                oIptu.data1Vencimento =Convert.ToDateTime(txt1Vencimento.DateValue.ToString());
                oIptu.parcelaAno = EmcResources.cInt(txtNroParcAno.Text);
                oIptu.flag = oRow.Cells["stoperacao"].Value.ToString();
                oIptu.anoBase = oRow.Cells["anobase"].Value.ToString();
                oIptu.nroParcela = EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString());
                oIptu.observacao = oRow.Cells["observacao"].Value.ToString();
                oIptu.situacao = oRow.Cells["situacao"].Value.ToString();
                oIptu.situacaoCobranca =  oRow.Cells["situacaocobranca"].Value.ToString();
                oIptu.tipoAcerto = "";
                oIptu.valorImposto = EmcResources.cCur(txtValorTotal.Value.ToString());
                oIptu.valorParcela = EmcResources.cCur(oRow.Cells["valorparcela"].Value.ToString());
                oIptu.valorParcelaCarne = EmcResources.cCur(txtVlrParcCarne.Value.ToString());
                oIptu.dataVencimento = Convert.ToDateTime(oRow.Cells["datavencimento"].Value.ToString());
               
                Imovel oImovel = new Imovel();
                oImovel.idImovel = EmcResources.cInt(txtIdImovel2.Text);
                oImovel.codigoImovel = txtCodImovel.Text;
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                oImovel.empresa = oEmpresa;
                oIptu.imovel = oImovel;

                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;
                oFornecedor = oFornRN.ObterPor(oFornecedor);

                oIptu.fornecedor = oFornecedor;

                oIptu.diaFixo = txtDiaFixo.Text;

                if (oIptu.flag == "E")
                {
                    oIptu.idUsuarioExclusao = EmcResources.cInt(usuario);
                    oIptu.dataExclusao = DateTime.Now;
                    oIptu.situacao = "C";
                }

                lstIptu.Add(oIptu);
            }
            return lstIptu;
        }

        private void montaTela(Iptu oIptu)
        {
            txtIdIptu.Text = oIptu.idIptu.ToString();

            txtIdImovel2.Text = oIptu.imovel.idImovel.ToString();
            txtCodImovel.Text = oIptu.imovel.codigoImovel;
            txtDescricaoImovel.Text = oIptu.imovel.tipoImovel.descricao;
            txtAnoBase.Text = oIptu.anoBase;
            txtDiaFixo.Text = oIptu.diaFixo;
            txt1Vencimento.Text = oIptu.data1Vencimento.ToString();
            txtVlrParcCarne.Text = oIptu.valorParcelaCarne.ToString();
            txtNroParcAno.Text = oIptu.parcelaAno.ToString();
            txtValorTotal.Text = oIptu.valorImposto.ToString();

            txtIdFornecedor.Text = oIptu.fornecedor.idPessoa.ToString();
            txtIdFornecedor_Validating(null, null);


            txtNroParcela.Text = oIptu.nroParcela.ToString();
            txtDataVencimento.Text = oIptu.dataVencimento.ToString();
            txtValorParcela.Text = oIptu.valorParcela.ToString();

            //Decimal total = 0;            
            //total = oIptu.nroParcela * oIptu.valorParcela;
            //txtValorTotal.Text = total.ToString();            

            txtObservacao.Text = oIptu.observacao;
            cboSituacao.SelectedValue = oIptu.situacao.ToString();
            cboSituacaoCobranca.SelectedValue = oIptu.situacaoCobranca.ToString();


            txtAnoBaseImovel.Text = oIptu.anoBase;
            txtAnoBase.Text = oIptu.anoBase;

            //AtualizaGrid(oIptu);

            txtIdIptu.Focus();
            AtivaEdicao();

            btnNovaParcela.Enabled = true;
            btnIncluiParcela.Enabled = false;
            btnAlteraParcelas.Enabled = true;
            btnExcluiParcela.Enabled = true;

            if (oIptu.situacao == "C")
            {
                btnAlteraParcelas.Enabled = false;
            }
            else if ( (oIptu.situacao != "A" && oIptu.situacao != "C") || oIptu.situacaoCobranca != "A" )
            {
                btnNovaParcela.Enabled = true;
                btnIncluiParcela.Enabled = false;
                btnAlteraParcelas.Enabled = false;
                btnExcluiParcela.Enabled = false;
            }

            objOcorrencia.chaveidentificacao = oIptu.idIptu.ToString();
        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            grpPesquisa.Enabled = true;
            grpManutencao.Enabled = true;
            grpGerar.Enabled = false;

            travaBotao("btnExcluir");
            mostraAbas();

            txtNroParcela.Focus();

        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            grpPesquisa.Enabled = false;
            grpManutencao.Enabled = false;
            grpGerar.Enabled = true;

            travaBotao("btnExcluir");
            txtCodImovel.Focus();

            ocultaAbas();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";

            grpPesquisa.Enabled = true;
            grpManutencao.Enabled = false;
            grpGerar.Enabled = false;
            txtCodigoImovel.Focus();

            ocultaAbas();

            travaBotao("btnExcluir");
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            try
            {
                psqIptu ofrm = new psqIptu(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdIptu.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdIptu.Enabled = true;
                    txtIdIptu.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtCodigoImovel.Text = EMCImob.retPesquisa.chavebusca.ToString();

                    //txtCodigoImovel.Focus();
                    txtIdIptu.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaIptu()
        {
            if (!String.IsNullOrEmpty(txtIdIptu.Text))
            {

                Iptu oIptu = new Iptu();
                try
                {
                    IptuRN IptuBLL = new IptuRN(Conexao, objOcorrencia, codempresa);

                    //   oImovel = montaImovel();
                    oIptu.idIptu = Convert.ToInt32(txtIdIptu.Text);
                    //oIptu.imovel.codigoImovel = txtCodigoImovel.Text;

                    oIptu = IptuBLL.ObterPor(oIptu);

                    if (oIptu.idIptu == 0)
                    {
                        DialogResult result = MessageBox.Show("IPTU não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oIptu);
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro IPTU: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            grdIptu.Rows.Clear();
            objOcorrencia.chaveidentificacao = "";

            /*
             * Situação para IPTU - Pagamento Financeiro
             * A - Aberto
             * G - Gerado Financeiro
             * P - Processado Financeiro
             * Q - Quitado
             * C - Cancelado
             */
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Aberto", "A"));
            arr.Add(new popCombo("Gerado Financeiro", "G"));
            arr.Add(new popCombo("Processado Financeiro", "P"));
            arr.Add(new popCombo("Quitado", "Q"));
            arr.Add(new popCombo("Cancelado", "C"));
            cboSituacao.DataSource = arr;
            cboSituacao.DisplayMember = "nome";
            cboSituacao.ValueMember = "valor";


            /*
             * Situação para IPTU - Cobrança locador ou locatário
             * 
             * A - Aberto
             * G - Gerado Parcela Contrato
             * 
             */ 
            ArrayList arrSituacaoCobranca = new ArrayList();
            arrSituacaoCobranca.Add(new popCombo("Aberto", "A"));
            arrSituacaoCobranca.Add(new popCombo("Gerado Parcela Contrato", "G"));
            cboSituacaoCobranca.DataSource = arrSituacaoCobranca;
            cboSituacaoCobranca.DisplayMember = "nome";
            cboSituacaoCobranca.ValueMember = "valor";

        }

        public override void SalvaObjeto()
        {
            try
            {
                IptuRN oIptuBLL = new IptuRN(Conexao, objOcorrencia, codempresa);
                oIptuBLL.Salvar(montaIptu());
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void AtualizaObjeto()
        {
            try
            {
                IptuRN oIptuBLL = new IptuRN(Conexao, objOcorrencia, codempresa);
                oIptuBLL.Salvar(montaIptu());
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void ExcluiObjeto()
        {
            try
            {
               
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relIptu ofrm = new Relatorios.relIptu(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid IPTU ***********************************************************************************************"

        private void grdIptu_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grdIptu.Rows[grdIptu.CurrentRow.Index].Cells["stoperacao"].Value.ToString() != "I")
                {
                    //Iptu oIptu = new Iptu();
                    if (grdIptu.Rows[grdIptu.CurrentRow.Index].Cells["situacao"].Value.ToString() != "A" ||
                        grdIptu.Rows[grdIptu.CurrentRow.Index].Cells["situacaocobranca"].Value.ToString() != "A")
                    {
                        txtIdIptu.Text = grdIptu.Rows[grdIptu.CurrentRow.Index].Cells["idiptu"].Value.ToString();
                        BuscaIptu();

                        MessageBox.Show("Parcela não está aberta para alterações", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdIptu.Text = grdIptu.Rows[grdIptu.CurrentRow.Index].Cells["idiptu"].Value.ToString();
                        BuscaIptu();
                    }
                    txtDataVencimento.Focus();
                }
                else
                {
                    MessageBox.Show("Confirmar a Inclusão do parcelamento, antes alterar.", "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void AtualizaGrid(List<Iptu> lstIptu)
        {
            grdIptu.Rows.Clear();
            foreach (Iptu oIptu in lstIptu)
            {
                grdIptu.Rows.Add(oIptu.idIptu, oIptu.imovel.codigoImovel, oIptu.anoBase, oIptu.nroParcela, oIptu.dataVencimento, oIptu.valorParcela, oIptu.situacao, oIptu.situacaoCobranca, "", oIptu.imovel.idImovel, oIptu.observacao);
            }

            //grdIptu.ScrollBars = ScrollBars.Both; 
        }

        public void atualizaSomaGrid()
        {
            Decimal somaParcelas = 0;
            //Double somaValorIndexado = 0;
            foreach (DataGridViewRow row in grdIptu.Rows)
            {
                if (row.Cells["flag"].Value.ToString() != "E")
                {
                    somaParcelas = somaParcelas + EmcResources.cCur(row.Cells["valorparcela"].Value.ToString());
                }
            }
            txtValorTotal.Text = somaParcelas.ToString();
        }      

        #endregion

        #region "Botões de Pesquisa  ***************************************************************************************************"

        private void txtIdIptu_Validating(object sender, CancelEventArgs e)
        {
            BuscaIptu();
        }
        private void txtAnoBaseIptu_Validating(object sender, CancelEventArgs e)
        {
            Iptu oIptu = new Iptu();

            grdIptu.Rows.Clear();
            
        }  
        private void btnImovel_Click(object sender, EventArgs e)
        {
            try
            {
                psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    //txtCodigoImovel.Text = "";
                }
                else
                {
                    txtIdImovel.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtCodigoImovel.Text = EMCImob.retPesquisa.chavebusca.ToString();
                    txtCodigoImovel.Focus();
                    txtCodigoImovel_Validating(null, null);
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtCodigoImovel_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigoImovel.Text))
                {
                    Imovel oImovel = new Imovel();
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = codempresa;

                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa = oEmpresa;

                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                    oImovel = oImovelRN.ObterPor(oImovel);

                    if (oImovel.idImovel > 0)
                    {
                        txtIdImovel.Text = oImovel.idImovel.ToString();
                        txtImovel.Text = oImovel.descricao.ToString();
                        txtAnoBaseImovel.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Imovel não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        #endregion

        #region "[metodos para gerir alteracoes no parcelamento - grdIptu] *************************************************************"
        private void limpaEdicaoParcela()
        {
            txtNroParcela.Enabled = false;
            txtNroParcela.Text = "";
            txtDataVencimento.Text = "";
            txtValorParcela.Text = "";
            txtObservacao.Text = "";
            cboSituacao.SelectedValue = "A";
            cboSituacaoCobranca.SelectedValue = "A";
            btnNovaParcela.Enabled = true;
            btnIncluiParcela.Enabled = false;
            btnAlteraParcelas.Enabled = false;
            btnExcluiParcela.Enabled = false;

        }
        private void btnNovaParcela_Click(object sender, EventArgs e)
        {
            limpaEdicaoParcela();

            txtNroParcela.Enabled = true;

            btnNovaParcela.Enabled = true;
            btnIncluiParcela.Enabled = true;
            btnAlteraParcelas.Enabled = false;
            btnExcluiParcela.Enabled = false;
        }
        
        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "E";

                foreach (DataGridViewRow oRow in grdIptu.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idiptu"].Value.ToString()) == EmcResources.cInt(txtIdIptu.Text))
                    {
                        if (oRow.Cells["situacao"].Value.ToString() == "C")
                        {
                            oRow.Cells["stoperacao"].Value = "R";
                        }
                        else
                            oRow.Cells["stoperacao"].Value = vFlag;
                    }

                    txtDataVencimento.Focus();
                }
                limpaEdicaoParcela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnIncluiParcela_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "I";
                Boolean controle = false;
                if (grdIptu.Rows.Count > 0)
                {
                    foreach (DataGridViewRow oRow in grdIptu.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString()) == EmcResources.cInt(txtNroParcela.Text))
                        {
                            controle = true;
                        }
                    }

                    if (!controle)
                    {
                        grdIptu.Rows.Add(0, txtCodImovel.Text, txtAnoBase.Text, txtNroParcela.Text, txtDataVencimento.Text, txtValorParcela.Text, "A", "A", "I", txtIdImovel2.Text, txtObservacao.Text);
                        limpaEdicaoParcela();
                    }
                    else
                    {
                        MessageBox.Show("Parcela já existe para o ano base", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNroParcela.Focus();
                    }
                }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnAlteraParcelas_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "A";

                foreach (DataGridViewRow oRow in grdIptu.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idiptu"].Value.ToString()) == EmcResources.cInt(txtIdIptu.Text))
                    {
                        oRow.Cells["datavencimento"].Value = txtDataVencimento.Text;
                        oRow.Cells["valorparcela"].Value = txtValorParcela.Value;
                        oRow.Cells["observacao"].Value = txtObservacao.Text;
                        oRow.Cells["stoperacao"].Value = vFlag;
                    }
                }
                limpaEdicaoParcela();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        #endregion

        
        private void calculaParcelamento()
        {
            //Limpa a grid
            grdIptu.Rows.Clear();

            //Atribui valores
            string observacao = "";
            Decimal valorParcela = EmcResources.cCur(txtVlrParcCarne.Value.ToString());
            int nroParcelas = Convert.ToInt32(txtNroParcAno.Text);
            Decimal vlrTotal = EmcResources.cCur(txtValorTotal.Value.ToString());

            //Calcula parcela e diferencas
            Decimal vlrDiferenca = vlrTotal - (valorParcela*nroParcelas);

            //Geração de Parcelas
            int xParc = 1;
            DateTime xDataVenc = Convert.ToDateTime(txt1Vencimento.Text);

            while (xParc <= nroParcelas)
            {
                //ser for a ultima parcela joga a diferença
                if (xParc == nroParcelas)
                {
                    valorParcela = (valorParcela + vlrDiferenca);
                    xDataVenc = xDataVenc.AddDays(30);
                }
                if (xParc != nroParcelas && xParc != 1)
                {
                    xDataVenc = xDataVenc.AddDays(30);
                }

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

                observacao = "IPTU : " + txtAnoBase.Text + " Imovel : " + txtCodImovel.Text + " Parc:" + xParc.ToString();
                grdIptu.Rows.Add(0, txtCodImovel.Text, txtAnoBase.Text, xParc, dataGravar, valorParcela,"A", "A", "I", txtIdImovel2.Text, observacao);
                xParc++;
            }

            //atualizaSomaGrid();
        }

        private void btnListaIptu_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean consulta = true;

                if (String.IsNullOrEmpty(txtCodigoImovel.Text))
                {
                    MessageBox.Show("Preencher o código do imóvel", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigoImovel.Focus();
                    consulta = false;
                }
                if (String.IsNullOrEmpty(txtAnoBaseImovel.Text))
                {
                    MessageBox.Show("Preencher o ano base do IPTU", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtAnoBaseImovel.Focus();
                    consulta = false;
                }

                if (consulta)
                {
                    List<Iptu> lstIptu = new List<Iptu>();
                    IptuRN oIptuRN = new IptuRN(Conexao, objOcorrencia, codempresa);
                    lstIptu = oIptuRN.LstIptu(0, EmcResources.cInt(txtIdImovel.Text), "", txtAnoBaseImovel.Text);

                    AtualizaGrid(lstIptu);

                    grpPesquisa.Enabled = false;
                }

            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodImovel_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodImovel.Text))
                {
                    Imovel oImovel = new Imovel();
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = codempresa;

                    oImovel.codigoImovel = txtCodImovel.Text;
                    oImovel.empresa = oEmpresa;

                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                    oImovel = oImovelRN.ObterPor(oImovel);

                    if (oImovel.idImovel > 0)
                    {
                        txtIdImovel2.Text = oImovel.idImovel.ToString();
                        txtDescricaoImovel.Text = oImovel.descricao.ToString();
                        txtAnoBase.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Imovel não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnImovel2_Click(object sender, EventArgs e)
        {
            try
            {
                psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    //txtCodigoImovel.Text = "";
                }
                else
                {
                    txtIdImovel2.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtCodImovel.Text = EMCImob.retPesquisa.chavebusca.ToString();
                    txtCodImovel_Validating(null, null);
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAnoBase_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                List<Iptu> lstIptu = new List<Iptu>();
                IptuRN oIptuRN = new IptuRN(Conexao, objOcorrencia, codempresa);
                lstIptu = oIptuRN.LstIptu(0, EmcResources.cInt(txtIdImovel.Text), "", txtAnoBaseImovel.Text);

                AtualizaGrid(lstIptu);

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
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
                        txtCPFCNPJFornecedor.Text = oFornecedor.pessoa.cnpjCpf;
                        txtFornecedor.Text = oFornecedor.pessoa.nome;

                        if (txtCPFCNPJFornecedor.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJFornecedor.Mask = "000.000.000-00";
                            lblCNPJFornecedor.Text = "CPF";
                        }
                        else if (txtCPFCNPJFornecedor.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJFornecedor.Mask = "00.000.000/0000-00";
                            lblCNPJFornecedor.Text = "CNPJ";
                        }

                        btnGerarParcela.Focus();
                    }

                }
                else
                {
                    txtCPFCNPJFornecedor.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdFornecedor.Text = "";
            else
                txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdFornecedor_Validating(null, null);
        }

        private void txtCPFCNPJFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJFornecedor.Text))
                {
                    txtIdFornecedor.ReadOnly = false;
                    txtIdFornecedor.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJFornecedor.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJFornecedor.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJFornecedor.Mask = "000.000.000-00";
                        lblCNPJFornecedor.Text = "CPF";
                        txtCPFCNPJFornecedor.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJFornecedor.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJFornecedor.Mask = "00.000.000/0000-00";
                        lblCNPJFornecedor.Text = "CNPJ";
                        txtCPFCNPJFornecedor.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCNPJFornecedor.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJFornecedor.Text.Trim().Length > 0)
                    {
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCPFCNPJFornecedor.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdFornecedor.ReadOnly = false;
                            txtIdFornecedor.Focus();
                        }
                        else
                        {
                            txtIdFornecedor.Text = oFornecedor.idPessoa.ToString();
                            txtFornecedor.Text = oFornecedor.pessoa.nome;
                            txtIdFornecedor.ReadOnly = true;
                            btnGerarParcela.Focus();
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

        private void txtCPFCNPJFornecedor_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJFornecedor.Mask = "";
            lblCNPJFornecedor.Text = "CNPJ/CPF";
            txtCPFCNPJFornecedor.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
        }

        private void btnGerarParcela_Click_1(object sender, EventArgs e)
        {
            //verifica as informações necessárias
            if (EmcResources.cCur(txtValorTotal.Value.ToString()) == 0)
                MessageBox.Show("Valor do IPTU deve ser informado!");
            else if (EmcResources.cInt(txtNroParcAno.Text) == 0)
                MessageBox.Show("Número de Parcelas deve ser informado!");
            else
            {
                calculaParcelamento();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void maskedNumber1_TextChanged(object sender, EventArgs e)
        {

        }

        public void ocultaAbas()
        {
            tabIptu.Controls.Remove(tabManutencao);

        }

        public void mostraAbas()
        {
            if (tabIptu.TabCount <= 1)
            {
                tabIptu.Controls.Add(tabManutencao);
            }

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void txtNroParcelas_TextChanged(object sender, EventArgs e)
        {

        }



       
    }
}
