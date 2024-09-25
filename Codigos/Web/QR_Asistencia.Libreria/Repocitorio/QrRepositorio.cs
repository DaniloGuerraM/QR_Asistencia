using QR_Asistencia.Libreria.Modelo;
namespace QR_Asistencia.Libreria.Repocitorio;

public class QrRepositorio
{
    private readonly QrContexto _qrContexto;
    public QrRepositorio()
    {
        _qrContexto = QrContexto.Crearinstancia();
    }
//////////////////////////////// toma de sistencia ////////////////////////////////
    public void TomaAsistencia (Registro_Asistencia registro)
    {
        TomarAsistencia(registro);
    }
    internal void TomarAsistencia (Registro_Asistencia registro)
    {
        _qrContexto.registro_Asistencia.Add(registro);
        _qrContexto.SaveChanges();
    }
//////////////////////////////// para listar los alumnos que estan ////////////////////////////////
    public List<Alumno> ListaDeAlumnoPorDNI (int dni)
    {
        return ListaDeAlumnoDNI(dni);
    }
    internal List<Alumno> ListaDeAlumnoDNI(int dni)
    {
        return _qrContexto.alumno.Where(d => d.DNI == dni).ToList();
    }
}
