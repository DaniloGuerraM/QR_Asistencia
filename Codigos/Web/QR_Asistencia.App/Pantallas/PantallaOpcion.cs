using QR_Asistencia.App.Pantallas.PantallaTomarAsistencia;
namespace QR_Asistencia.App.Pantallas;

public class PantallaOpcion
{
    public void Menu()
    {
        Console.WriteLine("¿Desea Tomar Asistencia? s/n");
        string q = Console.ReadLine();
        if (q == "s")
        {
            TomarAsistencia t = new TomarAsistencia();
            t.Asistencia();
        }
        else
        {
            Console.WriteLine("no");
        }

    }

}

