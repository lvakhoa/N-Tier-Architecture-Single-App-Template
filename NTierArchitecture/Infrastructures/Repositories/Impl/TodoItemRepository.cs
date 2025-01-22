using NTierArchitecture.Database;
using NTierArchitecture.Entities.Domain;

namespace NTierArchitecture.Infrastructures.Repositories.Impl;

public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
{
    public TodoItemRepository(DatabaseContext context) : base(context) { }
}
