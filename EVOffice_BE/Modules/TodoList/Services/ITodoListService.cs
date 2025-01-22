using EVOffice_BE.Common;
using EVOffice_BE.Modules.TodoList.Models;

namespace EVOffice_BE.Modules.TodoList.Services;

public interface ITodoListService
{
    Task<CreateTodoListResponseModel> CreateAsync(CreateTodoListModel createTodoListModel);

    Task<BaseResponseModel> DeleteAsync(Guid id);

    Task<IEnumerable<TodoListResponseModel>> GetAllAsync();

    Task<UpdateTodoListResponseModel> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel);
}
