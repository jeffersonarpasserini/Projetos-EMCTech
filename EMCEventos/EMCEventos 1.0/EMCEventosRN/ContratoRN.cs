using EMCEventosDAO;
using EMCEventosModel;
using EMCLibrary;
using EMCSecurityModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace EMCEventosRN
{
    public class ContratoRN
    {
        ContratoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

         public ContratoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

         #region Metodos Publicos da Classe

         public DataTable ListaContrato()
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.ListaContrato();
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }

         public DataTable ListaRelContrato(int idCliente, bool chkCliente, int idSubLocacao, bool chkSubLocacao, int idFornecedor, bool chkFornecedor, DateTime? dataInicial, DateTime? dataFinal)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.dstRelContrato(idCliente, chkCliente, idSubLocacao, chkSubLocacao, idFornecedor, chkFornecedor, dataInicial, dataFinal);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }

         public DataTable ListaContratoCli(int idCliente, bool chkCliente, DateTime? dataInicial, DateTime? dataFinal)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.dstRelatorioCli(idCliente, chkCliente, dataInicial, dataFinal);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }

         public DataTable ListaContratoSubLoc(int idSubLocacao, bool chkSubLocacao, DateTime? dataInicial, DateTime? dataFinal)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.dstRelatorioSubLoc(idSubLocacao, chkSubLocacao, dataInicial, dataFinal);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }

         public DataTable ListaContratoForn(int idFornecedor, bool chkFornecedor, DateTime? dataInicial, DateTime? dataFinal)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.dstRelatorioForn(idFornecedor, chkFornecedor, dataInicial, dataFinal);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }


         public DataTable pesquisaContrato(int empMaster, int idSubLocacao, int idCliente, int idFornecedor, DateTime? dataInicial, DateTime? dataFinal)
         {
             DataTable dtCon = new DataTable();

             try
             {
                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 dtCon = objBLL.pesquisaContrato(empMaster, idSubLocacao, idCliente, idFornecedor, dataInicial, dataFinal);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return dtCon;
         }

         public void Atualizar(Contrato objContrato)
         {
             try
             {
                 //Valida informações a serem gravadas
                 VerificaDados(objContrato);

                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 objBLL.Atualizar(objContrato);
             }
             catch (Exception erro)
             {
                 throw erro;
             }

         }

         public void Salvar(Contrato objContrato)
         {
             try
             {
                 //Valida informações a serem gravadas
                 VerificaDados(objContrato);


                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 objBLL.Salvar(objContrato);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
         }

         public void Excluir(Contrato objContrato)
         {
             try
             {
                 //Valida informações a serem gravadas
                 VerificaDados(objContrato);

                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 objBLL.Excluir(objContrato);
             }
             catch (Exception erro)
             {
                 throw erro;
             }
         }

         public Contrato ObterPor(Contrato objContrato)
         {
             try
             {
                 //Valida informações a serem gravadas

                 objBLL = new ContratoDAO(Conexao, oOcorrencia, codEmpresa);
                 objContrato = objBLL.ObterPor(objContrato);

             }
             catch (Exception erro)
             {
                 throw erro;
             }
             return objContrato;
         }
         #endregion

         #region Metodos Privados da Classe
         //Verifica erros no objeto
         public void VerificaDados(Contrato obj)
         {

             Exception objErro;
             if (obj.dataContrato == null)
             {
                 objErro = new Exception("Data do Contrato não pode ser nulo");
                 throw objErro;
             }

             if (obj.subLocacao.idSublocacao == 0)
             {
                 objErro = new Exception("SubLocação não pode ser nulo");
                 throw objErro;
             }

             //if (obj.cliente.idPessoa == 0)
             //{
             //    objErro = new Exception("Cliente não pode ser nulo");
             //    throw objErro;
             //}
             

             //if (obj.fornecedor.idPessoa == 0)
             //{
             //    objErro = new Exception("Fornecedor não pode ser nulo");
             //    throw objErro;
             //}

             if (obj.usuario.idUsuario == 0)
             {
                 objErro = new Exception("Usuário Contrato não pode ser nulo");
                 throw objErro;
             }


         }

         #endregion
    }
}
