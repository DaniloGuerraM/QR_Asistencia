using QR_Asistencia.App.Pantallas.PantallaTomarAsistencia;
namespace QR_Asistencia.App.Pantallas;

public class PantallaOpcion
{
    public void Menu()
    {
        Console.WriteLine("AAAArrancamos");
        TomarAsistencia t = new TomarAsistencia();
        t.Asistencia();
  

    }

}

