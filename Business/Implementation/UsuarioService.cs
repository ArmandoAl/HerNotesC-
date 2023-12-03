using Business.Contracts;
using Data.Contracts;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IDoctorRepository _doctorRepository;

        public UsuarioService(IPacienteRepository pacienteRepository, IDoctorRepository doctorRepository)
        {
            _pacienteRepository = pacienteRepository;
            _doctorRepository = doctorRepository;
        }

        public Usuario login(String email, String password)
        {
            if (email == null || password == null) return null;

            var doctor = _doctorRepository.login(email, password);

            if(doctor != null)
            {
                return doctor;
            }
            else
            {
                var paciente = _pacienteRepository.login(email, password);
                if (paciente != null)
                {
                    return paciente;
                }
            }

            return null;
        }
    }
}
