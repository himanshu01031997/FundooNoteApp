using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class MyNoteEntity
    {
        [Key]//primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//automatically pk generate when we insert it
        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime Reminder { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public bool Archive { get; set; }
        public bool PinNotes { get; set; }
        public bool Trash { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [ForeignKey("UserDetail")]
        public long UserId { get; set; }
        [JsonIgnore]
        public virtual UserTable? UserDetail { get; set; }

    }
}
