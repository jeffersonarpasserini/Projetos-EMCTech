using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using EMCLibrary;
using EMCCadastroModel;
using EMCCadastroDAO;
using EMCSecurityModel;
using EMCFinanceiroDAO;
using EMCFinanceiroModel;

namespace EMCFinanceiroRN
{
    public class ControleCaixaRN
    {
        ControleCaixaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public ControleCaixaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe

        public DataTable ListaControleCaixa(CtaBancaria oConta)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaControleCaixa(oConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaFechamentoCaixa(CtaBancaria oConta, Usuario oUsuario)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaFechamentoCaixa(oConta, oUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaConfereCaixa(CtaBancaria oConta)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                dtCon = objBLL.ListaConfereCaixa(oConta);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public void Atualizar(ControleCaixa oCaixa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(oCaixa);

                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Atualizar(oCaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(ControleCaixa oCaixa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(oCaixa);

                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                objBLL.Salvar(oCaixa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public ControleCaixa ObterPor(ControleCaixa oCaixa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                oCaixa = objBLL.ObterPor(oCaixa);


            }
            catch (Exception erro)
            {
                throw erro;
            }

            return oCaixa;

        }
        #endregion

        #region Metodos Privados da Classe
        //Verifica erros no objeto
        public void VerificaDados(ControleCaixa obj)
        {

            Exception objErro;

            ControleCaixaDAO oCtrCaixaDAO = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
            ControleCaixa oCtrCaixa = new ControleCaixa();
            oCtrCaixa.dtHoraAbertura = obj.dtHoraAbertura;
            oCtrCaixa.contaBancaria = obj.contaBancaria;
            oCtrCaixa = oCtrCaixaDAO.ObterPor(oCtrCaixa);


            if (oCtrCaixa.idControleCaixa > 0 && oCtrCaixa.fechado == "N")
            {
                objErro = new Exception("O Caixa já está aberto.");
                throw objErro;
            }
            //if (obj.idFormulario < 0)
            //{
            //    objErro = new Exception("Codigo da Conta não pode ser nulo");
            //    throw objErro;
            //}

        }

        public void verificaCaixa(CtaBancaria oConta, DateTime dtPagamento, int idUsuario )
        {
            try
            {

                //bool retorno = true;

                if (oConta.contaCaixa == "S")
                {
                    //verifica a abertura do caixa para dta pagamento
                    ControleCaixaDAO oCaixaDAO = new ControleCaixaDAO(Conexao, oOcorrencia, codEmpresa);
                    ControleCaixa oCaixa = new ControleCaixa();
                    oCaixa.contaBancaria = oConta;
                    oCaixa.dtHoraAbertura = dtPagamento;
                    oCaixa = oCaixaDAO.ObterPor(oCaixa);

                    if (oCaixa.fechado == "S")
                    {
                        Exception oErro = new Exception("Caixa do dia : " + dtPagamento.ToString() + " está fechado ");
                        throw oErro;
                    }
                    if (String.IsNullOrEmpty(oCaixa.fechado))
                    {
                        Exception oErro = new Exception("Não existe abertura para o Caixa do dia : " + dtPagamento.ToString());
                        throw oErro;
                    }
                    if (oCaixa.usuarioResponsavel != idUsuario)
                    {
                        Exception oErro = new Exception("Caixa do dia : " + dtPagamento.ToString() + " não foi aberto pelo usuário atual");
                        throw oErro;
                    }

                 }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        #endregion
    }
}
