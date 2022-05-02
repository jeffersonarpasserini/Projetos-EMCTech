using EMCCadastro;
using EMCCadastroModel;
using EMCCadastroRN;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMCImob.Relatorios
{
    public partial class relExtratoContrato : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relExtratoContrato";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0; 
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();
         
        public relExtratoContrato(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
         
        private void relExtratoContrato_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "locacaocontrato";

            txtIdentificacaoContrato.Focus();

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();           
        }

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ValidaCampos() == false)
            {
                return;
            }
                listaExtrato();            
        }

        private void listaExtrato()
        {
            try 
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                LocacaoContratoRN oBLL = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);

                if (!String.IsNullOrEmpty(txtIdentificacaoContrato.Text) || String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
                {                     
                    this.dstExtratoContrato.Tables["LocacaoContrato"].Clear();
                    this.dstExtratoContrato.Tables["LocacaoContrato"].Load(oBLL.ListaExtratoContrato(txtIdentificacaoContrato.Text, 
                                                                                                     txtDataInicial.DateValue, 
                                                                                                     txtDataFinal.DateValue,
                                                                                                     EmcResources.cInt(txtIdLocatarioRepresentante.Text),
                                                                                                     txtCodigoImovel.Text).CreateDataReader());
 
                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstExtratoContrato.Tables["LocacaoContrato"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptExtrato.SetParameterValue("Periodo", txtDataInicial.Text + " a " + txtDataFinal.Text);
                    rptExtrato.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptExtrato.SetParameterValue("Endereco", oEmpresa.endereco + "," + oEmpresa.numero + " - " + oEmpresa.complemento);
                    rptExtrato.SetParameterValue("Cidade", oEmpresa.cidade + " - " + oEmpresa.estado + "  CEP " + oEmpresa.cep.idCep);
                    rptExtrato.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }        

        private void btnLocatario_Click(object sender, EventArgs e)
        {
            try
            {
                psqCliente ofrm = new psqCliente(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
                ofrm.ShowDialog();

                if (EMCCadastro.retPesquisa.chaveinterna == 0)
                    txtIdLocatarioRepresentante.Text = "";
                else
                    txtIdLocatarioRepresentante.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

                txtIdLocatarioRepresentante_Validating(null, null);
            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro Pesquisa : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtIdLocatarioRepresentante_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdLocatarioRepresentante.Text))
                {
                    ClienteRN oClienteRN = new ClienteRN(Conexao, objOcorrencia, empMaster);
                    Cliente oCliente = new Cliente();

                    oCliente.idPessoa = EmcResources.cInt(txtIdLocatarioRepresentante.Text);
                    oCliente.codEmpresa = empMaster;

                    oCliente = oClienteRN.ObterPor(oCliente);

                    if (EmcResources.cInt(oCliente.idPessoa.ToString()) == 0)
                    {
                        MessageBox.Show("Cliente não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        txtIdLocatarioRepresentante.Text = oCliente.idPessoa.ToString();
                        txtNomeLocatario.Text = oCliente.pessoa.nome;
                    }
                }               
            }
            catch (Exception oErro)
            {
                MessageBox.Show(oErro.Message);
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
                    txtCodigoImovel_Validating(null, null);
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
                if (!String.IsNullOrEmpty(txtCodigoImovel.Text))
                {
                    Imovel oImovel = new Imovel();
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = codempresa;

                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa = oEmpresa;

                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, codempresa);
                    oImovel = oImovelRN.ObterPor(oImovel);

                    if (oImovel.idImovel > 0)
                    {
                        txtIdImovel.Text = oImovel.idImovel.ToString();
                        txtImovel.Text = oImovel.descricao.ToString();
                        txtImovel.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Imovel não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }

        private void txtIdentificacaoContrato_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtIdentificacaoContrato.Text))
                {
                    LocacaoContrato oLocContrato = new LocacaoContrato();
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.idEmpresa = codempresa;                                  

                    oLocContrato.identificacaoContrato = txtIdentificacaoContrato.Text;
                    oLocContrato.idEmpresa = codempresa;

                    LocacaoContratoRN oLocContratoRN = new LocacaoContratoRN(Conexao, objOcorrencia, codempresa);
                    oLocContrato = oLocContratoRN.ObterPor(oLocContrato);

                    if (oLocContrato.idLocacaoContrato > 0)
                    {
                        txtIdLocacaoContrato.Text = oLocContrato.idLocacaoContrato.ToString();
                        txtIdentificacaoContrato.Text = oLocContrato.identificacaoContrato.ToString();
                        txtIdLocatarioRepresentante.Text = oLocContrato.locatarioRepresentante.pessoa.idPessoa.ToString();
                        txtNomeLocatario.Text = oLocContrato.locatarioRepresentante.pessoa.nome.ToString();
                        txtIdImovel.Text = oLocContrato.imovel.idImovel.ToString();
                        txtCodigoImovel.Text = oLocContrato.imovel.codigoImovel.ToString();
                        txtImovel.Text = oLocContrato.imovel.descricao.ToString();

                        txtDataInicial.Focus();                        
                    }
                    else
                    {
                        MessageBox.Show("Contrato não cadastrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);                       
                    }
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Pesquisa : " + erro.Message);
            }
        }
         
        private Boolean ValidaCampos()
        {
            if (String.IsNullOrEmpty(txtDataInicial.DateValue.ToString()))
            {
                MessageBox.Show("A Data Inicial deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataInicial.Focus();
                return false;                
            }

            if (String.IsNullOrEmpty(txtDataFinal.DateValue.ToString()))
            {
                MessageBox.Show("A Data Final deve ser informada.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataFinal.Focus();
                return false;
            }

            if (txtDataFinal.DateValue < txtDataInicial.DateValue)
            {
                MessageBox.Show("A Data Final deve ser Maior que a Data Inicial.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDataInicial.Focus();
                return false;
            }
            return true;
        }
        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();
            txtIdentificacaoContrato.Focus();            
        }
        private void relExtratoContrato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }        
    }
}
 