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
    public partial class frmIbgeCidade : EMCLibrary.EMCForm
    {
         private const string nomeFormulario = "frmIbgeCidade";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        private string sitOperacao = "";

#region "metodos do form"
        public frmIbgeCidade(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmIbgeCidade()
        {
            InitializeComponent();
        }

        private void frmIbgeCidade_Activated(object sender, EventArgs e)
        {


        }
    
        private void frmIbgeCidade_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "ibgecidade";

            EstadoRN oEstadoRN = new EstadoRN(Conexao, objOcorrencia, codempresa);
            cboEstado.DataSource = oEstadoRN.ListaEstado();
            cboEstado.ValueMember = "idestado";
            cboEstado.DisplayMember = "abreviatura";

            AtualizaGrid();
            this.ActiveControl = txtCodigoIbge;
            CancelaOperacao();
            sitOperacao = "C";
        }
#endregion

#region "metodos para tratamento das informacoes"
        
        private IbgeCidade montaIbgeCidade()
        {
            IbgeCidade oIbgeCidade = new IbgeCidade();
            oIbgeCidade.codigoIbge = txtCodigoIbge.Text;
            oIbgeCidade.nomeCidade = txtNomeCidade.Text;
            
            Estado oEstado = new Estado();
            oEstado.idEstado = cboEstado.SelectedValue.ToString();
            EstadoRN oEstadoRN = new EstadoRN(Conexao, objOcorrencia, codempresa);
            oEstado = oEstadoRN.ObterPor(oEstado);
            oIbgeCidade.estado = oEstado;

            return oIbgeCidade;
        }
        
        private void montaTela(IbgeCidade oIbgeCidade)
        {
            txtIdIbgeCidade.Text = oIbgeCidade.idIbgeCidade.ToString();
            txtNomeCidade.Text = oIbgeCidade.nomeCidade;
            txtCodigoIbge.Text = oIbgeCidade.codigoIbge;
            cboEstado.SelectedValue = oIbgeCidade.estado.idEstado;

            objOcorrencia.chaveidentificacao = oIbgeCidade.idIbgeCidade.ToString();
            txtCodigoIbge.ReadOnly = true;
            
            txtNomeCidade.Focus();
            
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
            txtCodigoIbge.Enabled = false;
            sitOperacao = "A";
            
        }
        
        public override void AtivaInsercao()
        {
            
            base.AtivaInsercao();

            if (sitOperacao != "I")
            {
                txtCodigoIbge.Enabled = true;
                txtCodigoIbge.ReadOnly = false;
                txtCodigoIbge.Focus();
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
            txtCodigoIbge.Enabled = true;
            txtCodigoIbge.ReadOnly = false;
            txtCodigoIbge.Focus();
            sitOperacao = "C";

        }

        public override void BuscaObjeto()
        {
           try
            {
                psqIbgeCidade ofrm = new psqIbgeCidade (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdIbgeCidade.Value.ToString() = "";
                    
                }
                else
                {
                    txtCodigoIbge.Enabled = true;
                    //txtIdIbgeCidade.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtCodigoIbge.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtCodigoIbge.Focus();
                    SendKeys.Send("{TAB}");
                 }
            }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Tipo Cobrança: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
   
        public void BuscaIbgeCidade()
        {

            if (!String.IsNullOrEmpty(txtCodigoIbge.Value.ToString()))
            {

                IbgeCidade oIbgeCidade = new IbgeCidade();
                oIbgeCidade.codigoIbge = txtCodigoIbge.Value.ToString();
                try
                {
                    if (EmcResources.cInt(txtCodigoIbge.Value.ToString())>0)
                    {
                        IbgeCidadeRN IbgeCidadeBLL = new IbgeCidadeRN(Conexao, objOcorrencia, codempresa);
                        oIbgeCidade = IbgeCidadeBLL.ObterPor(oIbgeCidade);

                        if (oIbgeCidade.idIbgeCidade.Equals(null) || oIbgeCidade.idIbgeCidade == 0)
                        {
                            DialogResult result = MessageBox.Show("IbgeCidade não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                            montaTela(oIbgeCidade);
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
            txtCodigoIbge.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                IbgeCidade oIbgeCidade = new IbgeCidade();
                IbgeCidadeRN oUFBLL = new IbgeCidadeRN(Conexao, objOcorrencia, codempresa);
                oIbgeCidade = montaIbgeCidade();

                oUFBLL.Salvar(oIbgeCidade);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro IbgeCidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                IbgeCidade oIbgeCidade = new IbgeCidade();
                IbgeCidadeRN oIbgeCidadeBLL = new IbgeCidadeRN(Conexao,objOcorrencia,codempresa);
                oIbgeCidade = montaIbgeCidade();
                oIbgeCidade.idIbgeCidade = EmcResources.cInt(txtIdIbgeCidade.Text);

                oIbgeCidadeBLL.Atualizar(oIbgeCidade);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro IbgeCidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                IbgeCidade oIbgeCidade = new IbgeCidade();
                IbgeCidadeRN oIbgeCidadeBLL = new IbgeCidadeRN(Conexao,objOcorrencia,codempresa);
                oIbgeCidade = montaIbgeCidade();
                oIbgeCidade.idIbgeCidade = EmcResources.cInt(txtIdIbgeCidade.Text);

                oIbgeCidadeBLL.Excluir(oIbgeCidade);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro IbgeCidade: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relIbgeCidade ofrm = new Relatorios.relIbgeCidade(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro IbgeCidade: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    #endregion

#region "metodos da dbgrid"

        private void grdIbgeCidade_DoubleClick(object sender, EventArgs e)
        {
            txtCodigoIbge.Enabled = true;
            txtCodigoIbge.Text = grdIbgeCidade.Rows[grdIbgeCidade.CurrentRow.Index].Cells["codigoibge"].Value.ToString();
            txtCodigoIbge.Focus();
            SendKeys.Send("{TAB}");
            
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os IbgeCidades cadastrados
            IbgeCidadeRN objIbgeCidade = new IbgeCidadeRN(Conexao,objOcorrencia,codempresa);
            grdIbgeCidade.DataSource = objIbgeCidade.ListaIbgeCidade();
        }

        #endregion

      
        private void txtCodigoIbge_Validating(object sender, CancelEventArgs e)
        {
            BuscaIbgeCidade();
        }
    }
}
