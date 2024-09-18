using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asistencia.Application.Interfaces;
using Asistencia.Domain.Entities;

namespace Asistencia.Application
{
    public class ControlQRServicio : IControlQRServicio
    {
        private readonly IControlQRRepository _controlQRRepository;
        public ControlQRServicio(IControlQRRepository controlQRRepository)
        {
            _controlQRRepository = controlQRRepository;
        }

        public void GuardarQR(MicroDTO microDTO)
        {
            _controlQRRepository.SaveQR(microDTO);
        }

        MicroDTO IControlQRServicio.ObtenerQR()
        {
            return _controlQRRepository.GetQR();
        }
    }
}