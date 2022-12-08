using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace RepoLayer.Entity
{
    public class LabelEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }
        public string? LabelName { get; set; }
       
        [ForeignKey("UserDetail")]
        public long UserId { get; set; }
        [ForeignKey("NoteEntity")]

        public long NoteId { get; set; }
        [JsonIgnore]

        public virtual UserTable? UserDetail { get; set; }
        [JsonIgnore]

        public virtual MyNoteEntity? NoteEntity { get; set; }
    }
}
