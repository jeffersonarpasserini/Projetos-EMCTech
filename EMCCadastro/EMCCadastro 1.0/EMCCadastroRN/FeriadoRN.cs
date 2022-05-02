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
    public class FeriadoRN
    {

        FeriadoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public FeriadoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        /// <summary>
        /// Retorna o proximo dia util
        /// Verifica sabados e domingos e feriados de acordo com o parametro configurado no sistema
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DateTime diaUtil(DateTime data)
        {
            bool flag = true;
            DateTime dataCorreta = data;

            FeriadoDAO oFeriado = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);

            while (flag)
            {
                if (dataCorreta.DayOfWeek == DayOfWeek.Sunday)
                    dataCorreta = dataCorreta.AddDays(1);
                else if (dataCorreta.DayOfWeek == DayOfWeek.Saturday)
                    dataCorreta = dataCorreta.AddDays(2);
                else if (oFeriado.dataFeriado(dataCorreta))
                    dataCorreta = dataCorreta.AddDays(1);
                else flag = false;
            }

            return dataCorreta;
        }

        public DataTable ListaFeriado()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaFeriado();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Feriado objFeriado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFeriado);

                objBLL = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objFeriado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Feriado objFeriado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFeriado);

                objBLL = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objFeriado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Feriado objFeriado)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objFeriado);

                objBLL = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objFeriado);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public bool dataFeriado(DateTime data)
        {
            FeriadoDAO oFeriado = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);

            return oFeriado.dataFeriado(data);
 
        }
        
        public Feriado ObterPor(Feriado objFeriado)
        {
            try
            {
                //Valida informações a serem gravadas
               // VerificaDados(objFeriado);

                objBLL = new FeriadoDAO(Conexao,oOcorrencia,codEmpresa);
                objFeriado = objBLL.ObterPor(objFeriado);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objFeriado;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Feriado obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("Descrição do Feriado não pode ser nula");
                throw objErro;
            }
            if (obj.dataFeriado == null)
            {
                objErro = new Exception("Data do Feriado inválido");
                throw objErro;
            }
        }

        #endregion

    }
}
