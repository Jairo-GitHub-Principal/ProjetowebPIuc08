
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
    public class ServicosController:Controller
    {

         public IActionResult Servicos(){

        return View();
        }
         public IActionResult cadastrarOrcamento(){

        return View();
        }

[HttpPost]
          public IActionResult cadastrarOrcamento(Servicos serv){
              ServicosRepository sr = new ServicosRepository();
              sr.cadastrarOrcamento(serv);
              

        return View();
        }

         

        public IActionResult listarservicos(){

                 ServicosRepository sr=new ServicosRepository();
                 if(HttpContext.Session.GetInt32("idCliente") == null){
                     int ID = 0;
                     List<Servicos> servicoencontrado = sr.ListarServicos(ID);
                     return View(servicoencontrado);   
                 } else{
                                         // converção valida ou "(int)(HttpContext.Session.GetInt32("idCliente"))"                                   
             int idClienteSessao= Convert.ToInt32(HttpContext.Session.GetInt32("idCliente")); 
           
            List<Servicos> servicoencontrado = sr.ListarServicos(idClienteSessao);
             
             return View(servicoencontrado);       

                 }  

       
            
        
        }

        public IActionResult atualizaservico(int Id){
            ServicosRepository sr= new ServicosRepository();
            Servicos encontrado= sr.buscarPorId(Id);
            return View(encontrado);
        }

        [HttpPost]
          public IActionResult atualizaservico(Servicos atualizar){
            ServicosRepository sr= new ServicosRepository();
            sr.atualizarServico(atualizar);
            return RedirectToAction("listarservicos");
        }
        
    public IActionResult excluirservico(int Id){
        ServicosRepository sr = new ServicosRepository();
        sr.ExcluirServico(Id);
        return RedirectToAction("listarservicos");

    }
    
    
    }
}