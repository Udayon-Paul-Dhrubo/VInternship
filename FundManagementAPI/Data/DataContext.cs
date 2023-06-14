

using Microsoft.EntityFrameworkCore;

namespace FundManagementAPI.Data
{
    public class DataContext : DbContext 
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<System_User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Linked_Account> LinkedAccounts { get; set; }

        public DbSet<DepositSchema> DepositSchemas { get; set; }

        public DbSet<DepositAccount> DepositAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            // Linked_Account Table
            modelBuilder.Entity<Linked_Account>()
                .HasKey(la => new { la.System_User_Id, la.Account_Id });

            modelBuilder.Entity<Linked_Account>()
                .HasOne(su => su.System_User)
                .WithMany(la => la.Linked_Accounts)
                .HasForeignKey(su => su.System_User_Id);

            modelBuilder.Entity<Linked_Account>()
                .HasOne(a => a.Account)
                .WithOne(la => la.Linked_Account)
                .HasForeignKey<Linked_Account>(a => a.Account_Id);


            // Account Table
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.Customer_Id);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Branch)
                .WithMany(b => b.Accounts)
                .HasForeignKey(a => a.Branch_Id);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Product)
                .WithMany(p => p.Accounts)
                .HasForeignKey(a => a.Product_Id);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Linked_Account)
                .WithOne(la => la.Account)
                .HasForeignKey<Linked_Account>(la => la.Account_Id);


            // DepositAccount Table
            modelBuilder.Entity<DepositAccount>()
                .HasOne(a => a.Account)
                .WithMany(da => da.DepositAccounts)
                .HasForeignKey(a => a.Account_Id);

            modelBuilder.Entity<DepositAccount>()
                .HasOne(ds => ds.DepositSchema)
                .WithMany(da => da.DepositAccounts)
                .HasForeignKey(ds => ds.DepositSchema_Id);           


        }
  
    }
}
