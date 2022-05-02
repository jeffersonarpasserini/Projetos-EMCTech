using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCFinanceiro.Pesquisa;
using EMCFinanceiroModel;
using EMCCadastroModel;
using EMCFinanceiroRN;
using EMCCadastroRN;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EMCCadastro;
using System.Collections;

namespace EMCFinanceiro
{
    public partial class frmEmissaoCheques : EMCLibrary.EMCForm
    {
        clsPrinter oImpressora = new clsPrinter();
        Empresa oEmpresa = new Empresa();

        string cidadeCheque = "";

        private Ocorrencia objOcorrencia = new Ocorrencia();
        private const string nomeFormulario = "frmPagarDocumento";
        private const string nomeAplicativo = "EMCFinanceiro";

        private bool flagInclusao = false;
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        ConectaBancoMySql Conexao;

        #region [Metodos para configuração do formulário]
        public frmEmissaoCheques()
        {
            InitializeComponent();
        }
        public frmEmissaoCheques(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql pConexao)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = pConexao;
            InitializeComponent();
        }
        private void frmEmissaoCheques_Load(object sender, EventArgs e)
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
            objOcorrencia.tabela = "chequeemitir";

            CtaBancaria oConta = new CtaBancaria();
            oConta.codEmpresa = codempresa;

            Formulario oFormulario = new Formulario();
            oFormulario.contaBancaria = oConta;
            //tipo cheque
            oFormulario.tipoFormulario = "1";

            //Carregamento de Combobox do formulário
            FormularioRN oFormRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
            cboFormulario.DataSource = oFormRN.ListaFormulario(oFormulario);
            cboFormulario.DisplayMember = "descricao";
            cboFormulario.ValueMember = "idformulario";

            //inicializa combo de ordenação
            ArrayList arPrinter = new ArrayList();
            arPrinter = oImpressora.installedPrinters();
            cboImpressora.DataSource = arPrinter;
            cboImpressora.DisplayMember = "nome";
            cboImpressora.ValueMember = "valor";

            cboImpressora.SelectedIndex = 0;

            EmpresaRN oEmpRN = new EmpresaRN(Conexao, objOcorrencia, codempresa);
            oEmpresa.idEmpresa = codempresa;

            oEmpresa = oEmpRN.ObterPor(oEmpresa);

            cidadeCheque = oEmpresa.cidade;
            

            CancelaOperacao();

