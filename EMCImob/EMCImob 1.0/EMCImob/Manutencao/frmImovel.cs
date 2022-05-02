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
using System.Data.SqlClient;

namespace EMCImob
{
    public partial class frmImovel : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();



        public frmImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form ******************************************************************************************************"

        public frmImovel()
        {
            InitializeComponent();
        }

        private void frmImovel_Activated(object sender, EventArgs e)
        {

        }

        private void frmImovel_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "imovel";

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;

            AtualizaGrid();
            this.ActiveControl = txtCodigoImovel;
            CancelaOperacao();


        }

        #endregion

        #region "metodos para tratamento das informacoes ******************************************************************************"

        private Boolean verificaImovel(Imovel oImovel)
        {
            ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
            try
            {
                oImovelRN.VerificaDados(oImovel);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        private Imovel montaImovel()
        {
            Imovel oImovel = new Imovel();


            TipoImovel oTipoImovel = new TipoImovel();
            TipoImovelRN oTipoImRN = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
            oTipoImovel.idTipoImovel = EmcResources.cInt(cboTipoImovel.SelectedValue.ToString());
            //  oTipoImovel.descricao = cboTipoImovel.SelectedValue.ToString();
            oTipoImovel = oTipoImRN.ObterPor(oTipoImovel);
            oImovel.tipoImovel = oTipoImovel;

            oImovel.codigoImovel = txtCodigoImovel.Text;

            Empresa oEmpresa = new Empresa();
            oEmpresa.idEmpresa = empMaster;
            EmpresaRN oEmpRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
            oEmpresa = oEmpRN.ObterPor(oEmpresa);
            oImovel.empresa = oEmpresa;

            oImovel.descricao = txtDescricao.Text;
            oImovel.rua = txtRua.Text;
            oImovel.numero = txtNumero.Text.Trim();
            oImovel.complemento = txtComplemento.Text;
            oImovel.bairro = txtBairro.Text.Trim();
            oImovel.cidade = txtCidade.Text.Trim();
            oImovel.estado = txtEstado.Text;
            oImovel.nroCep = txtidCep.Text.Trim();
            oImovel.anotacoes = txtAnotacoes.Text;
            oImovel.observacoes = txtObservacoes.Text;
            oImovel.valorVenda = EmcResources.cCur(txtValorVenda.Value.ToString());
            oImovel.valorAluguel = EmcResources.cCur(txtValorAluguel.Value.ToString());
            oImovel.valorCondominio = EmcResources.cCur(txtValorCondominio.Value.ToString());
            oImovel.enderecoChave = txtEnderecoChave.Text;
            oImovel.matriculaCri = txtMatriculaCri.Text;
            oImovel.areaConstruida = EmcResources.cDouble(txtAreaConstruida.Text);

            //oImovel.situacao = "A";


            CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();
            CarteiraImoveisRN oCartImRN = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
            oCarteiraImoveis.idCarteiraImoveis = EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString());
            oCarteiraImoveis = oCartImRN.ObterPor(oCarteiraImoveis);
            oImovel.carteiraImoveis = oCarteiraImoveis;

            ContaCusto oContaCusto = new ContaCusto();
            ContaCustoRN oCtCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            oContaCusto.codigoConta = txtCodigoConta.Text;
            oContaCusto = oCtCustoRN.ObterPor(oContaCusto);
            oImovel.contaCusto = oContaCusto;

            //montar uma lista da grid imovelfuncionario

            /* lista de imovelcomodo */
            List<ImovelComodo> lstComodo = new List<ImovelComodo>();

            foreach (DataGridViewRow oRow in grdImovelComodo.Rows)
            {
                ImovelComodo oComodoImo = new ImovelComodo();

                Imovel oImovelComodo = new Imovel();
                oImovelComodo.idImovel = EmcResources.cInt(oRow.Cells["idimovelcomodo"].Value.ToString());
                oComodoImo.idImovel = oImovelComodo;

                Comodo oComodo = new Comodo();
                oComodo.idComodos = EmcResources.cInt(oRow.Cells["idcomodos"].Value.ToString());
                //oComodo.descricao = oRow.Cells["comodo"].Value.ToString();
                oComodoImo.idComodos = oComodo;

                oComodoImo.nroDepencia = EmcResources.cInt(oRow.Cells["nrodepencia"].Value.ToString());
                oComodoImo.descricao = oRow.Cells["descricaoimovelcomodo"].Value.ToString();
                oComodoImo.flag = oRow.Cells["flag"].Value.ToString();

                lstComodo.Add(oComodoImo);

            }
            oImovel.lstComodo = lstComodo;



            /* lista de imovelproprietario */

            List<ImovelProprietario> lstProprietario = new List<ImovelProprietario>();

            double somaParticipacao = 0;

            foreach (DataGridViewRow oRow in grdImovelProprietario.Rows)
            {
                ImovelProprietario oImoProp = new ImovelProprietario();

                oImoProp.idImovelProprietario = EmcResources.cInt(oRow.Cells["idimovelproprietario"].Value.ToString());

                Imovel oImovelProprietario = new Imovel();
                oImovelProprietario.idImovel = EmcResources.cInt(oRow.Cells["idimovelprop"].Value.ToString());
                oImoProp.idImovel = oImovelProprietario;

                Fornecedor oProprietario = new Fornecedor();
                oProprietario.codEmpresa = empMaster;
                oProprietario.idPessoa = EmcResources.cInt(oRow.Cells["idproprietario"].Value.ToString());
                oImoProp.idProprietario = oProprietario;


                oImoProp.representante = oRow.Cells["representante"].Value.ToString();

                oImoProp.flag = oRow.Cells["status"].Value.ToString();

                lstProprietario.Add(oImoProp);

                if (oRow.Cells["representante"].Value.ToString() == "S")
                {
                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = empMaster;
                    oFornecedor.idPessoa = EmcResources.cInt(oRow.Cells["idproprietario"].Value.ToString());
                    //   oFornecedor.pessoa.nome = oRow.Cells["nomepessoa"].Value.ToString();

                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, empMaster);
                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    oImovel.fornecedor = oFornecedor;
                }

                oImoProp.participacao = EmcResources.cDouble(oRow.Cells["participacao"].Value.ToString());
                somaParticipacao = somaParticipacao++;

                somaParticipacao = somaParticipacao + oImoProp.participacao;               

            }
            if (lblSituacao.Text != "Cancelado" && lblSituacao.Text != "")
            {
                if (somaParticipacao == 100)
                    oImovel.lstProprietario = lstProprietario;
                else
                {
                    Exception oPart = new Exception("Total da participação diferente de 100 %");
                    throw oPart;
                }
            }            

            return oImovel;

        }

        private void montaTela(Imovel oImovel)
        {
            txtIdImovel.Text = oImovel.idImovel.ToString();
           
            txtCodigoImovel.Text = oImovel.codigoImovel;
            txtIdEmpresa.Text = oImovel.empresa.idEmpresa.ToString();

            cboTipoImovel.SelectedValue = oImovel.tipoImovel.idTipoImovel;


            txtDescricao.Text = oImovel.descricao;
            txtRua.Text = oImovel.rua;
            txtNumero.Text = oImovel.numero;
            txtComplemento.Text = oImovel.complemento;
            txtBairro.Text = oImovel.bairro;
            txtCidade.Text = oImovel.cidade;
            txtEstado.Text = oImovel.estado;
            txtidCep.Text = oImovel.nroCep;
            txtAnotacoes.Text = oImovel.anotacoes;
            txtObservacoes.Text = oImovel.observacoes;
            txtValorVenda.Text = oImovel.valorVenda.ToString();
            txtValorAluguel.Text = oImovel.valorAluguel.ToString();
            txtValorCondominio.Text = oImovel.valorCondominio.ToString();
            txtEnderecoChave.Text = oImovel.enderecoChave;
            txtMatriculaCri.Text = oImovel.matriculaCri;
            txtAreaConstruida.Text = oImovel.areaConstruida.ToString();

            lblSituacao.Text = "";

            if (oImovel.situacao == "A")
            {
                lblSituacao.Text = "Liberado";
            }
            else if (oImovel.situacao == "L")
            {
                lblSituacao.Text = "Contrato em Andamento";
            }
            else if (oImovel.situacao == "V")
            {
                lblSituacao.Text = "Vendido";
            }
            else if(oImovel.situacao == "I")
            {
                lblSituacao.Text = "Inativo";
            }
            else if (oImovel.situacao == "C")
            {
                lblSituacao.Text = "Cancelado";
            }
            

            cboCarteiraImoveis.SelectedValue = oImovel.carteiraImoveis.idCarteiraImoveis;

            txtIdContaCusto.Text = oImovel.contaCusto.idContaCusto.ToString();
            txtCodigoConta.Text = oImovel.contaCusto.codigoConta;
            txtContaCusto.Text = oImovel.contaCusto.descricao;


            atualizaImoProprietarioGrid(oImovel);

            atualizaImoComodoGrid(oImovel);


            txtCodigoImovel.Focus();
            AtivaEdicao();
            objOcorrencia.chaveidentificacao = oImovel.idImovel.ToString();
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
            //txtIdImovel.Enabled = false;
            txtCodigoImovel.Enabled = false;
            cboTipoImovel.Focus();
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtIdImovel.Enabled = false;
            txtCodigoImovel.Focus();
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
            txtCodigoImovel.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtCodigoImovel.Focus();

            grdImovelComodo.Rows.Clear();
            grdImovelProprietario.Rows.Clear();

        }

        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();
            try
            {
                psqImovel ofrm = new psqImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0 && EMCImob.retPesquisa.chavebusca == "")
                {
                    // txtIdAplicacao.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtCodigoImovel.Enabled = true;
                    txtCodigoImovel.Text = EMCImob.retPesquisa.chavebusca.ToString();
                    txtIdImovel.Text = EMCImob.retPesquisa.chaveinterna.ToString();                    
                    txtCodigoImovel.Focus();
                    SendKeys.Send("{TAB}");

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void BuscaImovel()
        {
            if (!String.IsNullOrEmpty(txtIdImovel.Text) || !String.IsNullOrEmpty(txtCodigoImovel.Text))
            //if (!String.IsNullOrEmpty(txtCodigoImovel.Text))
            {

                Imovel oImovel = new Imovel();               
                try
                {
                    ImovelRN ImovelBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);

                    //oImovel = montaImovel();
                    //oImovel.idImovel = Convert.ToInt32(txtIdImovel.Text);
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = codempresa;

                    oImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa = oEmpresa;

                    oImovel = ImovelBLL.ObterPor(oImovel);


                    if (oImovel.idImovel == 0 || oImovel.codigoImovel == null)
                    //if (oImovel.codigoImovel == null)
                    {
                        DialogResult result = MessageBox.Show("Imóvel não Cadastrado, deseja incluir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            AtivaInsercao();
                            cboTipoImovel.Focus();
                        }
                        else
                            CancelaOperacao();
                    }
                    else
                    {
                        montaTela(oImovel);
                        AtivaEdicao();
                        txtCodigoImovel.Focus();
                        //AtualizaGrid();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Imóvel: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            objOcorrencia.chaveidentificacao = "";
            txtCodigoImovel.Focus();


            TipoImovelRN oTipoImovelRN = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
            cboTipoImovel.DataSource = oTipoImovelRN.ListaTipoImovel();
            cboTipoImovel.ValueMember = "idtipoimovel";
            cboTipoImovel.DisplayMember = "descricao";

            CarteiraImoveisRN oCarteiraImoveisRN = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
            cboCarteiraImoveis.DataSource = oCarteiraImoveisRN.ListaCarteiraImoveis();
            cboCarteiraImoveis.DisplayMember = "descricao";
            cboCarteiraImoveis.ValueMember = "idcarteiraimoveis";


            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Sim", "S"));
            arr.Add(new popCombo("Não", "N"));
            cboRepresentante.DataSource = arr;
            cboRepresentante.DisplayMember = "nome";
            cboRepresentante.ValueMember = "valor";

        }

        public override void SalvaObjeto()
        {
            try
            {
                Imovel oImovel = new Imovel();
                ImovelRN oImovelBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);
                lblSituacao.Text = "A";
                oImovel = montaImovel();
                oImovel.situacao = "A";

                oImovelBLL.Salvar(oImovel);
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
                Imovel oImovel = new Imovel();
                ImovelRN oImovelBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);
                oImovel = montaImovel();
                oImovel.situacao = "A";
                oImovel.idImovel = Convert.ToInt32(txtIdImovel.Text);
                oImovel.codigoImovel = txtCodigoImovel.Text;

                oImovelBLL.Atualizar(oImovel);
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
                Imovel oImovel = new Imovel();
                ImovelRN oImovelBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);
                lblSituacao.Text = "";
                oImovel = montaImovel();

                oImovel.situacao = "C";
                oImovel.idImovel = Convert.ToInt32(txtIdImovel.Text);
                oImovel.codigoImovel = txtCodigoImovel.Text;

                oImovelBLL.Excluir(oImovel);
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
                Relatorios.relImovel ofrm = new Relatorios.relImovel(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Relatório: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "metodos da dbgrid Imovel *********************************************************************************************"

        private void grdImovel_DoubleClick(object sender, EventArgs e)
        {
            txtIdImovel.Text = grdImovel.Rows[grdImovel.CurrentRow.Index].Cells["idimovel"].Value.ToString();
            txtCodigoImovel.Text = grdImovel.Rows[grdImovel.CurrentRow.Index].Cells["codigoimovel"].Value.ToString();
            BuscaImovel();

            txtCodigoImovel.Focus();
        }

        private void AtualizaGrid()
        {
            //carrega a grid com as Locações cadastrados
            ImovelRN objImovel = new ImovelRN(Conexao, objOcorrencia, codempresa);
            grdImovel.DataSource = objImovel.ListaImovel();
            txtCodigoImovel.Focus();

        }

        #endregion

        #region "Botões de Pesquisa Imóvel ********************************************************************************************"

        private void txtCodigoImovel_Validating(object sender, CancelEventArgs e)
        {
            BuscaImovel();
            //   BuscaObjeto();
        }

        private void txtidImovel_Validating(object sender, CancelEventArgs e)
        {
            BuscaImovel();
            //   BuscaObjeto();
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
                        txtIdPessoa.Focus();
                    }
                    else
                    {
                        txtPessoa.Text = oFornecedor.pessoa.nome;
                        txtParticipacao.Focus();
                    }
                }
                else
                {
                    txtPessoa.Focus();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
            // txtParticipacao.Focus();
            btnIncluiProprietario.Enabled = true;
            btnAlteraProprietario.Enabled = false;
            btnExcluiProprietario.Enabled = false;
        }

        private void cboTipoImovel_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TipoImovel oTpImovel = new TipoImovel();

                oTpImovel.idTipoImovel = EmcResources.cInt(cboTipoImovel.SelectedValue.ToString());

                if (!String.IsNullOrEmpty(oTpImovel.descricao))
                {
                    cboTipoImovel.SelectedValue = oTpImovel.descricao;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void cboCarteiraImoveis_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                CarteiraImoveis oCarteiraImoveis = new CarteiraImoveis();

                oCarteiraImoveis.idCarteiraImoveis = EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString());

                if (!String.IsNullOrEmpty(oCarteiraImoveis.Descricao))
                {
                    cboCarteiraImoveis.SelectedValue = oCarteiraImoveis.Descricao;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtidCep_Validating(object sender, CancelEventArgs e)
        {
            if (txtidCep.Text.Trim().Length == 8)
            {
                Cep oCep = new Cep(txtidCep.Text, "", "", "");
                try
                {
                    CepRN cepBLL = new CepRN(Conexao, objOcorrencia, codempresa);
                    oCep = cepBLL.ObterPor(oCep);

                    oCep.idCep = txtidCep.Text;

                    if (!String.IsNullOrEmpty(oCep.cidade))

                    //if (oCep.idCep.Trim().Length > 0)
                    {
                        txtCidade.Text = oCep.cidade;
                        txtBairro.Text = oCep.bairro;
                        txtEstado.Text = oCep.estado;
                        txtRua.Focus();
                    }
                    else
                        MessageBox.Show("Cep não cadastrado", "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Cep: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        private void btnBuscaCep_Click(object sender, EventArgs e)
        {
            psqCep ofrm = new psqCep(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
                txtidCep.Text = "";
            else
                txtidCep.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtidCep.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ContaCusto oContaCusto = new ContaCusto();
                ContaCustoRN oCtaRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                oContaCusto.codigoConta = txtCodigoConta.Text;
                oContaCusto = oCtaRN.ObterPor(oContaCusto);

                if (!String.IsNullOrEmpty(oContaCusto.descricao))
                {
                    txtContaCusto.Text = oContaCusto.descricao;
                    txtAreaConstruida.Focus();
                }
                else
                    MessageBox.Show("Conta Custo não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }
        private void btnLocalizarContaCusto_Click(object sender, EventArgs e)
        {
            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia, false);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdContaCusto.Text = "";
                // txtCodigoConta.Text = "";
            }
            else
            {
                txtIdContaCusto.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtCodigoConta.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
                txtCodigoConta.Focus();
                SendKeys.Send("{TAB}");
            }
        }

        private void btnLocalizarComodo_Click(object sender, EventArgs e)
        {
            try
            {
                psqComodo ofrm = new psqComodo(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCImob.retPesquisa.chaveinterna == 0)
                    txtIdComodo.Text = "";
                else
                    txtIdComodo.Text = EMCImob.retPesquisa.chaveinterna.ToString();
                txtIdComodo.Focus();
                SendKeys.Send("{TAB}");
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void txtIdComodo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdComodo.Text))
                {
                    ComodoRN oComodoRN = new ComodoRN(Conexao, objOcorrencia, empMaster);
                    Comodo oComodo = new Comodo();

                    oComodo.idComodos = EmcResources.cInt(txtIdComodo.Text);
                    oComodo = oComodoRN.ObterPor(oComodo);

                    if (EmcResources.cInt(oComodo.idComodos.ToString()) == 0)
                    {
                        MessageBox.Show("Comodo não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdComodo.Text = "";
                    }
                    else
                    {
                        txtComodo.Text = oComodo.descricao;
                        txtNroDependencia.Text = "";
                        txtDescricaoImoComodo.Text = "";
                        txtDescricaoImoComodo.Focus();
                    }

                    foreach (DataGridViewRow oRow in grdImovelComodo.Rows)
                    {
                        if (EmcResources.cInt(txtIdComodo.Text) == EmcResources.cInt(oRow.Cells["idcomodos"].Value.ToString()))
                        {
                            txtNroDependencia.Text = oRow.Cells["nrodepencia"].Value.ToString();
                            txtDescricaoImoComodo.Text = oRow.Cells["descricaoimovelcomodo"].Value.ToString();
                        }
                        else
                        {
                            txtComodo.Text = oComodo.descricao;
                        }
                    }
                }
                else
                {
                    txtComodo.Focus();

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }

            btnIncluiComodo.Enabled = true;
            btnAtualizaComodo.Enabled = false;
            btnExcluiComodo.Enabled = false;

        }

        #endregion

        #region "Tratamentos para buttons e texts comodo*******************************************************************************"

        private void btnExcluiComodo_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "E";

                foreach (DataGridViewRow oRow in grdImovelComodo.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idcomodos"].Value.ToString()) == EmcResources.cInt(txtIdComodo.Text))
                    {
                        oRow.Cells["flag"].Value = vFlag;
                        txtIdComodo.Text = "";
                        txtComodo.Text = "";
                        txtNroDependencia.Text = "";
                        txtDescricaoImoComodo.Text = "";
                    }

                    txtIdComodo.Focus();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnAlterarComodo_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "A";

                foreach (DataGridViewRow oRow in grdImovelComodo.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idcomodos"].Value.ToString()) == EmcResources.cInt(txtIdComodo.Text))
                    {
                        if (oRow.Cells["flag"].Value.ToString() == "I")
                            vFlag = "I";

                        oRow.Cells["nrodepencia"].Value = txtNroDependencia.Text;
                        oRow.Cells["flag"].Value = vFlag;
                        oRow.Cells["descricaoimovelcomodo"].Value = txtDescricaoImoComodo.Text;
                    }
                }
                txtIdComodo.Text = "";
                txtComodo.Text = "";
                txtNroDependencia.Text = "";
                txtDescricaoImoComodo.Text = "";

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnIncluiComodo_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "I";
                Boolean encontrou = false;

                if (EmcResources.cInt(txtIdComodo.Text) == 0 || txtComodo.Text == "")
                {
                    MessageBox.Show("Comodo não pode estar vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    encontrou = true;
                }
                else if (txtNroDependencia.Text == "")
                {
                    MessageBox.Show("Dependência não pode estar vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    encontrou = true;
                }

                if (grdImovelComodo.Rows.Count > 0)
                {

                    foreach (DataGridViewRow oRow in grdImovelComodo.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idcomodos"].Value.ToString()) == EmcResources.cInt(txtIdComodo.Text))
                        {
                            MessageBox.Show("Comodo já existe para o imóvel", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            encontrou = true;
                        }
                    }
                }

                if (!encontrou)
                {
                    Imovel objImovel = new Imovel();

                    if (EmcResources.cInt(txtIdImovel.Text) > 0)
                    {
                        objImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
                    }

                    grdImovelComodo.Rows.Add(objImovel.idImovel, txtIdComodo.Text, txtComodo.Text, txtNroDependencia.Text, vFlag, txtDescricaoImoComodo.Text);
                }

                txtIdComodo.Text = "";
                txtComodo.Text = "";
                txtNroDependencia.Text = "";
                txtDescricaoImoComodo.Text = "";

                txtIdComodo.Focus();

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btnNovoComodo_Click(object sender, EventArgs e)
        {
            btnLocalizarComodo.Enabled = true;
            txtIdComodo.Enabled = true;

            btnIncluiComodo.Enabled = true;
            btnAtualizaComodo.Enabled = false;
            btnExcluiComodo.Enabled = false;
        }

        #endregion

        #region"metodos da dbgrid ImovelComodo ***************************************************************************************"

        private void grdImovelComodo_DoubleClick(object sender, EventArgs e)
        {
            txtIdComodo.Text = grdImovelComodo.Rows[grdImovelComodo.CurrentRow.Index].Cells["idcomodos"].Value.ToString();
            txtComodo.Text = grdImovelComodo.Rows[grdImovelComodo.CurrentRow.Index].Cells["comodo"].Value.ToString();
            txtNroDependencia.Text = grdImovelComodo.Rows[grdImovelComodo.CurrentRow.Index].Cells["nrodepencia"].Value.ToString();
            txtDescricaoImoComodo.Text = grdImovelComodo.Rows[grdImovelComodo.CurrentRow.Index].Cells["descricaoimovelcomodo"].Value.ToString();
            txtIdComodo_Validating(null, null);

            btnIncluiComodo.Enabled = false;
            btnAtualizaComodo.Enabled = true;
            btnExcluiComodo.Enabled = true;

            txtIdComodo.Enabled = false;
            txtComodo.Enabled = false;
            btnLocalizarComodo.Enabled = false;

        }

        private void atualizaImoComodoGrid(Imovel oImovel)
        {

            List<ImovelComodo> lstImovelComodo = oImovel.lstComodo;

            grdImovelComodo.Rows.Clear();

            foreach (ImovelComodo oImoComodo in lstImovelComodo)
            {
                grdImovelComodo.Rows.Add(oImoComodo.idImovel.idImovel, oImoComodo.idComodos.idComodos, oImoComodo.idComodos.descricao, oImoComodo.nroDepencia, oImoComodo.flag, oImoComodo.descricao);
            }

            grdImovelComodo.ScrollBars = ScrollBars.Both;
            
        }

        #endregion

        #region "Tratamentos para buttons e texts proprietario*************************************************************************"

        private void btnNovoProprietario_Click(object sender, EventArgs e)
        {
            btnLocalizarProprietario.Enabled = true;
            txtIdPessoa.Enabled = true;

            btnIncluiProprietario.Enabled = true;
            btnAlteraProprietario.Enabled = false;
            btnExcluiProprietario.Enabled = false;
        }

        private void btnIncluiProprietario_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "I";
                Boolean encontrou = false;

                if (EmcResources.cInt(txtIdPessoa.Text) == 0)
                {
                    MessageBox.Show("Proprietário não pode estar vazio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    encontrou = true;
                }


                if (grdImovelProprietario.Rows.Count > 0)
                {
                    foreach (DataGridViewRow oRow in grdImovelProprietario.Rows)
                    {
                        if (EmcResources.cInt(oRow.Cells["idproprietario"].Value.ToString()) == EmcResources.cInt(txtIdPessoa.Text))
                        {
                            MessageBox.Show("Proprietário já existe para o imóvel", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            encontrou = true;
                        }            
                    }
                }

                if (cboRepresentante.SelectedValue.ToString() == "S")
                {
                    foreach (DataGridViewRow oRow in grdImovelProprietario.Rows)
                    {
                        if (oRow.Cells["representante"].Value.ToString() == "S")
                        {
                            MessageBox.Show("Já existe um representante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            encontrou = true;
                        }
                    }
                }              


                if (!encontrou)
                {
                    Imovel objImovel = new Imovel();
                    Fornecedor objFornecedor = new Fornecedor();

                    if (EmcResources.cInt(txtIdImovel.Text) > 0)
                    {
                        objImovel.idImovel = EmcResources.cInt(txtIdImovel.Text);
                    }
                    grdImovelProprietario.Rows.Add(txtIdImovelProprietario.Text, objImovel.idImovel, txtCodEmpresa.Text, txtIdPessoa.Text, txtParticipacao.Value, cboRepresentante.SelectedValue, vFlag);

                }

                txtIdPessoa.Text = "";
                txtPessoa.Text = "";
                txtParticipacao.Text = "";
                cboRepresentante.Text = "";

                txtIdPessoa.Focus();
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btnAlteraProprietario_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "A";

                foreach (DataGridViewRow oRow in grdImovelProprietario.Rows)
                {
                    if (EmcResources.cInt(oRow.Cells["idproprietario"].Value.ToString()) == EmcResources.cInt(txtIdPessoa.Text))
                    {
                        if (oRow.Cells["status"].Value.ToString() == "I")                        
                            vFlag = "I";                           
                        
                        oRow.Cells["participacao"].Value = txtParticipacao.Value;
                        oRow.Cells["representante"].Value = cboRepresentante.SelectedValue;
                        oRow.Cells["status"].Value = vFlag;
                            
                    }
                }
                txtIdPessoa.Text = "";
                txtPessoa.Text = "";
                txtParticipacao.Text = "";
                cboRepresentante.SelectedValue = "";

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btnExcluiProprietario_Click(object sender, EventArgs e)
        {
            try
            {
                string vFlag = "E";

                foreach (DataGridViewRow oRow in grdImovelProprietario.Rows)
                {

                    if (EmcResources.cInt(oRow.Cells["idproprietario"].Value.ToString()) == EmcResources.cInt(txtIdPessoa.Text))
                    {
                        oRow.Cells["status"].Value = vFlag;
                        txtIdPessoa.Text = "";
                        txtPessoa.Text = "";
                        txtParticipacao.Text = "";
                        cboRepresentante.Text = "";
                    }

                    txtIdPessoa.Focus();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        #region"metodos da dbgrid ImovelProprietario *********************************************************************************"

        private void grdImovelProprietario_DoubleClick(object sender, EventArgs e)
        {
            // txtIdImovelProprietario.Text = grdImovelProprietario.Rows[grdImovelProprietario.CurrentRow.Index].Cells["idimovelproprietario"].Value.ToString();
            txtIdPessoa.Text = grdImovelProprietario.Rows[grdImovelProprietario.CurrentRow.Index].Cells["idproprietario"].Value.ToString();
            txtParticipacao.Text = grdImovelProprietario.Rows[grdImovelProprietario.CurrentRow.Index].Cells["participacao"].Value.ToString();
            cboRepresentante.SelectedValue = grdImovelProprietario.Rows[grdImovelProprietario.CurrentRow.Index].Cells["representante"].Value.ToString();
            txtIdPessoa_Validating(null, null);

            btnIncluiProprietario.Enabled = false;
            btnAlteraProprietario.Enabled = true;
            btnExcluiProprietario.Enabled = true;

            txtIdPessoa.Enabled = false;
            txtPessoa.Enabled = false;
            btnLocalizarProprietario.Enabled = false;
        }

        private void atualizaImoProprietarioGrid(Imovel oImovel)
        {

            List<ImovelProprietario> lstImovelProprietario = oImovel.lstProprietario;

            grdImovelProprietario.Rows.Clear();

            foreach (ImovelProprietario oImoProp in lstImovelProprietario)
            {
                //se flag for nulo carrega vazio na grid
                string flag = " ";
                if (!String.IsNullOrEmpty(oImoProp.flag))
                    flag = oImoProp.flag;

                grdImovelProprietario.Rows.Add(oImoProp.idImovelProprietario, 
                                               oImoProp.idImovel.idImovel, 
                                               oImoProp.idProprietario.codEmpresa, 
                                               oImoProp.idProprietario.idPessoa, 
                                               oImoProp.participacao, 
                                               oImoProp.representante, 
                                               flag);
            }

            grdImovelProprietario.ScrollBars = ScrollBars.Both;

        }

        #endregion

    }
}