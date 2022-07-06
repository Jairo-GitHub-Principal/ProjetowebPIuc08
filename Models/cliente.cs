using System;
namespace Uc08Atv4jairoCesar.Models
{
    public class cliente
    {   
        public int idCliente {get; set;}
        public string nome{get; set;}
        public string cpf {get; set;}
        public DateTime datanascimento{get; set;}
        public string tel{get; set;}
        public string endereco{get; set;}
        public string email{get; set;}
        public string nomeUsuari{get;set;}
        public string senha{get; set;}
        public int identificadorCliente{get; set;} 
       
        
        public cliente(){
           
        }


    }
}