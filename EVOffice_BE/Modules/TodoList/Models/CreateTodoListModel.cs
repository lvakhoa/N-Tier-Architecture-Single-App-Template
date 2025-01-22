using EVOffice_BE.Common;

namespace EVOffice_BE.Modules.TodoList.Models;

public class CreateTodoListModel
{
    public string Title { get; set; }
}

public class CreateTodoListResponseModel : BaseResponseModel { }
