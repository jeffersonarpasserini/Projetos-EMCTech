using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using FirebirdSql.Data.FirebirdClient;

namespace EMCLibrary
{

    public class ConectaBanco
    {
        private string _servidorEndereco, _servidorUsuario, _servidorSenha, _servidorBD, _stringConexao, _bcoUtilizado;
        private MySqlConnection conMySQL = new MySqlConnection();
        private MySqlTransaction transMYSQL;

        private FbConnection conFirebird = new FbConnection();
        private FbTransaction transFirebird;

        public string stringConexao
        {
            get { return _stringConexao; }
            set { _stringConexao = value; }
        }
        public string servidorEndereco
        {
            get { return _servidorEndereco; }
            set { _servidorEndereco = value; }
        }
        public string servidorUsuario
        {
            get { return _servidorUsuario; }
            set { _servidorUsuario = value; }
        }
        public string servidorSenha
        {
            get { return _servidorSenha; }
            set { _servidorSenha = value; }
        }
        public string servidorBD
        {
            get { return _servidorBD; }
            set { _servidorBD = value; }
        }
        public string bcoUtilizado
        {
            get { return _bcoUtilizado; }
            set { _bcoUtilizado = value; }
        }

        public ConectaBanco()
        {
            ParametroBanco oParametro = new ParametroBanco();
            string bancoUtilizado = oParametro.strSelecionaBanco();
            this.bcoUtilizado = bancoUtilizado;

            if (bancoUtilizado == "MYSQL")
            {
                this.stringConexao = @oParametro.StrConnection();
            }
            else if (bancoUtilizado =="SQLSERVER")
            {
                this.stringConexao = @oParametro.StrConnection();
            }
            else if (bancoUtilizado == "FIREBIRD")
            {
                this.stringConexao = @oParametro.StrConnection();
            }
        }
        public bool conectar()
        {
            try
            {
                Boolean retorno = false;

                if (bcoUtilizado == "MYSQL")
                {
                    if ((conMySQL.State == ConnectionState.Broken) || (conMySQL.State == ConnectionState.Closed))
                    {
                        
                        if (this.stringConexao == "")
                            this.conMySQL.ConnectionString = "server=" + servidorEndereco + ";user id=" + servidorUsuario + ";password=" + servidorSenha + "; database=" + servidorBD;
                        else
                            this.conMySQL.ConnectionString = stringConexao;

                        this.conMySQL.Open();
                        retorno=true;
                        
                    }
                    else
                        retorno=true;
                }
                else if (bcoUtilizado == "FIREBIRD")
                {
                    if ((conFirebird.State == ConnectionState.Broken) || (conFirebird.State == ConnectionState.Closed))
                    {

                        if (this.stringConexao == "")
                            this.conFirebird.ConnectionString = "server=" + servidorEndereco + ";user id=" + servidorUsuario + ";password=" + servidorSenha + "; database=" + servidorBD;
                        else
                            this.conFirebird.ConnectionString = stringConexao;

                        this.conFirebird.Open();
                        retorno = true;

                    }
                    else
                        retorno = true;

                }

                return retorno;
            }
            catch
            {
                return false;
            }
        }
        public void fechar()
        {
            if (bcoUtilizado == "MYSQL")
            {
                if ((conMySQL.State == ConnectionState.Open) || (conMySQL.State == ConnectionState.Executing) || (conMySQL.State == ConnectionState.Fetching))
                {
                    conMySQL.Close();
                    conMySQL.Dispose();
                    conMySQL = null;
                }
            }
            else if (bcoUtilizado == "FIREBIRD")
            {
                conFirebird.Close();
                conFirebird.Dispose();
                conFirebird = null;
            }
        }
        public MySqlConnection getMysqlConection()
        {
            return this.conMySQL;
        }
        public FbConnection getFirebirdConection()
        {
            return this.conFirebird;
        }
        
    }

    public class ConectaBancoMySql
    {
        private string _servidorEndereco, _servidorUsuario, _servidorSenha, _servidorBD, _stringConexao, _bcoUtilizado;
        private MySqlConnection conMySQL = new MySqlConnection();
        private MySqlTransaction traMYSQL;

