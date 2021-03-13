using AdministracionEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: HomeController1
public ActionResult AltaEmpleado()
        {

            return View();
        }

        // GET: HomeController1
        [HttpPost]
        public ActionResult AltaEmpleado(EmpleadoModel emp)
        {
            int di = emp.IdEmpleado;
            string nombre = emp.NombreEmpleado;
            
            return View("/Home/Index");
        }
    }
}
