using Duende.IdentityServer.EntityFramework.Options;
using JenHairousApp.Server.Models;
using JenHairousApp.Shared.DBEntities;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace JenHairousApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Product>       Products            { get; set; }

        public DbSet<Category>      Categories          { get; set; }
    }
}