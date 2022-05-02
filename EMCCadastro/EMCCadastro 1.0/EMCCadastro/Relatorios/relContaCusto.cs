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
    public partial class relContaCusto : EMCLibrary.tplRelatorio
    {
      private const string nomeFormulario = "relContaCusto";
      private const string nomeAplicativo = "EMCCadastro";
      private String usuario = "";
      private String login = "";
      private int codempresa = 0;
      private int empMaster = 0;
      ConectaBancoMySql Conexao;
      private Ocorrencia objOcorrencia = new Ocorrencia();


      public relContaCusto(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
         {
         usuario = idUsuario;
         login = seqLogin;
         codempresa = Convert.ToInt32(idEmpresa);
         empMaster = Convert.ToInt32(empmaster);
         Conexao = pConexao;
         InitializeComponent();
         }


      #region "Configurações do Form"

      private void relContaCusto_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "contacusto";

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

          ContaCusto oContaCusto = new ContaCusto();
          try
          {
              Empresa oEmpresa = new Empresa();
              oEmpresa.idEmpresa = codempresa;
              EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
              oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

              //alimenta dataset do rpt com dados da consulta
              ContaCustoRN oBLL = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

              //Montando Consulta SQL para o relatório
              string drpRelatorio = DataReport();

              //inicializa o DataTable
              this.dataSet1.Tables["MyTable"].Clear();
              //obtendo resultado da consulta SQL e carregando no DataTabl
              this.dataSet1.Tables["MyTable"].Load(oBLL.ListaContaCusto(drpRelatorio).CreateDataReader());
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

          //inicializa combo de ordenação
          //cboOrdenar.Items.Clear();
          ArrayList arr = new ArrayList();
          arr.Add(new popCombo("Analítica", "1"));
          arr.Add(new popCombo("Sintética", "2"));
          arr.Add(new popCombo("Todas", "3"));
          
          cboOrdenar1.DataSource = arr;
          cboOrdenar1.DisplayMember = "nome";
          cboOrdenar1.ValueMember = "valor";

          ArrayList arrMatriz = new ArrayList();
          arrMatriz.Add(new popCombo("Matrizes", "1"));
          arrMatriz.Add(new popCombo("Filiais", "2"));
          cboOrdenar2.DataSource = arrMatriz;
          cboOrdenar2.DisplayMember = "nome";
          cboOrdenar2.ValueMember = "valor";
          
      }

      #endregion
       
      #region "Métodos Privados"
          

      private string DataReport()
      {
          StringBuilder strSQL = new StringBuilder();

          strSQL.Clear();
          strSQL.Append("Select");
          strSQL.Append(" c.codigoconta, c.tipoconta, c.descricao, e.razaosocial");
          strSQL.Append(" as Matriz, f.razaosocial");
          strSQL.Append(" from contacusto c, empresa e, empresa f");
          strSQL.Append(" where e.idEmpresa = c.idMatriz");
          strSQL.Append(" and f.idEmpresa = c.idFilial");
          
          //verifica se ordena pelo código ou descrição do Índice
          //if (cboOrdenarIndice.SelectedValue.ToString() == "1")
            //  strSQL.Append(" H.IdHolding, GE.IdGrupoEmpresa, E.IdEmpresa, E.CNPJCPF");
          //else
            //  strSQL.Append(" H.NomeHolding, GE.NomeGrupoEmpresa, E.RazaoSocial, E.CNPJCPF");

          //retorna string com consulta SQL
          return strSQL.ToString();

      }

      #endregion

   
    }
}
