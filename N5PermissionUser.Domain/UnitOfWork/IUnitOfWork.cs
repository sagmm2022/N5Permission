using N5PermissionUser.Domain.Repositories;

namespace N5PermissionUser.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        IPermissionsRepository PermissionsRepository { get; }
        ITypeRepository TypeRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
