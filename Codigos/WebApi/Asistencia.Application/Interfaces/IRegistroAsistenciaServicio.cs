using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IRegistroAsistenciaServicio
{
    RegistroAsistencia PedirAsistenciaPorDNI(int ind);
    bool TomarAsistenciaPorDNI(int dni);
}
