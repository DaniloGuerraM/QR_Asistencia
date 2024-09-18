using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces;

public interface IAsistenciaServicio
{
    AsistenciaR PedirAsistenciaPorDNI(int dni);


    bool TomarAsistenciaPorDNI(AsistenciaDTO asistenciaDTO);
    
}
