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
    public partial class frmMenuSistema : EMCLibrary.EMCForm
    {
        private const string descricao = "frmMenuSistema";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmMenuSistema()
        {
            InitializeComponent();
        }

        public frmMenuSistema(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmMenuSistema_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "MenuSistema";

            AtualizaGrid();
            this.ActiveControl = txtIdMenuSistema;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"

        private Boolean verificaMenuSistema(MenuSistema oMenuSistema)
        {
            MenuSistemaRN oMenuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oMenuSistemaRN.VerificaDados(oMenuSistema);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Menu Sistema: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private MenuSistema montaMenuSistema()
        {

            MenuSistema oMenuSistema = new MenuSistema();

            oMenuSistema.modulo = txtModulo.Text;
            oMenuSistema.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);
            oMenuSistema.descricao = txtDescricao.Text;
            oMenuSistema.nNamespace = txtNamespace.Text;
            oMenuSistema.endereco = txtEndereco.Text;
            oMenuSistema.urlImagem = txtUrlImagem.Text;
            oMenuSistema.exibeImagem = cboExibeImagem.SelectedValue.ToString();
            oMenuSistema.itemSeguranca = cboItemSeguranca.SelectedValue.ToString();
            oMenuSistema.indicadorAbertura = cboIndicadorAbertura.SelectedValue.ToString();
            oMenuSistema.ordem = EmcResources.cInt(txtOrdem.Text);
            oMenuSistema.menuPai = EmcResources.cInt(txtMenuPai.Text);
            oMenuSistema.nivel = EmcResources.cInt(txtNivel.Text);
            oMenuSistema.exclusivoJLM = cboExclusivoJlm.SelectedValue.ToString();
            oMenuSistema.nivelUsuario = EmcResources.cInt(cboNivelUsuario.SelectedValue.ToString());


            return oMenuSistema;
        }
       
        private void montaTela(MenuSistema oMenuSistema)
        {   
            txtModulo.Text = oMenuSistema.modulo;
            txtIdMenuSistema.Text = oMenuSistema.idMenuSistema.ToString();
            txtDescricao.Text = oMenuSistema.descricao;
            txtNamespace.Text = oMenuSistema.nNamespace;
            txtEndereco.Text = oMenuSistema.endereco;
            txtUrlImagem.Text = oMenuSistema.urlImagem;
            cboExibeImagem.SelectedValue = oMenuSistema.exibeImagem;
            cboItemSeguranca.SelectedValue = oMenuSistema.itemSeguranca;
            cboIndicadorAbertura.SelectedValue = oMenuSistema.indicadorAbertura;
            txtOrdem.Text = oMenuSistema.ordem.ToString();
            txtMenuPai.Text = oMenuSistema.menuPai.ToString();
            txtNivel.Text = oMenuSistema.nivel.ToString();
            cboExclusivoJlm.SelectedValue = oMenuSistema.exclusivoJLM;
            cboNivelUsuario.SelectedValue = oMenuSistema.nivelUsuario.ToString();


            objOcorrencia.chaveidentificacao = oMenuSistema.idMenuSistema.ToString()+"-"+oMenuSistema.modulo;

            txtIdMenuSistema.Enabled = false;
            txtModulo.Enabled = false;
            txtModulo.Focus();
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdMenuSistema.Enabled = false;
            txtModulo.Enabled = false;
            
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

            txtIdMenuSistema.Enabled = true;
            txtIdMenuSistema.Enabled = true;
            txtIdMenuSistema.Focus();

        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtIdMenuSistema.Enabled = true;
            txtModulo.Enabled = true;

            objOcorrencia.chaveidentificacao = "";

            //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Sim", "S"));
            arr.Add(new popCombo("Não", "N"));
            cboExibeImagem.DataSource = arr;
            cboExibeImagem.DisplayMember = "nome";
            cboExibeImagem.ValueMember = "valor";

            ArrayList arrItem = new ArrayList();
            arrItem.Add(new popCombo("Sim", "S"));
            arrItem.Add(new popCombo("Não", "N"));
            cboItemSeguranca.DataSource = arrItem;
            cboItemSeguranca.DisplayMember = "nome";
            cboItemSeguranca.ValueMember = "valor";

            ArrayList arrInd = new ArrayList();
            arrInd.Add(new popCombo("Sim", "S"));
            arrInd.Add(new popCombo("Não", "N"));
            cboIndicadorAbertura.DataSource = arrInd;
            cboIndicadorAbertura.DisplayMember = "nome";
            cboIndicadorAbertura.ValueMember = "valor";

            ArrayList arrExc = new ArrayList();
            arrExc.Add(new popCombo("Sim", "S"));
            arrExc.Add(new popCombo("Não", "N"));
            cboExclusivoJlm.DataSource = arrExc;
            cboExclusivoJlm.DisplayMember = "nome";
            cboExclusivoJlm.ValueMember = "valor";

            ArrayList ar = new ArrayList();
            ar.Add(new popCombo("0 - Administrador", "0"));
            ar.Add(new popCombo("1 - Diretor", "1"));
            ar.Add(new popCombo("2 - Gerente", "2"));
            ar.Add(new popCombo("3 - Encarregado", "3"));
            ar.Add(new popCombo("4 - Líder", "4"));
            ar.Add(new popCombo("5 - Operador", "5"));
            ar.Add(new popCombo("8 - Estágiario", "8"));
            cboNivelUsuario.DataSource = ar;
            cboNivelUsuario.DisplayMember = "nome";
            cboNivelUsuario.ValueMember = "valor";


            txtIdMenuSistema.Focus();
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

        public void BuscaMenuSistema()
        {

            if (!String.IsNullOrEmpty(txtIdMenuSistema.Text))
            {
                MenuSistema oMenuSistema = new MenuSistema();
                oMenuSistema.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);
                oMenuSistema.modulo = txtModulo.Text;

                try
                {
                    MenuSistemaRN menuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);
                    oMenuSistema = menuSistemaRN.ObterPor(oMenuSistema);

                    if (oMenuSistema.idMenuSistema == 0)
                    {
                        DialogResult result = MessageBox.Show("Sistema não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        txtIdMenuSistema.Enabled = false;
                        txtDescricao.Focus();
                    }
                    else
                    {
                        montaTela(oMenuSistema);
                        AtivaEdicao();
                        txtDescricao.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Menu Sistema: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            cboNivelUsuario.SelectedIndex = -1;
        }

        public override void SalvaObjeto()
        {
            try
            {
                MenuSistema oMenuSistema = new MenuSistema();
                MenuSistemaRN oMenuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);


                oMenuSistema = montaMenuSistema();

                if (verificaMenuSistema(oMenuSistema))
                {
                    oMenuSistemaRN.Salvar(oMenuSistema);

                    LimpaCampos();
                    montaTela(oMenuSistema);
                    AtualizaGrid();
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
            try
            {
                MenuSistema oMenuSistema = new MenuSistema();
                MenuSistemaRN oMenuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);

                oMenuSistema = montaMenuSistema();
                oMenuSistema.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);
                oMenuSistema.modulo = txtModulo.Text;


                if (verificaMenuSistema(oMenuSistema))
                {

                    oMenuSistemaRN.Atualizar(oMenuSistema);

                    LimpaCampos();                    
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oMenuSistema);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                MenuSistema oMenuSistema = new MenuSistema();
                MenuSistemaRN oMenuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);
                oMenuSistema = montaMenuSistema();
                oMenuSistema.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);
                oMenuSistema.modulo = txtModulo.Text;

                if (verificaMenuSistema(oMenuSistema))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Módulo?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oMenuSistemaRN.Excluir(oMenuSistema);

                        LimpaCampos();
                        MessageBox.Show("Módulo excluido!", "EMCtech");
                        AtualizaGrid();
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relHistorico ofrm = new Relatorios.relHistorico(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Menu Sistema: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "Tratamentos para buttons e texts**************************************************************************************"
        
        private void txtIdMenuSistema_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtModulo.Text) && EmcResources.cInt(txtIdMenuSistema.Text) > 0)
            {
                BuscaMenuSistema();
            }
            
        }
        private void txtModulo_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtModulo.Text) && EmcResources.cInt(txtIdMenuSistema.Text) > 0)
            {
                BuscaMenuSistema();
            }
        }
        


        #endregion

        #region "metodos da dbgrid*******************************************************************************************"

        private void grdMenuSistema_DoubleClick(object sender, EventArgs e)
        {
            txtIdMenuSistema.Enabled = true;
            txtIdMenuSistema.Text = grdMenuSistema.Rows[grdMenuSistema.CurrentRow.Index].Cells["idmenusistema"].Value.ToString();
            txtModulo.Text = grdMenuSistema.Rows[grdMenuSistema.CurrentRow.Index].Cells["modulo"].Value.ToString();
            txtIdMenuSistema.Focus();
            txtIdMenuSistema_Validating(null, null);
        }
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            MenuSistemaRN oMenuSistemaRN = new MenuSistemaRN(Conexao, objOcorrencia, codempresa);
            MenuSistema oMenuSistema = new MenuSistema();
            grdMenuSistema.DataSource = oMenuSistemaRN.ListaMenuSistema();
        }
        
        #endregion

        private void grdMenuSistema_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtModulo_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
