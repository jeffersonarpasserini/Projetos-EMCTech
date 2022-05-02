using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCObrasModel;
using EMCObrasDAO;
using EMCSecurityModel;
using EMCCadastroDAO;
using EMCCadastroModel;
using EMCEstoqueModel;

namespace EMCObrasRN
{
    public class Obra_CronogramaRN
    {
        Obra_CronogramaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_CronogramaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable listaObra()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaObra_Cronograma();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void atualizar(Obra_Cronograma objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void salvar(Obra_Cronograma objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.salvar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void excluir(Obra_Cronograma objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.excluir(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void atualizarSituacao(Obra_Cronograma objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objObra);

                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizarSituacao(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_Cronograma obterPor(Obra_Cronograma objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                objObra = objBLL.ObterPor(objObra);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra;

        }

        public DataTable pesquisaObra(int empMaster, string abreviacao, string descricaoObra)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaObra(empMaster, abreviacao, descricaoObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_CronogramaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string drDtaFinal(int codEmpresa, String situacao, DateTime dtaInicio, DateTime dtaFinal)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("SELECT o.*, u.nomecompleto as responsavel, c.codigoconta, c.descricao as contacusto");
            strSQL.Append(" FROM obra_cronograma o, usuario u, contacusto c");
            strSQL.Append(" where u.idusuario = o.responsavel_idusuario");
            strSQL.Append(" and  c.idcontacusto = o.idcontacusto");
            strSQL.Append(" and o.empresa_idEmpresa = '" + codEmpresa + "'");
            strSQL.Append(" and o.situacao = '" + situacao + "'");
            strSQL.Append(" and o.dtafinal between '" + dtaInicio.ToString("yyyy-MM-dd") + "' and '" + dtaFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" order by o.abreviacao");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string drDtaIncio(int codEmpresa, String situacao, DateTime dtaInicio, DateTime dtaFinal)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("SELECT o.*, u.nomecompleto as responsavel, c.codigoconta, c.descricao as contacusto");
            strSQL.Append(" FROM obra_cronograma o, usuario u, contacusto c");
            strSQL.Append(" where u.idusuario = o.responsavel_idusuario");
            strSQL.Append(" and  c.idcontacusto = o.idcontacusto");
            strSQL.Append(" and o.empresa_idEmpresa = '" + codEmpresa + "'");
            strSQL.Append(" and o.situacao = '" + situacao + "'");
            strSQL.Append(" and o.dtainicio between '" + dtaInicio.Date.ToString("yyyy-MM-dd") + "' and '" + dtaFinal.Date.ToString("yyyy-MM-dd") + "'");
            strSQL.Append(" order by o.abreviacao");
           
            //retorna string com consulta SQL
            return strSQL.ToString();
        }

        public string drSituacao(int codEmpresa, String situacao)
        {
            StringBuilder strSQL = new StringBuilder();

            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("SELECT o.*, u.nomecompleto as responsavel, c.codigoconta, c.descricao as contacusto");
            strSQL.Append(" FROM obra_cronograma o, usuario u, contacusto c");
            strSQL.Append(" where u.idusuario = o.responsavel_idusuario");
            strSQL.Append(" and  c.idcontacusto = o.idcontacusto");
            strSQL.Append(" and o.empresa_idEmpresa = '" + codEmpresa + "'");
            strSQL.Append(" and o.situacao = '" + situacao + "'");
            strSQL.Append(" order by o.abreviacao");

            //retorna string com consulta SQL
            return strSQL.ToString();
        }

       

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_Cronograma obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.situacao))
            {
                objErro = new Exception("A Situacao deve ser informada");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.atividadeCritica))
            {
                objErro = new Exception("A atividade critica deve ser informada");
                throw objErro;
            }

            if (obj.dtaFinal <= obj.dtaInicio)
            {
                objErro = new Exception("Data Final deve ser maior que a inicial");
                throw objErro;
            }
            if (obj.dtaFinalPreveisto <= obj.dtaInicioPrevisto)
            {
                objErro = new Exception("Data Final Prevista deve ser maior que a inicial Prevista");
                throw objErro;
            }

            if (obj.custoPrevisto > 0)
            {
                objErro = new Exception("Custo Previsto deve ser informada");
                throw objErro;
            }
            if (obj.obra_tarefa.idobra_tarefas == 0)
            {
                objErro = new Exception("Tarefa deve ser informada");
                throw objErro;
            }
            if (obj.idObra_Cronograma.idObra_Cronograma == 0)
            {
                objErro = new Exception("A Obra do Cronograma deve ser informada");
                throw objErro;
            }
            if (obj.qtdePrevisto == 0)
            {
                objErro = new Exception("A quantidade de serviço prevista deve ser informada");
                throw objErro;
            }

        }
        

        #endregion





    }
}
