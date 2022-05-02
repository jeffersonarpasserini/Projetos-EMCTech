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
    public partial class frmCusto_ComponenteGrupo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCusto_ComponenteGrupo";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmCusto_ComponenteGrupo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmCusto_ComponenteGrupo()
        {
            InitializeComponent();
        }

        private void frmCusto_ComponenteGrupo_Activated(object sender, EventArgs e)
        {


        }

        private void frmCusto_ComponenteGrupo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Custo_ComponenteGrupo";

            this.ActiveControl = txtidCusto_ComponenteGrupo;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"

        private Custo_ComponenteGrupo montaCusto_ComponenteGrupo()
        {
            Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
            oCusto_ComponenteGrupo.descricao = txtDescricao.Text;
            return oCusto_ComponenteGrupo;
        }
       
        private void montaTela(Custo_ComponenteGrupo oCusto_ComponenteGrupo)
        {
            txtDescricao.Text = oCusto_ComponenteGrupo.descricao;
            txtidCusto_ComponenteGrupo.Text = oCusto_ComponenteGrupo.idcusto_componentegrupo.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oCusto_ComponenteGrupo.idcusto_componentegrupo.ToString();
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
            txtidCusto_ComponenteGrupo.Enabled = true;
            txtidCusto_ComponenteGrupo.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqGrupoComponente ofrm = new psqGrupoComponente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidCusto_ComponenteGrupo.Enabled = true;
                    txtidCusto_ComponenteGrupo.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtidCusto_ComponenteGrupo.Focus();
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

                Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                Custo_ComponenteGrupoRN oCusto_ComponenteGrupoBLL = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
                oCusto_ComponenteGrupo = montaCusto_ComponenteGrupo();

                oCusto_ComponenteGrupoBLL.Salvar(oCusto_ComponenteGrupo);
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
                Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                Custo_ComponenteGrupoRN oCusto_ComponenteGrupoBLL = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
                oCusto_ComponenteGrupo = montaCusto_ComponenteGrupo();
                oCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(txtidCusto_ComponenteGrupo.Text);

                oCusto_ComponenteGrupoBLL.Atualizar(oCusto_ComponenteGrupo);
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
                Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                Custo_ComponenteGrupoRN oCusto_ComponenteGrupoBLL = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
                oCusto_ComponenteGrupo = montaCusto_ComponenteGrupo();
                oCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(txtidCusto_ComponenteGrupo.Text);

                oCusto_ComponenteGrupoBLL.Excluir(oCusto_ComponenteGrupo);
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
            
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCustoComponenteGrupo ofrm = new Relatorios.relCustoComponenteGrupo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Custo Componente: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void BuscaComponenteGrupo()
        {
            if (!String.IsNullOrEmpty(txtidCusto_ComponenteGrupo.Text))
            {

                Custo_ComponenteGrupo oCusto_ComponenteGrupo = new Custo_ComponenteGrupo();
                try
                {
                    Custo_ComponenteGrupoRN Custo_ComponenteGrupoBLL = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia, codempresa);

                    oCusto_ComponenteGrupo = montaCusto_ComponenteGrupo();
                    oCusto_ComponenteGrupo.idcusto_componentegrupo = Convert.ToInt32(txtidCusto_ComponenteGrupo.Text);

                    oCusto_ComponenteGrupo = Custo_ComponenteGrupoBLL.ObterPor(oCusto_ComponenteGrupo);

                    if (String.IsNullOrEmpty(oCusto_ComponenteGrupo.descricao))
                    {
                        DialogResult result = MessageBox.Show("Grupo de Componente de Custo não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oCusto_ComponenteGrupo);
                        // AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Custo_ComponenteGrupo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdCusto_ComponenteGrupo_DoubleClick(object sender, EventArgs e)
        {
            txtidCusto_ComponenteGrupo.Text = grdCusto_ComponenteGrupo.Rows[grdCusto_ComponenteGrupo.CurrentRow.Index].Cells["idCusto_ComponenteGrupo"].Value.ToString();
            txtidCusto_ComponenteGrupo.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Custo_ComponenteGrupoRN objCusto_ComponenteGrupo = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
            grdCusto_ComponenteGrupo.DataSource = objCusto_ComponenteGrupo.ListaCusto_ComponenteGrupo();
        }


        #endregion


        private void txtidCusto_ComponenteGrupo_Validating(object sender, CancelEventArgs e)
        {
            BuscaComponenteGrupo();
        }

       


    }
}
