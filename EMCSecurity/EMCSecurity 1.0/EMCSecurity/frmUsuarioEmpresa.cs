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
    public partial class frmUsuarioEmpresa : EMCLibrary.EMCForm
    {
        private const string descricao = "frmUsuarioEmpresa";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmUsuarioEmpresa()
        {
            InitializeComponent();
        }

        public frmUsuarioEmpresa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmUsuarioEmpresa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "UsuarioEmpresa";

          //  AtualizaGrid();
            this.ActiveControl = cboIdUsuario;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaUsuario(UsuarioEmpresa oUsuarioEmpresa)
        {
            UsuarioEmpresaRN oUsuarioEmpresaRN = new UsuarioEmpresaRN(Conexao);
            try
            {
                oUsuarioEmpresaRN.VerificaDados(oUsuarioEmpresa);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Usuário: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private UsuarioEmpresa montaUsuarioEmpresa()
        {

            UsuarioEmpresa oUsuarioEmpresa = new UsuarioEmpresa();

            oUsuarioEmpresa.idUsuario = EmcResources.cInt(cboIdUsuario.SelectedValue.ToString());
            oUsuarioEmpresa.idEmpresa = EmcResources.cInt(cboIdEmpresa.SelectedValue.ToString());

            return oUsuarioEmpresa;
        }

        private void montaTela(UsuarioEmpresa oUsuarioEmpresa)
        {
            cboIdUsuario.SelectedValue = oUsuarioEmpresa.idUsuario.ToString();
            cboIdEmpresa.SelectedValue = oUsuarioEmpresa.idEmpresa.ToString();

            objOcorrencia.chaveidentificacao = oUsuarioEmpresa.idUsuario.ToString();

            cboIdUsuario.Enabled = false;
            // cboIdUsuario.Focus();
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
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            //base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";

            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao,objOcorrencia,codempresa);
            cboIdUsuario.DataSource = oUsuarioRN.ListaUsuario();
            cboIdUsuario.ValueMember = "idusuario";
            cboIdUsuario.DisplayMember = "nome";

            cboIdUsuario.SelectedIndex = 0;


            EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
            cboIdEmpresa.DataSource = oEmpresaRN.ListaEmpresaNaoAutorizada(EmcResources.cInt(cboIdUsuario.SelectedValue.ToString()));
            cboIdEmpresa.ValueMember = "idempresa";
            cboIdEmpresa.DisplayMember = "razaosocial";


        }

        public override void BuscaObjeto()
        {
            try
            {/*
               // psqHistorico ofrm = new psqHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdTipoCobranca.Text = "";

                }
                else
                {
                    txtIdHistorico.Enabled = true;
                    txtIdHistorico.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtIdHistorico.Focus();
                    SendKeys.Send("{TAB}");
                }*/
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Menu Sistema: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscaUsuarioEmpresa()
        {

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
                UsuarioEmpresa oUsuarioEmpresa = new UsuarioEmpresa();
                UsuarioEmpresaRN oUsuarioEmpresaRN = new UsuarioEmpresaRN(Conexao, objOcorrencia, codempresa);


                oUsuarioEmpresa = montaUsuarioEmpresa();

                if (verificaUsuario(oUsuarioEmpresa))
                {
                    oUsuarioEmpresaRN.Salvar(oUsuarioEmpresa);
                    CancelaOperacao();
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
           
        }

        public override void ExcluiObjeto()
        {
            try
            {
                UsuarioEmpresaRN oUsuarioEmpresaRN = new UsuarioEmpresaRN(Conexao,objOcorrencia,codempresa);

                foreach (DataGridViewRow dataGridViewRow in grdUsuarioEmpresa.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];

                    if (ch1.Selected)
                    {
                        UsuarioEmpresa oUsuarioEmpresa = new UsuarioEmpresa();
                        oUsuarioEmpresa = montaUsuarioEmpresa();
                        oUsuarioEmpresa.idUsuario = EmcResources.cInt(dataGridViewRow.Cells["idusuario"].Value.ToString());
                        oUsuarioEmpresa.idEmpresa = EmcResources.cInt(dataGridViewRow.Cells["idempresa"].Value.ToString());

                        

                        DialogResult result = MessageBox.Show("Confirma exclusão da Liberação ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            oUsuarioEmpresaRN.Excluir(oUsuarioEmpresa);

                            MessageBox.Show("Liberação excluida!", "EMCtech");
                            CancelaOperacao();

                        }
                        else MessageBox.Show("Exclusão Cancelada!", "EMCtech");

                    }


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

        private void grdUsuarioEmpresa_DoubleClick(object sender, EventArgs e)
        {
            cboIdUsuario.Enabled = true;
            cboIdUsuario.SelectedValue =EmcResources.cInt(grdUsuarioEmpresa.Rows[grdUsuarioEmpresa.CurrentRow.Index].Cells["codigousuario"].Value.ToString());
            cboIdEmpresa.SelectedValue = EmcResources.cInt(grdUsuarioEmpresa.Rows[grdUsuarioEmpresa.CurrentRow.Index].Cells["codigoempresa"].Value.ToString());
            cboIdUsuario.Focus();
            SendKeys.Send("{TAB}");
        }

        private void AtualizaGrid()
        {
            UsuarioEmpresaRN oUsuarioEmpresaRN = new UsuarioEmpresaRN(Conexao, objOcorrencia, codempresa);
            if (cboIdUsuario.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                grdUsuarioEmpresa.DataSource = oUsuarioEmpresaRN.ListaEmpresaUsuario(EmcResources.cInt(cboIdUsuario.SelectedValue.ToString()));
            }
        }


        #endregion

        private void cboIdUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboIdUsuario.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    AtualizaGrid();
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboIdEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboIdEmpresa.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    if (EmcResources.cInt(cboIdEmpresa.SelectedValue.ToString()) > 0)
                    {
                        AtivaInsercao();
                    }
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro Fechamento Caixa: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void grdUsuarioEmpresa_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (grdUsuarioEmpresa.Rows.Count > 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell) grdUsuarioEmpresa.Rows[grdUsuarioEmpresa.CurrentRow.Index].Cells[0];
                if (ch1.Value.ToString() == "1")
                {
                    AtivaEdicao();
                    travaBotao("btnAtualizar");
                }
            }
        }

        private void grdUsuarioEmpresa_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            grdUsuarioEmpresa.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
}
