using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurityModel;


namespace EMCCadastro
{
    public partial class frmAutorizadosCliente : Form
    {
        private const string nomeFormulario = "frmAutorizadoCliente";
        private const string nomeAplicativo = "EMCCadastro";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private int codPessoa = 0;
        private int codAutorizado = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();

        public frmAutorizadosCliente(String idUsuario, String seqLogin, String idEmpresa, String empmaster, String idPessoa, String idAutorizado, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            codPessoa = Convert.ToInt32(idPessoa);
            codAutorizado = Convert.ToInt32(idAutorizado);
            Conexao = pConexao;

            InitializeComponent();
        }
        
        private void frmAutorizadosCliente_Load(object sender, EventArgs e)
        {
            //preenche dados de origem de ocorrencia
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmCliente";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "autorizados";

            cboParentesco.Items.Add("Pais");
            cboParentesco.Items.Add("Tios");
            cboParentesco.Items.Add("Avós");
            cboParentesco.Items.Add("Irmãos");
            cboParentesco.Items.Add("Primos");
            cboParentesco.Items.Add("Cônjuge");

            txtIdAutorizado.Text = codAutorizado.ToString();
            if (codAutorizado > 0)
            {
                AutorizadosCliente oRef = new AutorizadosCliente();
                oRef.codEmpresa = empMaster;
                oRef.idPessoa = codPessoa;
                oRef.idAutorizado = codAutorizado;
                AutorizadosClienteRN oRefRN = new AutorizadosClienteRN(Conexao,objOcorrencia,codempresa);
                oRef = oRefRN.ObterPor(oRef);
                montaTela(oRef);
            }
        }
        
        public frmAutorizadosCliente()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        protected virtual void EMCForm_KeyDown(object sender, KeyEventArgs e)
        {
            // vamos verificar se o usuário pressionou a tecla F5
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");

            if (e.KeyCode == Keys.F2)
            {
                LimpaCampos();
            }
            if (e.KeyCode == Keys.F3)
                SalvaObjeto();


        }

        public AutorizadosCliente montaReferencia()
        {
            AutorizadosCliente oReferencia = new AutorizadosCliente();
            oReferencia.codEmpresa = empMaster;
            oReferencia.idPessoa = codPessoa;
            //oContato.codigo = Convert.ToInt32(txtCodigo.Text);
            oReferencia.nome = txtNome.Text;

            /*
             1 - Pais
             2 - Tios
             3 - Avós
             4 - Irmãos
             5 - Primos
             6 - Conjuge
            */
            if (cboParentesco.Text == "Pais")
            {
                oReferencia.parentesco = "1";
            }
            else if (cboParentesco.Text == "Tios")
            {
                oReferencia.parentesco = "2";
            }
            else if (cboParentesco.Text == "Avós")
            {
                oReferencia.parentesco = "3";
            }
            else if (cboParentesco.Text == "Irmãos")
            {
                oReferencia.parentesco = "4";
            }
            else if (cboParentesco.Text == "Primos")
            {
                oReferencia.parentesco = "5";
            }
            else
            {
                //Conjuge
                oReferencia.parentesco = "6";
            }
            
            return oReferencia;
        }
        
        public void montaTela(AutorizadosCliente oReferencia)
        {
            txtIdAutorizado.Text = codAutorizado.ToString();
            txtNome.Text = oReferencia.nome;

            /*
             1 - Pais
             2 - Tios
             3 - Avós
             4 - Irmãos
             5 - Primos
             6 - Conjuge
            */
            if (oReferencia.parentesco == "1")
            {
                cboParentesco.Text = "Pais";
            }
            else if (oReferencia.parentesco == "2")
            {
                cboParentesco.Text = "Tios";
            }
            else if (oReferencia.parentesco == "3")
            {
                cboParentesco.Text = "Avós";
            }
            else if (oReferencia.parentesco == "4")
            {
                cboParentesco.Text = "Irmãos";
            }
            else if (oReferencia.parentesco == "5")
            {
                cboParentesco.Text = "Primos";
            }
            else
            {
                //Conjuge
                cboParentesco.Text = "Conjuge";
            }

            objOcorrencia.chaveidentificacao = oReferencia.idPessoa.ToString();
            
        }

