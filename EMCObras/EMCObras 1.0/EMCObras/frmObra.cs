using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCCadastro;
using EMCObrasModel;
using EMCObrasRN;
using EMCEstoqueModel;
using EMCEstoqueRN;
using EMCEstoque;
using System.Collections;


namespace EMCObras
{
    public partial class frmObra : EMCLibrary.EMCForm
    {
        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmObra";
        private const string nomeAplicativo = "EMCObras";

        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

       
        #region "metodos do form"
     
        public frmObra()
        {
            InitializeComponent();
        }
        public frmObra(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;

            InitializeComponent();
        }   
        private void frmObra_Load(object sender, EventArgs e)
        {
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome =nomeAplicativo;
            objOcorrencia.aplicativo=oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "obra_cronograma";

            ContaCustoRN oContaCustoRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);
            string vMascara = oContaCustoRN.montaMascara();
            txtCodigoConta.Mask = @vMascara;

            this.ActiveControl = txtAbreviacao;
            CancelaOperacao();
            AtualizaGrid();
        }
        #endregion
        
        #region "[ metodos para tratamento das informacoes ]"
       
        private Obra montaObra()
        {
            Obra oObra = new Obra();
            oObra.idObra_Cronograma = EmcResources.cInt(txtIdObra_Cronograma.Text);
            oObra.abreviacao = txtAbreviacao.Text;
            
            Usuario oAprovador = new Usuario();
            oAprovador.idUsuario = EmcResources.cInt(txtAprovador_idUsuario.Text);
            oObra.aprovador_idUsuario = oAprovador;

            oObra.codEmpresa = codempresa;

            ContaCusto oConta = new ContaCusto();
            ContaCustoRN oCtaRN = new ContaCustoRN(Conexao,objOcorrencia,codempresa);
            oConta.codigoConta = txtCodigoConta.Text;
            oConta = oCtaRN.ObterPor(oConta);
            oObra.contaCusto = oConta;

            Aplicacao oAplicacao = new Aplicacao();
            AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);
            oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Value.ToString());
            oAplicacao = oAplRN.ObterPor(oAplicacao);
            oObra.aplicacao = oAplicacao;

            oObra.descricao = txtDescricaoObra.Text;
            oObra.dtaAprovacao = Convert.ToDateTime(txtDtaAprovacao.Text);
            oObra.dtaCronograma = Convert.ToDateTime(txtDtaCronograma.Text);
            oObra.dtaFinal = Convert.ToDateTime(txtDtaFinal.Text);
            oObra.dtaInicio = Convert.ToDateTime(txtDtaInicio.Text);

            Pessoa oEngenheiro = new Pessoa();
            PessoaRN oEngRN = new PessoaRN(Conexao, objOcorrencia, codempresa);
            oEngenheiro.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
            oEngenheiro.codEmpresa = empMaster;
            oEngenheiro = oEngRN.ObterPor(oEngenheiro);
            oObra.engenheiro = oEngenheiro;

            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(txtResponsavel_idUsuario.Text);
            oObra.responsavel_idUsuario = oUsuario;

            oObra.nroCEI = txtNroCEI.Text;
            oObra.obraPropria = cboObraPropria.SelectedValue.ToString();

            Estq_Almoxarifado oAlmoxarifado = new Estq_Almoxarifado();
            Estq_AlmoxarifadoRN oAlmoxarifadoRN = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia, codempresa);
            oAlmoxarifado.idestq_almoxarifado = EmcResources.cInt(txtIdEstq_Almoxarifado.Text);
            oAlmoxarifado = oAlmoxarifadoRN.ObterPor(oAlmoxarifado);
            oObra.almoxarifado = oAlmoxarifado;

            Obra_TipoContrato oTpContrato = new Obra_TipoContrato();
            Obra_TipoContratoRN oTpContratoRN = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
            oTpContrato.idObra_TipoContrato = EmcResources.cInt(cboTipoContrato.SelectedValue.ToString());
            oTpContrato = oTpContratoRN.ObterPor(oTpContrato);
            oObra.tipoContrato = oTpContrato;


            if (txtSituacao.Text == "Aberto")
                oObra.situacao = "A";
            else if (txtSituacao.Text == "Encerrado")
                oObra.situacao = "E";
            else if (txtSituacao.Text == "Aprovado")
                oObra.situacao = "L";

            return oObra;
        }
       
        private void montaTela(Obra oObra)
        {
            txtIdObra_Cronograma.Text = oObra.idObra_Cronograma.ToString();
            txtAbreviacao.Text = oObra.abreviacao;
            txtDescricaoObra.Text = oObra.descricao;
            txtDtaInicio.Text = oObra.dtaInicio.ToShortDateString();
            txtDtaFinal.Text = oObra.dtaFinal.ToShortDateString();
            txtIdContaCusto.Text = oObra.contaCusto.idContaCusto.ToString();
            txtCodigoConta.Text = oObra.contaCusto.codigoConta;
            txtContaCusto.Text = oObra.contaCusto.descricao;
            txtIdAplicacao.Text = oObra.aplicacao.idAplicacao.ToString();
            txtAplicacao.Text = oObra.aplicacao.descricao;
            txtIdPessoa.Text = oObra.engenheiro.idPessoa.ToString();
            txtEngenheiro.Text = oObra.engenheiro.nome;

            txtOrcamentador.Text = oObra.responsavel_idUsuario.nome;
            txtResponsavel_idUsuario.Text = oObra.responsavel_idUsuario.idUsuario.ToString();

            txtAprovador.Text = oObra.aprovador_idUsuario.nome;
            txtAprovador_idUsuario.Text = oObra.aprovador_idUsuario.idUsuario.ToString();

            txtDtaCronograma.Text = oObra.dtaCronograma.ToShortDateString();
            txtDtaAprovacao.Text = oObra.dtaAprovacao.ToShortDateString();

            txtNroCEI.Text = oObra.nroCEI;
            cboObraPropria.SelectedValue = oObra.obraPropria;

            txtIdEstq_Almoxarifado.Text = oObra.almoxarifado.idestq_almoxarifado.ToString();
            txtAlmoxarifado.Text = oObra.almoxarifado.descricao;

            cboTipoContrato.SelectedValue = oObra.tipoContrato.idObra_TipoContrato;

            if (oObra.situacao == "A")
                txtSituacao.Text = "Aberto";
            else if(oObra.situacao == "E" )
                txtSituacao.Text = "Encerrado";
            else if(oObra.situacao == "L")
                txtSituacao.Text = "Aprovado";

            txtAbreviacao.ReadOnly = true;
            objOcorrencia.chaveidentificacao = oObra.idObra_Cronograma.ToString();
            txtDescricaoObra.Focus();
        }
       
        public override bool verificaSeguranca(EmcResources.operacaoSeguranca btnFlag)
        {
            if (verificaPermissao.getPermissao(Conexao,Convert.ToInt32(usuario),nomeAplicativo,nomeFormulario,btnFlag))
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
            txtAbreviacao.Enabled = false;
        }
       
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtAbreviacao.Enabled = true;
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
        }
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            txtAbreviacao.ReadOnly = false;
            txtAbreviacao.Enabled = true;
            objOcorrencia.chaveidentificacao = "";
            txtAbreviacao.Focus();
        }
       
        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                //Relatorios.relObra ofrm = new Relatorios.relObra(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                //ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Obra: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        
        public override void BuscaObjeto()
        {
           //base.BuscaObjeto();
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
            catch (Exception e)
            {
                MessageBox.Show("Erro : " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtSituacao.Text = "Aberto";
            txtResponsavel_idUsuario.Text = usuario.ToString();

            Usuario oUser = new Usuario();
            oUser.idUsuario = EmcResources.cInt(txtResponsavel_idUsuario.Text);

            Obra_TipoContratoRN oTpContratoRN = new Obra_TipoContratoRN(Conexao, objOcorrencia, codempresa);
            cboTipoContrato.DataSource = oTpContratoRN.ListaObra_TipoContrato();
            cboTipoContrato.ValueMember = "idobra_tipocontrato";
            cboTipoContrato.DisplayMember = "descricao";

            //Obra Propria
            ArrayList arrSituacao = new ArrayList();
            arrSituacao.Add(new popCombo("Não", "N"));
            arrSituacao.Add(new popCombo("Sim", "S"));
            cboObraPropria.DataSource = arrSituacao;
            cboObraPropria.DisplayMember = "nome";
            cboObraPropria.ValueMember = "valor";

            objOcorrencia.chaveidentificacao = "";
            txtIdObra_Cronograma.ReadOnly = true;
            txtAbreviacao.Focus();
        }

        public override void SalvaObjeto()
        {
            try
            {
                
                Obra oObra = new Obra();
                ObraRN oObraBLL = new ObraRN(Conexao,objOcorrencia,codempresa);
                oObra = montaObra();

                oObraBLL.salvar(oObra);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
        }

        public override void AtualizaObjeto()
        {
            try
            {
                Obra oObra = new Obra();
                ObraRN oObraBLL = new ObraRN(Conexao,objOcorrencia,codempresa);
                oObra = montaObra();
                oObra.idObra_Cronograma = Convert.ToInt32(txtIdObra_Cronograma.Text);

                if (oObra.situacao == "A")
                {
                    oObraBLL.atualizar(oObra);
                    AtualizaGrid();
                    LimpaCampos();
                    CancelaOperacao();
                }
                else
                {
                    MessageBox.Show("Obra já foi aprovada ou está encerrada, não é permitda a alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                Obra oObra = new Obra();
                ObraRN oObraBLL = new ObraRN(Conexao,objOcorrencia,codempresa);
                oObra = montaObra();
                oObra.idObra_Cronograma = Convert.ToInt32(txtIdObra_Cronograma.Text);

                oObraBLL.excluir(oObra);
                AtualizaGrid();
                LimpaCampos();
                CancelaOperacao();


            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public void BuscaObra()
        {

            if (!String.IsNullOrEmpty(txtIdObra_Cronograma.Text) || !String.IsNullOrEmpty(txtAbreviacao.Text))
            {

                Obra oObra = new Obra();
                oObra.abreviacao = txtAbreviacao.Text;

                try
                {
                    ObraRN ObraBLL = new ObraRN(Conexao, objOcorrencia, codempresa);

                    //oObra = montaObra();

                    oObra = ObraBLL.obterPor(oObra);

                    if (oObra.idObra_Cronograma == 0)
                    {
                        DialogResult result = MessageBox.Show("Obra não cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            //LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                    }
                    else
                    {
                        montaTela(oObra);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Obra: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }
     
        #endregion

        #region "metodos da dbgrid"

        private void grdObra_DoubleClick(object sender, EventArgs e)
        {
            txtIdObra_Cronograma.Enabled = true;
            txtIdObra_Cronograma.Text = grdObra.Rows[grdObra.CurrentRow.Index].Cells["idobra_cronograma"].Value.ToString();
            txtAbreviacao.Text = grdObra.Rows[grdObra.CurrentRow.Index].Cells["abreviacao"].Value.ToString();
            txtAbreviacao.Focus();
            SendKeys.Send("{TAB}");
                      
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os Obras cadastrados
            ObraRN objObra = new ObraRN(Conexao,objOcorrencia,codempresa);
            grdObra.DataSource = objObra.listaObra();
        }

        #endregion

      
        private void txtIdObra_Cronograma_Validating(object sender, CancelEventArgs e)
        {
            BuscaObra();
        }

        private void txtAbreviacao_Validating(object sender, CancelEventArgs e)
        {
            BuscaObra();
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            psqPessoa ofrm = new psqPessoa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdPessoa.Text = "";
            }
            else
                txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdPessoa.Focus();
            SendKeys.Send("{TAB}");
        }

        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Pessoa oPessoa = new Pessoa();
                PessoaRN oPessoaRN = new PessoaRN(Conexao, objOcorrencia, codempresa);

                oPessoa.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                oPessoa.codEmpresa = empMaster;

                oPessoa = oPessoaRN.ObterPor(oPessoa);

                txtEngenheiro.Text = oPessoa.nome;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }
        
        private void btnAplicacao_Click(object sender, EventArgs e)
        {
            psqAplicacao ofrm = new psqAplicacao(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                //txtIdAplicacao.Text = "0";
            }
            else
            {
                txtIdAplicacao.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                txtIdAplicacao.Focus();
                SendKeys.Send("{TAB}");
            }

            

        }
        
        private void btnContaCusto_Click(object sender, EventArgs e)
        {
            psqContaCusto ofrm = new psqContaCusto(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia,false);
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

        private void txtCodigoConta_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ContaCusto oContaCusto = new ContaCusto();
                ContaCustoRN oCtaRN = new ContaCustoRN(Conexao, objOcorrencia, codempresa);

                oContaCusto.codigoConta = txtCodigoConta.Text;
                oContaCusto = oCtaRN.ObterPor(oContaCusto);

                if (!String.IsNullOrEmpty(oContaCusto.descricao))
                    txtContaCusto.Text = oContaCusto.descricao;
                else
                    MessageBox.Show("Conta Custo não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtAbreviacao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdAplicacao_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Aplicacao oAplicacao = new Aplicacao();
                AplicacaoRN oAplRN = new AplicacaoRN(Conexao, objOcorrencia, codempresa);

                oAplicacao.idAplicacao = EmcResources.cInt(txtIdAplicacao.Value.ToString());
                oAplicacao = oAplRN.ObterPor(oAplicacao);

                if (!String.IsNullOrEmpty(oAplicacao.descricao))
                    txtAplicacao.Text = oAplicacao.descricao;
                else
                    MessageBox.Show("Aplicação não encontrada", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void maskedNumber1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAlmoxarifado_Click(object sender, EventArgs e)
        {
            psqAlmoxarifado ofrm = new psqAlmoxarifado(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCEstoque.retPesquisa.chaveinterna == 0)
            {
                //txtIdAplicacao.Text = "0";
            }
            else
            {
                txtIdEstq_Almoxarifado.Text = EMCEstoque.retPesquisa.chaveinterna.ToString();
                txtIdEstq_Almoxarifado_Validating(null, null);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIdEstq_Almoxarifado_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Estq_Almoxarifado oAlmoxarifado = new Estq_Almoxarifado();
                Estq_AlmoxarifadoRN oAlmRN = new Estq_AlmoxarifadoRN(Conexao, objOcorrencia, codempresa);

                oAlmoxarifado.idestq_almoxarifado = EmcResources.cInt(txtIdEstq_Almoxarifado.Value.ToString());
                oAlmoxarifado = oAlmRN.ObterPor(oAlmoxarifado);

                if (!String.IsNullOrEmpty(oAlmoxarifado.descricao))
                    txtAlmoxarifado.Text = oAlmoxarifado.descricao;
                else
                {
                    MessageBox.Show("Almoxarifado não encontrado", "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdEstq_Almoxarifado.Text = "";
                    txtAlmoxarifado.Text = "";
                }

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Almoxarifado :"+oErro.Message, "Obra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

 



    }
}
