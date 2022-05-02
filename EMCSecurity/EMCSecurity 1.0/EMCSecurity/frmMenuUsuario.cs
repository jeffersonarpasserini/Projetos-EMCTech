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
    public partial class frmMenuUsuario : EMCLibrary.EMCForm
    {
        private const string descricao = "frmMenuUsuario";
        private const string nomeAplicativo = "EMCSecurity";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmMenuUsuario()
        {
            InitializeComponent();
        }

        public frmMenuUsuario(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        private void frmMenuUsuario_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "MenuUsuario";


            AtualizaGrid();
            this.ActiveControl = cboIdUsuario;
            CancelaOperacao();

        }

        #region "metodos para tratamento das informacoes*********************************************************************"


        private Boolean verificaMenuUsuario(MenuUsuario oMenuUsuario)
        {
            MenuUsuarioRN oMenuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);
            try
            {
                oMenuUsuarioRN.VerificaDados(oMenuUsuario);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Menu Usuário: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private MenuUsuario montaMenuUsuario()
        {
            MenuUsuario oMenuUsuario = new MenuUsuario();

            oMenuUsuario.idUsuario = EmcResources.cInt(cboIdUsuario.SelectedValue.ToString());
            oMenuUsuario.modulo = txtModulo.Text;
            oMenuUsuario.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);
            oMenuUsuario.descricao = txtDescricao.Text;
            oMenuUsuario.nNamespace = txtNamespace.Text;
            oMenuUsuario.endereco = txtEndereco.Text;
            oMenuUsuario.urlImagem = txtUrlImagem.Text;
            oMenuUsuario.exibeImagem = cboExibeImagem.SelectedValue.ToString();
            oMenuUsuario.itemSeguranca = cboItemSeguranca.SelectedValue.ToString();
            oMenuUsuario.indicadorAbertura = cboIndicadorAbertura.SelectedValue.ToString();
            oMenuUsuario.ordem = EmcResources.cInt(txtOrdem.Text);
            oMenuUsuario.menuPai = EmcResources.cInt(txtMenuPai.Text);
            oMenuUsuario.nivel = EmcResources.cInt(txtNivel.Text);
            oMenuUsuario.exclusivoJLM = cboExclusivoJlm.SelectedValue.ToString();
            oMenuUsuario.nivelUsuario = EmcResources.cInt(cboNivelUsuario.SelectedValue.ToString());
            oMenuUsuario.executa = cboExecuta.SelectedValue.ToString();
            oMenuUsuario.inclusao = cboInclusao.SelectedValue.ToString();
            oMenuUsuario.alteracao = cboAlteracao.SelectedValue.ToString();
            oMenuUsuario.exclusao = cboExclusao.SelectedValue.ToString();
            oMenuUsuario.ocorrencia = cboOcorrencia.SelectedValue.ToString();
            oMenuUsuario.impressao = cboImpressao.SelectedValue.ToString();


            return oMenuUsuario;
        }

        private void montaTela(MenuUsuario oMenuUsuario)
        {
            cboIdUsuario.SelectedValue = oMenuUsuario.idUsuario.ToString();
            txtModulo.Text = oMenuUsuario.modulo;
            txtIdMenuSistema.Text = oMenuUsuario.idMenuSistema.ToString();
            txtDescricao.Text = oMenuUsuario.descricao;
            txtNamespace.Text = oMenuUsuario.nNamespace;
            txtEndereco.Text = oMenuUsuario.endereco;
            txtUrlImagem.Text = oMenuUsuario.urlImagem;
            cboExibeImagem.SelectedValue = oMenuUsuario.exibeImagem;
            cboItemSeguranca.SelectedValue = oMenuUsuario.itemSeguranca;
            cboIndicadorAbertura.SelectedValue = oMenuUsuario.indicadorAbertura;
            txtOrdem.Text = oMenuUsuario.ordem.ToString();
            txtMenuPai.Text = oMenuUsuario.menuPai.ToString();
            txtNivel.Text = oMenuUsuario.nivel.ToString();
            cboExclusivoJlm.SelectedValue = oMenuUsuario.exclusivoJLM;
            cboNivelUsuario.SelectedValue = oMenuUsuario.nivelUsuario.ToString();
            cboExecuta.SelectedValue = oMenuUsuario.executa;
            cboInclusao.SelectedValue = oMenuUsuario.inclusao;
            cboAlteracao.SelectedValue = oMenuUsuario.alteracao;
            cboExclusao.SelectedValue = oMenuUsuario.exclusao;
            cboOcorrencia.SelectedValue = oMenuUsuario.ocorrencia;
            cboImpressao.SelectedValue = oMenuUsuario.impressao;


            objOcorrencia.chaveidentificacao = oMenuUsuario.idUsuario.ToString();

            cboIdUsuario.Enabled = false;

        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            cboIdUsuario.Enabled = true;
            txtIdMenuSistema.Enabled = false;
            txtModulo.Enabled = false;
            txtNamespace.Enabled = false;
            txtDescricao.Enabled = false;
            txtEndereco.Enabled = false;
            txtUrlImagem.Enabled = false;
            cboExibeImagem.Enabled = false;
            cboItemSeguranca.Enabled = false;
            cboIndicadorAbertura.Enabled = false;
            txtOrdem.Enabled = false;
            txtMenuPai.Enabled = false;
            txtNivel.Enabled = false;
            cboExclusivoJlm.Enabled = false;
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

            cboIdUsuario.Enabled = true;
            txtIdMenuSistema.Enabled = false;
            txtModulo.Enabled = false;
            txtNamespace.Enabled = false;
            txtDescricao.Enabled = false;
            txtEndereco.Enabled = false;
            txtUrlImagem.Enabled = false;
            cboExibeImagem.Enabled = false;
            cboItemSeguranca.Enabled = false;
            cboIndicadorAbertura.Enabled = false;
            txtOrdem.Enabled = false;
            txtMenuPai.Enabled = false;
            txtNivel.Enabled = false;
            cboExclusivoJlm.Enabled = false;

            cboIdUsuario.Focus();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            cboIdUsuario.Enabled = true;
            objOcorrencia.chaveidentificacao = "";

            UsuarioBLL oUsuarioRN = new UsuarioBLL(Conexao, objOcorrencia, codempresa);
            cboIdUsuario.DataSource = oUsuarioRN.ListaUsuario();
            cboIdUsuario.ValueMember = "idusuario";
            cboIdUsuario.DisplayMember = "nome";


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
            ar.Add(new popCombo("8 - Estagiário", "8"));
            cboNivelUsuario.DataSource = ar;
            cboNivelUsuario.DisplayMember = "nome";
            cboNivelUsuario.ValueMember = "valor";

            ArrayList arrExe = new ArrayList();
            arrExe.Add(new popCombo("Sim", "S"));
            arrExe.Add(new popCombo("Não", "N"));
            cboExecuta.DataSource = arrExe;
            cboExecuta.DisplayMember = "nome";
            cboExecuta.ValueMember = "valor";

            ArrayList arrInc = new ArrayList();
            arrInc.Add(new popCombo("Sim", "S"));
            arrInc.Add(new popCombo("Não", "N"));
            cboInclusao.DataSource = arrInc;
            cboInclusao.DisplayMember = "nome";
            cboInclusao.ValueMember = "valor";

            ArrayList arrAlt = new ArrayList();
            arrAlt.Add(new popCombo("Sim", "S"));
            arrAlt.Add(new popCombo("Não", "N"));
            cboAlteracao.DataSource = arrAlt;
            cboAlteracao.DisplayMember = "nome";
            cboAlteracao.ValueMember = "valor";

            ArrayList arrExcl = new ArrayList();
            arrExcl.Add(new popCombo("Sim", "S"));
            arrExcl.Add(new popCombo("Não", "N"));
            cboExclusao.DataSource = arrExcl;
            cboExclusao.DisplayMember = "nome";
            cboExclusao.ValueMember = "valor";

            ArrayList arrOco = new ArrayList();
            arrOco.Add(new popCombo("Sim", "S"));
            arrOco.Add(new popCombo("Não", "N"));
            cboOcorrencia.DataSource = arrOco;
            cboOcorrencia.DisplayMember = "nome";
            cboOcorrencia.ValueMember = "valor";

            ArrayList arrImp = new ArrayList();
            arrImp.Add(new popCombo("Sim", "S"));
            arrImp.Add(new popCombo("Não", "N"));
            cboImpressao.DataSource = arrImp;
            cboImpressao.DisplayMember = "nome";
            cboImpressao.ValueMember = "valor";

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

        public void BuscaMenuUsuario()
        {
            if (!String.IsNullOrEmpty(cboIdUsuario.SelectedValue.ToString()))
            {
                MenuUsuario oMenuUsuario = new MenuUsuario();
                oMenuUsuario.idUsuario = EmcResources.cInt(cboIdUsuario.SelectedValue.ToString());
                oMenuUsuario.modulo = txtModulo.Text;
                oMenuUsuario.idMenuSistema = EmcResources.cInt(txtIdMenuSistema.Text);

                try
                {
                    MenuUsuarioRN menuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);
                    oMenuUsuario = menuUsuarioRN.ObterPor(oMenuUsuario);

                    if (oMenuUsuario.idUsuario == 0)
                    {
                        DialogResult result = MessageBox.Show("Usuário não Cadastrado, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                        cboIdUsuario.Enabled = true;
                        cboIdUsuario.Focus();
                    }
                    else
                    {
                        montaTela(oMenuUsuario);
                        AtivaEdicao();
                        cboIdUsuario.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Menu Usuario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            cboIdUsuario.SelectedIndex = -1;
        }

        public override void SalvaObjeto()
        {
            try
            {
                MenuUsuario oMenuUsuario = new MenuUsuario();
                MenuUsuarioRN oMenuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);


                oMenuUsuario = montaMenuUsuario();

                if (verificaMenuUsuario(oMenuUsuario))
                {
                    oMenuUsuarioRN.Salvar(oMenuUsuario);

                    LimpaCampos();
                    montaTela(oMenuUsuario);
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
                MenuUsuario oMenuUsuario = new MenuUsuario();
                MenuUsuarioRN oMenuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);

                oMenuUsuario = montaMenuUsuario();
                oMenuUsuario.idUsuario = EmcResources.cInt(cboIdUsuario.SelectedValue.ToString());


                if (verificaMenuUsuario(oMenuUsuario))
                {
                    oMenuUsuarioRN.Atualizar(oMenuUsuario);

                    LimpaCampos();
                    AtualizaGrid();
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oMenuUsuario);
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
                MenuUsuario oMenuUsuario = new MenuUsuario();
                MenuUsuarioRN oMenuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);
                oMenuUsuario = montaMenuUsuario();
                oMenuUsuario.idUsuario = EmcResources.cInt(cboIdUsuario.SelectedValue.ToString());

                if (verificaMenuUsuario(oMenuUsuario))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Usuário?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oMenuUsuarioRN.Excluir(oMenuUsuario);

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
                MessageBox.Show("Erro Menu Usuário: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid*******************************************************************************************"

        private void grdMenuUsuario_DoubleClick(object sender, EventArgs e)
        {
            cboIdUsuario.Enabled = true;
            cboIdUsuario.SelectedValue = grdMenuUsuario.Rows[grdMenuUsuario.CurrentRow.Index].Cells["idusuario"].Value.ToString();
            txtIdMenuSistema.Text = grdMenuUsuario.Rows[grdMenuUsuario.CurrentRow.Index].Cells["idmenusistema"].Value.ToString();
            txtModulo.Text = grdMenuUsuario.Rows[grdMenuUsuario.CurrentRow.Index].Cells["modulo"].Value.ToString();
            BuscaMenuUsuario();

            //txtModulo.Focus();
            SendKeys.Send("{TAB}");
        }
        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            MenuUsuarioRN oMenuUsuarioRN = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);
            MenuUsuario oMenuUsuario = new MenuUsuario();
            grdMenuUsuario.DataSource = oMenuUsuarioRN.ListaMenuUsuario();
        }

        #endregion

        private void cboIdUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboIdUsuario.SelectedIndex>-1 && cboIdUsuario.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    MenuUsuarioRN oMenuUser = new MenuUsuarioRN(Conexao, objOcorrencia,codempresa);
                    grdMenuUsuario.DataSource = oMenuUser.ListaMenuUsuario(EmcResources.cInt(cboIdUsuario.SelectedValue.ToString()));
                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro Menu Usuario: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
