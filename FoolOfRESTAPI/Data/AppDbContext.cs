using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext{

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users{ set; get; } = null!;
    public DbSet<Message> Messages { set; get; } = null!;
    public DbSet<Chat> Chats{ set; get; } = null!;
}
