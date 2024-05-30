using Microsoft.EntityFrameworkCore;
using ShiftsLoggerApi.Models;

namespace ShiftsLoggerApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<Worker> Workers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}