using CapaLogicaNegocio;
using Newtonsoft.Json;

namespace CapaPersistencia
{
    public sealed class Singleton
    {
        private static Singleton instance = new Singleton();
        private Singleton() { } 
        public static Singleton Instance { get { return instance; } }

        string pathClientes = "";
        List<Cliente> Clientes = new List<Cliente>();
        string pathAtenciones = "";
        public bool GuardarClientes(List<Cliente> clientes)
        {
            if (!File.Exists(pathClientes))
            {
                File.Create(pathClientes);
                using (StreamWriter writer = new StreamWriter(pathClientes,false))
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
        public List<Cliente> LeerClientes()
        {
            if (File.Exists(pathClientes))
            {
                using (StreamReader reader = new StreamReader(pathClientes))
                {
                    string cliente = reader.ReadToEnd();
                    if (cliente != "")
                    {
                        Clientes = JsonConvert.DeserializeObject<List<Cliente>>(cliente);
                    }
                }
            }
            return Clientes;
        }
    }
}