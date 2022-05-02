using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCImobDAO;
using EMCSecurityModel;
using EMCImobModel;

namespace EMCImobRN
{
    public class ImovelComodoRN
    {
        ImovelComodoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ImovelComodoRN(ConectaBancoMySql pConexao,Ocorrencia pOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = pOcorrencia;
            codEmpresa = idEmpresa;
        }


        #region Metodos Publicos da Classe
        

        public List<ImovelComodo> listaImovelComodo(int idImovel)
        {
            List<ImovelComodo> lstImoComodo = new List<ImovelComodo>();
            try
            {
                ImovelComodoDAO oImoComodoDAO = new ImovelComodoDAO(Conexao, oOcorrencia, codEmpresa);
                lstImoComodo = oImoComodoDAO.lstImovelComodo(idImovel);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return lstImoComodo;
        }



        public ImovelComodo ObterPor(ImovelComodo objImovelComodo)
        {
            try
            {
                //Valida informações a serem gravadas
              
                objBLL = new ImovelComodoDAO(Conexao, oOcorrencia, codEmpresa);
                objImovelComodo = objBLL.ObterPor(objImovelComodo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objImovelComodo;

        }

        public void VerificaDados(ImovelComodo obj)
        {

            Exception objErro;

            if (obj.idComodos.idComodos == 0)
            {
                objErro = new Exception("Cômodo não pode ser nulo");
                throw objErro;
            }

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.nroDepencia == 0)
            {
                objErro = new Exception("Dependência não pode ser nula");
                throw objErro;
            }
            
        }
        
        #endregion
    }
}
