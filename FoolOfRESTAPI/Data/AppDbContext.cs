using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}

    public DbSet<User> Users{get;} = null!;
    public DbSet<Message> Messages{get;} = null!;
}
