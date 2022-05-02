using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EMCImobModel;
using EMCImobRN;
using EMCImob;

namespace EMCEventos
{
    public partial class frmEvento : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEvento";
        private const string nomeAplicativo = "EMCEventos";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEvento(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmEvento()
        {
            InitializeComponent();
        }

        private void frmEvento_Activated(object sender, EventArgs e)
        {

        }
        private void frmEvento_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "evt_evento";

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;                      

            this.ActiveControl = txtIdEvento;
            //this.ActiveControl = txtCodigoImovel;
            CancelaOperacao();

            AtualizarCalendario();
            
        }
        #endregion

        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaEvento(Evento oEvento)
        {
            EventoRN oEventoRN = new EventoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oEventoRN.VerificaDados(oEvento);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Evento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Evento montaEvento()
        {
            Evento oEvento = new Evento();

            oEvento.idEvento = EmcResources.cInt(txtIdEvento.Text);
            oEvento.descricao = txtDescricaoEvento.Text;
            oEvento.dataInicio = Convert.ToDateTime(txtDataInicio.Text);
            oEvento.dataFinal = Convert.ToDateTime(txtDataFinal.Text);

            Imovel oImovel = new Imovel();
            ImovelRN oImoRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
            Empresa oEmpresa = new Empresa();
            oEmpresa.idEmpresa = codempresa;

            oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
            oImovel.codigoImovel = txtCodigoImovel.Text;
            oImovel.empresa = oEmpresa;
            oImovel = oImoRN.ObterPor(oImovel);
            oEvento.imovel = oImovel;

            //oEvento.statusEvento = lblSituacao.Text;

            List<Agenda> lstAgenda = new List<Agenda>();
            foreach (DataGridViewRow oRow in grdAgenda.Rows)
            {

                Agenda obAgenda = new Agenda();

                obAgenda.flag = oRow.Cells["status"].Value.ToString();

                if (obAgenda.flag == "E")
                {
                    obAgenda.idAgenda = EmcResources.cInt(oRow.Cells["idevt_agenda"].Value.ToString());
                }

                Evento obEvento = new Evento();
                obEvento.idEvento = EmcResources.cInt(oRow.Cells["idevt_evento"].Value.ToString());
                obAgenda.evento = obEvento;

                //obAgenda.dataAgenda = obEvento.dataInicio;
                obAgenda.dataAgenda = Convert.ToDateTime(oRow.Cells["dataagenda"].Value.ToString());

                obAgenda.situacao = oRow.Cells["statusevento"].Value.ToString();

                Imovel obImovel = new Imovel();
                ImovelRN obImoRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                Empresa obEmpresa = new Empresa();
                obEmpresa.idEmpresa = codempresa;

                obImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
                obImovel.codigoImovel = oRow.Cells["codigoimovel"].Value.ToString();
                obImovel.empresa = obEmpresa;
                obImovel = obImoRN.ObterPor(obImovel);
                obAgenda.imovel = obImovel;

                lstAgenda.Add(obAgenda);
            }
            oEvento.lstAgenda = lstAgenda;

            return oEvento;
        }

        private void montaTela(Evento oEvento)
        {
            txtIdEvento.Text = oEvento.idEvento.ToString();

            txtIdImovel.Text = oEvento.imovel.idImovel.ToString();
            txtCodigoImovel.Text = oEvento.imovel.codigoImovel;
            txtImovel.Text = oEvento.imovel.tipoImovel.descricao;

            txtDescricaoEvento.Text = oEvento.descricao.ToString();
            txtDataInicio.Text = oEvento.dataInicio.ToString();
            txtDataFinal.Text = oEvento.dataFinal.ToString();

            lblSituacao.Text = "";

            if (oEvento.statusEvento == "D")
            {
                lblSituacao.Text = "Disponível";
            }
            else if (oEvento.statusEvento == "R")
            {
                lblSituacao.Text = "Reservado";
            }
            else if (oEvento.statusEvento == "C")
            {
                lblSituacao.Text = "Confirmado";
            }

            txtIdEvento.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oEvento.idEvento.ToString();
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
            txtIdEvento.Enabled = false;
            txtCodigoImovel.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdEvento.Enabled = false;
            txtCodigoImovel.Focus();
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
            txtIdEvento.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtIdEvento.Focus();

            grdAgenda.Rows.Clear();
            LimpaAgenda();
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            try
            {
                psqEvento ofrm = new psqEvento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    // txtIdIptu.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdEvento.Enabled = true;
                    txtIdEvento.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtCodigoImovel.Text = EMCEventos.retPesquisa.chavebusca.ToString();

                    //txtCodigoImovel.Focus();
                    txtIdEvento.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaEvento()
        {
            if (!String.IsNullOrEmpty(txtIdEvento.Text))
            {

                Evento oEvento = new Evento();
                try
                {
                    EventoRN EventoBLL = new EventoRN(Conexao, objOcorrencia, codempresa);

                    //   oImovel = montaImovel();
                    oEvento.idEvento = Convert.ToInt32(txtIdEvento.Text);

                    oEvento = EventoBLL.ObterPor(oEvento);

                    if (oEvento.idEvento == 0)
                    {
                        DialogResult result = MessageBox.Show("Evento não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oEvento);
                        AtivaEdicao();
                        txtCodigoImovel.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Evento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdEvento.Focus();

        }

        public override void SalvaObjeto()
        {
            try
            {
                Evento oEvento = new Evento();
                EventoRN oEventoBLL = new EventoRN(Conexao, objOcorrencia, codempresa);

                lblSituacao.Text = "R";

                string vFlag = "I";

                foreach (DataGridViewRow oRow in grdAgenda.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idevt_evento"].Value.ToString()) == EmcResources.cInt(txtIdEvento.Text))
                    {
                        oRow.Cells["status"].Value = vFlag;
                    }
                    txtIdEvento.Focus();
                }

                oEvento = montaEvento();
                oEvento.statusEvento = "R";

                oEventoBLL.Salvar(oEvento);
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
                Evento oEvento = new Evento();
                EventoRN oEventoBLL = new EventoRN(Conexao, objOcorrencia, codempresa);

                string vFlag = "A";

                //Atribui valores
                DateTime dataInicio = Convert.ToDateTime(txtDataInicio.Text);
                DateTime dataFinal = Convert.ToDateTime(txtDataFinal.Text);
                //Geração de Parcelas   
                DateTime xData = Convert.ToDateTime(dataInicio);

                foreach (DataGridViewRow oRow in grdAgenda.Rows)
                {
                    DateTime dataGr = xData;
                    if (EmcResources.cInt(oRow.Cells["idevt_evento"].Value.ToString()) == EmcResources.cInt(txtIdEvento.Text))
                    {
                        if (dataGr == Convert.ToDateTime(oRow.Cells["dataagenda"].Value.ToString()))
                        {
                            oRow.Cells["status"].Value = vFlag;
                            oRow.Cells["dataagenda"].Value = dataGr;
                            oRow.Cells["idevt_evento"].Value = txtIdEvento.Text;
                            oRow.Cells["codigoimovel"].Value = txtCodigoImovel.Text;
                            oRow.Cells["descricao"].Value = txtDescricaoEvento.Text;
                            oRow.Cells["statusevento"].Value = "R";
                        }
                        xData = xData.AddDays(1);
                    }
                }

                oEvento = montaEvento();
                oEvento.statusEvento = "R";

                oEventoBLL.Atualizar(oEvento);
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
                Evento oEvento = new Evento();
                EventoRN oEventoBLL = new EventoRN(Conexao, objOcorrencia, codempresa);

                string vFlag = "E";

                foreach (DataGridViewRow oRow in grdAgenda.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idevt_evento"].Value.ToString()) == EmcResources.cInt(txtIdEvento.Text))
                    {
                        oRow.Cells["status"].Value = vFlag;
                    }
                    txtIdEvento.Focus();
                }

                oEvento = montaEvento();

                oEvento.statusEvento = "";
                oEventoBLL.Excluir(oEvento);
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
                Relatorios.relAgenda ofrm = new Relatorios.relAgenda(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid Evento ***********************************************************************************************"

        private void gerarEvento()
        {
            try
            {
                Boolean encontrou = false;

                foreach (DataGridViewRow oRow in grdAgenda.Rows)
                {
                    if (txtCodigoImovel.Text == oRow.Cells["codigoimovel"].Value.ToString() && Convert.ToDateTime(txtDataInicio.Text) == Convert.ToDateTime(oRow.Cells["dataagenda"].Value.ToString()))
                    {
                        MessageBox.Show("Imóvel já cadastrado para esta data", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        encontrou = true;
                        LimpaCampos();
                        txtCodigoImovel.Focus();
                    }
                }
                if (!encontrou)
                {
                    Evento oEvento = new Evento();

                    grdAgenda.Rows.Clear();

                    //Atribui valores
                    DateTime dataInicio = Convert.ToDateTime(txtDataInicio.Text);
                    DateTime dataFinal = Convert.ToDateTime(txtDataFinal.Text);

                    //Geração de Parcelas   
                    DateTime xData = Convert.ToDateTime(dataInicio);

                    while (xData <= dataFinal)
                    {
                        DateTime dataGravar = xData;

                        grdAgenda.Rows.Add("", dataGravar, txtCodigoImovel.Text, txtDescricaoEvento.Text, "R", "");

                        xData = xData.AddDays(1);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Dados Inválidos", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdAgenda_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIdEvento.Text = grdAgenda.Rows[grdAgenda.CurrentRow.Index].Cells["idevt_evento"].Value.ToString();
                BuscaEvento();

                txtCodigoImovel.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }     

        private void AtualizaGridAgenda(Agenda objAgenda)
        {

            List<Agenda> listaAgenda = new List<Agenda>();
            AgendaRN objAgendaRN = new AgendaRN(Conexao, objOcorrencia, codempresa);

            listaAgenda = objAgendaRN.LstAgendaGrid(EmcResources.cInt(txtIdEvento.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text, txtDataInicio.DateValue, txtDataFinal.DateValue);

            foreach (Agenda oAgenda in listaAgenda)
            {
                //grdAgenda.Rows.Add("", oAgenda.evento.idEvento, oAgenda.dataAgenda, oAgenda.imovel.codigoImovel, oAgenda.evento.descricao, oAgenda.situacao, oAgenda.idAgenda);
                grdAgenda.Rows.Add(oAgenda.evento.idEvento, oAgenda.dataAgenda, oAgenda.imovel.codigoImovel, oAgenda.evento.descricao, oAgenda.situacao, oAgenda.idAgenda);

                cldCalendario.AddBoldedDate(oAgenda.dataAgenda);
                cldCalendario.UpdateBoldedDates();
            }

            //grdIptu.ScrollBars = ScrollBars.Both; 
        }
        
        private void LimpaAgenda()
        {
            List<Agenda> listaAgenda = new List<Agenda>();
            AgendaRN objAgendaRN = new AgendaRN(Conexao, objOcorrencia, codempresa);

            listaAgenda = objAgendaRN.LstAgendaGrid(EmcResources.cInt(txtIdEvento.Text), EmcResources.cInt(txtIdImovel.Text), txtCodigoImovel.Text, txtDataInicio.DateValue, txtDataFinal.DateValue);

            foreach (Agenda oAgenda in listaAgenda)
            {
                cldCalendario.RemoveBoldedDate(oAgenda.dataAgenda);
                cldCalendario.UpdateBoldedDates();
            }
        }

        private void VerificarAgenda()
        {
            try
            {
                Agenda oAgenda = new Agenda();
                Boolean encontrou = false;

                List<Agenda> listaAgenda = new List<Agenda>();
                AgendaRN objAgendaRN = new AgendaRN(Conexao, objOcorrencia, codempresa);

                DateTime dataInicio = Convert.ToDateTime(txtDataInicio.Text);
                DateTime dataFinal = Convert.ToDateTime(txtDataFinal.Text);

                DateTime xData = Convert.ToDateTime(dataInicio);


                while (xData <= dataFinal)
                {
                    foreach (DataGridViewRow oRow in grdAgenda.Rows)
                    {
                        if (txtCodigoImovel.Text == oRow.Cells["codigoimovel"].Value.ToString() && xData == Convert.ToDateTime(oRow.Cells["dataagenda"].Value.ToString()))
                        {
                            MessageBox.Show("Imóvel já cadastrado para esta data", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            encontrou = true;
                            LimpaCampos();
                            txtCodigoImovel.Focus();
                        }
                    }
                    xData = xData.AddDays(1);
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }

        }

        private void cldCalendario_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                Agenda objAgenda = new Agenda();
                List<Agenda> listaAgenda = new List<Agenda>();
                AgendaRN objAgendaRN = new AgendaRN(Conexao, objOcorrencia, codempresa);

                listaAgenda = objAgendaRN.ListaCalendario(cldCalendario.SelectionStart);
                
                grdAgenda.Rows.Clear();
                cldCalendario.RemoveAllBoldedDates();
                cldCalendario.UpdateBoldedDates();
                LimpaCampos();

                foreach (Agenda oAgenda in listaAgenda)
                {
                    grdAgenda.Rows.Add(oAgenda.evento.idEvento, oAgenda.dataAgenda, oAgenda.imovel.codigoImovel, oAgenda.evento.descricao, oAgenda.situacao, oAgenda.idAgenda);

                    cldCalendario.AddBoldedDate(cldCalendario.SelectionStart);
                    cldCalendario.UpdateBoldedDates();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void AtualizarCalendario()
        {
            try
            {                
                List<Agenda> listaAgenda = new List<Agenda>();
                AgendaRN objAgendaRN = new AgendaRN(Conexao, objOcorrencia, codempresa);

                listaAgenda = objAgendaRN.ListaCalendario(cldCalendario.TodayDate);


                grdAgenda.Rows.Clear();
                cldCalendario.RemoveAllBoldedDates();
                cldCalendario.UpdateBoldedDates();
                LimpaCampos();

                foreach (Agenda oAgenda in listaAgenda)
                {
                    grdAgenda.Rows.Add(oAgenda.evento.idEvento, oAgenda.dataAgenda, oAgenda.imovel.codigoImovel, oAgenda.evento.descricao, oAgenda.situacao, oAgenda.idAgenda);

                    cldCalendario.AddBoldedDate(cldCalendario.TodayDate);
                    cldCalendario.UpdateBoldedDates();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }        

        #endregion

        #region "Botões de Pesquisa  ****************************************************************************************************"

        private void txtIdEvento_Validating(object sender, CancelEventArgs e)
        {
            BuscaEvento();
        }

        private void txtDataFinal_Validating(object sender, CancelEventArgs e)
        {
            VerificarAgenda();
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
                //Evento objEvento = new Evento();     
                Agenda objAgenda = new Agenda();

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

                        grdAgenda.Rows.Clear();
                        LimpaAgenda();
                        AtualizaGridAgenda(objAgenda);
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

        #region "Botões do Evento  ******************************************************************************************************"
        
        private void btnGerarEvento_Click(object sender, EventArgs e)
        {
            gerarEvento();
        }        

        private void btnAtualizarAgenda_Click(object sender, EventArgs e)
        {
            grdAgenda.Rows.Clear();

            Agenda objAgenda = new Agenda();
            AtualizaGridAgenda(objAgenda);

        }
        #endregion

    }
}
