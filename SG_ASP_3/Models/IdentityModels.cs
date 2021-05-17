using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.ExaMedico> ExaMedicoes { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.Aptitud> Aptituds { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.Atenciones> Atenciones { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.Medicina> Medicinas { get; set; }

        public System.Data.Entity.DbSet<SG_ASP_3.Models.Auditoria> Auditorias { get; set; }
        public DbSet<SG_ASP_3.Models.Interconsulta> Interconsultas { get; set; }
        public DbSet<SG_ASP_3.Models.Admision> Admisions { get; set; }
    }
}