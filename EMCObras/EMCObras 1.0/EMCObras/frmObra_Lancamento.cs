using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCObrasModel;
using EMCObrasRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCObras
{
    public partial class frmObra_Lancamento : EMCLibrary.EMCForm
    {
        

        private const string nomeFormulario = "frmObra_Lancamento";
        private const string nomeAplicativo = "EMCObras";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmObra_Lancamento(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmObra_Lancamento()
        {
            InitializeComponent();
        }

        private void frmObra_Lancamento_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "obra_lancamento";

            this.ActiveControl = txtIdObra;

            CancelaOperacao();
           
        }
        #endregion


        #region "metodos para tratamento das informacoes"
 
        private Obra_Lancamento montaObra_Lancamento()
        {
            Obra_Lancamento oObra_Lancamento = new Obra_Lancamento();
           

            return oObra_Lancamento;
        }

        private void montaTela(Obra_Lancamento oObra_Lancamento)
        {
     
            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oObra_Lancamento.idObra_Lancamento.ToString();
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
           
        }

        public override void BuscaObjeto()
        {
            //try
            //{
            //    psqObraEtapa ofrm = new psqObraEtapa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            //    ofrm.ShowDialog();

            //    if (EMCObras.retPesquisa.chaveinterna == 0)
            //    {
            //        //txtidBanco.Text = "";
            //        //CancelaOperacao();
            //    }
            //    else
            //    {
            //        txtidObra_Etapa.Enabled = true;
            //        txtidObra_Etapa.Text = EMCObras.retPesquisa.chaveinterna.ToString();
            //        txtidObra_Etapa.Focus();
            //        SendKeys.Send("{TAB}");
            //    }
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
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

                Obra_Lancamento oObra_Lancamento = new Obra_Lancamento();
                Obra_LancamentoRN oObra_LancamentoBLL = new Obra_LancamentoRN(Conexao, objOcorrencia, codempresa);
                oObra_Lancamento = montaObra_Lancamento();

                oObra_LancamentoBLL.salvar(oObra_Lancamento);
             
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
                Obra_Lancamento oObra_Lancamento = new Obra_Lancamento();
                Obra_LancamentoRN oObra_LancamentoBLL = new Obra_LancamentoRN(Conexao, objOcorrencia, codempresa);
                oObra_Lancamento = montaObra_Lancamento();
                oObra_Lancamento.idObra_Lancamento = Convert.ToInt32(txtIdObra_Lancamento.Text);

                oObra_LancamentoBLL.atualizar(oObra_Lancamento);
               
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
                Obra_Lancamento oObra_Lancamento = new Obra_Lancamento();
                Obra_LancamentoRN oObra_LancamentoBLL = new Obra_LancamentoRN(Conexao, objOcorrencia, codempresa);
                oObra_Lancamento = montaObra_Lancamento();
                oObra_Lancamento.idObra_Lancamento = Convert.ToInt32(txtIdObra_Lancamento.Text);

                oObra_LancamentoBLL.excluir(oObra_Lancamento);
                
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }

        public void BuscaObraLancamento()
        {
            //if (!String.IsNullOrEmpty(txtidObra_Etapa.Text))
            //{

            //    Obra_Etapa oObra_Etapa = new Obra_Etapa();
            //    try
            //    {
            //        Obra_EtapaRN Obra_EtapaBLL = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);

            //        oObra_Etapa = montaObra_Lancamento();
            //        oObra_Etapa.idobra_etapa = Convert.ToInt32(txtidObra_Etapa.Text);

            //        oObra_Etapa = Obra_EtapaBLL.ObterPor(oObra_Etapa);

            //        if (String.IsNullOrEmpty(oObra_Etapa.descricao))
            //        {
            //            DialogResult result = MessageBox.Show("Etapa não Cadastrada, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //            if (result == DialogResult.Yes)
            //            {
            //                AtivaInsercao();
            //            }

            //        }
            //        else
            //        {
            //            montaTela(oObra_Etapa);
            //            AtualizaGrid();
            //            AtivaEdicao();
            //        }
            //    }
            //    catch (Exception erro)
            //    {
            //        MessageBox.Show("Erro Obra_Etapa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }

        #endregion


        #region "metodos da dbgrid"

        //private void grdObra_Etapa_DoubleClick(object sender, EventArgs e)
        //{
        //    txtidObra_Etapa.Text = grdObra_Etapa.Rows[grdObra_Etapa.CurrentRow.Index].Cells["idobra_etapa"].Value.ToString();
        //    txtidObra_Etapa.Focus();
        //    SendKeys.Send("{TAB}");
        //    AtivaEdicao();

        //}

        //private void AtualizaGrid()
        //{
        //    //carrega a grid com os ceps cadastrados
        //    Obra_EtapaRN objObra_Etapa = new Obra_EtapaRN(Conexao, objOcorrencia, codempresa);
        //    grdObra_Etapa.DataSource = objObra_Etapa.ListaObra_Etapa();
        //}


        #endregion

        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtAbreviacao.Text))
            {
                try
                {

                    ObraRN oObraRN = new ObraRN(Conexao, objOcorrencia, codempresa);
                    Obra oObra = new Obra();
                    oObra.abreviacao = txtAbreviacao.Text;

                    oObra = oObraRN.obterPor(oObra);

                    if (oObra.idObra_Cronograma > 0)
                    {
                        txtDescricaoObra.Text = oObra.descricao;
                        txtIdObra.Text = oObra.idObra_Cronograma.ToString();
                        grpDocumento.Enabled = true;
                        grpItem.Enabled = true;
                        txtNroDocumento.Focus();

                    }
                    else
                    {
                        MessageBox.Show("Obra não encontrada.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAbreviacao.Focus();
                    }
                }

                catch (Exception oErro)
                {
                    MessageBox.Show("Erro Cronograma: " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscaObra_Click(object sender, EventArgs e)
        {
            try
            {
                psqObra ofrm = new psqObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (retPesquisa.chaveinterna == 0)
                {
                    // txtIdObra_Cronograma.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtAbreviacao.Enabled = true;
                    txtAbreviacao.Text = EMCObras.retPesquisa.chavebusca.ToString();
                    txtAbreviacao.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro : " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtIdFornecedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);

                oFornecedor.idPessoa = EmcResources.cInt(txtIdFornecedor.Text);
                oFornecedor.codEmpresa = empMaster;

                oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                txtFornecedor.Text = oFornecedor.pessoa.nome;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdFornecedor.Text = "";
                else
                    txtIdFornecedor.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdFornecedor.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtAbreviacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdProduto_TextChanged(object sender, EventArgs e)
        {

        }





    }
}
