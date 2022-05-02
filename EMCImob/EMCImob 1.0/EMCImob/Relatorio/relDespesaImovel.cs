using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroRN;
using EMCImobRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;
using System.Collections;
using EMCCadastro;
using EMCImobModel;

namespace EMCImob.Relatorios
{
    public partial class relDespesaImovel : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relDespesaImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relDespesaImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relDespesaImovel_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "despesaimovel";

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
                listaDespesaImovel();
            else if (cboRelatorio.SelectedIndex == 1)
                listaFornecedor();
            else if (cboRelatorio.SelectedIndex == 2)
                listaImovel();
        }

        private void listaDespesaImovel()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                DespesaImovelRN oBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdDespesaImovel.Text) >= 0)
                {                    
                    this.dstDespesaImovel.Tables["DespesaImovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Load(oBLL.ListaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                                               chkFornecedor.Checked,
                                                                                               txtCodigoImovel.Text,
                                                                                               chkImovel.Checked).CreateDataReader());
                   

                    this.dstDespesaImovel.Tables["DespesaImovel"].Load(oBLL.ListaDespesaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                                               chkFornecedor.Checked,
                                                                                               txtCodigoImovel.Text,
                                                                                               chkImovel.Checked, 
                                                                                               txtDataInicial.DateValue,
                                                                                               txtDataFinal.DateValue).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstDespesaImovel.Tables["DespesaImovel"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptDespesaImovel.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptDespesaImovel.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptDespesaImovel.Show();
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
                DespesaImovelRN oBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdPessoa.Text) >= 0)
                {
                    this.dstDespesaImovel.Tables["DespesaImovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Load(oBLL.ListaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                                                chkFornecedor.Checked,
                                                                                                txtCodigoImovel.Text,
                                                                                                chkImovel.Checked).CreateDataReader());
                   

                    this.dstDespesaImovel.Tables["DespesaImovel"].Load(oBLL.ListaDespesaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                                            chkFornecedor.Checked,
                                                                                            txtCodigoImovel.Text,
                                                                                            chkImovel.Checked,
                                                                                            txtDataInicial.DateValue,
                                                                                            txtDataFinal.DateValue).CreateDataReader());
                    
                    
                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstDespesaImovel.Tables["DespesaImovel"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptFornecedor.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptFornecedor.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptFornecedor.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaImovel()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                DespesaImovelRN oBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (String.IsNullOrEmpty(txtCodigoImovel.Text) || !String.IsNullOrEmpty(txtCodigoImovel.Text))
                {
                    this.dstDespesaImovel.Tables["DespesaImovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Clear();
                    this.dstDespesaImovel.Tables["Imovel"].Load(oBLL.ListaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                                 chkFornecedor.Checked,
                                                                                 txtCodigoImovel.Text,
                                                                                 chkImovel.Checked).CreateDataReader());
                    

                    this.dstDespesaImovel.Tables["DespesaImovel"].Load(oBLL.ListaDespesaImovel(EmcResources.cInt(txtIdPessoa.Text),
                                                                               chkFornecedor.Checked,
                                                                               txtCodigoImovel.Text,
                                                                               chkImovel.Checked,
                                                                               txtDataInicial.DateValue,
                                                                               txtDataFinal.DateValue).CreateDataReader());

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstDespesaImovel.Tables["Imovel"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptImovel.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptImovel.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptImovel.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnPessoa_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdPessoa.Text = "";
                else
                    txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdPessoa.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdPessoa.Text))
                {
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    Fornecedor oFornecedor = new Fornecedor();

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdPessoa.Text = "";
                        btnPessoa.Focus();
                    }
                    else
                    {
                        txtPessoa.Text = oFornecedor.pessoa.nome;
                        txtPessoa.Focus();
                    }
                }
                else
                {
                    btnPessoa.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
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
                    SendKeys.Send("{TAB}");
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
                if (!String.IsNullOrEmpty(txtCodigoImovel.Text) || !String.IsNullOrEmpty(txtIdImovel.Text))
                {
                    Imovel oImovel = new Imovel();
                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);

                    Empresa oEmpresa = new Empresa();
                    EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, empMaster);
                    oEmpresa.idEmpresa = empMaster;
                    oImovel.empresa = oEmpresa;

                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa.idEmpresa = empMaster;
                    oImovel = oImovelRN.ObterPor(oImovel);

                    if (String.IsNullOrEmpty(oImovel.codigoImovel) || oImovel.idImovel == 0)
                    {
                        MessageBox.Show("Imóvel não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodigoImovel.Text = "";
                        btnImovel.Focus();
                    }
                    else
                    {
                        txtImovel.Text = oImovel.tipoImovel.descricao;
                        txtImovel.Focus();
                    }
                }
                else
                {
                    btnImovel.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
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
            arr.Add(new popCombo("RELATÓRIO GERAL", "1"));
            arr.Add(new popCombo("POR FORNECEDOR", "2"));
            arr.Add(new popCombo("POR IMÓVEL", "3"));
            cboRelatorio.DataSource = arr;
            cboRelatorio.DisplayMember = "nome";
            cboRelatorio.ValueMember = "valor";
        }

        #endregion
    }
}
