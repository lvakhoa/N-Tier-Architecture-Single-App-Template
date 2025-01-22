using AutoMapper;

using EVOffice_BE.Modules.TodoList.Models;

namespace EVOffice_BE.Modules.TodoList.MappingProfiles;

public class TodoListProfile : Profile
{
    public TodoListProfile()
    {
        CreateMap<CreateTodoListModel, Entities.Domain.TodoList>();

        CreateMap<Entities.Domain.TodoList, TodoListResponseModel>();
    }
}
