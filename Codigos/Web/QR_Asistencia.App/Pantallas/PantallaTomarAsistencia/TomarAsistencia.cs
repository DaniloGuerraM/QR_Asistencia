using QR_Asistencia.Libreria.Repocitorio;
using QR_Asistencia.Libreria.Modelo;

namespace QR_Asistencia.App.Pantallas.PantallaTomarAsistencia;

public class TomarAsistencia
{
    DateTime fecha_p;
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
                registro.Id_Registro = 455;
                registro.DNI = dni;
                registro.Fecha =  new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); //DateTime.Now.Timestamp;
                _qrRepositorio.TomaAsistencia(registro);
                Console.WriteLine("esta el dni");
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

/*

*/