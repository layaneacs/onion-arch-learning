using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infra.Context;
public class EFDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<TaskItem> Tasks { get; set; }
}
