using System;

using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

using RazorModels;

namespace RazorServices
{
	public class AppDbContext : DbContext
	{
		public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Train> Trains { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Data Source=localhost; Initial Catalog=lab12; User Id=sa; Password=MyStr0ngPassword!;"); // TODO
        }
    }
}

