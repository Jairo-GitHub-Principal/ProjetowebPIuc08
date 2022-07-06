using System;
using MySqlConnector;
namespace Uc08Atv4jairoCesar.Models
{
    public class admRepository
    {

        protected const string DadosDaConexao = "Database =InfoCelEletronics;Data Source=localhost; User id=root; ";

        
        protected MySqlConnection conexao = new MySqlConnection(DadosDaConexao);

        public adm admlogin(adm log){

            conexao.Open();
            adm admlogin = null;

            string queryloginadm = "SELECT idadmin,username,senha FROM admin WHERE username=@username AND senha=@senha";

            MySqlCommand comando = new MySqlCommand(queryloginadm,conexao);

            comando.Parameters.AddWithValue("@username",log.username);
            comando.Parameters.AddWithValue("@senha",log.senha);

            MySqlDataReader reader = comando.ExecuteReader();

            if(reader.Read()){
                 admlogin=new adm();

                log.idadmin=reader.GetInt32("idadmin");
                 
                 

                if(!reader.IsDBNull(reader.GetOrdinal("username"))){
                    log.username = reader.GetString("username");
                }

                if(!reader.IsDBNull(reader.GetOrdinal("senha"))){
                        log.senha=reader.GetString("senha");
                }

                
            }




            conexao.Close();
            return admlogin;


        }



        public void cadastraadmin(adm adm){// create
           
            String query = "INSERT INTO admin (username,senha) VALUES(@username,@senha);" ;
            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query,conexao);

            comando.Parameters.AddWithValue("@username",adm.username);
            
            comando.Parameters.AddWithValue("@senha",adm.senha);

            comando.ExecuteNonQuery();

            conexao.Close();
        }
    }
}