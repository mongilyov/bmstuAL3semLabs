using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data;

namespace lab13
{
	public class AppDbContext : DbContext
	{
		public DbSet<Passenger> Passengers { get; set; }
		public DbSet<Ticket> Tickets { get; set; }
		public DbSet<Train> Trains { get; set; }

		public AppDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=lab12;User Id = sa; Password = MyStr0ngPassword!");
		}
	}
}

