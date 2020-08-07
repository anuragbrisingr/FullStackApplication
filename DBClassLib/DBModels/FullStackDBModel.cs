using System.Data.Entity;

namespace DBClassLib.DBModels
{
    public partial class FullStackDBModel : DbContext
    {
        public FullStackDBModel()
            : base("name=FullStackDBModel")
        {
        }

        public virtual DbSet<CustomerTable> CustomerTables { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
        public virtual DbSet<ProductTable> ProductTables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTable>()
                .Property(e => e.OrderAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<OrderTable>()
                .HasMany(e => e.CustomerTables)
                .WithOptional(e => e.OrderTable)
                .HasForeignKey(e => e.OrderID);

            modelBuilder.Entity<ProductTable>()
                .HasMany(e => e.OrderTables)
                .WithOptional(e => e.ProductTable)
                .HasForeignKey(e => e.ProductID);
        }
    }
}
