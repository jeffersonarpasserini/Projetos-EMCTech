using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using MySql.Data.MySqlClient;

using System.Data;



namespace Conexao_mysql

{

    class ConexaoMySql

    {

        private string _servidorEndereco, _servidorUsuario, _servidorSenha, _servidorBD;

        private MySqlConnection con = new MySqlConnection();

        private MySqlDataAdapter dap = new MySqlDataAdapter();

        private MySqlDataReader dataReaderMy;

        private MySqlCommand com;

        private DataTable dat = new DataTable();



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



        public ConexaoMySql(string servEndereco, string servUsuario, string servSenha, string servBD)

        {

            this.servidorEndereco = servEndereco;

            this.servidorUsuario = servUsuario;

            this.servidorSenha = servSenha;

            this.servidorBD = servBD;

        }



        public bool conectar()

        {

            if ((con.State == ConnectionState.Broken) || (con.State == ConnectionState.Closed))

            {

                try

                {

                    this.con.ConnectionString = "server=" + servidorEndereco + ";user id=" + servidorUsuario + ";password=" + servidorSenha + "; database=" + servidorBD;

                    this.con.Open();

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

            if ((con.State == ConnectionState.Open) || (con.State == ConnectionState.Executing) || (con.State == ConnectionState.Fetching))

            {

                con.Close();

                con.Dispose();

                con = null;

            }

        }



        public MySqlDataReader myDataReader(string sql)

        {

            try

            {

                this.conectar();

                this.com = new MySqlCommand(sql,con);

                this.dataReaderMy = com.ExecuteReader();

                return this.dataReaderMy;

            }

            catch

            {

                return this.dataReaderMy;

            }

        }



        public bool myComando(string sql)

        {

            try

            {

                this.conectar();

                this.com = new MySqlCommand(sql,con);

                this.com.ExecuteNonQuery();

                return true;

            }

            catch

            {

                return false;

            }



        }



        public DataTable myDataTable(string sql)

        {

            try

            {

                this.conectar();

                this.com = new MySqlCommand(sql, con);

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

    }

}

