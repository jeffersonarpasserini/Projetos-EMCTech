using System;
using System.Collections.Generic;
using System.Collections;
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
using EMCCadastroModel;
using EMCCadastroRN;
using EMCFaturamentoModel;
using EMCFaturamentoRN;
using EMCCadastro;
using MaskedNumber;

namespace EMCEstoque
{
    public partial class frmEstq_Produto : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEstq_Produto";
        private const string nomeAplicativo = "EMCEstoque";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();
        
        public String codAtual = "";
        public String statusOperacao = "";

        public frmEstq_Produto(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "metodos do form"

        public frmEstq_Produto()
        {
            InitializeComponent();
        }

        private void frmEstq_Produto_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "Estq_Produto";

            //carregando as combos na entrada da tela


            //** Grupo de Produtos **//
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
            cboEstq_Grupo.DataSource = oEstq_GrupoRN.ListaEstq_Grupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Grupo.ValueMember = "idestq_grupo";
            cboEstq_Grupo.DisplayMember = "descricao";

            //** SubGrupo de Produtos **//
            Estq_SubGrupoRN oEstq_SubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
            cboEstq_SubGrupo.DataSource = oEstq_SubGrupoRN.ListaEstq_SubGrupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_SubGrupo.ValueMember = "idestq_subgrupo";
            cboEstq_SubGrupo.DisplayMember = "descricao";

            carregandoUnidade();

            cboEstq_SubGrupo.Enabled = false;
            txtidEstq_SubGrupo.Enabled = false;

            //** Família de Produto **//
            Estq_FamiliaRN oEstq_FamiliaRN = new Estq_FamiliaRN(Conexao, objOcorrencia,codempresa);
            cboEstq_Familia.DataSource = oEstq_FamiliaRN.ListaEstq_Familia();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Familia.ValueMember = "idestq_familia";
            cboEstq_Familia.DisplayMember = "descricao";

            //** Tipo de Produto **//
            Estq_TipoProdutoRN oEstq_TipoProdutoRN = new Estq_TipoProdutoRN(Conexao, objOcorrencia,codempresa);
            cboEstq_TipoProduto.DataSource = oEstq_TipoProdutoRN.ListaEstq_TipoProduto();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_TipoProduto.ValueMember = "idestq_tipoproduto";
            cboEstq_TipoProduto.DisplayMember = "descricao";

            //** Componente de Custo - Grupo **//
            Custo_ComponenteGrupoRN oCustoGrupoRN = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia,codempresa);
            cboCusto_ComponenteCusto.DataSource = oCustoGrupoRN.ListaCusto_ComponenteGrupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboCusto_ComponenteCusto.ValueMember = "idcusto_componentegrupo";
            cboCusto_ComponenteCusto.DisplayMember = "descricao";


            //** Componente de Custo  **//
            Custo_ComponenteRN oCustoRN = new Custo_ComponenteRN(Conexao, objOcorrencia, codempresa);
            cboCusto_Componente.DataSource = oCustoRN.ListaCusto_Componente(0);
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboCusto_Componente.ValueMember = "idcusto_componente";
            cboCusto_Componente.DisplayMember = "descricao";

            cboCusto_Componente.Enabled = false;
            txtidComponente_Custo.Enabled = false;

            /* Situacao Fiscal IPI */
            Fatu_SituacaoFiscalIPIRN oIPi = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
            /* Situacao Fiscal IPI - Entrada */
            cboFatu_SitFiscalIPIEntrada.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("E");
            cboFatu_SitFiscalIPIEntrada.ValueMember = "idfatu_situacaofiscalipi";
            cboFatu_SitFiscalIPIEntrada.DisplayMember = "descricao";
            /* Situacao Fiscal IPI - Saida */
            cboFatu_SitFiscalIPISaida.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("S");
            cboFatu_SitFiscalIPISaida.ValueMember = "idfatu_situacaofiscalipi";
            cboFatu_SitFiscalIPISaida.DisplayMember = "descricao";

