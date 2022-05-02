using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;
using EMCLibrary;
using EMCObrasRN;
using EMCCadastro;
using EMCCadastroRN;
using EMCObrasModel;
using EMCCadastroModel;

namespace EMCObras.Relatorios
{
    public partial class relOrcamentoObra : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relOrcamentoObra";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public relOrcamentoObra(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relOrcamentoObra_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_previsaodespesa";

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        private void relOrcamentoObra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                Obra_PrevisaoDespesaRN oBLL = new Obra_PrevisaoDespesaRN(Conexao, objOcorrencia, codempresa);
                string drpRelatorio;

                if (String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
                {
                    MessageBox.Show("Obra não Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) && (!String.IsNullOrEmpty(txtidObra_Etapa.Text)) && (!String.IsNullOrEmpty(txtidObra_Modulo.Text)) && (!String.IsNullOrEmpty(txtidObra_Tarefas.Text)))
                {
                    if (rdSintetico.Checked)
                    {
                        drpRelatorio = oBLL.SinteticoObraEtapaModulo(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text), EmcResources.cInt(txtidObra_Modulo.Text));
                        this.dstOrcamentoObra.Tables["MyTable"].Clear();
                        this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                        {
                            MessageBox.Show("Registros não encontrados para os dados informados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        SinteticoObraEtapaModulo.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        SinteticoObraEtapaModulo.Show();
                    }
                    else

                        if (rdAnalitico.Checked)
                        {
                            drpRelatorio = oBLL.AnaliticoObraEtapaModuloTarefa(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text), EmcResources.cInt(txtidObra_Modulo.Text), EmcResources.cInt(txtidObra_Tarefas.Text));
                            this.dstOrcamentoObra.Tables["MyTable"].Clear();
                            this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                            if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                            {
                                MessageBox.Show("Registros não encontrados para dados encontrados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            AnaliticoObraEtapaModulo.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                            AnaliticoObraEtapaModulo.Show();
                        }
                }
                else
                if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) && (!String.IsNullOrEmpty(txtidObra_Etapa.Text)) && (!String.IsNullOrEmpty(txtidObra_Modulo.Text)))
                {
                    if (rdSintetico.Checked)
                    {
                        drpRelatorio = oBLL.SinteticoObraEtapaModulo(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text), EmcResources.cInt(txtidObra_Modulo.Text));
                        this.dstOrcamentoObra.Tables["MyTable"].Clear();
                        this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                        {
                            MessageBox.Show("Registros não encontrados para dados informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        SinteticoObraEtapaModulo.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        SinteticoObraEtapaModulo.Show();
                    }
                    else

                        if (rdAnalitico.Checked)
                        {
                            drpRelatorio = oBLL.AnaliticoObraEtapaModulo(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text), EmcResources.cInt(txtidObra_Modulo.Text));
                            this.dstOrcamentoObra.Tables["MyTable"].Clear();
                            this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                            if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                            {
                                MessageBox.Show("Registros não encontrados para os dados informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            AnaliticoObraEtapaModulo.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                            AnaliticoObraEtapaModulo.Show();
                        }
                }
                else

                    if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) && (!String.IsNullOrEmpty(txtidObra_Etapa.Text)))
                    {
                        if (rdSintetico.Checked)
                        {
                            drpRelatorio = oBLL.SinteticoObraEtapa(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text));
                            this.dstOrcamentoObra.Tables["MyTable"].Clear();
                            this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                            if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                            {
                                MessageBox.Show("Registros não encontrados para os dados informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            SinteticoObraEtapa.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                            SinteticoObraEtapa.Show();
                        }
                        else
                          
                            if (rdAnalitico.Checked)
                            {
                                drpRelatorio = oBLL.AnaliticoObraEtapa(EmcResources.cInt(txtIdObra_Cronograma.Text), EmcResources.cInt(txtidObra_Etapa.Text));
                                this.dstOrcamentoObra.Tables["MyTable"].Clear();
                                this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                                if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                                {
                                    MessageBox.Show("Registros não encontrados para os dados informados.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                AnaliticoObraEtapa.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                                AnaliticoObraEtapa.Show();
                            }
                    }
                    else
                        if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
                        {
                            if (rdSintetico.Checked)
                            {
                                drpRelatorio = oBLL.SinteticoObra(EmcResources.cInt(txtIdObra_Cronograma.Text));
                                this.dstOrcamentoObra.Tables["MyTable"].Clear();
                                this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                                if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                                {
                                    MessageBox.Show("Registros não encontrados para Obra Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                OrcamentoObra.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                                OrcamentoObra.Show();
                            }
                            else

                                if (rdAnalitico.Checked)
                                {
                                    drpRelatorio = oBLL.AnaliticoObra(EmcResources.cInt(txtIdObra_Cronograma.Text));
                                    this.dstOrcamentoObra.Tables["MyTable"].Clear();
                                    this.dstOrcamentoObra.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                                    if (Convert.ToInt32(this.dstOrcamentoObra.Tables["MyTable"].Rows.Count) == 0)
                                    {
                                        MessageBox.Show("Registros não encontrados para Obra Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                    OrcamentoObraItens.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                                    OrcamentoObraItens.Show();
                                }
                        }
            }


            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
         }
    
        private void btnBuscaObra_Click(object sender, EventArgs e)
        {
            try
            {
                psqObra ofrm = new psqObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtAbreviacao.Enabled = true;
                    txtIdObra_Cronograma.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                    txtAbreviacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) || !String.IsNullOrEmpty(txtAbreviacao.Text))
            {
                Obra oObra = new Obra();
                oObra.abreviacao = txtAbreviacao.Text;

                try
                {

                    ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
                                      

                    oObra = oObraRN.obterPor(oObra);
                    oObra.idObra_Cronograma = EmcResources.cInt(txtIdObra_Cronograma.Text);
                    txtAbreviacao.Text = oObra.abreviacao;
                    txtDescricaoObra.Text = oObra.descricao;
                    if (oObra.situacao == "A")
                        txtSituacao.Text = "Aberto";
                    else if (oObra.situacao == "E")
                        txtSituacao.Text = "Encerrado";
                    else if (oObra.situacao == "L")
                        txtSituacao.Text = "Aprovado";

                    if (txtDescricaoObra == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscaEtapa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
            {
                MessageBox.Show("Obra não informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                psqObraEtapa ofrm = new psqObraEtapa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Etapa.Enabled = true;
                    txtidObra_Etapa.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Etapa.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtidObra_Etapa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdObra_Cronograma.Text))
            {
                MessageBox.Show("Obra não Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            
            if (!String.IsNullOrEmpty(txtidObra_Etapa.Text))
            
                try
                {
                    Obra_Etapa oObraEtapa = new Obra_Etapa();

                    Obra_EtapaRN oObraEtapaRN = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);

                    oObraEtapa.idobra_etapa = EmcResources.cInt(txtidObra_Etapa.Text);

                    oObraEtapa = oObraEtapaRN.ObterPor(oObraEtapa);

                    txtDescricaoEtapa.Text = oObraEtapa.descricao;

                    if (txtDescricaoEtapa == null)
                    {

                    }
                }

                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
    
        private void btnBuscaModulo_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Etapa.Text))
            {
                MessageBox.Show("Etapa não informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            try
            {
                psqObraModulo ofrm = new psqObraModulo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Modulo.Enabled = true;
                    txtidObra_Modulo.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Modulo.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtidObra_Modulo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Etapa.Text))
            {
                MessageBox.Show("Etapa não Informada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!String.IsNullOrEmpty(txtidObra_Modulo.Text))
                try
                {
                    Obra_Modulo oObraModulo = new Obra_Modulo();

                    Obra_ModuloRN oObraModuloRN = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);

                    oObraModulo.idobra_modulo = EmcResources.cInt(txtidObra_Modulo.Text);

                    oObraModulo = oObraModuloRN.ObterPor(oObraModulo);

                    txtDescricaoModulo.Text = oObraModulo.descricao;

                    if (txtDescricaoModulo == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        private void btnBuscaTarefa_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Modulo.Text))
            {
                MessageBox.Show("Módulo não informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                psqObraTarefa ofrm = new psqObraTarefa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Tarefas.Enabled = true;
                    txtidObra_Tarefas.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Tarefas.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtidObra_Tarefas_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Modulo.Text))
            {
                MessageBox.Show("Módulo não Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!String.IsNullOrEmpty(txtidObra_Tarefas.Text))
                try
                {
                    Obra_Tarefa oObraTarefa = new Obra_Tarefa();

                    Obra_TarefaRN oObraTarefaRN = new Obra_TarefaRN(Conexao, objOcorrencia, codempresa);

                    oObraTarefa.idobra_tarefas = EmcResources.cInt(txtidObra_Tarefas.Text);

                    oObraTarefa = oObraTarefaRN.ObterPor(oObraTarefa);

                    txtDescricaoTarefa.Text = oObraTarefa.descricao;

                    if (txtDescricaoTarefa == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            

        }

     }
}
