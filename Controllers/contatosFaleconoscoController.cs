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
    public class contatosFaleconoscoController:Controller
    {
        public IActionResult contatosFaleconosco(int id){

    return View();
}

[HttpPost]
public IActionResult contatosFaleconosco(contatosFaleconosco clie){
    contatosFaleconoscoRepository cfr = new contatosFaleconoscoRepository();
    cfr.cadastrarcontatomsg(clie);
         ViewData["msg"]= "mensagem enviada com sucesso";
    return View();
   
}
       
        
    }
}