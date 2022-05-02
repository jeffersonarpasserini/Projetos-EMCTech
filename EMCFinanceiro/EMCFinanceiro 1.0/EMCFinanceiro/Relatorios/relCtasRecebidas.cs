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
using EMCFinanceiroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;
using EMCSecurityRN;


namespace EMCFinanceiro
{
    public partial class relCtasRecebidas : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relCtasRecebidas";
        private const string nomeAplicativo = "EMCFinanceiro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        int vTamMaximo = 0; //tamanho da conta custo no nivel 7
        int vNroNiveis = 0; // numero de niveis
        int vTamNV1 = 0; // tamanho no nivel 1
        int vTamNV2 = 0; // tamanho no nivel 2
        int vTamNV3 = 0; // tamanho no nivel 3
        int vTamNV4 = 0; // tamanho no nivel 4
        int vTamNV5 = 0; // tamanho no nivel 5
        int vTamNV6 = 0; // tamanho no nivel 6
        int vTamNV7 = 0; // tamanho no nivel 7
        string vMascara = "";

        public relCtasRecebidas(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relCtasRecebidas_Load(object sender, EventArgs e)
        {
            Parametro oParametro = new Parametro();
            ParametroRN oParametroRN = new ParametroRN(Conexao,objOcorrencia,codempresa);
            //verifica o parametro considera data valida para vencimento de parcelas.
            vTamMaximo = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAMANHO_CONTACUSTO"));
            vNroNiveis = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "NRONIVEIS_CONTACUSTO"));
            vTamNV1 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV1_CONTACUSTO"));
            vTamNV2 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV2_CONTACUSTO"));
            vTamNV3 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV3_CONTACUSTO"));
            vTamNV4 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV4_CONTACUSTO"));
            vTamNV5 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV5_CONTACUSTO"));
            vTamNV6 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV6_CONTACUSTO"));
            vTamNV7 = EmcResources.cInt(oParametroRN.retParametro(codempresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV7_CONTACUSTO"));

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;


            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "receberrateio";

            this.LimpaCampos();
        }

        #region "Botões Overrides"

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (ValidaCampos() == false)
            {
                return;
            }

            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                ReceberRateioRN oBLL = new ReceberRateioRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
                {
                    drpRelatorio = oBLL.DataReport4(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(txtIdTipoDocumento.Text));

                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para Período e Tipo Documento Informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    todos.SetParameterValue("Periodo", "Tipo Documento: " + txtTipoDocumento.Text.ToString() + " no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    todos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    todos.Show();
                }
                else
                if (ckContaCusto.Checked && ckClientes.Checked)
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    todos.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    todos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    todos.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtCodigoConta.Text) && !String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    drpRelatorio = oBLL.DataReport3(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), txtCodigoConta.Text, Convert.ToInt32(txtIdCliente.Text));
                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para o conta custo e fornecedor informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    contaCusto.SetParameterValue("Periodo", "Conta: " + txtCodigoConta.Text.ToString() + " - " + txtContaCusto.Text.ToString() + " e Fornecedor: " + txtCliente.Text.ToString() + " no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    contaCusto.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    contaCusto.Show();
                }
                else 
                if (ckClientes.Checked)
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    cliente.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    cliente.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    cliente.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtIdCliente.Text))
                {
                    drpRelatorio = oBLL.DataReport2(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), EmcResources.cInt(txtIdCliente.Text));
                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para o fornecedor informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    cliente.SetParameterValue("Periodo", "de " + txtCliente.Text.ToString() + " no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    cliente.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    cliente.Show();
                }
                else
                if (ckContaCusto.Checked)
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    contaCusto.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    contaCusto.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    contaCusto.Show();
                }
                else
                if (!String.IsNullOrEmpty(txtCodigoConta.Text))
                {
                    drpRelatorio = oBLL.DataReport1(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text), txtCodigoConta.Text);
                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros para o centro de custos informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    contaCusto.SetParameterValue("Periodo", "Conta: " + txtCodigoConta.Text.ToString() + " - " + txtContaCusto.Text.ToString() + " no Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    contaCusto.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    contaCusto.Show();
                }
                else
                {
                    drpRelatorio = oBLL.DataReport(Convert.ToDateTime(txtDtaInicial.Text), Convert.ToDateTime(txtDtaFinal.Text));

                    this.dstCtasRecebidas.Tables["MyTable"].Clear();
                    this.dstCtasRecebidas.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                    if (Convert.ToInt32(this.dstCtasRecebidas.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    todos.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
                    todos.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    todos.Show();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        #endregion

        #region "Métodos Overrides"

        public override void LimpaCampos()
        {
            base.LimpaCampos();

            //Monta período a emitir com base nos 30 últimos dias
            txtDtaInicial.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
            txtDtaFinal.Text = DateTime.Today.ToShortDateString();
            ckClientes.Checked = false;
            ckContaCusto.Checked = false;


        }

        #endregion

        private Boolean ValidaCampos()
        {
            if (String.IsNullOrEmpty(txtDtaInicial.Text.ToString()))
            {
                MessageBox.Show("A Data Inicial deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (String.IsNullOrEmpty(txtDtaFinal.Text.ToString()))
            {
                MessageBox.Show("A Data Final deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtDtaFinal.Value < txtDtaInicial.Value)
            {
                MessageBox.Show("A Data Final deve ser Maior que a Data Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void relCtasRecebidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCodigoConta.Text))
            {
                try
                {
                    ContaCusto oContaCusto = new ContaCusto();
                    ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                    oContaCusto.codigoConta = txtCodigoConta.Text;
                    //oContaCusto.codEmpresa = empMaster;

                    oContaCusto = oContaCustoRN.ObterPor(oContaCusto);

                    txtContaCusto.Text = oContaCusto.descricao;

                    if (oContaCusto.codigoConta == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
               
        private void btnContaCusto_Click(object sender, EventArgs e)
        {
            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, vTodas: true);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtCodigoConta.Text = "";
                //txtIdContaCusto.Text = "";
            }
            else
            txtCodigoConta.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
            txtIdContaCusto.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtCodigoConta.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtIdCliente_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdCliente.Text))
                try
                {
                    Cliente oCliente = new Cliente();
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, codempresa);

                    oCliente.idPessoa = EmcResources.cInt(txtIdCliente.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    txtCliente.Text = oCliente.pessoa.nome;

                    if (txtIdCliente == null)
                    {

                    }
                }

                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                // txtIdCliente.Text = "";
            }
            else
                txtIdCliente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdCliente.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtIdTipoDocumento_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdTipoDocumento.Text))
                try
                {
                    TipoDocumento oTipoDocumento = new TipoDocumento();

                    TipoDocumentoRN oTipoDocumentoRN = new TipoDocumentoRN(Conexao, objOcorrencia, codempresa);

                    oTipoDocumento.idTipoDocumento = EmcResources.cInt(txtIdTipoDocumento.Text);

                    oTipoDocumento = oTipoDocumentoRN.ObterPor(oTipoDocumento);

                    txtTipoDocumento.Text = oTipoDocumento.descricao;

                    if (txtIdTipoDocumento == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnTipoDocumento_Click(object sender, EventArgs e)
        {
            psqTipoDocumento ofrm = new psqTipoDocumento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdTipoDocumento.Text = "";
            }
            else
                txtIdTipoDocumento.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdTipoDocumento.Focus();
            SendKeys.Send("{TAB}");
        }
    }
}
