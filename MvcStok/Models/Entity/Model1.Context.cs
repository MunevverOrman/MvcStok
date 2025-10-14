

namespace MvcStok.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MvcDbStokEntities : DbContext
    {
        public MvcDbStokEntities()
            : base("name=MvcDbStokEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLKATEGORILER> TBLKATEGORILER { get; set; }
        public virtual DbSet<TBLMUSTERILER> TBLMUSTERILER { get; set; }
        public virtual DbSet<TBLSATISLAR> TBLSATISLAR { get; set; }
        public virtual DbSet<TBLURUNLER> TBLURUNLER { get; set; }
    }
}
