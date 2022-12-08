using Microsoft.EntityFrameworkCore;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoLayer.Context
{
    public class FundooDBContext:DbContext//represent a database connection and set of table
    {
        public FundooDBContext(DbContextOptions options):base(options) {} 
        public DbSet<UserTable> UserTable{ get; set; }//creating table (name of table UserDetailTable)
        public DbSet<MyNoteEntity> NoteTable { get; set; }//creating table (name of table NoteEntityTable)

        public DbSet<LabelEntity> LabelTable { get; set; }
        public DbSet<CollabratorEntity> CollabTable { get; set; }
    }
}
