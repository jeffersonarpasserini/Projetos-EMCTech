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
using EMCImobRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;

namespace EMCImob.Relatorios
{
    public partial class relTipoImovel : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relTipoImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relTipoImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relTipoImovel_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "tipoimovel";

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
                //
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                TipoImovelRN oBLL = new TipoImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório
                string drpRelatorio = DataReport();

                this.dstTipoImovel.Tables["MyTable"].Clear();
                this.dstTipoImovel.Tables["MyTable"].Load(oBLL.ListaTipoImovel(drpRelatorio).CreateDataReader());

                //verifica se encontrou registros a emitir
                if (this.dstTipoImovel.Tables["MyTable"].Rows.Count == 0)
                {
                    MessageBox.Show("Não foram encontrados registros a emitir.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //mostrando o relatório na tela
                report1.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
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
            arr.Add(new popCombo("Código do Tipo de Imóvel", "1"));
            arr.Add(new popCombo("Descrição do Tipo de Imóvel", "2"));
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
            strSQL.Append("Select * from tipoimovel");
            strSQL.Append(" order by");
            //verifica se ordena por código ou descrição
            if (cboOrdenar.SelectedValue.ToString() == "1")
                strSQL.Append(" idtipoimovel");
            else
                strSQL.Append(" Descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion
    }
}
