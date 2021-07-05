using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClassLibrary
{
    [Serializable, Table("dbo.customer_note")]
    public class CustomerNote
    {
        [Key, Column("note_id")]
        public int NoteId { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The field is required"), Column("note")]
        public string Note { get; set; }

    }
}
