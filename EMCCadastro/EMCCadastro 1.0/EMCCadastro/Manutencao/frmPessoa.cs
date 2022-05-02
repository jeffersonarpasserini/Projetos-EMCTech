using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurity;
using EMCSecurityModel;
using System.IO;

namespace EMCCadastro
{

    public partial class frmPessoa : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmPessoa";
        private const string nomeAplicativo = "EMCCadastro";
        private Boolean flagInclusao = true;
        private string vTipoPessoa = "F"; 
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Empresa oEmpresa = null;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmPessoa(String idUsuario, String seqLogin, String idEmpresa, String empmaster,ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmPessoa()
        {
            InitializeComponent();
        }

        private void frmPessoa_Load(object sender, EventArgs e)
        {
            //carrega dados da empresa atual
            //EmpresaRN oEmpRN = new EmpresaRN();
            //oEmpresa.idEmpresa = codempresa;
            //oEmpresa = oEmpRN.ObterPor(oEmpresa);
            objOcorrencia = new Ocorrencia();
            Aplicativo oAplicativo = new Aplicativo();
            oAplicativo.nome = nomeAplicativo;
            objOcorrencia.aplicativo = oAplicativo;
            objOcorrencia.formulario = nomeFormulario;
            objOcorrencia.seqLogin = EmcResources.cInt(login);
            Usuario oUsuario = new Usuario();
            oUsuario.idUsuario = EmcResources.cInt(usuario);
            objOcorrencia.usuario = oUsuario;
            objOcorrencia.tabela = "pessoa";
         
            
            AtualizaGrid();

            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.Estados)))
                cboEstado.Items.Add(s);

            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.TipoPessoa)))
                cboTipoPessoa.Items.Add(s);
            
            this.ActiveControl = txtIdPessoa;

            CancelaOperacao();
        }
        
