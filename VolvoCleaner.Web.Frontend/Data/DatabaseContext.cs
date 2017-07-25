using Microsoft.EntityFrameworkCore;
using VolvoCleaner.Web.Frontend.Models;

namespace VolvoCleaner.Web.Frontend.Data
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("CONNECTIONSTRING");

        public DbSet<FileModel> Files { get; set; }
        public DbSet<FileTypeModel> FileTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileModel>().ToTable("cleaner_files");
            modelBuilder.Entity<FileModel>().HasOne(ho => ho.Type).WithMany(wm => wm.Files).HasForeignKey(fk => fk.TypeId);

            modelBuilder.Entity<FileTypeModel>().ToTable("cleaner_filetypes");
            modelBuilder.Entity<FileTypeModel>().HasMany(hm => hm.Files).WithOne(wo => wo.Type).HasForeignKey(fk => fk.TypeId);
        }
    }
}

