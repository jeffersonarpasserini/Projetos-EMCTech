using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;
using EMCSecurityModel;

namespace EMCFinanceiroRN
{
    public class PagarFaturaRN
    {
        PagarFaturaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public PagarFaturaRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

         /// <summary>
         /// Salva parcelas do contas a pagar ( desativado )
         /// </summary>
         /// <param name="objPagarParcela"></param>
         public void Salvar(PagarFatura objPagarFatura)
         {
             try
             {
                 //Valida informações a serem gravadas
                 //VerificaDados(objPagarParcela);
                 //faz um backup das parcelas originais

                 objPagarFatura = geraBaseRateioFatura(objPagarFatura);

                 objBLL = new PagarFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 objBLL.Salvar(objPagarFatura);


             }
             catch (Exception erro)
             {
                 throw erro;
             }
         }

         /// <summary>
         /// Realiza busca ao banco de dados das parcelas em aberto para  sem aprovação de pagamento para geração de uma fatura
         /// </summary>
         /// <param name="oPagarFatura"></param>
         /// <returns></returns>
         public DataTable listaPagarFatura(PagarFatura oPagarFatura)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new PagarFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.ListaPagarFatura(oPagarFatura);

             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;


         }

         public DataTable pesquisaPagarFatura(int codEmpresa, int empMaster, int idFornecedor, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new PagarFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.pesquisaPagarFatura(codEmpresa, empMaster, idFornecedor, dataInicio, dataFinal, chkTodasContas, valorInicio, valorFinal, valorDocumento, docAberto);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;


         }
         /// <summary>
         /// Busca informações no banco de dados de uma fatura do contas a pagar
         /// retornando um objeto do tipo PagarFatura
         /// </summary>
         /// <param name="objPagarFatura"></param>
         /// <returns></returns>
         public PagarFatura ObterPor(PagarFatura objPagarFatura)
         {
             try
             {
                 //Valida informações a serem gravadas
                 //VerificaDados(objPagarParcela);

                 objBLL = new PagarFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 objPagarFatura = objBLL.ObterPor(objPagarFatura);


             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return objPagarFatura;

         }

         #region Metodos Privados da Classe

         public PagarFatura geraBaseRateioFatura(PagarFatura oFatura)
         {
             try
             {
                 List<PagarBaseRateio> oRat = new List<PagarBaseRateio>();
                 /*
                  * Primeiro passo montar uma lista unica dos centros de custo 
                  * de todos os documentos que formaram a fatura
                  * */

               

                 //percorre as parcelas que compõe o novo documento ou fatura
                 foreach (PagarParcela oParcela in oFatura.lstParcelas)
                 {
                     //percorre as bases de rateio originais
                     foreach (PagarBaseRateio oBase in oParcela.pagarDocumento.baseRateio)
                     {
                         oRat.Add(oBase);
                     }
                 }


                 //Cria uma nota lista de rateio
                 List<PagarBaseRateio> oFatRateio = new List<PagarBaseRateio>();

                 /*
                  * Calcular os totais de cada centro de custo e aplicação
                  * para formar uma unica base de rateio aglutinada
                  * */

                 //percorre a lista aglutinada
                 //for (int i=0; i <= oRat.Count; i++ )
                 foreach(PagarBaseRateio oBase in oRat)
                 {
                     //pega o proximo elemento da list e depois o remove
                     //PagarBaseRateio oBase = oRat.ElementAt(i);
                     //oRat.RemoveAt(0);

                     //percorre novamente a list procurando elementos iguais
                     foreach (PagarBaseRateio oBaseSoma in oRat)
                     {
                         //pega o proximo elemento da list
                         //oBaseSoma = oRat.ElementAt(0);

                         //se encontrar um outro elemento igual soma ao primeiro e remove da lista
                         if (oBase.contaCusto.idContaCusto == oBaseSoma.contaCusto.idContaCusto &&
                             oBase.aplicacao.idAplicacao == oBaseSoma.aplicacao.idAplicacao && !oBase.Equals(oBaseSoma))
                         {
                             oBase.valorRateio = oBase.valorRateio + oBaseSoma.valorRateio;
                             //oRat.Remove(oBaseSoma);
                         }


                     }

                     if (oFatRateio.Count > 0)
                     {
                         Boolean existe = false;
                         foreach (PagarBaseRateio oVerifica in oFatRateio)
                         {
                             //se encontrar um outro elemento igual soma ao primeiro e remove da lista
                             if (oBase.contaCusto.idContaCusto == oVerifica.contaCusto.idContaCusto &&
                                 oBase.aplicacao.idAplicacao == oVerifica.aplicacao.idAplicacao)
                             {
                                 existe = true;
                             }        
                         }

                         if (!existe)
                            oFatRateio.Add(oBase);
                     }
                     else
                         oFatRateio.Add(oBase);
                     
                    
                 }

                 /*
                  * Refaz o percentual de participação sobre o total dos documentos originais
                  * 
                  **/

                 //soma as bases de rateo
                 decimal soma = 0;
                 foreach (PagarBaseRateio oRateio in oFatRateio)
                 {
                     soma = soma + oRateio.valorRateio;
                 }

                 //refaz os rateios 
                 double somaRateio = 0;
                 decimal somaFatura = 0;
                 int conta = 0;
                 List<PagarBaseRateio> rateioFinal = new List<PagarBaseRateio>();

                 foreach (PagarBaseRateio oRateio in oFatRateio)
                 {
                     conta++;

                     oRateio.percentualRateio = EmcResources.cDouble(Math.Round(((oRateio.valorRateio / soma) * 100),4).ToString());
                     oRateio.valorRateio = EmcResources.cCur(Math.Round(((EmcResources.cDouble(oFatura.valorFatura.ToString()) * oRateio.percentualRateio)/100),2).ToString());
                     
                     somaFatura = somaFatura + oRateio.valorRateio;
                     somaRateio = somaRateio + oRateio.percentualRateio;

                     if (conta >= oFatRateio.Count)
                     {
                         if (somaRateio < 100)
                         {
                             oRateio.percentualRateio = oRateio.percentualRateio + (100 - somaRateio);
                         }
                         if (somaFatura < soma)
                         {
                             oRateio.valorRateio = oRateio.valorRateio + (oFatura.valorFatura - somaFatura);
                         }
                     }

                     oRateio.status = "I";

                     rateioFinal.Add(oRateio);
                 }


                 PagarDocumento oPgDoc = new PagarDocumento();
                 oPgDoc = oFatura.pagarDocumento;
                 oPgDoc.baseRateio = rateioFinal;

                 oFatura.pagarDocumento = oPgDoc;


                 //refaz listas de parcelas originais
                 List<PagarParcela> lstParc = new List<PagarParcela>();

                 foreach (PagarParcela oParcPagar in oFatura.lstParcelas)
                 {

                     PagarParcelaDAO oParcDAO = new PagarParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                     PagarParcela oParcNova = new PagarParcela();
                     oParcNova = oParcDAO.ObterPor(oParcPagar);

                     lstParc.Add(oParcNova);
                 }

                 oFatura.lstParcelas = lstParc;


             }
             catch (Exception e)
             {
                 throw e;
             }
             return oFatura;
         }

         /// <summary>
         /// Verifica dados dos atributos do objeto PagarFatura retornando uma Exception
         /// Deve ser circundada por um try catch
         /// </summary>
         /// <param name="obj"></param>
         public void VerificaDados(PagarFatura obj)
         {

             //Exception objErro;

             //if (String.IsNullOrEmpty(obj.descricao))
             //{
             //    objErro = new Exception("A descrição do PagarParcela não pode estar vazia");
             //    throw objErro;
             //}
         }
         #endregion

    }
}
