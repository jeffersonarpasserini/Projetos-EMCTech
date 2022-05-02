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
    public partial class relPessoa : EMCLibrary.tplRelatorio
  {
        private const string nomeFormulario = "relPessoa";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relPessoa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

      #region "Configurações do Form"

        private void relPessoa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Pessoa";

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

            
            try
            {

               Empresa oEmpresa = new Empresa();
               oEmpresa.idEmpresa = codempresa;
               EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
               oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

               //alimenta dataset do rpt com dados da consulta
               PessoaRN oBLL = new PessoaRN(Conexao, objOcorrencia,codempresa);

               switch (this.cboLayout.SelectedValue.ToString())
                  {
                  case "1":
                        //Montando Consulta SQL para o relatório
                        string drpRelatorio = DataReportGeral();
                        //inicializa o DataTable
                        this.dstPessoa.Tables["MyTable"].Clear();
                        //obtendo resultado da consulta SQL e carregando no DataTable
                        this.dstPessoa.Tables["MyTable"].Load(oBLL.Listar(drpRelatorio).CreateDataReader());
                        //passando parâmetros fixos
                        report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        //mostrando o relatório na tela
                        report1.Show();
                        break;
                  case "2":
                        //Montando Consulta SQL para o relatório
                        string drpRelAutorizado = DataReportAutorizadoCliente();
                        //inicializa o DataTable
                        this.dstAutorizado.Tables["MyTable"].Clear();
                        //obtendo resultado da consulta SQL e carregando no DataTable
                        this.dstAutorizado.Tables["MyTable"].Load(oBLL.Listar(drpRelAutorizado).CreateDataReader());
                        //passando parâmetros fixos
                        reportAutorizado.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        //mostrando o relatório na tela
                        reportAutorizado.Show();
                        break;
                  case "3":
                        //Montando Consulta SQL para o relatório
                        string drpRelReferencia = DataReportReferenciaCliente();
                        //inicializa o DataTable
                        this.dstReferencia.Tables["MyTable"].Clear();
                        //obtendo resultado da consulta SQL e carregando no DataTable
                        this.dstReferencia.Tables["MyTable"].Load(oBLL.Listar(drpRelReferencia).CreateDataReader());
                        //passando parâmetros fixos
                        reportReferencia.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                        //mostrando o relatório na tela
                        reportReferencia.Show();
                        break;
                  }

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

            //inicializa List com os Tipos de Pessoa
            lstCategoriaPessoa.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(EmcResources.CategoriaPessoa)))
                lstCategoriaPessoa.Items.Add(s,true);
           
            //inicializa combo com os Tipos de Pessoa
            cboTipoPessoa.Items.Clear();
            foreach (string s in Enum.GetNames(typeof(EmcResources.TipoPessoaTodas)))
                cboTipoPessoa.Items.Add(s);
            cboTipoPessoa.Text = Convert.ToString(EmcResources.TipoPessoaTodas.Todas);
            
            //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Código da Pessoa", "1"));
            arr.Add(new popCombo("Nome da Pessoa", "2"));
            cboOrdenar.DataSource = arr;
            cboOrdenar.DisplayMember = "nome";
            cboOrdenar.ValueMember = "valor";

            //inicializa combo de Layout
            ArrayList arrLayout = new ArrayList();
            arrLayout.Add(new popCombo("Cadastro Geral de Pessoas", "1"));
            arrLayout.Add(new popCombo("Autorizados do Cliente", "2")); 
            arrLayout.Add(new popCombo("Referências do Cliente", "3"));
            cboLayout.DataSource = arrLayout;
            cboLayout.DisplayMember = "nome";
            cboLayout.ValueMember = "valor";

        }

        #endregion

      #region "Métodos Privados"
      //Comando SQL para Cadastro Geral de Pessoas
      private string DataReportGeral()
         {

         StringBuilder strSQL = new StringBuilder();
         strSQL.Clear();
         strSQL.Append("Select");
         strSQL.Append(" (Case VP.Categoria");
         strSQL.Append(" when 'C' then 'Cliente'");
         strSQL.Append(" when 'F' then 'Fornecedor'");
         strSQL.Append(" when 'I' then 'Fiador'");
         strSQL.Append(" when 'V' then 'Vendedor'");
         strSQL.Append(" END) as DescrCategoria");
         strSQL.Append(", VP.*");
         strSQL.Append(" from");
         strSQL.Append(" V_Pessoas VP");
         strSQL.Append(" where");
         strSQL.Append(" VP.Categoria in (");

         //filtrando as categorias de Pessoas a emitir
         string sCategoria = EMCLibrary.EmcResources.ReadObject(this.lstCategoriaPessoa, EMCLibrary.EmcResources.TipoDados.Caracter, false);
         string sCategoriaAux = "";
         if (sCategoria.IndexOf("Cliente") > 0)
            if ((sCategoriaAux.Length) > 0) sCategoriaAux += ", 'C'"; else sCategoriaAux += "'C'";
         if (sCategoria.IndexOf("Fornecedor") > 0)
            if ((sCategoriaAux.Length) > 0) sCategoriaAux += ", 'F'"; else sCategoriaAux += "'F'";
         if (sCategoria.IndexOf("Vendedor") > 0)
            if ((sCategoriaAux.Length) > 0) sCategoriaAux += ", 'V'"; else sCategoriaAux += "'V'";
         if (sCategoria.IndexOf("Fiador") > 0)
            if ((sCategoriaAux.Length) > 0) sCategoriaAux += ", 'I'"; else sCategoriaAux += "'I'";
         sCategoriaAux = sCategoriaAux + ")";
         strSQL.Append(sCategoriaAux);

         //verifica se emite pessoa física ou jurídica 
         if (cboTipoPessoa.Text == "Jurídica")
            strSQL.Append(" and P.TipoPessoa = 'J'");
         else
            if (cboTipoPessoa.Text == "Física")
               strSQL.Append(" and P.TipoPessoa = 'F'");

         strSQL.Append(" Order by");
         if (cboOrdenar.SelectedValue.ToString() == "1")
            strSQL.Append(" Categoria, IdPessoa");
         else
            strSQL.Append(" Categoria, Nome");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }
      //Comando SQL para Autorizados do Cliente
      private string DataReportAutorizadoCliente()
         {

         StringBuilder strSQL = new StringBuilder();
         strSQL.Clear();
         strSQL.Append("Select");
	      strSQL.Append(" VC.idPessoa, VC.Nome");
	      strSQL.Append(", A.IdAutorizado, A.Nome as Autorizado");
	      strSQL.Append(", Case A.Parentesco");  
		   strSQL.Append(" when 1 then 'Pais'");
		   strSQL.Append(" when 2 then 'Tios'");
		   strSQL.Append(" when 4 then 'Avós'");
		   strSQL.Append(" when 5 then 'Irmãos'");
		   strSQL.Append(" when 6 then 'Primos'");
		   strSQL.Append(" when 7 then 'Cônjuges'");
	      strSQL.Append(" End as Parentesco");
         strSQL.Append(", Concat(VC.idPessoa, '-', VC.Nome) as Grupo1");
         strSQL.Append(" from");
	      strSQL.Append(" V_Cliente VC");
	      strSQL.Append(", Autorizados A");
         strSQL.Append(" where");
         strSQL.Append(" VC.CodEmpresa = " + codempresa);
         //verifica se emite pessoa física ou jurídica 
         if (cboTipoPessoa.Text == "Jurídica")
            strSQL.Append(" and VC.TipoPessoa = 'J'");
         else
            if (cboTipoPessoa.Text == "Física")
               strSQL.Append(" and VC.TipoPessoa = 'F'");
         strSQL.Append(" and A.CodEmpresa = VC.CodEmpresa");
         strSQL.Append(" and A.IdPessoa = VC.IdPessoa");
         // ordenando o relatório
         strSQL.Append(" Order by");
         if (cboOrdenar.SelectedValue.ToString() == "1")
            strSQL.Append(" VC.IdPessoa, A.IdAutorizado");
         else
            strSQL.Append(" VC.Nome, VC.IdPessoa, A.Nome");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }
      //Comando SQL para Autorizados do Cliente
      private string DataReportReferenciaCliente()
         {

         StringBuilder strSQL = new StringBuilder();
         strSQL.Clear();
         strSQL.Append("Select");
         strSQL.Append(" VC.idPessoa, VC.Nome");
         strSQL.Append(", R.IdReferencia, R.TipoReferencia, R.Nome as Referencia, R.Contato, R.Telefone01, R.Telefone02, R.Email");
         strSQL.Append(", Concat(VC.idPessoa, '-', VC.Nome) as Grupo1");
         strSQL.Append(", Case R.TipoReferencia");
         strSQL.Append(" when 1 then 'Bancária'");
         strSQL.Append(" when 2 then 'Comercial'");
         strSQL.Append(" when 3 then 'Pessoal'");
         strSQL.Append(" End as Grupo2");
         strSQL.Append(" from");
         strSQL.Append(" V_Cliente VC");
         strSQL.Append(", Referencias R");
         strSQL.Append(" where");
         strSQL.Append(" VC.CodEmpresa = " + codempresa);
         //verifica se emite pessoa física ou jurídica 
         if (cboTipoPessoa.Text == "Jurídica")
            strSQL.Append(" and VC.TipoPessoa = 'J'");
         else
            if (cboTipoPessoa.Text == "Física")
               strSQL.Append(" and VC.TipoPessoa = 'F'");
         strSQL.Append(" and R.CodEmpresa = VC.CodEmpresa");
         strSQL.Append(" and R.IdPessoa = VC.IdPessoa");
         // ordenando o relatório
         strSQL.Append(" Order by");
         if (cboOrdenar.SelectedValue.ToString() == "1")
            strSQL.Append(" VC.IdPessoa, VC.Nome, R.TipoReferencia");
         else
            strSQL.Append(" VC.Nome, VC.IdPessoa, R.TipoReferencia");

         //retorna string com consulta SQL
         return strSQL.ToString();

         }
      #endregion

  }
}

