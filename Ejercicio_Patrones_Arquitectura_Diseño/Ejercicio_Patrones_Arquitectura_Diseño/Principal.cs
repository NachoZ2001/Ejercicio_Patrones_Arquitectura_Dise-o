using CapaLogicaNegocio;

namespace Ejercicio_Patrones_Arquitectura_Diseño
{
    public sealed class Singleton 
    {
        private static Singleton instance = new Singleton();
        private Singleton() { }
        public static Singleton Instance { get { return instance; } }
      
        List<Enfermedad> Enfermedades = new List<Enfermedad>();
        List<Cliente> Clientes = new List<Cliente>();
        List<Atencion> Atenciones = new List<Atencion>();
        List<Cobertura> Coberturas = new List<Cobertura>();
        public double CargarAtenciones(int dni, int codigoEnfermedad, DateTime fechaAtencion)
        {
            Enfermedad enfermedad = (Enfermedad)Enfermedades.Where(x => x.CodigoEnfermedad == codigoEnfermedad);
            Cliente cliente = (Cliente)Clientes.Where(x => x.Dni == dni);
            if (cliente.ValidarEnfermedadIncluida(enfermedad))
            {
                Atencion nuevaAtencion = new Atencion(Atenciones.Count + 1, fechaAtencion, enfermedad, cliente);
                Atenciones.Add(nuevaAtencion);
                return enfermedad.CostoAsociado;
            }
            return 0;
        }
    }
}