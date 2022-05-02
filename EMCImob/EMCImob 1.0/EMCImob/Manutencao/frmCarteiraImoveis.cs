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
using EMCSecurity;
using EMCSecurityModel;

namespace EMCImob
{
    public partial class frmCarteiraImoveis : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCarteiraImoveis";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmCarteiraImoveis(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {

            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmCarteiraImoveis()
        {
            InitializeComponent();
        }

        private void frmCarteiraImoveis_Activated(object sender, EventArgs e)
        {

        }
        private void frmCarteiraImoveis_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "carteiraimoveis";

            AtualizaGrid();
            this.ActiveControl = txtIdCarteiraImoveis;
            CancelaOperacao();

        }

        #endregion


        #region "metodos para tratamento das informacoes"

        private Boolean verificaCarteiraImoveis(CarteiraImoveis oCarteiraImoveis)
        {
            CarteiraImoveisRN oCarteiraImoveisRN = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oCarteiraImoveisRN.VerificaDados(oCarteiraImoveis);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Carteira de Imóveis: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private CarteiraImoveis montaCarteiraImoveis()
        {
            CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
            oCarteiraImoveis.Descricao = txtDescricao.Text;

            return oCarteiraImoveis;
        }

        private void montaTela(CarteiraImoveis oCarteiraImoveis)
        {
            txtDescricao.Text = oCarteiraImoveis.Descricao;
            txtIdCarteiraImoveis.Text = oCarteiraImoveis.idCarteiraImoveis.ToString();
            txtDescricao.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oCarteiraImoveis.idCarteiraImoveis.ToString();   
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
            txtIdCarteiraImoveis.Enabled = false;
            txtDescricao.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdCarteiraImoveis.Enabled = false;
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
        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqCarteiraImoveis ofrm = new psqCarteiraImoveis(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdCarteiraImoveis.Enabled = true;
                    txtIdCarteiraImoveis.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtIdCarteiraImoveis.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaCarteiraImoveis()
        {
            if (!String.IsNullOrEmpty(txtIdCarteiraImoveis.Text))
            {

                CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                try
                {
                    CarteiraImoveisRN CarteiraImoveisBLL = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);

                    oCarteiraImoveis = montaCarteiraImoveis();
                    oCarteiraImoveis.idCarteiraImoveis = Convert.ToInt32(txtIdCarteiraImoveis.Text);

                    oCarteiraImoveis = CarteiraImoveisBLL.ObterPor(oCarteiraImoveis);

                    if (String.IsNullOrEmpty(oCarteiraImoveis.Descricao))
                    {
                        DialogResult result = MessageBox.Show("Carteira de Imóveis não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        //txtidCarteiraImoveis.Text = oCarteiraImoveis.idCarteiraImoveis;
                        montaTela(oCarteiraImoveis);
                        txtDescricao.Focus();
                        AtivaEdicao();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro CarteiraImoveis: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                CarteiraImoveisRN oCarteiraImoveisBLL = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
                oCarteiraImoveis = montaCarteiraImoveis();

                oCarteiraImoveisBLL.Salvar(oCarteiraImoveis);
                AtualizaGrid();
                CancelaOperacao();
              //  LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
       //     base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                CarteiraImoveisRN oCarteiraImoveisBLL = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
                oCarteiraImoveis = montaCarteiraImoveis();
                oCarteiraImoveis.idCarteiraImoveis = Convert.ToInt32(txtIdCarteiraImoveis.Text);

                oCarteiraImoveisBLL.Atualizar(oCarteiraImoveis);
                AtualizaGrid();
                CancelaOperacao();
             //   LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
                CarteiraImoveisRN oCarteiraImoveisBLL = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
                oCarteiraImoveis = montaCarteiraImoveis();
                oCarteiraImoveis.idCarteiraImoveis = Convert.ToInt32(txtIdCarteiraImoveis.Text);

                oCarteiraImoveisBLL.Excluir(oCarteiraImoveis);
                AtualizaGrid();
                CancelaOperacao();
                //LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
                CancelaOperacao();
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relCarteiraImoveis ofrm = new Relatorios.relCarteiraImoveis(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Feriado: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdCarteiraImoveis_DoubleClick(object sender, EventArgs e)
        {
            txtIdCarteiraImoveis.Text = grdCarteiraImoveis.Rows[grdCarteiraImoveis.CurrentRow.Index].Cells["idCarteiraImoveis"].Value.ToString();            
            BuscaCarteiraImoveis();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os CarteiraImoveiss cadastrados
            CarteiraImoveisRN objCarteiraImoveis = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
            grdCarteiraImoveis.DataSource = objCarteiraImoveis.ListaCarteiraImoveis();
            txtDescricao.Focus();
        }


        #endregion


        private void txtIdCarteiraImoveis_Validating(object sender, CancelEventArgs e)
        {
            BuscaCarteiraImoveis();            
        }

    }
}
