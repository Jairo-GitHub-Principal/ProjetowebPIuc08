namespace Uc08Atv4jairoCesar.Models
{
    public class adm
    {
        cliente c = new cliente();
       
       public int idadmin{get; set;}
        public string username{get; set;}
        public string senha{get; set;}
        public string selperfiladm{get; set;}
        public string selperfilclie{get; set;}
        

        public adm(){
            selperfiladm = "admin";
            selperfilclie="clie";
          
           }


        
    }
}