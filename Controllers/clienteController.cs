using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Uc08Atv4jairoCesar.Models;

namespace Uc08Atv4jairoCesar.Controllers
{
    public class clienteController:Controller
    {
        

public IActionResult CadastroCliente(){
    
    return View();
}

[HttpPost]

        public IActionResult CadastroCliente( cliente clieCad){
            clienteRepository cr = new clienteRepository();
            cr.cadastraCliente(clieCad);



                return RedirectToAction("LoginCliente");
        }

         public IActionResult LoginCliente(){

                 return View();
        }

        [HttpPost]
         public IActionResult LoginCliente(cliente L)
         {

             clienteRepository cr = new clienteRepository();
            cliente userSession= cr.ClienteLogin(L);

            if(userSession == null)
                {
                    
                   ViewBag.msg ="Usuario não encontrado";
                   return RedirectToAction("CadastroCliente");
               }
             else 
             {   
                    HttpContext.Session.SetString("senha",userSession.senha);
                    HttpContext.Session.SetInt32("idCliente",userSession.idCliente);
                    HttpContext.Session.SetString("n",userSession.nome);
                   
                    ViewBag.msg ="Cliente logado con sucesso";
                      return RedirectToAction("Index","Home");
             }
             
             
               
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // limpar os dados da sessaão
            

            // redirecionamento login 
            return View("LoginCliente");
        }

//_____________________FIM_LOGOUT_____________________________________        
        

       
       

            public IActionResult Cadastro(){

                return View();
            }



        public IActionResult ListarCliente(){
             clienteRepository clienteEncontrado = new clienteRepository();
           
                
                
             if(HttpContext.Session.GetInt32("idCliente")==null){ // cliente não logado
             int ID = 0;
                List<cliente>clienteLista = clienteEncontrado.LisatarCliente(ID);
            return View(clienteLista);
             }
             else{ 
                   int idClienteSessao= Convert.ToInt32(HttpContext.Session.GetInt32("idCliente")); 
                List<cliente>clienteLista = clienteEncontrado.LisatarCliente(idClienteSessao);
            return View(clienteLista);

             }
   
              
        }



        public IActionResult AtualizarCliente( int Id){

            
            clienteRepository cr = new clienteRepository();
            cliente clienteEncontrado = cr.BuscarPorId(Id);

            return View(clienteEncontrado);
        }

        [HttpPost]
        public IActionResult AtualizarCliente(cliente clieUpdate ){    
            clienteRepository cr = new clienteRepository(); 
            cr.Update(clieUpdate); 
            return RedirectToAction("ListarCliente");

        }

        public IActionResult delete(int Id){
            clienteRepository cr=new clienteRepository();
            cliente usuarioEncontrado =  cr.BuscarPorId(Id);

            if(usuarioEncontrado.idCliente > 0){
                cr.Delete(usuarioEncontrado);
            }else{
                ViewBag.msg="usuario não encontrado";
            }


            return RedirectToAction("ListarCliente");
        }





       
        
    }
}