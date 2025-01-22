using EVOffice_BE.Common;

namespace EVOffice_BE.Modules.TodoList.Models;

public class UpdateTodoListModel
{
    public string Title { get; set; }
}

public class UpdateTodoListResponseModel : BaseResponseModel { }
