using Data;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IPacienteService
    {
        int Add(PacienteUser user);

        PacienteUser Get(int id);

        PacienteUser login(string email, string password);

        bool Delete(int id);

        bool Update(PacienteUser user);

        DoctorUser getMyDoctor(int id);

        List<Nota> GetNotes(int id);

        bool RelateNoteWithUser(int noteId, int userId);

        bool RelatePacienteWithDoctor(int doctorid, int pacienteId);

        UserResponseModel otherLogin(string email, string password);


    }
}
