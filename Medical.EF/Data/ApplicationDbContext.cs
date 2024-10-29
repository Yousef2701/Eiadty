using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Medical.Core.Models;
using Medical.EF.Models;

namespace Medical.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostImage>()
           .HasKey(b => new { b.PostId, b.Image_Url });

            builder.Entity<PostVedio>()
           .HasKey(b => new { b.PostId, b.Vedio_Url });

            builder.Entity<Like>()
           .HasKey(b => new { b.PostId, b.Patient_Phone });

            builder.Entity<Diseases>()
           .HasKey(b => new { b.Diseases_Name, b.Patient_Phone });

            builder.Entity<Operation>()
           .HasKey(b => new { b.Operation_Name, b.Patient_Phone });

            builder.Entity<Drug>()
           .HasKey(b => new { b.Drug_Name, b.Patient_Phone });
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostImage> PostImages { get; set; }

        public DbSet<PostVedio> PostVedios { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Check> Checks { get; set; }

        public DbSet<Ray> Rays { get; set; }

        public DbSet<Analysis> Analyses { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Diseases> Diseases { get; set; }

        public DbSet<Operation> Operations { get; set; }

        public DbSet<Drug> Drugs { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

    }
}
