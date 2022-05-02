using EMCCadastroModel;
using EMCCadastroRN;
using EMCImobModel;
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
using EMCImobRN;

namespace EMCImob.Relatorios
{
    public partial class relContratoProventos : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relContratoProventos";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0; 
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();
         
        public relContratoProventos(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relContratoProventos_Load(object sender, EventArgs e)
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
                   
                    this.dstLocacaoCCReceber.Tables["LocacaoCCReceber"].Clear();
                    this.dstLocacaoCCReceber.Tables["LocacaoCCReceber"].Load(oBLL.ListaCCReceber(txtDataInicial.DateValue, txtIdentificacaoContrato.Text).CreateDataReader());                                      
                                      

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstLocacaoCCReceber.Tables["LocacaoCCReceber"].Rows.Count) == 0)
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

                if (cboSelecionar.SelectedIndex == 1)
                {                    
                    this.dstLocacaoCCPagar.Tables["LocacaoCCPagar"].Clear();
                    this.dstLocacaoCCPagar.Tables["LocacaoCCPagar"].Load(oBLLPag.ListaCCPagar(txtDataInicial.DateValue, txtIdentificacaoContrato.Text).CreateDataReader());
                                     

                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstLocacaoCCPagar.Tables["LocacaoCCPagar"].Rows.Count) == 0)
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

          
        }      

        private void relContratoProventos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }
        
    }
}
