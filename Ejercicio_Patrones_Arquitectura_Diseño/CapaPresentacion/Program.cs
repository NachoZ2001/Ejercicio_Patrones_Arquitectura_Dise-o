// See https://aka.ms/new-console-template for more information
//CapaLogicaNegocio.Singleton.Instance.CargarEnfermedadPrueba();
//CapaLogicaNegocio.Singleton.Instance.CargarClientePrueba();
Console.WriteLine("Ingrese su DNI");
int dni = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el codigo de la enfermedad");
int codigoEnfermedad = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese la fecha de atencion");
DateTime fechaAtencion = DateTime.Parse(Console.ReadLine());
Console.WriteLine("Ingrese su mail");
string mail = Console.ReadLine();
Console.WriteLine(CapaLogicaNegocio.Singleton.Instance.CargarAtenciones(dni, codigoEnfermedad, fechaAtencion, mail));




