
using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Uc08Atv4jairoCesar.Models
{
    public class clienteRepository:Repository


    {
        // C,R
         //const string DDconexao = "Database = InfoCelEletronics;Data Source = localhost; User Id = root; "; // string endereço do BD

          //MySqlConnection conexao = new MySqlConnection(DDconexao);
        public void cadastraCliente(cliente clieCad){// create
           
            
            String query = "INSERT INTO Cliente (nome,cpf,datanascimento,endereco,email,tel,usuario,senha,idclieperfil) VALUES(@nome,@cpf,@datanascimento,@endereco,@email,@tel,@usuario,@senha,@idclieperfil);" ;
            conexao.Open();

            MySqlCommand comando = new MySqlCommand(query,conexao);

            comando.Parameters.AddWithValue("@nome",clieCad.nome);
            comando.Parameters.AddWithValue("@cpf",clieCad.cpf);
            comando.Parameters.AddWithValue("@datanascimento",clieCad.datanascimento);
            comando.Parameters.AddWithValue("@endereco",clieCad.endereco);
            comando.Parameters.AddWithValue("@email",clieCad.email);
            comando.Parameters.AddWithValue("@tel",clieCad.tel);
            comando.Parameters.AddWithValue("@usuario",clieCad.nomeUsuari);
            comando.Parameters.AddWithValue("@senha",clieCad.senha);
                
                
                /* a condição if else abaixo cria uma condição na qual o usuari logado que cadastrar outro usuario, ele fica identificado na tabela cliente*/
                int n = 0;
                if(clieCad.identificadorCliente > 0){ // se o idclieperfil for > 0, significa que a pessoa que esta fazendo o cadastro não esta logado no sistema
                    comando.Parameters.AddWithValue("@idclieperfil",clieCad.identificadorCliente);
                }else{// se o idclieperfil for > 0 significa que o cliente esta logado e seu id foi enviado pela pagina de cadastro, nesse caso cadastrocliente
                      // e o valor do id do cliente vai ser enviado para prencher o campo idclieperfil e assim o cadastro vai ter uma identificação de quem o fez

                     comando.Parameters.AddWithValue("@idclieperfil",clieCad.identificadorCliente = n);

                }


            comando.ExecuteNonQuery();

            conexao.Close();
        }




                            // o parametro passado aqui para o metodo ListarCliente vai servir como referencia para 
                            // que o metodo traga do DB somente as informações que estiver relacionada com o ID do cliente
                            // logado que esta solicitando a lista de clientes
            public List<cliente> LisatarCliente(int idClienteSessao){ // Read

               
                    conexao.Open();

                     List<cliente> clienteCadastrado = new List<cliente>();

                    String query = "";
                    if(idClienteSessao > 0){
                     query = "SELECT * FROM Cliente WHERE idCliente="+idClienteSessao; // o codigo vai trazer somete as informações que estiver relacionado com idclientesessao
                    }else{
                        query = "SELECT * FROM Cliente";               
                        
                        }
                    
                     MySqlCommand comando = new MySqlCommand(query,conexao);
                    MySqlDataReader leitor = comando.ExecuteReader();

                    while(leitor.Read()){
                        cliente clieEncontrado = new cliente();

                         if(!leitor.IsDBNull(leitor.GetOrdinal("idCliente"))){    
                        clieEncontrado.idCliente=leitor.GetInt32("idCliente");
                        }

                        if(!leitor.IsDBNull(leitor.GetOrdinal("nome"))){    
                        clieEncontrado.nome=leitor.GetString("nome");
                        }


                        if(!leitor.IsDBNull(leitor.GetOrdinal("cpf")))
                            {clieEncontrado.cpf=leitor.GetString("cpf");
                             }

                             if(!leitor.IsDBNull(leitor.GetOrdinal("datanascimento")))
                             { clieEncontrado.datanascimento=leitor.GetDateTime("datanascimento");
                             }

                             if(!leitor.IsDBNull(leitor.GetOrdinal("endereco")))
                             { clieEncontrado.endereco=leitor.GetString("endereco");   
                             }
                                if(!leitor.IsDBNull(leitor.GetOrdinal("email")))
                             {   clieEncontrado.email=leitor.GetString("email");
                             }

                             if(!leitor.IsDBNull(leitor.GetOrdinal("tel")))
                             {   clieEncontrado.tel=leitor.GetString("tel");
                             }

                             if(!leitor.IsDBNull(leitor.GetOrdinal("usuario")))
                             {   clieEncontrado.nomeUsuari=leitor.GetString("usuario");
                             }

                             if(!leitor.IsDBNull(leitor.GetOrdinal("senha")))
                             {   clieEncontrado.senha=leitor.GetString("senha");
                             }

                             clienteCadastrado.Add(clieEncontrado);
                    }

                    conexao.Close();
        
                   
                    return clienteCadastrado;
                    
            }




        


        public void Update(cliente update){
            conexao.Open();
            string queryAtualizar = "UPDATE Cliente SET nome=@nome,cpf=@cpf,datanascimento=@datanascimento,endereco=@endereco,email=@email,tel=@tel,usuario=@usuario,senha=@senha WHERE idCliente=@Id";
            MySqlCommand comando = new MySqlCommand(queryAtualizar,conexao);
            comando.Parameters.AddWithValue("@Id",update.idCliente);
            comando.Parameters.AddWithValue("@nome",update.nome);
            comando.Parameters.AddWithValue("@cpf",update.cpf);
            comando.Parameters.AddWithValue("@datanascimento",update.datanascimento);
            comando.Parameters.AddWithValue("@endereco",update.endereco);
            comando.Parameters.AddWithValue("@email",update.email);
            comando.Parameters.AddWithValue("@tel",update.tel);
             comando.Parameters.AddWithValue("@usuario",update.nomeUsuari);
              comando.Parameters.AddWithValue("@senha",update.senha);
               
               comando.ExecuteNonQuery();
            

            conexao.Close();

        }

        public void Delete(cliente delete ){
         conexao.Open();
            string queryDelete = "DELETE  FROM Cliente WHERE idCliente=@idcliente";

            MySqlCommand comando = new MySqlCommand(queryDelete,conexao);

            comando.Parameters.AddWithValue("@idcliente",delete.idCliente);

            comando.ExecuteNonQuery();


         conexao.Close();
            
        }

        public cliente BuscarPorId(int idclie){

            conexao.Open();
            cliente clieEncontrado = new cliente();
            string queryBuscaPorId = "SELECT * FROM Cliente WHERE idCliente=@idCliente;";

            MySqlCommand comando= new MySqlCommand(queryBuscaPorId,conexao);

            comando.Parameters.AddWithValue("@idCliente",idclie);

            MySqlDataReader reader = comando.ExecuteReader();

            if(reader.Read()){
                
                clieEncontrado.idCliente=reader.GetInt32("idCliente");

                if(!reader.IsDBNull(reader.GetOrdinal("nome"))){
                    clieEncontrado.nome=reader.GetString("nome");
                }
                 if(!reader.IsDBNull(reader.GetOrdinal("cpf"))){
                    clieEncontrado.cpf=reader.GetString("cpf");
                }

                     if(!reader.IsDBNull(reader.GetOrdinal("datanascimento"))){
                clieEncontrado.datanascimento=reader.GetDateTime("datanascimento");
                     }

                if(!reader.IsDBNull(reader.GetOrdinal("endereco"))){                    
                clieEncontrado.endereco=reader.GetString("endereco");
                  }

                    if(!reader.IsDBNull(reader.GetOrdinal("tel"))){
                clieEncontrado.tel=reader.GetString("endereco");
                 }
                 if(!reader.IsDBNull(reader.GetOrdinal("usuario"))){
                clieEncontrado.nomeUsuari=reader.GetString("usuario");
                 }
                 if(!reader.IsDBNull(reader.GetOrdinal("senha"))){
                clieEncontrado.senha=reader.GetString("senha");
                 }

            }

            conexao.Close();

            return clieEncontrado;

    }

            public cliente ClienteLogin(cliente clieLog){ // login
          
            conexao.Open();
             cliente clie = null;

            String queryLogin = "SELECT * FROM Cliente WHERE usuario=@usuario AND senha=@senha";
            
            MySqlCommand comando = new MySqlCommand(queryLogin,conexao);

            comando.Parameters.AddWithValue("@usuario",clieLog.nomeUsuari);
            comando.Parameters.AddWithValue("@senha",clieLog.senha);
            
            MySqlDataReader reader = comando.ExecuteReader();
          

            if(reader.Read()){

                clie = new cliente();
                         if(!reader.IsDBNull(reader.GetOrdinal("idCliente"))){
                     clie.idCliente=reader.GetInt32("idCliente");
                      }  
                      if(!reader.IsDBNull(reader.GetOrdinal("nome"))){
                    clie.nome=reader.GetString("nome");
                  }         
                   if(!reader.IsDBNull(reader.GetOrdinal("usuario"))){
                    clie.nomeUsuari=reader.GetString("usuario"); 
                   }
                                
                  if(!reader.IsDBNull(reader.GetOrdinal("senha"))){
                    clie.senha=reader.GetString("senha");
                  }  


            }
            conexao.Close();
            return clie;
            

        }





           
                
        }
    }
