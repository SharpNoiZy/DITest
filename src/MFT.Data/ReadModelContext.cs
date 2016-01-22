using MFT.Core.Data;
using MFT.Core.Data.Models;
using MFT.Core.EventSourcing.Contracts;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Data
{
	public class ReadModelContext : DbContext, IReadModelContext
	{
		public DbSet<User> Users { get; set; }


		public ReadModelContext()
		{
			Database.EnsureCreated();
		}


		public ReadModelContext(DbContextOptions options) : base(options)
		{
			Database.EnsureCreated();
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "test.db" };
				var connectionString = connectionStringBuilder.ToString();
				var connection = new SqliteConnection(connectionString);

				optionsBuilder.UseSqlite(connection);
			}
		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<User>().HasKey("Username");
		}
	}
}