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
    public partial class frmObra_Etapa : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmObra_Etapa";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmObra_Etapa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmObra_Etapa()
        {
            InitializeComponent();
        }

        private void frmObra_Etapa_Activated(object sender, EventArgs e)
        {


        }

        private void frmObra_Etapa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_etapa";

            this.ActiveControl = txtidObra_Etapa;

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion


        #region "metodos para tratamento das informacoes"
 
        private Obra_Etapa montaObra_Etapa()
        {
            Obra_Etapa oObra_Etapa = new Obra_Etapa();
            oObra_Etapa.descricao = txtDescricao.Text;

            return oObra_Etapa;
        }

        private void montaTela(Obra_Etapa oObra_Etapa)
        {
            txtDescricao.Text = oObra_Etapa.descricao;
            txtidObra_Etapa.Text = oObra_Etapa.idobra_etapa.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oObra_Etapa.idobra_etapa.ToString();
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
            txtidObra_Etapa.Enabled = false;
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
            txtidObra_Etapa.Enabled = true;
            txtidObra_Etapa.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqObraEtapa ofrm = new psqObraEtapa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCObras.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidObra_Etapa.Enabled = true;
                    txtidObra_Etapa.Text = EMCObras.retPesquisa.chaveinterna.ToString();
                    txtidObra_Etapa.Focus();
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

                Obra_Etapa oObra_Etapa = new Obra_Etapa();
                Obra_EtapaRN oObra_EtapaBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
                oObra_Etapa = montaObra_Etapa();

                oObra_EtapaBLL.Salvar(oObra_Etapa);
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
                Obra_Etapa oObra_Etapa = new Obra_Etapa();
                Obra_EtapaRN oObra_EtapaBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
                oObra_Etapa = montaObra_Etapa();
                oObra_Etapa.idobra_etapa = Convert.ToInt32(txtidObra_Etapa.Text);

                oObra_EtapaBLL.Atualizar(oObra_Etapa);
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
                Obra_Etapa oObra_Etapa = new Obra_Etapa();
                Obra_EtapaRN oObra_EtapaBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
                oObra_Etapa = montaObra_Etapa();
                oObra_Etapa.idobra_etapa = Convert.ToInt32(txtidObra_Etapa.Text);

                oObra_EtapaBLL.Excluir(oObra_Etapa);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaObraEtapa()
        {
            if (!String.IsNullOrEmpty(txtidObra_Etapa.Text))
            {

                Obra_Etapa oObra_Etapa = new Obra_Etapa();
                try
                {
                    Obra_EtapaRN Obra_EtapaBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);

                    oObra_Etapa = montaObra_Etapa();
                    oObra_Etapa.idobra_etapa = Convert.ToInt32(txtidObra_Etapa.Text);

                    oObra_Etapa = Obra_EtapaBLL.ObterPor(oObra_Etapa);

                    if (String.IsNullOrEmpty(oObra_Etapa.descricao))
                    {
                        DialogResult result = MessageBox.Show("Etapa não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oObra_Etapa);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Obra_Etapa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdObra_Etapa_DoubleClick(object sender, EventArgs e)
        {
            txtidObra_Etapa.Text = grdObra_Etapa.Rows[grdObra_Etapa.CurrentRow.Index].Cells["idobra_etapa"].Value.ToString();
            txtidObra_Etapa.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            Obra_EtapaRN objObra_Etapa = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
            grdObra_Etapa.DataSource = objObra_Etapa.ListaObra_Etapa();
        }


        #endregion


        private void txtidObra_Etapa_Validating(object sender, CancelEventArgs e)
        {
            BuscaObraEtapa();
        }
    }
}
