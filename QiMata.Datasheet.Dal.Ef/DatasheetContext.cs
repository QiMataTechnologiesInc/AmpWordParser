namespace QiMata.Datasheet.Dal.Ef
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatasheetContext : DbContext
    {
        public DatasheetContext()
            : base("name=DatasheetContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Datasheet> Datasheets { get; set; }
        public virtual DbSet<Section> Sections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Category1)
                .WithOptional(e => e.Category2)
                .HasForeignKey(e => e.ParentCategoryId);

            modelBuilder.Entity<Datasheet>()
                .Property(e => e.DateSaved)
                .HasPrecision(0);

            modelBuilder.Entity<Datasheet>()
                .Property(e => e.PdfProvider)
                .IsUnicode(false);

            modelBuilder.Entity<Datasheet>()
                .HasMany(e => e.Sections)
                .WithRequired(e => e.Datasheet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Section>()
                .Property(e => e.SectionText)
                .IsUnicode(false);

            modelBuilder.Entity<Section>()
                .HasMany(e => e.Section1)
                .WithOptional(e => e.Section2)
                .HasForeignKey(e => e.ParentSectionId);
        }
    }
}
