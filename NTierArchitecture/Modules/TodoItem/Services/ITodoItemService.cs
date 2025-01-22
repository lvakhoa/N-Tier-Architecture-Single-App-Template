using NTierArchitecture.Common;
using NTierArchitecture.Modules.TodoItem.Models;

namespace NTierArchitecture.Modules.TodoItem.Services;

public interface ITodoItemService
{
    Task<CreateTodoItemResponseModel> CreateAsync(CreateTodoItemModel createTodoItemModel,
        CancellationToken cancellationToken = default);

    Task<BaseResponseModel> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<TodoItemResponseModel>>
        GetAllByListIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<UpdateTodoItemResponseModel> UpdateAsync(Guid id, UpdateTodoItemModel updateTodoItemModel,
        CancellationToken cancellationToken = default);
}
