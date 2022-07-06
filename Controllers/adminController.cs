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
    public class adminController:Controller
    {

        public IActionResult adminlogin(){


                return View();
        }

        [HttpPost]

        public IActionResult adminlogin(adm log){
            admRepository ar = new admRepository(); 
            adm usersession=ar.admlogin(log);

            if(usersession == null){

                ViewData["msg"]="voce não tem autorização para acessar esse local";
                
            }else{
                HttpContext.Session.SetString("Senha",log.senha);
                HttpContext.Session.SetInt32("Id",log.idadmin);
                  HttpContext.Session.SetString("usuarioADM",log.username);
               
                 
                 return RedirectToAction("Index","Home");
                  
            }
                return View();
        }

        public IActionResult logoutadm(){
            HttpContext.Session.Clear();

        return RedirectToAction("adminlogin");
        }



        public IActionResult admincadastro(){

            return View();
        }



        [HttpPost]
        public IActionResult admincadastro(adm cadastrarAdm){
            admRepository ar = new admRepository();
            ar.cadastraadmin(cadastrarAdm);
            return RedirectToAction("Index","Home");

        }


        
    }
}