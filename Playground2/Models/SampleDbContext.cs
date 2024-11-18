using Microsoft.EntityFrameworkCore;
using Playground2.Entity;

namespace Playground2.Models;

public partial class SampleDbContext: DbContext
{
    public SampleDbContext(DbContextOptions
        <SampleDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<UserRegisterModel> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserRegisterModel>(entity => {
            entity.HasKey(k => k.FullName);
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}