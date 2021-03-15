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
        public int RolEmpleado { get; set; }
        public int TipoEmpleado { get; set; }


        public double SueldoBaseHora { get; set; }

        public double PagoHoraEntrega { get; set; }

        public double BonoHora { get; set; }
        public int ValeDespensa { get; set; }
        public double SueldoBase { get; set; }

        public EmpleadoModel() { }

        public EmpleadoModel(String nombreEmpleado, int edad, String sexo, int rolEmpleado, int tipoEmpleado) {
            this.NombreEmpleado = nombreEmpleado;
            this.Edad = edad;
            this.Sexo = sexo;
            this.RolEmpleado= rolEmpleado;
            this.TipoEmpleado = tipoEmpleado;
        }

    }
}
