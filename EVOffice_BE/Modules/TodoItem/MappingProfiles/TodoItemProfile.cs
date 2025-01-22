using AutoMapper;

using EVOffice_BE.Modules.TodoItem.Models;

namespace EVOffice_BE.Modules.TodoItem.MappingProfiles;

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
