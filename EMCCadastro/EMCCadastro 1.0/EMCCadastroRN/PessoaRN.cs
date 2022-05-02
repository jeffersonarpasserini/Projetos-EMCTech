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
    public class PessoaRN
    {
        PessoaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PessoaRN(ConectaBancoMySql pConexao,Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        public DataTable pesquisaPessoa(int empMaster, int idPessoa, string nome, string cnpj)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PessoaDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.pesquisaPessoa(empMaster, idPessoa, nome, cnpj);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable Listar()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                dtCon = objBLL.Listar();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        //Retorna DataSet com o conteúdo da consulta passada como parâmetro
        public DataTable Listar(String sSQL)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new PessoaDAO(Conexao, oOcorrencia,codEmpresa);
                dtCon = objBLL.dstRelatorio(sSQL);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        
        public void Atualizar(Pessoa objPessoa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPessoa);

                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Atualizar(objPessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
      
        public void Salvar(Pessoa objPessoa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPessoa);

                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Salvar(objPessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public void Excluir(Pessoa objPessoa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objPessoa);

                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                objBLL.Excluir(objPessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }
        public Pessoa ObterPor(Pessoa objPessoa)
        {
            Pessoa oPessoa = new Pessoa();
            oPessoa = objPessoa;
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                oPessoa = objBLL.ObterPor(oPessoa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            

            return oPessoa;
            

        }
        public Boolean verificaCNPJCPFUnico(Pessoa oPessoa)
        {
            Boolean verificaCNPJCPFUnico = true;
            try
            {
                objBLL = new PessoaDAO(Conexao,oOcorrencia,codEmpresa);
                verificaCNPJCPFUnico = objBLL.verificaCNPJCPFUnico(oPessoa);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return verificaCNPJCPFUnico;
        }
        #endregion

        #region Metodos Privados da Classe
        //verifica pessoa
        public void VerificaPessoa(Pessoa obj)
        {
            Exception objErro;
            if (!verificaCNPJCPFUnico(obj))
            {
                objErro = new Exception("CNPJ/CPF já existe em outra ficha cadastral");
                throw objErro;
            }
        }

        //Verifica erros no objeto
        public void VerificaDados(Pessoa obj)
        {

            Exception objErro;

            if (obj.nome.Trim().Length == 0)
            {
                objErro = new Exception("Nome da pessoa não pode ser nulo");
                throw objErro;
            }
            if (obj.nomeFantasia.Trim().Length == 0)
            {
                objErro = new Exception("Nome Fantasia não pode ser nulo");
                throw objErro;
            }
            if (obj.cnpjCpf == null || obj.cnpjCpf.Trim().Length == 0)
            {
                objErro = new Exception("O campo CNPJ/CPF é obrigatorio ");
                throw objErro;
            }
            else if (!EmcResources.validaCNPJCPF(obj.cnpjCpf))
            {
                objErro = new Exception("CNPJ/CPF invalido ");
                throw objErro;
            }
            if (String.IsNullOrEmpty(obj.email))
            {
                objErro = new Exception("Email não pode ser nulo");
                throw objErro;
            }

            if (!obj.email.Contains("@") || (!obj.email.Contains(".")))
            {
                objErro = new Exception ("Email Inválido, verifique novamente");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.cidade))
            {
                objErro = new Exception("Cidade não pode ser nula");
                throw objErro;
            }

            if (String.IsNullOrEmpty(obj.endereco))
            {
                objErro = new Exception("Endereço não pode ser nulo");
                throw objErro;
            }

            if (obj.bairro.Trim().Length == 0)
            {
                objErro = new Exception("Bairro não pode ser nulo");
                throw objErro;
            }

            if (obj.numero.Trim().Length == 0)
            {
                objErro = new Exception("Número não pode ser nulo");
                throw objErro;
            }
            if (obj.dataNascimento > DateTime.Now)
            {
                objErro = new Exception("Data de nascimento não pode ser superior a atual");
                throw objErro;
            }
        }
        

        #endregion

    }
}
