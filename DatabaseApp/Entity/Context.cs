using Microsoft.EntityFrameworkCore;
using DatabaseApp.Entity;

namespace DatabaseApp.Context
{
    public class MyDbContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Depot> Depots { get; set; }
        public DbSet<Merchant> Merchant { get; set; }
        public DbSet<Order_item> Order_Items { get; set; }
        public DbSet<Region> Regions { get; set; }


        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Entities to tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<Depot>().ToTable("Depots");
            modelBuilder.Entity<Merchant>().ToTable("Merchants");
            modelBuilder.Entity<Order_item>().ToTable("Order_items");
            modelBuilder.Entity<Region>().ToTable("Regions");

            // Setting keys

            modelBuilder.Entity<Product>().HasKey(pd => pd.Id).HasName("PK_Prod");
            modelBuilder.Entity<Order>().HasKey(or => or.Id).HasName("PK_Order");
            modelBuilder.Entity<Depot>().HasKey(dp => dp.Id).HasName("PK_Depot");
            modelBuilder.Entity<Merchant>().HasKey(mrc => mrc.Id).HasName("PK_Merch");
            modelBuilder.Entity<Order_item>().HasKey(oi => oi.Id).HasName("PK_OrdItem");
            modelBuilder.Entity<Region>().HasKey(reg => reg.Id).HasName("PK_Region");

            // **Indexes**

            modelBuilder.Entity<Product>().HasIndex(p => p.Id).IsUnique().HasDatabaseName("Idx_ID");
            modelBuilder.Entity<Depot>().HasIndex(d => d.Id).IsUnique().HasDatabaseName("Idx_ID");
            modelBuilder.Entity<Order>().HasIndex(o => o.Id).IsUnique().HasDatabaseName("Idx_ID");
            modelBuilder.Entity<Merchant>().HasIndex(m => m.Id).IsUnique().HasDatabaseName("Idx_ID");
            modelBuilder.Entity<Order_item>().HasIndex(ordi => ordi.Id).IsUnique().HasDatabaseName("Idx_ID");
            modelBuilder.Entity<Region>().HasIndex(r => r.Id).IsUnique().HasDatabaseName("Idx_ID");


            // **Columns**

            //Product
            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Pd_quantity).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Pd_name).HasColumnType("nvarchar(100)").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Depot_id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Pd_price).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            //Order

            modelBuilder.Entity<Order>().Property(o => o.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Or_status).HasColumnType("nvarchar(100)").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Mc_id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.Arrived_at).HasColumnType("datetime").UseMySqlIdentityColumn().IsRequired(false);
            modelBuilder.Entity<Order>().Property(o => o.Created_at).HasColumnType("datetime").UseMySqlIdentityColumn().IsRequired();

            // Merchant
            modelBuilder.Entity<Merchant>().Property(m => m.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Merchant>().Property(m => m.Region).HasColumnType("nvarchar(100)").UseMySqlIdentityColumn().IsRequired();

            //Order Item
            modelBuilder.Entity<Order_item>().Property(ori => ori.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order_item>().Property(ori => ori.Pd_id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Order_item>().Property(ori => ori.Quantity).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            //Depot
            modelBuilder.Entity<Depot>().Property(d => d.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Depot>().Property(d => d.Region_id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();

            //Region
            modelBuilder.Entity<Region>().Property(r => r.Id).HasColumnType("int").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Region>().Property(r => r.Postcode).HasColumnType("nvarchar(10)").UseMySqlIdentityColumn().IsRequired();
            modelBuilder.Entity<Region>().Property(r => r.Reg_name).HasColumnType("nvarchar(100)").UseMySqlIdentityColumn().IsRequired();


            // ** Relationships **

            //modelBuilder.Entity<Product>().HasOne<Depot>().WithMany().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");

            modelBuilder.Entity<Product>()
            .HasOne(p => p.order_Item)
            .WithOne(ori => ori.product).HasForeignKey<Order_item>(ori => ori.Pd_id);

        }






    }


}
