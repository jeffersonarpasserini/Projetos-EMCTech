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
   public partial class relCustoComponenteGrupo : EMCLibrary.tplRelatorio
      {
      private const string nomeFormulario = "relCustoComponenteGrupo";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relCustoComponenteGrupo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)

         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }

      #region "Configurações do Form"

      private void relCustoComponenteGrupo_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "custo_componentegrupo";

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

         if (ValidaCampos() == false)
            {
            return;
            }

         try
            {
            Empresa oEmpresa = new Empresa();
            oEmpresa.idEmpresa = codempresa;
            EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
            oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

            //alimenta dataset do rpt com dados da consulta
            PessoaRN oBLL = new PessoaRN(Conexao, objOcorrencia,codempresa);

            //Montando Consulta SQL para o relatório
            string drpRelatorio = DataReport();

            //inicializa o DataTable
            this.dstCustoComponenteGrupo.Tables["MyTable"].Clear();
            //obtendo resultado da consulta SQL e carregando no DataTable
            this.dstCustoComponenteGrupo.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
            //verifica se encontrou registros a emitir
            if (Convert.ToInt32(this.dstCustoComponenteGrupo.Tables["MyTable"].Rows.Count) == 0)
               {
               MessageBox.Show("Não foram encontrados registros a Emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
               }
            //passando parâmetros fixos
            report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
            //mostrando o relatório na tela
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

         //inicializa combo de ordenação (Indices)
         ArrayList arr = new ArrayList();
         arr.Add(new popCombo("Ordem de Código", "1"));
         arr.Add(new popCombo("Ordem Alfabética", "2"));
         cboOrdenar.DataSource = arr;
         cboOrdenar.DisplayMember = "nome";
         cboOrdenar.ValueMember = "valor";

         }

      #endregion

      #region "Métodos Privados"

      private Boolean ValidaCampos()
         {
         //se passou por todas as validações
         return true;
         }

      private string DataReport()
         {
         StringBuilder strSQL = new StringBuilder();

         strSQL.Clear();
         strSQL.Append("Select");
         strSQL.Append(" IdCusto_ComponenteGrupo, Descricao");
         strSQL.Append(" from");
         strSQL.Append(" Custo_ComponenteGrupo");
         strSQL.Append(" order by");
         //verifica se ordena pelo código ou descrição do Índice
         if (cboOrdenar.SelectedValue.ToString() == "1")
            strSQL.Append(" IdCusto_ComponenteGrupo");
         else
            strSQL.Append(" Descricao");

         //retorna string com consulta SQL
         return strSQL.ToString();
         }

      #endregion
      }
   }
