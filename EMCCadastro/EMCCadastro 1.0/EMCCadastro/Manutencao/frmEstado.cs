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
    public partial class frmEstado : EMCLibrary.EMCForm
    {
        
        private const string nomeFormulario = "frmEstado";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        private string sitOperacao = "";

#region "metodos do form"
        public frmEstado(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmEstado()
        {
            InitializeComponent();
        }

        private void frmEstado_Activated(object sender, EventArgs e)
        {


        }
    
        private void frmEstado_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "estado";

            AtualizaGrid();
            this.ActiveControl = txtIdEstado;
            CancelaOperacao();
            sitOperacao = "C";
        }
#endregion

#region "metodos para tratamento das informacoes"
        
        private Estado montaEstado()
        {
            Estado oEstado = new Estado();
            oEstado.idEstado = txtIdEstado.Value.ToString();
            oEstado.nome = txtNome.Text;
            oEstado.abreviatura = txtAbreviatura.Text;

            return oEstado;
        }
        
        private void montaTela(Estado oEstado)
        {
            txtNome.Text = oEstado.nome;
            txtIdEstado.Text = oEstado.idEstado;
            txtAbreviatura.Text = oEstado.abreviatura;

            objOcorrencia.chaveidentificacao = oEstado.idEstado.ToString();
            txtIdEstado.ReadOnly = true;
            
            txtNome.Focus();
            
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
            txtIdEstado.Enabled = false;
            sitOperacao = "A";
            
        }
        
        public override void AtivaInsercao()
        {
            
            base.AtivaInsercao();

            if (sitOperacao != "I")
            {
                txtIdEstado.Enabled = true;
                txtIdEstado.ReadOnly = false;
                txtIdEstado.Focus();
                sitOperacao = "I";
            }
           
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtIdEstado.Enabled = true;
            txtIdEstado.ReadOnly = false;
            txtIdEstado.Focus();
            sitOperacao = "C";

        }

        public override void BuscaObjeto()
        {
           try
            {
                psqEstado ofrm = new psqEstado (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdEstado.Value.ToString() = "";
                    
                }
                else
                {
                    txtIdEstado.Enabled = true;
                    txtIdEstado.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdEstado.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        public void BuscaEstado()
        {

            if (!String.IsNullOrEmpty(txtIdEstado.Value.ToString()))
            {

                Estado oEstado = new Estado();
                oEstado.idEstado = txtIdEstado.Value.ToString();
                try
                {
                    if (EmcResources.cInt(txtIdEstado.Value.ToString())>0)
                    {
                        EstadoRN EstadoBLL = new EstadoRN(Conexao, objOcorrencia, codempresa);
                        oEstado = EstadoBLL.ObterPor(oEstado);

                        if (oEstado.idEstado.Equals(null) || EmcResources.cInt(oEstado.idEstado) == 0)
                        {
                            DialogResult result = MessageBox.Show("Estado não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                sitOperacao = "I";
                                AtivaInsercao();
                            }
                            else
                            {
                                CancelaOperacao();
                            }
                        }
                        else
                        {
                            montaTela(oEstado);
                            AtivaEdicao();
                        }

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Documento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdEstado.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Estado oEstado = new Estado();
                EstadoRN oUFBLL = new EstadoRN(Conexao, objOcorrencia, codempresa);
                oEstado = montaEstado();

                oUFBLL.Salvar(oEstado);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Estado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Estado oEstado = new Estado();
                EstadoRN oEstadoBLL = new EstadoRN(Conexao,objOcorrencia,codempresa);
                oEstado = montaEstado();
                oEstado.idEstado = txtIdEstado.Value.ToString();

                oEstadoBLL.Atualizar(oEstado);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Estado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Estado oEstado = new Estado();
                EstadoRN oEstadoBLL = new EstadoRN(Conexao,objOcorrencia,codempresa);
                oEstado = montaEstado();
                oEstado.idEstado = txtIdEstado.Value.ToString();

                oEstadoBLL.Excluir(oEstado);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Estado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relEstado ofrm = new Relatorios.relEstado(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Estado: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    #endregion

#region "metodos da dbgrid"

        private void grdEstado_DoubleClick(object sender, EventArgs e)
        {
            txtIdEstado.Enabled = true;
            txtIdEstado.Text = grdEstado.Rows[grdEstado.CurrentRow.Index].Cells["idEstado"].Value.ToString();
            txtIdEstado.Focus();
            SendKeys.Send("{TAB}");
            
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Estados cadastrados
            EstadoRN objEstado = new EstadoRN(Conexao,objOcorrencia,codempresa);
            grdEstado.DataSource = objEstado.ListaEstado();
        }

        #endregion

      
        private void txtIdEstado_Validating(object sender, CancelEventArgs e)
        {
            BuscaEstado();
        }

    }
}
