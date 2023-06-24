using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using N5PermissionUser.Domain.Entities;
using N5PermissionUser.QueryApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace N5PermissionUser.QueryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _permissionService;

        public PermissionController(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        [HttpGet]
        public async Task<IEnumerable<PermissionsEntity>> Get()
        {
            return await _permissionService.Get();
        }

        [HttpGet("{id}")]
        public async Task<PermissionsEntity> Get(long id)
        {
            return await _permissionService.Get(id);
        }
    }
}
