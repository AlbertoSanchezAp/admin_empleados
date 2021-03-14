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
        Uri URLWSAltaEmp = new Uri("http://localhost:7801/empleados_api/v1/alta_empleado");
        String url = "http://localhost:7801/empleados_api/v1/alta_empleado";
        // GET: HomeController1
        [HttpPost]
        public ActionResult AltaEmpleado(EmpleadoModel emp)
        {
            int di = emp.IdEmpleado;
            string nombre = emp.NombreEmpleado;

            //   String jsonReq= StringConvert
            //   HttpClient clientWS = new HttpClient();
            //HttpContent contentWS =  new StringContent("", Encoding.UTF8, "aplication/json");
            
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                 String json = $"{{\"data\":\"{"abc"}\"}}";
                 request.Method = "POST";
                 request.ContentType = "application/json";
                 request.Accept = "application/json";
                 String JsonRequest = JsonSerializer.Serialize<EmpleadoModel>(emp);                                 
                 using (var streamWriter = new StreamWriter(request.GetRequestStream()))
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
                                 Console.WriteLine(responseBody);
                             }
                         }
                     }
                 }
                 catch (WebException ex)
                 {
                     // Handle error
                 }
                return View("/Home/Index");
        }
    }
}
