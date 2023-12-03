using System;
using System.Collections.Generic;
using Business; // Importa los servicios necesarios
using Business.Contracts;
using Data.Contracts;
using Domain;  // Asegúrate de importar el espacio de nombres correcto

namespace Business.Implementation
{
    public class GrupoService : IGrupoService
    {
        private readonly IGrupoRepository _service;

        public GrupoService(IGrupoRepository grupoRepo)
        {
            _service = grupoRepo;
        }

        public int Add(Grupo grupo)
        {
            if (grupo == null) return 0;
            return _service.Add(grupo);
        }

        public bool Delete(int id)
        {
            if (id <= 0) return false;
            return _service.Delete(id);
        }

        public Grupo Get(int id)
        {
            if (id <= 0) return null;
            return _service.Get(id);
        }

        public List<Nota> GetNotas(int id)
        {
            if (id <= 0) return null;
            return _service.GetNotas(id);
        }

        public bool Update(Grupo grupo)
        {
            if (grupo == null) return false;
            if (grupo.Id <= 0) return false;
            return _service.Update(grupo);
        }
    }
}
