using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class CoberturaNormal : Cobertura
    {
        public override double CalcularCostoCobertura()
        {
            return CostoBaseCobertura + ListaEnfermedades.Average(x => x.CostoAsociado);
        }
    }
}
