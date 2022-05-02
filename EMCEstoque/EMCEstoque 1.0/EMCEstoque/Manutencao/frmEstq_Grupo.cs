using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCEstoque
{
    public partial class frmEstq_Grupo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Grupo";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_Grupo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Grupo()
        {
            InitializeComponent();
        }

        private void frmEstq_Grupo_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Grupo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Grupo";


            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
     
        private Estq_Grupo montaEstq_Grupo()
        {
            Estq_Grupo oEstq_Grupo = new Estq_Grupo();
            oEstq_Grupo.descricao = txtDescricao.Text;
            oEstq_Grupo.faturamentoentrada = cboFaturamentoEntrada.SelectedValue.ToString();
            oEstq_Grupo.faturamentosaida = cboFaturamentoSaida.SelectedValue.ToString();
            return oEstq_Grupo;
        }
        private void montaTela(Estq_Grupo oEstq_Grupo)
        {
            txtDescricao.Text = oEstq_Grupo.descricao;
            txtidEstq_Grupo.Text = oEstq_Grupo.idestq_grupo.ToString();
            cboFaturamentoEntrada.SelectedValue = oEstq_Grupo.faturamentoentrada.ToString();
            cboFaturamentoSaida.SelectedValue = oEstq_Grupo.faturamentosaida.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Grupo.idestq_grupo.ToString();
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
            txtidEstq_Grupo.Enabled = true;
            txtidEstq_Grupo.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqGrupoEstoque ofrm = new psqGrupoEstoque(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_Grupo.Enabled = true;
                    txtidEstq_Grupo.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_Grupo.Focus();
                    SendKeys.Send("{TAB}");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";

            //montando combo's
            ArrayList arrFaturamentoEntrada = new ArrayList();
            arrFaturamentoEntrada.Add(new popCombo("Sim", "S"));
            arrFaturamentoEntrada.Add(new popCombo("Não", "N"));
            cboFaturamentoEntrada.DataSource = arrFaturamentoEntrada;
            cboFaturamentoEntrada.DisplayMember = "nome";
            cboFaturamentoEntrada.ValueMember = "valor";

            ArrayList arrFaturamentoSaida = new ArrayList();
            arrFaturamentoSaida.Add(new popCombo("Sim", "S"));
            arrFaturamentoSaida.Add(new popCombo("Não", "N"));
            cboFaturamentoSaida.DataSource = arrFaturamentoSaida;
            cboFaturamentoSaida.DisplayMember = "nome";
            cboFaturamentoSaida.ValueMember = "valor";
        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                Estq_GrupoRN oEstq_GrupoBLL = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Grupo = montaEstq_Grupo();

                oEstq_GrupoBLL.Salvar(oEstq_Grupo);
                AtualizaGrid();
                LimpaCampos();
                AtivaInsercao();
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
                Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                Estq_GrupoRN oEstq_GrupoBLL = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Grupo = montaEstq_Grupo();
                oEstq_Grupo.idestq_grupo = Convert.ToInt32(txtidEstq_Grupo.Text);

                oEstq_GrupoBLL.Atualizar(oEstq_Grupo);
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
                Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                Estq_GrupoRN oEstq_GrupoBLL = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Grupo = montaEstq_Grupo();
                oEstq_Grupo.idestq_grupo = Convert.ToInt32(txtidEstq_Grupo.Text);

                oEstq_GrupoBLL.Excluir(oEstq_Grupo);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaGrupoEstoque()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Grupo.Text))
            {

                Estq_Grupo oEstq_Grupo = new Estq_Grupo();
                try
                {
                    Estq_GrupoRN Estq_GrupoBLL = new Estq_GrupoRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Grupo = montaEstq_Grupo();
                    oEstq_Grupo.idestq_grupo = Convert.ToInt32(txtidEstq_Grupo.Text);

                    oEstq_Grupo = Estq_GrupoBLL.ObterPor(oEstq_Grupo);

                    if (String.IsNullOrEmpty(oEstq_Grupo.descricao))
                    {
                        DialogResult result = MessageBox.Show("Grupo não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Grupo);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Grupo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Grupo_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_Grupo.Text = grdEstq_Grupo.Rows[grdEstq_Grupo.CurrentRow.Index].Cells["idEstq_Grupo"].Value.ToString();
            txtidEstq_Grupo.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Estq_GrupoRN objEstq_Grupo = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Grupo.DataSource = objEstq_Grupo.ListaEstq_Grupo();
        }


        #endregion


        private void txtidEstq_Grupo_Validating(object sender, CancelEventArgs e)
        {
            BuscaGrupoEstoque();
        }



    }
}
