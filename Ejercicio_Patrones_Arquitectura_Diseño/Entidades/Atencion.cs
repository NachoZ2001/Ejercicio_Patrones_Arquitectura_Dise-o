using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Atencion
    {
        public int CodigoAutoincremental { get; set; }
        public DateTime FechaAtencion { get; set; }
        public Enfermedad DatosEnfermedad { get; set; }
        public Cliente DatosCliente { get; set; }
        public Atencion() { }
        public Atencion(int codigoAutoincremental, DateTime fechaAtencion, Enfermedad datosEnfermedad, Cliente datosCliente)
        {
            CodigoAutoincremental = codigoAutoincremental;
            FechaAtencion = fechaAtencion;
            DatosEnfermedad = datosEnfermedad;
            DatosCliente = datosCliente;
        }

    }
}
