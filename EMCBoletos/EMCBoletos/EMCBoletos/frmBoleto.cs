using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCBoletosDAO;
using EMCBoletosModel;
using BoletoNet;
using EMCEmissorTitulos;
using System.IO;

namespace EMCBoletos
{
    public partial class frmBoletos : Form
    {
        Empresa oEmpresa = new Empresa();
        CtaBanco oConta = new CtaBanco();
        ContaBancaria oCta = new ContaBancaria();
        Cedente oCedente = new Cedente();
        Boletos boletos = new Boletos();

        public frmBoletos()
        {
            InitializeComponent();
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                List<TituloCobranca> lstTitulos = new List<TituloCobranca>();

                string tipoEmissao = "";
                int nroContaTitulo = 0;
                if (EmcResources.cInt(txtContratoFinal.Text) == 0 || String.IsNullOrEmpty(txtContratoFinal.Text))
                    txtContratoFinal.Text = txtContrato.Text;

                if (EmcResources.cInt(txtContratoFinal.Text) < EmcResources.cInt(txtContrato.Text))
                {
                    Exception oErro = new Exception("Nro Contrato Final é menor que inicial");
                    throw oErro;
                }

                if (cboTipoEmissao.SelectedItem.ToString().Trim() == "Emissão de Titulos")
                {
                    tipoEmissao = "E";
                    nroContaTitulo = 0;
                }
                else if (cboTipoEmissao.SelectedItem.ToString().Trim() == "Geração de Arquivo de Remessa")
                {
                    tipoEmissao = "G";
                    nroContaTitulo = EmcResources.cInt(cboContaBancaria.SelectedValue.ToString());
                }
                else
                {
                    tipoEmissao = "R";
                    nroContaTitulo = EmcResources.cInt(cboContaBancaria.SelectedValue.ToString());
                }

                titulosCobrancaDAO oBoletos = new titulosCobrancaDAO();
                lstTitulos = oBoletos.pesquisaTitulos(oEmpresa, EmcResources.cInt(txtContrato.Text), EmcResources.cInt(txtContratoFinal.Text), chkTodas.Checked, EmcResources.cInt(txtIdCliente.Text), Convert.ToDateTime(txtDataInicio.Text), Convert.ToDateTime(txtDataFinal.Text),tipoEmissao,nroContaTitulo);
                
                grdBoleto.Rows.Clear();

                foreach(TituloCobranca oTitulo in lstTitulos)
                {
                    grdBoleto.Rows.Add(false, oTitulo.nossoNUmero,oTitulo.idContrato, oTitulo.nroParcela, oTitulo.dtaVencimento, 
                                       oTitulo.vlrBoleto, oTitulo.sacadoRazaoSocial, oTitulo.sacadoCNPJ, oTitulo.dtaInicioPeriodo, 
                                       oTitulo.dtaFinalPeriodo,oTitulo.vlrAluguel,oTitulo.vlrCondominio, 
                                       oTitulo.vlrIptu, oTitulo.vlrAbono, oTitulo.vlrDescontoConcedido, 
                                       oTitulo.vlrOutros,oTitulo.idCliente,oTitulo.sacadoEndereco,oTitulo.sacadoNumero,
                                       oTitulo.sacadoBairro, oTitulo.sacadoCidade,oTitulo.sacadoEstado, oTitulo.sacadoCEP,
                                       oTitulo.idImovel,oTitulo.imovelEndereco,oTitulo.imovelNumero,oTitulo.imovelBairro,
                                       oTitulo.boletoMulta, oTitulo.boletoJurosDia );
                }

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message+ " - " + erro.StackTrace, "Erro", MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
        }

