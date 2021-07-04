using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    [Serializable]
    public class CustomerNote
    {
        [Key]
        public int NoteId { get; set; }
        //[Key, Column(Order = 1)]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The field is required")]
        public string Note { get; set; }

    }
}
