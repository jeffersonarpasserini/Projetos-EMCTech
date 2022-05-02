using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCSecurityModel;

namespace EMCEstoqueRN
{
    public class Estq_SubGrupoRN
    {

        Estq_SubGrupoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_SubGrupoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_SubGrupo()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstq_SubGrupo();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaEstq_SubGrupo(int pIDGrupoProduto)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstq_SubGrupo(pIDGrupoProduto);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_SubGrupo objEstq_SubGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_SubGrupo);

                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_SubGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_SubGrupo objEstq_SubGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_SubGrupo);

                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_SubGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_SubGrupo objEstq_SubGrupo)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_SubGrupo);

                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_SubGrupo);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_SubGrupo ObterPor(Estq_SubGrupo objEstq_SubGrupo)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_SubGrupo = objBLL.ObterPor(objEstq_SubGrupo);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_SubGrupo;

        }

        public DataTable pesquisaSubGrupo(int empMaster, int idEstqSubGrupo, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaSubGrupo(empMaster, idEstqSubGrupo, descricao);
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
                objBLL = new Estq_SubGrupoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string DataReport1()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select sg.*, g.descricao as grupo from estq_subgrupo sg, estq_grupo g");
            strSQL.Append(" where g.idestq_grupo = sg.estq_grupo_idestq_grupo");
            strSQL.Append(" order by sg.idestq_subgrupo");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select sg.*, g.descricao as grupo from estq_subgrupo sg, estq_grupo g");
            strSQL.Append(" where g.idestq_grupo = sg.estq_grupo_idestq_grupo");
            strSQL.Append(" order by sg.descricao");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Estq_SubGrupo obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Subgrupo deve ser informada");
                throw objErro;
            }

            if (obj.Estq_Grupo.idestq_grupo == 0)
            {
                objErro = new Exception("O Grupo do Estoque deve ser informado");
                throw objErro;
            }
            if (obj.Unidade_MenorControle.idestq_produto_unidade == 0)
            {
                objErro = new Exception("A Menor Unidade de Controle deve ser informada");
                throw objErro;
            }
            if (obj.UnidadePadrao.idestq_produto_unidade == 0)
            {
                objErro = new Exception("A Unidade Padrão deve ser informada");
                throw objErro;
            }

        }
        
        #endregion
    }
}
