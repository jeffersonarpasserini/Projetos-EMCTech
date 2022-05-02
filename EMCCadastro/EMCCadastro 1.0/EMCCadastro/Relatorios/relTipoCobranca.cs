﻿using System;
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
   public partial class relTipoCobranca : EMCLibrary.tplRelatorio
      {
      private const string nomeFormulario = "relTipoCobranca";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relTipoCobranca(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }

      #region "Configurações do Form"

      private void relTipoCobranca_Load(object sender, EventArgs e)
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
         objOcorrencia.tabela = "tipocobranca";

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

         TipoCobranca oTipoCobranca = new TipoCobranca();

         try
            {

            //alimenta dataset do rpt com dados da consulta
            TipoCobrancaRN oBLL = new TipoCobrancaRN(Conexao, objOcorrencia,codempresa);

            //Montando Consulta SQL para o relatório
            string drpRelatorio = DataReport();

            this.dstTipoCobranca.Tables["MyTable"].Clear();
            this.dstTipoCobranca.Tables["MyTable"].Load(oBLL.ListaTipoCobranca(drpRelatorio).CreateDataReader());

            //verifica se encontrou registros a emitir
            if (this.dstTipoCobranca.Tables["MyTable"].Rows.Count == 0)
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

         //inicializa combo de ordenação
         //cboOrdenar.Items.Clear();
         ArrayList arr = new ArrayList();
         arr.Add(new popCombo("Código Tipo Cobrança", "1"));
         arr.Add(new popCombo("Descrição Tipo Cobrança", "2"));
         cboOrdenar.DataSource = arr;
         cboOrdenar.DisplayMember = "nome";
         cboOrdenar.ValueMember = "valor";
         }

      #endregion

      #region "Métodos Privados"

      private string DataReport()
         {

         StringBuilder strSQL = new StringBuilder();
         strSQL.Clear();
         strSQL.Append("Select * from TipoCobranca");
         strSQL.Append(" order by");
         //verifica se ordena por código ou descrição
         if (cboOrdenar.SelectedValue.ToString() == "1")
            strSQL.Append(" IdTipoCobranca");
         else
            strSQL.Append(" Descricao");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }

      #endregion
      }
   }