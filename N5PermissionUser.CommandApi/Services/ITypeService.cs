using N5PermissionUser.CommandApi.Dtos;
using System.Threading.Tasks;

namespace N5PermissionUser.CommandApi.Services
{
    public interface ITypeService
    {
        public Task AddType(TypeDTO typeDTO);

        public Task UpdateType(long id, TypeDTO typeDTO);

        public Task DeleteType(long id);
    }
}
