using Microsoft.AspNetCore.Mvc;
using N5PermissionUser.Domain.Entities;
using N5PermissionUser.QueryApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5PermissionUser.QueryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpGet]
        public async Task<IEnumerable<TypeEntity>> Get()
        {
            return await _typeService.Get();
        }

        [HttpGet("{id}")]
        public async Task<TypeEntity> Get(long id)
        {
            return await _typeService.Get(id);
        }
    }
}
