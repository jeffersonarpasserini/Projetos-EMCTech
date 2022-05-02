using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;

namespace EMCCadastroRN
{
    public class HistoricoRN
    {
        
        HistoricoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public HistoricoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaHistorico(Historico oHistorico)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new HistoricoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaHistorico(oHistorico);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Historico oHistorico)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHistorico);

                objBLL = new HistoricoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(oHistorico);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Historico oHistorico)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHistorico);

                objBLL = new HistoricoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(oHistorico);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Historico oHistorico)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oHistorico);

                objBLL = new HistoricoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(oHistorico);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Historico ObterPor(Historico oHistorico)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new HistoricoDAO(Conexao,oOcorrencia,codEmpresa);
                oHistorico = objBLL.ObterPor(oHistorico);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            
            return oHistorico;

        }

        public DataTable pesquisaHistorico(int empMaster, int idHistorico, String descricao, String exigeComplemento)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new HistoricoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaHistorico(empMaster, idHistorico, descricao, exigeComplemento);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Historico obj)
        {

            Exception objErro;

            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.idHistorico < 0)
            {
                objErro = new Exception("Código da Histórico não pode ser nulo");
                throw objErro;
            }

        }

        #endregion

    }
}
