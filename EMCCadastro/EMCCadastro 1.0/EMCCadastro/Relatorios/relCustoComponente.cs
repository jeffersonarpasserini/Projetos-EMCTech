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
   public partial class relCustoComponente : EMCLibrary.tplRelatorio
      {
      private const string nomeFormulario = "relCustoComponente";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relCustoComponente(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }

      #region "Configurações do Form"

      private void relCustoComponente_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "custo_componente";

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
            this.dstCustoComponente.Tables["MyTable"].Clear();
            //obtendo resultado da consulta SQL e carregando no DataTable
            this.dstCustoComponente.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
            //verifica se encontrou registros a emitir
            if (Convert.ToInt32(this.dstCustoComponente.Tables["MyTable"].Rows.Count) == 0)
               {
               MessageBox.Show("Não foram encontrados registros a Emitir.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

         //inicializa List com os Grupos a Emitir
         Custo_ComponenteGrupo oCCGrupo = new Custo_ComponenteGrupo();
         Custo_ComponenteGrupoRN oCCGrupoRN = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
         lstComponente.DataSource = oCCGrupoRN.ListaCusto_ComponenteGrupo();
         lstComponente.DisplayMember = "descricao";
         lstComponente.ValueMember = "idcusto_componentegrupo";
         for (int i = 0; i < lstComponente.Items.Count; i++)
            lstComponente.SetItemChecked(i, true);

         //inicializa combo de ordenação (Indices)
         ArrayList arr = new ArrayList();
         arr.Add(new popCombo("Ordem de Código", "1"));
         arr.Add(new popCombo("Ordem Alfabética", "2"));
         cboOrdenarIndice.DataSource = arr;
         cboOrdenarIndice.DisplayMember = "nome";
         cboOrdenarIndice.ValueMember = "valor";
         }

      #endregion

      #region "Métodos Privados"

      private Boolean ValidaCampos()
         {
         //verifica se informou algum grupo a emitir
         if (lstComponente.CheckedItems.Count == 0)
            {
            MessageBox.Show("Selecione ao menos um Grupo de Componente a Emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
            }

         //se passou por todas as validações
         return true;
         }

      private string DataReport()
         {
         StringBuilder strSQL = new StringBuilder();

         string sGrupoComp = EmcResources.ReadObject(this.lstComponente, EMCLibrary.EmcResources.TipoDados.Numerico, true);

         strSQL.Clear();
         strSQL.Append("Select");
         strSQL.Append(" CC.IdCusto_Componente, CC.Descricao as DescrComponente");
         strSQL.Append(", CG.IdCusto_ComponenteGrupo, CG.Descricao as DescrGrupo");
         strSQL.Append(", Concat(CG.IdCusto_ComponenteGrupo, '-', CG.Descricao) as Grupo1");
         strSQL.Append(" from");
         strSQL.Append(" Custo_ComponenteGrupo CG");
         strSQL.Append(", Custo_Componente CC");
         strSQL.Append(" where");
         strSQL.Append(" CG.IdCusto_ComponenteGrupo in (" + sGrupoComp + ")");
         strSQL.Append(" and CC.IdGrupo_Componente = CG.IdCusto_ComponenteGrupo");
         strSQL.Append(" order by");
         //verifica se ordena pelo código ou descrição do Índice
         if (cboOrdenarIndice.SelectedValue.ToString() == "1")
            strSQL.Append(" CG.IdCusto_ComponenteGrupo, CC.IdCusto_Componente");
         else
            strSQL.Append(" CG.Descricao, CG.IdCusto_ComponenteGrupo, CC.Descricao, CC.IdCusto_Componente");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }

      #endregion
      }
   }



