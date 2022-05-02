using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityDAO;
using EMCSecurityModel;

namespace EMCCadastroRN
{
    public class ContaCustoRN
    {
        //Variaveis de Configuração do Formato da Conta Custo
        int vTamMaximo = 0; //tamanho da conta custo no nivel 7
        int vNroNiveis = 0; // numero de niveis
        int vTamNV1 = 0; // tamanho no nivel 1
        int vTamNV2 = 0; // tamanho no nivel 2
        int vTamNV3 = 0; // tamanho no nivel 3
        int vTamNV4 = 0; // tamanho no nivel 4
        int vTamNV5 = 0; // tamanho no nivel 5
        int vTamNV6 = 0; // tamanho no nivel 6
        int vTamNV7 = 0; // tamanho no nivel 7
        string vMascara = "";

        int codEmpresa;

        ContaCustoDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;

        public ContaCustoRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            try
            {

                Conexao = pConexao;
                oOcorrencia = parOcorrencia;

                this.codEmpresa = idEmpresa;

                Parametro oParametro = new Parametro();
                ParametroDAO oParametroDAO = new ParametroDAO(Conexao);
                //verifica o parametro considera data valida para vencimento de parcelas.
                vTamMaximo = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAMANHO_CONTACUSTO"));
                vNroNiveis = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "NRONIVEIS_CONTACUSTO"));
                vTamNV1 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV1_CONTACUSTO"));
                vTamNV2 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV2_CONTACUSTO"));
                vTamNV3 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV3_CONTACUSTO"));
                vTamNV4 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV4_CONTACUSTO"));
                vTamNV5 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV5_CONTACUSTO"));
                vTamNV6 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV6_CONTACUSTO"));
                vTamNV7 = EmcResources.cInt(oParametroDAO.retParametro(idEmpresa, "EMCCADASTRO", "CONTACUSTO", "TAM_NV7_CONTACUSTO"));

            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

#region Metodos Publicos da Classe
        public DataTable pesquisaContaCusto(int empMaster, String codigoConta, string nome, Boolean todas)
        {
            DataTable dtCon = new DataTable();

            try
            {

                objBLL = new ContaCustoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.pesquisaContaCusto(empMaster, codigoConta, nome, todas);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public string montaMascara()
        {
            vMascara = "";
            StringBuilder _mascaraConta = new StringBuilder();
            _mascaraConta.Append('>');
            if (vNroNiveis >= 1)
            {
                _mascaraConta.Append(new string('A', vTamNV1));
            }
            if (vNroNiveis >= 2)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV2));
            }
            if (vNroNiveis >= 3)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV3));
            }
            if (vNroNiveis >= 4)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV4));
            }
            if (vNroNiveis >= 5)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV5));
            }
            if (vNroNiveis >= 6)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV6));
            }
            if (vNroNiveis >= 7)
            {
                _mascaraConta.Append(".");
                _mascaraConta.Append(new string('A', vTamNV7));
            }


            vMascara = _mascaraConta.ToString();

            return vMascara;
        }
        public DataTable ListaContaEmpresa()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContaCustoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaContaEmpresa();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaContaDespesa()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaContaDespesa();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaContaReceita()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaContaReceita();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaContaCusto()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.ListaContaCusto();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public DataTable ListaContaCusto(String SSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ContaCustoDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.dstRelatorio(SSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public void Atualizar(ContaCusto objContaCusto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContaCusto);

                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objContaCusto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public void Salvar(ContaCusto objContaCusto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContaCusto);

                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objContaCusto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public void Excluir(ContaCusto objContaCusto)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objContaCusto);

                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objContaCusto);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public ContaCusto ObterPor(ContaCusto objContaCusto)
        {
            ContaCusto oCta = new ContaCusto();
            try
            {

                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                oCta = objBLL.ObterPor(objContaCusto);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oCta;

        }
        public ContaCusto buscaContaAcima(ContaCusto objContaCusto)
        {
            ContaCusto oCta = new ContaCusto();

            try
            {

                objBLL = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
                oCta = objBLL.buscaContaAcima(objContaCusto);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oCta;

        }
#endregion

#region Metodos Privados da Classe
        //Verifica erros no objeto
       
        public Boolean verificaCodigo(ContaCusto oCusto)
        {
            Boolean flgCodigo = false;
            ContaCustoDAO oCustoDAO = new ContaCustoDAO(Conexao,oOcorrencia,codEmpresa);
            ContaCusto oCta = new ContaCusto();

            if (!String.IsNullOrEmpty(oCusto.codigoConta))
            {
                //verifica nivel 7 para nivel 6
                if (oCusto.codigoConta.Trim().Length == (vTamNV1+vTamNV2+vTamNV3+vTamNV4+vTamNV5+vTamNV6+vTamNV7) && 7<=vNroNiveis)
                {
                    //Validação de nível 6
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1+vTamNV2+vTamNV3+vTamNV4+vTamNV5+vTamNV6));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;
                }
                //verifica nivel 6 para nivel 5
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6) && 6<=vNroNiveis)
                {
                    //Validação de nivel 5
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;
                }
                //verifica nivel 5 para nivel 4
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5) && 5<=vNroNiveis)
                {
                    //Validação de nivel 4
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;

                }
                //verifica nivel 4 para nivel 3
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4) && 4<=vNroNiveis)
                {
                    //Validação de nivel 3
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2 + vTamNV3));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;
                }
                //verifica nivel 3 para nivel 2
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2 + vTamNV3) && 3<=vNroNiveis)
                {
                    //Validação de nivel 2
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1 + vTamNV2));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;
                }
                //verifica nivel 2 para nivel 1
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1 + vTamNV2) && 2<=vNroNiveis)
                {
                    //Validação de nivel 1
                    oCta.codigoConta = oCusto.codigoConta.Trim().Substring(0, (vTamNV1));
                    oCta = oCustoDAO.ObterPor(oCta);
                    if (!String.IsNullOrEmpty(oCta.codigoConta))
                        flgCodigo = true;
                }
                //verifica nivel 1 - não precisa ser verificado pois não tem nivel anterior
                else if (oCusto.codigoConta.Trim().Length == (vTamNV1) && 1<=vNroNiveis)
                {
                    //Validação de nivel 1
                    flgCodigo = true;
                }
                else
                {
                    //conta com tamanho invalido
                    flgCodigo = false;
                }


            }

            return flgCodigo;
        }

        public void VerificaDados(ContaCusto obj)
        {

            Exception objErro;

            if (String.IsNullOrEmpty(obj.descricao))
            {
                objErro = new Exception("A descrição da Conta deve ser preenchida.");
                throw objErro;
            }
  
            int tamConta = obj.codigoConta.Trim().Length;

            if ((tamConta != (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6 + vTamNV7)) &&
                (tamConta != (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6)) &&
                (tamConta != (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5)) &&
                (tamConta != (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4)) &&
                (tamConta != (vTamNV1 + vTamNV2 + vTamNV3)) &&
                (tamConta != (vTamNV1 + vTamNV2)) &&
                (tamConta != (vTamNV1)) ||
                (tamConta > (vTamNV1 + vTamNV2 + vTamNV3 + vTamNV4 + vTamNV5 + vTamNV6 + vTamNV7)) ||
                (tamConta < (vTamNV1)))
            {
                objErro = new Exception("Tamanho do código conta invalido");
                throw objErro;
            }

            if (!verificaCodigo(obj))
            {
                objErro = new Exception("Nivel acima da conta não cadastrado");
                throw objErro;
            }

            if ( ( obj.filial.idEmpresa == 0) && (obj.codigoConta.Trim().Length == vTamMaximo))
            {
                objErro = new Exception("Não foi definido uma filial para o centro de custo");
                throw objErro;
            }
            
        }

#endregion

    }
}
