using System;
using MySqlConnector;
namespace Uc08Atv4jairoCesar.Models
{
    public class Repository
    {
         protected const string DDconexao = "Database = InfoCelEletronics;Data Source = localhost; User Id = root; "; // string endereço do BD

          protected MySqlConnection conexao = new MySqlConnection(DDconexao);


         public void testeconexao(){
             string query= "";
                MySqlCommand comando = new MySqlCommand(query,conexao);
                conexao.Open();
                Console.WriteLine("conexão ok");
                conexao.Close();
             
         }

    }
}