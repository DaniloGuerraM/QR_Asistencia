using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;

namespace Asistencia.Application;

public class AsistenciaServicio : IAsistenciaServicio
{
    private readonly IAsistenciaRepository _registroAsistenciaRepository;
    private readonly IAlumnoServicio _alumnoServicio;
    private readonly IControlQRServicio _controlQRServicio;
    public AsistenciaServicio(IAsistenciaRepository registroAsistenciaRepository, IAlumnoServicio alumnoServicio, IControlQRServicio controlQRServicio)
    {
        _registroAsistenciaRepository = registroAsistenciaRepository;
        _alumnoServicio = alumnoServicio;
        _controlQRServicio = controlQRServicio;
    }

    public AsistenciaR PedirAsistenciaPorDNI(int dni)
    {
        return _registroAsistenciaRepository.RequestAssistancebyID(dni);
    }

    public bool TomarAsistenciaPorDNI(AsistenciaDTO asistenciaDTO)
    {
        var alumno = _alumnoServicio.ObtenerPorMac(asistenciaDTO.MAC);
        string[] parte = asistenciaDTO.CodigoQR.Split('-');
        if (alumno != null)
        {
            var microDTO  = _controlQRServicio.ObtenerQR();
            if(microDTO.Key == parte[0])
            {
                if (microDTO.Valor == parte[1])
                {
                    AsistenciaR s = new AsistenciaR();
                    s.DNI = alumno.DNI;
                    s.Fecha = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
                    _registroAsistenciaRepository.takeAttendanceByID(s);
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }else{
            return false;
        }
       
    }
}
