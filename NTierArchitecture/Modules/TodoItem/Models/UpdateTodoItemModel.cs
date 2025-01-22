using NTierArchitecture.Common;

namespace NTierArchitecture.Modules.TodoItem.Models;

public class UpdateTodoItemModel
{
    public Guid TodoListId { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }

    public bool IsDone { get; set; }
}

public class UpdateTodoItemResponseModel : BaseResponseModel { }
