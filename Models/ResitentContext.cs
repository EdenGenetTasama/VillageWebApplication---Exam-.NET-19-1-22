using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VillageWebApplication___Exam.NET.Models
{
    public partial class ResitentContext : DbContext
    {
        public ResitentContext()
            : base("name=ResitentContext")
        {
        }

        public virtual DbSet <Resident> Residents { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
