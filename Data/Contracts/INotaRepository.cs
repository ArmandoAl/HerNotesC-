using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contracts
{
    public interface INotaRepository : IGenericRepository<Nota>
    {
        List<Emocion> GetEmociones(int id);
        bool Update(Nota nota);

        public bool RelateEmotionWithNote(int emotionId, int noteId);

        bool addNotations(AnotacionesModel model);
    }
}
