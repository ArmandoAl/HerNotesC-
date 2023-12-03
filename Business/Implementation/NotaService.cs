using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
    public class NotaService : INotaService
    {
        private readonly INotaRepository _service;
        private readonly IPacienteRepository _usuarioService;

        public NotaService(INotaRepository notaRepo, IPacienteRepository usuarioRepo)
        {
            _service = notaRepo;
            _usuarioService = usuarioRepo;
        }

        public int Add(AddNoteModel addNotaModel)
        {
            if (addNotaModel == null) return 0;

            Nota newNota = new Nota
            {
                Title = addNotaModel.nota.Title,
                Contenido = addNotaModel.nota.Contenido,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            int idNota = _service.Add(addNotaModel.nota);

            if(idNota <= 0) return 0;

            bool relacionesHechas = true;

            foreach (var emocion in addNotaModel.emotionsIds)
            {
                bool relacion = _service.RelateEmotionWithNote(emocion, idNota);

                if(!relacion) relacionesHechas = false;
            }

            if (!relacionesHechas) return 0;

            bool relacionUser = _usuarioService.RelateNoteWithUser(idNota, addNotaModel.userId);

            if (!relacionUser) return 0;

            return idNota;

        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _service.Delete(id);
        }

        public Nota Get(int id)
        {
            if (id <= 0) return null;
            return _service.Get(id);
        }

        public List<Emocion> GetEmociones(int id)
        {
            if (id <= 0) return null;
            return _service.GetEmociones(id);
        }

        public bool Update(Nota nota)
        {
            if (nota == null) return false;
            if (nota.Id <= 0) return false;
            return _service.Update(nota);
        }
        
        public bool addNotations(AnotacionesModel model)
        {
            if (model == null) return false;
            return _service.addNotations(model);
        }
    }
}
