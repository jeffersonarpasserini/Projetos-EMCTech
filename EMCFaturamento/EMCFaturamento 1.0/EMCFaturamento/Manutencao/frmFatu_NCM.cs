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
    public partial class frmFatu_NCM : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_NCM";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        

        #region "metodos do form"

        public frmFatu_NCM()
        {
            InitializeComponent();
        }

        public frmFatu_NCM(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmFatu_NCM_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_NCM";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_NCM montaFatu_NCM()
        {
            Fatu_NCM oFatu_NCM = new Fatu_NCM();
            oFatu_NCM.descricao = txtDescricao.Text;
            oFatu_NCM.situacao = cboSituacao.SelectedValue.ToString();
            oFatu_NCM.nroncm = txtNroNCM.Text;
            oFatu_NCM.classificacaofiscal = txtClassificacaoFiscal.Text;

            return oFatu_NCM;
        }
        private void montaTela(Fatu_NCM oFatu_NCM)
        {
            txtidFatu_NCM.Text = oFatu_NCM.idfatu_ncm.ToString();
            txtDescricao.Text = oFatu_NCM.descricao;
            cboSituacao.SelectedValue = oFatu_NCM.situacao.ToString();
            txtNroNCM.Text = oFatu_NCM.nroncm;
            txtClassificacaoFiscal.Text = oFatu_NCM.classificacaofiscal;

            //desabilitando o campo NCM que deve ser único
            txtNroNCM.Enabled = false;


            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_NCM.idfatu_ncm.ToString();
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
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtDescricao.Focus();
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

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidFatu_NCM.Text))
            {

                Fatu_NCM oFatu_NCM = new Fatu_NCM();
                try
                {
                    Fatu_NCMRN Fatu_NCMBLL = new Fatu_NCMRN(Conexao, objOcorrencia, codempresa);

                    oFatu_NCM = montaFatu_NCM();
                    oFatu_NCM.idfatu_ncm = Convert.ToInt32(txtidFatu_NCM.Text);

                    oFatu_NCM = Fatu_NCMBLL.ObterPor(oFatu_NCM);

                    if (String.IsNullOrEmpty(oFatu_NCM.descricao))
                    {
                        MessageBox.Show("Código NCM não Cadastrado", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_NCM);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_NCM: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtNroNCM.Enabled = true;
            
            //montando combo's
            ArrayList arrEntradaSaida = new ArrayList();
            arrEntradaSaida.Add(new popCombo("Ativo", "A"));
            arrEntradaSaida.Add(new popCombo("Inativo", "I"));
            cboSituacao.DataSource = arrEntradaSaida;
            cboSituacao.DisplayMember = "nome";
            cboSituacao.ValueMember = "valor";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Fatu_NCM oFatu_NCM = new Fatu_NCM();
                Fatu_NCMRN oFatu_NCMBLL = new Fatu_NCMRN(Conexao, objOcorrencia,codempresa);
                oFatu_NCM = montaFatu_NCM();

                oFatu_NCMBLL.Salvar(oFatu_NCM);
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
                Fatu_NCM oFatu_NCM = new Fatu_NCM();
                Fatu_NCMRN oFatu_NCMBLL = new Fatu_NCMRN(Conexao, objOcorrencia,codempresa);
                oFatu_NCM = montaFatu_NCM();
                oFatu_NCM.idfatu_ncm = Convert.ToInt32(txtidFatu_NCM.Text);

                oFatu_NCMBLL.Atualizar(oFatu_NCM);
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
                Fatu_NCM oFatu_NCM = new Fatu_NCM();
                Fatu_NCMRN oFatu_NCMBLL = new Fatu_NCMRN(Conexao, objOcorrencia,codempresa);
                oFatu_NCM = montaFatu_NCM();
                oFatu_NCM.idfatu_ncm = Convert.ToInt32(txtidFatu_NCM.Text);

                oFatu_NCMBLL.Excluir(oFatu_NCM);

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

        private void grdFatu_NCM_DoubleClick(object sender, EventArgs e)
        {

            //carregando os dados da grid nos campos da tela
            txtidFatu_NCM.Text = grdFatu_NCM.Rows[grdFatu_NCM.CurrentRow.Index].Cells["idfatu_ncm"].Value.ToString();
            txtNroNCM.Text = "";
            txtidFatu_NCM.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_NCMRN objFatu_NCM = new Fatu_NCMRN(Conexao, objOcorrencia,codempresa);
            grdFatu_NCM.DataSource = objFatu_NCM.ListaFatu_NCM();

        }

        #endregion


        private void txtidFatu_NCM_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }
        private void txtNroNCM_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtidFatu_NCM_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
