using EVOffice_BE.Common;

namespace EVOffice_BE.Modules.TodoItem.Models;

public class TodoItemResponseModel : BaseResponseModel
{
    public string Title { get; set; }

    public string Body { get; set; }

    public bool IsDone { get; set; }
}
