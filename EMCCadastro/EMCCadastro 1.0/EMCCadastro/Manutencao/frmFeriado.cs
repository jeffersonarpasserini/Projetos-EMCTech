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
    public partial class frmFeriado : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFeriado";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmFeriado(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

#region "metodos do form"

        public frmFeriado()
        {
            InitializeComponent();
        }

        private void frmFeriado_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "feriado";

            AtualizaGrid();
            this.ActiveControl = txtDataFeriado;
            CancelaOperacao();
        }
#endregion


#region "metodos para tratamento das informacoes"
        
        private Feriado montaFeriado()
        {
            Feriado oFeriado = new Feriado();
            oFeriado.dataFeriado = Convert.ToDateTime(txtDataFeriado.Text);
            oFeriado.descricao = txtDescricao.Text;
            oFeriado.idFeriado = EmcResources.cInt(txtidFeriado.Text);

            return oFeriado;
        }
       
        private void montaTela(Feriado oFeriado)
        {
            txtDescricao.Text = oFeriado.descricao;
            txtidFeriado.Text = oFeriado.idFeriado.ToString();
            txtDataFeriado.Text = oFeriado.dataFeriado.ToShortDateString();

            objOcorrencia.chaveidentificacao = oFeriado.idFeriado.ToString();
            
            txtDescricao.Focus();
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
        
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDescricao.Focus();
        }
        
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtDataFeriado.Enabled = true;
            txtDataFeriado.Focus();
            
        }

        public override void BuscaObjeto()
      
        {
            base.BuscaObjeto();

            if (txtDataFeriado.Text.Trim().Length > 0)
            {

                Feriado oFeriado = new Feriado();

                try
                {
                    FeriadoRN FeriadoBLL = new FeriadoRN(Conexao, objOcorrencia, codempresa);
                    oFeriado = montaFeriado();
                    oFeriado = FeriadoBLL.ObterPor(oFeriado);

                    if (String.IsNullOrEmpty(oFeriado.descricao))
                    {
                        DialogResult result = MessageBox.Show("Feriado não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {

                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }

                    }
                    else
                    {
                        montaTela(oFeriado);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Feriado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Feriado oFeriado = new Feriado();
                FeriadoRN oFeriadoBLL = new FeriadoRN(Conexao,objOcorrencia,codempresa);
                oFeriado = montaFeriado();

                oFeriadoBLL.Salvar(oFeriado);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Feriado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Feriado oFeriado = new Feriado();
                FeriadoRN oFeriadoBLL = new FeriadoRN(Conexao,objOcorrencia,codempresa);
                oFeriado = montaFeriado();
                oFeriado.idFeriado = Convert.ToInt32(txtidFeriado.Text);

                oFeriadoBLL.Atualizar(oFeriado);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Feriado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          //  base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Feriado oFeriado = new Feriado();
                FeriadoRN oFeriadoBLL = new FeriadoRN(Conexao,objOcorrencia,codempresa);
                oFeriado = montaFeriado();
                oFeriado.idFeriado = Convert.ToInt32(txtidFeriado.Text);

                oFeriadoBLL.Excluir(oFeriado);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Feriado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {

            try
            {
                //base.ImprimeObjeto();
                Relatorios.relFeriado ofrm = new Relatorios.relFeriado(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Feriado: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdFeriado_DoubleClick(object sender, EventArgs e)
        {
            txtidFeriado.Enabled = true;
            txtidFeriado.Text = grdFeriado.Rows[grdFeriado.CurrentRow.Index].Cells["idferiados"].Value.ToString();
            txtDataFeriado.Text = grdFeriado.Rows[grdFeriado.CurrentRow.Index].Cells["dataferiado"].Value.ToString();
            txtDataFeriado.Focus();
            SendKeys.Send("{TAB}");
            
           // BuscaObjeto();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Feriados cadastrados
            FeriadoRN objFeriado = new FeriadoRN(Conexao,objOcorrencia,codempresa);
            grdFeriado.DataSource = objFeriado.ListaFeriado();
        }


        #endregion

        private void txtidFeriado_TextChanged(object sender, EventArgs e)
        {
            //BuscaObjeto();
        }

        private void txtidFeriado_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFeriado_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtDataFeriado_Validating(object sender, CancelEventArgs e)
        {
           BuscaObjeto();
    
        }

    }
}
