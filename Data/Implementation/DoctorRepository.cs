using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementation
{
    public class DoctorRepository : IDoctorRepository
    {
        public int Add(DoctorUser user)
        {
            if (user == null) return 0;

            user.CreatedDate = DateTime.Now;
            user.ModifiedDate = DateTime.Now;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Data.Helpers.Constants.ConnectionString)
               .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                //crear validacion para que no pueda haber correos y contraseñas repetidas en la base de datos
                ctx.Doctors.Add(user);
                ctx.SaveChanges();
                return user.Id;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                var usuario = ctx.Doctors.FirstOrDefault(x => x.Id == id);

                if (usuario != null)
                {
                    ctx.Doctors.Remove(usuario);
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public DoctorUser Get(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return ctx.Doctors.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<PacienteUser> GetUsers(int id)
        {
            if (id <= 0) return null;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Data.Helpers.Constants.ConnectionString)
             .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                List<PacienteUser> pacientes = ctx.Pacientes
                .Where(p => p.doctorid == id) 
                .ToList();

                if (pacientes.Count() > 0) return pacientes;
            }

            return null; 
        }

        public DoctorUser login(String email, String password)
        {
            if (email == null || password == null) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
           .UseSqlServer(Data.Helpers.Constants.ConnectionString)
           .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                DoctorUser user = ctx.Doctors.Include(z => z.pacientes).Where(u => u.Email == email).FirstOrDefault();

                if (user != null && user.Password == password)
                {

                    return user;
                }
                return null;
            }
        }

        public bool Update(DoctorUser user)
        {
            if (user == null) return false;
            if (user.Id <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
            .UseSqlServer(Data.Helpers.Constants.ConnectionString)
            .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                DoctorUser uauario = ctx.Doctors.Where(s => s.Id == user.Id).FirstOrDefault();
                uauario.Name = user.Name;
                uauario.Email = user.Email;
                uauario.Password = user.Password;
                user.ModifiedDate = DateTime.Now;
                ctx.SaveChanges();
            }
            return true;
        }
    }
}
