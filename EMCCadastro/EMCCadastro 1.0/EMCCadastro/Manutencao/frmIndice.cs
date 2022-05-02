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
    public partial class frmIndice : EMCLibrary.EMCForm
    {
      
#region "metodos do form"
        public frmIndice()
        {
            InitializeComponent();

        }
        private const string nomeFormulario = "frmIndice";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public frmIndice(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();

        }

        private void frmIndice_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "indices";

            Indexador oIndexador = new Indexador();
            IndexadorRN oIndexadorRN = new IndexadorRN(Conexao,objOcorrencia,codempresa);

            cboIdIndexador.DataSource = oIndexadorRN.ListaIndexador();
            cboIdIndexador.DisplayMember = "descricao";
            cboIdIndexador.ValueMember = "idindexador";
            
            CancelaOperacao();
           
        }
     
#endregion


#region "metodos para tratamento das informacoes"
      
        private Indices montaIndice()
        {
            Indices oIndice = new Indices();
            if (!String.IsNullOrEmpty(txtIdIndice.Text))
            {
                oIndice.idIndice = EmcResources.cInt(txtIdIndice.Text);
            }
            oIndice.dataIndice = Convert.ToDateTime(txtDataIndice.Text);
            oIndice.valor = txtValor.Value;

            Indexador oIndexador = new Indexador();
            IndexadorRN oIndRN = new IndexadorRN(Conexao,objOcorrencia,codempresa);

            oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);

            oIndexador = oIndRN.ObterPor(oIndexador);

            oIndice.indexador = oIndexador;

            return oIndice;
        }
        
        private void montaTela(Indices oIndice)
        {
            txtValor.Value = oIndice.valor;
            txtDataIndice.Text = oIndice.dataIndice.ToString();

            cboIdIndexador.SelectedValue = EmcResources.cInt(oIndice.indexador.idIndexador.ToString());
            txtIdIndice.Text = oIndice.idIndice.ToString();

            objOcorrencia.chaveidentificacao = oIndice.idIndice.ToString();
        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }
       
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
        }
      
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
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
            objOcorrencia.chaveidentificacao = "";
            
        }

        public void BuscaIndices()
        {
            //base.BuscaObjeto();

            if (!String.IsNullOrEmpty(txtIdIndice.Text))
            {

                Indices oIndice = new Indices();
                try
                {
                    IndicesRN IndiceBLL = new IndicesRN(Conexao, objOcorrencia, codempresa);
                    oIndice = montaIndice();

                    oIndice = IndiceBLL.ObterPor(oIndice);

                    if (String.IsNullOrEmpty(txtDataIndice.Text))
                    {
                        DialogResult result = MessageBox.Show("Indice não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                    }
                    else
                    {
                        //txtidIndice.Text = oIndice.idIndice;
                        montaTela(oIndice);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Índice: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
          
        }

        public override void BuscaObjeto()
        {
            try
            {
                IndicesRN oIndiceRN = new IndicesRN(Conexao, objOcorrencia, codempresa);

                DataTable dtCon;

                if (cboIdIndexador.SelectedValue == null)
                {
                                      
                    dtCon = oIndiceRN.pesquisaIndice(empMaster, 0, Convert.ToDateTime(txtDataIndice.Text), EmcResources.cCur(txtValor.Text), ckData.Checked);
                    grdIndice.DataSource = dtCon;
                   
                }
                else
                {
                     dtCon = oIndiceRN.pesquisaIndice(empMaster, EmcResources.cInt(cboIdIndexador.SelectedValue.ToString()), Convert.ToDateTime(txtDataIndice.Text), EmcResources.cCur(txtValor.Text), ckData.Checked);
                     grdIndice.DataSource = dtCon;
                }
                
            }
            catch (Exception erro)
            {
               MessageBox.Show("Erro Índices: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtValor.Value = 0;
            ckData.Checked = false;
            
            
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Indices oIndice = new Indices();
                IndicesRN oIndiceBLL = new IndicesRN(Conexao,objOcorrencia,codempresa);
                oIndice = montaIndice();

                oIndiceBLL.Salvar(oIndice);
                LimpaCampos();

                Indexador oIndex = new Indexador();
                oIndex.idIndexador = oIndice.indexador.idIndexador;
                AtualizaGrid(oIndex);
                cboIdIndexador.SelectedValue = oIndex.idIndexador;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indice: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Indices oIndice = new Indices();
                IndicesRN oIndiceBLL = new IndicesRN(Conexao,objOcorrencia,codempresa);
                oIndice = montaIndice();
                oIndice.idIndice = Convert.ToInt32(txtIdIndice.Text);

                oIndiceBLL.Atualizar(oIndice);
                LimpaCampos();

                Indexador oIndex = new Indexador();
                oIndex.idIndexador = oIndice.indexador.idIndexador;
                AtualizaGrid(oIndex);
                cboIdIndexador.SelectedValue = oIndex.idIndexador;
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indice: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Indices oIndice = new Indices();
                IndicesRN oIndiceBLL = new IndicesRN(Conexao,objOcorrencia,codempresa);
                oIndice = montaIndice();
                oIndice.idIndice = Convert.ToInt32(txtIdIndice.Text);

                oIndiceBLL.Excluir(oIndice);
                LimpaCampos();

                Indexador oIndex = new Indexador();
                oIndex.idIndexador = oIndice.indexador.idIndexador;
                AtualizaGrid(oIndex);
                cboIdIndexador.SelectedValue = oIndex.idIndexador;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Indice: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relIndicePeríodo ofrm = new Relatorios.relIndicePeríodo (usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Indice: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
                
        #endregion

        #region "metodos da dbgrid"

        private void grdIndice_DoubleClick(object sender, EventArgs e)
        {
            txtIdIndice.Text = grdIndice.Rows[grdIndice.CurrentRow.Index].Cells["idIndices"].Value.ToString();
            txtDataIndice.Text = grdIndice.Rows[grdIndice.CurrentRow.Index].Cells["dataIndice"].Value.ToString();
            txtDataIndice.Focus();
            BuscaIndices();
            AtivaEdicao();

        }
       
        private void AtualizaGrid(Indexador oIndexador)
        {
            //carrega a grid com os Indices cadastrados
            IndicesRN objIndice = new IndicesRN(Conexao,objOcorrencia,codempresa);
            grdIndice.DataSource = objIndice.ListaIndices(oIndexador);

        }


        #endregion

#region [Metodos para tratamento dos texts]

        private void txtValor_Enter(object sender, EventArgs e)
        {
            txtValor.Value = 0;
        }
#endregion

        private void cboIdIndexador_ValueMemberChanged(object sender, EventArgs e)
        {
          
        }

        private void cboIdIndexador_Validating(object sender, CancelEventArgs e)
        {
            Indexador oIndexador = new Indexador();
            oIndexador.idIndexador = Convert.ToInt32(cboIdIndexador.SelectedValue);
            AtualizaGrid(oIndexador);
        }
      
    }
}
