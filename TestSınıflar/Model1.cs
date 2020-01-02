namespace TestSınıflar
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Table_KategorikOran> Table_KategorikOran { get; set; }
        public virtual DbSet<Table_Kategoriler> Table_Kategoriler { get; set; }
        public virtual DbSet<Table_Kullanici> Table_Kullanici { get; set; }
        public virtual DbSet<Table_Resimler> Table_Resimler { get; set; }
        public virtual DbSet<Table_Rol> Table_Rol { get; set; }
        public virtual DbSet<Table_Soru> Table_Soru { get; set; }
        public virtual DbSet<Table_SoruCevap> Table_SoruCevap { get; set; }
        public virtual DbSet<Table_Test> Table_Test { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table_Soru>()
                .Property(e => e.DogruCevap)
                .IsFixedLength();
        }
    }
}
