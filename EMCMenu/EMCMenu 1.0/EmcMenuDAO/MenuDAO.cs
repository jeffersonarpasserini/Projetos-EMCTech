using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using EMCLibrary;
using EmcMenuModel;


namespace EmcMenuDAO
{
    public class MenuDAO
    {
        
        MySqlConnection Conexao;
        //MySqlConnection Conexao;

        public MenuDAO(ConectaBancoMySql pConexao)
        {
            if (pConexao == null)
            {
                ConectaBancoMySql oConexao = new ConectaBancoMySql();
                oConexao.conectar();
                Conexao = oConexao.getConexao();
            }
            else
            {
                Conexao = pConexao.getConexao();
            }

        }

        public DataTable BuscaMenu(String sistema, int idusuario, int nivel, int menupai)
        {

            try
            {
                //Monta comando para a gravação do registro
                string strSQL = "";
                if (nivel == 2)
                {
                    strSQL = "select * from menuusuario where idmenusistema > 9999 and modulo = @sistema and idusuario = @idusuario and nivel = @nivel and menupai = @pai order by ordem";
                }
                else
                    strSQL = "select * from menuusuario where idmenusistema < 900 and modulo = @sistema and idusuario = @idusuario and nivel = @nivel and menupai = @pai order by ordem";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@sistema", sistema);
                Sqlcon.Parameters.AddWithValue("@idusuario", idusuario);
                Sqlcon.Parameters.AddWithValue("@nivel", nivel);
                Sqlcon.Parameters.AddWithValue("@pai", menupai);


                MySqlDataAdapter daCon = new MySqlDataAdapter();
                DataTable dtCon = new DataTable();

                daCon.SelectCommand = Sqlcon;
                daCon.Fill(dtCon);

                return dtCon;
            }
            catch (MySqlException erro)
            {
                throw erro;
            }
        }

        public MenuModel ObterForm(int Usuario, String Modulo, int MenuCodigo)
        {
            MySqlDataReader drCon;
            try
            {

                //Monta comando para a gravação do registro
                String strSQL = "select * from menuusuario Where idusuario = @idusuario and modulo = @modulo and idmenusistema = @menu";
                MySqlCommand Sqlcon = new MySqlCommand(@strSQL, Conexao);
                Sqlcon.Parameters.AddWithValue("@menu", MenuCodigo);
                Sqlcon.Parameters.AddWithValue("@idusuario", Usuario);
                Sqlcon.Parameters.AddWithValue("@modulo", Modulo);

                drCon = Sqlcon.ExecuteReader();

                MenuModel objMenu = new MenuModel();
                while (drCon.Read())
                {
                    objMenu.idUsuario = int.Parse(drCon["idusuario"].ToString());
                    objMenu.idUsuario = int.Parse(drCon["idusuario"].ToString());
                    objMenu.descricao = drCon["descricao"].ToString();
                    objMenu.nNamespace = drCon["namespace"].ToString();
                    objMenu.endereco = drCon["endereco"].ToString();
                    objMenu.urlimagem = drCon["urlimagem"].ToString();
                    objMenu.itemseguranca = drCon["itemseguranca"].ToString();
                    objMenu.indicadorabertura = drCon["indicadorabertura"].ToString();
                    objMenu.ordem = int.Parse(drCon["ordem"].ToString());
                    objMenu.menupai = int.Parse(drCon["menupai"].ToString());
                    objMenu.nivel = int.Parse(drCon["nivel"].ToString());
                }

                drCon.Close();
                return objMenu;

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
    
    }
}
