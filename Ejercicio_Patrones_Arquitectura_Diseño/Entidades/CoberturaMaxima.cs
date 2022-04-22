using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CoberturaMaxima : Cobertura
    {
        public CoberturaMaxima() { }
        public CoberturaMaxima(string descripcion, string empresa, int cantidadMaximaPersonasGrupoFamiliar, double costoBaseCobertura, List<Enfermedad> enfermedades)
        {
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.CantidadMaximaPersonasGrupoFamiliar = cantidadMaximaPersonasGrupoFamiliar;
            this.CostoBaseCobertura = costoBaseCobertura;
            this.ListaEnfermedades = enfermedades;
        }
        public override double CalcularCostoCobertura()
        {
            return ListaEnfermedades.Sum(x => x.CostoAsociado);
        }
    }
}
