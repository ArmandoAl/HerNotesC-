using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UserResponseModel
    {
       public String UserType { get; set; }

        public CompleteUserModel User { get; set; }

    }
}
