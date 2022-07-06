using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Uc08Atv4jairoCesar.Models
{
    public class contatosFaleconoscoRepository:Repository
    {

        public void cadastrarcontatomsg(contatosFaleconosco clie){

            conexao.Open();
            string querymsg = "insert into faleconosco(cliente,msg)values(@cliente,@msg); ";

            MySqlCommand comando = new MySqlCommand(querymsg,conexao);
            comando.Parameters.AddWithValue("@cliente",clie.Cliente);
            comando.Parameters.AddWithValue("@msg",clie.msgTexto);

            comando.ExecuteNonQuery();
            conexao.Close();
        }
        
    }
}