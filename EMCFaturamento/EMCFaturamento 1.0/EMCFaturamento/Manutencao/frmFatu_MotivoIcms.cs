using System;
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
using System.Collections;


namespace EMCFaturamento
{
    public partial class frmFatu_MotivoIcms : EMCLibrary.EMCForm
    {
         private const string nomeFormulario = "frmFatu_MotivoIcms";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        //controla a posição da linha da grid selecionada
        private int iLinhaSelecionada = 0;

       

        #region "metodos do form"

        public frmFatu_MotivoIcms()
        {
            InitializeComponent();
        }

         public frmFatu_MotivoIcms(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmFatu_MotivoIcms_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_MotivoIcms";

            this.ActiveControl = txtidFatu_MotivoIcms;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_MotivoIcms montaFatu_MotivoIcms()
        {
            Fatu_MotivoIcms oFatu_MotivoIcms = new Fatu_MotivoIcms();
            oFatu_MotivoIcms.idFatu_MotivoIcms = txtidFatu_MotivoIcms.Text;
            oFatu_MotivoIcms.descricao = txtDescricao.Text;
            oFatu_MotivoIcms.situacao = cboSituacao.SelectedValue.ToString();

            return oFatu_MotivoIcms;
        }
        private void montaTela(Fatu_MotivoIcms oFatu_MotivoIcms)
        {
            txtidFatu_MotivoIcms.Text = oFatu_MotivoIcms.idFatu_MotivoIcms.ToString();
            txtDescricao.Text = oFatu_MotivoIcms.descricao;
            cboSituacao.SelectedValue = oFatu_MotivoIcms.situacao;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_MotivoIcms.idFatu_MotivoIcms.ToString();
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
            if (!String.IsNullOrEmpty(txtidFatu_MotivoIcms.Text))
            {

                Fatu_MotivoIcms oFatu_MotivoIcms = new Fatu_MotivoIcms();
                try
                {
                    Fatu_MotivoIcmsRN Fatu_MotivoIcmsBLL = new Fatu_MotivoIcmsRN(Conexao, objOcorrencia,codempresa);

                    oFatu_MotivoIcms = montaFatu_MotivoIcms();
                    oFatu_MotivoIcms.idFatu_MotivoIcms = txtidFatu_MotivoIcms.Text;

                    oFatu_MotivoIcms = Fatu_MotivoIcmsBLL.ObterPor(oFatu_MotivoIcms);

                    if (String.IsNullOrEmpty(oFatu_MotivoIcms.descricao))
                    {
                        MessageBox.Show("Motivo Icms não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_MotivoIcms);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_MotivoIcms: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

            ArrayList arrSituacao = new ArrayList();
            arrSituacao.Add(new popCombo("Ativo", "A"));
            arrSituacao.Add(new popCombo("Inativo", "I"));
            cboSituacao.DataSource = arrSituacao;
            cboSituacao.DisplayMember = "nome";
            cboSituacao.ValueMember = "valor";

            txtidFatu_MotivoIcms.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                Fatu_MotivoIcms oFatu_MotivoIcms = new Fatu_MotivoIcms();
                Fatu_MotivoIcmsRN oFatu_MotivoIcmsBLL = new Fatu_MotivoIcmsRN(Conexao, objOcorrencia,codempresa);
                oFatu_MotivoIcms = montaFatu_MotivoIcms();

                oFatu_MotivoIcmsBLL.Salvar(oFatu_MotivoIcms);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void AtualizaObjeto()
        {
            try
            {
                Fatu_MotivoIcms oFatu_MotivoIcms = new Fatu_MotivoIcms();
                Fatu_MotivoIcmsRN oFatu_MotivoIcmsBLL = new Fatu_MotivoIcmsRN(Conexao, objOcorrencia,codempresa);
                oFatu_MotivoIcms = montaFatu_MotivoIcms();
                oFatu_MotivoIcms.idFatu_MotivoIcms = txtidFatu_MotivoIcms.Text;

                oFatu_MotivoIcmsBLL.Atualizar(oFatu_MotivoIcms);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void ExcluiObjeto()
        {
            try
            {
                Fatu_MotivoIcms oFatu_MotivoIcms = new Fatu_MotivoIcms();
                Fatu_MotivoIcmsRN oFatu_MotivoIcmsBLL = new Fatu_MotivoIcmsRN(Conexao, objOcorrencia,codempresa);
                oFatu_MotivoIcms = montaFatu_MotivoIcms();
                oFatu_MotivoIcms.idFatu_MotivoIcms = txtidFatu_MotivoIcms.Text;

                oFatu_MotivoIcmsBLL.Excluir(oFatu_MotivoIcms);
                iLinhaSelecionada = 0;
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }


        #endregion

        #region "metodos da dbgrid"

        private void grdFatu_MotivoIcms_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;

            //carregando os dados da grid nos campos da tela
            txtidFatu_MotivoIcms.Text = grdFatu_MotivoIcms.Rows[grdFatu_MotivoIcms.CurrentRow.Index].Cells["idFatu_MotivoIcms"].Value.ToString();
            txtidFatu_MotivoIcms.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_MotivoIcmsRN objFatu_MotivoIcms = new Fatu_MotivoIcmsRN(Conexao, objOcorrencia,codempresa);
            grdFatu_MotivoIcms.DataSource = objFatu_MotivoIcms.ListaFatu_MotivoIcms();

        }

        #endregion


        private void txtidFatu_MotivoIcms_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_MotivoIcms_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

    }
}
