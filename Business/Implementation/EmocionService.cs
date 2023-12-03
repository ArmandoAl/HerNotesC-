using Business.Contracts;
using Data.Contracts;
using Domain;

namespace Business.Implementation
{
    public class EmocionService : IEmocionService
    {
        private readonly IEmocionRepository _service;

        public EmocionService(IEmocionRepository emocionRepo)
        {
            _service = emocionRepo;
        }

        public int Add(Emocion emocion)
        {
            if (emocion == null) return 0;
            return _service.Add(emocion);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _service.Delete(id);
        }

        public Emocion Get(int id)
        {
            if (id <= 0) return null;
            return _service.Get(id);
        }

        public List<Nota> GetNotas(int id)
        {
            if (id <= 0) return null;
            return _service.GetNotas(id);
        }

        public bool Update(Emocion emocion)
        {
            if (emocion == null) return false;
            if (emocion.Id <= 0) return false;
            return _service.Update(emocion);
        }

        public List<Emocion> GetAllEmotionsFromDb()
        {
            return _service.GetAllEmotions();
        }
    }
}
