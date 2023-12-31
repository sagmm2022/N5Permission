﻿using N5PermissionUser.Domain.Entities;
using N5PermissionUser.Domain.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5PermissionUser.QueryApi.Services
{
    public class TypeService : ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TypeEntity>> Get()
        {
            return await _unitOfWork.TypeRepository.GetAllAsync();
        }

        public async Task<TypeEntity> Get(long id)
        {
            return await _unitOfWork.TypeRepository.GetAsync(t => t.Id == id);
        }
    }
}
