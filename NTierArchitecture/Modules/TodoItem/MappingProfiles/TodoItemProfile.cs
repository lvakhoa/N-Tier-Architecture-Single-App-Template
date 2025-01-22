using AutoMapper;

using NTierArchitecture.Modules.TodoItem.Models;

namespace NTierArchitecture.Modules.TodoItem.MappingProfiles;

public class TodoItemProfile : Profile
{
    public TodoItemProfile()
    {
        CreateMap<CreateTodoItemModel, Entities.Domain.TodoItem>()
            .ForMember(ti => ti.IsDone, ti => ti.MapFrom(cti => false));

        CreateMap<UpdateTodoItemModel, Entities.Domain.TodoItem>();

        CreateMap<Entities.Domain.TodoItem, TodoItemResponseModel>();
    }
}
