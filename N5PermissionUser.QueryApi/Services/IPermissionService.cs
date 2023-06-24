using N5PermissionUser.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5PermissionUser.QueryApi.Services
{
    public interface IPermissionService
    {
        public Task<IEnumerable<PermissionsEntity>> Get();

        public Task<PermissionsEntity> Get(long id);
    }
}
