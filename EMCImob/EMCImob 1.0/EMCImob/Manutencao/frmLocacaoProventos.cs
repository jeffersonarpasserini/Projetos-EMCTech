using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurity;
using EMCCadastroModel;
using EMCCadastroRN;
using System.Collections;
using EMCCadastro;

namespace EMCImob
{
    public partial class frmLocacaoProventos : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmLocacaoProventos";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmLocacaoProventos(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmLocacaoProventos()
        {
            InitializeComponent();
        }

        private void frmLocacaoProventos_Activated(object sender, EventArgs e)
        {

        }
        private void frmLocacaoProventos_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "locacaoproventos";

            AtualizaGrid();
            this.ActiveControl = txtIdLocacaoProventos;
            CancelaOperacao();
        }
        #endregion
        #region "metodos para tratamento das informacoes"

        private Boolean verificaLocacaoProventos(LocacaoProventos oLocacaoProventos)
        {
            LocacaoProventosRN oLocacaoProventosRN = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oLocacaoProventosRN.VerificaDados(oLocacaoProventos);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Locação Proventos: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }                

        private LocacaoProventos montaLocacaoProventos()
        {            

            LocacaoProventos oLocacaoProventos = new LocacaoProventos();           
         
            oLocacaoProventos.Descricao = txtDescricao.Text;
            oLocacaoProventos.TipoProvento = cboTipoProvento.SelectedValue.ToString();
            oLocacaoProventos.IntegraDimob = cboIntegraDimob.SelectedValue.ToString();

            Aplicacao oAplicacao = new Aplicacao();
            AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);
            oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Text);
            oAplicacao = oAplRN.ObterPor(oAplicacao);
            oLocacaoProventos.aplicacao = oAplicacao;
           
            oLocacaoProventos.BaseTaxaAdm = cboBaseTaxaAdm.SelectedValue.ToString();
            oLocacaoProventos.BaseTaxaAdmCondominio = cboBaseTaxaAdmCondominio.SelectedValue.ToString();
            oLocacaoProventos.Referencia = EmcResources.cDouble(txtReferencia.Value.ToString());
            oLocacaoProventos.ValorReferencia = cboValorReferencia.SelectedValue.ToString();
            oLocacaoProventos.BaseIrpf = cboBaseIrpf.SelectedValue.ToString();
            oLocacaoProventos.RotinaCalculo = EmcResources.cInt(txtRotinaCalculo.Text);

            return oLocacaoProventos;
        }

        private void montaTela(LocacaoProventos oLocacaoProventos)
        {
            txtIdLocacaoProventos.Text = oLocacaoProventos.idLocacaoProventos.ToString();
            txtDescricao.Text = oLocacaoProventos.Descricao;
            cboTipoProvento.SelectedValue = oLocacaoProventos.TipoProvento;
            cboIntegraDimob.SelectedValue = oLocacaoProventos.IntegraDimob;

            txtIdAplicacao.Text = oLocacaoProventos.aplicacao.idAplicacao.ToString();
            txtAplicacao.Text = oLocacaoProventos.aplicacao.descricao;

            cboBaseTaxaAdm.SelectedValue = oLocacaoProventos.BaseTaxaAdm;
            cboBaseTaxaAdmCondominio.SelectedValue = oLocacaoProventos.BaseTaxaAdmCondominio;
            txtReferencia.Text = oLocacaoProventos.Referencia.ToString();            
            cboValorReferencia.SelectedValue = oLocacaoProventos.ValorReferencia;
            cboBaseIrpf.SelectedValue = oLocacaoProventos.BaseIrpf;
            txtRotinaCalculo.Text = oLocacaoProventos.RotinaCalculo.ToString();

            txtDescricao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oLocacaoProventos.idLocacaoProventos.ToString();
        }

        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao, Convert.ToInt32(usuario), nomeAplicativo, nomeFormulario, btnFlag))
            {
                return true;
            }
            else return false;
        }

        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            txtIdLocacaoProventos.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdLocacaoProventos.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }

        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";

            ArrayList arTpProv = new ArrayList();
            arTpProv.Add(new popCombo("Débito", "D"));
            arTpProv.Add(new popCombo("Crédito", "C"));
            arTpProv.Add(new popCombo("Totalizador", "T"));
            cboTipoProvento.DataSource = arTpProv;
            cboTipoProvento.DisplayMember = "nome";
            cboTipoProvento.ValueMember = "valor";

            ArrayList arDimob = new ArrayList();
            arDimob.Add(new popCombo("Sim", "S"));
            arDimob.Add(new popCombo("Não", "N"));
            cboIntegraDimob.DataSource = arDimob;
            cboIntegraDimob.DisplayMember = "nome";
            cboIntegraDimob.ValueMember = "valor";

            ArrayList arTxAdm = new ArrayList();
            arTxAdm.Add(new popCombo("Sim", "S"));
            arTxAdm.Add(new popCombo("Não", "N"));
            cboBaseTaxaAdm.DataSource = arTxAdm;
            cboBaseTaxaAdm.DisplayMember = "nome";
            cboBaseTaxaAdm.ValueMember = "valor";

            ArrayList arTxAdmCond = new ArrayList();
            arTxAdmCond.Add(new popCombo("Sim", "S"));
            arTxAdmCond.Add(new popCombo("Não", "N"));
            cboBaseTaxaAdmCondominio.DataSource = arTxAdmCond;
            cboBaseTaxaAdmCondominio.DisplayMember = "nome";
            cboBaseTaxaAdmCondominio.ValueMember = "valor";

            ArrayList arVlRef = new ArrayList();
            arVlRef.Add(new popCombo("Valor", "V"));
            arVlRef.Add(new popCombo("Referencia", "R"));
            cboValorReferencia.DataSource = arVlRef;
            cboValorReferencia.DisplayMember = "nome";
            cboValorReferencia.ValueMember = "valor";

            ArrayList arIrpf = new ArrayList();
            arIrpf.Add(new popCombo("Sim", "S"));
            arIrpf.Add(new popCombo("Não", "N"));
            cboBaseIrpf.DataSource = arIrpf;
            cboBaseIrpf.DisplayMember = "nome";
            cboBaseIrpf.ValueMember = "valor";

        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqLocacaoProventos ofrm = new psqLocacaoProventos(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdLocacaoProventos.Enabled = true;
                    txtIdLocacaoProventos.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtIdLocacaoProventos.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaLocacaoProventos()
        {
            if (!String.IsNullOrEmpty(txtIdLocacaoProventos.Text))
            {

                LocacaoProventos oLocacaoProventos = new LocacaoProventos();
                try
                {
                    LocacaoProventosRN LocacaoProventosBLL = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);

                    oLocacaoProventos = montaLocacaoProventos();
                    oLocacaoProventos.idLocacaoProventos = Convert.ToInt32(txtIdLocacaoProventos.Text);

                    oLocacaoProventos = LocacaoProventosBLL.ObterPor(oLocacaoProventos);

                    if (String.IsNullOrEmpty(oLocacaoProventos.Descricao))
                    {
                        DialogResult result = MessageBox.Show("Locação Proventos não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        //txtidComodo.Text = oComodo.idComodo;
                        montaTela(oLocacaoProventos);
                        AtivaEdicao();
                        txtDescricao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Locação Proventos1: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtDescricao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                LocacaoProventos oLocacaoProventos = new LocacaoProventos();
                LocacaoProventosRN oLocacaoProventosBLL = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
                oLocacaoProventos = montaLocacaoProventos();

                oLocacaoProventosBLL.Salvar(oLocacaoProventos);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        public override void AtualizaObjeto()
        {
            try
            {
                LocacaoProventos oLocacaoProventos = new LocacaoProventos();
                LocacaoProventosRN oLocacaoProventosBLL = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
                oLocacaoProventos = montaLocacaoProventos();
                oLocacaoProventos.idLocacaoProventos = Convert.ToInt32(txtIdLocacaoProventos.Text);

                oLocacaoProventosBLL.Atualizar(oLocacaoProventos);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void ExcluiObjeto()
        {
            try
            {
                LocacaoProventos oLocacaoProventos = new LocacaoProventos();
                LocacaoProventosRN oLocacaoProventosBLL = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
                oLocacaoProventos = montaLocacaoProventos();
                oLocacaoProventos.idLocacaoProventos = Convert.ToInt32(txtIdLocacaoProventos.Text);

                oLocacaoProventosBLL.Excluir(oLocacaoProventos);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relLocacaoProventos ofrm = new Relatorios.relLocacaoProventos(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdLocacaoProventos_DoubleClick(object sender, EventArgs e)
        {
            txtIdLocacaoProventos.Text = grdLocacaoProventos.Rows[grdLocacaoProventos.CurrentRow.Index].Cells["idlocacaoproventos"].Value.ToString();
            BuscaLocacaoProventos();
            //BuscaObjeto();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com as Locações cadastrados
            LocacaoProventosRN objLocacaoProventos = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
            grdLocacaoProventos.DataSource = objLocacaoProventos.ListaLocacaoProventos();
            txtDescricao.Focus();
        }

        #endregion

        private void txtIdLocacaoProventos_Validating(object sender, CancelEventArgs e)
        {
            BuscaLocacaoProventos();
            //   BuscaObjeto();
        }        

        private void btnLocalizarAplicacao_Click(object sender, EventArgs e)
        {
            psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtIdAplicacao.Text = "";
            else
                txtIdAplicacao.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdAplicacao.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtIdAplicacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);

                oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Text);
                oAplicacao = oAplRN.ObterPor(oAplicacao);

                if (!String.IsNullOrEmpty(oAplicacao.descricao))
                {
                    txtAplicacao.Text = oAplicacao.descricao;
                    cboBaseTaxaAdm.Focus();
                }
                else
                    MessageBox.Show("Aplicação não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }        
    }
}

