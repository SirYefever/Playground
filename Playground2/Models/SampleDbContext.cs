using Microsoft.EntityFrameworkCore;
using Playground2.Entity;
using Playground2.Temp;

namespace Playground2.Models;

public partial class SampleDbContext: DbContext
{
    public SampleDbContext(DbContextOptions
        <SampleDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<User>(entity => {
    //         entity.HasKey(k => k.Id);
    //     });
    //     OnModelCreatingPartial(modelBuilder);
    // }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}