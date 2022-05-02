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
    public partial class frmCusto_Componente : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCusto_Componente";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmCusto_Componente(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmCusto_Componente()
        {
            InitializeComponent();
        }

        private void frmCusto_Componente_Activated(object sender, EventArgs e)
        {


        }

        private void frmCusto_Componente_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Custo_Componente";

            //carregando as combos na entrada da tela
            Custo_ComponenteGrupoRN oCusto_ComponenteGrupoRN = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
            cboCusto_ComponenteGrupo.DataSource = oCusto_ComponenteGrupoRN.ListaCusto_ComponenteGrupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboCusto_ComponenteGrupo.ValueMember = "idcusto_componentegrupo";
            cboCusto_ComponenteGrupo.DisplayMember = "descricao";

            this.ActiveControl = txtidCusto_Componente;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Custo_Componente montaCusto_Componente()
        {
            Custo_Componente oCusto_Componente = new Custo_Componente();
            oCusto_Componente.descricao = txtDescricao.Text;
            //Grupo de Componente de Custo
            Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
            oCusto_ComponenteGrupo.idcusto_componentegrupo = EmcResources.cInt(txtidGrupo_Componente.Text);
            Custo_ComponenteGrupoRN oCusto_ComponenteGrupoRN = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
            oCusto_Componente.Custo_ComponenteGrupo = oCusto_ComponenteGrupoRN.ObterPor(oCusto_ComponenteGrupo);

            return oCusto_Componente;
        }
     
        private void montaTela(Custo_Componente oCusto_Componente)
        {
            txtidCusto_Componente.Text = oCusto_Componente.idcusto_componente.ToString();
            txtDescricao.Text = oCusto_Componente.descricao;
            //Grupo do Componente de Custo
            txtidGrupo_Componente.Text = oCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo.ToString();
            cboCusto_ComponenteGrupo.SelectedValue = oCusto_Componente.Custo_ComponenteGrupo.idcusto_componentegrupo.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oCusto_Componente.idcusto_componente.ToString();
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
            txtidCusto_Componente.Enabled = true;
            txtidCusto_Componente.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqCustoComponente ofrm = new psqCustoComponente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidCusto_Componente.Enabled = true;
                    txtidCusto_Componente.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtidCusto_Componente.Focus();
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
        }

        public override void SalvaObjeto()
        {
            try
            {

                Custo_Componente oCusto_Componente = new Custo_Componente();
                Custo_ComponenteRN oCusto_ComponenteBLL = new Custo_ComponenteRN(Conexao, objOcorrencia,codempresa);
                oCusto_Componente = montaCusto_Componente();

                oCusto_ComponenteBLL.Salvar(oCusto_Componente);
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
                Custo_Componente oCusto_Componente = new Custo_Componente();
                Custo_ComponenteRN oCusto_ComponenteBLL = new Custo_ComponenteRN(Conexao, objOcorrencia,codempresa);
                oCusto_Componente = montaCusto_Componente();
                oCusto_Componente.idcusto_componente = Convert.ToInt32(txtidCusto_Componente.Text);

                oCusto_ComponenteBLL.Atualizar(oCusto_Componente);
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
                Custo_Componente oCusto_Componente = new Custo_Componente();
                Custo_ComponenteRN oCusto_ComponenteBLL = new Custo_ComponenteRN(Conexao, objOcorrencia,codempresa);
                oCusto_Componente = montaCusto_Componente();
                oCusto_Componente.idcusto_componente = Convert.ToInt32(txtidCusto_Componente.Text);

                oCusto_ComponenteBLL.Excluir(oCusto_Componente);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            //base.ImprimeObjeto();

            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCustoComponente ofrm = new Relatorios.relCustoComponente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Custo Componente : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaCustoComponente()
        {
            if (!String.IsNullOrEmpty(txtidCusto_Componente.Text))
            {

                Custo_Componente oCusto_Componente = new Custo_Componente();
                try
                {
                    Custo_ComponenteRN Custo_ComponenteBLL = new Custo_ComponenteRN(Conexao, objOcorrencia,codempresa);

                    oCusto_Componente = montaCusto_Componente();
                    oCusto_Componente.idcusto_componente = Convert.ToInt32(txtidCusto_Componente.Text);

                    oCusto_Componente = Custo_ComponenteBLL.ObterPor(oCusto_Componente);

                    if (String.IsNullOrEmpty(oCusto_Componente.descricao))
                    {
                        DialogResult result = MessageBox.Show("Componente de Custo não Cadastrada, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oCusto_Componente);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Custo_Componente: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }        
        }
        
        #endregion

        #region "metodos da dbgrid"

        private void grdCusto_Componente_DoubleClick(object sender, EventArgs e)
        {
            txtidCusto_Componente.Text = grdCusto_Componente.Rows[grdCusto_Componente.CurrentRow.Index].Cells["idCusto_Componente"].Value.ToString();
            txtidCusto_Componente.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Custo_ComponenteRN objCusto_Componente = new Custo_ComponenteRN(Conexao, objOcorrencia,codempresa);
            grdCusto_Componente.DataSource = objCusto_Componente.ListaCusto_Componente(0);
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidCusto_Componente_Validating(object sender, CancelEventArgs e)
        {
            BuscaCustoComponente();
        }

        private void cboCusto_ComponenteGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidGrupo_Componente.Text = Convert.ToString(cboCusto_ComponenteGrupo.SelectedValue);

        }

        private void txtidGrupo_Componente_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidGrupo_Componente.Text))
            {
                cboCusto_ComponenteGrupo.Focus();
            }
            else
            {
                cboCusto_ComponenteGrupo.SelectedValue = Convert.ToInt32(txtidGrupo_Componente.Text);
            }
        }


        //private void cboUnidadePadrao_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    // seu código
        //    txtUnidadePadrao.Text = Convert.ToString(cboUnidadePadrao.SelectedValue);

        //}

        //private void txtUnidadePadrao_Validating(object sender, CancelEventArgs e)
        //{
        //    if (String.IsNullOrEmpty(txtUnidadePadrao.Text))
        //    {
        //        cboUnidadePadrao.Focus();
        //    }
        //    else
        //    {
        //        cboUnidadePadrao.SelectedValue = Convert.ToInt32(txtUnidadePadrao.Text);
        //    }
        //}


        #endregion


    }
}
