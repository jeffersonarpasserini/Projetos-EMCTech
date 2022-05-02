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
    public partial class frmReceberAcordo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmReceberAcordo";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        //private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        private int usrAprovador01 = 0;
        private int usrAprovador02 = 0;
        private int usrAprovador03 = 0;
        private string stOperacao = "C";

        public frmReceberAcordo()
        {
            InitializeComponent();
        }

        public frmReceberAcordo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmReceberAcordo_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);

            UsuarioBLL oUsrDAO = new UsuarioBLL(Conexao);
            oUsuario = oUsrDAO.ObterPor(oUsuario);

            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "receberacordo";

            ParametroRN oParmRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
            usrAprovador01 = EmcResources.cInt(oParmRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "ID_APROV_ACORDO01"));
            usrAprovador03 = EmcResources.cInt(oParmRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "ID_APROV_ACORDO02"));
            usrAprovador02 = EmcResources.cInt(oParmRN.retParametro(codempresa, "EMCFINANCEIRO", "CTARECEBER", "ID_APROV_ACORDO03"));

            btnAprovaAcordo.Enabled = false;
            btnEstornaAprovacao.Enabled = false;
            txtDataLimiteRecebimento.Enabled = false;
            

            lblStatus.Text = "";
            CancelaOperacao();
            txtIdAcordo.Enabled = true;
            this.ActiveControl = txtIdAcordo;
        }

        #region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaAcordo(TarifaBancaria oTarifaBancaria)
        {
            try
            {
                
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }

        private ReceberAcordo montaReceberAcordo()
        {
            ReceberAcordo oAcordo = new ReceberAcordo();
            try
            {
                oAcordo.idAcordo = EmcResources.cInt(txtIdAcordo.Text);

                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                oCliente = oClienteRN.ObterPor(oCliente);

                oAcordo.cliente = oCliente;

                oAcordo.dataAcordo =Convert.ToDateTime(txtDataAcordo.DateValue.ToString());
                oAcordo.dataAprovacao = null;
                oAcordo.dataLimite = null;
                oAcordo.idAprovadorAcordo = 0;
                oAcordo.idEmpresa = codempresa;
                oAcordo.idGeradorAcordo = EmcResources.cInt(objOcorrencia.usuario.idUsuario.ToString());
                oAcordo.nomeAprovador = "";
                oAcordo.nomeGerador = objOcorrencia.usuario.nome;
                oAcordo.situacao = "P";

                ReceberParcelaRN oParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                List<ReceberParcela> lstParcelas = new List<ReceberParcela>();
                foreach(DataGridViewRow oRow in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(oRow.Cells[0].Value.ToString()))
                    {
                        ReceberParcela oParcela = new ReceberParcela();
                        oParcela.idReceberParcela = EmcResources.cInt(oRow.Cells["idreceberparcela"].Value.ToString());

                        oParcela = oParcelaRN.ObterPor(oParcela);

                        oParcela.jurosAcordo = EmcResources.cCur(oRow.Cells["jurosacordo"].Value.ToString());
                        oParcela.multaAcordo = EmcResources.cCur(oRow.Cells["multaacordo"].Value.ToString());
                        oParcela.descontoAcordo = EmcResources.cCur(oRow.Cells["descontoacordo"].Value.ToString());
                        oParcela.idAcordo = EmcResources.cInt(txtIdAcordo.Text);

                        lstParcelas.Add(oParcela);
                    }
                }

                oAcordo.lstParcelas = lstParcelas;

            }
            catch (Exception erro)
            {
                throw erro;
            }

            return oAcordo;
        }

        private void montaTela(ReceberAcordo oAcordo)
        {
            try
            {
                txtIdAcordo.Text = oAcordo.idAcordo.ToString();
                txtIdCliente.Text = oAcordo.cliente.pessoa.idPessoa.ToString();
                txtCNPJCPF.Text = oAcordo.cliente.pessoa.cnpjCpf.ToString();
                txtRazaoSocial.Text = oAcordo.cliente.pessoa.nome;
                txtNomeGerador.Text = oAcordo.nomeGerador;
                txtNomeAprovador.Text = oAcordo.nomeAprovador;
                txtDataAcordo.Text = oAcordo.dataAcordo.ToString();
                txtDataAprovacao.Text = oAcordo.dataAprovacao.ToString();
                txtDataLimiteRecebimento.Text = oAcordo.dataLimite.ToString();

                if (oAcordo.situacao == "P")
                    lblStatus.Text = "Aberto";
                else if (oAcordo.situacao == "A")
                    lblStatus.Text = "Aprovado";
                else if (oAcordo.situacao == "C")
                    lblStatus.Text = "Cancelado";


                if (objOcorrencia.usuario.idUsuario == usrAprovador01 ||
                    objOcorrencia.usuario.idUsuario == usrAprovador02 || 
                    objOcorrencia.usuario.idUsuario == usrAprovador03)
                {
                    if (oAcordo.situacao == "A")
                    {
                        btnAprovaAcordo.Enabled = false;
                        btnEstornaAprovacao.Enabled = true;
                        txtDataLimiteRecebimento.Enabled = false;
                    }
                    else if (oAcordo.situacao == "P")
                    {
                        btnAprovaAcordo.Enabled = true;
                        btnEstornaAprovacao.Enabled = false;
                        txtDataLimiteRecebimento.Enabled = true;
                    }
                    else
                    {
                        btnAprovaAcordo.Enabled = false;
                        btnEstornaAprovacao.Enabled = false;
                        txtDataLimiteRecebimento.Enabled = false;
                    }
                }
                else
                {
                    btnAprovaAcordo.Enabled = false;
                    btnEstornaAprovacao.Enabled = false;
                    txtDataLimiteRecebimento.Enabled = false;
                }

                exibeInfoCarteira();
                montaGrid(oAcordo);

                objOcorrencia.chaveidentificacao = oAcordo.idAcordo.ToString();

            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message);
            }

          


        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdAcordo.Enabled = false;
            txtCNPJCPF.Enabled = false;
            txtIdCliente.Enabled = false;
            btnCliente.Enabled = false;
            stOperacao = "A";
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

            txtIdAcordo.Enabled = false;
            txtCNPJCPF.Enabled = true;
            txtIdCliente.Enabled = true;
            btnCliente.Enabled = true;
            txtCNPJCPF.Focus();
            
            stOperacao = "I";
            objOcorrencia.chaveidentificacao = "";
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
            
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();

            txtIdAcordo.Enabled = true;
            txtCNPJCPF.Enabled = false;
            txtIdCliente.Enabled = false;
            btnCliente.Enabled = false;
            txtIdAcordo.Focus();
            stOperacao = "C";

            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();



        }

        public void pesquisaAcordo()
        {
            try
            {
                


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro PagarDocumento: " + erro.Message + erro.StackTrace, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            txtNomeGerador.Text = objOcorrencia.usuario.nome;
            txtDataAcordo.Text = DateTime.Now.ToString();
            lblStatus.Text = "";

            btnAprovaAcordo.Enabled = false;
            btnEstornaAprovacao.Enabled = false;
            txtDataLimiteRecebimento.Enabled = false;

            grdAcordo.Rows.Clear();

            txtCNPJCPF.Focus();
            objOcorrencia.chaveidentificacao = "";

        }

        public override void SalvaObjeto()
        {
            try
            {
                ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);
                ReceberAcordo oAcordo = new ReceberAcordo();

                oAcordo = montaReceberAcordo();

                int idAcordo = oAcordoRN.Salvar(oAcordo);

                MessageBox.Show("Código do Acordo : " + idAcordo.ToString(), "Acordo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpaCampos();
               
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
                ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);
                ReceberAcordo oAcordo = new ReceberAcordo();

                oAcordo = montaReceberAcordo();

                oAcordoRN.Atualizar(oAcordo);

                CancelaOperacao();

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
                ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);
                ReceberAcordo oAcordo = new ReceberAcordo();

                oAcordo = montaReceberAcordo();

                oAcordoRN.Excluir(oAcordo);

                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        #endregion

        #region [Tratamento de Texts, combos ]
        //Cliente
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
                            exibeInfoCarteira();
                            txtIdCliente.ReadOnly = true;
                            
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
                    exibeInfoCarteira();

                    ReceberAcordo oAcordo = new ReceberAcordo();
                    List<ReceberParcela> lstParcelas = new List<ReceberParcela>();

                    oAcordo.cliente = oCliente;
                    oAcordo.idAcordo = 0;
                    oAcordo.lstParcelas = lstParcelas;

                    montaGrid(oAcordo);
                    
                }

            }
            else
            {
                txtCNPJCPF.Focus();
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

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exibeInfoCarteira()
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text.Trim()) && txtIdCliente.Text != "System.Data.DataRowView")
            {

                Fornecedor oFornecedor = new Fornecedor();
                oFornecedor.codEmpresa = empMaster;
                oFornecedor.idPessoa = EmcResources.cInt(txtIdCliente.Text);

                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);

                //Receber
                ReceberParcelaRN oRcParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                txtCliSdoDevedor.Text = oRcParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtCliSdoAtraso.Text = oRcParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtCliVenc30d.Text = oRcParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtCliUp30d.Text = oRcParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();
                
                //Pagar
                PagarParcelaRN oPgParcelaRN = new PagarParcelaRN(Conexao, objOcorrencia, codempresa);
                txtForSdoDevedor.Text = oPgParcelaRN.calculaSaldoDevedor(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtForSdoAtraso.Text = oPgParcelaRN.calculaSaldoAtraso(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtForVenc30d.Text = oPgParcelaRN.calculaVencimento30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();
                txtForVencUp30d.Text = oPgParcelaRN.calculaSdoVencimentoUp30Dias(EmcResources.cInt(txtIdCliente.Text)).ToString();

                //dados adiantamentos - Fornecedor
                PagarBaixaRN oPgBaixaRN = new PagarBaixaRN(Conexao, objOcorrencia, codempresa);
                txtForSdoAdto.Text = oPgBaixaRN.calculaSdoAdiantamento(oFornecedor).ToString();

                //dados adiantamentos - Cliente
                ReceberBaixaRN oRcBaixaRN = new ReceberBaixaRN(Conexao, objOcorrencia, codempresa);
                txtCliSdoAdto.Text = oRcBaixaRN.calculaSdoAdiantamento(oCliente).ToString();
            }
        }

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
                        AtivaEdicao();
                        montaTela(oAcordo);
                    }
                    else
                    {
                        AtivaInsercao();
                        MessageBox.Show("Acordo não encontrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message);
            }
        }

        #endregion

        #region "metodos para grid"

        public void montaGrid(ReceberAcordo oAcordo)
        {
            try
            {
                grdAcordo.Rows.Clear();

                List<ReceberParcela> lstParcela = new List<ReceberParcela>();
                ReceberParcelaRN oParcelaRN = new ReceberParcelaRN(Conexao, objOcorrencia, codempresa);
                lstParcela = oParcelaRN.listaParcelaBaixa(codempresa, oAcordo.cliente.pessoa.codEmpresa, oAcordo.cliente.pessoa.idPessoa, DateTime.Now, DateTime.Now, true, "",0);

                string situacao = "";
                bool acordo = false;
                foreach(ReceberParcela oParcela in lstParcela)
                {
                    if (oParcela.dataVencimento < DateTime.Now)
                        situacao = "Vencida";
                    else
                        situacao = "A Vencer";

                    if (oParcela.idAcordo > 0)
                    {
                        acordo = true;
                    }
                    else
                    {
                        acordo = false;
                        oParcela.jurosAcordo = oParcela.jurosPrevisto;
                        oParcela.multaAcordo = oParcela.multaPrevisto;
                    }

                    if ( (oParcela.idAcordo > 0 && stOperacao == "I") || oAcordo.situacao == "C")
                    {
                        //se a parcela já está em um acordo não pode entrar em outro.
                    }
                    else
                    {
                        grdAcordo.Rows.Add(acordo,
                                           oParcela.receberDocumento.nroDocumento,
                                           oParcela.nroParcela,
                                           oParcela.dataVencimento.ToString(),
                                           oParcela.valorParcela,
                                           oParcela.saldoPagar,
                                           oParcela.jurosPrevisto,
                                           oParcela.multaPrevisto,
                                           oParcela.jurosAcordo,
                                           oParcela.multaAcordo,
                                           oParcela.descontoAcordo,
                                           situacao,
                                           oParcela.idReceberParcela);
                    }
                }

                calculaValoresAcordo();
              
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btnMarcaTodas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == false)
                    {
                        row.Cells[0].Value = true;
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnLimpaSelecao_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                    {
                        row.Cells[0].Value = false;
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnMarcaVencidas_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == false && row.Cells["situacao"].Value.ToString() == "Vencida")
                    {
                        row.Cells[0].Value = true;
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIsentaJuros_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                    {
                        row.Cells["jurosacordo"].Value = 0;
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnIsentaMulta_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                    {
                        row.Cells["multaacordo"].Value = 0;
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDescJuros_Click(object sender, EventArgs e)
        {
            try
            {
                double valorDesconto = 0;
                double valorJuros = 0;
                if (txtPercDescontoJuros.Value > 0)
                {
                    foreach (DataGridViewRow row in grdAcordo.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                        {
                            valorJuros = EmcResources.cDouble(row.Cells["jurosprevisto"].Value.ToString());
                            valorDesconto = valorJuros * (txtPercDescontoJuros.Value / 100);
                            valorJuros = Math.Round((valorJuros - valorDesconto), 2);
                            row.Cells["jurosacordo"].Value = EmcResources.cCur(valorJuros.ToString());
                        }
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDescMulta_Click(object sender, EventArgs e)
        {
            try
            {
                double valorDesconto = 0;
                double valorMulta = 0;
                if (txtPercDescontoMulta.Value > 0)
                {
                    foreach (DataGridViewRow row in grdAcordo.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                        {
                            valorMulta = EmcResources.cDouble(row.Cells["multaprevista"].Value.ToString());
                            valorDesconto = valorMulta * (txtPercDescontoMulta.Value / 100);
                            valorMulta = Math.Round((valorMulta - valorDesconto), 2);
                            row.Cells["multaacordo"].Value = EmcResources.cCur(valorMulta.ToString());
                        }
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDesconto_Click(object sender, EventArgs e)
        {
            try
            {
                double valorDesconto = 0;
                double valor = 0;
                if (txtPercDesconto.Value > 0)
                {
                    foreach (DataGridViewRow row in grdAcordo.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                        {
                            valor = EmcResources.cDouble(row.Cells["multaprevista"].Value.ToString()) + EmcResources.cDouble(row.Cells["jurosprevisto"].Value.ToString());
                            valorDesconto = Math.Round((valor * (txtPercDesconto.Value / 100)), 2);
                            row.Cells["descontoacordo"].Value = EmcResources.cCur(valorDesconto.ToString());
                        }
                    }
                }
                calculaValoresAcordo();
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRecompoe_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                    {
                        row.Cells["descontoacordo"].Value = 0;
                        row.Cells["jurosacordo"].Value = row.Cells["jurosprevisto"].Value;
                        row.Cells["multaacordo"].Value = row.Cells["multaprevista"].Value;
                    }
                }

                calculaValoresAcordo();

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void calculaValoresAcordo()
        {
            try
            {
                decimal valorJuros = 0;
                decimal valorMulta = 0;
                decimal totalJurosMulta = 0;
                decimal valorJurosAcordo = 0;
                decimal valorMultaAcordo = 0;
                decimal valorDescontoAcordo = 0;
                decimal totalAcordo = 0;


                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value.ToString()) == true)
                    {
                        valorDescontoAcordo += EmcResources.cCur(row.Cells["descontoacordo"].Value.ToString());
                        valorJurosAcordo += EmcResources.cCur(row.Cells["jurosacordo"].Value.ToString());
                        valorMultaAcordo += EmcResources.cCur(row.Cells["multaacordo"].Value.ToString());
                        valorJuros += EmcResources.cCur(row.Cells["jurosprevisto"].Value.ToString());
                        valorMulta += EmcResources.cCur(row.Cells["multaprevista"].Value.ToString());
                    }
                }

                totalAcordo = (valorJurosAcordo + valorMultaAcordo) - valorDescontoAcordo;
                totalJurosMulta = (valorJuros + valorMulta);

                txtVlrDiferenca.Text = (totalAcordo - totalJurosMulta).ToString();

                txtTotalAcordo.Text = totalAcordo.ToString();
                txtJurosAcordo.Text = valorJurosAcordo.ToString();
                txtMultaAcordo.Text = valorMultaAcordo.ToString();
                txtDescAcordo.Text = valorDescontoAcordo.ToString();
                
                txtTotalCobrar.Text = totalJurosMulta.ToString();
                txtJurosCobrar.Text = valorJuros.ToString();
                txtMultaCobrar.Text = valorMulta.ToString();

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdAcordo_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells[0].Value.ToString()))
                {
                    decimal valorJuros = EmcResources.cCur(grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["jurosprevisto"].Value.ToString());
                    decimal valorMulta = EmcResources.cCur(grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["multaprevista"].Value.ToString());

                    if (valorJuros <= 0)
                        txtJurosAltera.Enabled = false;
                    else
                        txtJurosAltera.Enabled = true;

                    if (valorMulta <= 0)
                        txtMultaAltera.Enabled = false;
                    else
                        txtMultaAltera.Enabled = true;


                    txtJurosAltera.Text = grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["jurosacordo"].Value.ToString();
                    txtMultaAltera.Text = grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["multaacordo"].Value.ToString();
                    txtDescontoAltera.Text = grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["descontoacordo"].Value.ToString();
                    txtIdReceberParcela.Text = grdAcordo.Rows[grdAcordo.CurrentRow.Index].Cells["idreceberparcela"].Value.ToString();

                    if (txtJurosAltera.Enabled)
                        txtJurosAltera.Focus();
                    else
                        txtDescontoAltera.Focus();
                }
                else
                    MessageBox.Show("Parcela não selecionada no acordo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAlteraAcordo_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in grdAcordo.Rows)
                {
                    if (EmcResources.cInt(row.Cells["idreceberparcela"].Value.ToString()) == EmcResources.cInt(txtIdReceberParcela.Text))
                    {
                        row.Cells["descontoacordo"].Value = txtDescontoAltera.Value;
                        row.Cells["jurosacordo"].Value = txtJurosAltera.Value;
                        row.Cells["multaacordo"].Value = txtMultaAltera.Value;
                    }
                }

                calculaValoresAcordo();

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAprovaAcordo_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDataLimiteRecebimento.DateValue is DateTime)
                {
                    ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);
                    ReceberAcordo oAcordo = new ReceberAcordo();

                    oAcordo = montaReceberAcordo();
                    oAcordo.dataAprovacao = DateTime.Now;
                    oAcordo.dataLimite = txtDataLimiteRecebimento.DateValue;
                    oAcordo.idAprovadorAcordo = objOcorrencia.usuario.idUsuario;

                    oAcordoRN.aprovaAcordo(oAcordo);

                    txtIdAcordo_Validating(null, null);
                }
                else
                {
                    MessageBox.Show("Preencher a data de validade da negociação", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDataLimiteRecebimento.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }

        }

        private void btnEstornaAprovacao_Click(object sender, EventArgs e)
        {
            try
            {
                ReceberAcordoRN oAcordoRN = new ReceberAcordoRN(Conexao, objOcorrencia, codempresa);
                ReceberAcordo oAcordo = new ReceberAcordo();

                oAcordo = montaReceberAcordo();

                oAcordoRN.estornaAprovacao(oAcordo);

                CancelaOperacao();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
        }

        #endregion

        

        



        

        
 
        

        

       


    }
}