        private void btnGeraBoleto_Click(object sender, EventArgs e)
        {

            try
            {
                //Variavel que define como será o processo de emissão dos boletos (E - Emissão R - Reemissão ou G - Geração Arquivo Remessa)
                string tipoEmissao = "";

                if (cboTipoEmissao.SelectedItem.ToString().Trim() == "Reemissão de Titulos")
                {
                    tipoEmissao = "R";
                }
                else if (cboTipoEmissao.SelectedItem.ToString().Trim() == "Geração de Arquivo de Remessa")
                {
                    tipoEmissao = "G";
                }
                else
                    tipoEmissao = "E";


                //atribui informação da conta bancaria ao boleto.net
                CtaBancoDAO oContaDAO = new CtaBancoDAO();

                oConta.codEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                oConta.idCtaBancaria = Convert.ToInt32(cboContaBancaria.SelectedValue);
                oConta = oContaDAO.ObterPor(oConta);

                string nossoNumero = "";

                if (oConta.nroBanco=="237")
                    nossoNumero = String.Format("{0:00000000000}", Convert.ToInt32(oConta.nossoNumero));
                else if (oConta.nroBanco=="756")
                    nossoNumero = String.Format("{0:0000000}", Convert.ToInt32(oConta.nossoNumero));
                else if (oConta.nroBanco == "104")
                {
                    // X = 1 -Registrada 2- Sem Registro
                    // Y = 4- Cedente
                    nossoNumero = String.Format("{0:000000000000000}", Convert.ToInt64(oConta.nossoNumero));
                    
                }

                oCta.Agencia = oConta.nroAgencia;
                oCta.DigitoAgencia = oConta.digAgencia;
                oCta.Conta = oConta.nroConta;
                oCta.DigitoConta = oConta.digConta;

                //atribui informçãoes do cedente ao boleto.net

                if (oConta.empCNPJ != oConta.cedenteCnpj && !String.IsNullOrEmpty(oConta.cedenteCnpj))
                {
                    oCedente.CPFCNPJ = oConta.cedenteCnpj;
                    oCedente.ContaBancaria = oCta;
                    oCedente.Nome = oConta.cedenteRazao;
                }
                else
                {
                    oCedente.CPFCNPJ = oConta.empCNPJ;
                    oCedente.ContaBancaria = oCta;
                    oCedente.Nome = oConta.empRazaoSocial;
                }

                //if (oConta.nroBanco == "104" && oConta.empCNPJ == "09821134807")
                //{
                oCedente.Codigo = EmcResources.cInt(oConta.nroCedente.Substring(0,6));
                //}
                //else
                  //  oCedente.Codigo = EmcResources.cInt(oConta.nroCedente);

                oCedente.NumeroSequencial = oConta.seqArqRemessa;

                if (oConta.nroBanco == "756")
                {
                    if (EmcResources.cInt(oConta.digCedente) > 0)
                    {
                        oCedente.DigitoCedente = EmcResources.cInt(oConta.digCedente);
                    }
                    else
                        oCedente.DigitoCedente = -1;

                    if (oConta.digAgencia.Trim().Length == 0)
                        oCta.DigitoAgencia = "";
                }
                else if (oConta.nroBanco == "104")
                {
                    oCedente.DigitoCedente = Mod11Base9(oCedente.Codigo.ToString());

                    //oCedente.DigitoCedente = Mod11Base9(oConta.nroCedente.Trim());
                }
                else
                    oCedente.DigitoCedente = EmcResources.cInt(oConta.digCedente);

                //Cria uma Lista de Boletos
                List<BoletoBancario> lstBoletos = new List<BoletoBancario>();


                string nossoNumeroEmissao = "";
                //monta uma lista de parcelas - para emissão de boletos
                foreach (DataGridViewRow dataGridViewRow in grdBoleto.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];

                    //if (ch1.Value.Equals(ch1.TrueValue))
                    if (Convert.ToBoolean(ch1.Value.ToString()))
                    {
                        BoletoBancario bBancario = new BoletoBancario();

                        if (cboEnderecoSacado.Text == "Sim" || cboEnderecoSacado.Text=="")
                            bBancario.OcultarEnderecoSacado = false;
                        else
                            bBancario.OcultarEnderecoSacado = true;

                        if (cboFormatoCarne.Text == "Sim")
                            bBancario.FormatoCarne = true;
                        else
                            bBancario.FormatoCarne = false;

                        if (cboComprovante.Text == "Sim")
                            bBancario.MostrarComprovanteEntrega = true;
                        else
                            bBancario.MostrarComprovanteEntrega = false;

                        bBancario.CodigoBanco = short.Parse(oConta.nroBanco);

                        //monta sacado
                        Sacado oSacado = new Sacado();

                        Endereco oEndereco = new Endereco();
                        oEndereco.End = dataGridViewRow.Cells["sacadoendereco"].Value.ToString().Trim() + ", " + dataGridViewRow.Cells["sacadonumero"].Value.ToString().Trim();
                        oEndereco.Logradouro = dataGridViewRow.Cells["sacadoendereco"].Value.ToString();
                        oEndereco.Numero = dataGridViewRow.Cells["sacadonumero"].Value.ToString();
                        oEndereco.Bairro = dataGridViewRow.Cells["sacadobairro"].Value.ToString();
                        oEndereco.Complemento = "";
                        oEndereco.Cidade = dataGridViewRow.Cells["sacadocidade"].Value.ToString();
                        oEndereco.UF = dataGridViewRow.Cells["sacadoestado"].Value.ToString();
                        oEndereco.CEP = dataGridViewRow.Cells["sacadocep"].Value.ToString();


                        oSacado.CPFCNPJ = dataGridViewRow.Cells["sacadocpf"].Value.ToString();
                        oSacado.Endereco = oEndereco;
                        oSacado.Nome = dataGridViewRow.Cells["entraza"].Value.ToString();

                        //Montagem Bradesco
                        if (bBancario.CodigoBanco == short.Parse("237"))
                        {
                            //monta instruções do boleto
                            Instrucao_Bradesco item0a = new Instrucao_Bradesco();
                            item0a.Descricao = "APÓS O VENCIMENTO PAGAVEL SOMENTE NAS AGÊNCIAS DO BANCO BRADESCO";
                            
                            Instrucao_Bradesco item0 = new Instrucao_Bradesco();
                            item0.Descricao = "A QUITACAO DESTA PARCELA NAO PRESUME A INEXISTENCIA DE DEBITOS ANTERIORES";

                            Instrucao_Bradesco item1 = new Instrucao_Bradesco();
                            item1.Descricao = "Multa :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["multa"].Value.ToString()));

                            Instrucao_Bradesco item1A = new Instrucao_Bradesco();
                            item1A.Descricao = "Juros :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["jurosDia"].Value.ToString())) + " ao dia ";


                            Instrucao_Bradesco item2 = new Instrucao_Bradesco(9, 5);
                            item2.Descricao += " após " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";

                            Instrucao_Bradesco item3 = new Instrucao_Bradesco();
                            item3.Descricao = "Aluguel : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpavalo"].Value.ToString()));
                            item3.Descricao += " + Condominio : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpacond"].Value.ToString()));
                            item3.Descricao += " + IPTU : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaiptu"].Value.ToString()));
                            item3.Descricao += " - Abono : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaabon"].Value.ToString()));
                            item3.Descricao += " - Desconto Concedido : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpalcde"].Value.ToString()));
                            item3.Descricao += "  + Outros : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaoutr"].Value.ToString()));

                            Instrucao_Bradesco item4 = new Instrucao_Bradesco();
                            item4.Descricao = "Contrato : " + dataGridViewRow.Cells["efpnume"].Value.ToString() + " Parcela : " + dataGridViewRow.Cells["efpparc"].Value.ToString();

                            //monta boleto
                            Decimal vlrBoleto = Convert.ToDecimal(dataGridViewRow.Cells["efpvalo"].Value.ToString());
                            DateTime dtaVencimento = Convert.ToDateTime(dataGridViewRow.Cells["efpvenc"].Value.ToString());

                            if (tipoEmissao == "R" || tipoEmissao == "G")
                            {
                                nossoNumero = String.Format("{0:00000000000}", Convert.ToInt32(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Substring(2,11)));
                            }

                            Boleto b = new Boleto(dtaVencimento, vlrBoleto, "09", nossoNumero, oCedente);

                            b.NumeroDocumento = nossoNumero;

                            b.Instrucoes.Add(item0a);
                            b.Instrucoes.Add(item0);
                            b.Instrucoes.Add(item1);
                            b.Instrucoes.Add(item1A);
                            b.Instrucoes.Add(item2);
                            b.Instrucoes.Add(item3);
                            b.Instrucoes.Add(item4);

                            b.Sacado = oSacado;

                            bBancario.Boleto = b;
                            bBancario.Boleto.Valida();

                            lstBoletos.Add(bBancario);
                            boletos.Add(bBancario.Boleto);

                            if (tipoEmissao == "E")
                            {
                                nossoNumero = String.Format("{0:00000000000}", Convert.ToInt32(nossoNumero) + 1);
                                txtNossoNumero.Text = nossoNumero;
                            }
                            
                        }
                        //Montagem Caixa Economica Federal
                        else if (bBancario.CodigoBanco == short.Parse("104"))
                        {
                            //monta instruções do boleto
                            Instrucao_Caixa item0a = new Instrucao_Caixa();
                            item0a.Descricao = "APÓS O VENCIMENTO PAGAVEL SOMENTE NAS AGÊNCIAS DA CAIXA";

                            Instrucao_Caixa item0 = new Instrucao_Caixa();
                            item0.Descricao = "A QUITACAO DESTA PARCELA NAO PRESUME A INEXISTENCIA DE DEBITOS ANTERIORES";

                            Instrucao_Caixa item1 = new Instrucao_Caixa();
                            item1.Descricao = "Multa :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["multa"].Value.ToString()));

                            Instrucao_Caixa item1A = new Instrucao_Caixa();
                            item1A.Descricao = "Juros :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["jurosDia"].Value.ToString())) + " ao dia ";


                            //Instrucao_Caixa item2 = new Instrucao_Caixa(81, 5);
                            //item2.Descricao += " após " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";

                            Instrucao_Caixa item3 = new Instrucao_Caixa();
                            item3.Descricao = "Aluguel : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpavalo"].Value.ToString()));
                            item3.Descricao += " + Condominio : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpacond"].Value.ToString()));
                            item3.Descricao += " + IPTU : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaiptu"].Value.ToString()));
                            item3.Descricao += " - Abono : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaabon"].Value.ToString()));
                            item3.Descricao += " - Desconto Concedido : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpalcde"].Value.ToString()));
                            item3.Descricao += "  + Outros : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaoutr"].Value.ToString()));

                            Instrucao_Caixa item4 = new Instrucao_Caixa();
                            item4.Descricao = "Contrato : " + dataGridViewRow.Cells["efpnume"].Value.ToString() + " Parcela : " + dataGridViewRow.Cells["efpparc"].Value.ToString();

                            //monta boleto
                            Decimal vlrBoleto = Convert.ToDecimal(dataGridViewRow.Cells["efpvalo"].Value.ToString());
                            DateTime dtaVencimento = Convert.ToDateTime(dataGridViewRow.Cells["efpvenc"].Value.ToString());

                            nossoNumeroEmissao = "";
                            if (tipoEmissao == "R" || tipoEmissao == "G")
                            {
                                nossoNumeroEmissao = String.Format("{0:000000000000000}", Convert.ToInt64(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Substring(0, 17)));
                            }
                            else
                                nossoNumeroEmissao = "24" + nossoNumero;

                            Boleto b = new Boleto(dtaVencimento, vlrBoleto, "SR", nossoNumeroEmissao, oCedente);

                            b.NumeroDocumento = nossoNumeroEmissao;
                            b.QuantidadeMoeda = 0;


                            EspecieDocumento oEspdoc = new EspecieDocumento(756, "02");
                            b.EspecieDocumento = oEspdoc;

                            b.Instrucoes.Add(item0a);
                            b.Instrucoes.Add(item0);
                            b.Instrucoes.Add(item1);
                            b.Instrucoes.Add(item1A);
                            //b.Instrucoes.Add(item2);
                            b.Instrucoes.Add(item3);
                            b.Instrucoes.Add(item4);

                            b.Sacado = oSacado;
                            
                            
                            bBancario.Boleto = b;
                            bBancario.Boleto.Valida();

                            

                            lstBoletos.Add(bBancario);
                            boletos.Add(bBancario.Boleto);

                            if (tipoEmissao == "E")
                            {
                                nossoNumero = String.Format("{0:000000000000000}", Convert.ToInt64(nossoNumero) + 1);
                                txtNossoNumero.Text = nossoNumero;
                            }

                        }
                        //Montagem Credicitrus
                        else if (bBancario.CodigoBanco == short.Parse("756"))
                        {
                            //monta instruções do boleto
                            Instrucao_Sicoob item0a = new Instrucao_Sicoob();
                            item0a.Descricao = "APÓS O VENCIMENTO PAGAVEL SOMENTE NAS AGÊNCIAS DO BANCO CREDICITRUS";

                            Instrucao_Sicoob item0 = new Instrucao_Sicoob();
                            item0.Descricao = "A QUITACAO DESTA PARCELA NAO PRESUME A INEXISTENCIA DE DEBITOS ANTERIORES";

                            Instrucao_Sicoob item1 = new Instrucao_Sicoob();
                            item1.Descricao = "Multa :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["multa"].Value.ToString()));

                            Instrucao_Sicoob item1A = new Instrucao_Sicoob();
                            item1A.Descricao = "Juros :" + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["jurosDia"].Value.ToString())) + " ao dia ";


                            Instrucao_Sicoob item2 = new Instrucao_Sicoob(9, 5);
                            item2.Descricao += " após " + item2.QuantidadeDias.ToString() + " dias corridos do vencimento.";

                            Instrucao_Sicoob item3 = new Instrucao_Sicoob();
                            item3.Descricao = "Aluguel : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpavalo"].Value.ToString()));
                            item3.Descricao += " + Condominio : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpacond"].Value.ToString()));
                            item3.Descricao += " + IPTU : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaiptu"].Value.ToString()));
                            item3.Descricao += " - Abono : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaabon"].Value.ToString()));
                            item3.Descricao += " - Desconto Concedido : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpalcde"].Value.ToString()));
                            item3.Descricao += "  + Outros : " + String.Format("{0:C}", Convert.ToDecimal(dataGridViewRow.Cells["lpaoutr"].Value.ToString()));

                            Instrucao_Sicoob item4 = new Instrucao_Sicoob();
                            item4.Descricao = "Contrato : " + dataGridViewRow.Cells["efpnume"].Value.ToString() + " Parcela : " + dataGridViewRow.Cells["efpparc"].Value.ToString();

                            //monta boleto
                            Decimal vlrBoleto = Convert.ToDecimal(dataGridViewRow.Cells["efpvalo"].Value.ToString());
                            DateTime dtaVencimento = Convert.ToDateTime(dataGridViewRow.Cells["efpvenc"].Value.ToString());

                            if (tipoEmissao == "R" || tipoEmissao=="G")
                            {
                                nossoNumero = String.Format("{0:0000000}", Convert.ToInt32(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Substring(0,7)));
                            }

                            Boleto b = new Boleto(dtaVencimento, vlrBoleto, "101", nossoNumero, oCedente);

                            b.NumeroParcela = 1;
                            b.NumeroDocumento = nossoNumero;

                            EspecieDocumento oEspdoc = new EspecieDocumento(756, "02");
                            b.EspecieDocumento = oEspdoc;

                            b.Instrucoes.Add(item0a);
                            b.Instrucoes.Add(item0);
                            b.Instrucoes.Add(item1);
                            b.Instrucoes.Add(item1A);
                            b.Instrucoes.Add(item2);
                            b.Instrucoes.Add(item3);
                            b.Instrucoes.Add(item4);

                            b.Sacado = oSacado;

                            bBancario.Boleto = b;
                            bBancario.Boleto.Valida();

                            lstBoletos.Add(bBancario);

                            boletos.Add(bBancario.Boleto);

                            if (tipoEmissao == "E")
                            {
                                nossoNumero = String.Format("{0:0000000}", Convert.ToInt32(nossoNumero) + 1);
                                txtNossoNumero.Text = nossoNumero;
                            }

                        }

                        
                        //grava e calculo novo nosso número
                        if (tipoEmissao == "E")
                        {
                            string vNossoNumero = EmcResources.RemoveChars(bBancario.Boleto.NossoNumero, true, true,true);
                            dataGridViewRow.Cells["nrotitulo"].Value = vNossoNumero;
                            //dataGridViewRow.Cells["nrotitulo"].Value = nossoNumero;
                        }

                    }

                }

                if (cboTipoEmissao.SelectedItem.ToString().Trim() == "Geração de Arquivo de Remessa")
                {
                    //Gera arquivo de remessa
                    string nomeArquivo = "";
                    nomeArquivo = geraArquivoRemessa();
                    //Acumula codigo de arquivo remessa
                    oConta.seqArqRemessa = oConta.seqArqRemessa + 1;
                    //Grava nomo numero sequencia arquivo de remessa
                    gravaNumeroSequencia(oConta);
                    //atualiza titulos como já gerados com a remessa
                    gravaRemessaTitulos(nomeArquivo);

                    limpaTela();
                }
                else
                {
                    NBoleto form = new NBoleto(lstBoletos);
                    if (oConta.nroBanco == "756")
                    {
                        form.CodigoBanco = 756;
                    }
                    else if (oConta.nroBanco == "104")
                    {
                        form.CodigoBanco = 104;
                    }
                    else if (oConta.nroBanco == "237")
                    {
                        form.CodigoBanco = 237;
                    }
                    form.ShowDialog();

                    if (tipoEmissao == "E")
                    {
                        DialogResult result = MessageBox.Show("Boletos emitidos corretamente, confirma gravação ?", "EMC", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            gravaTitulos();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro Geração de Boletos - " + ex.Message);
            }
            finally
            {
                btnPesquisa_Click(null, null);
            }

        }

        private void limpaTela()
        {
            txtContrato.Text = "";
            txtIdCliente.Text = "";
            txtDataFinal.Text = DateTime.Now.ToString();
            txtDataInicio.Text = DateTime.Now.ToString();
            txtNomeCliente.Text = "";
            cboEnderecoSacado.Text = "Sim";
            cboComprovante.Text = "Não";
            cboFormatoCarne.Text = "Não";
            grdBoleto.Rows.Clear();

        }
        private void gravaRemessaTitulos(string nArquivo)
        {
            try
            {
                List<TituloCobranca> lstTitulosRemessa = new List<TituloCobranca>();

                 //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdBoleto.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];

                    //if (ch1.Value.Equals(ch1.TrueValue))
                    if (Convert.ToBoolean(ch1.Value.ToString()) && EmcResources.cInt(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Trim()) > 0)
                    {
                        TituloCobranca oTitulo = new TituloCobranca();
                        oTitulo.codEmpresa = EmcResources.cInt(cboEmpresa.SelectedValue.ToString());
                        oTitulo.idCliente = EmcResources.cInt(dataGridViewRow.Cells["idcliente"].Value.ToString());
                        oTitulo.idContrato = EmcResources.cInt(dataGridViewRow.Cells["efpnume"].Value.ToString());
                        oTitulo.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["efpparc"].Value.ToString());
                        oTitulo.nossoNUmero = dataGridViewRow.Cells["nrotitulo"].Value.ToString();
                        oTitulo.nroContaTitulo = EmcResources.cInt(cboContaBancaria.SelectedValue.ToString());
                        oTitulo.nomeArquivo = nArquivo;

                        lstTitulosRemessa.Add(oTitulo);
                    }
                }

                titulosCobrancaDAO oTituloDAO = new titulosCobrancaDAO();
                oTituloDAO.gravaRemessa(lstTitulosRemessa,nArquivo);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro gravação do nome da remessa nos titulos "+ex.Message);
            }
        }

        private void gravaTitulos()
        {
            try
            {
                List<TituloCobranca> lstTituloCobranca = new List<TituloCobranca>();

                //monta uma lista de parcelas
                foreach (DataGridViewRow dataGridViewRow in grdBoleto.Rows)
                {
                    DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                    ch1 = (DataGridViewCheckBoxCell)dataGridViewRow.Cells[0];

                    //if (ch1.Value.Equals(ch1.TrueValue))
                    //if (Convert.ToBoolean(ch1.Value.ToString()) && Convert.ToInt64(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Trim()) > 0)
                    if (Convert.ToBoolean(ch1.Value.ToString()) && !String.IsNullOrEmpty(dataGridViewRow.Cells["nrotitulo"].Value.ToString().Trim()))
                    {
                        TituloCobranca oTitulo = new TituloCobranca();
                        oTitulo.codEmpresa = EmcResources.cInt(cboEmpresa.SelectedValue.ToString());
                        oTitulo.idCliente = EmcResources.cInt(dataGridViewRow.Cells["idcliente"].Value.ToString());
                        oTitulo.idContrato = EmcResources.cInt(dataGridViewRow.Cells["efpnume"].Value.ToString());
                        oTitulo.nroParcela = EmcResources.cInt(dataGridViewRow.Cells["efpparc"].Value.ToString());
                        oTitulo.nossoNUmero = dataGridViewRow.Cells["nrotitulo"].Value.ToString();
                        oTitulo.nroContaTitulo = EmcResources.cInt(cboContaBancaria.SelectedValue.ToString());

                        lstTituloCobranca.Add(oTitulo);
                    }
                }

                titulosCobrancaDAO oTituloDAO = new titulosCobrancaDAO();
                oTituloDAO.gravaTitulos(lstTituloCobranca, oEmpresa, EmcResources.cInt(cboContaBancaria.SelectedValue.ToString()), txtNossoNumero.Text);


            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void gravaNumeroSequencia(CtaBanco oCta)
        {

            try
            {
                CtaBancoDAO oCtaDAO = new CtaBancoDAO();
                oCtaDAO.geraSequencia(oCta);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro geração do numero de sequencia do arquivo remessa."+ex.Message, "EMC");
            }
        }

        private string geraArquivoRemessa()
        {
            IBanco oBanco = null;
            string strMSG;
            // cria objeto STREAM
            FileStream objFILESTREAM = default(FileStream);

            // cria objeto do arquivo remessa
            ArquivoRemessa objREMESSA = default(ArquivoRemessa);

            string nome = "";

            try
            {
               
                //Gerar o nome do arquivo
                nome = "REM_" + oConta.nroAgencia.Trim() + "_" + oConta.nroCedente.Trim()+oConta.digCedente.Trim() + "_" + String.Format("{0:000000}", oConta.seqArqRemessa.ToString())+".CED";
                string diretorio = "";
                diretorio = "C:\\Remessas\\" + nome;

                 //Abre arquivo STREAM
                objFILESTREAM = File.Create(@diretorio);

                if (oConta.nroBanco == "756") //credicitrus
                {
                    objREMESSA = new ArquivoRemessa(TipoArquivo.CNAB240);
                    oBanco = new Banco(756);
                }
                else if (oConta.nroBanco == "104") //Caixa Economica Federal
                {
                    //Não Gera Remessa
                }
                else if (oConta.nroBanco == "237") //bradesco
                {
                    objREMESSA = new ArquivoRemessa(TipoArquivo.CNAB400);
                    oBanco = new Banco(237);
                }
                
                //Gera o arquivo REMESSA
                objREMESSA.GerarArquivoRemessa(oCedente.Convenio.ToString(), oBanco, oCedente, boletos, objFILESTREAM, oConta.seqArqRemessa);

                objREMESSA = null;
                objFILESTREAM = null;

                strMSG = "Arquivo de REMESSA [ " + nome + " ] foi gerado com sucesso !";
                MessageBox.Show(strMSG);
                
            }
            catch (Exception ex)
            {
                objREMESSA = null;
                objFILESTREAM = null;

                strMSG = "Houve um problema na geração do arquivo REMESSA. \n";
                strMSG += "Erro: " + ex.Message;
                MessageBox.Show(strMSG);
            }

            return nome;
        }

        private void frmBoletos_Load(object sender, EventArgs e)
        {

            EmpresaDAO oEmpDAO = new EmpresaDAO();
            cboEmpresa.DataSource = oEmpDAO.ListaEmpresa();
            cboEmpresa.DisplayMember = "razaosocial";
            cboEmpresa.ValueMember = "codempresa";

            cboTipoEmissao.Items.Add("Emissão de Titulos");
            cboTipoEmissao.Items.Add("Reemissão de Titulos");
            cboTipoEmissao.Items.Add("Geração de Arquivo de Remessa");
            cboTipoEmissao.SelectedItem = "Emissão de Titulos";


            cboEnderecoSacado.Text = "Sim";
            cboComprovante.Text = "Não";
            cboFormatoCarne.Text = "Não";

            this.ActiveControl = txtContrato;

            txtControle.Value = 30;

            //CtaBancoDAO oBcoDAO = new CtaBancoDAO();
            //cboContaBancaria.DataSource = oBcoDAO.ListaConta();
            //cboContaBancaria.ValueMember = "bancodi";
            //cboContaBancaria.DisplayMember = "bandesc";
        }

        private void cboContaBancaria_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboContaBancaria.SelectedValue.ToString().Trim()) && cboContaBancaria.SelectedValue.ToString().Trim() != "System.Data.DataRowView")
            {
                CtaBancoDAO oCtaDAO = new CtaBancoDAO();
                CtaBanco oConta = new CtaBanco();
                oConta.codEmpresa = Convert.ToInt32(cboEmpresa.SelectedValue.ToString());
                oConta.idCtaBancaria = Convert.ToInt32(cboContaBancaria.SelectedValue);
                oConta = oCtaDAO.ObterPor(oConta);
                txtNossoNumero.Text = oConta.nossoNumero;
            }
        }

        private void cboEmpresa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cboEmpresa.SelectedValue.ToString()) && cboEmpresa.SelectedValue.ToString().Trim() != "System.Data.DataRowView")
            {
                EmpresaDAO oEmpDAO = new EmpresaDAO();
                oEmpresa.codEmpresa = EmcResources.cInt(cboEmpresa.SelectedValue.ToString());
                oEmpresa = oEmpDAO.ObterPor(oEmpresa);


                CtaBancoDAO oBcoDAO = new CtaBancoDAO();
                cboContaBancaria.DataSource = oBcoDAO.ListaConta(EmcResources.cInt(cboEmpresa.SelectedValue.ToString()));
                cboContaBancaria.ValueMember = "bancodi";
                cboContaBancaria.DisplayMember = "bandesc";
            }

        }

        protected static int Mod11Base9(string seq)
        {
            /* Variáveis
             * -------------
             * d - Dígito
             * s - Soma
             * p - Peso
             * b - Base
             * r - Resto
             */

            int d, s = 0, p = 2, b = 9;


            for (int i = seq.Length - 1; i >= 0; i--)
            {
                string aux = Convert.ToString(seq[i]);
                s += (Convert.ToInt32(aux) * p);
                if (p >= b)
                    p = 2;
                else
                    p = p + 1;
            }

            if (s < 11)
            {
                d = 11 - s;
                return d;
            }
            else
            {
                d = 11 - (s % 11);
                if ((d > 9) || (d == 0))
                    d = 0;

                return d;
            }
        }

        private void txtContratoFinal_Validating(object sender, CancelEventArgs e)
        {
            if (EmcResources.cInt(txtContratoFinal.Text) == 0 || String.IsNullOrEmpty(txtContratoFinal.Text))
                txtContratoFinal.Text = txtContrato.Text;
        }

        private void btnMarcar_Click(object sender, EventArgs e)
        {
            try
            {
                int conta = 1;
                foreach (DataGridViewRow dataGridViewRow in grdBoleto.Rows)
                {
                    if (conta <= txtControle.Value)
                    {
                        dataGridViewRow.Cells[0].Value = true;
                    }
                    conta++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro  " + ex.Message);
            }
        }

       
    }
}
