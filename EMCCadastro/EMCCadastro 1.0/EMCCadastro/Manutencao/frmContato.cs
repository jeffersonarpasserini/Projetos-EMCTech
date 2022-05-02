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
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmContato : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmContato";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int codPessoa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmContato()
        {
            InitializeComponent();
        }
        public frmContato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, String idPessoa, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            codPessoa = Convert.ToInt32(idPessoa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmContato_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = "frmPessoa";
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "contato";


            AtualizaGrid();
            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.SimNao)))
                cboRecado.Items.Add(s);

            cboTipoTelefone.Items.Add("Comercial");
            cboTipoTelefone.Items.Add("Residencial");
            cboTipoTelefone.Items.Add("Celular");
            cboTipoTelefone.Items.Add("Fax");

            CancelaOperacao();

            AtivaInsercao();

            this.ActiveControl = txtTelefone;

        }


#region "metodos para tratamento das informacoes*********************************************************************"
      
        private Boolean verificaContato(Contato oContato)
        {
            ContatoRN oContatoRN = new ContatoRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oContatoRN.VerificaDados(oContato);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
       
        private Contato montaContato()
        {
            Contato oContato = new Contato();
            oContato.codEmpresa = empMaster;
            oContato.idPessoa = codPessoa;
            //oContato.codigo = Convert.ToInt32(txtCodigo.Text);
            oContato.numero = txtTelefone.Text;
            if (cboTipoTelefone.Text == "Comercial")
            {
                oContato.tipoTelefone = "1";
            }
            else if (cboTipoTelefone.Text == "Residencial")
            {
                oContato.tipoTelefone = "2";
            }
            else if (cboTipoTelefone.Text == "Celular")
            {
                oContato.tipoTelefone = "3";
            }
            else if (cboTipoTelefone.Text == "Fax")
            {
                oContato.tipoTelefone = "4";
            }
            else oContato.tipoTelefone = "3";


            if (cboRecado.Text == "Sim")
            {
                oContato.recado = "S";
            }
            else if (cboRecado.Text == "Não")
            {
                oContato.recado = "N";
            }
            else
            {
                oContato.recado = "N";
            }
            oContato.eMail = txtEmail.Text;

            return oContato;
        }
      
        private void montaTela(Contato oContato)
        {
            //txtCodigo.ReadOnly = true;
            //txtTelefone.Focus();
            objOcorrencia.chaveidentificacao = oContato.codigo.ToString();

            txtTelefone.Text = oContato.numero;

            if (oContato.tipoTelefone == "1")
            {
                cboTipoTelefone.Text = "Comercial";                
            }
            else if (oContato.tipoTelefone == "2")
            {
                cboTipoTelefone.Text = "Residencial";
            }
            else if (oContato.tipoTelefone == "3")
            {
                cboTipoTelefone.Text = "Celular";
            }
            else if (oContato.tipoTelefone == "4")
            {
                cboTipoTelefone.Text = "Fax";
            }


            if (oContato.recado == "S")
            {
                cboRecado.Text = "Sim";
            }
            else if (oContato.recado == "N")
            {
                cboRecado.Text = "Não";
            }
            txtEmail.Text = oContato.eMail;
            

        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
        
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }
        
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtCodigo.Enabled = false;
            txtTelefone.Focus();
        }
      
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtCodigo.Enabled = false;
            txtTelefone.Focus();

        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtCodigo.ReadOnly = true;
            txtTelefone.Focus();
        }
      
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            Contato oContato = new Contato();
            oContato = montaContato();
            oContato.codEmpresa = empMaster;
            oContato.idPessoa = codPessoa;
            oContato.codigo = Convert.ToInt32(txtCodigo.Text);

            if (oContato.codigo > 0)
            {
                try
                {
                    ContatoRN contatoRN = new ContatoRN(Conexao,objOcorrencia,codempresa);
                    oContato = contatoRN.ObterPor(oContato);
                    
                    montaTela(oContato);
                    AtualizaGrid();
                    AtivaEdicao();

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Contato: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtCodigo.ReadOnly = true;
            txtTelefone.Focus();

            AtualizaGrid();
            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.SimNao)))
                cboRecado.Items.Add(s);

            cboTipoTelefone.Items.Add("Comercial");
            cboTipoTelefone.Items.Add("Residencial");
            cboTipoTelefone.Items.Add("Celular");
            cboTipoTelefone.Items.Add("Fax");
        }

        public override void SalvaObjeto()
        {
            try
            {
                Contato oContato = new Contato();
                ContatoRN oContatoRN = new ContatoRN(Conexao,objOcorrencia,codempresa);

                oContato = montaContato();

                if (verificaContato(oContato))
                {
                    oContatoRN.Salvar(oContato);
                    AtualizaGrid();
                    LimpaCampos();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.SalvaObjeto();
        }
       
        public override void AtualizaObjeto()
        {
            try
            {
                Contato oContato = new Contato();
                ContatoRN oContatoRN = new ContatoRN(Conexao,objOcorrencia,codempresa);
                oContato = montaContato();
                oContato.codigo = Convert.ToInt32(txtCodigo.Text);

                if (verificaContato(oContato))
                {
                    oContatoRN.Atualizar(oContato);
                    AtualizaGrid();
                    LimpaCampos();
                    MessageBox.Show("Contato atualizado com sucesso");
                }
                else MessageBox.Show("Atualização cancelada");

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.AtualizaObjeto();
        }
        
        public override void ExcluiObjeto()
        {
            try
            {
                Contato oContato = new Contato();
                ContatoRN oContatoRN = new ContatoRN(Conexao,objOcorrencia,codempresa);
                oContato = montaContato();
                oContato.codigo = Convert.ToInt32(txtCodigo.Text);

                if (verificaContato(oContato))
                {
                    oContatoRN.Excluir(oContato);
                    AtualizaGrid();
                    LimpaCampos();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
#endregion
#region "Tratamentos para texts**************************************************************************************"
        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

#endregion
#region "metodos da dbgrid*******************************************************************************************"

        private void grdContato_DoubleClick(object sender, EventArgs e)
        {
            txtCodigo.Text = grdContato.Rows[grdContato.CurrentRow.Index].Cells["idtelefone"].Value.ToString();
            AtivaEdicao();
            BuscaObjeto();
        }
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            ContatoRN objContato = new ContatoRN(Conexao,objOcorrencia,codempresa);
            Contato oContato = new Contato();
            oContato = montaContato();
          
            grdContato.DataSource = objContato.ListaContato(oContato);
            
        }


#endregion

 
    }
}
