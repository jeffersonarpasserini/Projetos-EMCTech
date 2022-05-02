using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurity;
using EMCCadastro;
using EMCCadastroRN;
using EMCCadastroModel;
using System.Collections;
using EMCSecurityRN;
using EMCIntegracaoModel;
using EMCIntegracaoRN;

namespace EMCImob
{
    public partial class frmIntegFinanceiro : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmIntegFinanceiro";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        #region "metodos do form"

        public frmIntegFinanceiro(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmIntegFinanceiro()
        {
            InitializeComponent();
        }

        private void frmIntegFinanceiro_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "IntegFinanceiro";

            
            this.ActiveControl = txtDataInicial;
            AtivaInsercao();
        }

        #endregion

        #region "metodos para tratamento das informacoes"

        private Boolean verificaIntegFinanceiro(IntegFinanceiro oInteg)
        {
            LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                //oContratoRN.VerificaDados(oContrato);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro LocacaoContrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private IntegFinanceiro montaIntegracao()
        {
            IntegFinanceiro oIntegra = new IntegFinanceiro();
            try
            {
              
                
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            return oIntegra;
        }

        private void montaTela()
        {
            AtivaEdicao();

            objOcorrencia.chaveidentificacao = "";
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

        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            objOcorrencia.chaveidentificacao = "";
            carregaConfiguracoes();
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

        public void carregaConfiguracoes()
        {

            /* monta combos */
    

        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();

            carregaConfiguracoes();

            limpaGrids();

            objOcorrencia.chaveidentificacao = "";

        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                //psqLocacaoContrato ofrm = new psqLocacaoContrato(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                //ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {


                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaContrato()
        {
            if (!String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
            {

                LocacaoContrato oContrato = new LocacaoContrato();
                try
                {

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro LocacaoContrato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();



            limpaGrids();


            objOcorrencia.chaveidentificacao = "";
            txtIdentificacaoContrato.Focus();

        }

        public void limpaAbaLocacaoReceber()
        {

        }

        public void limpaAbaLocacaoPagar()
        {

        }

        public void limpaAbaIptu()
        {

        }

        public void limpaAbaDespesaImovel()
        {

        }

        public void limpaAbaCaptacao()
        {


        }

        public override void SalvaObjeto()
        {
            try
            {
                //LocacaoContrato oContrato = new LocacaoContrato();
                //LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                //oContrato = montaIntegracao();
                //oContrato.statusOperacao = "I";

                //oContratoRN.Salvar(oContrato);

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
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void ocultaAbas()
        {
            //tabContrato.Controls.Remove(tabFiador);

        }

        public void mostraAbas()
        {
            //tabContrato.Controls.Add(tabFiador);
        }

        #endregion

        #region Carregamento de Informações nas grids
        private void limpaGrids()
        {
            //grdCCReceber.Rows.Clear();

        }

        private void montaGridLocacaoReceber(List<LocacaoCliente> lstCliente)
        {
            try
            {
                foreach (LocacaoCliente oCliente in lstCliente)
                {


                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridLocacaoPagar(List<LocacaoFornecedor> lstFornecedor)
        {
            try
            {
                foreach (LocacaoFornecedor oProprietario in lstFornecedor)
                {

                   

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridIptu(List<LocacaoFiador> lstFiador)
        {
            try
            {
                foreach (LocacaoFiador oFiador in lstFiador)
                {


                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }

        }

        private void montaGridDespesaImovel(List<LocacaoReceber> lstReceber)
        {
            try
            {
                foreach (LocacaoReceber oParcela in lstReceber)
                {

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void montagridCaptacao(List<LocacaoCCReceber> lstCCReceber)
        {
            try
            {
                foreach (LocacaoCCReceber oCta in lstCCReceber)
                {

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        #endregion

        #region Tratamento de Campos - Formulario Geral
        private void txtDataInicial_Validating(object sender, CancelEventArgs e)
        {
            if (txtDataInicial.DateValue >= txtDataFinal.DateValue)
            {
                MessageBox.Show("Período do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataInicial.Focus();
            }
        }

        private void txtDataFinal_Validating(object sender, CancelEventArgs e)
        {
            if (txtDataInicial.DateValue >= txtDataFinal.DateValue)
            {
                MessageBox.Show("Período do contrato, invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDataInicial.Focus();
            }
            txtIdentificacaoContrato.Focus();

        }

        private void txtIdentificacaoContrato_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
                {
                    LocacaoContratoRN oContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                    LocacaoContrato oContrato = new LocacaoContrato();
                    oContrato.idEmpresa = codempresa;
                    oContrato.identificacaoContrato = txtIdentificacaoContrato.Text;

                    oContrato = oContratoRN.ObterPor(oContrato);

                    if (oContrato.valorTotalContrato > 0)
                    {
                        txtIdContrato.Text = oContrato.idLocacaoContrato.ToString();
                        txtCodigoImovel.Text = oContrato.imovel.codigoImovel.ToString();
                        txtCodigoImovel_Validating(null, null);
                    }
                    else
                    {
                        AtivaInsercao();
                    }
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtCodigoImovel_Validating(object sender, CancelEventArgs e)
        {
            try
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
                    txtCidade.Text = oImovel.cidade;
                    txtEstado.Text = oImovel.estado;
                    txtEndereco.Text = oImovel.rua;
                    txtNumero.Text = oImovel.numero;
                }
                else
                {
                    MessageBox.Show("Imovel não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void btnBuscaImovel_Click(object sender, EventArgs e)
        {
            psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (retPesquisa.chaveinterna == 0)
            {
                txtIdImovel.Text = "";
                txtCodigoImovel.Text = "";
            }
            else
            {
                txtIdImovel.Text = retPesquisa.chaveinterna.ToString();
                txtCodigoImovel.Text = retPesquisa.chavebusca.ToString();
            }

            txtCodigoImovel_Validating(null, null);
        }

        #endregion

        #region "Tratamento de Campos - Tab - Aba de Parcela a Receber"
        
        private void txtIdLocatarioReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocatarioReceber.Text))
                {
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                    Cliente oCliente = new Cliente();

                    oCliente.idPessoa = EmcResources.cInt(txtIdLocatarioReceber.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocatarioReceber.Text = oCliente.idPessoa.ToString();
                        txtCPFCNPJReceber.Text = oCliente.pessoa.cnpjCpf;
                        txtNomeLocatarioReceber.Text = oCliente.pessoa.nome;

                        if (txtCPFCNPJReceber.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJReceber.Mask = "000.000.000-00";
                            lblCnpjReceber.Text = "CPF";
                        }
                        else if (txtCPFCNPJReceber.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJReceber.Mask = "00.000.000/0000-00";
                            lblCnpjReceber.Text = "CNPJ";
                        }
                    }

                }
                else
                {
                    txtCPFCNPJReceber.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtCPFCNPJReceber_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJReceber.Text))
                {
                    txtIdLocatarioReceber.ReadOnly = false;
                    txtIdLocatarioReceber.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJReceber.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJReceber.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJReceber.Mask = "000.000.000-00";
                        lblCnpjReceber.Text = "CPF";
                        txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJReceber.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJReceber.Mask = "00.000.000/0000-00";
                        lblCnpjReceber.Text = "CNPJ";
                        txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjReceber.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJReceber.Text.Trim().Length > 0)
                    {
                        ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                        Cliente oCliente = new Cliente();

                        oCliente = oClienteRN.ObterPor(empMaster, txtCPFCNPJReceber.Text.Trim());

                        if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocatarioReceber.ReadOnly = false;
                            txtIdLocatarioReceber.Focus();
                        }
                        else
                        {
                            txtIdLocatarioReceber.Text = oCliente.idPessoa.ToString();
                            txtNomeLocatarioReceber.Text = oCliente.pessoa.nome;
                            txtIdLocatarioReceber.ReadOnly = true;

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

        private void txtCPFCNPJReceber_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJReceber.Mask = "";
            lblCnpjReceber.Text = "CNPJ/CPF";
            txtCPFCNPJReceber.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;


        }

        private void btnLocatarioReceber_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocatarioReceber.Text = "";
                else
                    txtIdLocatarioReceber.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocatarioReceber_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnPsqLocacaoReceber_Click(object sender, EventArgs e)
        {
            try
            {
                List<LocacaoReceber> lstLocacaoReceber = new List<LocacaoReceber>();
                LocacaoReceberRN oReceberDAO = new LocacaoReceberRN(Conexao, objOcorrencia, codempresa);
                lstLocacaoReceber =  oReceberDAO.lstLocacaoReceber(txtDataInicial.DateValue, 
                                              txtDataFinal.DateValue, 
                                              txtIdentificacaoContrato.Text, 
                                              EmcResources.cInt(txtNroParcelaReceber.Text), 
                                              EmcResources.cInt(txtIdImovel.Text), 
                                              empMaster, 
                                              EmcResources.cInt(txtIdLocatarioReceber.Text));

                montaGridReceber(lstLocacaoReceber);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        public void montaGridReceber(List<LocacaoReceber> lstLocacaoReceber)
        {
            try
            {
                grdLocacaoReceber.Rows.Clear();

                foreach(LocacaoReceber oReceber in lstLocacaoReceber)
                {
                    grdLocacaoReceber.Rows.Add(oReceber.locatario.pessoa.nome,
                                               oReceber.locatario.pessoa.idPessoa,
                                               oReceber.contrato.identificacaoContrato,
                                               oReceber.nroParcela,
                                               oReceber.dataVencimento,
                                               oReceber.valorParcela,
                                               oReceber.periodoInicio,
                                               oReceber.periodoFim,
                                               oReceber.situacao,
                                               "",
                                               oReceber.contrato.idLocacaoContrato,
                                               oReceber.idLocacaoReceber);

                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIntegraReceber_Click(object sender, EventArgs e)
        {
            try
            {
                List<LocacaoReceber> lstReceber = new List<LocacaoReceber>();
                LocacaoReceberRN oReceberRN = new LocacaoReceberRN(Conexao, objOcorrencia, codempresa);

                foreach (DataGridViewRow oRecRow in grdLocacaoReceber.Rows)
                {
                    LocacaoReceber oReceber = new LocacaoReceber();
                    oReceber.idLocacaoReceber = EmcResources.cInt(oRecRow.Cells["idlocacaoreceber"].Value.ToString());
                    oReceber = oReceberRN.ObterPor(oReceber);

                    lstReceber.Add(oReceber);
                }   
                    
                IntegracaoRN oIntegRN = new IntegracaoRN(Conexao, objOcorrencia, codempresa);
                oIntegRN.integraLocacaoReceber(lstReceber, EmcResources.cInt(usuario));

                grdLocacaoReceber.Rows.Clear();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        #endregion

        #region "Tratamento de Campos - Tab - Aba de Parcela a Pagar"
        
        private void txtIdLocadorPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocadorPagar.Text))
                {
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    Fornecedor oFornecedor = new Fornecedor();

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdLocadorPagar.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocadorPagar.Text = oFornecedor.idPessoa.ToString();
                        txtCPFCNPJPagar.Text = oFornecedor.pessoa.cnpjCpf;
                        txtNomeLocadorPagar.Text = oFornecedor.pessoa.nome;

                        if (txtCPFCNPJPagar.Text.Trim().Length == 11)
                        {
                            txtCPFCNPJPagar.Mask = "000.000.000-00";
                            lblCnpjPagar.Text = "CPF";
                        }
                        else if (txtCPFCNPJPagar.Text.Trim().Length == 14)
                        {
                            txtCPFCNPJPagar.Mask = "00.000.000/0000-00";
                            lblCnpjPagar.Text = "CNPJ";
                        }
                    }

                }
                else
                {
                    txtCPFCNPJPagar.Focus();
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
            }
        }

        private void txtCPFCNPJPagar_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCPFCNPJPagar.Text))
                {
                    txtIdLocadorPagar.ReadOnly = false;
                    txtIdLocadorPagar.Focus();
                }
                else if (!EmcResources.validaCNPJCPF(txtCPFCNPJPagar.Text))
                {
                    MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (txtCPFCNPJPagar.Text.Trim().Length == 11)
                    {
                        txtCPFCNPJPagar.Mask = "000.000.000-00";
                        lblCnpjPagar.Text = "CPF";
                        txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else if (txtCPFCNPJPagar.Text.Trim().Length == 14)
                    {
                        txtCPFCNPJPagar.Mask = "00.000.000/0000-00";
                        lblCnpjPagar.Text = "CNPJ";
                        txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                    }
                    else
                    {
                        //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblCnpjPagar.Text = "CNPJ/CPF";
                    }

                    if (txtCPFCNPJPagar.Text.Trim().Length > 0)
                    {
                        FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                        Fornecedor oFornecedor = new Fornecedor();

                        oFornecedor = oFornecedorRN.ObterPor(empMaster, txtCPFCNPJReceber.Text.Trim());

                        if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                        {
                            MessageBox.Show("CNPJ/CPF não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtIdLocadorPagar.ReadOnly = false;
                            txtIdLocadorPagar.Focus();
                        }
                        else
                        {
                            txtIdLocadorPagar.Text = oFornecedor.idPessoa.ToString();
                            txtNomeLocadorPagar.Text = oFornecedor.pessoa.nome;
                            txtIdLocadorPagar.ReadOnly = true;

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

        private void txtCPFCNPJPagar_Enter(object sender, EventArgs e)
        {
            txtCPFCNPJPagar.Mask = "";
            lblCnpjPagar.Text = "CNPJ/CPF";
            txtCPFCNPJPagar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;


        }

        private void btnLocadorPagar_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocadorPagar.Text = "";
                else
                    txtIdLocadorPagar.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocadorPagar_Validating(null, null);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnPsqLocacaoPagar_Click(object sender, EventArgs e)
        {
            try
            {
                List<LocacaoPagar> lstLocacaoPagar = new List<LocacaoPagar>();
                LocacaoPagarRN oReceberDAO = new LocacaoPagarRN(Conexao, objOcorrencia, codempresa);
                lstLocacaoPagar = oReceberDAO.lstLocacaoPagar(txtDataInicial.DateValue,
                                              txtDataFinal.DateValue,
                                              txtIdentificacaoContrato.Text,
                                              EmcResources.cInt(txtNroParcelaReceber.Text),
                                              EmcResources.cInt(txtIdImovel.Text),
                                              empMaster,
                                              EmcResources.cInt(txtIdLocadorPagar.Text));

                montaGridPagar(lstLocacaoPagar);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        public void montaGridPagar(List<LocacaoPagar> lstLocacaoPagar)
        {
            try
            {
                grdLocacaoPagar.Rows.Clear();

                foreach (LocacaoPagar oPagar in lstLocacaoPagar)
                {
                    grdLocacaoPagar.Rows.Add(oPagar.locador.pessoa.nome,
                                               oPagar.locador.pessoa.idPessoa,
                                               oPagar.contrato.identificacaoContrato,
                                               oPagar.nroParcela,
                                               oPagar.dataVencimento,
                                               oPagar.valorParcela,
                                               oPagar.periodoInicio,
                                               oPagar.periodoFim,
                                               oPagar.situacao,
                                               "",
                                               oPagar.contrato.idLocacaoContrato,
                                               oPagar.idLocacaoPagar);

                }


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        private void btnIntegraPagar_Click(object sender, EventArgs e)
        {
            try
            {
                List<LocacaoPagar> lstPagar = new List<LocacaoPagar>();
                LocacaoPagarRN oPagarRN = new LocacaoPagarRN(Conexao, objOcorrencia, codempresa);

                foreach (DataGridViewRow oPgRow in grdLocacaoPagar.Rows)
                {
                    LocacaoPagar oPagar = new LocacaoPagar();
                    oPagar.idLocacaoPagar = EmcResources.cInt(oPgRow.Cells["idlocacaopagar"].Value.ToString());
                    oPagar = oPagarRN.ObterPor(oPagar);

                    lstPagar.Add(oPagar);
                }

                IntegracaoRN oIntegRN = new IntegracaoRN(Conexao, objOcorrencia, codempresa);
                oIntegRN.integraLocacaoPagar(lstPagar, EmcResources.cInt(usuario));

                grdLocacaoPagar.Rows.Clear();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Aviso");
            }
        }

        #endregion
       




    }
}
