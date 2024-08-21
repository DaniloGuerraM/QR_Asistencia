using QR_Asistencia.Libreria.Modelo;
namespace QR_Asistencia.Libreria.Repocitorio;

public class QrRepositorio
{
    private readonly QrContexto _qrContexto;
    public QrRepositorio()
    {
        _qrContexto = QrContexto.Crearinstancia();
    }

    public void TomaAsistencia (Registro_Asistencia registro_Asistencia)
    {
        TomarAsistencia(registro_Asistencia);
    }
    internal void TomarAsistencia (Registro_Asistencia registro_Asistencia)
    {
        _qrContexto.registro_Asistencia.Add(registro_Asistencia);
        _qrContexto.SaveChanges();
    }

    public List<Alumno> ListaDeAlumnoPorDNI (int dni)
    {
        return ListaDeAlumnoDNI(dni);
    }
    internal List<Alumno> ListaDeAlumnoDNI(int dni)
    {
        return _qrContexto.alumno.Where(d => d.DNI == dni).ToList();
    }
}
