using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCImobModel;
using EMCImobRN;
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

namespace EMCImob
{
    public partial class frmDespesaImovel : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmDespesaImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();



        public frmDespesaImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmDespesaImovel()
        {
            InitializeComponent();
        }

        private void frmDespesaImovel_Activated(object sender, EventArgs e)
        {

        }
        private void frmDespesaImovel_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "despesaimovel";

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;


            AtualizaGrid();
            this.ActiveControl = txtIdDespesaImovel;
            CancelaOperacao();
        }
        #endregion

        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaImovel(DespesaImovel oDespImovel)
        {
            DespesaImovelRN oDespesaImovelRN = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oDespesaImovelRN.VerificaDados(oDespImovel);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Despesa Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private DespesaImovel montaDespesaImovel()
        {
            DespesaImovel oDespesaImovel = new DespesaImovel();
           

            Imovel oImovel = new Imovel();
            ImovelRN oImoRN = new ImovelRN(Conexao, objOcorrencia, codempresa);

            Empresa oEmpresa = new Empresa();
            oEmpresa.idEmpresa = codempresa;

            oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
            oImovel.codigoImovel = txtCodigoImovel.Text;
            oImovel.empresa = oEmpresa;
            oImovel = oImoRN.ObterPor(oImovel);
            oDespesaImovel.imovel = oImovel;

            LocacaoProventos oLocacaoProventos = new LocacaoProventos();
            LocacaoProventosRN oLocProventosRN = new LocacaoProventosRN(Conexao, objOcorrencia, codempresa);
            oLocacaoProventos.idLocacaoProventos = EmcResources.cInt(txtIdLocacaoProvento.Text);
            oLocacaoProventos = oLocProventosRN.ObterPor(oLocacaoProventos);

            if (oLocacaoProventos.TipoProvento == "D")
            {
                oDespesaImovel.locacaoProventos = oLocacaoProventos;
            }
            else
            {
                Exception oProventos = new Exception("Tipo de Provento não é uma Despesa");
                throw oProventos;
            }

            oDespesaImovel.dataLancamento = Convert.ToDateTime(txtDataLancamento.Text);
            oDespesaImovel.historico = txtHistorico.Text;
            oDespesaImovel.valorDespesa = EmcResources.cCur(txtValorDespesa.Value.ToString());
            oDespesaImovel.dataAcerto = Convert.ToDateTime(txtDataAcerto.Text);
            oDespesaImovel.descricaoAcerto = txtDescricaoAcerto.Text;

            Fornecedor oFornecedor = new Fornecedor();
            FornecedorRN oFornecRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
            oFornecedor.codEmpresa = empMaster;
            oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
            oFornecedor = oFornecRN.ObterPor(oFornecedor);
            oDespesaImovel.fornecedor = oFornecedor;

            oDespesaImovel.idUsuarioExclusao = EmcResources.cInt(usuario.ToString());
            oDespesaImovel.dataExclusao = Convert.ToDateTime(DateTime.Now);

            return oDespesaImovel;
        }

        private void montaTela(DespesaImovel oDespesaImovel)
        {
            txtIdDespesaImovel.Text = oDespesaImovel.idDespesaImovel.ToString();

            txtIdImovel.Text = oDespesaImovel.imovel.idImovel.ToString();
            txtCodigoImovel.Text = oDespesaImovel.imovel.codigoImovel;
            txtImovel.Text = oDespesaImovel.imovel.tipoImovel.descricao;

            txtIdLocacaoProvento.Text = oDespesaImovel.locacaoProventos.idLocacaoProventos.ToString();
            txtIdLocacaoProvento_Validating(null, null);

            txtDataLancamento.Text = oDespesaImovel.dataLancamento.ToString();
            txtHistorico.Text = oDespesaImovel.historico;
            txtValorDespesa.Text = oDespesaImovel.valorDespesa.ToString();
            txtDataAcerto.Text = oDespesaImovel.dataAcerto.ToString();

            lblSituacao.Text = "";

            if (oDespesaImovel.situacao == "A")
            {
                lblSituacao.Text = "Agendado";
            }
            else if (oDespesaImovel.situacao == "C")
            {
                lblSituacao.Text = "Cancelado";
            }

            txtDescricaoAcerto.Text = oDespesaImovel.descricaoAcerto;

            txtIdPessoa.Text = oDespesaImovel.fornecedor.idPessoa.ToString();
            txtIdPessoa_Validating(null, null);

            txtIdDespesaImovel.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oDespesaImovel.idDespesaImovel.ToString();
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
            txtIdDespesaImovel.Enabled = false;
            txtDataLancamento.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdDespesaImovel.Enabled = false;
            txtDataLancamento.Focus();
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
            lblSituacao.Text = "";
            objOcorrencia.chaveidentificacao = "";
            txtDataLancamento.Focus();

        }

        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            try
            {
                psqDespesaImovel ofrm = new psqDespesaImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    // txtIdDespesaImovel.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdDespesaImovel.Enabled = true;
                    txtIdDespesaImovel.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtIdDespesaImovel.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaDespesaImovel()
        {
            if (!String.IsNullOrEmpty(txtIdDespesaImovel.Text))
            {

                DespesaImovel oDespesaImovel = new DespesaImovel();
                try
                {
                    DespesaImovelRN DespesaImovelBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);

                    //oDespesaImovel = montaDespesaImovel();
                    oDespesaImovel.idDespesaImovel = Convert.ToInt32(txtIdDespesaImovel.Text);                  

                    oDespesaImovel = DespesaImovelBLL.ObterPor(oDespesaImovel);

                    if (oDespesaImovel.idDespesaImovel == 0)
                    {
                        DialogResult result = MessageBox.Show("Despesa de Imóvel não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oDespesaImovel);
                        AtivaEdicao();
                        txtDataLancamento.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Despesa Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtDataLancamento.Focus();

        }

        public override void SalvaObjeto()
        {
            try
            {
                DespesaImovel oDespesaImovel = new DespesaImovel();
                DespesaImovelRN oDespesaImovelBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);
                oDespesaImovel = montaDespesaImovel();
                oDespesaImovel.situacao = "A";

                oDespesaImovelBLL.Salvar(oDespesaImovel);
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
                DespesaImovel oDespesaImovel = new DespesaImovel();
                DespesaImovelRN oDespesaImovelBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);
                oDespesaImovel = montaDespesaImovel();
                oDespesaImovel.idDespesaImovel = Convert.ToInt32(txtIdDespesaImovel.Text);

                oDespesaImovelBLL.Atualizar(oDespesaImovel);
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
                DespesaImovel oDespesaImovel = new DespesaImovel();
                DespesaImovelRN oDespesaImovelBLL = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);
                oDespesaImovel = montaDespesaImovel();
                oDespesaImovel.situacao = "C";

                oDespesaImovel.idDespesaImovel = Convert.ToInt32(txtIdDespesaImovel.Text);

                oDespesaImovelBLL.Excluir(oDespesaImovel);
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
                Relatorios.relDespesaImovel ofrm = new Relatorios.relDespesaImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid Imovel *********************************************************************************************"

        private void grdDespesaImovel_DoubleClick(object sender, EventArgs e)
        {
            txtIdDespesaImovel.Text = grdDespesaImovel.Rows[grdDespesaImovel.CurrentRow.Index].Cells["iddespesaimovel"].Value.ToString();
            BuscaDespesaImovel();

            //txtIdDespesaImovel.Focus();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com as Locações cadastrados
            DespesaImovelRN objDespesaImovel = new DespesaImovelRN(Conexao, objOcorrencia, codempresa);
            grdDespesaImovel.DataSource = objDespesaImovel.ListaDespesaImovel();
            //txtIdDespesaImovel.Focus();
            //SendKeys.Send("{TAB}");

        }

        #endregion

        #region "Botões de Pesquisa  ***************************************************************************************************"

        private void txtIdDespesaImovel_Validating(object sender, CancelEventArgs e)
        {
            BuscaDespesaImovel();
        }

        private void btnLocalizarProprietario_Click(object sender, EventArgs e)
        {
            try
            {
                psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdPessoa.Text = "";
                else
                    txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdPessoa.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdPessoa.Text))
                {
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    Fornecedor oFornecedor = new Fornecedor();

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    if (EmcResources.cInt(oFornecedor.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Fornecedor não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdPessoa.Text = "";
                        btnLocalizarProprietario.Focus();
                    }
                    else
                    {
                        txtPessoa.Text = oFornecedor.pessoa.nome;
                        txtPessoa.Focus();
                    }
                }
                else
                {
                    btnLocalizarProprietario.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void btnImovel_Click(object sender, EventArgs e)
        {
            try
            {
                psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                {
                    //txtCodigoImovel.Text = "";
                }
                else
                {
                    txtIdImovel.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                    txtCodigoImovel.Text = EMCImob.retPesquisa.chavebusca.ToString();
                    txtCodigoImovel.Focus();
                    SendKeys.Send("{TAB}");
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtCodigoImovel_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigoImovel.Text) || !String.IsNullOrEmpty(txtIdImovel.Text))
                {
                    Imovel oImovel = new Imovel();
                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);

                    Empresa oEmpresa = new Empresa();
                    EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, empMaster);
                    oEmpresa.idEmpresa = empMaster;
                    oImovel.empresa = oEmpresa;

                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa.idEmpresa = empMaster;
                    oImovel = oImovelRN.ObterPor(oImovel);

                    if (String.IsNullOrEmpty(oImovel.codigoImovel) || oImovel.idImovel == 0)
                    {
                        MessageBox.Show("Imóvel não encontrado", "Imóvel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCodigoImovel.Text = "";
                        btnImovel.Focus();
                    }
                    else
                    {
                        txtImovel.Text = oImovel.tipoImovel.descricao;
                        txtImovel.Focus();
                    }
                }
                else
                {
                    btnImovel.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }        
        }
       

        private void btnLocacaoProvento_Click(object sender, EventArgs e)
        {
            try
            {
                psqLocacaoProventos ofrm = new psqLocacaoProventos(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                    txtIdLocacaoProvento.Text = "";
                else
                    txtIdLocacaoProvento.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                txtIdLocacaoProvento.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdLocacaoProvento_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocacaoProvento.Text))
                {
                    LocacaoProventosRN oLocacaoProventoRN = new LocacaoProventosRN(Conexao, objOcorrencia, empMaster);
                    LocacaoProventos oLocacaoProventos = new LocacaoProventos();

                    oLocacaoProventos.idLocacaoProventos = EmcResources.cInt(txtIdLocacaoProvento.Text);
                    oLocacaoProventos = oLocacaoProventoRN.ObterPor(oLocacaoProventos);

                    if (EmcResources.cInt(oLocacaoProventos.idLocacaoProventos.ToString()) == 0)
                    {
                        MessageBox.Show("Locação Proventos não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdLocacaoProvento.Text = "";
                        btnLocacaoProvento.Focus();
                    }
                    else if (oLocacaoProventos.TipoProvento != "D")
                    {
                        MessageBox.Show("Tipo Provento não é Despesa", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdLocacaoProvento.Text = "";
                        btnLocacaoProvento.Focus();
                    }
                    else
                    {
                        txtLocacaoProvento.Text = oLocacaoProventos.Descricao;
                        txtLocacaoProvento.Focus();
                    }
                }
                else
                {
                    btnLocacaoProvento.Focus();
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

