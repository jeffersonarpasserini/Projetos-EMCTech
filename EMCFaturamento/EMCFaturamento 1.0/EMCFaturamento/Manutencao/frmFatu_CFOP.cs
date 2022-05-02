using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFaturamentoModel;
using EMCFaturamentoRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;


namespace EMCFaturamento
{
    public partial class frmFatu_CFOP : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_CFOP";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();



        public frmFatu_CFOP(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmFatu_CFOP()
        {
            InitializeComponent();
        }


        private void frmFatu_CFOP_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_CFOP";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_CFOP montaFatu_CFOP()
        {
            Fatu_CFOP oFatu_CFOP = new Fatu_CFOP();
            oFatu_CFOP.descricao = txtDescricao.Text;
            oFatu_CFOP.nrocfop = txtNroCFOP.Text;
            oFatu_CFOP.observacao = txtObservacao.Text;

            return oFatu_CFOP;
        }
        private void montaTela(Fatu_CFOP oFatu_CFOP)
        {
            txtidFatu_CFOP.Text = oFatu_CFOP.idfatu_cfop.ToString();
            txtDescricao.Text = oFatu_CFOP.descricao;
            txtNroCFOP.Text = oFatu_CFOP.nrocfop;
            txtObservacao.Text = oFatu_CFOP.observacao;

            //desabilitando o campo CFOP que é único
            txtNroCFOP.Enabled = false;
 

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_CFOP.idfatu_cfop.ToString();
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
            txtidFatu_CFOP.Enabled = false;
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDescricao.Focus();
            txtidFatu_CFOP.Enabled = false;
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidFatu_CFOP.Enabled = true;
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidFatu_CFOP.Text))
            {

                Fatu_CFOP oFatu_CFOP = new Fatu_CFOP();
                try
                {
                    Fatu_CFOPRN Fatu_CFOPBLL = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);

                    oFatu_CFOP = montaFatu_CFOP();
                    oFatu_CFOP.idfatu_cfop = Convert.ToInt32(txtidFatu_CFOP.Text);

                    oFatu_CFOP = Fatu_CFOPBLL.ObterPor(oFatu_CFOP);

                    if (String.IsNullOrEmpty(oFatu_CFOP.descricao))
                    {
                        MessageBox.Show("Código CFOP não Cadastrado", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_CFOP);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_CFOP: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

            txtNroCFOP.Enabled = true;
        }

        public override void SalvaObjeto()
        {
            try
            {

                Fatu_CFOP oFatu_CFOP = new Fatu_CFOP();
                Fatu_CFOPRN oFatu_CFOPBLL = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                oFatu_CFOP = montaFatu_CFOP();

                oFatu_CFOPBLL.Salvar(oFatu_CFOP);
                AtualizaGrid();
                LimpaCampos();
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
                Fatu_CFOP oFatu_CFOP = new Fatu_CFOP();
                Fatu_CFOPRN oFatu_CFOPBLL = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                oFatu_CFOP = montaFatu_CFOP();
                oFatu_CFOP.idfatu_cfop = Convert.ToInt32(txtidFatu_CFOP.Text);

                oFatu_CFOPBLL.Atualizar(oFatu_CFOP);
                AtualizaGrid();
                LimpaCampos();
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
                Fatu_CFOP oFatu_CFOP = new Fatu_CFOP();
                Fatu_CFOPRN oFatu_CFOPBLL = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
                oFatu_CFOP = montaFatu_CFOP();
                oFatu_CFOP.idfatu_cfop = Convert.ToInt32(txtidFatu_CFOP.Text);

                oFatu_CFOPBLL.Excluir(oFatu_CFOP);

                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdFatu_CFOP_DoubleClick(object sender, EventArgs e)
        {
            LimpaCampos();
           
            //carregando os dados da grid nos campos da tela
            txtidFatu_CFOP.Text = grdFatu_CFOP.Rows[grdFatu_CFOP.CurrentRow.Index].Cells["idFatu_CFOP"].Value.ToString();
            txtidFatu_CFOP_Validating(null, null);
        
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_CFOPRN objFatu_CFOP = new Fatu_CFOPRN(Conexao, objOcorrencia, codempresa);
            grdFatu_CFOP.DataSource = objFatu_CFOP.ListaFatu_CFOP();

            
        }

        #endregion


        private void txtidFatu_CFOP_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        private void txtNroCFOP_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtidFatu_CFOP_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
