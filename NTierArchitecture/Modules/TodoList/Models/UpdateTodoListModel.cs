using NTierArchitecture.Common;

namespace NTierArchitecture.Modules.TodoList.Models;

public class UpdateTodoListModel
{
    public string Title { get; set; }
}

public class UpdateTodoListResponseModel : BaseResponseModel { }
