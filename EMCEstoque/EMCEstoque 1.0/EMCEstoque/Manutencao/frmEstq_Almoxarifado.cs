using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCCadastroRN;
using EMCCadastroModel;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCEstoque
{
    public partial class frmEstq_Almoxarifado : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Almoxarifado";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmEstq_Almoxarifado(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Almoxarifado()
        {
            InitializeComponent();
        }

        private void frmEstq_Almoxarifado_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Almoxarifado_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Almoxarifado";

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_Almoxarifado montaEstq_Almoxarifado()
        {
            Estq_Almoxarifado oEstq_Almoxarifado = new Estq_Almoxarifado();
            oEstq_Almoxarifado.descricao = txtDescricao.Text;
            Empresa oEmpresa = new Empresa();
            oEmpresa.idEmpresa = codempresa;
            EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
            oEstq_Almoxarifado.Empresa = oEmpresaRN.ObterPor(oEmpresa);

            return oEstq_Almoxarifado;
        }
        
        private void montaTela(Estq_Almoxarifado oEstq_Almoxarifado)
        {
            txtidEstq_Almoxarifado.Text = oEstq_Almoxarifado.idestq_almoxarifado.ToString();
            txtDescricao.Text = oEstq_Almoxarifado.descricao;

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Almoxarifado.idestq_almoxarifado.ToString();
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
            txtidEstq_Almoxarifado.Enabled = true;
            txtidEstq_Almoxarifado.Focus();
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqAlmoxarifado ofrm = new psqAlmoxarifado(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCEstoque.retPesquisa.chaveinterna == 0)
                {
                    //txtidBanco.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtidEstq_Almoxarifado.Enabled = true;
                    txtidEstq_Almoxarifado.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                    txtidEstq_Almoxarifado.Focus();
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

                Estq_Almoxarifado oEstq_Almoxarifado = new Estq_Almoxarifado();
                Estq_AlmoxarifadoRN oEstq_AlmoxarifadoBLL = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Almoxarifado = montaEstq_Almoxarifado();

                oEstq_AlmoxarifadoBLL.Salvar(oEstq_Almoxarifado);
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
                Estq_Almoxarifado oEstq_Almoxarifado = new Estq_Almoxarifado();
                Estq_AlmoxarifadoRN oEstq_AlmoxarifadoBLL = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Almoxarifado = montaEstq_Almoxarifado();
                oEstq_Almoxarifado.idestq_almoxarifado = Convert.ToInt32(txtidEstq_Almoxarifado.Text);

                oEstq_AlmoxarifadoBLL.Atualizar(oEstq_Almoxarifado);
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
                Estq_Almoxarifado oEstq_Almoxarifado = new Estq_Almoxarifado();
                Estq_AlmoxarifadoRN oEstq_AlmoxarifadoBLL = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia,codempresa);
                oEstq_Almoxarifado = montaEstq_Almoxarifado();
                oEstq_Almoxarifado.idestq_almoxarifado = Convert.ToInt32(txtidEstq_Almoxarifado.Text);

                oEstq_AlmoxarifadoBLL.Excluir(oEstq_Almoxarifado);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaAlmoxarifado()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Almoxarifado.Text))
            {

                Estq_Almoxarifado oEstq_Almoxarifado = new Estq_Almoxarifado();
                try
                {
                    Estq_AlmoxarifadoRN Estq_AlmoxarifadoBLL = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Almoxarifado = montaEstq_Almoxarifado();
                    oEstq_Almoxarifado.idestq_almoxarifado = Convert.ToInt32(txtidEstq_Almoxarifado.Text);

                    oEstq_Almoxarifado = Estq_AlmoxarifadoBLL.ObterPor(oEstq_Almoxarifado);

                    if (String.IsNullOrEmpty(oEstq_Almoxarifado.descricao))
                    {
                        DialogResult result = MessageBox.Show("Almoxarifado não Cadastrado, deseja incluir?", "JLMTech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Almoxarifado);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Almoxarifado: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Almoxarifado_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_Almoxarifado.Text = grdEstq_Almoxarifado.Rows[grdEstq_Almoxarifado.CurrentRow.Index].Cells["idEstq_Almoxarifado"].Value.ToString();
            txtidEstq_Almoxarifado.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();

        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Estq_AlmoxarifadoRN objEstq_Almoxarifado = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Almoxarifado.DataSource = objEstq_Almoxarifado.ListaEstq_Almoxarifado(Convert.ToString(codempresa));
        }

        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_Almoxarifado_Validating(object sender, CancelEventArgs e)
        {
            BuscaAlmoxarifado();
        }

        #endregion

    }
}
