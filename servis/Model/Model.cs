namespace Servis.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DDDBEntities : DbContext
    {
        public DDDBEntities()
            : base("name=DDDBEntities")
        {
        }

        public virtual DbSet<Kullanici> Kullanici { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