            /*Carrega combo com regime de tributação de ipi */
            Fatu_TributacaoIPIRN oIPIRN = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);
            cboTributacaoIPI.DataSource = oIPIRN.ListaFatu_TributacaoIPI();
            cboTributacaoIPI.ValueMember = "idfatu_tributacaoipi";
            cboTributacaoIPI.DisplayMember = "descricao";


            this.ActiveControl = txtCodigoProduto;
            CancelaOperacao();
        }
        #endregion

        #region "metodos para tratamento das informacoes"

        private void recarregaCombos()
        {
            try
            {
                //** Grupo de Produtos **//
                Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia, codempresa);
                cboEstq_Grupo.DataSource = oEstq_GrupoRN.ListaEstq_Grupo();
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboEstq_Grupo.ValueMember = "idestq_grupo";
                cboEstq_Grupo.DisplayMember = "descricao";

                //** SubGrupo de Produtos **//
                Estq_SubGrupoRN oEstq_SubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
                cboEstq_SubGrupo.DataSource = oEstq_SubGrupoRN.ListaEstq_SubGrupo();
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboEstq_SubGrupo.ValueMember = "idestq_subgrupo";
                cboEstq_SubGrupo.DisplayMember = "descricao";

                cboEstq_SubGrupo.Enabled = false;
                txtidEstq_SubGrupo.Enabled = false;

                //** Família de Produto **//
                Estq_FamiliaRN oEstq_FamiliaRN = new Estq_FamiliaRN(Conexao, objOcorrencia, codempresa);
                cboEstq_Familia.DataSource = oEstq_FamiliaRN.ListaEstq_Familia();
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboEstq_Familia.ValueMember = "idestq_familia";
                cboEstq_Familia.DisplayMember = "descricao";

                //** Tipo de Produto **//
                Estq_TipoProdutoRN oEstq_TipoProdutoRN = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
                cboEstq_TipoProduto.DataSource = oEstq_TipoProdutoRN.ListaEstq_TipoProduto();
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboEstq_TipoProduto.ValueMember = "idestq_tipoproduto";
                cboEstq_TipoProduto.DisplayMember = "descricao";

                //** Componente de Custo - Grupo **//
                Custo_ComponenteGrupoRN oCustoGrupoRN = new Custo_ComponenteGrupoRN(Conexao, objOcorrencia, codempresa);
                cboCusto_ComponenteCusto.DataSource = oCustoGrupoRN.ListaCusto_ComponenteGrupo();
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboCusto_ComponenteCusto.ValueMember = "idcusto_componentegrupo";
                cboCusto_ComponenteCusto.DisplayMember = "descricao";


                //** Componente de Custo  **//
                Custo_ComponenteRN oCustoRN = new Custo_ComponenteRN(Conexao, objOcorrencia, codempresa);
                cboCusto_Componente.DataSource = oCustoRN.ListaCusto_Componente(0);
                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboCusto_Componente.ValueMember = "idcusto_componente";
                cboCusto_Componente.DisplayMember = "descricao";

                cboCusto_Componente.Enabled = false;
                txtidComponente_Custo.Enabled = false;


                /* Situacao Fiscal IPI */
                Fatu_SituacaoFiscalIPIRN oIPi = new Fatu_SituacaoFiscalIPIRN(Conexao, objOcorrencia, codempresa);
                /* Situacao Fiscal IPI - Entrada */
                cboFatu_SitFiscalIPIEntrada.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("E");
                cboFatu_SitFiscalIPIEntrada.ValueMember = "idfatu_situacaofiscalipi";
                cboFatu_SitFiscalIPIEntrada.DisplayMember = "descricao";
                /* Situacao Fiscal IPI - Saida */
                cboFatu_SitFiscalIPISaida.DataSource = oIPi.ListaFatu_SituacaoFiscalIPI("S");
                cboFatu_SitFiscalIPISaida.ValueMember = "idfatu_situacaofiscalipi";
                cboFatu_SitFiscalIPISaida.DisplayMember = "descricao";

                /*Carrega combo com regime de tributação de ipi */
                Fatu_TributacaoIPIRN oIPIRN = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);
                cboTributacaoIPI.DataSource = oIPIRN.ListaFatu_TributacaoIPI();
                cboTributacaoIPI.ValueMember = "idfatu_tributacaoipi";
                cboTributacaoIPI.DisplayMember = "descricao";
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private Estq_Produto montaEstq_Produto()
        {
            Estq_Produto oEstq_Produto = new Estq_Produto();
            oEstq_Produto.codigoProduto = txtCodigoProduto.Text;
            oEstq_Produto.descricao = txtDescricao.Text;
            oEstq_Produto.descricaodetalhada = txtDescricaoDetalhada.Text;
            oEstq_Produto.situacao = txtSituacao.Text;
            oEstq_Produto.codigoean = txtCodigoEan.Text;
            oEstq_Produto.qtde_estoqueminimo = EmcResources.nDec(txtQtde_EstoqueMinimo.Value.ToString());
            oEstq_Produto.qtde_estoquemaxima = EmcResources.nDec(txtQtde_EstoqueMaxima.Value.ToString());

            //Montando a Unidade Padrao
            
            Estq_Produto_Unidade oUnidade = new Estq_Produto_Unidade();
            oUnidade.idestq_produto_unidade = EmcResources.cInt(txtIdUnidadePadrao.Text);
            Estq_Produto_UnidadeRN oUnidadeRN = new Estq_Produto_UnidadeRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.Estq_Produto_Unidade = oUnidadeRN.ObterPor(oUnidade); 
            
            //Montando o Grupo
            Estq_Grupo oEstq_Grupo = new Estq_Grupo();
            oEstq_Grupo.idestq_grupo = EmcResources.cInt(txtidEstq_Grupo.Text);
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia,codempresa);
            oEstq_Produto.Estq_Grupo = oEstq_GrupoRN.ObterPor(oEstq_Grupo);

            //Montando Sub Grupo
            Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
            oEstq_SubGrupo.Estq_Grupo = oEstq_Grupo;
            oEstq_SubGrupo.idestq_subgrupo = EmcResources.cInt(txtidEstq_SubGrupo.Text);
            Estq_SubGrupoRN oEstq_SubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.Estq_SubGrupo = oEstq_SubGrupoRN.ObterPor(oEstq_SubGrupo);

            //Montando o Familia
            Estq_Familia oEstq_Familia = new Estq_Familia();
            oEstq_Familia.idestq_familia = EmcResources.cInt(txtidEstq_Familia.Text);
            Estq_FamiliaRN oEstq_FamiliaRN = new Estq_FamiliaRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.Estq_Familia = oEstq_FamiliaRN.ObterPor(oEstq_Familia);

            //montando o fabricante
            Fornecedor oFabricante = new Fornecedor();
            oFabricante.idPessoa = EmcResources.cInt(txtIdFabricante.Value.ToString());
            oFabricante.codEmpresa = empMaster;
            FornecedorRN oFabricanteRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.fabricante = oFabricanteRN.ObterPor(oFabricante);

            //Montando o Tipo de Produto
            Estq_TipoProduto oEstq_TipoProduto = new Estq_TipoProduto();
            oEstq_TipoProduto.idestq_tipoproduto = EmcResources.cInt(txtidEstq_TipoProduto.Text);
            Estq_TipoProdutoRN oEstq_TipoProdutoRN = new Estq_TipoProdutoRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.Estq_TipoProduto = oEstq_TipoProdutoRN.ObterPor(oEstq_TipoProduto);
            
            //Componente Custo
            Custo_ComponenteGrupo oGrupoCusto = new Custo_ComponenteGrupo();
            Custo_Componente oCusto = new Custo_Componente();
            oGrupoCusto.idcusto_componentegrupo = EmcResources.cInt(txtIdGrupo_ComponenteCusto.Text);
            oCusto.idcusto_componente = EmcResources.cInt(txtidComponente_Custo.Text);
            oCusto.Custo_ComponenteGrupo = oGrupoCusto;
            Custo_ComponenteRN oCustoRN = new Custo_ComponenteRN(Conexao, objOcorrencia, codempresa);
            oEstq_Produto.componenteCusto = oCustoRN.ObterPor(oCusto);

            /* ncm */
            Fatu_NCM oNcm = new Fatu_NCM();
            Fatu_NCMRN oNcmRN = new Fatu_NCMRN(Conexao, objOcorrencia, codempresa);
            oNcm.idfatu_ncm = EmcResources.cInt(txtidFatu_NCM.Text);
            oEstq_Produto.ncm = oNcmRN.ObterPor(oNcm);

            /* origem mercadoria */
            Fatu_OrigemMercadoria oOrigemMercadoria = new Fatu_OrigemMercadoria();
            Fatu_OrigemMercadoriaRN oOrigemMercadoriaRN = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia, codempresa);
            oOrigemMercadoria.idfatu_origemmercadoria = EmcResources.cInt(txtidFatu_OrigemMercadoria.Text);
            oEstq_Produto.origemMercadoria = oOrigemMercadoriaRN.ObterPor(oOrigemMercadoria);

            /* tributacao */
            if (EmcResources.cInt(txtidFatu_Tributacao.Text) > 0)
            {
                Fatu_Tributacao oTributacao = new Fatu_Tributacao();
                Fatu_TributacaoRN oTributacaoRN = new Fatu_TributacaoRN(Conexao, objOcorrencia, codempresa);
                oTributacao.idfatu_tributacao = EmcResources.cInt(txtidFatu_Tributacao.Text);
                oEstq_Produto.tributacao = oTributacaoRN.ObterPor(oTributacao);
            }

            /* ipi */
            if (cboTributacaoIPI.SelectedValue != null)
            {
                Fatu_TributacaoIPI oTributacaoIPI = new Fatu_TributacaoIPI();
                Fatu_TributacaoIPIRN oTributacaoIPIRN = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);
                oTributacaoIPI.idFatu_TributacaoIPI = EmcResources.cInt(cboTributacaoIPI.SelectedValue.ToString());
                oEstq_Produto.tributacaoIPI = oTributacaoIPIRN.ObterPor(oTributacaoIPI);
            }

            carregandoUnidade(oEstq_Produto);

            return oEstq_Produto;


        }
        private void montaTela(Estq_Produto oEstq_Produto)
        {
            txtidEstq_Produto.Text = oEstq_Produto.idestq_produto.ToString();
            txtDescricao.Text = oEstq_Produto.descricao;
            txtDescricaoDetalhada.Text = oEstq_Produto.descricaodetalhada;

            if (oEstq_Produto.situacao == "A")
            {
                lblSituacao.Text = "Produto : Ativo";
            }
            else
                lblSituacao.Text = "Produto : Inativo";

            txtSituacao.Text = oEstq_Produto.situacao.ToString();

            txtCodigoEan.Text = oEstq_Produto.codigoean.ToString();
            
            txtQtde_EstoqueMinimo.Text = oEstq_Produto.qtde_estoqueminimo.ToString();
            txtQtde_EstoqueMaxima.Text = oEstq_Produto.qtde_estoquemaxima.ToString();

            //carregando o grupo do estoque
            //** Grupo de Produtos **//
            Estq_GrupoRN oEstq_GrupoRN = new Estq_GrupoRN(Conexao, objOcorrencia, codempresa);
            cboEstq_Grupo.DataSource = oEstq_GrupoRN.ListaEstq_Grupo();
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboEstq_Grupo.ValueMember = "idestq_grupo";
            cboEstq_Grupo.DisplayMember = "descricao";

            txtidEstq_Grupo.Text = oEstq_Produto.Estq_Grupo.idestq_grupo.ToString();
            cboEstq_Grupo.SelectedValue = oEstq_Produto.Estq_Grupo.idestq_grupo.ToString();
            cboEstq_Grupo_SelectedValueChanged(null, null);
            
            //carregando o subgrupo do estoque
            //** SubGrupo de Produtos **//
            cboEstq_SubGrupo.SelectedValue = oEstq_Produto.Estq_SubGrupo.idestq_subgrupo.ToString();
            txtidEstq_SubGrupo.Text = oEstq_Produto.Estq_SubGrupo.idestq_subgrupo.ToString();
            txtidEstq_SubGrupo_Validating(null, null);
            
            carregandoUnidade(oEstq_Produto);

            //carregando a Familia
            txtidEstq_Familia.Text = oEstq_Produto.Estq_Familia.idestq_familia.ToString();
            cboEstq_Familia.SelectedValue = oEstq_Produto.Estq_Familia.idestq_familia.ToString();

            //carregando o fabricante
            if (oEstq_Produto.fabricante.idPessoa > 0)
            {
                txtIdFabricante.Text = oEstq_Produto.fabricante.idPessoa.ToString();
                txtFabricante.Text = oEstq_Produto.fabricante.pessoa.nome;
            }

            //carregando o Tipo de Produto
            txtidEstq_TipoProduto.Text = oEstq_Produto.Estq_TipoProduto.idestq_tipoproduto.ToString();
            cboEstq_TipoProduto.SelectedValue = oEstq_Produto.Estq_TipoProduto.idestq_tipoproduto.ToString();

            //Grupo Componente custo
            cboCusto_ComponenteCusto.SelectedValue = oEstq_Produto.componenteCusto.Custo_ComponenteGrupo.idcusto_componentegrupo.ToString();
            txtIdGrupo_ComponenteCusto.Text = oEstq_Produto.componenteCusto.Custo_ComponenteGrupo.idcusto_componentegrupo.ToString();

            
            //** Componente de Custo  **//
            Custo_ComponenteRN oCustoRN = new Custo_ComponenteRN(Conexao, objOcorrencia, codempresa);
            cboCusto_Componente.DataSource = oCustoRN.ListaCusto_Componente(EmcResources.cInt(cboCusto_ComponenteCusto.SelectedValue.ToString()));
            //definindo o campo que vai ser chave da combo e o que vai ser exibido
            cboCusto_Componente.ValueMember = "idcusto_componente";
            cboCusto_Componente.DisplayMember = "descricao";

            cboCusto_Componente.Enabled = true;
            txtidComponente_Custo.Enabled = true;

            txtidComponente_Custo.Text = oEstq_Produto.componenteCusto.idcusto_componente.ToString();
            cboCusto_Componente.SelectedValue = oEstq_Produto.componenteCusto.idcusto_componente.ToString();

            /* NCM */
            txtNCM.Text = oEstq_Produto.ncm.nroncm.ToString();
            txtidFatu_NCM.Text = oEstq_Produto.ncm.idfatu_ncm.ToString();
            txtNCMDescricao.Text = oEstq_Produto.ncm.descricao;

            /* codigo origem */
            txtidFatu_OrigemMercadoria.Text = oEstq_Produto.origemMercadoria.idfatu_origemmercadoria.ToString();
            txtCodigoOrigem.Text = oEstq_Produto.origemMercadoria.codigoOrigem;
            txtOrigemDescricao.Text = oEstq_Produto.origemMercadoria.descricao;

            /* tributação */
            txtidFatu_Tributacao.Text = oEstq_Produto.tributacao.idfatu_tributacao.ToString();
            txtCodigoTributacao.Text = oEstq_Produto.tributacao.codigotributacao.ToString();
            txtTributacao.Text = oEstq_Produto.tributacao.descricao;

            /* ipi */
            cboTributacaoIPI.SelectedValue = oEstq_Produto.tributacaoIPI.idFatu_TributacaoIPI.ToString();

            txtIpi_Perc_Tributado.Text = oEstq_Produto.tributacaoIPI.percTributado.ToString();
            txtIpi_Perc_Isentos.Text = oEstq_Produto.tributacaoIPI.percIsento.ToString();
            txtIpi_Perc_Outros.Text = oEstq_Produto.tributacaoIPI.percOutros.ToString();
            txtIpi_Perc_Ipi.Text = oEstq_Produto.tributacaoIPI.aliquotaIPI.ToString();

            cboFatu_SitFiscalIPIEntrada.SelectedValue = oEstq_Produto.tributacaoIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi.ToString();
            cboFatu_SitFiscalIPISaida.SelectedValue = oEstq_Produto.tributacaoIPI.situacaoIPISaida.idfatu_situacaofiscalipi.ToString();

            txtDescricao.Focus();

            //setando a ocorrência do código carregado
            objOcorrencia.chaveidentificacao = oEstq_Produto.idestq_produto.ToString();
        }
        public void carregandoUnidade()
        {
            String indiceConversao = "";

            Estq_SubGrupoRN oSubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
            Estq_SubGrupo oSubGrupo = new Estq_SubGrupo();

            oSubGrupo.idestq_subgrupo = EmcResources.cInt(cboEstq_SubGrupo.SelectedValue.ToString());

            oSubGrupo = oSubGrupoRN.ObterPor(oSubGrupo);

            Estq_Produto_VolumeRN oVolumeRN = new Estq_Produto_VolumeRN(Conexao, objOcorrencia, codempresa);
            Estq_Produto_Volume oVolume = new Estq_Produto_Volume();

            //Carregando unidades padrão
            /* Menor unidade de controle */
            txtUnidadeMenor.Text =  oSubGrupo.Unidade_MenorControle.unidade_abreviatura + "[1]";

            /* Unidade Padrao*/
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadePadrao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

            }
            txtUnidadePadrao.Text = oSubGrupo.UnidadePadrao.unidade_abreviatura + "[" + indiceConversao + "]";
            txtIdUnidadePadrao.Text = oSubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();


            /* Unidade Recebimento */
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadeRecebimento.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";
            }
            txtUnidadeRecebimento.Text = oSubGrupo.UnidadeRecebimento.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Requisicao  */
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadeRequisicao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

            }
            txtUnidadeRequisicao.Text = oSubGrupo.UnidadeRequisicao.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Solicitacao  */
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadeSolicitacao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

            }
            txtUnidadeSolicitacao.Text = oSubGrupo.UnidadeSolicitacao.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Venda  */
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadeVenda.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

            }
            txtUnidadeVenda.Text = oSubGrupo.UnidadeVenda.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Industria  */
            indiceConversao = "";
            if (oSubGrupo.Unidade_MenorControle.idestq_produto_unidade == oSubGrupo.UnidadeIndustria.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";
            }
            txtUnidadeIndustria.Text = oSubGrupo.UnidadeIndustria.unidade_abreviatura + "[" + indiceConversao + "]";

        }
        public void carregandoUnidade(Estq_Produto oEstq_Produto)
        {
            String indiceConversao = "";
            Estq_Produto_VolumeRN oVolumeRN = new Estq_Produto_VolumeRN(Conexao, objOcorrencia, codempresa);
            Estq_Produto_Volume oVolume = new Estq_Produto_Volume();

            //Carregando unidades padrão
            /* Menor unidade de controle */
            txtUnidadeMenor.Text = oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.unidade_abreviatura + "[1]";

            /* Unidade Padrao*/
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadePadrao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadePadrao;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }
            }
            txtUnidadePadrao.Text = oEstq_Produto.Estq_SubGrupo.UnidadePadrao.unidade_abreviatura + "["+indiceConversao+"]";
            txtIdUnidadePadrao.Text = oEstq_Produto.Estq_SubGrupo.UnidadePadrao.idestq_produto_unidade.ToString();


            /* Unidade Recebimento */
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadeRecebimento.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadeRecebimento;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }
            }
            txtUnidadeRecebimento.Text = oEstq_Produto.Estq_SubGrupo.UnidadeRecebimento.unidade_abreviatura + "["+indiceConversao+"]";

            /* Unidade Requisicao  */
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadeRequisicao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadeRequisicao;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }
            }
            txtUnidadeRequisicao.Text = oEstq_Produto.Estq_SubGrupo.UnidadeRequisicao.unidade_abreviatura + "["+indiceConversao+"]";

            /* Unidade Solicitacao  */
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadeSolicitacao.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadeSolicitacao;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }
            }
            txtUnidadeSolicitacao.Text = oEstq_Produto.Estq_SubGrupo.UnidadeSolicitacao.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Venda  */
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadeVenda.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadeVenda;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }

            }
            txtUnidadeVenda.Text = oEstq_Produto.Estq_SubGrupo.UnidadeVenda.unidade_abreviatura + "[" + indiceConversao + "]";

            /* Unidade Industria  */
            indiceConversao = "";
            if (oEstq_Produto.Estq_SubGrupo.Unidade_MenorControle.idestq_produto_unidade == oEstq_Produto.Estq_SubGrupo.UnidadeIndustria.idestq_produto_unidade)
                indiceConversao = "1";
            else
            {
                indiceConversao = "buscar";

                oVolume.Estq_Produto = oEstq_Produto;
                oVolume.Estq_Produto_Unidade = oEstq_Produto.Estq_SubGrupo.UnidadeIndustria;
                oVolume = oVolumeRN.ObterPor(oVolume);
                if (oVolume.idestq_produto_volume > 0)
                {
                    indiceConversao = oVolume.fatorconversao.ToString();
                }
            }
            txtUnidadeIndustria.Text = oEstq_Produto.Estq_SubGrupo.UnidadeIndustria.unidade_abreviatura + "[" + indiceConversao + "]";
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
            //ativando botões
            btnVolume.Enabled = true;
            btnFornecedor.Enabled = true;
            btnCliente.Enabled = true;
            btnLote.Enabled = true;
            btnPreco.Enabled = true;

            statusOperacao = "A";
        }
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();

            if (statusOperacao == "I")
            {
                txtCodigoProduto.Focus();
            }
            statusOperacao = "I";
            
        }
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            statusOperacao = "C";
        }

        public override void BuscaObjeto()
        {
            try
            {
                psqProduto ofrm = new psqProduto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                 if (!String.IsNullOrEmpty(EMCEstoque.retPesquisa.chavebusca))
           {
               txtCodigoProduto.Enabled = true;
               txtCodigoProduto.Text = EMCEstoque.retPesquisa.chavebusca.ToString();
               txtCodigoProduto.Focus();
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
            objOcorrencia.chaveidentificacao = "";
            cboEstq_SubGrupo.Enabled = false;
            txtidEstq_SubGrupo.Enabled = false;

            cboCusto_Componente.Enabled = false;
            txtidComponente_Custo.Enabled = false;

            //desativando botões
            btnVolume.Enabled = false;
            btnFornecedor.Enabled = false;
            btnCliente.Enabled = false;
            btnLote.Enabled = false;
            btnPreco.Enabled = false;
            base.LimpaCampos();
            txtIpi_Perc_Tributado.Text = "0";
            txtIpi_Perc_Outros.Text = "0";
            txtIpi_Perc_Isentos.Text = "0";
            txtIpi_Perc_Ipi.Text = "0";
            txtQtde_EstoqueMaxima.Text = "0";
            txtQtde_EstoqueMinimo.Text = "0";

            recarregaCombos();

            txtCodigoProduto.Focus();

            txtSituacao.Text = "A";

        }

        public override void SalvaObjeto()
        {
            try
            {

                Estq_Produto oEstq_Produto = new Estq_Produto();
                Estq_ProdutoRN oEstq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

                oEstq_Produto = montaEstq_Produto();

                oEstq_ProdutoBLL.Salvar(oEstq_Produto);
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Produto : " + erro.Message, "Aviso", MessageBoxButtons.OK,MessageBoxIcon.Information );
                txtDescricao.Focus();
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Estq_Produto oEstq_Produto = new Estq_Produto();
                Estq_ProdutoRN oEstq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);
                oEstq_Produto = montaEstq_Produto();
                oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

                oEstq_ProdutoBLL.Atualizar(oEstq_Produto);
                LimpaCampos();
                txtCodigoProduto.Focus();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Produto : " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Estq_Produto oEstq_Produto = new Estq_Produto();
                Estq_ProdutoRN oEstq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);
                oEstq_Produto = montaEstq_Produto();
                oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

                oEstq_ProdutoBLL.Excluir(oEstq_Produto);
                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Produto : " + erro.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            base.ExcluiObjeto();
        }

        public void BuscaProduto()
        {
            if (!String.IsNullOrEmpty(txtCodigoProduto.Text))
            {

                Estq_Produto oEstq_Produto = new Estq_Produto();
                try
                {
                    Estq_ProdutoRN Estq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

                    oEstq_Produto = montaEstq_Produto();
                    oEstq_Produto.codigoProduto = txtCodigoProduto.Text;

                    oEstq_Produto = Estq_ProdutoBLL.ObterPor(oEstq_Produto);

                    if (oEstq_Produto.idestq_produto == 0)
                    {
                        if (statusOperacao != "I")
                        {
                            DialogResult result = MessageBox.Show("Produto não Cadastrado, deseja incluir?", "JLMtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                AtivaInsercao();
                                codAtual = txtCodigoProduto.Text;
                                LimpaCampos();
                                txtCodigoProduto.Text = codAtual;
                            }
                        }
                    }
                    else
                    {
                        montaTela(oEstq_Produto);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Estq_Produto: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        #endregion

        #region [Tratamento de Texts, combos ]

        private void txtCodigoProduto_Validating(object sender, CancelEventArgs e)
        {
            BuscaProduto();
        }

        private void txtidEstq_Produto_Validating(object sender, CancelEventArgs e)
        {
            BuscaProduto();
        }

        private void txtidEstq_Produto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboEstq_Grupo_SelectedValueChanged(object sender, EventArgs e)
        {
            //limpando o Subgrupo de produtos
            txtidEstq_SubGrupo.Text = string.Empty;
            cboEstq_SubGrupo.DataSource = null;

            // seu código
            txtidEstq_Grupo.Text = Convert.ToString(cboEstq_Grupo.SelectedValue);

            //se selecionado algum grupo
            if (cboEstq_Grupo.SelectedIndex != -1 && cboEstq_Grupo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                //carregando o Subgrupo de acordo com o Grupo selecionado
                Estq_SubGrupoRN oEstq_SubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
                //
                cboEstq_SubGrupo.DataSource = oEstq_SubGrupoRN.ListaEstq_SubGrupo(EmcResources.cInt(cboEstq_Grupo.SelectedValue.ToString()));

                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboEstq_SubGrupo.ValueMember = "idestq_subgrupo";
                cboEstq_SubGrupo.DisplayMember = "descricao";

            }
        }
        
        private void txtidEstq_Grupo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidEstq_Grupo.Text))
            {
                cboEstq_Grupo.Focus();
            }
            else
            {
                cboEstq_Grupo.SelectedValue = Convert.ToInt32(txtidEstq_Grupo.Text);
                cboEstq_SubGrupo.Enabled = true;
                txtidEstq_SubGrupo.Enabled = true;
            }
        }

        private void txtidEstq_Grupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboEstq_Grupo_Validating(object sender, CancelEventArgs e)
        {
            if (EmcResources.cInt(txtidEstq_Grupo.Text) > 0)
            {
                cboEstq_SubGrupo.Enabled = true;
                txtidEstq_SubGrupo.Enabled = true;
            }
        }

        private void cboEstq_SubGrupo_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidEstq_SubGrupo.Text = Convert.ToString(cboEstq_SubGrupo.SelectedValue);
        }

        private void txtidEstq_SubGrupo_Validating(object sender, CancelEventArgs e)
        {
            try
            {

                
                //Carrega as unidades padrões de medida para o subgrupo
                if (!String.IsNullOrEmpty(txtidEstq_SubGrupo.Text))
                {
                    Estq_SubGrupo oEstq_SubGrupo = new Estq_SubGrupo();
                    oEstq_SubGrupo.idestq_subgrupo = EmcResources.cInt(txtidEstq_SubGrupo.Text);
                    Estq_SubGrupoRN oEstq_SubGrupoRN = new Estq_SubGrupoRN(Conexao, objOcorrencia, codempresa);
                    oEstq_SubGrupo = oEstq_SubGrupoRN.ObterPor(oEstq_SubGrupo);

                    if (oEstq_SubGrupo.idestq_subgrupo == 0)
                    {
                        MessageBox.Show("Sub-Grupo não não encontrado ", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtidEstq_SubGrupo.Focus();
                    }
                    else if (oEstq_SubGrupo.Estq_Grupo.idestq_grupo != EmcResources.cInt(txtidEstq_Grupo.Text))
                    {
                        MessageBox.Show("Sub-Grupo não pertence ao grupo escolhido ", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtidEstq_SubGrupo.Focus();
                    }
                    else
                    {
                        Estq_Produto oProduto = new Estq_Produto();
                        oProduto.Estq_SubGrupo = oEstq_SubGrupo;

                        carregandoUnidade(oProduto);
                    }


                    if (String.IsNullOrEmpty(txtidEstq_SubGrupo.Text))
                    {
                        cboEstq_SubGrupo.Focus();
                    }
                    else
                    {
                        cboEstq_SubGrupo.SelectedValue = Convert.ToInt32(txtidEstq_SubGrupo.Text);
                    }

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Produto :" + oErro.Message, "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtidEstq_SubGrupo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboEstq_Familia_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidEstq_Familia.Text = Convert.ToString(cboEstq_Familia.SelectedValue);
        }
        
        private void txtidEstq_Familia_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidEstq_Familia.Text))
            {
                cboEstq_Familia.Focus();
            }
            else
            {
                cboEstq_Familia.SelectedValue = Convert.ToInt32(txtidEstq_Familia.Text);
            }
        }

        private void txtidEstq_Familia_KeyPress(object sender, KeyPressEventArgs e)
        
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboEstq_TipoProduto_SelectedValueChanged(object sender, EventArgs e)
        {
            // seu código
            txtidEstq_TipoProduto.Text = Convert.ToString(cboEstq_TipoProduto.SelectedValue);
            txtIdFabricante.Focus();
        }

        private void txtidEstq_TipoProduto_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidEstq_TipoProduto.Text))
            {
                cboEstq_TipoProduto.Focus();
            }
            else
            {
                cboEstq_TipoProduto.SelectedValue = Convert.ToInt32(txtidEstq_TipoProduto.Text);
            }
        }

        private void txtidEstq_TipoProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCodigoTributacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigoOrigem.Text))
                {

                    Fatu_TributacaoRN oTribRN = new Fatu_TributacaoRN(Conexao, objOcorrencia, codempresa);
                    Fatu_Tributacao oTrib = new Fatu_Tributacao();
                    oTrib.codigotributacao = txtCodigoTributacao.Text.Trim();

                    oTrib = oTribRN.ObterPor(oTrib);

                    if (oTrib.idfatu_tributacao > 0)
                    {
                        txtidFatu_Tributacao.Text = oTrib.idfatu_tributacao.ToString();
                        txtTributacao.Text = oTrib.descricao;
                    }
                    else
                    {
                        MessageBox.Show("Tributação ICMS não cadastrado.", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtNCM_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtNCM.Text))
                {

                    Fatu_NCMRN oNcmRN = new Fatu_NCMRN(Conexao, objOcorrencia, codempresa);
                    Fatu_NCM oNcm = new Fatu_NCM();
                    oNcm.nroncm = txtNCM.Text.Trim();

                    oNcm = oNcmRN.ObterPor(oNcm);

                    if (oNcm.idfatu_ncm > 0)
                    {
                        txtidFatu_NCM.Text = oNcm.idfatu_ncm.ToString();
                        txtNCMDescricao.Text = oNcm.descricao;
                    }
                    else
                    {
                        MessageBox.Show("NCM não cadastrado.", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigoOrigem_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigoOrigem.Text))
                {

                    Fatu_OrigemMercadoriaRN oOrigemRN = new Fatu_OrigemMercadoriaRN(Conexao, objOcorrencia, codempresa);
                    Fatu_OrigemMercadoria oOrigem = new Fatu_OrigemMercadoria();
                    oOrigem.codigoOrigem = txtCodigoOrigem.Text.Trim();

                    oOrigem = oOrigemRN.ObterPor(oOrigem);

                    if (oOrigem.idfatu_origemmercadoria > 0)
                    {
                        txtidFatu_OrigemMercadoria.Text = oOrigem.idfatu_origemmercadoria.ToString();
                        txtOrigemDescricao.Text = oOrigem.descricao;
                    }
                    else
                    {
                        MessageBox.Show("Origem Mercadoria não cadastrado.", "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtCodigoEan_Validating(object sender, CancelEventArgs e)
        {
            txtidEstq_Grupo.Focus();
        }

        private void txtIdGrupo_ComponenteCusto_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtIdGrupo_ComponenteCusto.Text))
            {
                cboCusto_ComponenteCusto.Focus();
            }
            else
            {
                cboCusto_ComponenteCusto.SelectedValue = Convert.ToInt32(txtIdGrupo_ComponenteCusto.Text);
                cboCusto_Componente.Enabled = true;
                txtidComponente_Custo.Enabled = true;
            }
        }
        
        private void cboCusto_ComponenteCusto_Validating(object sender, CancelEventArgs e)
        {
            if (EmcResources.cInt(txtIdGrupo_ComponenteCusto.Text) > 0)
            {
                cboCusto_Componente.Enabled = true;
                txtidComponente_Custo.Enabled = true;
            }
        }

        private void cboCusto_ComponenteCusto_SelectedValueChanged(object sender, EventArgs e)
        {
            //limpando o Componente de custo
            txtidComponente_Custo.Text = string.Empty;
            cboCusto_Componente.DataSource = null;

            // seu código
            txtIdGrupo_ComponenteCusto.Text = Convert.ToString(cboCusto_ComponenteCusto.SelectedValue);

            //se selecionado algum grupo
            if (cboCusto_ComponenteCusto.SelectedIndex != -1 && cboCusto_ComponenteCusto.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                //carregando o Subgrupo de acordo com o Grupo selecionado
                Custo_ComponenteRN oComponenteRN = new Custo_ComponenteRN(Conexao, objOcorrencia, codempresa);
                //
                cboCusto_Componente.DataSource = oComponenteRN.ListaCusto_Componente(EmcResources.cInt(cboCusto_ComponenteCusto.SelectedValue.ToString()));

                //definindo o campo que vai ser chave da combo e o que vai ser exibido
                cboCusto_Componente.ValueMember = "idcusto_componente";
                cboCusto_Componente.DisplayMember = "descricao";

               
            }
        }

        private void txtIdGrupo_ComponenteCusto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtidComponente_Custo_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtidComponente_Custo.Text))
            {
                cboCusto_Componente.Focus();
            }
            else
            {
                cboCusto_Componente.SelectedValue = Convert.ToInt32(txtidComponente_Custo.Text);
            }
        }

        private void txtidComponente_Custo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cboCusto_Componente_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCusto_Componente.SelectedValue != null)
                txtidComponente_Custo.Text = cboCusto_Componente.SelectedValue.ToString();
        }

        private void btnNCM_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtNCM.Text))
            //{
                txtCodigoOrigem.Focus();
            //}
        }

        private void btnOrigem_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtCodigoOrigem.Text))
            //{
                txtCodigoTributacao.Focus();
            //}
        }

        private void txtQtde_EstoqueMaxima_Validating(object sender, CancelEventArgs e)
        {
            cboTributacaoIPI.Focus();
        }

        private void txtIdFabricante_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdFabricante_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdFabricante.Text))
            {
                //verificando se o fornecedor existe
                FornecedorRN oFabricanteRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);
                Fornecedor oFabricante = new Fornecedor();
                oFabricante.codEmpresa = empMaster;
                oFabricante.idPessoa = EmcResources.cInt(txtIdFabricante.Text);
                oFabricante = oFabricanteRN.ObterPor(oFabricante);
                if (oFabricante.pessoa == null)
                    MessageBox.Show("Fornecedor/Fabricante não Cadastrado", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    //verificando se já existe codigo interno cadastrado para o produto e o fornecedor digitados
                    txtFabricante.Text = oFabricante.pessoa.nome;
            }
        }

        private void btnFabricante_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtIdFabricante.Value.ToString()))
                {
                    psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                    ofrm.ShowDialog();

                    if (EMCCadastro.retPesquisa.chaveinterna == 0)
                        txtIdFabricante.Text = "";
                    else
                        txtIdFabricante.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                    txtIdFabricante.Focus();
                    SendKeys.Send("{TAB}");
                }
                else
                {
                    txtIdGrupo_ComponenteCusto.Focus();
                }

            }
            catch (Exception oerro)
            {
                MessageBox.Show("Erro:" + oerro.Message, "Estoque", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboTributacaoIPI_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void cboTributacaoIPI_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (cboTributacaoIPI.SelectedValue != null)
                {
                    Fatu_TributacaoIPI oIPI = new Fatu_TributacaoIPI();
                    Fatu_TributacaoIPIRN oIPIRN = new Fatu_TributacaoIPIRN(Conexao, objOcorrencia, codempresa);

                    oIPI.idFatu_TributacaoIPI = EmcResources.cInt(cboTributacaoIPI.SelectedValue.ToString());

                    oIPI = oIPIRN.ObterPor(oIPI);

                    if (!String.IsNullOrEmpty(oIPI.descricao))
                    {
                        /* ipi */
                        txtIpi_Perc_Tributado.Text = oIPI.percTributado.ToString();
                        txtIpi_Perc_Isentos.Text = oIPI.percIsento.ToString();
                        txtIpi_Perc_Outros.Text = oIPI.percOutros.ToString();
                        txtIpi_Perc_Ipi.Text = oIPI.aliquotaIPI.ToString();

                        cboFatu_SitFiscalIPIEntrada.SelectedValue = oIPI.situacaoIPIEntrada.idfatu_situacaofiscalipi.ToString();
                        cboFatu_SitFiscalIPISaida.SelectedValue = oIPI.situacaoIPISaida.idfatu_situacaofiscalipi.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Regime de Tributação de IPI não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
        #endregion

        #region [ buttons ]

        private void btnVolume_Click(object sender, EventArgs e)
        {

            Estq_Produto oEstq_Produto = new Estq_Produto();

            Estq_ProdutoRN Estq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

            oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

            oEstq_Produto = Estq_ProdutoBLL.ObterPor(oEstq_Produto);

            frmEstq_Produto_Volume ofrm = new frmEstq_Produto_Volume(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, oEstq_Produto);
            ofrm.ShowDialog();
        }

        private void btnCodigoFornecedor_Click(object sender, EventArgs e)
        {

            Estq_Produto oEstq_Produto = new Estq_Produto();

            Estq_ProdutoRN Estq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

            oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

            oEstq_Produto = Estq_ProdutoBLL.ObterPor(oEstq_Produto);

            frmEstq_Produto_Fornecedor ofrm = new frmEstq_Produto_Fornecedor(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, oEstq_Produto);
            ofrm.ShowDialog();
        }

        private void btnDescrCliente_Click(object sender, EventArgs e)
        {

            Estq_Produto oEstq_Produto = new Estq_Produto();

            Estq_ProdutoRN Estq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

            oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

            oEstq_Produto = Estq_ProdutoBLL.ObterPor(oEstq_Produto);

            frmEstq_Descricao ofrm = new frmEstq_Descricao(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, oEstq_Produto);
            ofrm.ShowDialog();
        }

        private void btnLote_Click(object sender, EventArgs e)
        {
            Estq_Produto oEstq_Produto = new Estq_Produto();

            Estq_ProdutoRN Estq_ProdutoBLL = new Estq_ProdutoRN(Conexao, objOcorrencia, codempresa);

            oEstq_Produto.idestq_produto = Convert.ToInt32(txtidEstq_Produto.Text);

            oEstq_Produto = Estq_ProdutoBLL.ObterPor(oEstq_Produto);

            frmEstq_Produto_Lote ofrm = new frmEstq_Produto_Lote(usuario, login, codempresa.ToString(), empMaster.ToString(), Conexao, oEstq_Produto);
            ofrm.ShowDialog();
        }

        #endregion

        private void btnIcms_Click(object sender, EventArgs e)
        {
            //if (String.IsNullOrEmpty(txtCodigoTributacao.Text))
            //{
                txtQtde_EstoqueMinimo.Focus();
            //}
        }

  

    }
}
