using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asistencia.Domain.Entities;

namespace Asistencia.Application.Interfaces
{
    public interface IControlQRServicio
    {
        public void GuardarQR(MicroDTO microDTO);
        public MicroDTO ObtenerQR();
    }
}