using Entidades;
using Newtonsoft.Json;

namespace CapaPersistencia
{
    public sealed class Json
    {
        private static Json instance = new Json();
        private Json() { } 
        public static Json Instance { get { return instance; } }

        string pathClientes = @"D:\PROGRAMACION II\Ejercicio_Patrones_\Ejercicio_Patrones_Arquitectura_Diseño\Clientes.txt";
        string pathAtenciones = @"D:\PROGRAMACION II\Ejercicio_Patrones_\Ejercicio_Patrones_Arquitectura_Diseño\Atenciones.txt";
        string pathEnfermedades = @"D:\PROGRAMACION II\Ejercicio_Patrones_\Ejercicio_Patrones_Arquitectura_Diseño\Enfermedades.txt";
        string pathCoberturas = @"D:\PROGRAMACION II\Ejercicio_Patrones_\Ejercicio_Patrones_Arquitectura_Diseño\Coberturas.txt";

        public List<Cobertura> LeerCoberturas()
        {
            List<Cobertura> coberturas = new List<Cobertura>();
            if (File.Exists(pathCoberturas))
            {
                using (StreamReader reader = new StreamReader(pathCoberturas))
                {
                    string cobertura = reader.ReadToEnd();
                    if (cobertura != "")
                    {
                        coberturas = JsonConvert.DeserializeObject<List<Cobertura>>(cobertura);
                    }
                }
            }
            return coberturas;
        }
        
        public bool GuardarListaCoberturas(List<Cobertura> coberturas)
        {
            if (!File.Exists(pathCoberturas))
            {
                File.Create(pathCoberturas);
                using (StreamWriter writer = new StreamWriter(pathCoberturas, false))
                {
                    string coberturasJson = JsonConvert.SerializeObject(coberturas);
                    writer.Write(coberturasJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(pathCoberturas, false))
                {
                    string coberturasJson = JsonConvert.SerializeObject(coberturas);
                    writer.Write(coberturasJson);
                }
            }
            return true;
        }
        public List<Cliente> LeerClientes()
        {
            List < Cliente > clientes = new List < Cliente >(); 
            if (File.Exists(pathClientes))
            {
                using (StreamReader reader = new StreamReader(pathClientes))
                {
                    string cliente = reader.ReadToEnd();
                    if (cliente != "")
                    {
                        clientes = JsonConvert.DeserializeObject<List<Cliente>>(cliente);
                    }
                }
            }
            return clientes;
        }
        public bool GuardarListaClientes(List<Cliente> clientes)
        {
            if (!File.Exists(pathClientes))
            {
                File.Create(pathClientes);
                using (StreamWriter writer = new StreamWriter(pathClientes, false))
                {
                    string clientesJson = JsonConvert.SerializeObject(clientes);
                    writer.Write(clientesJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(pathClientes, false))
                {
                    string clientesJson = JsonConvert.SerializeObject(clientes);
                    writer.Write(clientesJson);
                }
            }
            return true;
        }
        public List<Atencion> LeerAtenciones()
        {
            List<Atencion> atenciones = new List<Atencion>();
            if (File.Exists(pathAtenciones))
            {
                using (StreamReader reader = new StreamReader(pathAtenciones))
                {
                    string atencion = reader.ReadToEnd();
                    if (atencion != "")
                    {
                        atenciones = JsonConvert.DeserializeObject<List<Atencion>>(atencion);
                    }
                }
            }
            return atenciones;
        }
        public bool GuardarListaAtenciones(List<Atencion> atenciones)
        {
            if (!File.Exists(pathAtenciones))
            {
                File.Create(pathAtenciones);
                using (StreamWriter writer = new StreamWriter(pathAtenciones, false))
                {
                    string atencionesJson = JsonConvert.SerializeObject(atenciones);
                    writer.Write(atencionesJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(pathAtenciones, false))
                {
                    string atencionesJson = JsonConvert.SerializeObject(atenciones);
                    writer.Write(atencionesJson);
                }
            }
            return true;
        }       
        public List<Enfermedad> LeerEnfermedades()
        {
            List<Enfermedad> enfermedades = new List<Enfermedad>();
            if (File.Exists(pathEnfermedades))
            {
                using (StreamReader reader = new StreamReader(pathEnfermedades))
                {
                    string enfermedad = reader.ReadToEnd();
                    if (enfermedad != "")
                    {
                        enfermedades = JsonConvert.DeserializeObject<List<Enfermedad>>(enfermedad);
                    }
                }
            }
            return enfermedades;
        }
        public bool GuardarListaEnfermedades(List<Enfermedad> enfermedades)
        {
            if (!File.Exists(pathEnfermedades))
            {
                File.Create(pathEnfermedades);
                using (StreamWriter writer = new StreamWriter(pathEnfermedades, false))
                {
                    string enfermedadesJson = JsonConvert.SerializeObject(enfermedades);
                    writer.Write(enfermedadesJson);
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(pathEnfermedades, false))
                {
                    string enfermedadesJson = JsonConvert.SerializeObject(enfermedades);
                    writer.Write(enfermedadesJson);
                }
            }
            return true;
        }
    }
}