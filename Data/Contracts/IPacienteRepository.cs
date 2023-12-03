using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPacienteRepository : IGenericRepository<PacienteUser>
    {
        int Add(PacienteUser user);

        PacienteUser Get(int id);

        PacienteUser login(String email, String password);

        bool Delete(int id);

        bool Update(PacienteUser user);

        List<Nota> GetNotes(int id);

        DoctorUser getMyDoctor(int id);

        bool RelateNoteWithUser(int noteId, int userId);

        bool RelatePacienteWithDoctor(int doctorid, int pacienteId);
    }
}
