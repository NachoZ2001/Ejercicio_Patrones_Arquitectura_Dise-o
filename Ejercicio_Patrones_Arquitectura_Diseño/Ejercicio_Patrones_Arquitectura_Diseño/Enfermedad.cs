using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Enfermedad
    {
        public int CodigoEnfermedad;
        public tipoEnfermedad TipoEnfermedad { get; set; }
        public string Nombre { get; set; }
        public double CostoAsociado { get; set; }
    }
}
