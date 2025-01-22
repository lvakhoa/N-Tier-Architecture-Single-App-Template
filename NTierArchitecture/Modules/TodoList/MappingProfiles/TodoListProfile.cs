using AutoMapper;

using NTierArchitecture.Modules.TodoList.Models;

namespace NTierArchitecture.Modules.TodoList.MappingProfiles;

public class TodoListProfile : Profile
{
    public TodoListProfile()
    {
        CreateMap<CreateTodoListModel, Entities.Domain.TodoList>();

        CreateMap<Entities.Domain.TodoList, TodoListResponseModel>();
    }
}
