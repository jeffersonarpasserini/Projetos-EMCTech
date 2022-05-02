using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCImob;
using EMCImobModel;
using EMCImobRN;
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
    public partial class relAgenda : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relAgenda";
        private const string nomeAplicativo = "EMCEventos";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relAgenda(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relAgenda_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "evt_agenda";

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
                listaAgendaImovel();
            else if (cboRelatorio.SelectedIndex == 1)
                listaAgendaEvento();            
        }
              
        private void listaAgendaImovel()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                AgendaRN oBLL = new AgendaRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdAgenda.Text) >= 0)
                {
                    this.dstAgenda.Tables["Agenda"].Clear();
                    this.dstAgenda.Tables["Evento"].Clear();
                    this.dstAgenda.Tables["Imovel"].Clear();                   
                    this.dstAgenda.Tables["Imovel"].Load(oBLL.ListaAgendaEvento(EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                                txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstAgenda.Tables["Agenda"].Load(oBLL.ListaAgendaEvento(EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                                txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstAgenda.Tables["Evento"].Load(oBLL.ListaAgendaEvento(EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                                txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstAgenda.Tables["Evento"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptImovel.SetParameterValue("Periodo", txtDataInicio.Text + " a " + txtDataFinal.Text);
                    rptImovel.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptImovel.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaAgendaEvento()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                AgendaRN oBLL = new AgendaRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (EmcResources.cInt(txtIdAgenda.Text) >= 0)
                {
                    this.dstAgenda.Tables["Evento"].Clear();
                    this.dstAgenda.Tables["Imovel"].Clear(); 
                    this.dstAgenda.Tables["Agenda"].Clear();             
                    this.dstAgenda.Tables["Agenda"].Load(oBLL.ListaAgendaEvento( EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                                txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstAgenda.Tables["Evento"].Load(oBLL.ListaAgendaEvento( EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                               EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                               txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());

                    this.dstAgenda.Tables["Imovel"].Load(oBLL.ListaAgendaEvento(EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text,
                                                                                EmcResources.cInt(txtIdEvento.Text), txtDescEvento.Text, chkImovel.Checked, chkEvento.Checked,
                                                                                txtDataInicio.DateValue, txtDataFinal.DateValue).CreateDataReader());
                    

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstAgenda.Tables["Agenda"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptEvento.SetParameterValue("Periodo", txtDataInicio.Text + " a " + txtDataFinal.Text);
                    rptEvento.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptEvento.Show();
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

        private void btnEvento_Click(object sender, EventArgs e)
        {
            try
            {
                psqEvento ofrm = new psqEvento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    txtIdEvento.Text = "";
                }
                else
                {
                    txtIdEvento.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtIdEvento.Focus();
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdEvento_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //SubLocacao objSubLocacao = new SubLocacao();

                if (!String.IsNullOrEmpty(txtIdEvento.Text))
                {
                    Evento oEvento = new Evento();
                    EventoRN oEventoRN = new EventoRN(Conexao, objOcorrencia, codempresa);

                    oEvento.idEvento = EmcResources.cInt(txtIdEvento.Text);
                    oEvento = oEventoRN.ObterPor(oEvento);

                    if (oEvento.idEvento == 0)
                    {
                        MessageBox.Show("Evento não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdEvento.Text = "";
                        btnEvento.Focus();
                    }
                    else
                    {
                        txtDescEvento.Text = oEvento.descricao;
                        txtDescEvento.Focus();
                        //AtualizaGrid();
                    }
                }
                else
                {
                    btnEvento.Focus();
                }
                //AtualizaGrid(objIptu);
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
            arr.Add(new popCombo("POR EVENTO", "2"));
            cboRelatorio.DataSource = arr;
            cboRelatorio.DisplayMember = "nome";
            cboRelatorio.ValueMember = "valor";
        }

        #endregion
    }
}
