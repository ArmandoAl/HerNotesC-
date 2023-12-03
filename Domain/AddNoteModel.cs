using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AddNoteModel
    {
        public Nota nota { get; set; }
        public int userId { get; set; }

        public List<int> emotionsIds { get; set; }
    }
}
