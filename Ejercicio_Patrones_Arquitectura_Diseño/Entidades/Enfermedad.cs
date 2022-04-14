using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Enfermedad
    {
        public int CodigoEnfermedad;
        public tipoEnfermedad TipoEnfermedad { get; set; }
        public string Nombre { get; set; }
        public double CostoAsociado { get; set; }

        public Enfermedad() { }
        public Enfermedad(int codigoEnfermedad, tipoEnfermedad tipoEnfermedad, string nombre, double costoAsociado)
        {
            this.CodigoEnfermedad = codigoEnfermedad;
            this.TipoEnfermedad = tipoEnfermedad;
            this.Nombre = nombre;
            this.CostoAsociado = costoAsociado;
        }
    }
}
