using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCEventosModel;
using EMCEventosRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EMCEventos
{
    public partial class frmSubLocacao : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmSubLocacao";
        private const string nomeAplicativo = "EMCEventos";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();


        public frmSubLocacao(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmSubLocacao()
        {
            InitializeComponent();
        }

        private void frmSubLocacao_Activated(object sender, EventArgs e)
        {

        }
        private void frmSubLocacao_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "evt_sublocacao";

            //Fornecedor oFornecedor = new Fornecedor();
            //oFornecedor.codEmpresa = empMaster;

            AtualizaGrid();
            this.ActiveControl = txtIdEvento;
            CancelaOperacao();
        }
        #endregion

        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaSubLocacao(SubLocacao oSubLocacao)
        {
            SubLocacaoRN oSubLocRN = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oSubLocRN.VerificaDados(oSubLocacao);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Evento: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private SubLocacao montaSubLocacao()
        {
            SubLocacao oSubLocacao = new SubLocacao();

            oSubLocacao.idSublocacao = EmcResources.cInt(txtIdSubLocacao.Text);
            oSubLocacao.descricao = txtDescricaoSubLoc.Text;

            Evento oEvento = new Evento();
            EventoRN oEventoRN = new EventoRN(Conexao, objOcorrencia, codempresa);           

            oEvento.idEvento = EmcResources.cInt(txtIdEvento.Text);
            oEvento.descricao = txtDescEvento.Text;
            oEvento = oEventoRN.ObterPor(oEvento);
            oSubLocacao.evento = oEvento;            

            oSubLocacao.idBox = txtIdBox.Text;

            return oSubLocacao;
        }

        private void montaTela(SubLocacao oSubLocacao)
        {
            txtIdSubLocacao.Text = oSubLocacao.idSublocacao.ToString();

            txtIdEvento.Text = oSubLocacao.evento.idEvento.ToString();
            txtDescEvento.Text = oSubLocacao.evento.descricao;

            txtDescricaoSubLoc.Text = oSubLocacao.descricao.ToString();
            txtIdBox.Text = oSubLocacao.idBox;
            

            txtIdSubLocacao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oSubLocacao.idSublocacao.ToString();
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
            txtIdSubLocacao.Enabled = false;
            txtIdEvento.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdSubLocacao.Enabled = false;
            txtIdEvento.Focus();
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
            txtIdSubLocacao.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtIdSubLocacao.Focus();
                      
        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            try
            {
                psqSubLocacao ofrm = new psqSubLocacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    // txtIdIptu.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdSubLocacao.Enabled = true;
                    txtIdSubLocacao.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtIdEvento.Text = EMCEventos.retPesquisa.chavebusca.ToString();

                    //txtCodigoImovel.Focus();
                    txtIdSubLocacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaSubLocacao()
        {
            if (!String.IsNullOrEmpty(txtIdSubLocacao.Text))
            {

                SubLocacao oSubLocacao = new SubLocacao();
                try
                {
                    SubLocacaoRN SubLocacaoBLL = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);
                                        
                    oSubLocacao.idSublocacao = Convert.ToInt32(txtIdSubLocacao.Text);                   

                    oSubLocacao = SubLocacaoBLL.ObterPor(oSubLocacao);

                    if (oSubLocacao.idSublocacao == 0)
                    {
                        DialogResult result = MessageBox.Show("Sub Locação não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oSubLocacao);
                        AtivaEdicao();
                        txtIdSubLocacao.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro SubLocação: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtIdSubLocacao.Focus();

        }

        public override void SalvaObjeto()
        {
            try
            {
                SubLocacao oSubLocacao = new SubLocacao();
                SubLocacaoRN oSubLocacaoBLL = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);

                oSubLocacao = montaSubLocacao();     

                oSubLocacaoBLL.Salvar(oSubLocacao);
                AtualizaGrid();
                CancelaOperacao();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void AtualizaObjeto()
        {
            try
            {
                SubLocacao oSubLocacao = new SubLocacao();
                SubLocacaoRN oSubLocacaoBLL = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);
              

                oSubLocacao = montaSubLocacao();

                oSubLocacaoBLL.Atualizar(oSubLocacao);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void ExcluiObjeto()
        {
            try
            {
                SubLocacao oSubLocacao = new SubLocacao();
                SubLocacaoRN oSubLocacaoBLL = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);
                oSubLocacao = montaSubLocacao();

                oSubLocacaoBLL.Excluir(oSubLocacao);
                AtualizaGrid();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
        }

        public override void ImprimeObjeto()
        {
            try
            {
                Relatorios.relSubLocacao ofrm = new Relatorios.relSubLocacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid Evento ***********************************************************************************************"

        private void grdSubLocacao_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIdSubLocacao.Text = grdSubLocacao.Rows[grdSubLocacao.CurrentRow.Index].Cells["idevt_sublocacao"].Value.ToString();
                BuscaSubLocacao();

                txtIdSubLocacao.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void AtualizaGrid()
        {
            SubLocacaoRN objSubLocacaoRN = new SubLocacaoRN(Conexao, objOcorrencia, codempresa);
            grdSubLocacao.DataSource = objSubLocacaoRN.ListaSubLocacao();
            txtIdEvento.Focus();            

        }

        #endregion

        #region "Botões de Pesquisa  ****************************************************************************************************"

        private void txtIdSubLocacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaSubLocacao();
        }

        private void btnEvento_Click(object sender, EventArgs e)
        {
            try
            {
                psqEvento ofrm = new psqEvento(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEventos.retPesquisa.chaveinterna == 0)
                {
                    txtIdEvento.Text = "";
                }
                else
                {
                    txtIdEvento.Text = EMCEventos.retPesquisa.chaveinterna.ToString();
                    txtIdEvento.Focus();
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdEvento_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //SubLocacao objSubLocacao = new SubLocacao();

                if (!String.IsNullOrEmpty(txtIdEvento.Text))
                {
                    Evento oEvento = new Evento();
                    EventoRN oEventoRN = new EventoRN(Conexao, objOcorrencia, codempresa);

                    oEvento.idEvento = EmcResources.cInt(txtIdEvento.Text);
                    oEvento = oEventoRN.ObterPor(oEvento);

                    if (oEvento.idEvento == 0)
                    {
                        MessageBox.Show("Evento não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdEvento.Text = "";
                        btnEvento.Focus();
                    }
                    else
                    {
                        txtDescEvento.Text = oEvento.descricao;
                        txtDescEvento.Focus();
                        //AtualizaGrid();
                    }
                }
                else
                {
                    btnEvento.Focus();
                }
                //AtualizaGrid(objIptu);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtIdBox_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                SubLocacao oSubLocacao = new SubLocacao();

                foreach (DataGridViewRow oRow in grdSubLocacao.Rows)
                {
                    if (EmcResources.cInt(txtIdEvento.Text) != EmcResources.cInt(oRow.Cells["idevt_evento"].Value.ToString()) || txtIdBox.Text != oRow.Cells["idbox"].Value.ToString())
                    {
                        oSubLocacao.idBox = txtIdBox.Text;                
                    }
                    else
                    {
                        MessageBox.Show("Box não disponível para o Evento", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtIdEvento.Focus();
                    }                    
                }                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }
        #endregion 

    }
}
