using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class LabalEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string LabelName { get; set; }

        [ForeignKey("UserTable")]
        public long UserId { get; set; }
        [ForeignKey("MyNoteEntity")]
        public long NoteID { get; set; }
        public virtual UserTable userEntity { get; set; }
        public virtual MyNoteEntity noteEntity { get; set; }
    }
}
