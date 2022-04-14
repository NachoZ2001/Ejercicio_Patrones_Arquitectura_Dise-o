using Entidades;
using CapaPersistencia;
using Newtonsoft.Json;
using System.Net.Mail;
using System.Net;

namespace CapaLogicaNegocio
{
    public sealed class Singleton 
    {
        private static Singleton instance = new Singleton();

        List<Enfermedad> Enfermedades;
        List<Cliente> Clientes;
        List<Atencion> Atenciones;
        List<Cobertura> Coberturas;

        private Singleton() 
        {
            Enfermedades = new List<Enfermedad>();
            Clientes = new List<Cliente>();
            Atenciones = new List<Atencion>();
            Coberturas = new List<Cobertura>();
        }
        public static Singleton Instance { get { return instance; } }
       
        public List<Cliente> LeerClientes()
        {
            return Json.Instance.LeerClientes();
        }
        //public bool CargarCliente(int dni, string nombre, string apellido, DateTime fechaNacimiento, string ciudad, double ingresosNetos, double ingresosAnuales)
        //{
        //    Cliente nuevoCliente = new Cliente(dni, nombre, apellido, fechaNacimiento, ciudad, ingresosNetos, ingresosAnuales);
        //    Clientes = LeerClientes();
        //    Clientes.Add(nuevoCliente);
        //    GuardarListadoClientes(Clientes);
        //    return true;
        //}
        public bool GuardarListadoClientes(List<Cliente> clientes)
        {
            Json.Instance.GuardarListaClientes(clientes);
            return true;
        }
        public List<Enfermedad> LeerEnfermedades()
        {
            return Json.Instance.LeerEnfermedades();
        }
        public bool CargarEnfermedad(int codigoEnfermedad, tipoEnfermedad tipoEnfermedad, string nombre, double costoAsociado)
        {
            Enfermedad nuevaEnfermedad = new Enfermedad(codigoEnfermedad, tipoEnfermedad, nombre, costoAsociado);
            Enfermedades = LeerEnfermedades();
            Enfermedades.Add(nuevaEnfermedad);
            GuardarListadoEnfermedades(Enfermedades);
            return true;
        }
        public bool GuardarListadoEnfermedades(List<Enfermedad> enfermedades)
        {
            Json.Instance.GuardarListaEnfermedades(enfermedades);
            return true;
        }
        public List<Cobertura> LeerCoberturas()
        {
            return Json.Instance.LeerCoberturas();
        }
        public bool GuardarListadoCoberturas(List<Cobertura> coberturas)
        {
            Json.Instance.GuardarListaCoberturas(coberturas);
            return true;
        }
        public bool CargarCobertura(string descripcion, string empresa, int cantidadMaximaPersonasGrupoFamiliar, double costoBaseCobertura, List<Enfermedad> enfermedades, bool esCoberturaMaxima)
        {
            if (esCoberturaMaxima)
            {
                CoberturaMaxima nuevaCobertura = new CoberturaMaxima(descripcion, empresa, cantidadMaximaPersonasGrupoFamiliar, costoBaseCobertura, enfermedades);
                Coberturas = LeerCoberturas();
                Coberturas.Add(nuevaCobertura);
                GuardarListadoCoberturas(Coberturas);
            }
            else
            {
                CoberturaNormal nuevaCobertura = new CoberturaNormal(descripcion, empresa, cantidadMaximaPersonasGrupoFamiliar, costoBaseCobertura, enfermedades);
                Coberturas = LeerCoberturas();
                Coberturas.Add(nuevaCobertura);
                GuardarListadoCoberturas(Coberturas);
            }
            return true;
        }
        public List<Atencion> LeerAtenciones()
        {
            return Json.Instance.LeerAtenciones();
        }
        public bool GuardarListadoAtenciones(List<Atencion> atenciones)
        {
            Json.Instance.GuardarListaAtenciones(atenciones);
            return true;
        }
        public double CargarAtenciones(int dni, int codigoEnfermedad, DateTime fechaAtencion, string mailCliente)
        {
            Enfermedad enfermedad = LeerEnfermedades().FirstOrDefault(x => x.CodigoEnfermedad == codigoEnfermedad);
            Cliente cliente = LeerClientes().FirstOrDefault(x => x.Dni == dni);
            if (cliente != null && enfermedad != null && cliente.ValidarEnfermedadIncluida(enfermedad.CodigoEnfermedad))
            {
                Atenciones = LeerAtenciones();               
                Atencion nuevaAtencion = new Atencion(Atenciones.Count + 1, fechaAtencion, enfermedad, cliente);
                Atenciones.Add(nuevaAtencion);
                GuardarListadoAtenciones(Atenciones);
                EnviarMail(mailCliente);
                return enfermedad.CostoAsociado;
            }
            else
            {
                EnviarMail(mailCliente, true);
                return 0;
            }           
        }
        public bool EnviarMail(string mailCliente) 
        {
            MailAddress to = new MailAddress(mailCliente);
            MailAddress from = new MailAddress("ramoncamoranesi2@gmail.com");
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Atencion registrada";
            mail.Body = "Su atencion se pudo registrar";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("ramoncamoranesi2@gmail.com", "Carlos66");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception )
            {
                throw new Exception("No se ha podido enviar el email");
            }
            finally
            {
                smtp.Dispose();
            }
            return true;
        }
        public bool EnviarMail(string mailCliente, bool error)
        {
            MailAddress to = new MailAddress(mailCliente);
            MailAddress from = new MailAddress("ramoncamoranesi2@gmail.com");
            MailMessage mail = new MailMessage(from, to);
            mail.Subject = "Atencion no registrada";
            mail.Body = "Su atencion no se pudo registrar";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("ramoncamoranesi2@gmail.com", "Carlos66");
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception)
            {
                throw new Exception("No se ha podido enviar el email");
            }
            return true;
        }

        public void CargarClientePrueba()
        {
            Cliente nuevoCliente = new Cliente(43494396, "Ignacio", "Zbrun", DateTime.Now.Date, "Rafaela", 10000, 123456, "ta terrible", "Sancor",5,888.8,LeerEnfermedades());
            Clientes = LeerClientes();
            Clientes.Add(nuevoCliente);
            GuardarListadoClientes(Clientes);
        }
        public void CargarEnfermedadPrueba()
        {
            Enfermedad nuevaEnfermedad = new Enfermedad(3, 0, "Cancer", 700);
            Enfermedades = LeerEnfermedades();
            Enfermedades.Add(nuevaEnfermedad);
            GuardarListadoEnfermedades(Enfermedades);
        }
    }
}