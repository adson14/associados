using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Trab2Mod
{
    public class ClassConexao
    {

        private SqlConnection con;
        
        private SqlDataAdapter da;
        private SqlCommand cmd;
        private DataTable dt;

        private string server = @"ADSON-PC\SQLEXPRESS";
        private string database = "AssociadosDePlantao";

        //metodo conectar

        public void Conectar()
        {
            if (con != null) 
                con.Close();

            //Define a string de conexão
            string conStr = String.Format("server={0}; Initial Catalog={1};Integrated Security=SSPI", server, database);

            try
            {
                con = new SqlConnection(conStr); //Recebe a string de conexão para conectar ao banco
                con.Open(); // abre a conexão
            }
            catch (Exception ex)
            {
                //Retorna mensagem ao usuário
                throw new Exception(ex.Message); // Retorna mensagem de erro ao usuário
            }

        }
        ////////////////////////
        public void ExecutarComandosSql(string comandoSql)
        {
            try
            {
                cmd = new SqlCommand(comandoSql, con); 
                cmd.ExecuteNonQuery(); 
                con.Close();
            }
            catch (Exception ex)
            {
                //Retorna mensagem ao usuário
                throw new Exception(ex.Message); // Retorna mensagem de erro ao usuário
            }

        }

        //////////////////////////////////////
        public DataTable RetDataTable(string sql)
        {
            try
            {
                dt = new DataTable();
                da = new SqlDataAdapter(sql, con); 
                da.Fill(dt);
                return dt; 
            }
            catch (Exception ex)
            {
                //Retorna mensagem ao usuário
                throw new Exception(ex.Message); // Retorna mensagem de erro ao usuário
            }

        }
      
      /// /////////////////////////////////////////////
      
        public void Desconectar()
        {
            
            string conStr = String.Format("server={0}; Initial Catalog={1};Integrated Security=SSPI", server, database);

            try
            {
                con = new SqlConnection(conStr); 
                con.Close(); // fecha a conexão
            }
            catch (Exception ex)
            {
                //Retorna mensagem ao usuário
                throw new Exception(ex.Message); // Retorna mensagem de erro ao usuário
            }
        }

    }
}
