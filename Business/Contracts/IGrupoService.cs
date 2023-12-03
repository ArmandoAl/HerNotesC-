﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IGrupoService
    {
        int Add(Grupo grupo);

        Grupo Get(int id);

        bool Delete(int id);

        bool Update(Grupo grupo);

        List<Nota> GetNotas(int id);
    }
}

