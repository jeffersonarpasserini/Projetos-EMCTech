using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastroRN;
using EMCImobRN;
using EMCCadastroModel;
using EMCSecurity;
using EMCSecurityModel;
using FastReport;
using System.Collections;
using EMCCadastro;
using EMCImobModel;

namespace EMCImob.Relatorios
{
    public partial class relImovel : EMCLibrary.tplRelatorio
    {
        private const string nomeFormulario = "relImovel";
        private const string nomeAplicativo = "EMCImob";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia = new Ocorrencia();


        public relImovel(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }

        #region "Configurações do Form"

        private void relImovel_Load(object sender, EventArgs e)
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

            //chama método para inicializar os campos do formulário
            this.LimpaCampos();
        }

        #endregion

        #region "Botões Overrides"

        public override void btnRelatorio_Click(object sender, EventArgs e)
        {
            if (verificaSeguranca(EmcResources.operacaoSeguranca.impressao) == false)
            {
                MessageBox.Show("Operação não permitida para o usuário! Procure o administrador do sistema.", "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (cboSelecionar.SelectedIndex == 0)
                listaImovelSimplificado();
            else if (cboSelecionar.SelectedIndex == 1)
                listaProprietario();
            else if (cboSelecionar.SelectedIndex == 2)
                listaImovelCompleto();
        }

        private void listaImovelCompleto()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ImovelRN oBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (cboTipoImovel.SelectedIndex >= 0)
                {
                    this.dstImovel.Tables["Proprietario"].Clear();
                    this.dstImovel.Tables["Comodo"].Clear();
                    this.dstImovel.Tables["MyTable"].Clear();

                    this.dstImovel.Tables["MyTable"].Load(oBLL.ListaImovelCompleto(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());

                    this.dstImovel.Tables["Proprietario"].Load(oBLL.ListaProprietario(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());

                    this.dstImovel.Tables["Comodo"].Load(oBLL.ListaComodo(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());
                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstImovel.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptCompleto.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptCompleto.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaImovelSimplificado()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ImovelRN oBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (cboTipoImovel.SelectedIndex >= 0)
                {

                    this.dstImovel.Tables["Proprietario"].Clear();
                    this.dstImovel.Tables["Comodo"].Clear();
                    this.dstImovel.Tables["MyTable"].Clear();
                    this.dstImovel.Tables["MyTable"].Load(oBLL.ListaImovelSimplificado(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());

                    this.dstImovel.Tables["Proprietario"].Load(oBLL.ListaProprietario(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());





                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstImovel.Tables["MyTable"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptSimplificado.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptSimplificado.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void listaProprietario()
        {
            try
            {
                Empresa oEmpresa = new Empresa();
                oEmpresa.idEmpresa = codempresa;
                EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
                oEmpresa = oEmpresaRN.ObterPor(oEmpresa);

                //alimenta dataset do rpt com dados da consulta
                ImovelRN oBLL = new ImovelRN(Conexao, objOcorrencia, codempresa);

                //Montando Consulta SQL para o relatório                    

                if (cboTipoImovel.SelectedIndex >= 0)
                {
                    this.dstProprietario.Tables["ImovelProprietario"].Clear();
                    this.dstProprietario.Tables["Imovel"].Clear();
                    this.dstProprietario.Tables["Imovel"].Load(oBLL.ListaImovelCompleto(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());

                    this.dstProprietario.Tables["ImovelProprietario"].Load(oBLL.ListaImovelProprietario(EmcResources.cInt(cboTipoImovel.SelectedValue.ToString()),
                                                                           chkTipoImovel.Checked,
                                                                           EmcResources.cInt(cboCarteiraImoveis.SelectedValue.ToString()),
                                                                           chkCarteiraImoveis.Checked,
                                                                           cboStatus.SelectedValue.ToString(),
                                                                           chkSituacao.Checked,
                                                                           EmcResources.cInt(txtIdPessoa.Text),
                                                                           chkProprietario.Checked,
                                                                           txtCodigoImovel.Text,
                                                                           EmcResources.cInt(txtIdEmpresa.Text)).CreateDataReader());


                    //verifica se encontrou registros a emitir
                    if (Convert.ToInt32(this.dstProprietario.Tables["ImovelProprietario"].Rows.Count) == 0)
                    {
                        MessageBox.Show("Não foram encontrados registros no Período Informado.", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    //mostrando o relatório na tela
                    rptProprietario.SetParameterValue("Empresa", oEmpresa.idEmpresa + "-" + oEmpresa.razaoSocial);
                    rptProprietario.Show();
                }
            }

            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        #endregion

        private void txtIdPessoa_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtIdPessoa.Text))
            {
                try
                {
                    Fornecedor oFornecedor = new Fornecedor();
                    FornecedorRN oFornecedorRN = new FornecedorRN(Conexao, objOcorrencia, codempresa);

                    oFornecedor.idPessoa = EmcResources.cInt(txtIdPessoa.Text);
                    oFornecedor.codEmpresa = empMaster;

                    oFornecedor = oFornecedorRN.ObterPor(oFornecedor);

                    txtPessoa.Text = oFornecedor.pessoa.nome;

                    if (txtIdPessoa == null)
                    {

                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
                MessageBox.Show("Proprietário não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                
        }
        private void btnPessoa_Click(object sender, EventArgs e)
        {
            psqFornecedor ofrm = new psqFornecedor(usuario.ToString(), login.ToString(), codempresa.ToString(), empMaster.ToString(), Conexao, objOcorrencia);
            ofrm.ShowDialog();

            if (EMCCadastro.retPesquisa.chaveinterna == 0)
            {
                // txtIdFornecedor.Text = "";
            }
            else
                txtIdPessoa.Text = EMCCadastro.retPesquisa.chaveinterna.ToString();

            txtIdPessoa.Focus();
            SendKeys.Send("{TAB}");
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
            if (!String.IsNullOrEmpty(txtCodigoImovel.Text))
            {
                try
                {   
                    ImovelRN oImovelRN = new ImovelRN(Conexao, objOcorrencia, empMaster);
                    Imovel oImovel = new Imovel();

                    Empresa oEmpresa = new Empresa();
                    EmpresaRN oEmpresaRN = new EmpresaRN(Conexao, objOcorrencia, empMaster);
                    oEmpresa.idEmpresa = empMaster;
                    oImovel.empresa = oEmpresa;

                    oImovel.codigoImovel = txtCodigoImovel.Text;
                    oImovel.empresa.idEmpresa = empMaster;
                    oImovel = oImovelRN.ObterPor(oImovel);

                    //txtImovel.Text = oImovel.tipoImovel.descricao;

                    if (!String.IsNullOrEmpty(oImovel.tipoImovel.descricao))
                    {
                        txtImovel.Text = oImovel.tipoImovel.descricao;
                        txtImovel.Focus();
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro Pesquisa : " + erro.Message);
                }
            }
            else
            {
                MessageBox.Show("Imovel não encontrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region "Métodos Overrides"

        public override void LimpaCampos()
        {
            //limpa os campos do formulário
            base.LimpaCampos();

            //inicializa combo de ordenação

            TipoImovelRN oTipoImovelRN = new TipoImovelRN(Conexao, objOcorrencia, codempresa);
            cboTipoImovel.DataSource = oTipoImovelRN.ListaTipoImovel();
            cboTipoImovel.ValueMember = "idtipoimovel";
            cboTipoImovel.DisplayMember = "descricao";

            CarteiraImoveisRN oCarteiraImoveisRN = new CarteiraImoveisRN(Conexao, objOcorrencia, codempresa);
            cboCarteiraImoveis.DataSource = oCarteiraImoveisRN.ListaCarteiraImoveis();
            cboCarteiraImoveis.DisplayMember = "descricao";
            cboCarteiraImoveis.ValueMember = "idcarteiraimoveis";


            ArrayList arr = new ArrayList();
            arr.Add(new popCombo("LIBERADO", "A"));
            arr.Add(new popCombo("CONTRATO EM ANDAMENTO ", "L"));
            arr.Add(new popCombo("VENDIDO", "V"));
            arr.Add(new popCombo("INATIVO", "I"));
            cboStatus.DataSource = arr;
            cboStatus.DisplayMember = "nome";
            cboStatus.ValueMember = "valor";

            //Selecionar
            ArrayList arrOrd = new ArrayList();
            arrOrd.Add(new popCombo("RELATÓRIO SIMPLIFICADO", "1"));
            arrOrd.Add(new popCombo("PROPRIETÁRIO", "2"));
            arrOrd.Add(new popCombo("FICHA DO IMÓVEL", "3"));
            cboSelecionar.DataSource = arrOrd;
            cboSelecionar.DisplayMember = "nome";
            cboSelecionar.ValueMember = "valor";

        }

        #endregion

    }
}
