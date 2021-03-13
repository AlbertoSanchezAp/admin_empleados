using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdministracionEmpleados.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }
        public String NombreEmpleado { get; set; }
        public int Edad { get; set; }
        public String Sexo { get; set; }

        public int TipoEmpleado { get; set; }

        public EmpleadoModel() { }

        public EmpleadoModel(int idEmpleado, String nombreEmpleado, int edad, String sexo ,int tipoEmpleado) {
            this.IdEmpleado = idEmpleado;
            this.NombreEmpleado = nombreEmpleado;
            this.Edad = edad;
            this.Sexo = sexo;
            this.TipoEmpleado = tipoEmpleado;
        }



    }
}
