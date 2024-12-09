using Microsoft.EntityFrameworkCore;
using Todo.API.Entities;

namespace Todo.API.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public required DbSet<ListTitle> ListTitles { get; set; }
        public required DbSet<ListItem> ListItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListTitle>().ToTable(nameof(ListTitle));
            modelBuilder.Entity<ListItem>().ToTable(nameof(ListItem));

            modelBuilder.Entity<ListTitle>()
                .HasMany(lt => lt.Items)
                .WithOne(li => li.ListTitle)
                .HasForeignKey(li => li.ListTitleId);
        }
    }
}