            this.ActiveControl = cboFormulario;

        }
        #endregion

        #region "metodos para tratamento das informacoes*********************************************************************"
        private Boolean verificaChequeEmitir(ChequeEmitir oCheque)
        {
            return true;
        }
        private void montaReceberFormulario()
        {

            
        }
        private void montaTela(Formulario oFormulario)
        {
            objOcorrencia.chaveidentificacao = oFormulario.idFormulario.ToString();

        }
        public override void AtivaEdicao()
        {
            base.AtivaEdicao();

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
        public override void AtivaInsercao()
        {
            //base.AtivaInsercao();
            //LimpaCampos();

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

            try
            {
                

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ReceberFormulario: " + erro.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
               

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.SalvaObjeto();
        }
        public override void AtualizaObjeto()
        {
            try
            {
               
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message + " " + erro.StackTrace);
            }
            base.AtualizaObjeto();
        }
        public override void ExcluiObjeto()
        {
            try
            {

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            base.ExcluiObjeto();
        }
        public override void ImprimeObjeto()
        {
            base.ImprimeObjeto();

            int numeroCheque = EmcResources.cInt(txtNroDocumento.Text);
            try
            {
                Formulario oFormulario = new Formulario();
                oFormulario.idFormulario = EmcResources.cInt(cboFormulario.SelectedValue.ToString());

                FormularioRN oFomRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
                oFormulario = oFomRN.ObterPor(oFormulario);

                //monta uma lista de cheques
                foreach (DataGridViewRow oRow in grdCheque.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                    ch1 = (DataGridViewCheckBoxCell)oRow.Cells[0];
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        oRow.Cells["nrocheque"].Value = String.Format("{0:0000000}", numeroCheque.ToString());
                        oRow.Cells["idformulario"].Value = EmcResources.cInt(cboFormulario.SelectedValue.ToString()).ToString();

                        ChequeEmitir oChequeEmitir = new ChequeEmitir();
                        oChequeEmitir.dataCheque = Convert.ToDateTime(oRow.Cells["datacheque"].Value.ToString());
                        oChequeEmitir.preDatado = oRow.Cells["predatado"].Value.ToString();

                        if (oChequeEmitir.preDatado == "S")
                            oChequeEmitir.dataPreDatado = Convert.ToDateTime(oRow.Cells["datapredatado"].Value.ToString());


                        oChequeEmitir.empresa = oEmpresa;

                        oChequeEmitir.idChequeEmitir = EmcResources.cInt(oRow.Cells["idchequeemitir"].Value.ToString());

                        oChequeEmitir.idMovimentoBancario = EmcResources.cInt(oRow.Cells["idmovimentobancario"].Value.ToString());

                        oChequeEmitir.nominal = oRow.Cells["nominal"].Value.ToString();

                        oChequeEmitir.valorCheque = EmcResources.cCur(oRow.Cells["valorcheque"].Value.ToString());

                        CtaBancaria oCtaBancaria = new CtaBancaria();
                        oCtaBancaria.idCtaBancaria = EmcResources.cInt(oRow.Cells["idctabancaria"].Value.ToString());
                        oCtaBancaria.codEmpresa = EmcResources.cInt(oRow.Cells["ctabancaria_idempresa"].Value.ToString());

                        oChequeEmitir.contaBancaria = oCtaBancaria;

                        this.imprimeFormularioPadrao(oFormulario, oChequeEmitir);

                        numeroCheque++;

                        txtNroDocumento.Text = numeroCheque.ToString();
                    }

                }

                //confirma se os cheques foram emitidos corretamente se sim grava senão cancela os números
                if (MessageBox.Show("Cheque(s) foram emitidos corretamente ?", "Emissão de Cheques", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    /*
                     * Gravar numero do cheque emitido no controle de formulário
                     * Atualizar tabela chequeemitido
                     */

                    ChequeEmitirRN oChequeRN = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);
                    //monta uma lista de cheques
                    foreach (DataGridViewRow oRow in grdCheque.Rows)
                    {
                        DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();

                        ch1 = (DataGridViewCheckBoxCell)oRow.Cells[0];
                        if (Convert.ToBoolean(ch1.Value.ToString()))
                        {
                            ChequeEmitir oCheque = new ChequeEmitir();
                            ChequeEmitirRN oChRN = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);

                            oCheque.idChequeEmitir = EmcResources.cInt(oRow.Cells["idchequeemitir"].Value.ToString());
                            oCheque = oChequeRN.ObterPor(oCheque);

                            oCheque.nroCheque = oRow.Cells["nrocheque"].Value.ToString();
                            oCheque.formulario = oFormulario;

                            oChRN.emiteCheque(oCheque);

                        }
                    }
                }
                else
                {
                    //se não foram emitidos corretamente pergunta se houve perda de formulario e se
                    //deseja cancelar os numeros emitidos
                    if (MessageBox.Show("Houve perda de formulário, deseja cancelar os mesmos ?", "Emissão de Cheques", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                       
                    }
                    else
                    {
                        cboFormulario.Focus();
                        SendKeys.Send("{TAB}");
                    }
                }

                AtualizaGrid(oFormulario);

            }
            catch (Exception oErro)
            {
                MessageBox.Show("Erro : " + oErro.Message, "EMC", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        #region [Metodos Buttons, Texts]
        private void cboFormulario_Validating(object sender, CancelEventArgs e)
        {
            if (cboFormulario.SelectedIndex == -1)
            {
                //não selecionado o formulario não faz nada
            }
            else
            {

                Formulario oFormulario = new Formulario();
                oFormulario.idFormulario = EmcResources.cInt(cboFormulario.SelectedValue.ToString());

                FormularioRN oFormRN = new FormularioRN(Conexao, objOcorrencia, codempresa);
                oFormulario = oFormRN.ObterPor(oFormulario);

                txtIdCtaBancaria.Text = oFormulario.contaBancaria.idCtaBancaria.ToString();

                txtContaBancaria.Text = oFormulario.contaBancaria.descricao;

                txtNroDocumento.Text = String.Format("{0:0000000}", oFormulario.nroAtual.ToString());

                AtualizaGrid(oFormulario);             
            }
        }
        #endregion

        #region [metodos para controle da grid - grdFaturaParcelas]
        public void AtualizaGrid(Formulario oFormulario)
        {

            CtaBancaria oConta = new CtaBancaria();
            oConta = oFormulario.contaBancaria;

            ChequeEmitirRN oChRN = new ChequeEmitirRN(Conexao, objOcorrencia, codempresa);

            grdCheque.DataSource = oChRN.ListaChequeEmitir(oConta);

            foreach (DataGridViewRow oRow in grdCheque.Rows)
            {
                oRow.Cells[0].Value = false;
            }


        }
        #endregion

        #region "[Impressão Cheques (Private)]"

        private void imprimeFormularioPadrao(Formulario oFormulario, ChequeEmitir oCheque)
        {
            string printerName = cboImpressora.Text;

            // --> calculando a quantidade de caracteres da linha (com base na linha da data da emissão)
            string sAux="";

            //--> seta a impressora para oitavos
            oImpressora.SendStringToPrinter(printerName, oImpressora.printerOitavos, 0);
            

            //--> inicializando a impressora
            //verificando se imprime o cheque descompactado
            if (oFormulario.layoutCheque.chequeCompacta == "N")
            {
                //descompactando a impressora
                oImpressora.SendStringToPrinter(printerName, oImpressora.PrinterDescompactada, 0);
            }
            else
            {
                //compactando a impressora
                oImpressora.SendStringToPrinter(printerName, oImpressora.printerCompactada, 0);
            }

            //--> imprimindo o valor

            //verifica se valor imprime compactado
            if (oFormulario.layoutCheque.valorCompacta=="S")
                sAux+=oImpressora.printerCompactada;
            else
                sAux+=oImpressora.PrinterDescompactada;


            //seta a margem para o valor do cheque
            sAux = EmcResources.Space(oFormulario.layoutCheque.margemValor);
            //seta impressão do valor
            sAux += EmcResources.FormatText(oCheque.valorCheque.ToString(),"###,###,##0.00",oFormulario.layoutCheque.espacoValor, EmcResources.eAlign.Direita).Replace(" ", "*");

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoValor);
            
            //se imprimir o valor descompactado e o cheque estava compactado, compacta novamente
            if (oFormulario.layoutCheque.valorCompacta=="S" && oFormulario.layoutCheque.chequeCompacta=="N")
                oImpressora.SendStringToPrinter(printerName, oImpressora.PrinterDescompactada,0);
            else if (oFormulario.layoutCheque.valorCompacta=="N" && oFormulario.layoutCheque.chequeCompacta=="S")
                oImpressora.SendStringToPrinter(printerName, oImpressora.printerCompactada,0);

            //'montando o extenso do cheque
            clsExtenso oExtenso = new clsExtenso();
            oExtenso.SetNumero(EmcResources.cCur(oCheque.valorCheque.ToString()));
            string sExtenso = oExtenso.ToString().ToUpper();

            int tamLinha1 = 0;
            if (sExtenso.Length < oFormulario.layoutCheque.espacoExtenso1)
                tamLinha1 = sExtenso.Length;
            else
                tamLinha1 = oFormulario.layoutCheque.espacoExtenso1;

            //Imprimindo linha 1 do extenso com margem
            sAux = EmcResources.Space(oFormulario.layoutCheque.margemExtenso1);
            if (tamLinha1 >= oFormulario.layoutCheque.espacoExtenso1)
                sAux += sExtenso.Substring(0, tamLinha1);
            else
            {
                sAux += sExtenso.Substring(0, tamLinha1);
                sAux += EmcResources.Space((oFormulario.layoutCheque.espacoExtenso1 - tamLinha1)).Replace(" ", "*");
            }

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoExtenso1);

            //Imprimindo linha 2 do extenso com margem
            if (sExtenso.Length > tamLinha1)
            {
                int tamLinha2 = sExtenso.PadLeft(oFormulario.layoutCheque.espacoExtenso1 + 1).Length;

                sAux = EmcResources.Space(oFormulario.layoutCheque.margemExtenso2);
                sAux += sExtenso.PadLeft(oFormulario.layoutCheque.espacoExtenso1 + 1);
                if ( tamLinha2 < oFormulario.layoutCheque.espacoExtenso2)
                    sAux += EmcResources.Space((oFormulario.layoutCheque.espacoExtenso2 - tamLinha2)).Replace(" ", "*");

            }
            else
                sAux = EmcResources.Space(oFormulario.layoutCheque.espacoExtenso2).Replace(" ", "*");

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoExtenso2);



            //--> imprimindo o portador do cheque
            sAux = EmcResources.Space(oFormulario.layoutCheque.margemNominal);
            sAux += EmcResources.FormatText(EmcResources.RemoveChars(oCheque.nominal), "", oFormulario.layoutCheque.espacoNominal, EmcResources.eAlign.Esquerda);

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoNominal);

            //--> imprime emissão/documento
            DateTime vDtaEmissao = Convert.ToDateTime(oCheque.dataCheque.ToString());
            sAux = EmcResources.Space(oFormulario.layoutCheque.margemCidade);
            sAux += EmcResources.FormatText(cidadeCheque, "", oFormulario.layoutCheque.espacoCidade,false,EmcResources.eAlign.Esquerda);
            sAux += EmcResources.FormatText(vDtaEmissao.Day.ToString(),"##",oFormulario.layoutCheque.espacoDia,false,EmcResources.eAlign.Esquerda);
            sAux += EmcResources.FormatText(EmcResources.ExtensoMes(vDtaEmissao.Month,false),"",oFormulario.layoutCheque.espacoMes,false,EmcResources.eAlign.Esquerda);
            sAux += EmcResources.FormatText(vDtaEmissao.Year.ToString(),"",oFormulario.layoutCheque.espacoAno,false,EmcResources.eAlign.Esquerda);

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoCidade);


            //--> imprimindo a data do cheque pré-datado (na posição da quantidade de linhas -5)
            sAux = "";
            sAux = EmcResources.Space(oFormulario.layoutCheque.margemObservacao);
            sAux += EmcResources.FormatText("","",oFormulario.layoutCheque.espacoObservação,EmcResources.eAlign.Esquerda);

            if (oCheque.preDatado == "S") 
            {
                sAux += EmcResources.Space(oFormulario.layoutCheque.espacoPredatado);
                sAux += EmcResources.FormatText(oCheque.dataPreDatado.ToString(),"dd/MM/yyyy",oFormulario.layoutCheque.espacoPredatado,false,EmcResources.eAlign.Esquerda);
            }

            oImpressora.SendStringToPrinter(printerName, sAux, oFormulario.layoutCheque.saltoPreDatado);

            oImpressora.SendStringToPrinter(printerName, "", oFormulario.layoutCheque.saltoProximaFolha);

        }

        #endregion
    }
}
