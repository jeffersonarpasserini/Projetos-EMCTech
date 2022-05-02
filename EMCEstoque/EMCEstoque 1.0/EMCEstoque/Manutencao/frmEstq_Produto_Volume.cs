using System.Globalization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using MaskedNumber;

//*** O codigo principal da tabela idestq_produto_volume esta oculto atras da imagem do código de barras ***//
namespace EMCEstoque
{
    public partial class frmEstq_Produto_Volume : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Produto_Volume";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
        Estq_Produto oProduto = new Estq_Produto();

        public frmEstq_Produto_Volume(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao, Estq_Produto oEstq_Produto)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            //recebendo o produto como parâmetro
            oProduto = oEstq_Produto;

            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Produto_Volume()
        {
            InitializeComponent();
        }

        private void frmEstq_Produto_Volume_Activated(object sender, EventArgs e)
        {


        }

        private void frmEstq_Produto_Volume_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Produto_Volume";

            //carregando o nome do produto na label da tela
            lblProduto.Text = "PRODUTO: " + oProduto.idestq_produto + "-" + oProduto.descricao;

            //carregando as combos na entrada da tela
            //Unidade de Produto
            Estq_Produto_UnidadeRN oEstq_Produto_UnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            cboEstq_Produto_Unidade.DataSource = oEstq_Produto_UnidadeRN.ListaEstq_Produto_Unidade();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Produto_Unidade.ValueMember = "idestq_produto_unidade";
            cboEstq_Produto_Unidade.DisplayMember = "unidade_descricao";

            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private Estq_Produto_Volume montaEstq_Produto_Volume()
        {
            Estq_Produto_Volume oEstq_Produto_Volume = new Estq_Produto_Volume();
            oEstq_Produto_Volume.fatorconversao = txtFatorConversao.Value.ToString();
            //Produto
            oEstq_Produto_Volume.Estq_Produto = oProduto;
            //Unidade de Produto
            Estq_Produto_Unidade oEstq_Produto_Unidade = new Estq_Produto_Unidade();
            oEstq_Produto_Unidade.idestq_produto_unidade = EmcResources.cInt(txtEstq_Produto_Unidade.Text);
            Estq_Produto_UnidadeRN oEstq_Produto_UnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia,codempresa);
            oEstq_Produto_Volume.Estq_Produto_Unidade = oEstq_Produto_UnidadeRN.ObterPor(oEstq_Produto_Unidade);

            return oEstq_Produto_Volume;
        }
        private void montaTela(Estq_Produto_Volume oEstq_Produto_Volume)
        {
            txtidEstq_Produto_Volume.Text = oEstq_Produto_Volume.idestq_produto_volume.ToString();
            txtFatorConversao.Text = oEstq_Produto_Volume.fatorconversao;
            //Unidade de Produto
            txtEstq_Produto_Unidade.Text = oEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade.ToString();
            cboEstq_Produto_Unidade.SelectedValue = oEstq_Produto_Volume.Estq_Produto_Unidade.idestq_produto_unidade.ToString();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Produto_Volume.idestq_produto_volume.ToString();
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
            txtEstq_Produto_Unidade.Focus();
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidEstq_Produto_Volume.Text))
            {

                Estq_Produto_Volume oEstq_Produto_Volume = new Estq_Produto_Volume();
                try
                {
                    Estq_Produto_VolumeRN Estq_Produto_VolumeBLL = new Estq_Produto_VolumeRN(Conexao, objOcorrencia,codempresa);

                    oEstq_Produto_Volume = montaEstq_Produto_Volume();
                    oEstq_Produto_Volume.idestq_produto_volume = Convert.ToInt32(txtidEstq_Produto_Volume.Text);

                    oEstq_Produto_Volume = Estq_Produto_VolumeBLL.ObterPor(oEstq_Produto_Volume);

                    if (String.IsNullOrEmpty(oEstq_Produto_Volume.idestq_produto_volume.ToString()))
                    {
                        DialogResult result = MessageBox.Show("Volume de Produto não Cadastrado, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }

                    }
                    else
                    {
                        montaTela(oEstq_Produto_Volume);
                        AtualizaGrid();
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto_Volume: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtFatorConversao.Text = "0";
            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {
                Estq_Produto_Volume oEstq_Produto_Volume = new Estq_Produto_Volume();
                Estq_Produto_VolumeRN oEstq_Produto_VolumeBLL = new Estq_Produto_VolumeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Volume = montaEstq_Produto_Volume();

                oEstq_Produto_VolumeBLL.Salvar(oEstq_Produto_Volume);
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
                Estq_Produto_Volume oEstq_Produto_Volume = new Estq_Produto_Volume();
                Estq_Produto_VolumeRN oEstq_Produto_VolumeBLL = new Estq_Produto_VolumeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Volume = montaEstq_Produto_Volume();
                oEstq_Produto_Volume.idestq_produto_volume = Convert.ToInt32(txtidEstq_Produto_Volume.Text);

                oEstq_Produto_VolumeBLL.Atualizar(oEstq_Produto_Volume);
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
                Estq_Produto_Volume oEstq_Produto_Volume = new Estq_Produto_Volume();
                Estq_Produto_VolumeRN oEstq_Produto_VolumeBLL = new Estq_Produto_VolumeRN(Conexao, objOcorrencia,codempresa);
                oEstq_Produto_Volume = montaEstq_Produto_Volume();
                oEstq_Produto_Volume.idestq_produto_volume = Convert.ToInt32(txtidEstq_Produto_Volume.Text);

                oEstq_Produto_VolumeBLL.Excluir(oEstq_Produto_Volume);
                AtualizaGrid();
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }


        #endregion

        #region "metodos da dbgrid"

        private void grdEstq_Produto_Volume_DoubleClick(object sender, EventArgs e)
        {
            txtidEstq_Produto_Volume.Text = grdEstq_Produto_Volume.Rows[grdEstq_Produto_Volume.CurrentRow.Index].Cells["idEstq_Produto_Volume"].Value.ToString();
            txtidEstq_Produto_Volume.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
        }

        private void AtualizaGrid()
        {
            //carrega a grid
            Estq_Produto_VolumeRN objEstq_Produto_Volume = new Estq_Produto_VolumeRN(Conexao, objOcorrencia,codempresa);
            grdEstq_Produto_Volume.DataSource = objEstq_Produto_Volume.ListaEstq_Produto_Volume(oProduto.idestq_produto);
        }
        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtidEstq_Produto_Volume_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }


        private void cboEstq_Produto_Unidade_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtEstq_Produto_Unidade.Text = Convert.ToString(cboEstq_Produto_Unidade.SelectedValue);

        }

        private void txtEstq_Produto_Unidade_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtEstq_Produto_Unidade.Text))
            {
                cboEstq_Produto_Unidade.Focus();
            }
            else
            {
                cboEstq_Produto_Unidade.SelectedValue = Convert.ToInt32(txtEstq_Produto_Unidade.Text);
            }
        }


        #endregion

    }
}
