using Microsoft.EntityFrameworkCore;
using ContactManagementAPI.Models.Entities;

namespace ContactManagementAPI.Data;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
	{
	}
	
	public DbSet<Contact> Contacts { get; set; } = null!;
}