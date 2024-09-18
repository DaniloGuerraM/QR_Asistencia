using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces
{
    public interface IControlQRRepository
    {
        public void SaveQR(MicroDTO microDTO);
        public MicroDTO GetQR();
    }
}