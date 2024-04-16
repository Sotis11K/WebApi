using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts;

public class ApiContexts(DbContextOptions<ApiContexts> options) : DbContext(options)
{
    public DbSet<SubscribersEntity> Subscribers { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<ContactEntity> Contact { get; set; }
    public DbSet<UserEntity> Users { get; set; }



}
