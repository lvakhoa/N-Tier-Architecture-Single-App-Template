using NTierArchitecture.Database;
using NTierArchitecture.Entities.Domain;

namespace NTierArchitecture.Infrastructures.Repositories.Impl;

public class TodoListRepository : BaseRepository<TodoList>, ITodoListRepository
{
    public TodoListRepository(DatabaseContext context) : base(context) { }
}
