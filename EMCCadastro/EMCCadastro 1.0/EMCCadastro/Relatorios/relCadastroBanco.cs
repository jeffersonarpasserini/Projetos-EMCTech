using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;

namespace EMCCadastro.Relatorios
{
    public partial class relCadastroBanco : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relCadastroBanco";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


    public relCadastroBanco(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
    {
        usuario = idUsuario;
        login = seqLogin;
        codempresa = Convert.ToInt32(idEmpresa);
        empMaster = Convert.ToInt32(empmaster);
        Conexao = pConexao;
        InitializeComponent();
    }

   #region "Configurações do Form"

      private void relCadastroBanco_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "banco";

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

         Banco oBanco = new Banco();

         try
         {

               //alimenta dataset do rpt com dados da consulta
               BancoRN oBLL = new BancoRN(Conexao, objOcorrencia,codempresa);
               oBanco.ordem = Convert.ToString(cboOrdenar.SelectedValue);

               this.dstCadastroBanco.Tables["MyTable"].Clear();
               this.dstCadastroBanco.Tables["MyTable"].Load(oBLL.ListaBanco(oBanco).CreateDataReader());
               report1.Show();

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
         //limpa os campos do formulário
         base.LimpaCampos();

         //inicializa combo de ordenação
         //cboOrdenar.Items.Clear();
         ArrayList arr = new ArrayList();
         arr.Add(new popCombo("Nro do Banco", "1"));
         arr.Add(new popCombo("Nome do Banco", "2"));
         cboOrdenar.DataSource = arr;
         cboOrdenar.DisplayMember = "nome";
         cboOrdenar.ValueMember = "valor";
      }

      #endregion

   #region "Métodos para Tratamento das Informações"

      #endregion

    }
}
