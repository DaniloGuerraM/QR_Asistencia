using QR_Asistencia.Libreria.Repocitorio;
using QR_Asistencia.Libreria.Modelo;

namespace QR_Asistencia.App.Pantallas.PantallaTomarAsistencia;

public class TomarAsistencia
{
    int esta;
    private QrRepositorio _qrRepositorio;
    public TomarAsistencia()
    {
        _qrRepositorio = new QrRepositorio();
    }
    public void Asistencia()
    {
        Console.WriteLine("Ingrese el DNI del alumno");
        string string_dni = Console.ReadLine();
        int dni = Convert.ToInt32(string_dni);
        try
        {
            QrRepositorio buscarDNI = new QrRepositorio();
            List<Alumno> estaDNI = buscarDNI.ListaDeAlumnoPorDNI(dni);

            
            foreach (Alumno alumno in estaDNI)
            {
                esta = alumno.DNI;
                Console.Write("el DNI :");
                Console.WriteLine(esta);
            }



        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("/////////////////// no anda che ///////////////////");
        }
        try
        {
            if (esta == dni)
            {
                Registro_Asistencia registro = new Registro_Asistencia();
                //registro.Id_Registro = 455;
                registro.DNI = dni;
                registro.Fecha =  new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); //DateTime.Now.Timestamp;
                _qrRepositorio.TomaAsistencia(registro);
                Console.WriteLine("esta el dni");
                //////////////////////////// controlando la hora ////////////////////////////
                long unix2 = 1724802345;
                long unix = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                DateTime date = DateTimeOffset.FromUnixTimeSeconds(unix).DateTime;
                DateTime date2 = DateTimeOffset.FromUnixTimeSeconds(unix2).DateTime;

                TimeSpan hora = date.TimeOfDay;
                TimeSpan hora2 = date2.TimeOfDay;

                Console.WriteLine("hora " + hora.ToString());
                Console.WriteLine("hora2 " + hora2.ToString());
                
            }
            else
            {
                Console.WriteLine("no esta el dni");
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("/////////////////// no guarda che ///////////////////");
        }
        
        
    }
}
