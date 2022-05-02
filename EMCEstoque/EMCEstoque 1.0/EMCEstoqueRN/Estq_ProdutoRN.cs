using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCEstoqueModel;
using EMCEstoqueDAO;
using EMCSecurityModel;
using EMCFaturamentoModel;

namespace EMCEstoqueRN
{
    public class Estq_ProdutoRN
    {

        Estq_ProdutoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Estq_ProdutoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaEstq_Produto()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaEstq_Produto();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Estq_Produto objEstq_Produto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto);

                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Atualizar(objEstq_Produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Estq_Produto objEstq_Produto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto);

                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Salvar(objEstq_Produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Estq_Produto objEstq_Produto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEstq_Produto);

                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objBLL.Excluir(objEstq_Produto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Estq_Produto ObterPor(Estq_Produto objEstq_Produto)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia,codEmpresa);
                objEstq_Produto = objBLL.ObterPor(objEstq_Produto);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEstq_Produto;

        }

        public DataTable pesquisaProduto(int empMaster, int codigoProduto, string descricao)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaProduto(empMaster, codigoProduto, descricao);
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
                objBLL = new Estq_ProdutoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string DataReport()
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select p.*, subg.descricao as descricaosubgrupo, cc.descricao as descricaocustocomponente,");
            strSQL.Append(" cg.descricao as descricaocomponentegrupo, uni.unidade_abreviatura as unidadeproduto,");
            strSQL.Append(" g.descricao as descricaogrupo, ncm.nroncm as ncm,");
            strSQL.Append(" fam.descricao as descricaofamilia, tri.descricao as tributacao, tp.descricao as tipoproduto");
            strSQL.Append(" from estq_produto p, estq_subgrupo subg, custo_componente cc, custo_componentegrupo cg, estq_grupo g,");
            strSQL.Append(" estq_produto_unidade uni, estq_familia fam, fatu_tributacao tri, estq_tipoproduto tp, fatu_ncm ncm");
            strSQL.Append(" where subg.idestq_subgrupo = p.estq_subgrupo_idestq_subgrupo");
            strSQL.Append(" and cc.idcusto_componente = p.custo_componente_idcusto_componente");
            strSQL.Append(" and cg.idcusto_componentegrupo = p.custo_componente_idgrupo_componente");
            strSQL.Append(" and uni.idestq_produto_unidade = p.estq_produto_unidade_idestq_produto_unidade");
            strSQL.Append(" and fam.idestq_familia = p.estq_familia_idestq_familia");
            strSQL.Append(" and tri.idfatu_tributacao = p.idfatu_tributacaoipi");
            strSQL.Append(" and tp.idestq_tipoproduto = p.estq_tipoproduto_idestq_tipoproduto");
            strSQL.Append(" and g.idestq_grupo = p.estq_subgrupo_estq_grupo_idestq_grupo");
            strSQL.Append(" and ncm.idfatu_ncm = p.fatu_ncm_idfatu_ncm");
            strSQL.Append(" order by p.descricaodetalhada");
         
            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport2(string codigoProduto)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select p.*, subg.descricao as descricaosubgrupo, cc.descricao as descricaocustocomponente,");
            strSQL.Append(" cg.descricao as descricaocomponentegrupo, uni.unidade_abreviatura as unidadeproduto,");
            strSQL.Append(" g.descricao as descricaogrupo, ncm.nroncm as ncm,");
            strSQL.Append(" fam.descricao as descricaofamilia, tri.descricao as tributacao, tp.descricao as tipoproduto");
            strSQL.Append(" from estq_produto p, estq_subgrupo subg, custo_componente cc, custo_componentegrupo cg, estq_grupo g,");
            strSQL.Append(" estq_produto_unidade uni, estq_familia fam, fatu_tributacao tri, estq_tipoproduto tp, fatu_ncm ncm");
            strSQL.Append(" where subg.idestq_subgrupo = p.estq_subgrupo_idestq_subgrupo");
            strSQL.Append(" and cc.idcusto_componente = p.custo_componente_idcusto_componente");
            strSQL.Append(" and cg.idcusto_componentegrupo = p.custo_componente_idgrupo_componente");
            strSQL.Append(" and uni.idestq_produto_unidade = p.estq_produto_unidade_idestq_produto_unidade");
            strSQL.Append(" and fam.idestq_familia = p.estq_familia_idestq_familia");
            strSQL.Append(" and tri.idfatu_tributacao = p.idfatu_tributacaoipi");
            strSQL.Append(" and tp.idestq_tipoproduto = p.estq_tipoproduto_idestq_tipoproduto");
            strSQL.Append(" and g.idestq_grupo = p.estq_subgrupo_estq_grupo_idestq_grupo");
            strSQL.Append(" and ncm.idfatu_ncm = p.fatu_ncm_idfatu_ncm");
            strSQL.Append(" and p.codigoproduto = '"+ codigoProduto.ToString()+ "'" );
            strSQL.Append(" order by p.descricaodetalhada");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport3(int idEstq_TipoProduto)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select p.*, subg.descricao as descricaosubgrupo, cc.descricao as descricaocustocomponente,");
            strSQL.Append(" cg.descricao as descricaocomponentegrupo, uni.unidade_abreviatura as unidadeproduto,");
            strSQL.Append(" g.descricao as descricaogrupo, ncm.nroncm as ncm,");
            strSQL.Append(" fam.descricao as descricaofamilia, tri.descricao as tributacao, tp.descricao as tipoproduto");
            strSQL.Append(" from estq_produto p, estq_subgrupo subg, custo_componente cc, custo_componentegrupo cg, estq_grupo g,");
            strSQL.Append(" estq_produto_unidade uni, estq_familia fam, fatu_tributacao tri, estq_tipoproduto tp, fatu_ncm ncm");
            strSQL.Append(" where subg.idestq_subgrupo = p.estq_subgrupo_idestq_subgrupo");
            strSQL.Append(" and cc.idcusto_componente = p.custo_componente_idcusto_componente");
            strSQL.Append(" and cg.idcusto_componentegrupo = p.custo_componente_idgrupo_componente");
            strSQL.Append(" and uni.idestq_produto_unidade = p.estq_produto_unidade_idestq_produto_unidade");
            strSQL.Append(" and fam.idestq_familia = p.estq_familia_idestq_familia");
            strSQL.Append(" and tri.idfatu_tributacao = p.idfatu_tributacaoipi");
            strSQL.Append(" and tp.idestq_tipoproduto = p.estq_tipoproduto_idestq_tipoproduto");
            strSQL.Append(" and g.idestq_grupo = p.estq_subgrupo_estq_grupo_idestq_grupo");
            strSQL.Append(" and ncm.idfatu_ncm = p.fatu_ncm_idfatu_ncm");
            strSQL.Append(" and p.estq_tipoproduto_idestq_tipoproduto = '" + idEstq_TipoProduto.ToString() + "'");
            strSQL.Append(" order by p.descricaodetalhada");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport4(int idEstq_Subgrupo)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select p.*, subg.descricao as descricaosubgrupo, cc.descricao as descricaocustocomponente,");
            strSQL.Append(" cg.descricao as descricaocomponentegrupo, uni.unidade_abreviatura as unidadeproduto,");
            strSQL.Append(" g.descricao as descricaogrupo, ncm.nroncm as ncm,");
            strSQL.Append(" fam.descricao as descricaofamilia, tri.descricao as tributacao, tp.descricao as tipoproduto");
            strSQL.Append(" from estq_produto p, estq_subgrupo subg, custo_componente cc, custo_componentegrupo cg, estq_grupo g,");
            strSQL.Append(" estq_produto_unidade uni, estq_familia fam, fatu_tributacao tri, estq_tipoproduto tp, fatu_ncm ncm");
            strSQL.Append(" where subg.idestq_subgrupo = p.estq_subgrupo_idestq_subgrupo");
            strSQL.Append(" and cc.idcusto_componente = p.custo_componente_idcusto_componente");
            strSQL.Append(" and cg.idcusto_componentegrupo = p.custo_componente_idgrupo_componente");
            strSQL.Append(" and uni.idestq_produto_unidade = p.estq_produto_unidade_idestq_produto_unidade");
            strSQL.Append(" and fam.idestq_familia = p.estq_familia_idestq_familia");
            strSQL.Append(" and tri.idfatu_tributacao = p.idfatu_tributacaoipi");
            strSQL.Append(" and tp.idestq_tipoproduto = p.estq_tipoproduto_idestq_tipoproduto");
            strSQL.Append(" and g.idestq_grupo = p.estq_subgrupo_estq_grupo_idestq_grupo");
            strSQL.Append(" and ncm.idfatu_ncm = p.fatu_ncm_idfatu_ncm");
            strSQL.Append(" and p.estq_subgrupo_idestq_subgrupo = '" + idEstq_Subgrupo.ToString() + "'");
            strSQL.Append(" order by p.descricaodetalhada");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        public string DataReport5(int idEstq_Grupo)
        {
            StringBuilder strSQL = new StringBuilder();


            //string sIndexador = EmcResources.ReadObject(this.lstIndice, EMCLibrary.EmcResources.TipoDados.Caracter, true);
            strSQL.Clear();
            strSQL.Append("select p.*, subg.descricao as descricaosubgrupo, cc.descricao as descricaocustocomponente,");
            strSQL.Append(" cg.descricao as descricaocomponentegrupo, uni.unidade_abreviatura as unidadeproduto,");
            strSQL.Append(" g.descricao as descricaogrupo, ncm.nroncm as ncm,");
            strSQL.Append(" fam.descricao as descricaofamilia, tri.descricao as tributacao, tp.descricao as tipoproduto");
            strSQL.Append(" from estq_produto p, estq_subgrupo subg, custo_componente cc, custo_componentegrupo cg, estq_grupo g,");
            strSQL.Append(" estq_produto_unidade uni, estq_familia fam, fatu_tributacao tri, estq_tipoproduto tp, fatu_ncm ncm");
            strSQL.Append(" where subg.idestq_subgrupo = p.estq_subgrupo_idestq_subgrupo");
            strSQL.Append(" and cc.idcusto_componente = p.custo_componente_idcusto_componente");
            strSQL.Append(" and cg.idcusto_componentegrupo = p.custo_componente_idgrupo_componente");
            strSQL.Append(" and uni.idestq_produto_unidade = p.estq_produto_unidade_idestq_produto_unidade");
            strSQL.Append(" and fam.idestq_familia = p.estq_familia_idestq_familia");
            strSQL.Append(" and tri.idfatu_tributacao = p.idfatu_tributacaoipi");
            strSQL.Append(" and tp.idestq_tipoproduto = p.estq_tipoproduto_idestq_tipoproduto");
            strSQL.Append(" and g.idestq_grupo = p.estq_subgrupo_estq_grupo_idestq_grupo");
            strSQL.Append(" and ncm.idfatu_ncm = p.fatu_ncm_idfatu_ncm");
            strSQL.Append(" and p.estq_subgrupo_estq_grupo_idestq_grupo = '" + idEstq_Grupo.ToString() + "'");
            strSQL.Append(" order by p.descricaodetalhada");

            //retorna string com consulta SQL
            return strSQL.ToString();

        }

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Estq_Produto obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.codigoProduto))
            {
                objErro = new Exception("O Código do Produto deve ser informada");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A Descrição do Produto deve ser informada");
                throw objErro;
            }


            if (obj.tributacaoIPI.idFatu_TributacaoIPI == 0)
            {
                objErro = new Exception("A Tributação de IPI deve ser informada");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.descricaodetalhada))
            {
                objErro = new Exception("A Descrição Detalhada deve ser informada");
                throw objErro;
            }

            if (obj.Estq_Grupo.idestq_grupo==0)
            {
                objErro = new Exception("O Grupo de Estoque deve ser informada");
                throw objErro;
            }
            if (obj.Estq_SubGrupo.idestq_subgrupo==0)
            {
                objErro = new Exception("O SubGrupo deve ser informada");
                throw objErro;
            }
            if (obj.ncm.idfatu_ncm==0)
            {
                objErro = new Exception("O NCM deve ser informada");
                throw objErro;
            }
            if (obj.origemMercadoria.idfatu_origemmercadoria==0)
            {
                objErro = new Exception("A Origem da mercadoria deve ser informada");
                throw objErro;
            }
            if (obj.tributacao.idfatu_tributacao==0)
            {
                objErro = new Exception("A Tributação de ICMS deve ser informada");
                throw objErro;
            }
            if (obj.tributacaoIPI.idFatu_TributacaoIPI==0)
            {
                objErro = new Exception("A Tributação de IPI deve ser informada");
                throw objErro;
            }
            if (obj.Estq_Familia.idestq_familia==0)
            {
                objErro = new Exception("A Familia do Produto deve ser informada");
                throw objErro;
            }
            if (obj.Estq_TipoProduto.idestq_tipoproduto==0)
            {
                objErro = new Exception("O Tipo do Produto deve ser informada");
                throw objErro;
            }
            if (obj.componenteCusto.idcusto_componente==0)
            {
                objErro = new Exception("O Componenete de Custo deve ser informada");
                throw objErro;
            }

            //if (obj.Estq_Grupo.idestq_grupo == 0)
            //{
            //    objErro = new Exception("O Grupo do Estoque deve ser informado");
            //    throw objErro;
            //}
        }

        #endregion
    }
}
