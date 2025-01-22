using EVOffice_BE.Common;

namespace EVOffice_BE.Infrastructures.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task RollBackChangesAsync();
    IBaseRepository<T> Repository<T>() where T : BaseEntity;
}
