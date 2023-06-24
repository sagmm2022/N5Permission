using Microsoft.EntityFrameworkCore;
using N5PermissionUser.Domain.Entities;

namespace N5PermissionUser.Infrastructure
{
    public class N5PermissionUserContext : DbContext
    {
        public DbSet<PermissionsEntity> Permissions { get; set; }

        public DbSet<TypeEntity> Type { get; set; }

        public N5PermissionUserContext(DbContextOptions<N5PermissionUserContext> options) : base(options) { }

    }
}