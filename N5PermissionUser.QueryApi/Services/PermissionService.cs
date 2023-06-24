using N5PermissionUser.Domain.Entities;
using N5PermissionUser.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5PermissionUser.QueryApi.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PermissionsEntity>> Get()
        {
            return await _unitOfWork.PermissionsRepository.GetAllAsync();
        }

        public async Task<PermissionsEntity> Get(long id)
        {
            return await _unitOfWork.PermissionsRepository.GetAsync(t => t.Id == id);
        }
    }
}
