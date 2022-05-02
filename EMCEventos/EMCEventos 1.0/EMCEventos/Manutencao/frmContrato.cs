using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCSecurityRN;
using EMCSecurity;
using EMCCadastro;
using System.Collections;

namespace EMCEventos
{
    public partial class frmContrato : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmContrato";
        private const string nomeAplicativo = "EMCEventos";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmContrato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmContrato()
        {
            InitializeComponent();
        }

        private void frmContrato_Activated(object sender, EventArgs e)
        {

        }
        private void frmContrato_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "evt_contrato";

           

            AtualizaGrid();
            this.ActiveControl = txtIdContrato;
            CancelaOperacao();
        }
        #endregion
         
        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaContrato(Contrato oContrato)
        {
            ContratoRN oContratoRN = new ContratoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oContratoRN.VerificaDados(oContrato);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Evento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Contrato montaContrato()
        {
            Contrato oContrato = new Contrato();                     

            oContrato.idContrato = EmcResources.cInt(txtIdContrato.Text);
            oContrato.dataContrato = Convert.ToDateTime(txtDataContrato.Text);
            oContrato.valorContrato = EmcResources.cCur(txtValorContrato.Value.ToString());
            oContrato.nroParcelas = EmcResources.cInt(txtNroParcelas.Text);
            
            SubLocacao oSubLoc = new SubLocacao();
            SubLocacaoRN oSubLocRN = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);    
            oSubLoc.idSublocacao = EmcResources.cInt(txtIdSubLocacao.Text);
            oSubLoc.descricao = txtDescSubLocacao.Text;
            oSubLoc = oSubLocRN.ObterPor(oSubLoc);
            oContrato.subLocacao = oSubLoc;

            Cliente oCliente = new Cliente();
            ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);
            oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
            oCliente.codEmpresa = empMaster;
            oCliente = oClienteRN.ObterPor(oCliente);
            oContrato.cliente = oCliente;
            
            Fornecedor oFornecedor = new Fornecedor();
            FornecedorRN ofornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
            oFornecedor.idPessoa = EmcResources.cInt(cboFornecedor.SelectedValue.ToString());
            oFornecedor.codEmpresa = empMaster;
            oFornecedor = ofornecedorRN.ObterPor(oFornecedor);
            oContrato.fornecedor = oFornecedor;

            oContrato.geraContasPagar = cboGeraContasPagar.SelectedValue.ToString();
            oContrato.geraTaxaAdministracao = cboGeraTxAdm.SelectedValue.ToString();
            oContrato.percenturalAdministracao = EmcResources.cCur(txtPercenturalAdm.Value.ToString());
            oContrato.valorAdministracao = EmcResources.cCur(txtValorAdministracao.Value.ToString());
            oContrato.dataAprovacao = Convert.ToDateTime(txtDataAprovacao.Text);
          
            Usuario oUsuario = new Usuario();
            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
            oUsuario.idUsuario = EmcResources.cInt(usuario.ToString());
            oUsuario = oUsuarioRN.ObterPor(oUsuario);
            oContrato.usuario = oUsuario;


            List<ContratoParcela> lstContratoParcela = new List<ContratoParcela>();
            foreach (DataGridViewRow oRow in grdParcelas.Rows)
            {

                ContratoParcela oContParc = new ContratoParcela();

                oContParc.flag = oRow.Cells["flag"].Value.ToString();
                               
                oContParc.idContratoParcela = EmcResources.cInt(oRow.Cells["idevt_contratoparcela"].Value.ToString());

                Contrato obContrato = new Contrato();
                obContrato.idContrato = EmcResources.cInt(oRow.Cells["idevt_contr"].Value.ToString());
                oContParc.contrato = obContrato;

                oContParc.nroParcela = EmcResources.cInt(oRow.Cells["nroparcela"].Value.ToString());
                oContParc.dataVencimento = Convert.ToDateTime(oRow.Cells["datavencimento"].Value.ToString());
                oContParc.valorParcela = EmcResources.cCur(oRow.Cells["valorparcela"].Value.ToString());     
                oContParc.situacao = oRow.Cells["situacaoparcela"].Value.ToString();

                lstContratoParcela.Add(oContParc);
            }
            oContrato.lstContratoParcela = lstContratoParcela;
                        

            return oContrato;
        }

        private void montaTela(Contrato oContrato)
        {
            ContratoParcela oContParcela = new ContratoParcela();

            txtIdContrato.Text = oContrato.idContrato.ToString();

            txtDataContrato.Text = oContrato.dataContrato.ToString();
            txtValorContrato.Text = oContrato.valorContrato.ToString();
            txtNroParcelas.Text = oContrato.nroParcelas.ToString();

            txtIdSubLocacao.Text = oContrato.subLocacao.idSublocacao.ToString();
            txtDescSubLocacao.Text = oContrato.subLocacao.descricao;

            txtIdCliente.Text = oContrato.cliente.idPessoa.ToString();
            txtIdCliente_Validating(null, null);

            //txtIdPessoa.Text = oContrato.fornecedor.idPessoa.ToString();
            //txtIdPessoa_Validating(null, null);
                       
            cboFornecedor.SelectedValue = oContrato.fornecedor.idPessoa.ToString();

            cboGeraContasPagar.SelectedValue = oContrato.geraContasPagar;
            cboGeraTxAdm.SelectedValue = oContrato.geraTaxaAdministracao;
            txtPercenturalAdm.Text = oContrato.percenturalAdministracao.ToString();
            txtValorAdministracao.Text = oContrato.valorAdministracao.ToString();
            txtDataAprovacao.Text = oContrato.dataAprovacao.ToString();

            lblSituacao.Text = "";

            if (oContrato.situacao == "A")
            {
                lblSituacao.Text = "Aberto";
            }
            else if (oContrato.situacao == "C")
            {
                lblSituacao.Text = "Cancelado";
            }

            AtualizaGridParcela(oContrato);

            txtIdContrato.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oContrato.idContrato.ToString();
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
            txtIdContrato.Enabled = false;
            txtDataContrato.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdContrato.Enabled = false;
            txtDataContrato.Focus();
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
            lblSituacao.Text = "";
            lblSituacaoParcelas.Text = "";
            txtIdContrato.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtIdContrato.Focus();

            grdParcelas.Rows.Clear();

        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            try
            {
                psqContrato ofrm = new psqContrato(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    // txtIdIptu.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdContrato.Enabled = true;
                    txtIdContrato.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    //txtIdContrato.Text = EMCEventos.retPesquisa.chavebusca.ToString();

                    //txtCodigoImovel.Focus();
                    txtIdContrato.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaContrato()
        {
            if (!String.IsNullOrEmpty(txtIdContrato.Text))
            {

                Contrato oContrato = new Contrato();
                try
                {
                    ContratoRN ContratoBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);
                                        
                    oContrato.idContrato = Convert.ToInt32(txtIdContrato.Text);                   

                    oContrato = ContratoBLL.ObterPor(oContrato);

                    if (oContrato.idContrato == 0)
                    {
                        DialogResult result = MessageBox.Show("Contrato não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oContrato);
                        AtivaEdicao();
                        txtIdContrato.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Contrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdContrato.Focus();


            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Sim", "S"));
            arr.Add(new popCombo("Não", "N"));
            cboGeraContasPagar.DataSource = arr;
            cboGeraContasPagar.DisplayMember = "nome";
            cboGeraContasPagar.ValueMember = "valor";

            ArrayList arrAdm = new ArrayList();
            arrAdm.Add(new popCombo("Sim", "S"));
            arrAdm.Add(new popCombo("Não", "N"));
            cboGeraTxAdm.DataSource = arrAdm;
            cboGeraTxAdm.DisplayMember = "nome";
            cboGeraTxAdm.ValueMember = "valor";
                        

            Fornecedor oFornecedor = new Fornecedor();
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
            oFornecedor.codEmpresa = codempresa;
            cboFornecedor.DataSource = oFornecedorRN.ListaFornecedor(oFornecedor);
            cboFornecedor.ValueMember = "idpessoa";
            cboFornecedor.DisplayMember = "nome";

            cboFornecedor.SelectedIndex = -1;           

        }

        public override void SalvaObjeto()
        {
            try
            {
                Contrato oContrato = new Contrato();
                ContratoRN oContratoBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);

                lblSituacao.Text = "A";
                oContrato = montaContrato();
                oContrato.situacao = "A";

                oContratoBLL.Salvar(oContrato);
                AtualizaGrid();
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
                Contrato oContrato = new Contrato();
                ContratoRN oContratoBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);
                
                oContrato = montaContrato();
                oContrato.situacao = "A";

                oContratoBLL.Atualizar(oContrato);
                AtualizaGrid();
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
                Contrato oContrato = new Contrato();
                ContratoRN oContratoBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);
                lblSituacao.Text = "";
                oContrato = montaContrato();
                oContrato.situacao = "C";

                oContratoBLL.Excluir(oContrato);
                AtualizaGrid();
                CancelaOperacao();
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
                Relatorios.relContrato ofrm = new Relatorios.relContrato(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid Evento ***********************************************************************************************"

        private void grdContrato_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIdContrato.Text = grdContrato.Rows[grdContrato.CurrentRow.Index].Cells["idevt_contrato"].Value.ToString();
                BuscaContrato();                
                txtIdContrato.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void AtualizaGrid()
        {
            ContratoRN objContratoRN = new ContratoRN(Conexao, objOcorrencia, codempresa);
            grdContrato.DataSource = objContratoRN.ListaContrato();
            txtDataContrato.Focus();            

        }

        #endregion

        #region "Botões de Pesquisa  ****************************************************************************************************"

        private void txtIdContrato_Validating(object sender, CancelEventArgs e)
        {
            BuscaContrato();
        }

        private void btnSubLocacao_Click(object sender, EventArgs e)
        {
            try
            {
                psqSubLocacao ofrm = new psqSubLocacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    txtIdSubLocacao.Text = "";
                }
                else
                {
                    txtIdSubLocacao.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtIdSubLocacao.Focus();
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdSubLocacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //SubLocacao objSubLocacao = new SubLocacao();

                if (!String.IsNullOrEmpty(txtIdSubLocacao.Text))
                {
                    SubLocacao oSubLocacao = new SubLocacao();
                    SubLocacaoRN oSubLocRN = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);

                    oSubLocacao.idSublocacao = EmcResources.cInt(txtIdSubLocacao.Text);
                    oSubLocacao = oSubLocRN.ObterPor(oSubLocacao);

                    if (oSubLocacao.idSublocacao == 0)
                    {
                        MessageBox.Show("Sub Locação não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdSubLocacao.Text = "";
                        btnSubLocacao.Focus();
                    }
                    else
                    {
                        txtDescSubLocacao.Text = oSubLocacao.descricao;
                        cboFornecedor.SelectedValue = oSubLocacao.evento.imovel.fornecedor.idPessoa;
                        txtDescSubLocacao.Focus();
                        //AtualizaGrid();
                    }
                }
                else
                {
                    btnSubLocacao.Focus();
                }
                //AtualizaGrid(objIptu);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

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
                    txtRazaoSocial.Text = oCliente.pessoa.nome;

                    txtRazaoSocial.Focus();
                }

            }
            else
            {
                btnCliente.Focus();
            }
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
                txtRazaoSocial.Focus();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void btnFornecedor_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
        //        ofrm.ShowDialog();

        //        if (EMCCadastro.retPesquisa.chaveinterna == 0)
        //            txtIdPessoa.Text = "";
        //        else
        //            txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

        //        txtIdPessoa.Focus();
        //        SendKeys.Send("{TAB}");
        //    }
        //    catch (Exception oErro)
        //    {
        //        MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        //private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        //{
        //    try
        //    {
        //        if (!String.IsNullOrEmpty(txtIdPessoa.Text))
        //        {
        //            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
        //            Fornecedor oFornecedor = new Fornecedor();

        //            oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
        //            oFornecedor.codEmpresa = empMaster;

        //            oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

        //            if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
        //            {
        //                MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                txtIdPessoa.Text = "";
        //                btnFornecedor.Focus();
        //            }
        //            else
        //            {
        //                txtPessoa.Text = oFornecedor.pessoa.nome;
        //                txtPessoa.Focus();
        //            }
        //        }
        //        else
        //        {
        //            btnFornecedor.Focus();
        //        }
        //    }
        //    catch (Exception erro)
        //    {
        //        MessageBox.Show("Erro Pesquisa : " + erro.Message);
        //    }
        //}

        #endregion 

        private void grdParcelas_DoubleClick(object sender, EventArgs e)
        {
            txtIdContratoParcela.Text = grdParcelas.Rows[grdParcelas.CurrentRow.Index].Cells["idevt_contratoparcela"].Value.ToString();
            txtNroParcelasContParc.Text = grdParcelas.Rows[grdParcelas.CurrentRow.Index].Cells["nroparcela"].Value.ToString();
            txtDataVencimento.Text = grdParcelas.Rows[grdParcelas.CurrentRow.Index].Cells["datavencimento"].Value.ToString();
            txtValorParcela.Text = grdParcelas.Rows[grdParcelas.CurrentRow.Index].Cells["valorparcela"].Value.ToString();
            //txtIdPessoa_Validating(null, null);

            btnIncluiParcela.Enabled = false;
        }      

        private void AtualizaGridParcela(Contrato oContrato)
        {
            //carrega a grid com as Locações cadastrados
            List<ContratoParcela> lstContratoParc = new List<ContratoParcela>();
            ContratoParcelaRN objContratoParc = new ContratoParcelaRN(Conexao, objOcorrencia, codempresa);

            grdParcelas.Rows.Clear();

            lstContratoParc = objContratoParc.ListaContratoParcela(EmcResources.cInt(txtIdContrato.Text));

            foreach (ContratoParcela obContratoParc in lstContratoParc)
            {
                string flag = "";
                if (!String.IsNullOrEmpty(obContratoParc.flag))
                    flag = obContratoParc.flag;

                grdParcelas.Rows.Add(obContratoParc.idContratoParcela, obContratoParc.contrato.idContrato, obContratoParc.nroParcela, obContratoParc.dataVencimento, 
                                     obContratoParc.valorParcela, obContratoParc.situacao, flag);
            }

            //grdIptu.ScrollBars = ScrollBars.Both; 
        }        

        #region "[metodos para gerir alteracoes no parcelamento - grdIptu] *************************************************************"
        private void btnExcluiParcela_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "E";

                foreach (DataGridViewRow oRow in grdParcelas.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idevt_contratoparcela"].Value.ToString()) == EmcResources.cInt(txtIdContratoParcela.Text))
                    {
                        oRow.Cells["flag"].Value = vFlag;
                        //atualizaSomaGrid();
                    }

                    txtNroParcelasContParc.Text = "";
                    txtValorParcela.Text = "";
                    txtDataVencimento.Text = "";

                    txtNroParcelasContParc.Focus();
                }
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

                if (grdParcelas.Rows.Count > 0)
                {      

                    if (vFlag == "I")
                    {
                        grdParcelas.Rows.Add("", "", txtNroParcelasContParc.Text, txtDataVencimento.Text, txtValorParcela.Value, "", vFlag);
                    }
                    atualizaSomaGrid();

                    txtNroParcelasContParc.Text = "";
                    txtValorParcela.Text = "";
                    txtDataVencimento.Text = "";

                    txtNroParcelasContParc.Focus();
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

                foreach (DataGridViewRow oRow in grdParcelas.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idevt_contratoparcela"].Value.ToString()) == EmcResources.cInt(txtIdContratoParcela.Text))
                    {
                        oRow.Cells["datavencimento"].Value = txtDataVencimento.Text;
                        oRow.Cells["valorparcela"].Value = txtValorParcela.Value;
                        oRow.Cells["nroparcela"].Value = txtNroParcelasContParc.Text;
                        oRow.Cells["flag"].Value = vFlag;
                    }
                }

                txtNroParcelasContParc.Text = "";
                txtValorParcela.Text = "";
                txtDataVencimento.Text = "";
                btnIncluiParcela.Enabled = true;

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }
        private void btnLimpaParcela_Click(object sender, EventArgs e)
        {
            txtNroParcelasContParc.Text = "";
            txtValorParcela.Text = "";
            txtDataVencimento.Text = "";

            btnIncluiParcela.Enabled = true; ;
            txtNroParcelasContParc.Focus();
        }
       

        #endregion


        private void btnGerarParcela_Click(object sender, EventArgs e)
        {
            //verifica as informações necessárias
            if (EmcResources.cCur(txtValorParcela.Value.ToString()) == 0)
                MessageBox.Show("Valor da Parcela deve ser informado!");
            else if (EmcResources.cInt(txtNroParcelasContParc.Text) == 0)
                MessageBox.Show("Número de Parcelas deve ser informado!");
            else
            {
                calculaParcelamento();
            }
        }
        private void calculaParcelamento()
        {
            if(EmcResources.cInt(txtNroParcelas.Text) == EmcResources.cInt(txtNroParcelasContParc.Text))
            {         


            //Limpa a grid
            grdParcelas.Rows.Clear();

            //Atribui valores
            Decimal valorParcela = EmcResources.cCur(txtValorParcela.Value.ToString());
            int nroParcelas = Convert.ToInt32(txtNroParcelasContParc.Text);
            Decimal vlrTotal = EmcResources.cCur(txtValorContrato.Value.ToString());

            //Calcula parcela e diferencas
            Decimal valorTotal = Decimal.Round((valorParcela * nroParcelas), 2);
            Decimal vlrDiferenca = vlrTotal - (valorTotal);

            //Geração de Parcelas
            int xParc = 1;
            DateTime xDataVenc = Convert.ToDateTime(txtDataVencimento.Text);

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

                    //ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                    ////verifica o parametro considera data valida para vencimento de parcelas.
                    //if (oParametroRN.retParametro(codempresa, "EMCIMOB", "IPTU", "VENCIMENTO_DIA_UTIL") == "S")
                    //{
                    //    // colocar if de acordo com parametro
                    //    FeriadoRN oFeriadoRN = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                    //    dataGravar = oFeriadoRN.diaUtil(dataGravar);
                    //}

                    dtDiafixo = diaFixo + "/" + xDataVenc.Month.ToString() + "/" + xDataVenc.Year.ToString();

                    dataGravar = Convert.ToDateTime(dtDiafixo);
                }


                grdParcelas.Rows.Add("", "", xParc, dataGravar, valorParcela, "A", "I");
                xParc++;
            }

            atualizaSomaGrid();
            }
            else
            {
                MessageBox.Show("Nro. de Parcelas não confere", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNroParcelasContParc.Focus();
            }
        }

        public void atualizaSomaGrid()
        {
            Decimal somaParcelas = 0;
            //Double somaValorIndexado = 0;
            foreach (DataGridViewRow row in grdParcelas.Rows)
            {
                if (row.Cells["flag"].Value.ToString() != "E")
                {
                    somaParcelas = somaParcelas + EmcResources.cCur(row.Cells["valorparcela"].Value.ToString());
                }
            }

            if(somaParcelas != EmcResources.cCur(txtValorContrato.Value.ToString()))
            {
                MessageBox.Show("Valor do contrato não confere", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CancelaOperacao();
            }
            else
            {
                txtValorContrato.Text = somaParcelas.ToString();
            }
            
        }

        
       
    }
}
