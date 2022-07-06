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
    public class produtosController:Controller
    {

        public IActionResult produtos(){

        return View();
        }

        
        public IActionResult computadores(){

        return View();
        }
        public IActionResult smartphone(){

        return View();
        }
        public IActionResult pecasComputador(){

        return View();
        }
        public IActionResult pecasSmartphone(){

        return View();
        }
        public IActionResult acessorios(){

        return View();
        }

        public IActionResult pecasPcCel(){

            return View();
        }
    }
}