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
    public class ReceberFaturaRN
    {
        ReceberFaturaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public ReceberFaturaRN(ConectaBancoMySql pConexao, Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }

         /// <summary>
         /// Salva parcelas do contas a receber ( desativado )
         /// </summary>
         /// <param name="objReceberParcela"></param>
         public void Salvar(ReceberFatura objReceberFatura)
         {
             try
             {
                 //Valida informações a serem gravadas
                 //VerificaDados(objReceberParcela);
                 //faz um backup das parcelas originais

                 objReceberFatura = geraBaseRateioFatura(objReceberFatura);

                 objBLL = new ReceberFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 objBLL.Salvar(objReceberFatura);


             }
             catch (Exception erro)
             {
                 throw erro;
             }
         }

         /// <summary>
         /// Realiza busca ao banco de dados das parcelas em aberto para  sem aprovação de pagamento para geração de uma fatura
         /// </summary>
         /// <param name="oReceberFatura"></param>
         /// <returns></returns>
         public DataTable listaReceberFatura(ReceberFatura oReceberFatura)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ReceberFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.ListaReceberFatura(oReceberFatura);

             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;


         }

         public DataTable pesquisaReceberFatura(int codEmpresa, int empMaster, int idCliente, DateTime dataInicio, DateTime dataFinal, bool chkTodasContas, decimal valorInicio, decimal valorFinal, bool valorDocumento, bool docAberto)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ReceberFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.pesquisaReceberFatura(codEmpresa, empMaster, idCliente, dataInicio, dataFinal, chkTodasContas, valorInicio, valorFinal, valorDocumento, docAberto);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;


         }
         /// <summary>
         /// Busca informações no banco de dados de uma fatura do contas a receber
         /// retornando um objeto do tipo ReceberFatura
         /// </summary>
         /// <param name="objReceberFatura"></param>
         /// <returns></returns>
         public ReceberFatura ObterPor(ReceberFatura objReceberFatura)
         {
             try
             {
                 //Valida informações a serem gravadas
                 //VerificaDados(objReceberParcela);

                 objBLL = new ReceberFaturaDAO(Conexao, oOcorrencia, codEmpresa);
                 objReceberFatura = objBLL.ObterPor(objReceberFatura);


             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return objReceberFatura;

         }

         #region Metodos Privados da Classe

         public ReceberFatura geraBaseRateioFatura(ReceberFatura oFatura)
         {
             try
             {
                 List<ReceberBaseRateio> oRat = new List<ReceberBaseRateio>();
                 /*
                  * Primeiro passo montar uma lista unica dos centros de custo 
                  * de todos os documentos que formaram a fatura
                  * */

               

                 //percorre as parcelas que compõe o novo documento ou fatura
                 foreach (ReceberParcela oParcela in oFatura.lstParcelas)
                 {
                     //percorre as bases de rateio originais
                     foreach (ReceberBaseRateio oBase in oParcela.receberDocumento.baseRateio)
                     {
                         oRat.Add(oBase);
                     }
                 }


                 //Cria uma nota lista de rateio
                 List<ReceberBaseRateio> oFatRateio = new List<ReceberBaseRateio>();

                 /*
                  * Calcular os totais de cada centro de custo e aplicação
                  * para formar uma unica base de rateio aglutinada
                  * */

                 //percorre a lista aglutinada
                 //for (int i=0; i <= oRat.Count; i++ )
                 foreach(ReceberBaseRateio oBase in oRat)
                 {
                     //pega o proximo elemento da list e depois o remove
                     //ReceberBaseRateio oBase = oRat.ElementAt(i);
                     //oRat.RemoveAt(0);

                     //percorre novamente a list procurando elementos iguais
                     foreach (ReceberBaseRateio oBaseSoma in oRat)
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
                         foreach (ReceberBaseRateio oVerifica in oFatRateio)
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
                 foreach (ReceberBaseRateio oRateio in oFatRateio)
                 {
                     soma = soma + oRateio.valorRateio;
                 }

                 //refaz os rateios 
                 double somaRateio = 0;
                 decimal somaFatura = 0;
                 int conta = 0;
                 List<ReceberBaseRateio> rateioFinal = new List<ReceberBaseRateio>();

                 foreach (ReceberBaseRateio oRateio in oFatRateio)
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


                 ReceberDocumento oPgDoc = new ReceberDocumento();
                 oPgDoc = oFatura.receberDocumento;
                 oPgDoc.baseRateio = rateioFinal;

                 oFatura.receberDocumento = oPgDoc;


                 //refaz listas de parcelas originais
                 List<ReceberParcela> lstParc = new List<ReceberParcela>();

                 foreach (ReceberParcela oParcReceber in oFatura.lstParcelas)
                 {

                     ReceberParcelaDAO oParcDAO = new ReceberParcelaDAO(Conexao, oOcorrencia, codEmpresa);
                     ReceberParcela oParcNova = new ReceberParcela();
                     oParcNova = oParcDAO.ObterPor(oParcReceber);

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
         /// Verifica dados dos atributos do objeto ReceberFatura retornando uma Exception
         /// Deve ser circundada por um try catch
         /// </summary>
         /// <param name="obj"></param>
         public void VerificaDados(ReceberFatura obj)
         {

             //Exception objErro;

             //if (String.IsNullOrEmpty(obj.descricao))
             //{
             //    objErro = new Exception("A descrição do ReceberParcela não pode estar vazia");
             //    throw objErro;
             //}
         }
         #endregion



    }
}
