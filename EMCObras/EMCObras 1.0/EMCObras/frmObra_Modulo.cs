using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCObrasModel;
using EMCObrasRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCObras
{
    public partial class frmObra_Modulo : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmObra_Modulo";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmObra_Modulo(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmObra_Modulo()
        {
            InitializeComponent();
        }

        private void frmObra_Modulo_Activated(object sender, EventArgs e)
        {


        }

        private void frmObra_Modulo_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_modulo";

            //carregando as combos na entrada da tela
            Obra_EtapaRN oObra_EtapaRN = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
            cboObra_Etapa.DataSource = oObra_EtapaRN.ListaObra_Etapa();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboObra_Etapa.ValueMember = "idobra_etapa";
            cboObra_Etapa.DisplayMember = "descricao";

            this.ActiveControl = txtidObra_Etapa;

            CancelaOperacao();
            this.ActiveControl = txtidObra_Modulo;
            AtualizaGrid();
        }
        #endregion
        
        #region "metodos para tratamento das informacoes"
      
        private Obra_Modulo montaObra_Modulo()
        {
            Obra_Modulo oObra_Modulo = new Obra_Modulo();
            oObra_Modulo.descricao = txtDescricao.Text;
            Obra_Etapa oObra_Etapa = new Obra_Etapa();
            oObra_Etapa.idobra_etapa = EmcResources.cInt(txtidObra_Etapa.Text);
            Obra_EtapaRN oObraEtapaRN = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
            oObra_Modulo.obra_etapa = oObraEtapaRN.ObterPor(oObra_Etapa);

            return oObra_Modulo;
        }
       
        private void montaTela(Obra_Modulo oObra_Modulo)
        {
            txtidObra_Modulo.Text = oObra_Modulo.idobra_modulo.ToString();
            txtDescricao.Text = oObra_Modulo.descricao;

            txtidObra_Etapa.Text = oObra_Modulo.obra_etapa.idobra_etapa.ToString();
            cboObra_Etapa.SelectedValue = oObra_Modulo.obra_etapa.idobra_etapa.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oObra_Modulo.idobra_modulo.ToString();
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
        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidObra_Modulo.Enabled = true;
            txtidObra_Modulo.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqObraModulo ofrm = new psqObraModulo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCObras.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Modulo.Enabled = true;
                    txtidObra_Modulo.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Modulo.Focus();
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

                Obra_Modulo oObra_Modulo = new Obra_Modulo();
                Obra_ModuloRN oObra_ModuloBLL = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
                oObra_Modulo = montaObra_Modulo();

                oObra_ModuloBLL.Salvar(oObra_Modulo);
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
                Obra_Modulo oObra_Modulo = new Obra_Modulo();
                Obra_ModuloRN oObra_ModuloBLL = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
                oObra_Modulo = montaObra_Modulo();
                oObra_Modulo.idobra_modulo = Convert.ToInt32(txtidObra_Modulo.Text);

                oObra_ModuloBLL.Atualizar(oObra_Modulo);
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
                Obra_Modulo oObra_Modulo = new Obra_Modulo();
                Obra_ModuloRN oObra_ModuloBLL = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
                oObra_Modulo = montaObra_Modulo();
                oObra_Modulo.idobra_modulo = Convert.ToInt32(txtidObra_Modulo.Text);

                oObra_ModuloBLL.Excluir(oObra_Modulo);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaObraModulo()
        {
            if (!String.IsNullOrEmpty(txtidObra_Modulo.Text))
            {

                Obra_Modulo oObra_Modulo = new Obra_Modulo();
                try
                {
                    Obra_ModuloRN Obra_ModuloBLL = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);

                    oObra_Modulo = montaObra_Modulo();
                    oObra_Modulo.idobra_modulo = Convert.ToInt32(txtidObra_Modulo.Text);

                    oObra_Modulo = Obra_ModuloBLL.ObterPor(oObra_Modulo);

                    if (String.IsNullOrEmpty(oObra_Modulo.descricao))
                    {
                        DialogResult result = MessageBox.Show("Etapa não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oObra_Modulo);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Obra_Modulo: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdObra_Modulo_DoubleClick(object sender, EventArgs e)
        {
            txtidObra_Modulo.Text = grdObra_Modulo.Rows[grdObra_Modulo.CurrentRow.Index].Cells["idobra_modulo"].Value.ToString();
            txtidObra_Modulo.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Obra_ModuloRN objObra_Modulo = new Obra_ModuloRN(Conexao, objOcorrencia, codempresa);
            grdObra_Modulo.DataSource = objObra_Modulo.ListaObra_Modulo();
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidObra_Modulo_Validating(object sender, CancelEventArgs e)
        {
            BuscaObraModulo();
        }

        private void cboObra_Etapa_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidObra_Etapa.Text = Convert.ToString(cboObra_Etapa.SelectedValue);
            
        }
        private void txtidObra_Etapa_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidObra_Etapa.Text))
            {
                cboObra_Etapa.Focus();
            }
            else
            {
                cboObra_Etapa.SelectedValue = Convert.ToInt32(txtidObra_Etapa.Text);
            }
        }
        
        
        #endregion
    }
}
