using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class CollabratorEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabID { get; set; }
        public string? CollabEmail { get; set; }
        public DateTime? Modifiedat { get; set; }


        [ForeignKey("UserDetail")]
        public long UserId { get; set; }
        [ForeignKey("NoteEntity")]
        public long NoteId { get; set; }
        public virtual UserTable? UserDetail { get; set; }
        public virtual MyNoteEntity? NoteEntity { get; set; }
    }
}
