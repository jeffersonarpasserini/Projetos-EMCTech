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
using EMCSecurityRN;

namespace EMCFinanceiro.Relatorios
{
    public partial class relCentroCusto : EMCLibrary.tplRelatorio
    {

        private const string nomeFormulario = "relCentroCusto";
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

        public relCentroCusto()
        {
            InitializeComponent();
        }

        public relCentroCusto(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void relCentroCusto_Load(object sender, EventArgs e)
        {
            Parametro oParametro = new Parametro();
            ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
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
            objOcorrencia.tabela = "pagarrateio";

            this.LimpaCampos();
        }


    }
}
