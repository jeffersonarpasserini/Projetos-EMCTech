using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCSecurity;
using EMCSecurityModel;
using System.Collections;

namespace EMCCadastro
{
    public partial class frmEmpresa : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmEmpresa";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private Pessoa objPessoa = new Pessoa();
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        #region "Configurações do Form"

        public frmEmpresa(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        public frmEmpresa()
        {
            InitializeComponent();
        }

        private void frmEmpresa_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "empresa";

            //inicializa combo de ordenação
            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("Matriz", "M"));
            arr.Add(new popCombo("Filial", "F"));
            cboFilialMatriz.DataSource = arr;
            cboFilialMatriz.DisplayMember = "nome";
            cboFilialMatriz.ValueMember = "valor";

            GrupoEmpresa oGrp = new GrupoEmpresa();
            GrupoEmpresaRN oGrpRN = new GrupoEmpresaRN(Conexao, objOcorrencia,codempresa);
            cboGrupoEmpresa.DataSource = oGrpRN.ListaGrupoEmpresa(oGrp);
            cboGrupoEmpresa.DisplayMember = "nomegrupoempresa";
            cboGrupoEmpresa.ValueMember = "idgrupoempresa";


            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.Estados)))
            cboEstado.Items.Add(s);
            AtualizaGrid();
           
            this.ActiveControl = txtidEmpresa;
            CancelaOperacao();

        }

        #endregion

        #region "metodos para tratamento das informacoes"

        public void AtualizaLogo()
        {
            //if (txtLogo.Text.Trim().Length > 0)
            //{
            pctLogo.ImageLocation = txtLogo.Text;

            //}
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
            txtEmpMaster.Enabled = false;
            cboGrupoEmpresa.Enabled = false;
            txtidEmpresa.Enabled = false;
            
        }

        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            txtEmpMaster.Enabled = true;
            cboGrupoEmpresa.Enabled = true;
        }

        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
            txtidEmpresa.Enabled = true;
            txtidEmpresa.ReadOnly = false;
            txtidEmpresa.Focus();
            
        }

        public override void AtualizaTela()
        {
        }

        public void BuscaEmpMaster()
        {
            if (txtEmpMaster.Text.Trim().Length > 0)
            {
                try
                {

                    Empresa oEmpresa = new Empresa();
                    EmpresaRN empresaBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);
                    oEmpresa = empresaBLL.BuscaEmpMaster(Convert.ToInt32(txtEmpMaster.Text));
                    txtRazaoEmpMaster.Text = oEmpresa.razaoSocial;
                }
                catch (Exception oErro)
                {
                    MessageBox.Show("Erro Empresa Master : " + oErro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        public override void BuscaObjeto()
        {
            if (!String.IsNullOrEmpty(txtidEmpresa.Text))
            {
                Empresa oEmpresa = new Empresa();
                try
                {

                    EmpresaRN empresaBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);
                    oEmpresa.idEmpresa = Convert.ToInt32(txtidEmpresa.Text);
                    oEmpresa = empresaBLL.ObterPor(oEmpresa);
                    objPessoa = oEmpresa.pessoa;

                        if (oEmpresa.idEmpresa == 0)
                        {
                            DialogResult result = MessageBox.Show("Empresa não Cadastrada, deseja incluir?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                AtivaInsercao();
                                
                            }
                            else
                            {
                                CancelaOperacao();
                            }
                        }
                        else
                        {
                            txtEmpMaster.Text = Convert.ToString(oEmpresa.empMaster.idEmpresa);
                            txtRazaoEmpMaster.Text = oEmpresa.empMaster.razaoSocial;
                            txtCNPJCPF.Text = oEmpresa.cnpjcpf;
                            txtInscrEstadual.Text = oEmpresa.inscrEstadual;
                            txtInscrMunicipal.Text = oEmpresa.inscrMunicipal;
                            txtRazaoSocial.Text = oEmpresa.razaoSocial;
                            txtNomeFantasia.Text = oEmpresa.nomeFantasia;
                            txtEndereco.Text = oEmpresa.endereco;
                            txtNumero.Text = oEmpresa.numero;
                            txtBairro.Text = oEmpresa.bairro;
                            txtComplemento.Text = oEmpresa.complemento;
                            txtCidade.Text = oEmpresa.cidade;
                            cboEstado.Text = oEmpresa.estado;
                            txtidCep.Text = oEmpresa.cep.idCep;
                            txtTelefone.Text = oEmpresa.telefone;
                            txtLogo.Text = oEmpresa.logo;
                            cboGrupoEmpresa.SelectedValue = oEmpresa.grupoEmpresa.idGrupoEmpresa;
                            cboFilialMatriz.SelectedValue = oEmpresa.matrizFilial;

                            txtIdEmpresaMatriz.Text = oEmpresa.matriz.idEmpresa.ToString();
                            BuscaMatriz();

                            //txtNomeEmpresaMatriz.Text = oEmpresa.matriz.razaoSocial;

                            AtualizaLogo();
                            AtivaEdicao();

                            if (cboFilialMatriz.SelectedValue.ToString() == "F")
                                cboGrupoEmpresa.Enabled = false;
                            else
                                cboGrupoEmpresa.Enabled = false;


                            objOcorrencia.chaveidentificacao = oEmpresa.idEmpresa.ToString();
                        }
                    }

                catch (Exception erro)
                {
                    MessageBox.Show("Erro Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtidEmpresa.Enabled = true;
                txtidEmpresa.Focus();

            }
            //AtualizaGrid();
        }
       
        public override void Ocorrencia()
        {
            base.Ocorrencia();
            frmOcorrencia ofrm = new frmOcorrencia(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();
        }

        public override void LimpaCampos()
        {
            base.LimpaCampos();
            txtidEmpresa.Enabled = true;
            txtidEmpresa.Focus();
            objOcorrencia.chaveidentificacao = "";
        }

        public override void SalvaObjeto()
        {
            try
            {
                Cep oCep = new Cep(txtidCep.Text, "", "", "");
                Empresa oEmpMaster = new Empresa();
                EmpresaRN oEmpMasterBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);

                if (txtEmpMaster.Text.Trim().Length > 0)
                {
                    oEmpMaster = oEmpMasterBLL.BuscaEmpMaster(Convert.ToInt32(txtEmpMaster.Text.Trim()));
                }
                else
                    oEmpMaster.idEmpresa = Convert.ToInt32(txtidEmpresa.Text); //A PROPRIA EMPRESA É MASTER

                Pessoa oPessoa = new Pessoa();
                oPessoa.codEmpresa = oEmpMaster.idEmpresa;
                oPessoa.nome = txtRazaoSocial.Text;
                oPessoa.nomeFantasia = txtNomeFantasia.Text;
                oPessoa.nroRG = "";
                oPessoa.cnpjCpf = txtCNPJCPF.Text;
                oPessoa.endereco = txtEndereco.Text;
                oPessoa.numero = txtNumero.Text;
                oPessoa.bairro = txtBairro.Text;
                oPessoa.complemento = txtComplemento.Text;
                oPessoa.cidade = txtCidade.Text;
                oPessoa.estado = cboEstado.Text;
                oPessoa.idCep = oCep.idCep;
                oPessoa.tipopessoa = "J";
                


                Empresa oEmpresa = new Empresa(Convert.ToInt32(txtidEmpresa.Text), oEmpMaster, txtRazaoSocial.Text, txtNomeFantasia.Text, txtCNPJCPF.Text,
                                               txtInscrEstadual.Text, txtInscrMunicipal.Text, txtEndereco.Text, txtNumero.Text,
                                               txtBairro.Text, txtComplemento.Text, txtCidade.Text, oCep, cboEstado.Text, txtLogo.Text,
                                               txtTelefone.Text, oPessoa);

                GrupoEmpresa oGrupo = new GrupoEmpresa();
                oGrupo.idGrupoEmpresa = EmcResources.cInt(cboGrupoEmpresa.SelectedValue.ToString());
                oEmpresa.grupoEmpresa = oGrupo;

                Empresa oMatriz = new Empresa();
                if (EmcResources.cInt(txtIdEmpresaMatriz.Text) > 0)
                {
                    oMatriz.idEmpresa = EmcResources.cInt(txtIdEmpresaMatriz.Text);
                }
                else
                    oMatriz.idEmpresa = 0;

                oEmpresa.matriz = oMatriz;
                oEmpresa.matrizFilial = cboFilialMatriz.SelectedValue.ToString();


                EmpresaRN oEmpresaBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);
                oEmpresaBLL.Salvar(oEmpresa);
                AtualizaLogo();

                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.SalvaObjeto();
            AtualizaGrid();

        }

        public override void AtualizaObjeto()
        {
            try
            {
                Cep oCep = new Cep(txtidCep.Text, "", "", "");
                Empresa oEmpMaster = new Empresa();
                EmpresaRN oEmpMasterBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);

                oEmpMaster = oEmpMasterBLL.BuscaEmpMaster(Convert.ToInt32(txtEmpMaster.Text.Trim()));


                Empresa oEmpresa = new Empresa(Convert.ToInt32(txtidEmpresa.Text), oEmpMaster, txtRazaoSocial.Text, txtNomeFantasia.Text, txtCNPJCPF.Text,
                                               txtInscrEstadual.Text, txtInscrMunicipal.Text, txtEndereco.Text, txtNumero.Text,
                                               txtBairro.Text, txtComplemento.Text, txtCidade.Text, oCep, cboEstado.Text, txtLogo.Text,
                                               txtTelefone.Text, objPessoa);
                
                GrupoEmpresa oGrupo = new GrupoEmpresa();
                oGrupo.idGrupoEmpresa = EmcResources.cInt(cboGrupoEmpresa.SelectedValue.ToString());
                oEmpresa.grupoEmpresa = oGrupo;

                Empresa oMatriz = new Empresa();
                oMatriz.idEmpresa = EmcResources.cInt(txtIdEmpresaMatriz.Text);
                oEmpresa.matriz = oMatriz;

                oEmpresa.matrizFilial = cboFilialMatriz.SelectedValue.ToString();


                EmpresaRN oEmpresaBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);
                oEmpresaBLL.Atualizar(oEmpresa);
                AtualizaLogo();

                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           // base.AtualizaObjeto();
            AtualizaGrid();

        }

        public override void ExcluiObjeto()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = Convert.ToInt32(txtidEmpresa.Text);
                EmpresaRN oEmpresaBLL = new EmpresaRN(Conexao,objOcorrencia,codempresa);
                oEmpresaBLL.Excluir(oEmpresa);
                AtualizaLogo();

                LimpaCampos();
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Empresa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //base.ExcluiObjeto();
            AtualizaGrid();
        }

        public override void ImprimeObjeto()
        {
            try
            {
                //base.ImprimeObjeto();
                Relatorios.relEmpresa ofrm = new Relatorios.relEmpresa(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao);
                ofrm.ShowDialog();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro Empresa: " + e.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region "Text´s e Button´s

        private void BuscaMatriz()
        {
            try
            {

                Empresa oMat = new Empresa();
                EmpresaRN oMatRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
                oMat.idEmpresa = EmcResources.cInt(txtIdEmpresaMatriz.Text);

                oMat = oMatRN.ObterPor(oMat);

                txtNomeEmpresaMatriz.Text = oMat.razaoSocial;
            }
            catch (Exception erro)
            {
                MessageBox.Show("Matriz não encontrada : " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);

             }
        }
       
        private void txtIdEmpresaMatriz_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Empresa oMat = new Empresa();
                EmpresaRN oMatRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
                oMat.idEmpresa = EmcResources.cInt(txtIdEmpresaMatriz.Text);

                oMat = oMatRN.ObterPor(oMat);

                txtNomeEmpresaMatriz.Text = oMat.razaoSocial;

            }
            catch (Exception erro)
            {
                MessageBox.Show("Matriz não encontrada : "+erro.Message, "EMCtech", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cboFilialMatriz_Validating(object sender, CancelEventArgs e)
        {
            if (cboFilialMatriz.SelectedValue.ToString() == "F")
            {
                EmpresaRN oEmpRN = new EmpresaRN(Conexao, objOcorrencia,codempresa);
                Empresa oEmp = oEmpRN.BuscaMatriz(txtCNPJCPF.Text);

                if (oEmp.idEmpresa > 0)
                {
                    txtIdEmpresaMatriz.Text = oEmp.idEmpresa.ToString();
                    txtNomeEmpresaMatriz.Text = oEmp.razaoSocial;
                    cboGrupoEmpresa.SelectedValue = oEmp.grupoEmpresa.idGrupoEmpresa;
                    cboGrupoEmpresa.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Empresa Matriz não encontrada", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                
            }

        }

        private void txtCNPJCPF_Validating(object sender, CancelEventArgs e)
        {
            if (!EmcResources.validaCNPJCPF(txtCNPJCPF.Text))
            {
                MessageBox.Show("CNPJ ou CPF invalido");
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

        private void txtidEmpresa_Validating(object sender, CancelEventArgs e)
        {
            BuscaObjeto();
        }

        private void txtEmpMaster_Validating(object sender, CancelEventArgs e)
        {
            BuscaEmpMaster();
        }

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
                        string nomeArquivo = "D:" + EmcResources.LogoDiretory("EMCInd") + "LgEmp" + txtidEmpresa.Text.Trim() + ".jpg";
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
                        if ((txtLogo.Text = nomeArquivo) != null)
                        {
                            pctLogo.ImageLocation = txtLogo.Text;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        #endregion

        #region "metodos da dbgrid"

        private void grdEmpresa_DoubleClick(object sender, EventArgs e)
        {
            txtidEmpresa.Text = grdEmpresa.Rows[grdEmpresa.CurrentRow.Index].Cells["idEmpresa"].Value.ToString();
            txtidEmpresa.Focus();
            SendKeys.Send("{TAB}");
            AtivaEdicao();
            BuscaObjeto();
            

        }

        private void AtualizaGrid()
        {
            //carrega a grid com os ceps cadastrados
            EmpresaRN objEmpresa = new EmpresaRN(Conexao,objOcorrencia,codempresa);
            grdEmpresa.DataSource = objEmpresa.Lista();

        }
        #endregion

        private void txtidEmpresa_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

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
    }
}
