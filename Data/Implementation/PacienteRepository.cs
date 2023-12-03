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
    public class PacienteRepository : IPacienteRepository
    {
        public int Add(PacienteUser user)
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
                ctx.Pacientes.Add(user);
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
                var usuario = ctx.Pacientes.FirstOrDefault(x => x.Id == id);

                if (usuario != null)
                {
                    ctx.Pacientes.Remove(usuario);
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public PacienteUser Get(int id)
        {

            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return ctx.Pacientes.FirstOrDefault(x => x.Id == id);
            }
        }

        public DoctorUser getMyDoctor(int id)
        {
            if (id <= 0) return null;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
           .UseSqlServer(Data.Helpers.Constants.ConnectionString)
           .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {

                DoctorUser user = ctx.Doctors.FirstOrDefault(s => s.Id == id);
                if(user != null) return user;
            }
            return null;

        }

        public List<Nota> GetNotes(int id)
        {
            if (id <= 0) return null;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
           .UseSqlServer(Data.Helpers.Constants.ConnectionString)
           .Options;
            List<Nota> notes;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                notes = ctx.Pacientes
            .Where(s => s.Id == id)
            .SelectMany(e => e.Notas)
            .Include(x => x.Contenido)
            .Include(x => x.Emociones)
            .ToList();
            }
            return notes;
        }

        public PacienteUser login(String email, String password)
        {
            if (email == null || password == null) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
           .UseSqlServer(Data.Helpers.Constants.ConnectionString)
           .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                PacienteUser user = ctx.Pacientes.Where(u => u.Email == email).First();

                if (user != null && user.Password == password)
                {

                    return user;
                }
                return null;
            }
        }

        public bool Update(PacienteUser user)
        {
            if (user == null) return false;
            if (user.Id <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
            .UseSqlServer(Data.Helpers.Constants.ConnectionString)
            .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                PacienteUser uauario = ctx.Pacientes.Where(s => s.Id == user.Id).FirstOrDefault();
               if(uauario != null)
                {
                    uauario.Name = user.Name;
                    uauario.Email = user.Email;
                    uauario.Password = user.Password;
                    user.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RelateNoteWithUser(int noteId, int userId)
        {
            if (noteId <= 0) return false;
            if (userId <= 0 || userId == null) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
              .UseSqlServer(Data.Helpers.Constants.ConnectionString)
              .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                var nota = ctx.Notas.FirstOrDefault(x => x.Id == noteId);
                var usuario = ctx.Pacientes.Include(u => u.Notas).FirstOrDefault(u => u.Id == userId);

                if (nota != null && usuario != null)
                {
                    usuario.Notas.Add(nota);
                    ctx.SaveChanges();

                }
            }
            return true;

        }

        public bool RelatePacienteWithDoctor(int doctorid, int pacienteId)
        {
            if (doctorid <= 0) return false;
            if (pacienteId <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Data.Helpers.Constants.ConnectionString)
             .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                var doctor = ctx.Doctors.FirstOrDefault(x => x.Id ==  doctorid);
                var paciente = ctx.Pacientes.FirstOrDefault(x => x.Id == pacienteId);

                if(paciente != null &&  paciente != null)
                {
                    doctor.pacientes.Add(paciente);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
