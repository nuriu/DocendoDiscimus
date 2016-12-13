using System.Data.Entity;

namespace servis.Model
{

    public partial class DDDBEntities : DbContext
    {
        public DDDBEntities()
            : base("name=DDDBEntities")
        {
        }

        public virtual DbSet<Kullanici> Kullanicilar { get; set; }
        public virtual DbSet<Soru> Sorular { get; set; }
        public virtual DbSet<Cevap> Cevaplar { get; set; }
        public virtual DbSet<Yorum> Yorumlar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soru>().HasRequired(s => s.Soran).WithMany(k => k.SorduguSorular);
            modelBuilder.Entity<Cevap>().HasRequired(c => c.VerildigiSoru).WithMany(s => s.Cevaplar);
            modelBuilder.Entity<Yorum>().HasRequired(y => y.YapildigiCevap).WithMany(c => c.Yorumlar);
        }
    }
}
