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
    public partial class frmReferenciaCliente : Form
    {
        private const string nomeFormulario = "frmReferenciaCliente";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private int codPessoa = 0;
        private int codReferencia = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmReferenciaCliente(String idUsuario, String seqLogin, String idEmpresa, String empmaster, String idPessoa, String idReferencia,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            codPessoa = Convert.ToInt32(idPessoa);
            codReferencia = Convert.ToInt32(idReferencia);
            Conexao = pConexao;
            InitializeComponent();
        }
        
        private void frmReferenciaCliente_Load(object sender, EventArgs e)
        {

            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmCliente";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "referencias";
            
            cboTipoReferencia.Items.Add("Bancaria");
            cboTipoReferencia.Items.Add("Comercial");
            cboTipoReferencia.Items.Add("Pessoal");
            txtIdReferencia.Text = codReferencia.ToString();
            if (codReferencia > 0)
            {
                ReferenciaCliente oRef = new ReferenciaCliente();
                oRef.codEmpresa = empMaster;
                oRef.idPessoa = codPessoa;
                oRef.idReferencia = codReferencia;
                ReferenciaClienteRN oRefRN = new ReferenciaClienteRN(Conexao,objOcorrencia,codempresa);
                oRef = oRefRN.ObterPor(oRef);
                montaTela(oRef);
            }
        }
        
        public frmReferenciaCliente()
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

        public ReferenciaCliente montaReferencia()
        {
            ReferenciaCliente oReferencia = new ReferenciaCliente();
            oReferencia.codEmpresa = empMaster;
            oReferencia.idPessoa = codPessoa;
            //oContato.codigo = Convert.ToInt32(txtCodigo.Text);
            oReferencia.nome = txtNome.Text;
            oReferencia.telefone1 = txtTelefone01.Text;
            oReferencia.telefone2 = txtTelefone02.Text;
            oReferencia.contato = txtContato.Text;
            oReferencia.eMail = txtEmail.Text;

            if (cboTipoReferencia.Text == "Bancaria")
            {
                oReferencia.tipoReferencia = "1";
            }
            else if (cboTipoReferencia.Text == "Comercial")
            {
                oReferencia.tipoReferencia = "2";
            }
            else 
            {
                //Pessoal
                oReferencia.tipoReferencia = "3";
            }
            
            return oReferencia;
        }
        
        public void montaTela(ReferenciaCliente oReferencia)
        {
            txtIdReferencia.Text = codReferencia.ToString();
            txtNome.Text = oReferencia.nome;
            txtTelefone01.Text = oReferencia.telefone1;
            txtTelefone02.Text = oReferencia.telefone2;
            txtContato.Text = oReferencia.contato;
            txtEmail.Text = oReferencia.eMail;

            if (oReferencia.tipoReferencia == "1")
            {
                cboTipoReferencia.Text = "Bancaria";
            }
            else if (oReferencia.tipoReferencia == "2")
            {
                cboTipoReferencia.Text = "Comercial";
            }
            else
            {
                //Pessoal
                cboTipoReferencia.Text = "Pessoal";
            }
            objOcorrencia.chaveidentificacao = oReferencia.idPessoa.ToString();
        }

        public bool verificaReferencia(ReferenciaCliente oRef)
        {
            ReferenciaClienteRN oRefRN = new ReferenciaClienteRN(Conexao,objOcorrencia,codempresa);
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
                ReferenciaCliente oReferencia = new ReferenciaCliente();
                ReferenciaClienteRN oRefRN = new ReferenciaClienteRN(Conexao,objOcorrencia,codempresa);

                oReferencia = montaReferencia();

                if (verificaReferencia(oReferencia))
                {
                    if (Convert.ToInt32(txtIdReferencia.Text) == 0)
                    {
                        oRefRN.Salvar(oReferencia);
                        LimpaCampos();
                        this.Close();
                        
                    }
                    else
                    {
                        oReferencia.idReferencia = Convert.ToInt32(txtIdReferencia.Text);
                        oRefRN.Atualizar(oReferencia);
                        LimpaCampos();
                        this.Close();
                    }
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Referência: " + erro.Message, "Messagem", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
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
            txtIdReferencia.Text = "0";
            objOcorrencia.chaveidentificacao = "";
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvaObjeto();
            
        }



    }
}
