using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobModel;
using EMCImobDAO;
using EMCSecurityModel;

namespace EMCImobRN
{
    public class DespesaImovelRN
    {
        DespesaImovelDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public DespesaImovelRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaDespesaImovel()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaDespesaImovel();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaDespesaImovel(int idPessoa, bool chkFornecedor, string codigoImovel, bool chkImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioDespesaImovel(idPessoa, chkFornecedor, codigoImovel, chkImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaImovel(int idPessoa, bool chkFornecedor, string codigoImovel, bool chkImovel)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioImovel(idPessoa, chkFornecedor, codigoImovel, chkImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable pesquisaDespesaImovel(int empMaster, int idPessoa, string codigoImovel, DateTime? dataInicial, DateTime? dataFinal)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaDespesaImovel(empMaster, idPessoa, codigoImovel, dataInicial, dataFinal);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(DespesaImovel objDespesaImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objDespesaImovel);

                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objDespesaImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(DespesaImovel objDespesaImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objDespesaImovel);

                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objDespesaImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public void Excluir(DespesaImovel objDespesaImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objDespesaImovel);

                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objDespesaImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        public DespesaImovel ObterPor(DespesaImovel objDespesaImovel)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new DespesaImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objDespesaImovel = objBLL.ObterPor(objDespesaImovel);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objDespesaImovel;
        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(DespesaImovel obj)
        {

            Exception objErro;

            if (obj.imovel.idImovel == 0)
            {
                objErro = new Exception("Imóvel não pode ser nula");
                throw objErro;
            }
            if (obj.locacaoProventos.idLocacaoProventos == 0)
            {
                objErro = new Exception("Locação Proventos não pode ser nula");
                throw objErro;
            }
           
            if (obj.historico.Trim().Length == 0)
            {
                objErro = new Exception("Histórico não pode ser nulo");
                throw objErro;
            }
            if (obj.valorDespesa == 0)
            {
                objErro = new Exception("Valor da Despesa não pode ser nulo");
                throw objErro;
            }
            
            if (obj.descricaoAcerto.Trim().Length == 0)
            {
                objErro = new Exception("Descrição do Acerto não pode ser nulo");
                throw objErro;
            }                     

            if (obj.fornecedor.idPessoa == 0)
            {
                objErro = new Exception("Fornecedor não pode ser nulo");
                throw objErro;
            }            
        }

        #endregion
    }
}
