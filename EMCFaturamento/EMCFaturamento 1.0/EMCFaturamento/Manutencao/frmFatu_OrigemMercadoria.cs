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
    public partial class frmFatu_OrigemMercadoria : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_OrigemMercadoria";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        //controla a posição da linha da grid selecionada
        private int iLinhaSelecionada = 0;

        public frmFatu_OrigemMercadoria(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmFatu_OrigemMercadoria()
        {
            InitializeComponent();
        }


        private void frmFatu_OrigemMercadoria_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_OrigemMercadoria";

            this.ActiveControl = txtCodigoOrigem;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Fatu_OrigemMercadoria montaFatu_OrigemMercadoria()
        {
            Fatu_OrigemMercadoria oFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
            oFatu_OrigemMercadoria.descricao = txtDescricao.Text;
            oFatu_OrigemMercadoria.codigoOrigem = txtCodigoOrigem.Text;

            return oFatu_OrigemMercadoria;
        }
        private void montaTela(Fatu_OrigemMercadoria oFatu_OrigemMercadoria)
        {
            txtidFatu_OrigemMercadoria.Text = oFatu_OrigemMercadoria.idfatu_origemmercadoria.ToString();
            txtDescricao.Text = oFatu_OrigemMercadoria.descricao;
            txtCodigoOrigem.Text = oFatu_OrigemMercadoria.codigoOrigem;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_OrigemMercadoria.idfatu_origemmercadoria.ToString();
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
            if (!String.IsNullOrEmpty(txtidFatu_OrigemMercadoria.Text))
            {

                Fatu_OrigemMercadoria oFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
                try
                {
                    Fatu_OrigemMercadoriaRN Fatu_OrigemMercadoriaBLL = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia,codempresa);

                    oFatu_OrigemMercadoria = montaFatu_OrigemMercadoria();
                    oFatu_OrigemMercadoria.idfatu_origemmercadoria = Convert.ToInt32(txtidFatu_OrigemMercadoria.Text);

                    oFatu_OrigemMercadoria = Fatu_OrigemMercadoriaBLL.ObterPor(oFatu_OrigemMercadoria);

                    if (String.IsNullOrEmpty(oFatu_OrigemMercadoria.descricao))
                    {
                        MessageBox.Show("Origem da Mercadoria não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_OrigemMercadoria);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_OrigemMercadoria: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                Fatu_OrigemMercadoria oFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
                Fatu_OrigemMercadoriaRN oFatu_OrigemMercadoriaBLL = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia,codempresa);
                oFatu_OrigemMercadoria = montaFatu_OrigemMercadoria();

                oFatu_OrigemMercadoriaBLL.Salvar(oFatu_OrigemMercadoria);
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
                Fatu_OrigemMercadoria oFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
                Fatu_OrigemMercadoriaRN oFatu_OrigemMercadoriaBLL = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia,codempresa);
                oFatu_OrigemMercadoria = montaFatu_OrigemMercadoria();
                oFatu_OrigemMercadoria.idfatu_origemmercadoria = Convert.ToInt32(txtidFatu_OrigemMercadoria.Text);

                oFatu_OrigemMercadoriaBLL.Atualizar(oFatu_OrigemMercadoria);
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
                Fatu_OrigemMercadoria oFatu_OrigemMercadoria = new Fatu_OrigemMercadoria();
                Fatu_OrigemMercadoriaRN oFatu_OrigemMercadoriaBLL = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia,codempresa);
                oFatu_OrigemMercadoria = montaFatu_OrigemMercadoria();
                oFatu_OrigemMercadoria.idfatu_origemmercadoria = Convert.ToInt32(txtidFatu_OrigemMercadoria.Text);

                oFatu_OrigemMercadoriaBLL.Excluir(oFatu_OrigemMercadoria);
                iLinhaSelecionada = 0;
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

        private void grdFatu_OrigemMercadoria_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;

            if (grdFatu_OrigemMercadoria.CurrentRow != null)
            {
                iLinhaSelecionada = grdFatu_OrigemMercadoria.CurrentRow.Index;
            }


            //carregando os dados da grid nos campos da tela
            txtidFatu_OrigemMercadoria.Text = grdFatu_OrigemMercadoria.Rows[grdFatu_OrigemMercadoria.CurrentRow.Index].Cells["idFatu_OrigemMercadoria"].Value.ToString();
            txtidFatu_OrigemMercadoria.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_OrigemMercadoriaRN objFatu_OrigemMercadoria = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia,codempresa);
            grdFatu_OrigemMercadoria.DataSource = objFatu_OrigemMercadoria.ListaFatu_OrigemMercadoria();

            //setando a linha selecionada
            if (grdFatu_OrigemMercadoria.RowCount > 0) grdFatu_OrigemMercadoria.Rows[iLinhaSelecionada].Selected = true;
        }

        #endregion


        private void txtidFatu_OrigemMercadoria_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_OrigemMercadoria_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
