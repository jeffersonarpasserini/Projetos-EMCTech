using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCSecurityRN
{
    public class OcorrenciaRN
    {
        OcorrenciaDAO objBLL;
        ConectaBancoMySql Conexao;
        int codEmpresa;

        public OcorrenciaRN(ConectaBancoMySql pConexao, int idEmpresa)
        {
            Conexao = pConexao;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public List<Ocorrencia> ListaOcorrencia(Ocorrencia oOcorrencia)
        {
            List<Ocorrencia> lstOcorrencia = new List<Ocorrencia>();

            try
            {
                objBLL = new OcorrenciaDAO(Conexao,codEmpresa);
                lstOcorrencia = objBLL.ListaOcorrencia(oOcorrencia);
                return lstOcorrencia;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            
        }
  
        #endregion


    }
}
