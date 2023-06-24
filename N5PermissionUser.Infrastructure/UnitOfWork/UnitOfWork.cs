using N5PermissionUser.Domain.Repositories;
using N5PermissionUser.Domain.UnitOfWork;
using N5PermissionUser.Infrastructure.Repositories;

namespace N5PermissionUser.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly N5PermissionUserContext _dbContext;
        private IPermissionsRepository _permissionRepository;
        private ITypeRepository _typeRepository;

        public UnitOfWork(N5PermissionUserContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IPermissionsRepository PermissionsRepository
        {
            get { return _permissionRepository = _permissionRepository ?? new PermissionsRepository(_dbContext); }
        }

        public ITypeRepository TypeRepository
        {
            get { return _typeRepository = _typeRepository ?? new TypeRepository(_dbContext); }
        }

        public void Commit()
            => _dbContext.SaveChanges();


        public async Task CommitAsync()
            => await _dbContext.SaveChangesAsync();


        public void Rollback()
            => _dbContext.Dispose();


        public async Task RollbackAsync()
            => await _dbContext.DisposeAsync();
    }
}
