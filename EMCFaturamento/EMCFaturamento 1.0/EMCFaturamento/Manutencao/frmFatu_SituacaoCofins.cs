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
    public partial class frmFatu_SituacaoCofins : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_SituacaoCofins";
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

        public frmFatu_SituacaoCofins()
        {
            InitializeComponent();
        }

         public frmFatu_SituacaoCofins(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmFatu_SituacaoCofins_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_SituacaoCofins";

            this.ActiveControl = txtidFatu_SituacaoCofins;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_SituacaoCofins montaFatu_SituacaoCofins()
        {
            Fatu_SituacaoCofins oFatu_SituacaoCofins = new Fatu_SituacaoCofins();
            oFatu_SituacaoCofins.descricao = txtDescricao.Text;
            oFatu_SituacaoCofins.codigoFiscal = txtCodigoFiscal.Text;

            return oFatu_SituacaoCofins;
        }
        private void montaTela(Fatu_SituacaoCofins oFatu_SituacaoCofins)
        {
            txtidFatu_SituacaoCofins.Text = oFatu_SituacaoCofins.idFatu_SituacaoCofins.ToString();
            txtDescricao.Text = oFatu_SituacaoCofins.descricao;
            txtCodigoFiscal.Text = oFatu_SituacaoCofins.codigoFiscal;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_SituacaoCofins.idFatu_SituacaoCofins.ToString();
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
            if (!String.IsNullOrEmpty(txtidFatu_SituacaoCofins.Text))
            {

                Fatu_SituacaoCofins oFatu_SituacaoCofins = new Fatu_SituacaoCofins();
                try
                {
                    Fatu_SituacaoCofinsRN Fatu_SituacaoCofinsBLL = new Fatu_SituacaoCofinsRN(Conexao, objOcorrencia,codempresa);

                    oFatu_SituacaoCofins = montaFatu_SituacaoCofins();
                    oFatu_SituacaoCofins.idFatu_SituacaoCofins = Convert.ToInt32(txtidFatu_SituacaoCofins.Text);

                    oFatu_SituacaoCofins = Fatu_SituacaoCofinsBLL.ObterPor(oFatu_SituacaoCofins);

                    if (String.IsNullOrEmpty(oFatu_SituacaoCofins.descricao))
                    {
                        MessageBox.Show("Situação Cofins não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_SituacaoCofins);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_SituacaoCofins: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Fatu_SituacaoCofins oFatu_SituacaoCofins = new Fatu_SituacaoCofins();
                Fatu_SituacaoCofinsRN oFatu_SituacaoCofinsBLL = new Fatu_SituacaoCofinsRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoCofins = montaFatu_SituacaoCofins();

                oFatu_SituacaoCofinsBLL.Salvar(oFatu_SituacaoCofins);
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
                Fatu_SituacaoCofins oFatu_SituacaoCofins = new Fatu_SituacaoCofins();
                Fatu_SituacaoCofinsRN oFatu_SituacaoCofinsBLL = new Fatu_SituacaoCofinsRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoCofins = montaFatu_SituacaoCofins();
                oFatu_SituacaoCofins.idFatu_SituacaoCofins = Convert.ToInt32(txtidFatu_SituacaoCofins.Text);

                oFatu_SituacaoCofinsBLL.Atualizar(oFatu_SituacaoCofins);
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
                Fatu_SituacaoCofins oFatu_SituacaoCofins = new Fatu_SituacaoCofins();
                Fatu_SituacaoCofinsRN oFatu_SituacaoCofinsBLL = new Fatu_SituacaoCofinsRN(Conexao, objOcorrencia,codempresa);
                oFatu_SituacaoCofins = montaFatu_SituacaoCofins();
                oFatu_SituacaoCofins.idFatu_SituacaoCofins = Convert.ToInt32(txtidFatu_SituacaoCofins.Text);

                oFatu_SituacaoCofinsBLL.Excluir(oFatu_SituacaoCofins);
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

        private void grdFatu_SituacaoCofins_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;

            if (grdFatu_SituacaoCofins.CurrentRow != null)
            {
                iLinhaSelecionada = grdFatu_SituacaoCofins.CurrentRow.Index;
            }


            //carregando os dados da grid nos campos da tela
            txtidFatu_SituacaoCofins.Text = grdFatu_SituacaoCofins.Rows[grdFatu_SituacaoCofins.CurrentRow.Index].Cells["idFatu_SituacaoCofins"].Value.ToString();
            txtidFatu_SituacaoCofins.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_SituacaoCofinsRN objFatu_SituacaoCofins = new Fatu_SituacaoCofinsRN(Conexao, objOcorrencia,codempresa);
            grdFatu_SituacaoCofins.DataSource = objFatu_SituacaoCofins.ListaFatu_SituacaoCofins();

        }

        #endregion


        private void txtidFatu_SituacaoCofins_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_SituacaoCofins_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
