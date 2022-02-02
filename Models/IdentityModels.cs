using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using Code_First_Jashim.Models;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace Code_First_Jashim.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DbCon", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Liberian>()
                        .MapToStoredProcedures();



            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<StudentGroup> StudentGroups { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Teachers> Teachers { get; set; }
        public DbSet<Liberian> Liberians { get; set; }
        public DbSet<BookIssue> BookIssues { get; set; }
        public DbSet<BookIssueLog> BookIssueLog { get; set; }
        public DbSet<ReservedBook> ReservedBooks { get; set; }
        public DbSet<FineRecords> FineRecords { get; set; }

        public System.Data.Entity.DbSet<Code_First_Jashim.ViewModel.InfoViewModel> InfoViewModels { get; set; }
    }
}