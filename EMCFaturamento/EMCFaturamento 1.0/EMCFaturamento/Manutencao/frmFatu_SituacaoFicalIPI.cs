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
    public partial class frmFatu_SituacaoFiscalIPI : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFatu_SituacaoFiscalIPI";
        private const string nomeAplicativo = "EMCFaturamento";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        //controla a posição da linha da grid selecionada
        private int iLinhaSelecionada = 0;

        public frmFatu_SituacaoFiscalIPI(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmFatu_SituacaoFiscalIPI()
        {
            InitializeComponent();
        }


        private void frmFatu_SituacaoFiscalIPI_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Fatu_SituacaoFiscalIPI";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
        
        private Fatu_SituacaoFiscalIPI montaFatu_SituacaoFiscalIPI()
        {
            Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
            oFatu_SituacaoFiscalIPI.codigosituacaoipi = txtCodigoSituacaoIPI.Text;
            oFatu_SituacaoFiscalIPI.descricao = txtDescricao.Text;
            oFatu_SituacaoFiscalIPI.entradasaida = cboEntradaSaida.SelectedValue.ToString();

            return oFatu_SituacaoFiscalIPI;
        }
        private void montaTela(Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI)
        {
            txtidFatu_SituacaoFiscalIPI.Text = oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi.ToString();
            txtCodigoSituacaoIPI.Text = oFatu_SituacaoFiscalIPI.codigosituacaoipi;
            txtDescricao.Text = oFatu_SituacaoFiscalIPI.descricao;
            cboEntradaSaida.SelectedValue = oFatu_SituacaoFiscalIPI.entradasaida.ToString();


            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi.ToString();
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
            txtCodigoSituacaoIPI.Focus();
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
            if (!String.IsNullOrEmpty(txtidFatu_SituacaoFiscalIPI.Text))
            {

                Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
                try
                {
                    Fatu_SituacaoFiscalIPIRN Fatu_SituacaoFiscalIPIBLL = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia,codempresa);

                    oFatu_SituacaoFiscalIPI = montaFatu_SituacaoFiscalIPI();
                    oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi = Convert.ToInt32(txtidFatu_SituacaoFiscalIPI.Text);

                    oFatu_SituacaoFiscalIPI = Fatu_SituacaoFiscalIPIBLL.ObterPor(oFatu_SituacaoFiscalIPI);

                    if (String.IsNullOrEmpty(oFatu_SituacaoFiscalIPI.descricao))
                    {
                        MessageBox.Show("Situação Fiscal IPI não Cadastrada", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        montaTela(oFatu_SituacaoFiscalIPI);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Fatu_SituacaoFiscalIPI: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            
            //montando combo's
            ArrayList arrEntradaSaida = new ArrayList();
            arrEntradaSaida.Add(new popCombo("Entrada", "E"));
            arrEntradaSaida.Add(new popCombo("Saída", "S"));
            cboEntradaSaida.DataSource = arrEntradaSaida;
            cboEntradaSaida.DisplayMember = "nome";
            cboEntradaSaida.ValueMember = "valor";

        }

        public override void SalvaObjeto()
        {
            try
            {

                Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
                Fatu_SituacaoFiscalIPIRN oFatu_SituacaoFiscalIPIBLL = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
                oFatu_SituacaoFiscalIPI = montaFatu_SituacaoFiscalIPI();

                oFatu_SituacaoFiscalIPIBLL.Salvar(oFatu_SituacaoFiscalIPI);
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
                Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
                Fatu_SituacaoFiscalIPIRN oFatu_SituacaoFiscalIPIBLL = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
                oFatu_SituacaoFiscalIPI = montaFatu_SituacaoFiscalIPI();
                oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi = Convert.ToInt32(txtidFatu_SituacaoFiscalIPI.Text);

                oFatu_SituacaoFiscalIPIBLL.Atualizar(oFatu_SituacaoFiscalIPI);
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
                Fatu_SituacaoFiscalIPI oFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPI();
                Fatu_SituacaoFiscalIPIRN oFatu_SituacaoFiscalIPIBLL = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
                oFatu_SituacaoFiscalIPI = montaFatu_SituacaoFiscalIPI();
                oFatu_SituacaoFiscalIPI.idfatu_situacaofiscalipi = Convert.ToInt32(txtidFatu_SituacaoFiscalIPI.Text);

                oFatu_SituacaoFiscalIPIBLL.Excluir(oFatu_SituacaoFiscalIPI);
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

        private void grdFatu_SituacaoFiscalIPI_DoubleClick(object sender, EventArgs e)
        {
            //armazenando a posição a linha selecionada
            iLinhaSelecionada = 0;
            
            if (grdFatu_SituacaoFiscalIPI.CurrentRow != null)
            {
                iLinhaSelecionada = grdFatu_SituacaoFiscalIPI.CurrentRow.Index;
            }


            //carregando os dados da grid nos campos da tela
            txtidFatu_SituacaoFiscalIPI.Text = grdFatu_SituacaoFiscalIPI.Rows[grdFatu_SituacaoFiscalIPI.CurrentRow.Index].Cells["idfatu_situacaofiscalipi"].Value.ToString();
            txtidFatu_SituacaoFiscalIPI.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Fatu_SituacaoFiscalIPIRN objFatu_SituacaoFiscalIPI = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia,codempresa);
            grdFatu_SituacaoFiscalIPI.DataSource = objFatu_SituacaoFiscalIPI.ListaFatu_SituacaoFiscalIPI("T");

            //setando a linha selecionada
            if (grdFatu_SituacaoFiscalIPI.RowCount > 0) grdFatu_SituacaoFiscalIPI.Rows[iLinhaSelecionada].Selected = true;
            
        }
                
        #endregion


        private void txtidFatu_SituacaoFiscalIPI_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtidFatu_SituacaoFiscalIPI_KeyPress(object sender, KeyPressEventArgs e)
        //permite digitar somente numeros no campo CFOP
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
