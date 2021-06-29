using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    [Serializable]
    public class CustomerNote
    {
        public int NoteId { get; set; }
        public int CustomerId { get; set; }

        public string Note { get; set; }

    }
}
