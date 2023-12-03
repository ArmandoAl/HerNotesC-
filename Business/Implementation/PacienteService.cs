using Business.Contracts;
using Data;
using Data.Contracts;
using Data.Implementation;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementation
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _service;
        private readonly IDoctorService _doctorService;

        public PacienteService(IPacienteRepository service, IDoctorService doctorService)
        {
            _service = service;
            _doctorService = doctorService;
        }

        public int Add(PacienteUser user)
        {
            if (user == null) return 0;
            return _service.Add(user);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _service.Delete(id);
        }

        public PacienteUser Get(int id)
        {
            if (id <= 0) return null;
            return _service.Get(id);
        }

        public PacienteUser login(string email, string password)
        {
            if (email == null || password == null) return null;
            return _service.login(email, password);
        }

        public bool RelatePacienteWithDoctor(int doctorid, int pacienteId)
        {
            if (doctorid <= 0) return false;
            if (pacienteId <= 0) return false;
            return _service.RelatePacienteWithDoctor(doctorid, pacienteId);
        }

        public bool Update(PacienteUser usuario)
        {
            if (usuario == null) return false;
            if (usuario.Id <= 0) return false;
            return _service.Update(usuario);
        }

        public DoctorUser getMyDoctor(int id)
        {
            if (id <= 0) return null;
            return _service.getMyDoctor(id);
        }

        public List<Nota> GetNotes(int id)
        {
            if(id <= 0) return new List<Nota>();

            return _service.GetNotes(id);
        }

        public bool RelateNoteWithUser(int noteId, int userId)
        {
           if(noteId <= 0) return false;
           if (userId <= 0) return false;
           return _service.RelateNoteWithUser(noteId, userId);
        }

        public UserResponseModel otherLogin(string email, string password)
        {
            if (email == null || password == null) return null;

            DoctorUser doctor = _doctorService.login(email, password);

            if (doctor != null)
            {
                UserResponseModel userResponseModel = new UserResponseModel
                {
                    User = new CompleteUserModel
                    {
                        Id = doctor.Id,
                        Name = doctor.Name,
                        Email = doctor.Email,
                        Password = doctor.Password,
                        pacientes = doctor.pacientes
                    },
                    UserType = "doctor"
                };
                        
                return userResponseModel;
            }
            else
            {
                PacienteUser paciente = _service.login(email, password);
                if (paciente != null)
                {
                    UserResponseModel userResponse = new UserResponseModel
                    {
                        User = new CompleteUserModel
                        {
                            Id = paciente.Id,
                            Name = paciente.Name,
                            Email = paciente.Email,
                            Password = paciente.Password,
                            doctorid = paciente.doctorid,
                            Notas = paciente.Notas
                        },
                        UserType = "paciente"
                    };
                    return userResponse;
                }
            }

            return null;
        }
    }
}
