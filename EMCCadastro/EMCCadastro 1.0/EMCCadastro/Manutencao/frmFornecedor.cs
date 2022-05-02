using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityModel;

namespace EMCCadastro
{
    public partial class frmFornecedor : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmFornecedor";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int codPessoa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmFornecedor()
        {
            InitializeComponent();
        }
        public frmFornecedor(String idUsuario, String seqLogin, String idEmpresa, String empmaster, String idPessoa, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            codPessoa = Convert.ToInt32(idPessoa);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmFornecedor_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "fornecedor";
    
            Banco bco = new Banco();
            BancoRN bcoRN = new BancoRN(Conexao,objOcorrencia,codempresa);

            cboBanco.DataSource = bcoRN.ListaBanco(bco);
            cboBanco.DisplayMember = "descricao";
            cboBanco.ValueMember = "idbanco";

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;
            oFornecedor.idPessoa = codPessoa;

            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);

            oFornecedor = oFornecedorRN.ObterPor(oFornecedor);
               
            if (oFornecedor.idPessoa == null || oFornecedor.idPessoa == 0)
            {
                AtivaInsercao();
            }
            else
            {
                AtivaEdicao();
                montaTela(oFornecedor);
            }
            
        }


#region "metodos para tratamento das informacoes*********************************************************************"
      
        private Boolean verificaFornecedor(Fornecedor oFornecedor)
        {
            FornecedorRN oFornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oFornecedorRN.VerificaDados(oFornecedor);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
     
        private Fornecedor montaFornecedor()
        {
            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor.codEmpresa = empMaster;
            oFornecedor.idPessoa = codPessoa;
            oFornecedor.observacao = txtObservacao.Text;
            oFornecedor.agencia = txtAgencia.Text;
            oFornecedor.contaCorrente = txtContaCorrente.Text;
            oFornecedor.titularConta = txtTitularConta.Text;

            Banco bco = new Banco();
            bco.idBanco = Convert.ToInt32(cboBanco.SelectedValue);

            BancoRN bcoRN = new BancoRN(Conexao,objOcorrencia,codempresa);
            oFornecedor.banco = bcoRN.ObterPor(bco);

            
            return oFornecedor;
        }
        
        private void montaTela(Fornecedor oFornecedor)
        {

            txtObservacao.Text = oFornecedor.observacao;
            if (String.IsNullOrEmpty(oFornecedor.titularConta))
            {
                txtTitularConta.Text = oFornecedor.pessoa.nome;
            }
            else
                txtTitularConta.Text = oFornecedor.titularConta;

            txtAgencia.Text = oFornecedor.agencia;
            txtContaCorrente.Text = oFornecedor.contaCorrente;
            cboBanco.SelectedValue = oFornecedor.banco.idBanco;

            objOcorrencia.chaveidentificacao = oFornecedor.idPessoa.ToString();

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
            base.BuscaObjeto();

            Fornecedor oFornecedor = new Fornecedor();
            oFornecedor = montaFornecedor();
            oFornecedor.codEmpresa = empMaster;
            oFornecedor.idPessoa = codPessoa;

            try
            {
                FornecedorRN FornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);
                oFornecedor = FornecedorRN.ObterPor(oFornecedor);
                    
                montaTela(oFornecedor);
                AtivaEdicao();
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Fornecedor: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);
                

                oFornecedor = montaFornecedor();
                oFornecedor.dataCadastro = DateTime.Now;

                if (verificaFornecedor(oFornecedor))
                {
                    oFornecedorRN.Salvar(oFornecedor);
                    
                    LimpaCampos();
                    BuscaObjeto();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.SalvaObjeto();
        }
       
        public override void AtualizaObjeto()
        {
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);
                
                oFornecedor = montaFornecedor();
                

                if (verificaFornecedor(oFornecedor))
                {
                    
                    oFornecedorRN.Atualizar(oFornecedor);

                    BuscaObjeto();
                    MessageBox.Show("Fornecedor atualizado com sucesso");
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oFornecedor);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message+" "+erro.StackTrace);
            }
            //base.AtualizaObjeto();
        }
        
        public override void ExcluiObjeto()
        {
            try
            {
                Fornecedor oFornecedor = new Fornecedor();
                FornecedorRN oFornecedorRN = new FornecedorRN(Conexao,objOcorrencia,codempresa);
                oFornecedor = montaFornecedor();

                if (verificaFornecedor(oFornecedor))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Fornecedor ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        oFornecedorRN.Excluir(oFornecedor);

                        LimpaCampos();
                        MessageBox.Show("Fornecedor excluido!", "EMCtech");
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            //base.ExcluiObjeto();
        }
#endregion
#region "Tratamentos para buttons e texts**************************************************************************************" 
#endregion
#region "metodos da dbgrid*******************************************************************************************"
#endregion

 

    }
}
