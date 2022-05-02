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
    public class Obra_PrevisaoDespesaRN
    {

        Obra_PrevisaoDespesaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_PrevisaoDespesaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable listaPrevisaoDespesa(string Tipo, int id)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaObra_PrevisaoDespesa(Tipo, id);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public Decimal listaTotalDespesaTarefa(int idObra_CronogramaItem)
        {
            Decimal totalDespesaTarefa = 0;
            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                totalDespesaTarefa = objBLL.listaTotalDespesaTarefa(idObra_CronogramaItem);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return totalDespesaTarefa;
        }

        public Decimal listaTotalDespesaObra(int idObra)
        {
            Decimal totalDespesaObra = 0;
            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                totalDespesaObra = objBLL.listaTotalDespesaObra(idObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return totalDespesaObra;
        }

        public void atualizar(Obra_PrevisaoDespesa objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.atualizar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void salvar(Obra_PrevisaoDespesa objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.salvar(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void excluir(Obra_PrevisaoDespesa objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objObra);

                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.excluir(objObra);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_PrevisaoDespesa obterPor(Obra_PrevisaoDespesa objObra)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                objObra = objBLL.ObterPor(objObra);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objObra;

        }

        public DataTable listaResumoOrcamento(int idObraCronograma)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaResumoOrcamento(idObraCronograma);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable listaDespesasItens(int idObraCronogramaItem)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaDespesasItens(idObraCronogramaItem);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable listaModuloEtapaObra(int idObraModulo, int idObraEtapa, int idObraCronograma)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.listaModuloEtapaObra(idObraModulo, idObraEtapa, idObraCronograma);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        #region relatorio orcamentoObra
      
        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new Obra_PrevisaoDespesaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public string SinteticoObra(int idObraCronograma)
        {
            StringBuilder strSQL = new StringBuilder();
                       
            strSQL.Clear();
            strSQL.Append("SELECT * FROM secol.v_obra_etapa_modulo_tarefa"
                              + " where idObra_cronograma = '" + idObraCronograma + "'"
                              + " and idobra_tarefas > 0 "
                              +  " order by idobra_cronograma, idobra_etapa, idobra_modulo, idobra_tarefas");
                                
            return strSQL.ToString();

        }
     
        public string SinteticoObraEtapa(int idObraCronograma, int idObraEtapa)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("SELECT v.*, (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_etapa = '"+idObraEtapa+"')  as vlretapa, " 
	                          +" (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_cronograma = '"+idObraCronograma+"')  as vlrobra"
                              +" FROM secol.v_obra_etapa_modulo_tarefa as v"
                              + " where idObra_cronograma = '" + idObraCronograma + "'"
                              + " and idobra_etapa = '" + idObraEtapa + "'"
                              + " and idobra_tarefas > 0 "
                              + " order by idobra_cronograma, idobra_etapa, idobra_modulo, idobra_tarefas");

            return strSQL.ToString();

        }

        public string SinteticoObraEtapaModulo(int idObraCronograma, int idObraEtapa, int idObraModulo)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("SELECT v.*,(select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_etapa = '" + idObraEtapa + "')  as vlretapa, "
                              + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_cronograma = '" + idObraCronograma + "')  as vlrobra,"
                              + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_modulo = '" + idObraModulo + "')  as vlrmodulo"
                              + " FROM secol.v_obra_etapa_modulo_tarefa as v"
                              + " where idObra_cronograma = '" + idObraCronograma + "'"
                              + " and idobra_etapa = '" + idObraEtapa + "'"
                              + " and idobra_modulo = '" + idObraModulo + "'"
                              + " and idobra_tarefas > 0 "
                              + " order by idobra_cronograma, idobra_etapa, idobra_modulo, idobra_tarefas");

            return strSQL.ToString();

        }

        public string AnaliticoObra(int idObraCronograma)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select o.abreviacao, o.descricao as obra,"
                          + " p.idobra_cronograma,"
                          + " p.idobra_etapa,"
                          + " p.idobra_modulo,"
                          + " p.idobra_tarefas,"
                          + " e.descricao as etapa,"
                          + " m.descricao as modulo,"
                          + " t.descricao as tarefas,"
                          + " pr.codigoproduto,"
                          + " pr.descricao as produto,"
                          + " u.unidade_abreviatura as unidade,"
                          + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                          + " p.quantidade as qtdeproduto, p.vlrunitario, p.vlrdespesa"       
                        + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                          + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                          + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                        + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                          + " and i.idobra_cronograma = p.idobra_cronograma"
                          + " and m.idobra_modulo = p.idobra_modulo"
                          + " and e.idobra_etapa = p.idobra_etapa"
                          + " and t.idobra_tarefas = p.idobra_tarefas"
                          + " and pr.idestq_produto = p.idestq_produto"
                          + " and c.idcusto_componente = p.idcusto_componente"
                          + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                          + " and u.idestq_produto_unidade = p.idunidade"
                          + " and p.idobra_cronograma = '" +idObraCronograma+ "'"
                          + " order by p.idobra_cronograma, p.idobra_etapa, p.idobra_modulo, p.idobra_tarefas");

            return strSQL.ToString();

        }

        public string AnaliticoObraEtapa(int idObraCronograma, int idObraEtapa)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select o.abreviacao, o.descricao as obra,"
                          + " p.idobra_cronograma,"
                          + " p.idobra_etapa,"
                          + " p.idobra_modulo,"
                          + " p.idobra_tarefas,"
                          + " e.descricao as etapa,"
                          + " m.descricao as modulo,"
                          + " t.descricao as tarefas,"
                          + " pr.codigoproduto,"
                          + " pr.descricao as produto,"
                          + " u.unidade_abreviatura as unidade,"
                          + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                          + " p.quantidade as qtdeproduto, p.vlrunitario, p.vlrdespesa, "
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_etapa = '"+idObraEtapa+"')  as vlretapa,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_cronograma = '"+idObraCronograma+"')  as vlrobra"
                        + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                          + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                          + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                        + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                          + " and i.idobra_cronograma = p.idobra_cronograma"
                          + " and m.idobra_modulo = p.idobra_modulo"
                          + " and e.idobra_etapa = p.idobra_etapa"
                          + " and t.idobra_tarefas = p.idobra_tarefas"
                          + " and pr.idestq_produto = p.idestq_produto"
                          + " and c.idcusto_componente = p.idcusto_componente"
                          + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                          + " and u.idestq_produto_unidade = p.idunidade"
                          + " and p.idobra_cronograma = '" + idObraCronograma + "'"
                          + " and p.idobra_etapa = '" + idObraEtapa + "'"
                          + " order by p.idobra_cronograma, p.idobra_etapa, p.idobra_modulo, p.idobra_tarefas");

            return strSQL.ToString();

        }

        public string AnaliticoObraEtapaModulo(int idObraCronograma, int idObraEtapa, int idObraModulo)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select o.abreviacao, o.descricao as obra,"
                          + " p.idobra_cronograma,"
                          + " p.idobra_etapa,"
                          + " p.idobra_modulo,"
                          + " p.idobra_tarefas,"
                          + " e.descricao as etapa,"
                          + " m.descricao as modulo,"
                          + " t.descricao as tarefas,"
                          + " pr.codigoproduto,"
                          + " pr.descricao as produto,"
                          + " u.unidade_abreviatura as unidade,"
                          + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                          + " p.quantidade as qtdeproduto, p.vlrunitario, p.vlrdespesa, "
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_etapa = '" + idObraEtapa + "')  as vlretapa,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_cronograma = '" + idObraCronograma + "')  as vlrobra,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_modulo = '" + idObraModulo + "')  as vlrmodulo"
                        + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                          + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                          + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                        + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                          + " and i.idobra_cronograma = p.idobra_cronograma"
                          + " and m.idobra_modulo = p.idobra_modulo"
                          + " and e.idobra_etapa = p.idobra_etapa"
                          + " and t.idobra_tarefas = p.idobra_tarefas"
                          + " and pr.idestq_produto = p.idestq_produto"
                          + " and c.idcusto_componente = p.idcusto_componente"
                          + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                          + " and u.idestq_produto_unidade = p.idunidade"
                          + " and p.idobra_cronograma = '" + idObraCronograma + "'"
                          + " and p.idobra_etapa = '" + idObraEtapa + "'"
                          + " and p.idobra_modulo = '" + idObraModulo + "'"
                          + " order by p.idobra_cronograma, p.idobra_etapa, p.idobra_modulo, p.idobra_tarefas");

            return strSQL.ToString();

        }

        public string AnaliticoObraEtapaModuloTarefa(int idObraCronograma, int idObraEtapa, int idObraModulo, int idObraTarefas)
        {
            StringBuilder strSQL = new StringBuilder();

            strSQL.Clear();
            strSQL.Append("Select o.abreviacao, o.descricao as obra,"
                          + " p.idobra_cronograma,"
                          + " p.idobra_etapa,"
                          + " p.idobra_modulo,"
                          + " p.idobra_tarefas,"
                          + " e.descricao as etapa,"
                          + " m.descricao as modulo,"
                          + " t.descricao as tarefas,"
                          + " pr.codigoproduto,"
                          + " pr.descricao as produto,"
                          + " u.unidade_abreviatura as unidade,"
                          + " c.descricao as custocomponente, cg.descricao as grupocomponente, "
                          + " p.quantidade as qtdeproduto, p.vlrunitario, p.vlrdespesa,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_etapa = '" + idObraEtapa + "')  as vlretapa,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_cronograma = '" + idObraCronograma + "')  as vlrobra,"
                          + " (select sum(p.vlrdespesa) from obra_previsaodespesa p where p.idobra_modulo = '" + idObraModulo + "')  as vlrmodulo"
                        + " from obra_previsaodespesa p, obra_cronogramaitem i,estq_produto pr, "
                          + " custo_componente c, custo_componentegrupo cg, estq_produto_unidade u,"
                          + " obra_cronograma o, obra_etapa e, obra_modulo m, obra_tarefas t"
                        + " where i.idobra_cronogramaitem = p.idobra_cronogramaitem"
                          + " and i.idobra_cronograma = p.idobra_cronograma"
                          + " and m.idobra_modulo = p.idobra_modulo"
                          + " and e.idobra_etapa = p.idobra_etapa"
                          + " and t.idobra_tarefas = p.idobra_tarefas"
                          + " and pr.idestq_produto = p.idestq_produto"
                          + " and c.idcusto_componente = p.idcusto_componente"
                          + " and cg.idcusto_componentegrupo = p.idgrupo_componente"
                          + " and u.idestq_produto_unidade = p.idunidade"
                          + " and p.idobra_cronograma = '" + idObraCronograma + "'"
                          + " and p.idobra_etapa = '" + idObraEtapa + "'"
                          + " and p.idobra_modulo = '" + idObraModulo + "'"
                          + " and p.idobra_tarefas = '" + idObraTarefas + "'"
                          + " order by p.idobra_cronograma, p.idobra_etapa, p.idobra_modulo, p.idobra_tarefas");

            return strSQL.ToString();

        }

        #endregion
     
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_PrevisaoDespesa obj)
        {

            Exception objErro;

            if (obj.idCusto_Componente.idcusto_componente==0)
            {
                objErro = new Exception("O Componente de Custo deve deve ser informado");
                throw objErro;
            }

            if (obj.idObra_CronogramaItem.idObra_CronogramaItem==0)
            {
                objErro = new Exception("Id do Cronograma deve ser informado");
                throw objErro;
            }
            if (obj.idObra_Tarefa.idobra_tarefas==0)
            {
                objErro = new Exception("A tarefa deve ser informada");
                throw objErro;
            }

            if (obj.idEstq_Produto.idestq_produto==0)
            {
                objErro = new Exception("Produto ou Serviço deve ser informado");
                throw objErro;
            }
            if (obj.quantidade == 0)
            {
                objErro = new Exception("A Quantidade deve ser informada");
                throw objErro;
            }
            if (obj.vlrUnitario == 0)
            {
                objErro = new Exception("O Valor Unitario deve ser informado");
                throw objErro;
            }
            if (obj.vlrDespesa == 0)
            {
                objErro = new Exception("O valor da despesa deve ser informado");
                throw objErro;
            }

        }
        

        #endregion
    }
}
