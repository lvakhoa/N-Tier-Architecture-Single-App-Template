using NTierArchitecture.Common;

namespace NTierArchitecture.Modules.TodoItem.Models;

public class CreateTodoItemModel
{
    public Guid TodoListId { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }
}

public class CreateTodoItemResponseModel : BaseResponseModel { }
