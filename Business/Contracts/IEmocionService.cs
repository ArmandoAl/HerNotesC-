using Domain;
using System.Collections.Generic;

namespace Business.Contracts
{
    public interface IEmocionService
    {
        int Add(Emocion emocion);

        Emocion Get(int id);

        bool Update(Emocion emocion);

        bool Delete(int id);

        List<Nota> GetNotas(int id);

        List<Emocion> GetAllEmotionsFromDb();
    }
}
