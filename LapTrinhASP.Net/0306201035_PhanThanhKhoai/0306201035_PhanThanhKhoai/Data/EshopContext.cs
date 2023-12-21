using System;
using _0306201035_PhanThanhKhoai.Models;
using Microsoft.EntityFrameworkCore;

namespace _0306201035_PhanThanhKhoai.Data
{
	public class EshopContext : DbContext
	{
		public EshopContext(DbContextOptions<EshopContext>options): base(options)
		{
		}
		public DbSet<Classroom> Classrooms { get; set; }
		public DbSet<Student> Students { get; set; }
	}
}

