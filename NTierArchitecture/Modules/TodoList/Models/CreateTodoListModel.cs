using NTierArchitecture.Common;

namespace NTierArchitecture.Modules.TodoList.Models;

public class CreateTodoListModel
{
    public string Title { get; set; }
}

public class CreateTodoListResponseModel : BaseResponseModel { }
