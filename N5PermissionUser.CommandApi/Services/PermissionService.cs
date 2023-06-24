using N5PermissionUser.CommandApi.Dtos;
using N5PermissionUser.Domain.Entities;
using N5PermissionUser.Domain.UnitOfWork;
using System.Threading.Tasks;

namespace N5PermissionUser.CommandApi.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPermission(PermissionDTO permissionDTO)
        {
            var permission = new PermissionsEntity
            {
                FirstName = permissionDTO.FirstName,
                LastName = permissionDTO.LastName,
                DateOfPermission = System.DateTime.Now,
                TypeId = permissionDTO.TypeId,
            };

            _unitOfWork.PermissionsRepository.Add(permission);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePermission(long id, PermissionDTO permissionDTO)
        {
            PermissionsEntity permission = _unitOfWork.PermissionsRepository.Get(t => t.Id == id);
            permission.FirstName = permissionDTO.FirstName;
            permission.LastName = permissionDTO.LastName;
            permission.TypeId = permissionDTO.TypeId;

            _unitOfWork.PermissionsRepository.Update(permission);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePermission(long id)
        {
            PermissionsEntity permission = _unitOfWork.PermissionsRepository.Get(t => t.Id == id);

            _unitOfWork.PermissionsRepository.Remove(permission);
            await _unitOfWork.CommitAsync();
        }
    }
}
