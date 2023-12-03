using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Login
    {
        public String email {  get; set; }
        public String password { get; set; }
    }
}
