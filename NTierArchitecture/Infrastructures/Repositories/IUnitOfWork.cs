using NTierArchitecture.Common;

namespace NTierArchitecture.Infrastructures.Repositories;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    Task RollBackChangesAsync();
    IBaseRepository<T> Repository<T>() where T : BaseEntity;
}
