using Domain;
using System;
using System.Collections.Generic;

namespace Data.Contracts
{
    public interface IEmocionRepository : IGenericRepository<Emocion>
    {
        List<Nota> GetNotas(int id);
        bool Update(Emocion emocion);

        List<Emocion> GetAllEmotions();
    }
}
