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
using System.Collections;

namespace EMCCadastro
{
    public partial class frmIndexador : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmIndexador";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmIndexador(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        public frmIndexador()
        {
            InitializeComponent();
        }

        private void frmIndexador_Activated(object sender, EventArgs e)
        {


        }
        
        private void frmIndexador_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "indexador";

            AtualizaGrid();
            this.ActiveControl = txtIdIndexador;
            CancelaOperacao();
        }
#endregion

#region "metodos para tratamento das informacoes"
        
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
     
        private Indexador montaIndexador()
        {
            Indexador oIndexador = new Indexador();
            oIndexador.idIndexador = EmcResources.cInt(txtIdIndexador.Text);
            oIndexador.descricao = txtIndexador.Text;
            oIndexador.tipoIndexador = cboTipoIndexador.SelectedValue.ToString();
            oIndexador.simbolo = txtSimbolo.Text;

            return oIndexador;
        }
      
        private void montaTela(Indexador oIndexador)
        {
            txtIndexador.Text = oIndexador.descricao;
            txtIdIndexador.Text = oIndexador.idIndexador.ToString();
            txtSimbolo.Text = oIndexador.simbolo;
            cboTipoIndexador.SelectedValue = oIndexador.tipoIndexador;
            objOcorrencia.chaveidentificacao = oIndexador.idIndexador.ToString();
            txtIdIndexador.ReadOnly = true;
            txtIndexador.Focus();
           
            
        }
       
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdIndexador.Enabled = false;
        }
       
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();


            ArrayList ar = new ArrayList();
            ar.Add(new popCombo("R-Ref.Monetária", "R"));
            ar.Add(new popCombo("I-Indice Inflação", "I"));
            cboTipoIndexador.DataSource = ar;
            cboTipoIndexador.DisplayMember = "nome";
            cboTipoIndexador.ValueMember = "valor";


            objOcorrencia.chaveidentificacao = "";
            txtIdIndexador.Enabled = true;
            txtIdIndexador.ReadOnly = false;
            txtIdIndexador.Focus();
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();

            try
            {
                psqIndexador ofrm = new psqIndexador(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdIndexador.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdIndexador.Enabled = true;
                    txtIdIndexador.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdIndexador.Focus();
                    SendKeys.Send("{TAB}");
                   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdIndexador.ReadOnly = true;
            txtIndexador.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorBLL = new IndexadorRN(Conexao,objOcorrencia,codempresa);
                oIndexador = montaIndexador();

                oIndexadorBLL.Salvar(oIndexador);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indexador: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorBLL = new IndexadorRN(Conexao,objOcorrencia,codempresa);
                oIndexador = montaIndexador();
                oIndexador.idIndexador = Convert.ToInt32(txtIdIndexador.Text);

                oIndexadorBLL.Atualizar(oIndexador);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indexador: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Indexador oIndexador = new Indexador();
                IndexadorRN oIndexadorBLL = new IndexadorRN(Conexao,objOcorrencia,codempresa);
                oIndexador = montaIndexador();
                oIndexador.idIndexador = Convert.ToInt32(txtIdIndexador.Text);

                oIndexadorBLL.Excluir(oIndexador);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indexador: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public void BuscaIndexador()
        {
            if (!String.IsNullOrEmpty(txtIdIndexador.Text))
            {

                Indexador oIndexador = new Indexador();
                oIndexador.idIndexador = EmcResources.cInt(txtIdIndexador.Text);

                try
                {
                    IndexadorRN indexadorRN = new IndexadorRN(Conexao, objOcorrencia, codempresa);

                    oIndexador = montaIndexador();

                    oIndexador = indexadorRN.ObterPor(oIndexador);

                    if (oIndexador.idIndexador == 0)
                    {
                        DialogResult result = MessageBox.Show("Indexador não cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }

                    }
                    else
                    {
                        montaTela(oIndexador);
                        //AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Indexador: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


#endregion

#region "metodos da dbgrid"

        private void grdIndexador_DoubleClick(object sender, EventArgs e)
        {
            txtIdIndexador.Enabled = true;
            txtIdIndexador.Text = grdIndexador.Rows[grdIndexador.CurrentRow.Index].Cells["idIndexador"].Value.ToString();
            txtIdIndexador.Focus();
            SendKeys.Send("{TAB}");
           
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Indexadors cadastrados
            IndexadorRN objIndexador = new IndexadorRN(Conexao,objOcorrencia,codempresa);
            grdIndexador.DataSource = objIndexador.ListaIndexador();
        }


        #endregion

      
        private void txtIdIndexador_Validating(object sender, CancelEventArgs e)
        {
            BuscaIndexador();
        }



    }
}
