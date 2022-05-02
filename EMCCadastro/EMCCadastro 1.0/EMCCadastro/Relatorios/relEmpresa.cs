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
   public partial class relEmpresa : EMCLibrary.tplRelatorio
      {
      private const string nomeFormulario = "relEmpresa";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relEmpresa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }

      #region "Configurações do Form"

      private void relEmpresa_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "empresa";

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
            GrupoEmpresaRN oBLL = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);

            //Montando Consulta SQL para o relatório
            string drpRelatorio = DataReport();

            //inicializa o DataTable
            this.dataSet1.Tables["MyTable"].Clear();
            //obtendo resultado da consulta SQL e carregando no DataTable
            this.dataSet1.Tables["MyTable"].Load(oBLL.ListaGrupoEmpresa(drpRelatorio).CreateDataReader());
            //verifica se encontrou registros a emitir
            if (Convert.ToInt32(this.dataSet1.Tables["MyTable"].Rows.Count) == 0)
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
         //inicializa List com os Grupos a Emitir
         GrupoEmpresa oGrupoEmpresa = new GrupoEmpresa();
         GrupoEmpresaRN oGrupoEmpresaRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);
         lstGrupo.DataSource = oGrupoEmpresaRN.ListaGrupoEmpresa(oGrupoEmpresa);
         lstGrupo.DisplayMember = "nomegrupoempresa";
         lstGrupo.ValueMember = "idgrupoempresa";
         for (int i = 0; i < lstGrupo.Items.Count; i++)
            lstGrupo.SetItemChecked(i, true);

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
         if (lstGrupo.CheckedItems.Count == 0)
            {
            MessageBox.Show("Selecione ao menos um Grupo de Empresa a Emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
            }

         //se passou por todas as validações
         return true;
         }

      private string DataReport()
         {
         StringBuilder strSQL = new StringBuilder();

         string sGrupoComp = EmcResources.ReadObject(this.lstGrupo, EMCLibrary.EmcResources.TipoDados.Numerico, true);

         strSQL.Clear();
         strSQL.Append("Select");
	      strSQL.Append(" H.IdHolding, H.NomeHolding");
         strSQL.Append(", GE.IdGrupoEmpresa, GE.NomeGrupoEmpresa");
	      strSQL.Append(", E.idEmpresa, E.EmpMaster, E.RazaoSocial, E.NomeFantasia, E.CNPJCPF, E.InscrEstadual, E.InscrMunicipal");
	      strSQL.Append(", Concat(E.Endereco,  ' ', E.Numero) as Endereco, E.Bairro, E.Complemento, E.Cidade, E.Estado, E.idCEP, E.Telefone");
	      strSQL.Append(", If(E.MatrizFilial = 'M', 'Matriz', 'Filial') as MatrizFilial");
         strSQL.Append(", Concat(E.IdMatriz, '-', Ex.RazaoSocial) as EmpresaMatriz");
	      strSQL.Append(", Concat(H.IdHolding, '-', H.NomeHolding) as Grupo1");
	      strSQL.Append(", Concat(GE.IdGrupoEmpresa, '-', GE.NomeGrupoEmpresa) as Grupo2");
         strSQL.Append(" from");
	      strSQL.Append(" Holding H");
	      strSQL.Append(", GrupoEmpresa GE");
	      strSQL.Append(", Empresa E");
	      strSQL.Append(", Empresa Ex");
         strSQL.Append(" where");
	      strSQL.Append(" GE.Holding_IdHolding = H.idHolding");
	      strSQL.Append(" and E.IdGrupoEmpresa = GE.IdGrupoEmpresa");
	      strSQL.Append(" and Ex.IdEmpresa = E.IdMatriz");
         strSQL.Append(" order by ");
         //verifica se ordena pelo código ou descrição do Índice
         if (cboOrdenarIndice.SelectedValue.ToString() == "1")
            strSQL.Append(" H.IdHolding, GE.IdGrupoEmpresa, E.IdEmpresa, E.CNPJCPF");
         else
            strSQL.Append(" H.NomeHolding, GE.NomeGrupoEmpresa, E.RazaoSocial, E.CNPJCPF");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }

      #endregion

      
      }
   }



