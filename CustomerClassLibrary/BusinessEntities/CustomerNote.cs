using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "The field is required")]
        public string Note { get; set; }

    }
}
