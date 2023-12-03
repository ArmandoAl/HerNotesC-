using Data.Contracts;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Text.Json;


namespace Data.Implementation
{
    public class NotaRepository : INotaRepository
    {
        public int Add(Nota nota)
        {
            if (nota == null) return 0;

            nota.CreatedDate = DateTime.Now;
            nota.ModifiedDate = DateTime.Now;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Data.Helpers.Constants.ConnectionString)
               .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                ctx.Notas.Add(nota);
                ctx.SaveChanges();
                return nota.Id;
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
                var nota = ctx.Notas.FirstOrDefault(x => x.Id == id);

                if (nota != null)
                {
                    ctx.Notas.Remove(nota);
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public Nota Get(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                Nota nota = ctx.Notas.Include(x => x.Contenido).Include(s => s.Emociones).Where(x => x.Id == id).FirstOrDefault();
                return nota;
            }
        }


        public List<Emocion> GetEmociones(int id)
        {
            if (id <= 0) return null;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
                .UseSqlServer(Data.Helpers.Constants.ConnectionString)
                .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                return ctx.Notas.Where(n => n.Id == id).SelectMany(n => n.Emociones).ToList();
            }
        }

        public bool RelateEmotionWithNote(int emotionId, int noteId)
        {
            if (emotionId <= 0) return false;
            if (noteId <= 0) return false;
            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
              .UseSqlServer(Data.Helpers.Constants.ConnectionString)
              .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                var emotion = ctx.Emociones.Include(x => x.Notas).FirstOrDefault(u => u.Id == emotionId);
                var nota = ctx.Notas.FirstOrDefault(u => u.Id == noteId);

                if(emotion != null && nota != null)
                {
                    emotion.Notas.Add(nota);
                    ctx.SaveChanges();
                }
                else
                {
                    return false;
                }
                return true;
            }
        }

        public bool Update(Nota nota)
        {
            if (nota == null) return false;
            if (nota.Id <= 0) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
               .UseSqlServer(Data.Helpers.Constants.ConnectionString)
               .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                Nota existingNota = ctx.Notas.FirstOrDefault(n => n.Id == nota.Id);
                if (existingNota != null)
                {
                    existingNota.Title = nota.Title;
                    existingNota.Contenido = nota.Contenido;
                    //existingNota.Emociones = nota.Emociones;
                    existingNota.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                    return true;
                }
            }

            return false;
        }


        public bool addNotations(AnotacionesModel model)
        {
            if (model == null) return false;

            var connectionOptions = new DbContextOptionsBuilder<SurveyDBContext>()
             .UseSqlServer(Data.Helpers.Constants.ConnectionString)
             .Options;

            using (var ctx = new SurveyDBContext(options: connectionOptions))
            {
                Nota oldNote = ctx.Notas.FirstOrDefault(n => n.Id == model.noteId);

                if(oldNote != null)
                {
                    oldNote.Notaciones = model.anotacion;
                    oldNote.ModifiedDate = DateTime.Now;
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;

        }
    }
}
