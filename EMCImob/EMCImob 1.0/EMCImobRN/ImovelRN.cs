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
    public class ImovelRN
    {
        ImovelDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ImovelRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaImovel()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaImovel();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaImovelSimplificado(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                             int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioSimplificado(idTipoImovel, chkTipoImovel, idCarteiraImoveis, chkCarteiraImoveis, situacao, chkSituacao, idProprietario, chkProprietario, codigoImovel, idEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaImovelCompleto(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                             int idProprietario, bool chkProprietario, string  codigoImovel, int idEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioCompleto(idTipoImovel, chkTipoImovel, idCarteiraImoveis, chkCarteiraImoveis, situacao, chkSituacao, idProprietario, chkProprietario, codigoImovel, idEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaProprietario(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                             int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioProprietario(idTipoImovel, chkTipoImovel, idCarteiraImoveis, chkCarteiraImoveis, situacao, chkSituacao, idProprietario, chkProprietario, codigoImovel, idEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        
        public DataTable ListaImovelProprietario(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                             int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioImovelProprietario(idTipoImovel, chkTipoImovel, idCarteiraImoveis, chkCarteiraImoveis, situacao, chkSituacao, idProprietario, chkProprietario, codigoImovel, idEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaComodo(int idTipoImovel, bool chkTipoImovel, int idCarteiraImoveis, bool chkCarteiraImoveis, string situacao, bool chkSituacao,
                                             int idProprietario, bool chkProprietario, string codigoImovel, int idEmpresa)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorioComodo(idTipoImovel, chkTipoImovel, idCarteiraImoveis, chkCarteiraImoveis, situacao, chkSituacao, idProprietario, chkProprietario, codigoImovel, idEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }


        public DataTable pesquisaImovel(int empMaster, int idImovel, string codigoImovel, int idEmpresa, int idTipoImovel, int idCarteiraImoveis, string idCep, string cidade, string estado, string bairro,
                                        string rua, string numero, string complemento, bool chkTipoImovel, bool chkCarteiraImoveis)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaImovel(empMaster, idImovel, codigoImovel, idEmpresa, idTipoImovel, idCarteiraImoveis, idCep, cidade, estado, bairro, rua, numero,
                                                complemento, chkTipoImovel, chkCarteiraImoveis);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Imovel objImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objImovel);

                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(objImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Imovel objImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objImovel);

                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(objImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Imovel objImovel)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objImovel);

                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Excluir(objImovel);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Imovel ObterPor(Imovel objImovel)
        {
            try
            {
                //Valida informações a serem gravadas

                objBLL = new ImovelDAO(Conexao, oOcorrencia, codEmpresa);
                objImovel = objBLL.ObterPor(objImovel);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objImovel;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(Imovel obj)
        {

            Exception objErro;

            if (obj.tipoImovel.idTipoImovel == 0)
            {
                objErro = new Exception("Tipo Imóvel não pode ser nula");
                throw objErro;
            }
            if (obj.descricao.Trim().Length == 0)
            {
                objErro = new Exception("Descrição não pode ser nula");
                throw objErro;
            }
            if (obj.rua.Trim().Length == 0)
            {
                objErro = new Exception("Rua não pode ser nula");
                throw objErro;
            }
            if (obj.numero.Trim().Length == 0)
            {
                objErro = new Exception("Número não pode ser nulo");
                throw objErro;
            }
            if (obj.complemento.Trim().Length == 0)
            {
                objErro = new Exception("Complemento não pode ser nulo");
                throw objErro;
            }
            if (obj.bairro.Trim().Length == 0)
            {
                objErro = new Exception("Bairro não pode ser nulo");
                throw objErro;
            }
            if (obj.cidade.Trim().Length == 0)
            {
                objErro = new Exception("Cidade não pode ser nulo");
                throw objErro;
            }
            if (obj.estado.Trim().Length == 0)
            {
                objErro = new Exception("Estado não pode ser nulo");
                throw objErro;
            }
            if (obj.nroCep.Trim().Length == 0)
            {
                objErro = new Exception("CEP não pode ser nulo");
                throw objErro;
            }
            if (obj.anotacoes.Trim().Length == 0)
            {
                objErro = new Exception("Anotações não pode ser nulo");
                throw objErro;
            }
            if (obj.observacoes.Trim().Length == 0)
            {
                objErro = new Exception("Observações não pode ser nulo");
                throw objErro;
            }
            //if (obj.valorVenda == 0)
            //{
            //    objErro = new Exception("Valor Venda não pode ser nulo");
            //    throw objErro;
            //}
            //if (obj.valorAluguel == 0)
            //{
            //    objErro = new Exception("Valor Aluguel não pode ser nulo");
            //    throw objErro;
            //}
            //if (obj.valorCondominio == 0)
            //{
            //    objErro = new Exception("Calor Condomínio não pode ser nulo");
            //    throw objErro;
            //}
            if (obj.enderecoChave.Trim().Length == 0)
            {
                objErro = new Exception("Endereço Chave não pode ser nulo");
                throw objErro;
            }
            if (obj.matriculaCri.Trim().Length == 0)
            {
                objErro = new Exception("Matrícula não pode ser nula");
                throw objErro;
            }
            if (obj.areaConstruida == 0)
            {
                objErro = new Exception("Área Construída não pode ser nula");
                throw objErro;
            }

            //if (obj.fornecedor.idPessoa == 0)
            //{
            //    objErro = new Exception("Proprietário não pode ser nulo");
            //    throw objErro;
            //}
            if (obj.carteiraImoveis.idCarteiraImoveis == 0)
            {
                objErro = new Exception("Carteira Imóveis não pode ser nulo");
                throw objErro;
            }
            if (obj.contaCusto.idContaCusto == 0)
            {
                objErro = new Exception("Conta Custo não pode ser nulo");
                throw objErro;
            }
        }

        #endregion
    }
}
