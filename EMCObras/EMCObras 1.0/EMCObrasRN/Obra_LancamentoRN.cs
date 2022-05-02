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
    public class Obra_LancamentoRN
    {
        Obra_LancamentoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public Obra_LancamentoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
                objBLL = new Obra_LancamentoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaObraLancamento();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void atualizar(Obra_Lancamento objLacto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLacto);

                objBLL = new Obra_LancamentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objLacto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void salvar(Obra_Lancamento objLacto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLacto);

                objBLL = new Obra_LancamentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objLacto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void excluir(Obra_Lancamento objLacto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objLacto);

                objBLL = new Obra_LancamentoDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objLacto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Obra_Lancamento obterPor(Obra_Lancamento objLacto)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new Obra_LancamentoDAO(Conexao, oOcorrencia, codEmpresa);
                objLacto = objBLL.ObterPor(objLacto);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objLacto;

        }
          

        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        private void VerificaDados(Obra_Lancamento obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.nroDocuemnto))
            {
                objErro = new Exception("o Numero do Documento o deve ser informado");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.dataEntrada.ToString()))
            {
                objErro = new Exception("A Data de Entrada deve ser informada");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.dataDocumento.ToString()))
            {
                objErro = new Exception("A Data do documento deve ser informada");
                throw objErro;
            }
            if (obj.fornecedor.idPessoa<=0)
            {
                objErro = new Exception("O Fornecedor deve ser informado");
                throw objErro;
            }
            if (obj.obra.idObra_Cronograma <= 0)
            {
                objErro = new Exception("A obra deve ser informada");
                throw objErro;
            }
            if (obj.vlrDocumento <=0)
            {
                objErro = new Exception("O valor do documento deve ser informado");
                throw objErro;
            }

        }
        

        #endregion




    }
}
