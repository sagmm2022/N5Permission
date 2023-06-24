using N5PermissionUser.Domain.Entities;
using N5PermissionUser.Domain.Repositories;

namespace N5PermissionUser.Infrastructure.Repositories
{
    public class PermissionsRepository : GenericRepository<PermissionsEntity>, IPermissionsRepository
    {
        public PermissionsRepository(N5PermissionUserContext dbContext) : base(dbContext)
        {
        }
    }
}
