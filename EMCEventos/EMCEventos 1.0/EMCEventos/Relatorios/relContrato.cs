using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMCEventos.Relatorios
{
    public partial class relContrato : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relContrato";
        private const string nomeAplicativo = "EMCEventos";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relContrato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relContrato_Load(object sender, EventArgs e)
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

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        #endregion

        #region "Botões Overrides"

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboRelatorio.SelectedIndex == 0)
                listaContrato();
            else if (cboRelatorio.SelectedIndex == 1)
                listaCliente();
            else if (cboRelatorio.SelectedIndex == 2)
                listaFornecedor();
        }

        private void listaContrato()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ContratoRN oBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdContrato.Text) >= 0)
                {
                    this.dstContrato.Tables["Cliente"].Clear();
                    this.dstContrato.Tables["Fornecedor"].Clear();
                    this.dstContrato.Tables["SubLocacao"].Clear();
                    this.dstContrato.Tables["Contrato"].Clear();
                    this.dstContrato.Tables["Contrato"].Load(oBLL.ListaRelContrato(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked, EmcResources.cInt(txtIdSubLocacao.Text),
                                                                                    chkSubLocacao.Checked, EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["SubLocacao"].Load(oBLL.ListaContratoSubLoc(EmcResources.cInt(txtIdSubLocacao.Text), chkSubLocacao.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["Fornecedor"].Load(oBLL.ListaContratoForn(EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["Cliente"].Load(oBLL.ListaContratoCli(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked,
                                                                                   txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstContrato.Tables["Contrato"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptContrato.SetParameterValue("Periodo", txtDataInicio.Text + " a " + txtDataFinal.Text);
                    rptContrato.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptContrato.Show();

                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaCliente()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ContratoRN oBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdCliente.Text) >= 0)
                {
                    this.dstContrato.Tables["Fornecedor"].Clear();
                    this.dstContrato.Tables["SubLocacao"].Clear();
                    this.dstContrato.Tables["Contrato"].Clear();
                    this.dstContrato.Tables["Cliente"].Clear();
                    this.dstContrato.Tables["Cliente"].Load(oBLL.ListaContratoCli(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked,
                                                                                   txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());
                                        
                    this.dstContrato.Tables["Contrato"].Load(oBLL.ListaRelContrato(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked, EmcResources.cInt(txtIdSubLocacao.Text),
                                                                                    chkSubLocacao.Checked, EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["SubLocacao"].Load(oBLL.ListaContratoSubLoc(EmcResources.cInt(txtIdSubLocacao.Text), chkSubLocacao.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["Fornecedor"].Load(oBLL.ListaContratoForn(EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());



                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstContrato.Tables["Contrato"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptCliente.SetParameterValue("Periodo", txtDataInicio.Text + " a " + txtDataFinal.Text);
                    rptCliente.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptCliente.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaFornecedor()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ContratoRN oBLL = new ContratoRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(cboFornecedor.SelectedValue.ToString()) >= 0)
                {
                    this.dstContrato.Tables["SubLocacao"].Clear();
                    this.dstContrato.Tables["Cliente"].Clear();
                    this.dstContrato.Tables["Contrato"].Clear();                    
                    this.dstContrato.Tables["Fornecedor"].Clear();
                    this.dstContrato.Tables["Fornecedor"].Load(oBLL.ListaContratoForn(EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());
                    
                    this.dstContrato.Tables["Contrato"].Load(oBLL.ListaRelContrato(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked, EmcResources.cInt(txtIdSubLocacao.Text),
                                                                                    chkSubLocacao.Checked, EmcResources.cInt(cboFornecedor.SelectedValue.ToString()), chkFornecedor.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["Cliente"].Load(oBLL.ListaContratoCli(EmcResources.cInt(txtIdCliente.Text), chkCliente.Checked,
                                                                                   txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstContrato.Tables["SubLocacao"].Load(oBLL.ListaContratoSubLoc(EmcResources.cInt(txtIdSubLocacao.Text), chkSubLocacao.Checked,
                                                                                    txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                                        

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstContrato.Tables["Fornecedor"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptFornecedor.SetParameterValue("Periodo", txtDataInicio.Text + " a " + txtDataFinal.Text);
                    rptFornecedor.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptFornecedor.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
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

      

        #endregion

        #region "Métodos Overrides"

        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();


            //inicializa combo de ordenação
            //cboRelatorio.Items.Clear();
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("POR CONTRATO", "1"));
            arr.Add(new popCombo("POR CLIENTE", "2"));
            arr.Add(new popCombo("POR FORNECEDOR", "3"));
            cboRelatorio.DataSource = arr;
            cboRelatorio.DisplayMember = "nome";
            cboRelatorio.ValueMember = "valor";


            Fornecedor oFornecedor = new Fornecedor();
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
            oFornecedor.codEmpresa = codempresa;
            cboFornecedor.DataSource = oFornecedorRN.ListaFornecedor(oFornecedor);
            cboFornecedor.ValueMember = "idpessoa";
            cboFornecedor.DisplayMember = "nome";

            //cboFornecedor.SelectedIndex = -1;
        }

        #endregion


    }
}
