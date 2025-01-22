using EVOffice_BE.Database;
using EVOffice_BE.Entities.Domain;

namespace EVOffice_BE.Infrastructures.Repositories.Impl;

public class TodoItemRepository : BaseRepository<TodoItem>, ITodoItemRepository
{
    public TodoItemRepository(DatabaseContext context) : base(context) { }
}
