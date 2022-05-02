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
   public partial class relCtaBancaria : EMCLibrary.tplRelatorio
      {
      private const string nomeFormulario = "relCtaBancaria";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relCtaBancaria(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }

      #region "Configurações do Form"

      private void relCtaBancaria_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "ctabancaria";

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

         CtaBancaria oTipoCobranca = new CtaBancaria();

         try
            {

            //alimenta dataset do rpt com dados da consulta
            CtaBancariaRN oBLL = new CtaBancariaRN(Conexao, objOcorrencia,codempresa);

            //Montando Consulta SQL para o relatório
            string drpRelatorio = DataReport();

            this.dstCtaBancaria.Tables["MyTable"].Clear();
            this.dstCtaBancaria.Tables["MyTable"].Load(oBLL.ListaCtaBancaria(drpRelatorio).CreateDataReader());

            //verifica se encontrou registros a emitir
            if (this.dstCtaBancaria.Tables["MyTable"].Rows.Count == 0)
               {
               MessageBox.Show("Não foram encontrados registros a emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
               return;
               }
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

         //inicializa combo de agrupamento
         ArrayList arr = new ArrayList();
         arr.Add(new popCombo("Nome do Banco", "1"));
         arr.Add(new popCombo("Código do Banco", "2"));
         cboAgrupar.DataSource = arr;
         cboAgrupar.DisplayMember = "nome";
         cboAgrupar.ValueMember = "valor";

         //inicializa combo de ordenação
         ArrayList arrOrd = new ArrayList();
         arrOrd.Add(new popCombo("Descrição Cta Bancária", "1"));
         arrOrd.Add(new popCombo("Número da Cta Bancária", "2"));
         cboOrdenar.DataSource = arrOrd;
         cboOrdenar.DisplayMember = "nome";
         cboOrdenar.ValueMember = "valor";

         //monta CheckedListBox com Bancos a Emitir
         Banco oBanco = new Banco();
         BancoRN oBancoRN = new BancoRN(Conexao, objOcorrencia,codempresa);
         lstBanco.DataSource = oBancoRN.ListaBanco(oBanco);
         lstBanco.DisplayMember = "descricao";
         lstBanco.ValueMember = "idbanco";
         for (int i = 0; i < lstBanco.Items.Count; i++)
            lstBanco.SetItemChecked(i, true);

         }

      #endregion

      #region "Métodos Privados"

      private string DataReport()
         {

         StringBuilder strSQL = new StringBuilder();
         string sBanco = EmcResources.ReadObject(this.lstBanco, EMCLibrary.EmcResources.TipoDados.Numerico, true);
      
         strSQL.Clear();
         strSQL.Append("Select");
         strSQL.Append(" CB.*");
         strSQL.Append(", B.Descricao as DescrBanco");
         strSQL.Append(", Concat(B.IdBanco, '-', B.Descricao) as Grupo1");
         strSQL.Append(" from");
         strSQL.Append(" CtaBancaria CB");
         strSQL.Append(", Banco B");
         strSQL.Append(" where");
         strSQL.Append(" CB.IdEmpresa = " + codempresa);
         strSQL.Append(" and CB.IdBanco in (" + sBanco +")");
         strSQL.Append(" and B.IdBanco = CB.IdBanco");
         strSQL.Append(" order by");
         //verifica se ordena por código ou nome do banco
         if (cboAgrupar.SelectedValue.ToString() == "1")
            strSQL.Append(" B.Descricao");
         else
            strSQL.Append(" B.IdBanco");

         //verifica se ordena por código ou nome da Conta
         if (cboAgrupar.SelectedValue.ToString() == "1")
            strSQL.Append(", CB.Descricao, CB.Agencia, CB.Conta");
         else
            strSQL.Append(",CB.Agencia, CB.Conta, CB.Descricao");

         //retorna string com consulta SQL
         return strSQL.ToString();
         }

      #endregion
      }
   }