#region Tratamento de eventos de botões*****************************************************************
        
        private void btnTelefone_Click(object sender, EventArgs e)
        {
            frmContato frmContato = new frmContato(usuario, login, codempresa.ToString(),empMaster.ToString(), txtIdPessoa.Text,Conexao);
            frmContato.ShowDialog();
        }
        
        private void btnCliente_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdPessoa.Text))
            {
                frmCliente frmCliente = new frmCliente(usuario, login, codempresa.ToString(), empMaster.ToString(), txtIdPessoa.Text,Conexao);
                frmCliente.ShowDialog();
                Pessoa oPessoa = new Pessoa();
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                oPessoa.codEmpresa = empMaster;
                oPessoa.idPessoa = Convert.ToInt32(txtIdPessoa.Text);
                montaTela(oPessoaRN.ObterPor(oPessoa));

            }
        }

        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdPessoa.Text))
            {
                frmFornecedor frmFornecedor = new frmFornecedor(usuario, login, codempresa.ToString(), empMaster.ToString(), txtIdPessoa.Text, Conexao);
                frmFornecedor.ShowDialog();
                Pessoa oPessoa = new Pessoa();
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                oPessoa.codEmpresa = empMaster;
                oPessoa.idPessoa = Convert.ToInt32(txtIdPessoa.Text);
                montaTela(oPessoaRN.ObterPor(oPessoa));
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

#endregion

#region Tratamento de Texts************************************************************************************
       
        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            if (!EmcResources.validaCNPJCPF(txtCNPJCPF.Text))
            {
                MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtCNPJCPF.Text.Trim().Length == 11)
            {
                txtCNPJCPF.Mask = "000.000.000-00";
                lblCNPJ.Text = "CPF";
                lblDtaNascimento.Text = "Nascimento";
                cboTipoPessoa.Text = "Física";
                txtNroRG.Enabled = true;
                txtInscrEstadual.Enabled = false;
                txtInscrMunicipal.Enabled = false;
            }
            else if (txtCNPJCPF.Text.Trim().Length == 14)
            {
                txtCNPJCPF.Mask = "00.000.000/0000-00";
                lblCNPJ.Text = "CNPJ";
                lblDtaNascimento.Text = "Fundação";
                cboTipoPessoa.Text = "Juridica";
                txtNroRG.Enabled = false;
                txtInscrEstadual.Enabled = true;
                txtInscrMunicipal.Enabled = true;
            }
            else
            {
                //MessageBox.Show("CNPJ/CPF Invalido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblCNPJ.Text = "CNPJ/CPF";
                lblDtaNascimento.Text = "Nasc/Fundação";
            }

            if (txtCNPJCPF.Text.Trim().Length > 0)
            {
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                Pessoa oPessoa = new Pessoa();

                oPessoa.codEmpresa = empMaster;
                oPessoa.cnpjCpf = txtCNPJCPF.Text;
                oPessoa = oPessoaRN.ObterPor(oPessoa);

                if (oPessoa.idPessoa == 0 && !flagInclusao)
                {
                    MessageBox.Show("CNPJ/CPF não encontrado" +
                                    " Cod: " + oPessoa.idPessoa + " Nome: " + oPessoa.nome, "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
                if (oPessoa.idPessoa > 0 && flagInclusao && oPessoa.idPessoa != EmcResources.cInt(txtIdPessoa.Text))
                {
                    MessageBox.Show("CNPJ/CPF já pertence a outro cadastro" +
                                    " Cod: " + oPessoa.idPessoa + " Nome: " + oPessoa.nome, "Erro", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }


            }
        }
       
        private void txtCNPJCPF_Enter(object sender, EventArgs e)
        {
            txtCNPJCPF.Mask = "";
            lblCNPJ.Text = "CNPJ/CPF";
            lblDtaNascimento.Text = "Nasc/Fundação";
        }
        
        private void cboTipoPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (cboTipoPessoa.Text == "Física")
                vTipoPessoa = "F";
            else if (cboTipoPessoa.Text == "Juridica")
                vTipoPessoa = "J";
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

                    if (oCep.idCep.Trim().Length > 0)
                    {
                        txtCidade.Text = oCep.cidade;
                        txtBairro.Text = oCep.bairro;
                        cboEstado.Text = oCep.estado;
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

        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            BuscaPessoa();
        }

        public void BuscaPessoa()
        {
            if (!String.IsNullOrEmpty(txtIdPessoa.Text))
            {

                Pessoa oPessoa = new Pessoa();
                oPessoa.idPessoa = EmcResources.cInt(txtIdPessoa.Text);

                try
                {


                    PessoaRN oRN = new PessoaRN(Conexao, objOcorrencia, codempresa);

                    oPessoa = montaPessoa();

                    oPessoa = oRN.ObterPor(oPessoa);

                   if (oPessoa.idPessoa == 0)
                    {
                        DialogResult result = MessageBox.Show("Pessoa não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            LimpaCampos();
                            AtivaInsercao();
                        }
                        else
                        {
                            CancelaOperacao();
                        }
                    }
                    else
                    {                        
                        montaTela(oPessoa);
                        AtivaEdicao();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pessoa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
   
#endregion

#region "Métodos Privados"
       
        private Boolean verificaPessoa(Pessoa oPessoa)
        {
            PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oPessoaRN.VerificaDados(oPessoa);
                return true;
            } catch (Exception erro)
            {
                MessageBox.Show("Erro Pessoa: " + erro.Message, "Messagem", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                
                return false;
            }
        }
       
        private Boolean verificaPessoaUnico(Pessoa oPessoa)
        {
            PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oPessoaRN.VerificaPessoa(oPessoa);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pessoa: "+erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        
        private Pessoa montaPessoa()
        {
            Pessoa oPessoa = new Pessoa();
            if (codempresa == empMaster)
            {
                oPessoa.codEmpresa = codempresa;
            }
            else
            {
                oPessoa.codEmpresa = empMaster;
            }
            oPessoa.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
            oPessoa.nome = txtNome.Text;
            oPessoa.nomeFantasia = txtNomeFantasia.Text;
            oPessoa.cnpjCpf = txtCNPJCPF.Text;
            oPessoa.nroRG = txtNroRG.Text.Trim();
            oPessoa.InscrEstadual = txtInscrEstadual.Text.Trim();
            oPessoa.endereco = txtEndereco.Text.Trim();
            oPessoa.numero = txtNumero.Text.Trim();
            oPessoa.bairro = txtBairro.Text.Trim();
            oPessoa.complemento = txtComplemento.Text.Trim();
            oPessoa.cidade = txtCidade.Text.Trim();
            oPessoa.estado = cboEstado.Text;
            oPessoa.idCep = txtidCep.Text.Trim();
            oPessoa.dataNascimento = Convert.ToDateTime(txtDtaNascimento.Text);
            oPessoa.email = txtEmail.Text.Trim();
            oPessoa.imagem = txtImagem.Text.Trim();
            oPessoa.site = txtSite.Text.Trim();
            oPessoa.tipopessoa = vTipoPessoa;
            oPessoa.inscrMunicipal = txtInscrMunicipal.Text.Trim();

            return oPessoa;
        }
       
        private void montaTela(Pessoa oPessoa)
        {
            
            txtNome.Text = oPessoa.nome;
            txtNomeFantasia.Text = oPessoa.nomeFantasia;
            txtCNPJCPF.Text = oPessoa.cnpjCpf;
            txtNroRG.Text = oPessoa.nroRG;
            txtInscrEstadual.Text = oPessoa.InscrEstadual;
            txtEndereco.Text = oPessoa.endereco;
            txtNumero.Text = oPessoa.numero;
            txtBairro.Text = oPessoa.bairro;
            txtComplemento.Text = oPessoa.complemento;
            txtCidade.Text = oPessoa.cidade;
            cboEstado.Text = oPessoa.estado;
            txtidCep.Text = oPessoa.idCep;
            txtDtaNascimento.Text = EmcResources.sDate(oPessoa.dataNascimento);
            txtImagem.Text = oPessoa.imagem;
            txtSite.Text = oPessoa.site;
            cboTipoPessoa.SelectedText = oPessoa.tipopessoa;
            txtInscrMunicipal.Text = oPessoa.inscrMunicipal;
            txtEmail.Text = oPessoa.email;

            if (oPessoa.cliente.idPessoa > 0)
            {
                btnCliente.Image = EMCCadastro.Properties.Resources.Pessoas_32x32;
            }
            else
            {
                btnCliente.Image = EMCCadastro.Properties.Resources.Pessoas_32x32pb;
            }

            if (oPessoa.fornecedor.idPessoa > 0)
            {
                btnFornecedor.Image = EMCCadastro.Properties.Resources.Pessoas_32x32;
            }
            else
            {
                btnFornecedor.Image = EMCCadastro.Properties.Resources.Pessoas_32x32pb;
            }

            if (txtCNPJCPF.Text.Trim().Length == 11)
            {
                txtCNPJCPF.Mask = "000.000.000-00";
                lblCNPJ.Text = "CPF";
                lblDtaNascimento.Text = "Nascimento";
                cboTipoPessoa.Text = "Física";
                txtNroRG.Enabled = true;
                txtInscrEstadual.Enabled = false;
                txtInscrMunicipal.Enabled = false;
                cboTipoPessoa.Text = "Física";

            }
            else if (txtCNPJCPF.Text.Trim().Length == 14)
            {
                txtCNPJCPF.Mask = "00.000.000/0000-00";
                lblCNPJ.Text = "CNPJ";
                lblDtaNascimento.Text = "Fundação";
                cboTipoPessoa.Text = "Juridica";
                txtNroRG.Enabled = false;
                txtInscrEstadual.Enabled = true;
                txtInscrMunicipal.Enabled = true;
                cboTipoPessoa.Text = "Judiridica";
            }


            objOcorrencia.chaveidentificacao = oPessoa.idPessoa.ToString();


            AtivaEdicao();

        }

#endregion

#region "Métodos Overrides"
        
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
            flagInclusao = false;
            btnCliente.Enabled = true;
            btnFornecedor.Enabled = true;
            btnFiador.Enabled = true;
            btnTelefone.Enabled = true;
            txtIdPessoa.Enabled = false;
            
        }
        
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            flagInclusao = true;
            btnCliente.Enabled = false;
            btnFornecedor.Enabled = false;
            btnFiador.Enabled = false;
            btnTelefone.Enabled = false;
            txtIdPessoa.Enabled = false;
            txtNomeFantasia.Focus();
            
        }
        
        public override void AtualizaTela()
        {
            base.AtualizaTela();
     
        }
        
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtIdPessoa.Enabled = true;
            txtIdPessoa.Focus();
        }
        
        public override void BuscaObjeto()
        {
            //base.BuscaObjeto();

            try
            {
                psqPessoa ofrm = new psqPessoa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                {
                    //txtIdPessoa.Text = "";
                    //txtCNPJCPF.Text = "";
                    //CancelaOperacao();
                }
                else
                {
                    txtIdPessoa.Enabled = true;
                    txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();
                    txtCNPJCPF.Text = EMCCadastro.retPesquisa.chavebusca.ToString();
                    txtIdPessoa.Focus();
                    SendKeys.Send("{TAB}");
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Pessoa: "+e.Message,"Mensagem",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
       
        public override void LimpaCampos()
        {
            base.LimpaCampos();
        }
       
        public override void SalvaObjeto()
        {
            //base.SalvaObjeto();
            try
            {
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                Pessoa oPessoa = new Pessoa();
                oPessoa = montaPessoa();

                if (verificaPessoa(oPessoa))
                {
                    if (verificaPessoaUnico(oPessoa)) 
                    {
                        oPessoaRN.Salvar(oPessoa);
                        AtualizaGrid();
                        LimpaCampos();
                    }

                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pessoa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public override void AtualizaObjeto()
        {
            Pessoa oPessoa = new Pessoa();
            try
            {
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                
                oPessoa = montaPessoa();

                if (verificaPessoa(oPessoa))
                {
                    oPessoaRN.Atualizar(oPessoa);
                    AtualizaGrid();
                    LimpaCampos();
                }
                
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pessoa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            //base.AtualizaObjeto();
        }

        public override void ExcluiObjeto()
        {
            try
            {
                PessoaRN oPessoaRN = new PessoaRN(Conexao,objOcorrencia,codempresa);
                Pessoa oPessoa = new Pessoa();
                oPessoa = montaPessoa();

                
                oPessoaRN.Excluir(oPessoa);
                AtualizaGrid();
                LimpaCampos();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pessoa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                EMCCadastro.Relatorios.relPessoa oFrm = new EMCCadastro.Relatorios.relPessoa(usuario, login, Convert.ToString(codempresa), Convert.ToString(empMaster), Conexao);
                oFrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Pessoa: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

#endregion
        
#region "metodos da dbgrid***************************************************************************************"

        private void grdPessoa_DoubleClick(object sender, EventArgs e)
        {
            txtIdPessoa.Enabled = true;
            txtIdPessoa.Text = grdPessoa.Rows[grdPessoa.CurrentRow.Index].Cells["idpessoa"].Value.ToString();          
            txtIdPessoa.Focus();
            SendKeys.Send("{TAB}");
  
        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            PessoaRN objPessoa = new PessoaRN(Conexao,objOcorrencia,empMaster);
            grdPessoa.DataSource = objPessoa.Listar();
        }

#endregion

        private void btnLogo_Click(object sender, EventArgs e)
        {
            OpenFileDialog oFile = new OpenFileDialog();

            oFile.Multiselect = false;
            oFile.Title = "Selecionar Fotos";
            oFile.InitialDirectory = "D:" + @EmcResources.LogoDiretory("EMCInd");
            //oFile.InitialDirectory = "c:\\";
            oFile.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";
            oFile.FilterIndex = 2;
            oFile.RestoreDirectory = true;

            if (oFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (oFile.FileName != null)
                    {
                        // Caminho do seu arquivo original, que foi selecionado pelo usuário
                        string imagemOriginal = oFile.FileName;
                        // Obtém o caminho para onde você quer copiar a imagem
                        // "C:\imagemBD\Hamburguer.jpg
                        string nomeArquivo = "D:" + EmcResources.LogoDiretory("EMCInd") + "LgEmp" + txtIdPessoa.Text.Trim() + ".jpg";
                        //string imagemDestino = Path.Combine(nomeArquivo, Path.GetFileName(imagemOriginal));
                        // Faz a cópia do arquivo

                        //verifica se o logo já existe armazenado
                        if (File.Exists(nomeArquivo))
                        {
                            DialogResult result = MessageBox.Show("Logo já existe, deseja substituir?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                File.Delete(nomeArquivo);
                                File.Copy(imagemOriginal, nomeArquivo);
                            }
                        }
                        else
                        {
                            File.Copy(imagemOriginal, nomeArquivo);
                        }


                        //Exibe arquivo selecionado
                        if ((txtImagem.Text = nomeArquivo) != null)
                        {
                            pctLogo.ImageLocation = txtImagem.Text;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

    }
}
