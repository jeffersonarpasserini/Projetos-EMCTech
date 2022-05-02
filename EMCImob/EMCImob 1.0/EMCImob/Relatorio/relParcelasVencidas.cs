using EMCCadastroModel;
using EMCCadastroRN;
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

namespace EMCImob.Relatorios
{
    public partial class relParcelasVencidas : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relParcelasVencidas";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();
         
        public relParcelasVencidas(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relParcelasVencidas_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "locacaocontrato";



            //chama método para inicializar os campos do formulário
            this.LimpaCampos();

            txtDataInicial.DateValue = DateTime.Now;
        }

        #endregion

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboSelecionar.SelectedIndex == 0)
                listaPorLocatario();
            else if (cboSelecionar.SelectedIndex == 1)
                listaPorLocador();
        }

        private void listaPorLocatario()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                LocacaoReceberRN oBLL = new LocacaoReceberRN(Conexao, objOcorrencia, codempresa);
                

                if (cboSelecionar.SelectedIndex == 0)
                {
                    this.dstLocacaoReceber.Tables["LocacaoReceber"].Clear();                   
                    this.dstLocacaoReceber.Tables["LocacaoReceber"].Load(oBLL.ListaLocatario(txtDataInicial.DateValue).CreateDataReader());

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstLocacaoReceber.Tables["LocacaoReceber"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptLocatario.SetParameterValue("Periodo", txtDataInicial.Text);
                    rptLocatario.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptLocatario.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaPorLocador()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);
       
                LocacaoPagarRN oBLLPag = new LocacaoPagarRN(Conexao, objOcorrencia, codempresa);

                //string drpRelatorio;

                if (cboSelecionar.SelectedIndex == 1)
                {
                   
                    this.dstLocacaoPagar.Tables["LocacaoPagar"].Clear();
                    this.dstLocacaoPagar.Tables["LocacaoPagar"].Load(oBLLPag.ListaLocador(txtDataInicial.DateValue).CreateDataReader());

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstLocacaoPagar.Tables["LocacaoPagar"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptLocador.SetParameterValue("Periodo", txtDataInicial.Text);
                    rptLocador.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptLocador.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private Boolean ValidaCampos()
        {
            if (String.IsNullOrEmpty(txtDataInicial.Text.ToString()))
            {
                MessageBox.Show("A Data Inicial deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();

            //inicializa combo de ordenação 

            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("POR LOCATÁRIO", "1"));
            arr.Add(new popCombo("POR LOCADOR ", "2"));
            cboSelecionar.DataSource = arr;
            cboSelecionar.DisplayMember = "nome";
            cboSelecionar.ValueMember = "valor";

            grdParcelas.Rows.Clear();
        }

        private void btnBuscarParcelas_Click(object sender, EventArgs e)
        {
            pesquisaParcela();

        }
        public void pesquisaParcela()
        {
            try
            {
                if (cboSelecionar.SelectedIndex == 0)
                {
                    List<LocacaoReceber> lstLocReceber = new List<LocacaoReceber>();
                    LocacaoReceberRN oLocacaoReceberRN = new LocacaoReceberRN(Conexao, objOcorrencia, codempresa);

                    lstLocReceber = oLocacaoReceberRN.listaLocReceber(EmcResources.cInt(usuario), codempresa,
                                                                      EmcResources.cInt(txtIdLocatario.Text),
                                                                      Convert.ToDateTime(txtDataInicial.DateValue));


                    if (lstLocReceber.Count > 0)
                    {
                        grdParcelas.Rows.Clear();
                        foreach (LocacaoReceber oLocReceber in lstLocReceber)
                        {

                            grdParcelas.Rows.Add(oLocReceber.idLocacaoReceber, 0, oLocReceber.contrato.idLocacaoContrato, oLocReceber.contrato.identificacaoContrato, oLocReceber.nroParcela, oLocReceber.valorParcela, oLocReceber.dataVencimento,
                                                      oLocReceber.locatario.pessoa.nome, oLocReceber.locatario.idPessoa, 0, "");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foram encontradas parcelas em aberto para o fornecedor", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }

                else if (cboSelecionar.SelectedIndex == 1)
                {
                    List<LocacaoPagar> lstLocPagar = new List<LocacaoPagar>();
                    LocacaoPagarRN oLocacaoPagarRN = new LocacaoPagarRN(Conexao, objOcorrencia, codempresa);

                    lstLocPagar = oLocacaoPagarRN.listaLocPagar(EmcResources.cInt(usuario), codempresa,
                                                                      EmcResources.cInt(txtIdLocador.Text),
                                                                      Convert.ToDateTime(txtDataInicial.DateValue));

                    if (lstLocPagar.Count > 0)
                    {
                        grdParcelas.Rows.Clear();
                        foreach (LocacaoPagar oLocPagar in lstLocPagar)
                        {

                            grdParcelas.Rows.Add(0, oLocPagar.idLocacaoPagar, oLocPagar.contrato.idLocacaoContrato, oLocPagar.contrato.identificacaoContrato, oLocPagar.nroParcela, oLocPagar.valorParcela, oLocPagar.dataVencimento,
                                                  oLocPagar.locador.pessoa.nome, 0, oLocPagar.locador.idPessoa, "", 0);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foram encontradas parcelas em aberto para o fornecedor", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void relParcelasVencidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        
    }
}
