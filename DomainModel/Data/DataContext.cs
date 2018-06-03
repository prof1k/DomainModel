using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel.Entity;
using System.Data.Entity;

namespace DomainModel.Data
{
    public class DataContext : DbContext
    {
        public DbSet<ICC> ICC { get; set; }
        public DbSet<Incidents> Incidents { get; set; }
        public DbSet<LastMileType> LastMileType { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<PostOffice> PostOffice { get; set; }
        public DbSet<TypeOfService> TypeOfService { get; set; }
        public DbSet<Users> Users { get; set; }

        public DataContext() : base(new Constants().getConnection())// : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<InsuranceContract>().ToTable("InsuranceContract");
        }*/
    }
}
