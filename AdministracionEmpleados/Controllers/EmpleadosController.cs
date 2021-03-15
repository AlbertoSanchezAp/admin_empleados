using AdministracionEmpleados.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;
//using System.Text.Json;

namespace AdministracionEmpleados.Controllers
{

    public class EmpleadosController : Controller
    {
        // GET: HomeController1
        public ActionResult AltaEmpleado()
        {
            return View();
        }


        
        String URL_alta = "http://localhost:7801/empleados_api/v1/alta_empleado";
        String URL_actualiza = "http://localhost:7801/empleados_api/v1/actualiza/empleados";
        // GET: HomeController1
        [HttpPost]
        public ActionResult AltaEmpleado(EmpleadoModel emp)
        {
            Respuesta respJson = new Respuesta();
                
                int jornadaLaboralHoras = 8;
                int sucontratadoDespensa = emp.TipoEmpleado;
            // quirar
                emp.Sexo = "";
                if (sucontratadoDespensa.Equals(1)) {
                    emp.ValeDespensa = 4;
                }
                else {
                    emp.ValeDespensa = 0;
                }
                // calcular sueldo mensual
                double sueldoBaseMensual= (emp.SueldoBaseHora * jornadaLaboralHoras) * 30;
                emp.SueldoBase = sueldoBaseMensual;
                
                
                 HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_alta);
                 request.Method = "POST";
                 request.ContentType = "application/json";
                 request.Accept = "application/json";
            
                 String JsonRequest = JsonSerializer.Serialize<EmpleadoModel>(emp);                                 
                 using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
                 {
                     streamWriter.Write(JsonRequest);
                     streamWriter.Flush();
                     streamWriter.Close();
                 }

                 try
                 {
                     using (WebResponse response = request.GetResponse())
                     {
                         using (Stream strReader = response.GetResponseStream())
                         {
                        if (strReader == null) return View();
                             using (StreamReader objReader = new StreamReader(strReader))
                             {
                                 string responseBody = objReader.ReadToEnd();
                                 respJson = JsonSerializer.Deserialize<Respuesta>(responseBody);

                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                             }
                         }
                     }
                 }
                 catch (WebException ex)
                 {
                     // Handle error
                 }
                return View();
        }
        public ActionResult ActualizarEmpleados()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ActualizarEmpleados(EmpleadoModel emp)
        {
            Respuesta respJson = new Respuesta();

            int jornadaLaboralHoras = 8;

            double sueldoBaseMensual = (emp.SueldoBaseHora * jornadaLaboralHoras) * 30;
            emp.SueldoBase = sueldoBaseMensual;
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL_actualiza);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            String JsonRequest = JsonSerializer.Serialize<EmpleadoModel>(emp);
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(JsonRequest);
                streamWriter.Flush();
                streamWriter.Close();
            }

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                            using (StreamReader objReader = new StreamReader(strReader))
                            {
                                string responseBody = objReader.ReadToEnd();
                                // Do something with responseBody
                                respJson = JsonSerializer.Deserialize<Respuesta>(responseBody);

                                Console.WriteLine(responseBody);
                            }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }
            
            return View();
        }

    }
}
