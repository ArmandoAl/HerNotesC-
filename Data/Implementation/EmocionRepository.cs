using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Implementation
{
    public class EmocionRepository : IEmocionRepository
    {
        public int Add(Emocion emocion)
        {
            if (emocion == null) return 0;

            emocion.CreatedDate = DateTime.Now;
            emocion.ModifiedDate = DateTime.Now;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Data.Helpers.Constants.ConnectionString)
               .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                ctx.Emociones.Add(emocion);
                ctx.SaveChanges();
                return emocion.Id;
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
                var emocion = ctx.Emociones.FirstOrDefault(x => x.Id == id);

                if (emocion != null)
                {
                    ctx.Emociones.Remove(emocion);
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public Emocion Get(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return ctx.Emociones.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Nota> GetNotas(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return null;
            }
        }

        public bool Update(Emocion emocion)
        {
            if (emocion == null) return false;
            if (emocion.Id <= 0) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Data.Helpers.Constants.ConnectionString)
               .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                Emocion existingEmocion = ctx.Emociones.FirstOrDefault(e => e.Id == emocion.Id);
                if (existingEmocion != null)
                {
                    existingEmocion.Tipo = emocion.Tipo;
                    existingEmocion.Valor = emocion.Valor;
                    existingEmocion.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public List<Emocion> GetAllEmotions()
        {
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Data.Helpers.Constants.ConnectionString)
             .Options;

            List<Emocion> emocions;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                emocions = ctx.Emociones.ToList();
            }

            return emocions;
         }
    }
}
