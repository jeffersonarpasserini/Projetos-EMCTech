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
    public class PessoaDAO
    {
        ConectaBancoMySql parConexao;
        MySqlConnection Conexao;
        Ocorrencia oOcorrencia;
        int codEmpresa;

        public PessoaDAO(ConectaBancoMySql pConexao, Ocorrencia parOcorrencia, int idEmpresa)
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
            codEmpresa = idEmpresa;
        }


        public void Salvar(Pessoa objPessoa)
        {

            //Grava um novo registro de Pessoa
            MySqlTransaction Transacao = Conexao.BeginTransaction();
            try
            {
                Pessoa oPessoa = new Pessoa();
                oPessoa = Salvar(objPessoa, Conexao, Transacao);

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
        public Pessoa Salvar(Pessoa objPessoa, MySqlConnection Conexao, MySqlTransaction Transacao)
        {
            Int32 idPessoa = 0;
            //Grava um novo registro de Pessoa
            try
            {
                if (objPessoa.idPessoa == 0)
                {
                    
                    //busca o codigo do documento no banco de dados  apartir do prox. numero auto incremento
                    String strSQL2 = "select max(idpessoa) as ultimocodigo from pessoa " +
                                        "where codempresa = " + objPessoa.codEmpresa.ToString();

                    MySqlCommand Sqlcon2 = new MySqlCommand(@strSQL2, Conexao, Transacao);

                    MySqlDataReader drCon;
                    drCon = Sqlcon2.ExecuteReader();


                    while (drCon.Read())
                    {
                        idPessoa = EmcResources.cInt(drCon["ultimocodigo"].ToString());
                    }
                    objPessoa.idPessoa = (idPessoa+1);

                    drCon.Close();
                    drCon.Dispose();

                }

                geraOcorrencia(objPessoa, "I"); 

                //Monta comando para a gravação do registro
                String strSQL = "insert into pessoa (codempresa, idpessoa, nome, nomefantasia, " +
                                                    "cnpjcpf, nrorg, inscrestadual, endereco, numero, " +
                                                    "bairro, complemento, cidade, estado, idcep, dtanascimento, " +
                                                    "email, imagem, site, tipopessoa, inscrmunicipal ) " +
                                "values (@codempresa, @idpessoa, @nome, @nomefantasia, @cnpjcpf, @nrorg, @inscrestadual, " +
                                        "@endereco, @numero, @bairro, @complemento, @cidade, @estado, @idcep, " +
                                        "@dtanascimento, @email, @imagem, @site, @tipopessoa, @inscrmunicipal )";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao, Transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPessoa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objPessoa.idPessoa);
                Sqlcon.Parameters.AddWithValue("@nome", objPessoa.nome);
                Sqlcon.Parameters.AddWithValue("@nomefantasia", objPessoa.nomeFantasia);
                Sqlcon.Parameters.AddWithValue("@cnpjcpf", objPessoa.cnpjCpf);
                Sqlcon.Parameters.AddWithValue("@nrorg", objPessoa.nroRG);
                Sqlcon.Parameters.AddWithValue("@inscrestadual", objPessoa.InscrEstadual);
                Sqlcon.Parameters.AddWithValue("@endereco", objPessoa.endereco);
                Sqlcon.Parameters.AddWithValue("@numero", objPessoa.numero);
                Sqlcon.Parameters.AddWithValue("@bairro", objPessoa.bairro);
                Sqlcon.Parameters.AddWithValue("@complemento", objPessoa.complemento);
                Sqlcon.Parameters.AddWithValue("@cidade", objPessoa.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objPessoa.estado);
                Sqlcon.Parameters.AddWithValue("@idcep", objPessoa.idCep);
                Sqlcon.Parameters.AddWithValue("@dtanascimento", objPessoa.dataNascimento);
                Sqlcon.Parameters.AddWithValue("@email", objPessoa.email);
                Sqlcon.Parameters.AddWithValue("@imagem", objPessoa.imagem);
                Sqlcon.Parameters.AddWithValue("@site", objPessoa.site);
                Sqlcon.Parameters.AddWithValue("@tipopessoa", objPessoa.tipopessoa);
                Sqlcon.Parameters.AddWithValue("@inscrmunicipal", objPessoa.inscrMunicipal);
                
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, Transacao);

                return objPessoa;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
     
        }

        public void Atualizar(Pessoa objPessoa)
        {
            MySqlTransaction transacao = Conexao.BeginTransaction();
            //atualiza um registro
            try
            {
                geraOcorrencia(objPessoa, "A");
 
                //Monta comando para a gravação do registro
                String strSQL = "update pessoa set nome=@nome, nomefantasia=@nomefantasia, " +
                                                    "cnpjcpf=@cnpjcpf, nrorg=@nrorg, inscrestadual=@inscrestadual, " +
                                                    "endereco=@endereco, numero=@numero, " +
                                                    "bairro=@bairro, complemento=@complemento, cidade=@cidade, " +
                                                    "estado=@estado, idcep=@idcep, dtanascimento=@dtanascimento, " +
                                                    "email=@email, imagem=@imagem, site=@site, tipopessoa=@tipopessoa, inscrmunicipal=@inscrmunicipal " +
                                "where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPessoa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objPessoa.idPessoa);
                Sqlcon.Parameters.AddWithValue("@nome", objPessoa.nome);
                Sqlcon.Parameters.AddWithValue("@nomefantasia", objPessoa.nomeFantasia);
                Sqlcon.Parameters.AddWithValue("@cnpjcpf", objPessoa.cnpjCpf);
                Sqlcon.Parameters.AddWithValue("@nrorg", objPessoa.nroRG);
                Sqlcon.Parameters.AddWithValue("@inscrestadual", objPessoa.InscrEstadual);
                Sqlcon.Parameters.AddWithValue("@endereco", objPessoa.endereco);
                Sqlcon.Parameters.AddWithValue("@numero", objPessoa.numero);
                Sqlcon.Parameters.AddWithValue("@bairro", objPessoa.bairro);
                Sqlcon.Parameters.AddWithValue("@complemento", objPessoa.complemento);
                Sqlcon.Parameters.AddWithValue("@cidade", objPessoa.cidade);
                Sqlcon.Parameters.AddWithValue("@estado", objPessoa.estado);
                Sqlcon.Parameters.AddWithValue("@idcep", objPessoa.idCep);
                Sqlcon.Parameters.AddWithValue("@dtanascimento", objPessoa.dataNascimento);
                Sqlcon.Parameters.AddWithValue("@email", objPessoa.email);
                Sqlcon.Parameters.AddWithValue("@imagem", objPessoa.imagem);
                Sqlcon.Parameters.AddWithValue("@site", objPessoa.site);
                Sqlcon.Parameters.AddWithValue("@tipopessoa", objPessoa.tipopessoa);
                Sqlcon.Parameters.AddWithValue("@inscrmunicipal", objPessoa.inscrMunicipal);
                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
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

        public void Excluir(Pessoa objPessoa)
        {

            MySqlTransaction transacao = Conexao.BeginTransaction();
            //apaga registro de CEP
            try
            {
                geraOcorrencia(objPessoa, "E");    
                //Monta comando para a gravação do registro
                String strSQL = "delete from pessoa where codempresa = @codempresa and idpessoa = @idpessoa";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao,transacao);
                Sqlcon.Parameters.AddWithValue("@codempresa", objPessoa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", objPessoa.idPessoa);

                Sqlcon.ExecuteNonQuery();

                OcorrenciaDAO oOcoDAO = new OcorrenciaDAO(parConexao, codEmpresa);
                oOcoDAO.Salvar(oOcorrencia, transacao);

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
        public DataTable pesquisaPessoa(int empMaster, int idPessoa, string nome, string cnpj)
        {
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select p.* from pessoa p where p.codempresa = @codempresa ";

                if (idPessoa > 0)
                    strSQL += " and p.idpessoa = @idpessoa ";

                if (!String.IsNullOrEmpty(nome.Trim()))
                    strSQL += " and p.nome like @nome ";

                if (!String.IsNullOrEmpty(cnpj.Trim()))
                    strSQL += " and p.cnpjcpf = @cnpj ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", empMaster);
                Sqlcon.Parameters.AddWithValue("@idpessoa", idPessoa);
                Sqlcon.Parameters.AddWithValue("@nome", "%" + nome.Trim() + "%");
                Sqlcon.Parameters.AddWithValue("@cnpj", cnpj);


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
        public DataTable Listar()
        {

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from pessoa " + 
                                "where codempresa = " + codEmpresa.ToString() + " " +
                                "order by idpessoa";
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

        public DataTable dstRelatorio(String sSQL)
        {

            try
            {
                //Monta comando para a gravação do registro
                //String strSQL = "select * from pessoa order by idpessoa";
                string strSQL = sSQL.ToString();
                MySqlCommand Sqlcon = new MySqlCommand(strSQL, Conexao);
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


        public Pessoa ObterPor(Pessoa oPessoa)
        {
            MySqlDataReader drCon;

            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from pessoa Where ";

                //verifica se o atributo está vazio
                if (oPessoa.idPessoa > 0)
                {
                    strSQL += " codempresa = " + oPessoa.codEmpresa + " and idpessoa = " + oPessoa.idPessoa + " ";
                }
                else if (oPessoa.cnpjCpf != null && oPessoa.cnpjCpf.Trim().Length > 0)
                {
                    strSQL += " cnpjcpf = '" + oPessoa.cnpjCpf.Trim() + "' ";
                    strSQL += " and codempresa = " + oPessoa.codEmpresa.ToString();
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

               
                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    Pessoa objPessoa = new Pessoa();
                    objPessoa.codEmpresa = Convert.ToInt32(drCon["codempresa"]);
                    objPessoa.idPessoa = Convert.ToInt32(drCon["idpessoa"]);
                    objPessoa.nome = drCon["nome"].ToString();
                    objPessoa.nomeFantasia = drCon["nomefantasia"].ToString();
                    objPessoa.cnpjCpf = drCon["cnpjcpf"].ToString();
                    objPessoa.nroRG = drCon["nrorg"].ToString();
                    objPessoa.InscrEstadual = drCon["inscrestadual"].ToString();
                    objPessoa.endereco = drCon["endereco"].ToString();
                    objPessoa.numero = drCon["numero"].ToString();
                    objPessoa.bairro = drCon["bairro"].ToString();
                    objPessoa.complemento = drCon["complemento"].ToString();
                    objPessoa.cidade = drCon["cidade"].ToString();
                    objPessoa.estado = drCon["estado"].ToString();
                    objPessoa.idCep = drCon["idcep"].ToString();
                    objPessoa.dataNascimento = Convert.ToDateTime(drCon["dtanascimento"]);
                    objPessoa.email = drCon["email"].ToString();
                    objPessoa.imagem = drCon["imagem"].ToString();
                    objPessoa.site = drCon["site"].ToString();
                    objPessoa.tipopessoa = drCon["tipopessoa"].ToString();
                    objPessoa.inscrMunicipal = drCon["inscrmunicipal"].ToString();

                    drCon.Close();
                    drCon.Dispose();
                    drCon = null;

                    //carregando informações de cliente vinculado a pessoa
                    Cliente oCliente = new Cliente();
                    oCliente.codEmpresa = oPessoa.codEmpresa;
                    oCliente.idPessoa = oPessoa.idPessoa;
                    ClienteDAO oClienteDAO = new ClienteDAO(parConexao,oOcorrencia,codEmpresa);
                    objPessoa.cliente = oClienteDAO.ObterPor(oCliente);

                    //carregando informações de fornecedor vinculado a pessoa
                    Fornecedor oFornecedor = new Fornecedor();
                    oFornecedor.codEmpresa = oPessoa.codEmpresa;
                    oFornecedor.idPessoa = oPessoa.idPessoa;
                    FornecedorDAO oFornecedorDAO = new FornecedorDAO(parConexao,oOcorrencia,codEmpresa);
                    objPessoa.fornecedor = oFornecedorDAO.ObterPor(oFornecedor);
                    

                    return objPessoa;
                }

                drCon.Close();
                drCon.Dispose();
                Pessoa objPessoa1 = new Pessoa();
                return objPessoa1;

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
        public Pessoa ObterPessoa(Pessoa oPessoa)
        {
            MySqlDataReader drCon;
            try
            {
                //Monta comando para a gravação do registro
                String strSQL = "select * from pessoa Where codempresa=@codempresa and idpessoa=@idpessoa ";

                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@codempresa", oPessoa.codEmpresa);
                Sqlcon.Parameters.AddWithValue("@idpessoa", oPessoa.idPessoa);

                drCon = Sqlcon.ExecuteReader();

                while (drCon.Read())
                {
                    Pessoa objPessoa = new Pessoa();
                    objPessoa.codEmpresa = Convert.ToInt32(drCon["codempresa"]);
                    objPessoa.idPessoa = Convert.ToInt32(drCon["idpessoa"]);
                    objPessoa.nome = drCon["nome"].ToString();
                    objPessoa.nomeFantasia = drCon["nomefantasia"].ToString();
                    objPessoa.cnpjCpf = drCon["cnpjcpf"].ToString();
                    objPessoa.nroRG = drCon["nrorg"].ToString();
                    objPessoa.InscrEstadual = drCon["inscrestadual"].ToString();
                    objPessoa.endereco = drCon["endereco"].ToString();
                    objPessoa.numero = drCon["numero"].ToString();
                    objPessoa.bairro = drCon["bairro"].ToString();
                    objPessoa.complemento = drCon["complemento"].ToString();
                    objPessoa.cidade = drCon["cidade"].ToString();
                    objPessoa.estado = drCon["estado"].ToString();
                    objPessoa.idCep = drCon["idcep"].ToString();
                    objPessoa.dataNascimento = Convert.ToDateTime(drCon["dtanascimento"]);
                    objPessoa.email = drCon["email"].ToString();
                    objPessoa.imagem = drCon["imagem"].ToString();
                    objPessoa.site = drCon["site"].ToString();
                    objPessoa.tipopessoa = drCon["tipopessoa"].ToString();
                    objPessoa.inscrMunicipal = drCon["inscrmunicipal"].ToString();

                    //carregando informações de cliente vinculado a pessoa
                    Cliente oCliente = new Cliente();
                    objPessoa.cliente = oCliente;

                    //carregando informações de fornecedor vinculado a pessoa
                    Fornecedor oFornecedor = new Fornecedor();
                    objPessoa.fornecedor = oFornecedor;
                    
                    drCon.Close();
                    drCon.Dispose();

                    return objPessoa;
                }

                drCon.Close();
                drCon.Dispose();
                Pessoa objPessoa1 = new Pessoa();
                return objPessoa1;

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
        public Boolean verificaCNPJCPFUnico(Pessoa oPessoa)
        {
            MySqlDataReader drCon;
            Boolean verificaCNPJCPFUnico = true;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from pessoa Where ";

                //verifica se o atributo está vazio
                if (oPessoa.cnpjCpf != null && oPessoa.cnpjCpf.Trim().Length > 0)
                {
                    strSQL += " cnpjcpf = '" + oPessoa.cnpjCpf.Trim() + "' ";
                    strSQL += " and codempresa = " + oPessoa.codEmpresa.ToString();
                }
                
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);

                drCon = Sqlcon.ExecuteReader();


                while (drCon.Read())
                {
                    if (oPessoa.idPessoa != Convert.ToInt32(drCon["idpessoa"]))
                    {
                      verificaCNPJCPFUnico = false;   
                    }
                }
                drCon.Close();
                drCon.Dispose();
                return verificaCNPJCPFUnico;

            }
            catch (MySqlException erro)
            {
                throw erro;
            }
            finally
            {
                drCon=null;
            }
        }

        private void geraOcorrencia(Pessoa oPessoa, string flag)
        {
            try
            {
                string descricao = "";

                UsuarioDAO oUsrDAO = new UsuarioDAO(parConexao);
                oOcorrencia.usuario = oUsrDAO.ObterPor(oOcorrencia.usuario);
                oOcorrencia.chaveidentificacao = oPessoa.idPessoa.ToString();

                if (flag == "A")
                {

                    Pessoa oPes = new Pessoa();
                    oPes = ObterPor(oPessoa);

                    if (!oPes.Equals(oPessoa))
                    {
                        descricao = "Pessoa " + oPessoa.idPessoa + " foi alterada por " + oOcorrencia.usuario.nome + " - ";
                        if (!oPes.bairro.Equals(oPessoa.bairro))
                        {
                            descricao += " Bairro de " + oPes.bairro +" para " + oPessoa.bairro;
                        }
                        if (!oPes.cidade.Equals(oPessoa.cidade))
                        {
                            descricao += " Cidade de " + oPes.cidade + " para " + oPessoa.cidade;
                        }
                        if (!oPes.cnpjCpf.Equals(oPessoa.cnpjCpf))
                        {
                            descricao += " Cnpj/cpf de " + oPes.cnpjCpf + " para " + oPessoa.cnpjCpf;
                        }
                        if (!oPes.complemento.Equals(oPessoa.complemento))
                        {
                            descricao += " Complemento de " + oPes.complemento + " para " + oPessoa.complemento;
                        }
                        if (!oPes.dataNascimento.Equals(oPessoa.dataNascimento))
                        {
                            descricao += " Data Nasc/Fundação de " + oPes.dataNascimento + " para " + oPessoa.dataNascimento;
                        }
                        if (!oPes.email.Equals(oPessoa.email))
                        {
                            descricao += " Email de " + oPes.email + " para " + oPessoa.email;
                        }
                        if (!oPes.endereco.Equals(oPessoa.endereco))
                        {
                            descricao += " Endereco de " + oPes.endereco + " para " + oPessoa.endereco;
                        }
                        if (!oPes.estado.Equals(oPessoa.estado))
                        {
                            descricao += " Estado de " + oPes.estado + " para " + oPessoa.estado;
                        }
                        if (!oPes.idCep.Equals(oPessoa.idCep))
                        {
                            descricao += " CEP de " + oPes.idCep + " para " + oPessoa.idCep;
                        }
                        if (!oPes.InscrEstadual.Equals(oPessoa.InscrEstadual))
                        {
                            descricao += " Inscr Estadual de " + oPes.InscrEstadual + " para " + oPessoa.InscrEstadual;
                        }
                        if (!oPes.inscrMunicipal.Equals(oPessoa.inscrMunicipal))
                        {
                            descricao += " Inscr Municipal de " + oPes.inscrMunicipal + " para " + oPessoa.inscrMunicipal;
                        }
                        if (!oPes.nome.Equals(oPessoa.nome))
                        {
                            descricao += " Nome de " + oPes.nome + " para " + oPessoa.nome;
                        }
                        if (!oPes.nomeFantasia.Equals(oPessoa.nomeFantasia))
                        {
                            descricao += " Nome Fantasia de " + oPes.nomeFantasia + " para " + oPessoa.nomeFantasia;
                        }
                        if (!oPes.nroRG.Equals(oPessoa.nroRG))
                        {
                            descricao += " Nro RG de " + oPes.nroRG + " para " + oPessoa.nroRG;
                        }
                        if (!oPes.numero.Equals(oPessoa.numero))
                        {
                            descricao += " Nro Endereco de " + oPes.numero + " para " + oPessoa.numero;
                        }
                        if (!oPes.site.Equals(oPessoa.site))
                        {
                            descricao += " Site de " + oPes.site + " para " + oPessoa.site;
                        }
                        if (!oPes.tipopessoa.Equals(oPessoa.tipopessoa))
                        {
                            descricao += " Tipo Pessoa de " + oPes.tipopessoa + " para " + oPessoa.tipopessoa;
                        }

                    }

                }
                else if (flag == "I")
                {
                    descricao = "Pessoa : " + oPessoa.idPessoa + " - Nome " + oPessoa.nome +
                                "Nome Fantasia : " + oPessoa.nomeFantasia + " - CNPJ/CPF : " + oPessoa.cnpjCpf +
                                "Inscr Estadual : " + oPessoa.InscrEstadual + " - Inscr. Municipal : " + oPessoa.inscrMunicipal +
                                "Nro RG : " + oPessoa.nroRG + " - Tipo Pessoa : " + oPessoa.tipopessoa +
                                "Data Nasc/Fundação : " + oPessoa.dataNascimento + " - CNPJ/CPF : " + oPessoa.endereco +
                                "Numero : " + oPessoa.numero + " - Bairro : " + oPessoa.bairro +
                                "Complemento : " + oPessoa.complemento + " - Cidade : " + oPessoa.cidade +
                                "Estado : " + oPessoa.estado + " - Estado : " + oPessoa.estado +
                                "CEP : " + oPessoa.idCep + " - Email : " + oPessoa.email +
                                "Site : " + oPessoa.site + " foi incluida por " + oOcorrencia.usuario.nome;
                }
                else if (flag == "E")
                {
                    descricao = "Pessoa : " + oPessoa.idPessoa + " - Nome " + oPessoa.nome +
                                "Nome Fantasia : " + oPessoa.nomeFantasia + " - CNPJ/CPF : " + oPessoa.cnpjCpf +
                                "Inscr Estadual : " + oPessoa.InscrEstadual + " - Inscr. Municipal : " + oPessoa.inscrMunicipal +
                                "Nro RG : " + oPessoa.nroRG + " - Tipo Pessoa : " + oPessoa.tipopessoa +
                                "Data Nasc/Fundação : " + oPessoa.dataNascimento + " - CNPJ/CPF : " + oPessoa.endereco +
                                "Numero : " + oPessoa.numero + " - Bairro : " + oPessoa.bairro +
                                "Complemento : " + oPessoa.complemento + " - Cidade : " + oPessoa.cidade +
                                "Estado : " + oPessoa.estado + " - Estado : " + oPessoa.estado +
                                "CEP : " + oPessoa.idCep + " - Email : " + oPessoa.email +
                                "Site : " + oPessoa.site + " foi incluida por " + oOcorrencia.usuario.nome;

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
