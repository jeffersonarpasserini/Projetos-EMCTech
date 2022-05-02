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
    public class EmpresaRN
    {
        EmpresaDAO objBLL;
        ConectaBancoMySql Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public EmpresaRN(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
        {
            Conexao = pConexao;
            oOcorrencia = parOcorrencia;
            codEmpresa = idEmpresa;
        }

        #region Metodos Publicos da Classe
        
        public DataTable Lista()
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                dtCon = objBLL.Lista();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }
        public DataTable ListaEmpresaNaoAutorizada(int idUsuario)
        {
            DataTable dtCon = new DataTable();

            try
            {
                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                dtCon = objBLL.ListaEmpresaNaoAutorizada(idUsuario);
            }
            catch (Exception erro)
            {
                throw erro;
            }
            return dtCon;
        }

        public void Atualizar(Empresa objEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEmpresa,"A");

                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                objBLL.Atualizar(objEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Salvar(Empresa objEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEmpresa,"I");

                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                objBLL.Salvar(objEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public void Excluir(Empresa objEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                VerificaDados(objEmpresa,"E");

                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                objBLL.Excluir(objEmpresa);
            }
            catch (Exception erro)
            {
                throw erro;
            }

        }

        public Empresa BuscaMatriz(string cnpj)
        {
            Empresa oEmpresa = new Empresa();
            try
            {
                
                objBLL = new EmpresaDAO(Conexao, oOcorrencia);
                oEmpresa = objBLL.BuscaMatriz(cnpj);

            }
            catch (Exception erro)
            {
                throw erro;
            }
            return oEmpresa;

        }
      
        public Empresa BuscaEmpMaster(int idEmpMaster)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);
                Empresa objEmpresa = new Empresa();
                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                objEmpresa = objBLL.BuscaEmpMaster(idEmpMaster);
                return objEmpresa;

            }
            catch (Exception erro)
            {
                throw erro;
            }
            

        }

        public Empresa ObterPor(Empresa objEmpresa)
        {
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                objEmpresa = objBLL.ObterPor(objEmpresa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return objEmpresa;

        }

        public bool ExisteCodigo(Empresa objEmpresa)
        {
            bool ExisteCodigo = false;
            try
            {
                //Valida informações a serem gravadas
                //VerificaDados(objCep);

                objBLL = new EmpresaDAO(Conexao,oOcorrencia);
                ExisteCodigo = objBLL.ExisteCodigo(objEmpresa);


            }
            catch (Exception erro)
            {
                throw erro;
            }
            return ExisteCodigo;

        }

        #endregion

        #region Metodos Privados da Classe
        
        //Verifica erros no objeto
        private void VerificaDados(Empresa obj, String Status)
        {

            Exception objErro;

            if (Status == "A" || Status == "E" || Status == "I")
            {
                //verifica codigo da empresa
                if (obj.idEmpresa == 0)
                {
                    objErro = new Exception("Número da Empresa não pode ser nulo");
                    throw objErro;
                }
            }

            if (Status == "A")
            {
                //verifica se empresa master existe
                Empresa oMaster = new Empresa();
                EmpresaDAO MasterDAO = new EmpresaDAO(Conexao,oOcorrencia);

                oMaster = MasterDAO.BuscaEmpMaster(obj.empMaster.idEmpresa);
                if (oMaster.idEmpresa == 0)
                {
                    objErro = new Exception("Empresa Master não cadastrada");
                    throw objErro;
                }

                //verifica se empresa master é valida
                //if (Convert.ToInt32(oMaster.empMaster.idEmpresa) != Convert.ToInt32(oMaster.empMaster.empMaster))
                //{
                //    objErro = new Exception("Uma empresa para ser master não pode depender de outra empresa");
                //    throw objErro;
                //}
            }

            if (Status == "A" || Status == "I")
            {
                //verifica se o CEP é Valido
                Cep oCep = new Cep("", "", "", "");
                CepDAO CepDAO = new CepDAO(Conexao,oOcorrencia,codEmpresa);
                oCep = CepDAO.ObterPor(obj.cep);

                if (oCep.idCep.Trim().Length == 0)
                {
                    objErro = new Exception("Cep não cadastrado");
                    throw objErro;
                }

                //verifica cnpj
                if (obj.cnpjcpf.Trim().Length == 0)
                {
                    objErro = new Exception("Preencher o Cnpj");
                    throw objErro;
                }

                if (obj.cnpjcpf.Trim().Length > 11)
                {
                    if (!EmcResources.validaCNPJCPF(obj.cnpjcpf))
                    {
                        objErro = new Exception("CNPJ Inválido");
                        throw objErro;
                    }
                }
                else
                {
                    if (!EmcResources.validaCNPJCPF(obj.cnpjcpf))
                    {
                        objErro = new Exception("CPF Inválido");
                        throw objErro;
                    }
                }

                //verifica razao social
                if (obj.razaoSocial.Trim().Length == 0)
                {
                    objErro = new Exception("Preencher a Razão Social");
                    throw objErro;
                }

                //verifica cep
                if (obj.cep.idCep.Trim().Length == 0)
                {
                    objErro = new Exception("Preencher o CEP");
                    throw objErro;
                }

                //verifica estado
                if (obj.estado.Trim().Length == 0)
                {
                    objErro = new Exception("Estado não pode ser nulo");
                    throw objErro;
                }
                
                if (obj.matrizFilial == "F" && obj.matriz.idEmpresa == 0)
                {
                    objErro = new Exception("Defina uma matriz para está filial");
                    throw objErro;
                }

                if (String.IsNullOrEmpty(obj.bairro))
                {
                    objErro = new Exception("O Bairro não pode ser nulo");
                    throw objErro;
                }
                if (String.IsNullOrEmpty(obj.cidade))
                {
                    objErro = new Exception("A Cidade não pode ser nula");
                    throw objErro;
                }
                if (String.IsNullOrEmpty(obj.endereco))
                {
                    objErro = new Exception("O Endereço não pode ser nulo");
                    throw objErro;
                }
                if (String.IsNullOrEmpty(obj.numero))
                {
                    objErro = new Exception("O Número não pode ser nulo");
                    throw objErro;
                }
            }

        }

        #endregion
    }
}
