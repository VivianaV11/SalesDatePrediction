using Microsoft.EntityFrameworkCore;

namespace SalesDatePrediction.API.Models
{
    public class SalesDbContext : DbContext
    {
        public SalesDbContext(DbContextOptions<SalesDbContext> options) : base(options) { }

        public DbSet<Category> categories { get; set; }
        public DbSet<Supplier> suppliers { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Shipper> shippers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<CustomerOrderPredictionDto> CustomerOrderPredictions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customers", schema: "Sales");
            modelBuilder.Entity<Category>().ToTable("Categories", schema: "Production");
            modelBuilder.Entity<Employee>().ToTable("Employees", schema: "Employees");
            modelBuilder.Entity<Order>().ToTable("Orders", schema: "Sales");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails", schema: "Sales");
            modelBuilder.Entity<Shipper>().ToTable("Shippers", schema: "Sales");
            modelBuilder.Entity<Product>().ToTable("Products", schema: "Production");
            modelBuilder.Entity<CustomerOrderPredictionDto>().HasNoKey();

        }
    }
}
