using QR_Asistencia.Libreria.Repocitorio;
using QR_Asistencia.Libreria.Modelo;

namespace QR_Asistencia.App.Pantallas.PantallaTomarAsistencia;

public class TomarAsistencia
{
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

            int esta;
            foreach (Alumno alumno in estaDNI)
            {
                esta = alumno.DNI;
                Console.WriteLine(esta);
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("/////////////////// no anda che ///////////////////");
        }
        
        
    }
}

/*

*/