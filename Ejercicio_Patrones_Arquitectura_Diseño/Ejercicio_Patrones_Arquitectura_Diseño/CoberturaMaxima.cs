using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class CoberturaMaxima : Cobertura
    {
        public override double CalcularCostoCobertura()
        {
            return ListaEnfermedades.Sum(x => x.CostoAsociado);
        }
    }
}
