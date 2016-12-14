using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace servis.Model
{

    public partial class DDDBEntities : DbContext
    {
        public DDDBEntities()
            : base("name=DDDBEntities")
        {
        }

        public virtual DbSet<TKullanici> Kullanicilar { get; set; }
        public virtual DbSet<TSoru> Sorular { get; set; }
        public virtual DbSet<TCevap> Cevaplar { get; set; }
        public virtual DbSet<TYorum> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
