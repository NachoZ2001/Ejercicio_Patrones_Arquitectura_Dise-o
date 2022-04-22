using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente : Cobertura
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
        public double IngresosNetos { get; set; }
        public double IngresosAnuales { get; set; }

        public Cliente() { }
        public Cliente(int dni, string nombre, string apellido, DateTime fechaNacimiento, string ciudad, double ingresosNetos, double ingresosAnuales,string descripcion, string empresa, int cantMaximaGrupoFamiliar, double costoBaseCobertura, List<Enfermedad> enfermedades)
        {
            this.Dni = dni;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.Ciudad = ciudad;
            this.IngresosNetos = ingresosNetos;
            this.IngresosAnuales = ingresosAnuales;
            this.Descripcion = descripcion;
            this.Empresa = empresa;
            this.CantidadMaximaPersonasGrupoFamiliar = cantMaximaGrupoFamiliar;
            this.CostoBaseCobertura = costoBaseCobertura;
            this.ListaEnfermedades = enfermedades;
        }
        public bool CalcularAccesoCobertura(Cobertura cobertura)
        {
            return (cobertura.CostoBaseCobertura <= IngresosAnuales);
        }

        public override double CalcularCostoCobertura()
        {
            throw new NotImplementedException();
        }
    }
}
