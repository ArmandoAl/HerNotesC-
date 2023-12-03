using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contracts
{
    public interface INotaService
    {
        int Add(AddNoteModel addNotaModel);

        Nota Get(int id);

        bool Update(Nota nota);

        bool Delete(int id);

        List<Emocion> GetEmociones(int id);

        bool addNotations(AnotacionesModel model);
    }
}
