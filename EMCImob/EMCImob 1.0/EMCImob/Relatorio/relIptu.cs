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
    public partial class relIptu : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relDespesaImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relIptu(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relIptu_Load(object sender, EventArgs e)
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
                listaIptu();
            else if (cboRelatorio.SelectedIndex == 1)
                listaIptuAnoBase();            
        }

        private void listaIptu()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                IptuRN oBLL = new IptuRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdImovel.Text) >= 0)
                {                    
                    this.dstIptu.Tables["Iptu"].Clear();
                    this.dstIptu.Tables["Imovel"].Clear();
                    this.dstIptu.Tables["Imovel"].Load(oBLL.ListaIptuImovel(EmcResources.cInt(txtIdIptu.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text, 
                                                                            chkImovel.Checked, txtAnoBase.Text, txtDataInicial.DateValue, txtDataFinal.DateValue).CreateDataReader());


                    this.dstIptu.Tables["Iptu"].Load(oBLL.ListaIptu(EmcResources.cInt(txtIdIptu.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text, 
                                                                                      chkImovel.Checked, txtAnoBase.Text, txtDataInicial.DateValue, 
                                                                                      txtDataFinal.DateValue).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstIptu.Tables["Imovel"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptIptu.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptIptu.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptIptu.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaIptuAnoBase()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                IptuRN oBLL = new IptuRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdIptu.Text) >= 0)
                {
                    this.dstIptu.Tables["Iptu"].Clear();
                    this.dstIptu.Tables["Imovel"].Clear();
                    this.dstIptu.Tables["Imovel"].Load(oBLL.ListaIptuImovel(EmcResources.cInt(txtIdIptu.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                            chkImovel.Checked, txtAnoBase.Text, txtDataInicial.DateValue, txtDataFinal.DateValue).CreateDataReader());


                    this.dstIptu.Tables["Iptu"].Load(oBLL.ListaIptu(EmcResources.cInt(txtIdIptu.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                      chkImovel.Checked, txtAnoBase.Text, txtDataInicial.DateValue,
                                                                                      txtDataFinal.DateValue).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstIptu.Tables["Imovel"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptIptuAnoBase.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptIptuAnoBase.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptIptuAnoBase.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
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
            arr.Add(new popCombo("POR IMÓVEL", "1"));
            arr.Add(new popCombo("POR ANO BASE", "2"));
            cboRelatorio.DataSource = arr;
            cboRelatorio.DisplayMember = "nome";
            cboRelatorio.ValueMember = "valor";
        }

        #endregion
    }
}
