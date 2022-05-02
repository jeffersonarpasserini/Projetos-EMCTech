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

namespace EMCFaturamento
{
    public partial class frmFatu_SituacaoPis : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_SituacaoPis";
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

        public frmFatu_SituacaoPis()
        {
            InitializeComponent();
        }

         public frmFatu_SituacaoPis(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmFatu_SituacaoPis_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_SituacaoPis";

            this.ActiveControl = txtidFatu_SituacaoPis;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_SituacaoPis montaFatu_SituacaoPis()
        {
            Fatu_SituacaoPis oFatu_SituacaoPis = new Fatu_SituacaoPis();
            oFatu_SituacaoPis.descricao = txtDescricao.Text;
            oFatu_SituacaoPis.codigoFiscal = txtCodigoFiscal.Text;

            return oFatu_SituacaoPis;
        }
        private void montaTela(Fatu_SituacaoPis oFatu_SituacaoPis)
        {
            txtidFatu_SituacaoPis.Text = oFatu_SituacaoPis.idFatu_SituacaoPis.ToString();
            txtDescricao.Text = oFatu_SituacaoPis.descricao;
            txtCodigoFiscal.Text = oFatu_SituacaoPis.codigoFiscal;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_SituacaoPis.idFatu_SituacaoPis.ToString();
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
            if (!String.IsNullOrEmpty(txtidFatu_SituacaoPis.Text))
            {

                Fatu_SituacaoPis oFatu_SituacaoPis = new Fatu_SituacaoPis();
                try
                {
                    Fatu_SituacaoPisRN Fatu_SituacaoPisBLL = new Fatu_SituacaoPisRN(Conexao, objOcorrencia,codempresa);

                    oFatu_SituacaoPis = montaFatu_SituacaoPis();
                    oFatu_SituacaoPis.idFatu_SituacaoPis = Convert.ToInt32(txtidFatu_SituacaoPis.Text);

                    oFatu_SituacaoPis = Fatu_SituacaoPisBLL.ObterPor(oFatu_SituacaoPis);

                    if (String.IsNullOrEmpty(oFatu_SituacaoPis.descricao))
                    {
                        MessageBox.Show("Situação Pis não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_SituacaoPis);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_SituacaoPis: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtCodigoFiscal.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                Fatu_SituacaoPis oFatu_SituacaoPis = new Fatu_SituacaoPis();
                Fatu_SituacaoPisRN oFatu_SituacaoPisBLL = new Fatu_SituacaoPisRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoPis = montaFatu_SituacaoPis();

                oFatu_SituacaoPisBLL.Salvar(oFatu_SituacaoPis);
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
                Fatu_SituacaoPis oFatu_SituacaoPis = new Fatu_SituacaoPis();
                Fatu_SituacaoPisRN oFatu_SituacaoPisBLL = new Fatu_SituacaoPisRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoPis = montaFatu_SituacaoPis();
                oFatu_SituacaoPis.idFatu_SituacaoPis = Convert.ToInt32(txtidFatu_SituacaoPis.Text);

                oFatu_SituacaoPisBLL.Atualizar(oFatu_SituacaoPis);
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
                Fatu_SituacaoPis oFatu_SituacaoPis = new Fatu_SituacaoPis();
                Fatu_SituacaoPisRN oFatu_SituacaoPisBLL = new Fatu_SituacaoPisRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoPis = montaFatu_SituacaoPis();
                oFatu_SituacaoPis.idFatu_SituacaoPis = Convert.ToInt32(txtidFatu_SituacaoPis.Text);

                oFatu_SituacaoPisBLL.Excluir(oFatu_SituacaoPis);
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

        private void grdFatu_SituacaoPis_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;

            if (grdFatu_SituacaoPis.CurrentRow != null)
            {
                iLinhaSelecionada = grdFatu_SituacaoPis.CurrentRow.Index;
            }


            //carregando os dados da grid nos campos da tela
            txtidFatu_SituacaoPis.Text = grdFatu_SituacaoPis.Rows[grdFatu_SituacaoPis.CurrentRow.Index].Cells["idFatu_SituacaoPis"].Value.ToString();
            txtidFatu_SituacaoPis.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_SituacaoPisRN objFatu_SituacaoPis = new Fatu_SituacaoPisRN(Conexao, objOcorrencia,codempresa);
            grdFatu_SituacaoPis.DataSource = objFatu_SituacaoPis.ListaFatu_SituacaoPis();

        }

        #endregion


        private void txtidFatu_SituacaoPis_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_SituacaoPis_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
