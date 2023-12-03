using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data
{
    public class SurveyDBContext : DbContext
    {
        public DbSet<Nota> Notas { get; set; }

        public DbSet<Emocion> Emociones { get; set; }

        public DbSet<Contenido> Contenidos { get; set; }

        public DbSet<DoctorUser> Doctors { get; set; }

        public DbSet<PacienteUser> Pacientes { get; set; }

        public DbSet<Grupo> Grupos { get; set; }

        public SurveyDBContext(DbContextOptions<SurveyDBContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:hernotesdbserver.database.windows.net,1433;Initial Catalog=hernotes_db;Persist Security Info=False;User ID=ArmandoAl;Password=UntilYourLastBreath_;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