        public string stringConexao
        {
            get { return _stringConexao; }
            set { _stringConexao = value; }
        }
        public string servidorEndereco
        {
            get { return _servidorEndereco; }
            set { _servidorEndereco = value; }
        }
        public string servidorUsuario
        {
            get { return _servidorUsuario; }
            set { _servidorUsuario = value; }
        }
        public string servidorSenha
        {
            get { return _servidorSenha; }
            set { _servidorSenha = value; }
        }
        public string servidorBD
        {
            get { return _servidorBD; }
            set { _servidorBD = value; }
        }
        public string bcoUtilizado
        {
            get { return _bcoUtilizado; }
            set { _bcoUtilizado = value; }
        }

        public ConectaBancoMySql(string servEndereco, string servUsuario, string servSenha, string servBD)
        {
            this.servidorEndereco = servEndereco;
            this.servidorUsuario = servUsuario;
            this.servidorSenha = servSenha;
            this.servidorBD = servBD;
            this.bcoUtilizado = "MYSQL";
        }
        public ConectaBancoMySql(string stringConexao)
        {
            this.stringConexao = stringConexao;
            this.bcoUtilizado = "MYSQL";
        }
        public ConectaBancoMySql()
        {
            ParametroBanco oParametro = new ParametroBanco();
            this.stringConexao = @oParametro.StrConnection();
            this.bcoUtilizado = "MYSQL";
        }

        public bool conectar()
        {
            if ((conMySQL.State == ConnectionState.Broken) || (conMySQL.State == ConnectionState.Closed))
            {
                try
                {
                    if (this.stringConexao == "")
                        this.conMySQL.ConnectionString = "server=" + servidorEndereco + ";user id=" + servidorUsuario + ";password=" + servidorSenha + "; database=" + servidorBD;
                    else
                        this.conMySQL.ConnectionString = stringConexao;

                    this.conMySQL.Open();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
                return true;
        }
        public void fechar()
        {
            if ((conMySQL.State == ConnectionState.Open) || (conMySQL.State == ConnectionState.Executing) || (conMySQL.State == ConnectionState.Fetching))
            {
                conMySQL.Close();
                conMySQL.Dispose();
                conMySQL = null;
            }
        }
        public MySqlConnection getConexao()
        {
            return this.conMySQL;
        }
        public MySqlTransaction abreTransacao()
        {
             traMYSQL = conMySQL.BeginTransaction();
             return traMYSQL;
        }
        public void gravaTransacao()
        {
            traMYSQL.Commit();
        }
        public void cancelaTransacao()
        {
            traMYSQL.Rollback();
        } 


    }

    public class OperacaoBanco
    {
        private MySqlConnection Conexao = new MySqlConnection();
        
        private MySqlDataAdapter dap = new MySqlDataAdapter();
        private MySqlDataReader dataReaderMy;
        private MySqlCommand com;
        private DataTable dat = new DataTable();

        public OperacaoBanco(ConectaBancoMySql oConexao)
        {
            Conexao = oConexao.getConexao();
        }

        #region Metodos Publicos

        public MySqlDataReader Select(String query)
        {
            MySqlDataReader dadosObtidos = myDataReader(query);
            return dadosObtidos;
        }
        public DataTable SelectDatatable(String query)
        {
            DataTable mData = myDataTable(query);
            return mData;
        }
        public Boolean Insert(String query)
        {
            try
            {
                myCommand(query);
                return true;
            }
            catch(MySqlException erro)
            {
                throw erro;
                return false;
            }
        }
        public Boolean Update(String query)
        {
            try
            {
                
                myCommand(query);
                return true;
                
            }
            catch(MySqlException erro)
            {
                return false;
                throw erro;
               
            }
        }
        public Boolean Delete(String query)
        {
            try
            {
                myCommand(query);
                return true;
            }
            catch(MySqlException erro)
            {
                throw erro;
                return false;
            }
        }
        #endregion

        #region Metodos Privados
        private MySqlDataReader myDataReader(string sql)
        {
            try
            {
                this.com = new MySqlCommand(sql, Conexao);
                this.dataReaderMy = com.ExecuteReader();
                return this.dataReaderMy;
            }
            catch
            {
                return this.dataReaderMy;
            }
        }
        private DataTable myDataTable(string sql)
        {
            try
            {
                this.com = new MySqlCommand(sql, Conexao);
                this.com.CommandType = CommandType.Text;
                this.com.CommandText = sql;
                dap.SelectCommand = this.com;
                dap.Fill(dat);
                dap.Dispose();
                return dat;
            }
            catch
            {
                return dat;
            }
        }
        private bool myCommand(string sql)
        {
            try
            {
                this.com = new MySqlCommand(sql, Conexao);
                this.com.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException erro)
            {
                throw erro;
                return false;
            }
        }

        #endregion
    }

  
}
