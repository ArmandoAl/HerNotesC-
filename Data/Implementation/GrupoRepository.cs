using Data; // Asegúrate de importar el espacio de nombres correcto
using Data.Contracts;
using Data.Helpers;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class GrupoRepository : IGrupoRepository
    {
        public int Add(Grupo grupo)
        {
            if (grupo == null) return 0;

            grupo.CreatedDate = DateTime.Now;
            grupo.ModifiedDate = DateTime.Now;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Constants.ConnectionString)
               .Options;
            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                //ctx.Grupos.Add(grupo);
                //ctx.SaveChanges();
                return grupo.Id;
            }
        }

        public int Add(Emocion entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
               

                
                    return true;
                
            }

            return false;
        }

        public Grupo Get(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return null;
            }
        }

        public List<Nota> GetNotas(int id)
        {
           // if (id <= 0) return null;
           // var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
           //.UseSqlServer(Constants.ConnectionString)
           //.Options;
           // List<Nota> notas;
           // using (var ctx = new SurveyDBContext(options: connectionOptions))
           // {
           //     notas = ctx.Grupos.Where(s => s.Id == id).SelectMany(e => e.Notas).ToList();
           // }
            return null;
        }

        public bool Update(Grupo grupo)
        {
            //if (grupo == null) return false;
            //if (grupo.Id <= 0) return false;
            //var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
            //.UseSqlServer(Constants.ConnectionString)
            //.Options;
            //using (var ctx = new SurveyDBContext(options: connectionOptions))
            //{
            //    Grupo dbGrupo = ctx.Grupos.FirstOrDefault(s => s.Id == grupo.Id);
            //    dbGrupo.Name = grupo.Name;
            //    dbGrupo.Description = grupo.Description;
            //    dbGrupo.Notas = grupo.Notas;
            //    dbGrupo.ModifiedDate = DateTime.Now;
            //    ctx.SaveChanges();
            //}
            return true;
        }
   
    }
}
