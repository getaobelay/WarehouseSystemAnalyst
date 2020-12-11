using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WarehouseSystemAnalyst.Server.Models;

namespace WarehouseSystemAnalyst.Server.Data
{
    public class UserDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public UserDbContext(
            DbContextOptions<UserDbContext> options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }
    }
}