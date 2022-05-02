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
   public partial class relIndicePeríodo : EMCLibrary.tplRelatorio
  {
        private const string nomeFormulario = "relIndicePeriodo";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relIndicePeríodo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

      #region "Configurações do Form"

        private void relIndicePeriodo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Indice";

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

            //alimenta dataset do rpt com dados da consulta
            PessoaRN oBLL = new PessoaRN(Conexao, objOcorrencia,codempresa);

            //Montando Consulta SQL para o relatório
            string drpRelatorio = DataReport();

            //inicializa o DataTable
            this.dstIndice.Tables["MyTable"].Clear();
            //obtendo resultado da consulta SQL e carregando no DataTable
            this.dstIndice.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
            //verifica se encontrou registros a emitir
            if (Convert.ToInt32(this.dstIndice.Tables["MyTable"].Rows.Count) == 0)
            {
            MessageBox.Show("Não foram encontrados registros no Período Informado.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            }
            //passando parâmetros fixos
            report1.SetParameterValue("Periodo", "Período de " + txtDtaInicial.Text.ToString() + " a " + txtDtaFinal.Text.ToString());
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

           //Monta período a emitir com base nos 30 últimos dias
           txtDtaInicial.Text = DateTime.Today.AddMonths(-1).ToShortDateString();
           txtDtaFinal.Text = DateTime.Today.ToShortDateString();

           //inicializa List com os Índices a Emitir
           Indexador oIndexador = new Indexador();
           IndexadorRN oIndexadorRN = new IndexadorRN(Conexao,objOcorrencia,codempresa);
           lstIndice.DataSource = oIndexadorRN.ListaIndexador();
           lstIndice.DisplayMember = "descricao";
           lstIndice.ValueMember = "idindexador";
           for (int i = 0; i < lstIndice.Items.Count; i++)
              lstIndice.SetItemChecked(i, true);

           //inicializa combo de ordenação (Indices)
           ArrayList arr = new ArrayList();
           arr.Add(new popCombo("Código do Índice", "1"));
           arr.Add(new popCombo("Descricao do Índice", "2"));
           cboOrdenarIndice.DataSource = arr;
           cboOrdenarIndice.DisplayMember = "nome";
           cboOrdenarIndice.ValueMember = "valor";

           //inicializa combo de ordenação (Período)
           ArrayList arrPeriodo = new ArrayList();
           arrPeriodo.Add(new popCombo("Em Ordem Decrescente", "1"));
           arrPeriodo.Add(new popCombo("Em Ordem Crescente", "2"));
           cboOrdenarPeriodo.DataSource = arrPeriodo;
           cboOrdenarPeriodo.DisplayMember = "nome";
           cboOrdenarPeriodo.ValueMember = "valor";
        }

        #endregion

#region "Métodos Privados"

   private Boolean ValidaCampos()
   {
      //verfica se foi informada a Data Inicial
      if (String.IsNullOrEmpty(txtDtaInicial.Text.ToString()))
         {
         MessageBox.Show("A Data Inicial deve ser informada.",this.Text,MessageBoxButtons.OK,MessageBoxIcon.Warning);
         return false;
         }

      //verfica se foi informada a Data Final
      if (String.IsNullOrEmpty(txtDtaFinal.Text.ToString()))
         {
         MessageBox.Show("A Data Final deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return false;
         }

      //verifica se a Data Final é posterior à Data Inicial
      if (txtDtaFinal.Value < txtDtaInicial.Value)
         {
         MessageBox.Show("A Data Final deve ser Maior que a Data Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return false;
         }

      //verifica se informou algum índice a emitir
      if (lstIndice.CheckedItems.Count == 0)
         {
         MessageBox.Show("Selecione ao menos um Índice a Emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
         return false;
         }
      
      //se passou por todas as validações
      return true;
   }

      private string DataReport()
      {
      StringBuilder strSQL = new StringBuilder();
      
      string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
      
      strSQL.Clear();
      strSQL.Append("Select");
      strSQL.Append(" Id.IdIndices, Id.DataIndice, Id.Valor");
      strSQL.Append(", Idx.IdIndexador, Idx.Descricao");
      strSQL.Append(", Concat(Idx.IdIndexador, '-', Idx.Descricao) as Grupo1");
      strSQL.Append(" from");
      strSQL.Append(" Indices Id");
      strSQL.Append(", Indexador Idx");
      strSQL.Append(" where");
      strSQL.Append(" Id.IdIndexador in ("+ sIndexador + ")");
      strSQL.Append(" and Id.DataIndice between '" + txtDtaInicial.Value.Date.ToString("yyyy-MM-dd") + "' and '" + txtDtaFinal.Value.Date.ToString("yyyy-MM-dd") + "'");
      strSQL.Append(" and Idx.IdIndexador = Id.IdIndexador");
      strSQL.Append(" order by");
      //verifica se ordena pelo código ou descrição do Índice
      if (cboOrdenarIndice.SelectedValue.ToString() == "1")
         strSQL.Append(" Idx.IdIndexador");
      else
         strSQL.Append(" Idx.Descricao");

      //verifica se ordena pela data mais recente ou mais antiga
      if (cboOrdenarPeriodo.SelectedValue.ToString() == "1")
         strSQL.Append(", Id.DataIndice Desc");
      else
         strSQL.Append(", Id.DataIndice");

      //retorna string com consulta SQL
      return strSQL.ToString();

      }

      #endregion

     
  }
 }



