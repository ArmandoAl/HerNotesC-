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
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _service;

        public DoctorService(IDoctorRepository service)
        {
            _service = service;
        }

        public int Add(DoctorUser user)
        {
            if (user == null) return 0;
            return _service.Add(user);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _service.Delete(id);
        }

        public DoctorUser Get(int id)
        {
            if (id <= 0) return null;
            return _service.Get(id);
        }

        public DoctorUser login(string email, string password)
        {
            if (email == null || password == null) return null;
            return _service.login(email, password);
        }

        public bool Update(DoctorUser usuario)
        {
            if (usuario == null) return false;
            if (usuario.Id <= 0) return false;
            return _service.Update(usuario);
        }

        public List<PacienteUser> GetUsers(int id)
        {
            if (id <= 0) return null;
            return _service.GetUsers(id);
        }
    }
}
