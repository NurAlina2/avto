//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace avto.Components
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProbaaEntities : DbContext
    {
        public ProbaaEntities()
            : base("name=ProbaaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categor> Categor { get; set; }
        public virtual DbSet<DocumentByProduct> DocumentByProduct { get; set; }
        public virtual DbSet<ExecutionStage> ExecutionStage { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<ManufacturerCountry> ManufacturerCountry { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCountry> ProductCountry { get; set; }
        public virtual DbSet<ProductOrder> ProductOrder { get; set; }
        public virtual DbSet<ProductShipment> ProductShipment { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceOrder> ServiceOrder { get; set; }
        public virtual DbSet<SheetFormat> SheetFormat { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
    }
}
