using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using EMCLibrary;
using EMCCadastroModel;
using EMCSecurityModel;
using EMCSecurityDAO;

namespace EMCCadastroDAO
{
    public class EmpresaDAO 
    {

        MySqlConnection Conexao;
        ConectaBancoMySql parConexao;
        Ocorrencia oOcorrencia;
        
        public EmpresaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
                parConexao = oConexao;
                oOcorrencia = parOcorrencia;
            }
            else
            {
                parConexao = pConexao;
                Conexao = parConexao.getConexao();
                oOcorrencia = parOcorrencia;
            }

        }


        public void Salvar(Empresa objEmpresa)
        {
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, objEmpresa.idEmpresa);
            Ocorrencia ocoPessoa = new Ocorrencia();
           
            Int32 idPessoa = 0;

            //Grava um novo registro de Empresa
            try
            {

                geraOcorrencia(objEmpresa, "I");

                //Monta comando para a gravação do registro
                String strSQL = "insert into empresa (idEmpresa,EmpMaster,razaosocial, nomefantasia, " +
                                "cnpjcpf, inscrestadual, inscrmunicipal, endereco, numero, " +
                                "bairro, complemento, cidade, estado, logo, idCep, telefone, pessoa_codempresa, pessoa_idpessoa, " + 
                                "idgrupoempresa, idmatriz, matrizfilial)" +
                                "values (@idEmpresa, @EmpMaster, @razaosocial, @nomefantasia, @cnpjcpf, " +
                                "@inscrestadual, @inscrmunicipal,@endereco, @numero, @bairro, " +
                                "@complemento, @cidade, @estado, @logo, @Cep, @telefone, @pessoa_codempresa, @pessoa_idpessoa, "+ 
                                "@idgrupoempresa, @idmatriz, @matrizfilial)";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@idEmpresa", objEmpresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@EmpMaster", objEmpresa.empMaster.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@razaosocial", objEmpresa.razaoSocial);
                Sqlcon.Parameters.AddWithValue("@nomefantasia", objEmpresa.nomeFantasia);
                Sqlcon.Parameters.AddWithValue("@cnpjcpf", objEmpresa.cnpjcpf);
                Sqlcon.Parameters.AddWithValue("@inscrestadual", objEmpresa.inscrEstadual);
                Sqlcon.Parameters.AddWithValue("@inscrmunicipal", objEmpresa.inscrMunicipal);
                Sqlcon.Parameters.AddWithValue("@endereco", objEmpresa.endereco);
                Sqlcon.Parameters.AddWithValue("@numero", objEmpresa.numero);
                Sqlcon.Parameters.AddWithValue("@bairro", objEmpresa.bairro);
                Sqlcon.Parameters.AddWithValue("@complemento", objEmpresa.complemento);
                Sqlcon.Parameters.AddWithValue("@cidade", objEmpresa.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objEmpresa.estado);
                Sqlcon.Parameters.AddWithValue("@logo", objEmpresa.logo);
                Sqlcon.Parameters.AddWithValue("@Cep", objEmpresa.cep.idCep);
                Sqlcon.Parameters.AddWithValue("@telefone", objEmpresa.telefone);
                Sqlcon.Parameters.AddWithValue("@pessoa_codempresa", null);
                Sqlcon.Parameters.AddWithValue("@pessoa_idpessoa", null);
                Sqlcon.Parameters.AddWithValue("@idgrupoempresa", objEmpresa.grupoEmpresa.idGrupoEmpresa);
                if (objEmpresa.matriz.idEmpresa>0)
                    Sqlcon.Parameters.AddWithValue("@idmatriz", objEmpresa.matriz.idEmpresa);
                else
                    Sqlcon.Parameters.AddWithValue("@idmatriz", objEmpresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@matrizfilial", objEmpresa.matrizFilial);
                //abre conexao e executa o comando
                Sqlcon.ExecuteNonQuery();

                oOcoDAO.Salvar(oOcorrencia, Transacao);


                //GRAVA PESSOA
                Aplicativo oAplicativo = new Aplicativo();
                oAplicativo.nome = "EMCCadastro";
                ocoPessoa.aplicativo = oAplicativo;
                ocoPessoa.formulario = "frmPessoa";
                ocoPessoa.seqLogin = oOcorrencia.seqLogin;
                ocoPessoa.usuario = oOcorrencia.usuario;
                ocoPessoa.tabela = "pessoa";
                PessoaDAO oPessoaDAO = new PessoaDAO(parConexao, ocoPessoa, objEmpresa.idEmpresa);
                Pessoa oPessoa = new Pessoa();
                oPessoa = oPessoaDAO.Salvar(objEmpresa.pessoa, Conexao, Transacao);

                objEmpresa.pessoa = oPessoa;


                //ATUALIZA PESSOA NA EMPRESA..
                strSQL = "update empresa set pessoa_codempresa=@pessoa_codempresa, pessoa_idpessoa=@pessoa_idpessoa " +
                         "where idempresa=@idEmpresa";
                MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon2.Parameters.AddWithValue("@idEmpresa", objEmpresa.idEmpresa);
                Sqlcon2.Parameters.AddWithValue("@pessoa_codempresa", objEmpresa.pessoa.codEmpresa);
                Sqlcon2.Parameters.AddWithValue("@pessoa_idpessoa", objEmpresa.pessoa.idPessoa);
                Sqlcon2.ExecuteNonQuery();


                Transacao.Commit();
            }
            catch (MySqlException erro)
            {
                Transacao.Rollback();
                throw erro;
            }
            finally
            {
                Transacao.Dispose();
                Transacao = null;
            }
        }
        
        public void Atualizar(Empresa objEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();

            //atualiza um registro de CEP
            try
            {
                geraOcorrencia(objEmpresa, "A");

                //Monta comando para a gravação do registro
                String strSQL = "update empresa set razaosocial = @razaosocial, " +
                                                    " nomefantasia = @nomefantasia, " +
                                                    " cnpjcpf = @cnpjcpf, " +
                                                    " inscrestadual = @inscrestadual, " +
                                                    " inscrmunicipal = @inscrmunicipal, " +
                                                    " endereco = @endereco, " +
                                                    " numero = @numero, " +
                                                    " bairro = @bairro, " +
                                                    " complemento = @complemento, " +
                                                    " cidade = @cidade, " +
                                                    " estado = @estado, " +
                                                    " logo = @logo, " +
                                                    " idcep = @cep, " +
                                                    " telefone = @telefone, " +
                                                    " empmaster = @EmpMaster, " +
                                                    " matrizfilial = @matrizfilial " +
                                                    " Where idEmpresa = @idEmpresa ";
                                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEmpresa", objEmpresa.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@razaosocial", objEmpresa.razaoSocial);
                Sqlcon.Parameters.AddWithValue("@nomefantasia", objEmpresa.nomeFantasia);
                Sqlcon.Parameters.AddWithValue("@cnpjcpf", objEmpresa.cnpjcpf);
                Sqlcon.Parameters.AddWithValue("@inscrestadual", objEmpresa.inscrEstadual);
                Sqlcon.Parameters.AddWithValue("@inscrmunicipal", objEmpresa.inscrMunicipal);
                Sqlcon.Parameters.AddWithValue("@endereco", objEmpresa.endereco);
                Sqlcon.Parameters.AddWithValue("@numero", objEmpresa.numero);
                Sqlcon.Parameters.AddWithValue("@bairro", objEmpresa.bairro);
                Sqlcon.Parameters.AddWithValue("@complemento", objEmpresa.complemento);
                Sqlcon.Parameters.AddWithValue("@cidade", objEmpresa.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objEmpresa.estado);
                Sqlcon.Parameters.AddWithValue("@logo", objEmpresa.logo);
                Sqlcon.Parameters.AddWithValue("@cep", objEmpresa.cep.idCep);
                Sqlcon.Parameters.AddWithValue("@telefone", objEmpresa.telefone);
                Sqlcon.Parameters.AddWithValue("@EmpMaster", objEmpresa.empMaster.idEmpresa);
                Sqlcon.Parameters.AddWithValue("@matrizfilial", objEmpresa.matrizFilial);
                Sqlcon.ExecuteNonQuery();


                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, objEmpresa.idEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


                transacao.Commit();
            }
            catch (MySqlException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }

        }

        public void Excluir(Empresa objEmpresa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP

            try
            {
                geraOcorrencia(objEmpresa, "E");

                //Monta comando para a gravação do registro
                String strSQL = "delete from empresa where idempresa = @idEmpresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, transacao);
                Sqlcon.Parameters.AddWithValue("@idEmpresa", objEmpresa.idEmpresa);

                Sqlcon.ExecuteNonQuery();


                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, objEmpresa.idEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);


                transacao.Commit();

            }
            catch (MySqlException erro)
            {
                transacao.Rollback();
                throw erro;
            }
            finally
            {
                transacao.Dispose();
                transacao = null;
            }

        }

        public DataTable Lista()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select e.* from empresa e order by e.idempresa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);


                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();
                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }
        public DataTable ListaEmpresaNaoAutorizada(int idUsuario)
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "SELECT * FROM empresa e " + 
                                "where e.idempresa not in (select idempresa from usuarioempresa p where p.idusuario=@idusuario);";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@idusuario", idUsuario);


                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);
                daCon.Dispose();
                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public Empresa BuscaEmpMaster(int idEmpMaster)
        {
            MySqlDataReader drCon;

            try
            {

                Empresa oEmp = new Empresa();

                String strSQL = "";

                if (idEmpMaster > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from empresa Where idEmpresa = '" + idEmpMaster + "' ";

                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    drCon = Sqlcon.ExecuteReader();


                    while (drCon.Read())
                    {


                        Empresa oEmpMaster = new Empresa();
                        Int32 nroEmpMaster = Convert.ToInt32(drCon["EmpMaster"]);
                        oEmpMaster.idEmpresa = Convert.ToInt32(nroEmpMaster);


                        Cep oCep = new Cep();
                        if (drCon["idCep"].ToString() == "")
                            oCep.idCep = "";
                        else
                            oCep.idCep = drCon["idCep"].ToString();


                        Pessoa oPessoa = new Pessoa();

                        oEmp = new Empresa(Convert.ToInt32(drCon["idempresa"]),
                                                          oEmpMaster,
                                                          drCon["razaosocial"].ToString(),
                                                          drCon["nomefantasia"].ToString(),
                                                          drCon["cnpjcpf"].ToString(),
                                                          drCon["inscrestadual"].ToString(),
                                                          drCon["inscrmunicipal"].ToString(),
                                                          drCon["endereco"].ToString(),
                                                          drCon["numero"].ToString(),
                                                          drCon["bairro"].ToString(),
                                                          drCon["complemento"].ToString(),
                                                          drCon["cidade"].ToString(),
                                                          oCep,
                                                          drCon["estado"].ToString(),
                                                          drCon["logo"].ToString(),
                                                          drCon["telefone"].ToString(),
                                                          oPessoa
                                                          );

                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;

                        CepDAO oCepDao = new CepDAO(parConexao, oOcorrencia, oEmp.idEmpresa);
                        oCep = oCepDao.ObterPor(oCep);

                        if (oEmp.idEmpresa != oEmp.empMaster.idEmpresa)
                        {
                            Exception erro = new Exception("Empresa não pode ser Empresa Master");
                            throw erro;
                        }

                        return oEmp;
                    }

                }

               
                drCon = null;
                return oEmp;
            }
            catch (MySqlException oErro)
            {
                throw oErro;
            }
            finally
            {
                drCon = null;
            }
            

        }

        public Empresa BuscaMatriz(string cnpj)
        {
            MySqlDataReader drCon;
            Empresa oMatriz = new Empresa();
            string strSQL = "";

            try
            {

                strSQL = "select * from empresa where substring(cnpjcpf,1,8) = @cnpjcpf and matrizfilial='M' ";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@cnpjcpf", cnpj.Substring(0,8));                    
                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    oMatriz.idEmpresa = EmcResources.cInt(drCon["idempresa"].ToString());
                }
                drCon.Close();
                drCon.Dispose();

                oMatriz = ObterPor(oMatriz);
               
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }
            return oMatriz;

        }

        public Empresa ObterPor(Empresa oEmpresa)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "";

                //verifica se o atributo está vazio
                if (oEmpresa.idEmpresa > 0)
                {


                    //Monta comando para a gravação do registro
                    strSQL = "select distinct e.*, m.razaosocial as mrazao, m.nomefantasia as mfantasia, " +
                                          " m.cnpjcpf as mcnpj, mtz.idempresa as idmatriz " +
                            " from empresa e, empresa m, empresa mtz, cep c " + 
                            " where m.idempresa = e.empmaster and mtz.idempresa = e.idmatriz " +
                            "   and e.idempresa =" + oEmpresa.idEmpresa;
                    MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                    
                    drCon = Sqlcon.ExecuteReader();


                    while (drCon.Read())
                    {
                        Empresa oEmpMaster = new Empresa();
                        oEmpMaster.idEmpresa = EmcResources.cInt(drCon["empmaster"].ToString());
                        oEmpMaster.razaoSocial = drCon["mrazao"].ToString();
                        oEmpMaster.nomeFantasia = drCon["mfantasia"].ToString();
                        oEmpMaster.cnpjcpf = drCon["mcnpj"].ToString();

                        Cep oCep = new Cep();

                        if (drCon["idCep"].ToString() == "")
                            oCep.idCep = "";
                        else
                            oCep.idCep = drCon["idCep"].ToString();

                        Pessoa oPessoa = new Pessoa();
                        oPessoa.codEmpresa = Convert.ToInt32(drCon["pessoa_codempresa"].ToString());
                        oPessoa.idPessoa = Convert.ToInt32(drCon["pessoa_idpessoa"].ToString());

                        GrupoEmpresa oGrupo = new GrupoEmpresa();
                        oGrupo.idGrupoEmpresa = EmcResources.cInt(drCon["idgrupoempresa"].ToString());

                        Empresa oMatriz = new Empresa();
                        oMatriz.idEmpresa = EmcResources.cInt(drCon["idmatriz"].ToString());


                        Empresa objRetorno = new Empresa(Convert.ToInt32(drCon["idempresa"]),
                                                          oEmpMaster,
                                                          drCon["razaosocial"].ToString(),
                                                          drCon["nomefantasia"].ToString(),
                                                          drCon["cnpjcpf"].ToString(),
                                                          drCon["inscrestadual"].ToString(),
                                                          drCon["inscrmunicipal"].ToString(),
                                                          drCon["endereco"].ToString(),
                                                          drCon["numero"].ToString(),
                                                          drCon["bairro"].ToString(),
                                                          drCon["complemento"].ToString(),
                                                          drCon["cidade"].ToString(),
                                                          oCep,
                                                          drCon["estado"].ToString(),
                                                          drCon["logo"].ToString(),
                                                          drCon["telefone"].ToString(),
                                                          oPessoa
                                                          );

                        objRetorno.grupoEmpresa = oGrupo;
                        objRetorno.matriz = oMatriz;
                        objRetorno.matrizFilial = drCon["matrizfilial"].ToString();

                        drCon.Close();
                        drCon.Dispose();

                        CepDAO oCepDao = new CepDAO(parConexao,oOcorrencia,objRetorno.idEmpresa);
                        oCep = oCepDao.ObterPor(oCep);
                        objRetorno.cep = oCep;

                        PessoaDAO oPessoaDAO = new PessoaDAO(parConexao,oOcorrencia,objRetorno.idEmpresa);
                        oPessoa = oPessoaDAO.ObterPessoa(oPessoa);
                        objRetorno.pessoa = oPessoa;

                        GrupoEmpresaDAO oGrupoDAO = new GrupoEmpresaDAO(parConexao, oOcorrencia,objRetorno.idEmpresa);
                        objRetorno.grupoEmpresa = oGrupoDAO.ObterPor(objRetorno.grupoEmpresa);
                    
                        return objRetorno;
                    }

                    drCon.Close();
                    drCon.Dispose();
                }

                
                Empresa objEmpresa = new Empresa();
                return objEmpresa;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon = null;
            }

        }

        public bool ExisteCodigo(Empresa oEmpresa)
        {
            try
            {

                String strSQL = "";
                //verifica se o atributo está vazio
                if (oEmpresa.idEmpresa > 0)
                {
                    //Monta comando para a gravação do registro
                    strSQL = "select * from empresa Where idEmpresa = " +
                             oEmpresa.idEmpresa + "' ";
                }
                else
                {
                    Exception oErro = new Exception("Informe o código da empresa");
                    throw oErro;
                }

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                MySqlDataReader drCon;
                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    if (!drCon.IsDBNull(0))
                    {
                        drCon.Close();
                        drCon.Dispose();
                        drCon = null;
                        return true;
                    }
                }
                drCon.Close();
                drCon.Dispose();
                drCon = null;
                return false;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        private void geraOcorrencia(Empresa oEmpresa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oEmpresa.idEmpresa.ToString();

                if (flag == "A")
                {

                    Empresa oEmp = new Empresa();
                    oEmp = ObterPor(oEmpresa);

                    if (!oEmp.Equals(oEmpresa))
                    {
                        descricao = "Empresa : " + oEmpresa.idEmpresa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oEmp.bairro.Equals(oEmpresa.bairro))
                        {
                            descricao += " Bairro de " + oEmp.bairro + " para " + oEmpresa.bairro;
                        }
                        if (!oEmp.cep.idCep.Equals(oEmpresa.cep.idCep))
                        {
                            descricao += " CEP de " + oEmp.cep.idCep + " para " + oEmpresa.cep.idCep;
                        }
                        if (!oEmp.cidade.Equals(oEmpresa.cidade))
                        {
                            descricao += " Cidade de " + oEmp.cidade + " para " + oEmpresa.cidade;
                        }
                        if (!oEmp.cnpjcpf.Equals(oEmpresa.cnpjcpf))
                        {
                            descricao += " CNPJ/CPF de " + oEmp.cnpjcpf + " para " + oEmpresa.cnpjcpf;
                        }
                        if (!oEmp.complemento.Equals(oEmpresa.complemento))
                        {
                            descricao += " Complemento de " + oEmp.complemento + " para " + oEmpresa.complemento;
                        }
                        if (!oEmp.endereco.Equals(oEmpresa.endereco))
                        {
                            descricao += " Endereco de " + oEmp.endereco + " para " + oEmpresa.endereco;
                        }
                        if (!oEmp.estado.Equals(oEmpresa.estado))
                        {
                            descricao += " Estado de " + oEmp.estado + " para " + oEmpresa.estado;
                        }
                        if (!oEmp.inscrEstadual.Equals(oEmpresa.inscrEstadual))
                        {
                            descricao += " Inscr.Estadual de " + oEmp.inscrEstadual + " para " + oEmpresa.inscrEstadual;
                        }
                        if (!oEmp.inscrMunicipal.Equals(oEmpresa.inscrMunicipal))
                        {
                            descricao += " Inscr Municipal de " + oEmp.inscrMunicipal + " para " + oEmpresa.inscrMunicipal;
                        }
                        if (!oEmp.nomeFantasia.Equals(oEmpresa.nomeFantasia))
                        {
                            descricao += " Nome Fantasia de " + oEmp.nomeFantasia + " para " + oEmpresa.nomeFantasia;
                        }
                        if (!oEmp.numero.Equals(oEmpresa.numero))
                        {
                            descricao += " Numero Endereco de " + oEmp.numero + " para " + oEmpresa.numero;
                        }
                        if (!oEmp.razaoSocial.Equals(oEmpresa.razaoSocial))
                        {
                            descricao += " Razão Social de " + oEmp.razaoSocial + " para " + oEmpresa.razaoSocial;
                        }
                        if (!oEmp.telefone.Equals(oEmpresa.telefone))
                        {
                            descricao += " Telefone de " + oEmp.telefone + " para " + oEmpresa.telefone;
                        }
                    }
                }
                else if (flag == "I")
                {
                    descricao = "Empresa nro : " + oEmpresa.idEmpresa + " - Razao Social : " + oEmpresa.razaoSocial +
                                " Nome Fantasia : " + oEmpresa.nomeFantasia + " - CNPJ/CPF : " + oEmpresa.cnpjcpf +
                                " Inscr Estadual : " + oEmpresa.inscrEstadual + " - Inscr Municipal : " + oEmpresa.inscrMunicipal +
                                " Endereco : " + oEmpresa.endereco + " - Numero : " + oEmpresa.numero +
                                " Bairro : " + oEmpresa.bairro + " - Complemento : " + oEmpresa.complemento +
                                " Cidade : " + oEmpresa.cidade + " - Estado : " + oEmpresa.estado +
                                " CEP : " + oEmpresa.cep.idCep + " - telefone : " + oEmpresa.telefone +
                                " Pessoa : " + oEmpresa.pessoa.idPessoa + " - " + oEmpresa.pessoa.nome +         
                                " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = " Empresa nro : " + oEmpresa.idEmpresa + " - Razao Social : " + oEmpresa.razaoSocial +
                                " Nome Fantasia : " + oEmpresa.nomeFantasia + " - CNPJ/CPF : " + oEmpresa.cnpjcpf +
                                " Inscr Estadual : " + oEmpresa.inscrEstadual + " - Inscr Municipal : " + oEmpresa.inscrMunicipal +
                                " Endereco : " + oEmpresa.endereco + " - Numero : " + oEmpresa.numero +
                                " Bairro : " + oEmpresa.bairro + " - Complemento : " + oEmpresa.complemento +
                                " Cidade : " + oEmpresa.cidade + " - Estado : " + oEmpresa.estado +
                                " CEP : " + oEmpresa.cep.idCep + " - telefone : " + oEmpresa.telefone +
                                " Pessoa : " + oEmpresa.pessoa.idPessoa + " - " + oEmpresa.pessoa.nome +
                                " foi excluída por " + oOcorrencia.usuario.nome;
                }
                oOcorrencia.data_hora = DateTime.Now;
                descricao += " em " + oOcorrencia.data_hora.ToString();

                oOcorrencia.descricao = descricao;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }

        }


    }
}
