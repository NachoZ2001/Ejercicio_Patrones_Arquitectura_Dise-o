using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Cobertura
    {
        public string Descripcion { get; set; }
        public string Empresa { get; set; }
        public int CantidadMaximaPersonasGrupoFamiliar { get; set; }
        public double CostoBaseCobertura { get; set; }
        public List<Enfermedad> ListaEnfermedades { get; set; }
        public abstract double CalcularCostoCobertura();
     
        public bool ValidarEnfermedadIncluida(int codigoEnfermedad)
        {
            return ListaEnfermedades.Any(x => x.CodigoEnfermedad == codigoEnfermedad);
        }
    }
}
