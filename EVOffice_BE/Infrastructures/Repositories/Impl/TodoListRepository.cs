using EVOffice_BE.Database;
using EVOffice_BE.Entities.Domain;

namespace EVOffice_BE.Infrastructures.Repositories.Impl;

public class TodoListRepository : BaseRepository<TodoList>, ITodoListRepository
{
    public TodoListRepository(DatabaseContext context) : base(context) { }
}