        public bool verificaReferencia(AutorizadosCliente oRef)
        {
            AutorizadosClienteRN oRefRN = new AutorizadosClienteRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oRefRN.VerificaDados(oRef);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }

        }

        public void SalvaObjeto()
        {
            try
            {
                AutorizadosCliente oReferencia = new AutorizadosCliente();
                AutorizadosClienteRN oRefRN = new AutorizadosClienteRN(Conexao,objOcorrencia,codempresa);

                oReferencia = montaReferencia();

                if (verificaReferencia(oReferencia))
                {
                    if (Convert.ToInt32(txtIdAutorizado.Text) == 0)
                    {
                        oRefRN.Salvar(oReferencia);
                        LimpaCampos();
                        
                    }
                    else
                    {
                        oReferencia.idAutorizado = Convert.ToInt32(txtIdAutorizado.Text);
                        oRefRN.Atualizar(oReferencia);
                        LimpaCampos();
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message+erro.StackTrace);
            }


        }

        public void LimpaCampos()
        {

            foreach (Control c in Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                {
                    (c as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Text = "";
                }
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                }
                if (c is MaskedTextBox)
                {
                    (c as MaskedTextBox).Text = "";
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Text = "";
                }


                //dentro de um Panel
                if (c is Panel)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {

                        if (c.Controls[i].GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                        {
                            (c.Controls[i] as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                        }
                        if (c.Controls[i] is DateTimePicker)
                        {
                            (c.Controls[i] as DateTimePicker).Text = "";
                        }

                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                        if (c.Controls[i] is MaskedTextBox)
                        {
                            (c.Controls[i] as MaskedTextBox).Text = "";
                        }
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                    }
                }

                // dentro de um group box
                if (c is GroupBox)
                {
                    for (int i = 0; i < c.Controls.Count; i++)
                    {
                        if (c.Controls[i].GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                        {
                            (c.Controls[i] as System.Windows.Forms.Sample.DecimalTextBox).Text = "";
                        }
                        if (c.Controls[i] is DateTimePicker)
                        {
                            (c.Controls[i] as DateTimePicker).Text = "";
                        }

                        if (c.Controls[i] is TextBox)
                        {
                            (c.Controls[i] as TextBox).Text = "";
                        }
                        if (c.Controls[i] is MaskedTextBox)
                        {
                            (c.Controls[i] as MaskedTextBox).Text = "";
                        }
                        if (c.Controls[i] is ComboBox)
                        {
                            (c.Controls[i] as ComboBox).Text = "";
                        }
                    }
                }

                //dentro de tab
                foreach (Control item in c.Controls)
                {
                    if (item.HasChildren)
                    {
                        //LimpaControle(item);
                    }
                    if (item.GetType() == typeof(ComboBox))
                    {
                        ComboBox cbo;
                        cbo = (ComboBox)item;
                        cbo.SelectedIndex = -1;
                    }
                    else if (item.GetType() == typeof(TextBox))
                    {
                        TextBox txt;
                        txt = (TextBox)item;
                        txt.Text = string.Empty;
                    }
                    else if (item.GetType() == typeof(DateTimePicker))
                    {
                        DateTimePicker dtp;
                        dtp = (DateTimePicker)item;
                        dtp.Text = string.Empty;
                    }
                    else if (item.GetType() == typeof(System.Windows.Forms.Sample.DecimalTextBox))
                    {
                        System.Windows.Forms.Sample.DecimalTextBox dec;
                        dec = (System.Windows.Forms.Sample.DecimalTextBox)item;
                        dec.Text = String.Empty;

                    }

                }
            }
            txtIdAutorizado.Text = "0";
            objOcorrencia.chaveidentificacao = "";

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvaObjeto();
        }



    }
}
