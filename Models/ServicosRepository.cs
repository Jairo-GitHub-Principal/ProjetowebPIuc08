using System;
using System.Collections.Generic;
using MySqlConnector;
namespace Uc08Atv4jairoCesar.Models
{
    public class ServicosRepository:Repository
    {
        public void cadastrarOrcamento(Servicos serv){ // Create
            conexao.Open();
            string queryCadastro="INSERT INTO Servico (categoriaserv,nomedoservico,quantidade,cliente)VALUES(@categoriaserv,@nomeserv,@quantidade,@cliente);";

            MySqlCommand comando = new MySqlCommand(queryCadastro,conexao);

            comando.Parameters.AddWithValue("@categoriaserv",serv.categoriaserv);
            comando.Parameters.AddWithValue("@nomeserv",serv.nomedoservico);
            comando.Parameters.AddWithValue("@quantidade",serv.quantidadeserv);
             comando.Parameters.AddWithValue("@valorunitario",serv.valorunitario);
              comando.Parameters.AddWithValue("@valortotal",serv.valortotal);

                
                /* a condição if else abaixo cria uma condição na qual o usuari logado que cadastrar outro usuario, ele fica identificado na tabela cliente*/
                
                int idclieZ = 0;
                if(serv.idclienteServico > 0){ // se o idclieperfil for > 0, significa que a pessoa que esta fazendo o cadastro  esta logado no sistemae seu id foi enviado pela pagina de cadastro, nesse caso cadastrocliente
                      // e o valor do id do cliente vai ser enviado para prencher o campo idclieperfil e assim o cadastro vai ter uma identificação de quem o fez
                    comando.Parameters.AddWithValue("@cliente",serv.idclienteServico);
                }else{// se o idclieperfil for < 0 significa que o cliente não esta logado 

                     comando.Parameters.AddWithValue("@cliente",serv.idclienteServico=idclieZ );

                }

            comando.ExecuteNonQuery();
            conexao.Close();
        }


        public List<Servicos> ListarServicos(int idClienteSessao){//Read
                 
                conexao.Open();   

                List<Servicos>listadeservicos = new List<Servicos>();//%
               
               String querylistarservico="";
               if(idClienteSessao > 0){
                    querylistarservico = "SELECT * FROM Servico WHERE cliente="+idClienteSessao;
               }else{
                    querylistarservico = "SELECT * FROM Servico";
               }
               
               

                 MySqlCommand comando = new MySqlCommand(querylistarservico,conexao);

                MySqlDataReader reader = comando.ExecuteReader();
                while(reader.Read()){
                    Servicos servicosencontrados = new Servicos();

                    servicosencontrados.idservico=reader.GetInt32("idservico");

                    if(!reader.IsDBNull(reader.GetOrdinal("categoriaserv"))){
                        servicosencontrados.categoriaserv=reader.GetString("categoriaserv");
                    } 

                    if(!reader.IsDBNull(reader.GetOrdinal("nomedoservico"))){
                        servicosencontrados.nomedoservico=reader.GetString("nomedoservico");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("quantidade"))){
                        servicosencontrados.quantidadeserv=reader.GetInt32("quantidade");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("valorunitario"))){
                        servicosencontrados.valorunitario=reader.GetDouble("valorunitario");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("valortotal"))){
                        servicosencontrados.valortotal=reader.GetDouble("valortotal");
                    }
                     if(!reader.IsDBNull(reader.GetOrdinal("cliente"))){
                        servicosencontrados.idclienteServico=reader.GetInt32("cliente");
                    }


                    listadeservicos.Add(servicosencontrados);
                }

                conexao.Close();

            return listadeservicos;
        }

      



        public void atualizarServico(Servicos atualizar){ // Update
            conexao.Open();
            string queryAtualizarServico="UPDATE Servico SET categoriaserv=@categoriaserv,nomedoservico=@nomedoservico,quantidade=@quantidade,valorunitario=@valorunitario,valortotal=quantidade*@valorunitario WHERE idservico=@Id;";

            MySqlCommand comando = new MySqlCommand(queryAtualizarServico,conexao);
            
             comando.Parameters.AddWithValue("@Id",atualizar.idservico);
            comando.Parameters.AddWithValue("categoriaserv",atualizar.categoriaserv);
            comando.Parameters.AddWithValue("nomedoservico",atualizar.nomedoservico);
            comando.Parameters.AddWithValue("quantidade",atualizar.quantidadeserv);
            comando.Parameters.AddWithValue("valorunitario",atualizar.valorunitario);
            comando.Parameters.AddWithValue("valortotal",atualizar.valortotal);
             
             comando.ExecuteNonQuery();
            conexao.Close();
        }


        public void ExcluirServico(int Id){ //Delete
            conexao.Open();
            string queryEscluir="DELETE FROM Servico WHERE  idservico=@Id";

            MySqlCommand comando = new MySqlCommand(queryEscluir,conexao);
            comando.Parameters.AddWithValue("@Id",Id);
            comando.ExecuteNonQuery();

            conexao.Close();
        }


           
           
            public Servicos buscarPorId(int Id){ // Busca por Id, é nescessario para Update, e Delete
                conexao.Open();
                Servicos servicoid = new Servicos();
                string queryBuscaId="SELECT * FROM Servico WHERE idservico=@Id;";
                MySqlCommand comando = new MySqlCommand(queryBuscaId,conexao);

                comando.Parameters.AddWithValue("@Id",Id);

            MySqlDataReader reader = comando.ExecuteReader();
            if(reader.Read()){
               

                servicoid.idservico=reader.GetInt32("idservico");

                 if(!reader.IsDBNull(reader.GetOrdinal("categoriaserv"))){
                        servicoid.categoriaserv=reader.GetString("categoriaserv");
                    } 

                    if(!reader.IsDBNull(reader.GetOrdinal("nomedoservico"))){
                        servicoid.nomedoservico=reader.GetString("nomedoservico");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("quantidade"))){
                        servicoid.quantidadeserv=reader.GetInt32("quantidade");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("valorunitario"))){
                        servicoid.valorunitario=reader.GetDouble("valorunitario");
                    }

                    if(!reader.IsDBNull(reader.GetOrdinal("valortotal"))){
                        servicoid.valortotal=reader.GetDouble("valortotal");
                    }

            }

                conexao.Close();
                return servicoid;
                
            }


           


        
    }
}