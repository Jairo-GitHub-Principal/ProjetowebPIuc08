
using System;
namespace Uc08Atv4jairoCesar.Models
{
    public class Servicos
    {
        public int idservico {get;set;}
       public string categoriaserv {get; set;}
       public string nomedoservico   {get; set;} 
       public int quantidadeserv {get;set;}

        public double valorunitario {get;set;}
         public double valortotal {get;set;}

         public int idclienteServico{get; set;}
       
        
       
    }
}