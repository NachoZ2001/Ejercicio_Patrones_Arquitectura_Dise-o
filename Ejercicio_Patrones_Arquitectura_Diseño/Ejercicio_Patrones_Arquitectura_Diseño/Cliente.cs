using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogicaNegocio
{
    public class Cliente : Cobertura
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public double IngresosNetos { get; set; }
        public double IngresoAnuales { get; set; }

        public bool CalcularAccesoCobertura(Cobertura cobertura)
        {
            return (cobertura.CostoBaseCobertura <= IngresoAnuales);
        }

        public override double CalcularCostoCobertura()
        {
            throw new NotImplementedException();
        }
    }
}
