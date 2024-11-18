using Microsoft.EntityFrameworkCore;
using Playground2.Entity;

namespace Playground2.Models;

partial class SampleDbContext: DbContext
{
    public SampleDbContext(DbContextOptions
        <SampleDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<AuthorDto> TestName { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthorDto>(entity => {
            entity.HasKey(k => k.FullName);
        });
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}