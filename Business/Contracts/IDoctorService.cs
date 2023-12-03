using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IDoctorService
    {
        int Add(DoctorUser user);

        DoctorUser Get(int id);

        DoctorUser login(String email, String password);

        bool Delete(int id);

        bool Update(DoctorUser user);

        List<PacienteUser> GetUsers(int id);
    }
}
