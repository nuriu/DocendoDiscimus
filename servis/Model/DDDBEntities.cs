namespace servis.Model
{
    using System.Data.Entity;

    public partial class DDDBEntities : DbContext
    {
        public DDDBEntities()
            : base("name=DDDBEntities")
        {
        }

        public virtual DbSet<Kullanici> Kullanicilar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
