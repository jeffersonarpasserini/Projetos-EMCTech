using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurityModel;
using EMCSecurityRN;
using System.Collections;

namespace EMCSecurity
{
    public partial class frmParametro : EMCLibrary.EMCForm
    {
        private const string descricao = "frmParametro";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmParametro()
        {
            InitializeComponent();
        }

        public frmParametro(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmParametro_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = descricao;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "Parametro";

            AtualizaGrid();
            this.ActiveControl = txtAplicacao;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaParametro(Parametro oParametro)
        {
            ParametroRN oParametroRN = new ParametroRN(Conexao);
            try
            {
                oParametroRN.VerificaDados(oParametro);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Parametro: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Parametro montaParametro()
        {

            Parametro oParametro = new Parametro();

            oParametro.idParametro = EmcResources.cInt(txtIdParametro.Text);
            oParametro.aplicacao = txtAplicacao.Text;
            oParametro.sessao = txtSessao.Text;
            oParametro.chave = txtChave.Text;
            oParametro.tipo = cboTipo.SelectedValue.ToString();
            oParametro.valor = txtValor.Text;
            oParametro.descricao = txtDescricao.Text;
            oParametro.codEmpresa = codempresa;            

            return oParametro;
        }

        private void montaTela(Parametro oParametro)
        {
            txtIdParametro.Text = oParametro.idParametro.ToString();
            txtAplicacao.Text = oParametro.aplicacao;
            txtSessao.Text = oParametro.sessao;
            txtChave.Text = oParametro.chave;
            cboTipo.SelectedValue = oParametro.tipo;
            txtValor.Text = oParametro.valor;
            txtDescricao.Text = oParametro.descricao;

            objOcorrencia.chaveidentificacao = oParametro.idParametro.ToString();

            txtAplicacao.Enabled = true;
            txtAplicacao.Focus();
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            //txtIdHistorico.Enabled = false;
        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, descricao, btnFlag))
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

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();

            txtAplicacao.Enabled = true;
            txtSessao.Enabled = true;
            txtChave.Enabled = true;
            txtAplicacao.Focus();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtAplicacao.Enabled = true;
            txtSessao.Enabled = true;
            txtChave.Enabled = true;
            objOcorrencia.chaveidentificacao = "";


            ArrayList ar = new ArrayList();
            ar.Add(new popCombo("C - CARACTERES", "C"));
            ar.Add(new popCombo("I - INTEIROS", "I"));
            ar.Add(new popCombo("D - DATA", "D"));
            ar.Add(new popCombo("B - BOOLEANO", "B"));
            ar.Add(new popCombo("F - DECIMAL", "F"));
            cboTipo.DataSource = ar;
            cboTipo.DisplayMember = "nome";
            cboTipo.ValueMember = "valor";


            txtAplicacao.Focus();

            AtualizaGrid();

        }

        public override void BuscaObjeto()
        {
            try
            {
                Parametro oParametro = new Parametro();
                if (!String.IsNullOrEmpty(txtAplicacao.Text))
                    oParametro.aplicacao = txtAplicacao.Text;

                if (!String.IsNullOrEmpty(txtSessao.Text))
                    oParametro.sessao = txtSessao.Text;

                if (!String.IsNullOrEmpty(txtChave.Text))
                    oParametro.chave = txtChave.Text;

                oParametro.codEmpresa = codempresa;

                ParametroRN oParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                grdParametro.DataSource = oParametroRN.ListaParametro(oParametro);


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Menu Sistema: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaParametro()
        {
            if (!String.IsNullOrEmpty(txtIdParametro.Text))
            {
                Parametro oParametro = new Parametro();
                oParametro.idParametro = EmcResources.cInt(txtIdParametro.Text);
                oParametro.aplicacao = txtAplicacao.Text;
                oParametro.sessao = txtSessao.Text;
                oParametro.chave = txtChave.Text;
                oParametro.codEmpresa = codempresa;

                try
                {
                    ParametroRN ParametroRN = new ParametroRN(Conexao);
                    oParametro = ParametroRN.ObterPor(oParametro);

                    if (oParametro.idParametro == 0)
                    {
                        DialogResult result = MessageBox.Show("Parametro não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtAplicacao.Enabled = false;
                        txtSessao.Enabled = false;
                        txtChave.Enabled = false;
                        //   txtValor.Focus();
                    }
                    else
                    {
                        montaTela(oParametro);
                        AtivaEdicao();
                        txtSessao.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Parametro: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            cboTipo.SelectedIndex = -1;

        }

        public override void SalvaObjeto()
        {
            try
            {
                Parametro oParametro = new Parametro();
                ParametroRN oParametroRN = new ParametroRN(Conexao);


                oParametro = montaParametro();

                if (verificaParametro(oParametro))
                {
                    oParametroRN.Salvar(oParametro);

                    montaTela(oParametro);
                    LimpaCampos();
                    txtAplicacao.Focus();
                    AtualizaGrid();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Parametro oParametro = new Parametro();
                ParametroRN oParametroRN = new ParametroRN(Conexao);

                oParametro = montaParametro();
                oParametro.idParametro = EmcResources.cInt(txtIdParametro.Text);


                if (verificaParametro(oParametro))
                {

                    oParametroRN.Atualizar(oParametro);

                    LimpaCampos();
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oParametro);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Parametro oParametro = new Parametro();
                ParametroRN oParametroRN = new ParametroRN(Conexao);
                oParametro = montaParametro();
                oParametro.idParametro = EmcResources.cInt(txtIdParametro.Text);

                if (verificaParametro(oParametro))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Parametro ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oParametroRN.Excluir(oParametro);

                        LimpaCampos();
                        MessageBox.Show("Parametro excluido!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.ExcluiObjeto();
        }

        #endregion


        #region "metodos da dbgrid*******************************************************************************************"

        private void grdParametro_DoubleClick(object sender, EventArgs e)
        {
            txtAplicacao.Enabled = true;
            txtIdParametro.Text = grdParametro.Rows[grdParametro.CurrentRow.Index].Cells["idparametro"].Value.ToString();
            BuscaParametro();
        }

        private void AtualizaGrid()
        {
            ParametroRN oParametroRN = new ParametroRN(Conexao);
            Parametro oParametro = new Parametro();
            oParametro.codEmpresa = codempresa;
            grdParametro.DataSource = oParametroRN.ListaParametro(oParametro);
        }


        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtIdParametro_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdParametro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void txtAplicacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAplicacao.Text) &&
                    !String.IsNullOrEmpty(txtSessao.Text) &&
                    !String.IsNullOrEmpty(txtChave.Text))
                {
                    Parametro oParametro = new Parametro();
                    oParametro.aplicacao = txtAplicacao.Text;
                    oParametro.sessao = txtSessao.Text;
                    oParametro.chave = txtChave.Text;
                    oParametro.codEmpresa = codempresa;

                    ParametroRN ParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                    oParametro = ParametroRN.ObterPor(oParametro);

                    if (oParametro.idParametro == 0)
                    {
                        DialogResult result = MessageBox.Show("Parametro não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtAplicacao.Enabled = false;
                        txtSessao.Enabled = false;
                        txtChave.Enabled = false;
                        cboTipo.Focus();
                    }
                    else
                    {
                        montaTela(oParametro);
                        AtivaEdicao();
                        cboTipo.Focus();
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Parametro: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSessao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAplicacao.Text) &&
                    !String.IsNullOrEmpty(txtSessao.Text) &&
                    !String.IsNullOrEmpty(txtChave.Text))
                {
                    Parametro oParametro = new Parametro();
                    oParametro.aplicacao = txtAplicacao.Text;
                    oParametro.sessao = txtSessao.Text;
                    oParametro.chave = txtChave.Text;
                    oParametro.codEmpresa = codempresa;

                    ParametroRN ParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                    oParametro = ParametroRN.ObterPor(oParametro);

                    if (oParametro.idParametro == 0)
                    {
                        DialogResult result = MessageBox.Show("Parametro não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtAplicacao.Enabled = false;
                        txtSessao.Enabled = false;
                        txtChave.Enabled = false;
                        cboTipo.Focus();
                    }
                    else
                    {
                        montaTela(oParametro);
                        AtivaEdicao();
                        cboTipo.Focus();
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Parametro: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtChave_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAplicacao.Text) &&
                    !String.IsNullOrEmpty(txtSessao.Text) &&
                    !String.IsNullOrEmpty(txtChave.Text))
                {
                    Parametro oParametro = new Parametro();
                    oParametro.aplicacao = txtAplicacao.Text;
                    oParametro.sessao = txtSessao.Text;
                    oParametro.chave = txtChave.Text;
                    oParametro.codEmpresa = codempresa;

                    ParametroRN ParametroRN = new ParametroRN(Conexao, objOcorrencia, codempresa);
                    oParametro = ParametroRN.ObterPor(oParametro);

                    if (oParametro.idParametro == 0)
                    {
                        DialogResult result = MessageBox.Show("Parametro não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtAplicacao.Enabled = false;
                        txtSessao.Enabled = false;
                        txtChave.Enabled = false;
                        cboTipo.Focus();
                    }
                    else
                    {
                        montaTela(oParametro);
                        AtivaEdicao();
                        cboTipo.Focus();
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Parametro: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
