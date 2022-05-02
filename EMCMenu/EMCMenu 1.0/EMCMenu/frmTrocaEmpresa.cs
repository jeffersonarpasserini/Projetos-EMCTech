using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;

namespace EMCMenu
{
    public partial class frmTrocaEmpresa : Form
    {
        int idUsuario;
        string nomeUsuario;
        int codEmpresa;
        int empMaster;
        string nomeEmpresa;

        ConectaBancoMySql Conexao;

        public frmTrocaEmpresa(ConectaBancoMySql pConexao)
        {

            Conexao = pConexao;

            InitializeComponent();
        }

        private void frmTrocaEmpresa_Load(object sender, EventArgs e)
        {
            idUsuario = EmcResources.cInt(UsuarioLogado.codUsuario);
            nomeUsuario = UsuarioLogado.nomeUsuario;
            codEmpresa = EmcResources.cInt(UsuarioLogado.idEmpresa);
            nomeEmpresa = UsuarioLogado.nomeEmpresa;
            empMaster = EmcResources.cInt(UsuarioLogado.empresaMaster);

            lblEmpresa.Text = lblEmpresa.Text + " " + nomeEmpresa;
            lblUsuario.Text = lblUsuario.Text + " " + nomeUsuario;

            UsuarioEmpresaRN oUserEmpRN = new UsuarioEmpresaRN(Conexao);

            cboEmpresaUsuario.DataSource = oUserEmpRN.ListaEmpresaUsuario(idUsuario);
            cboEmpresaUsuario.DisplayMember = "razaosocial";
            cboEmpresaUsuario.ValueMember = "idempresa";
        }

        private void btmEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Ocorrencia oOcorrencia = new Ocorrencia();

                Empresa oEmp = new Empresa();
                EmpresaRN oEmpRN = new EmpresaRN(Conexao, oOcorrencia, EmcResources.cInt(UsuarioLogado.idEmpresa));

                oEmp.idEmpresa = EmcResources.cInt(cboEmpresaUsuario.SelectedValue.ToString());

                oEmp = oEmpRN.ObterPor(oEmp);

                if (!String.IsNullOrEmpty(oEmp.razaoSocial))
                {
                    UsuarioLogado.nomeEmpresa = oEmp.razaoSocial;
                    UsuarioLogado.idEmpresa = oEmp.idEmpresa.ToString();
                    UsuarioLogado.empresaMaster = oEmp.empMaster.idEmpresa.ToString(); 
                }
                else
                {
                    MessageBox.Show("Não foi possivel trocar a empresa atual", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch(Exception oerro)
            {
                MessageBox.Show(oerro.Message);
            }
        }
    }
}
