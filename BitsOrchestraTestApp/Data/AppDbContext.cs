using BitsOrchestraTestApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BitsOrchestraTestApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(
                new Person() { Id = 1, Name = "Flory McLuckie", DateOfBirth = new DateTime(2023, 11, 22), Married = true, Phone = "678-606-5234", Salary = 5739 },
                new Person() { Id = 2, Name = "Angelo Iacobetto", DateOfBirth = new DateTime(2024, 3, 12), Married = true, Phone = "718-384-4919", Salary = 504 },
                new Person() { Id = 3, Name = "Eada Frome", DateOfBirth = new DateTime(2024, 8, 10), Married = true, Phone = "747-226-5268", Salary = 23585 },
                new Person() { Id = 4, Name = "Ibbie Glewe", DateOfBirth = new DateTime(2023, 10, 19), Married = false, Phone = "505-161-4189", Salary = 36789 },
                new Person() { Id = 5, Name = "Ashly Waldie", DateOfBirth = new DateTime(2024, 6, 24), Married = false, Phone = "294-825-5871", Salary = 944 },
                new Person() { Id = 6, Name = "Holden Ridgeway", DateOfBirth = new DateTime(2024, 3, 14), Married = true, Phone = "219-790-4260", Salary = 1 },
                new Person() { Id = 7, Name = "Arnuad Dimitriou", DateOfBirth = new DateTime(2024, 4, 25), Married = true, Phone = "787-414-1823", Salary = 10 },
                new Person() { Id = 8, Name = "Lorianne Sanney", DateOfBirth = new DateTime(2024, 1, 23), Married = false, Phone = "536-923-6367", Salary = 4327 },
                new Person() { Id = 9, Name = "Filmer Basindale", DateOfBirth = new DateTime(2024, 5, 4), Married = false, Phone = "937-235-4935", Salary = 17243 },
                new Person() { Id = 10, Name = "Rodolphe Cassie", DateOfBirth = new DateTime(2024, 5, 21), Married = true, Phone = "962-414-2092", Salary = 7 }
        );
        }
    }
}
