using N5PermissionUser.CommandApi.Dtos;
using System.Threading.Tasks;

namespace N5PermissionUser.CommandApi.Services
{
    public interface IPermissionService
    {
        public Task AddPermission(PermissionDTO permissionDTO);

        public Task UpdatePermission(long id, PermissionDTO permissionDTO);

        public Task DeletePermission(long id);
    }
}
