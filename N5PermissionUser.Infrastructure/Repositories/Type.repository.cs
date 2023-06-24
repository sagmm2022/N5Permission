using N5PermissionUser.Domain.Entities;
using N5PermissionUser.Domain.Repositories;

namespace N5PermissionUser.Infrastructure.Repositories
{
    public class TypeRepository : GenericRepository<TypeEntity>, ITypeRepository
    {
        public TypeRepository(N5PermissionUserContext dbContext) : base(dbContext)
        {
        }
    }
}
