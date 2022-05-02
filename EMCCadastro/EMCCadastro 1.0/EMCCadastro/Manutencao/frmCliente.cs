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
    public partial class frmCliente : EMCLibrary.EMCForm
    {
        private const string nomeFormulario = "frmCliente";
        private const string nomeAplicativo = "EMCCadastro";
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private int codPessoa = 0;
        ConectaBancoMySql Conexao;
        Ocorrencia objOcorrencia = new Ocorrencia();

        public frmCliente()
        {
            InitializeComponent();
        }

        public frmCliente(String idUsuario, String seqLogin, String idEmpresa, String empmaster, String idPessoa, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = EmcResources.cInt(empmaster);
            codPessoa = Convert.ToInt32(idPessoa);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmCliente_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "cliente";

            //carrega os estados para a combo a partir de um enum
            foreach (string s in Enum.GetNames(typeof(EmcResources.SimNao)))
            {
                cboAlertaAviso1.Items.Add(s);
                cboAlertaAviso2.Items.Add(s);
                cboContrICMS.Items.Add(s);
                cboRetemISS.Items.Add(s);
                cboMicroEmpresa.Items.Add(s);
                cboSPC.Items.Add(s);

                Cliente oCliente = new Cliente();
                oCliente.codEmpresa = empMaster;
                oCliente.idPessoa = codPessoa;

                ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                oCliente = oClienteRN.ObterPor(oCliente);
               
                if (oCliente.idPessoa == null || oCliente.idPessoa == 0)
                {
                    AtivaInsercao();
                }
                else
                {
                    AtivaEdicao();
                    montaTela(oCliente);
                    AtualizaGridRef();
                    AtualizaGridAut();
                }
            }
            

        }


#region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaCliente(Cliente oCliente)
        {
            ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
            try
            {
                oClienteRN.VerificaDados(oCliente);
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "Erro", MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
                return false;
            }
        }
        
        private Cliente montaCliente()
        {
            Cliente oCliente = new Cliente();
            oCliente.codEmpresa = empMaster;
            oCliente.idPessoa = codPessoa;
            oCliente.observacao = txtObservacao.Text;
            oCliente.alerta1 = txtAviso1.Text;
            oCliente.alerta2 = txtAviso2.Text;
            oCliente.dtValidadeAlerta = Convert.ToDateTime(txtDtValidadeAviso.Text);
  
            if (cboSPC.Text == "Sim")
            {
                oCliente.spc = "S";
            }
            else
            {
                oCliente.spc = "N";
            }

            if (cboMicroEmpresa.Text == "Sim")
            {
                oCliente.microEmpresa = "S";
            }
            else
            {
                oCliente.microEmpresa = "N";
            }

            if (cboContrICMS.Text == "Sim")
            {
                oCliente.contrIcms = "S";
            }
            else
            {
                oCliente.contrIcms = "N";
            }

            if (cboRetemISS.Text == "Sim")
            {
                oCliente.retemISS = "S";
            }
            else
            {
                oCliente.retemISS = "N";
            }

            if (cboAlertaAviso1.Text == "Sim")
            {
                oCliente.avisoAlerta1 = "S";
            }
            else
            {
                oCliente.avisoAlerta1 = "N";
            }

            if (cboAlertaAviso2.Text == "Sim")
            {
                oCliente.avisoAlerta2 = "S";
            }
            else
            {
                oCliente.avisoAlerta2 = "N";
            }


            return oCliente;
        }
        
        private void montaTela(Cliente oCliente)
        {

            objOcorrencia.chaveidentificacao = oCliente.idPessoa.ToString();
            
            txtObservacao.Text = oCliente.observacao;
            txtAviso1.Text = oCliente.alerta1;
            txtAviso2.Text = oCliente.alerta2;
            txtDtValidadeAviso.Text = oCliente.dtValidadeAlerta.ToString();

            if (oCliente.spc == "S")
            {
                cboSPC.Text = "Sim";
            }
            else
            {
                cboSPC.Text = "Não";
            }

            if (oCliente.microEmpresa=="S")
            {
                cboMicroEmpresa.Text = "Sim";
            }
            else
            {
                cboMicroEmpresa.Text = "Não";
            }

            if (oCliente.contrIcms == "S")
            {
                cboContrICMS.Text = "Sim";
            }
            else
            {
                cboContrICMS.Text = "Não";
            }

            if (oCliente.retemISS=="S")
            {
                cboRetemISS.Text = "Sim";
            }
            else
            {
                cboRetemISS.Text = "Não";
            }

            if (oCliente.avisoAlerta1 =="S")
            {
                cboAlertaAviso1.Text = "Sim";
            }
            else
            {
                cboAlertaAviso1.Text = "Não";
            }

            if (oCliente.avisoAlerta2=="S")
            {
                cboAlertaAviso2.Text = "Sim";
            }
            else
            {
                cboAlertaAviso2.Text = "Não";
            }

        }
       
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();
            btnExcluiRef.Enabled = true;
            btnIncluiRef.Enabled = true;
            btnIncluiAut.Enabled = true;
            btnExcluiAut.Enabled = true;
            grdAutorizados.Enabled = true;
            grdReferencia.Enabled = true;
        }
       
        public override void AtivaInsercao()
        {
            base.AtivaInsercao();
            btnExcluiRef.Enabled = false;
            btnIncluiRef.Enabled = false;
            btnIncluiAut.Enabled = false;
            btnExcluiAut.Enabled = false;
            grdAutorizados.Enabled = false;
            grdReferencia.Enabled = false;
        }
       
        public override void AtualizaTela()
        {
            base.AtualizaTela();
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
       
        public override void CancelaOperacao()
        {
            base.CancelaOperacao();
            objOcorrencia.chaveidentificacao = "";
        }
        
        public override void BuscaObjeto()
        {
            base.BuscaObjeto();
            Cliente oCliente = new Cliente();
            oCliente = montaCliente();
            oCliente.codEmpresa = empMaster;
            oCliente.idPessoa = codPessoa;

            try
            {
                ClienteRN ClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                oCliente = ClienteRN.ObterPor(oCliente);
                    
                montaTela(oCliente);
                AtualizaGridRef();
                AtualizaGridAut();
                AtivaEdicao();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro Cliente: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                oCliente.dataCadastro = DateTime.Now;

                oCliente = montaCliente();

                if (verificaCliente(oCliente))
                {
                    oClienteRN.Salvar(oCliente);
                    AtualizaGridRef();
                    AtualizaGridAut();
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
                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                
                oCliente = montaCliente();
                

                if (verificaCliente(oCliente))
                {
                    
                    oClienteRN.Atualizar(oCliente);
                    
                    AtualizaGridRef();
                    AtualizaGridAut();
                    LimpaCampos();
                    MessageBox.Show("Cliente atualizado com sucesso");
                }
                else MessageBox.Show("Atualização cancelada");
                montaTela(oCliente);
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message+" "+erro.StackTrace);
            }
            base.AtualizaObjeto();
        }
        
        public override void ExcluiObjeto()
        {
            try
            {
                Cliente oCliente = new Cliente();
                ClienteRN oClienteRN = new ClienteRN(Conexao,objOcorrencia,codempresa);
                oCliente = montaCliente();

                if (verificaCliente(oCliente))
                {
                    DialogResult result = MessageBox.Show("Confirma exclusão do Cliente ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {

                        oClienteRN.Excluir(oCliente);
                        AtualizaGridRef();
                        AtualizaGridAut();
                        LimpaCampos();
                        MessageBox.Show("Cliente excluído!", "EMCtech");
                    }
                    else MessageBox.Show("Exclusão Cancelada!", "EMCtech");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
#endregion
#region "Tratamentos para buttons e texts**************************************************************************************"
        private void btnExcluiRef_Click(object sender, EventArgs e)
        {
            try
            {

                ReferenciaClienteRN oCliRefRN = new ReferenciaClienteRN(Conexao,objOcorrencia,codempresa);
                ReferenciaCliente oCli = new ReferenciaCliente();
                oCli.idReferencia = Convert.ToInt32(grdReferencia.Rows[grdReferencia.CurrentRow.Index].Cells["idreferencia"].Value.ToString());
                oCli.idPessoa = codPessoa;
                oCli.codEmpresa = empMaster;
                DialogResult result = MessageBox.Show("Confirma exclusão da Referencia : "  + grdReferencia.Rows[grdReferencia.CurrentRow.Index].Cells["nome"].Value.ToString() + " ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    oCli = oCliRefRN.ObterPor(oCli);
                    oCliRefRN.Excluir(oCli);
                    AtualizaGridRef();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnExcluiAut_Click(object sender, EventArgs e)
        {
            try
            {

                AutorizadosClienteRN oCliRefRN = new AutorizadosClienteRN(Conexao,objOcorrencia,codempresa);
                AutorizadosCliente oCli = new AutorizadosCliente();
                oCli.idAutorizado = Convert.ToInt32(grdAutorizados.Rows[grdAutorizados.CurrentRow.Index].Cells["idautorizado"].Value.ToString());
                oCli.idPessoa = codPessoa;
                oCli.codEmpresa = empMaster;
                DialogResult result = MessageBox.Show("Confirma exclusão do Autorizado : " + grdAutorizados.Rows[grdAutorizados.CurrentRow.Index].Cells["nome"].Value.ToString() + " ?", "EMCtech", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    oCli = oCliRefRN.ObterPor(oCli);
                    oCliRefRN.Excluir(oCli);
                    AtualizaGridAut();
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
        private void btnIncluiRef_Click(object sender, EventArgs e)
        {
            frmReferenciaCliente frmRefCli = new frmReferenciaCliente(usuario, login, codempresa.ToString(), empMaster.ToString(), codPessoa.ToString(), "0", Conexao);
            frmRefCli.ShowDialog();
            AtualizaGridRef();
        }
        private void btnIncluiAut_Click(object sender, EventArgs e)
        {
            frmAutorizadosCliente frmRefCli = new frmAutorizadosCliente(usuario, login, codempresa.ToString(), empMaster.ToString(), codPessoa.ToString(), "0",Conexao);
            frmRefCli.ShowDialog();
            AtualizaGridAut();
        }

        private void grdReferencia_DoubleClick(object sender, EventArgs e)
        {
            string refCliente = grdReferencia.Rows[grdReferencia.CurrentRow.Index].Cells["idreferencia"].Value.ToString();
            frmReferenciaCliente frmRefCli = new frmReferenciaCliente(usuario, login, codempresa.ToString(), empMaster.ToString(), codPessoa.ToString(), refCliente, Conexao);
            frmRefCli.ShowDialog();
            AtualizaGridRef();
        }

        private void grdAutorizados_DoubleClick(object sender, EventArgs e)
        {
            string refAutorizado = grdAutorizados.Rows[grdAutorizados.CurrentRow.Index].Cells["idautorizado"].Value.ToString();
            frmAutorizadosCliente frmRefCli = new frmAutorizadosCliente(usuario, login, codempresa.ToString(), empMaster.ToString(), codPessoa.ToString(), refAutorizado,Conexao);
            frmRefCli.ShowDialog();
            AtualizaGridAut();
        }
#endregion
#region "metodos da dbgrid*******************************************************************************************"

        //Atualizar grid de Referencias e grid de Autorizados
        public void AtualizaGridRef()
        {
            //carrega a grid com os ceps cadastrados
            ReferenciaClienteRN objClienteRef = new ReferenciaClienteRN(Conexao,objOcorrencia,codempresa);
            ReferenciaCliente oClienteRef = new ReferenciaCliente();
            oClienteRef.codEmpresa = empMaster;
            oClienteRef.idPessoa = codPessoa;
          
            grdReferencia.DataSource = objClienteRef.ListaReferenciaCliente(oClienteRef);
        }

        protected void AtualizaGridAut()
        {
            //carrega a grid com os ceps cadastrados
            AutorizadosClienteRN objClienteAut = new AutorizadosClienteRN(Conexao,objOcorrencia,codempresa);
            AutorizadosCliente oClienteAut = new AutorizadosCliente();
            oClienteAut.codEmpresa = empMaster;
            oClienteAut.idPessoa = codPessoa;

            grdAutorizados.DataSource = objClienteAut.ListaAutorizadosCliente(oClienteAut);
        }


#endregion

        private void btnRelatorio_Click_1(object sender, EventArgs e)
        {

        }

 


    }
}
