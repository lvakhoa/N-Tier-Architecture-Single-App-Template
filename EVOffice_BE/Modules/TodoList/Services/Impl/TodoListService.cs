using AutoMapper;

using EVOffice_BE.Common;
using EVOffice_BE.Exceptions;
using EVOffice_BE.Helpers;
using EVOffice_BE.Infrastructures.Repositories;
using EVOffice_BE.Infrastructures.Specifications.Impl;
using EVOffice_BE.Modules.TodoList.Models;
using EVOffice_BE.Shared.Claim;

namespace EVOffice_BE.Modules.TodoList.Services.Impl;

public class TodoListService : ITodoListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IClaimService _claimService;

    public TodoListService(IUnitOfWork unitOfWork, IMapper mapper, IClaimService claimService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _claimService = claimService;
    }

    public async Task<IEnumerable<TodoListResponseModel>> GetAllAsync()
    {
        var userId = ParseGuidString.ParseGuid(_claimService.GetUserId());
        var todoListSpec = TodoListSpecification.GetTodoListByUserIdSpec(userId);
        var todoLists = await _unitOfWork.Repository<Entities.Domain.TodoList>().GetAllAsync(todoListSpec);

        return _mapper.Map<IEnumerable<TodoListResponseModel>>(todoLists);
    }

    public async Task<CreateTodoListResponseModel> CreateAsync(CreateTodoListModel createTodoListModel)
    {
        var todoList = _mapper.Map<Entities.Domain.TodoList>(createTodoListModel);

        var addedTodoList = await _unitOfWork.Repository<Entities.Domain.TodoList>().AddAsync(todoList);

        await _unitOfWork.SaveChangesAsync();

        return new CreateTodoListResponseModel
        {
            Id = addedTodoList.Id
        };
    }

    public async Task<UpdateTodoListResponseModel> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel)
    {
        var todoListSpec = TodoListSpecification.GetTodoListByIdSpec(id);
        var todoList = await _unitOfWork.Repository<Entities.Domain.TodoList>().GetFirstAsync(todoListSpec);

        var userId = ParseGuidString.ParseGuid(_claimService.GetUserId());

        if (userId != todoList.CreatedBy)
            throw new BadRequestException("The selected list does not belong to you");

        todoList.Title = updateTodoListModel.Title;
        var updatedTodoList = await _unitOfWork.Repository<Entities.Domain.TodoList>().UpdateAsync(todoList);

        await _unitOfWork.SaveChangesAsync();

        return new UpdateTodoListResponseModel
        {
            Id = updatedTodoList.Id
        };
    }

    public async Task<BaseResponseModel> DeleteAsync(Guid id)
    {
        var todoListSpec = TodoListSpecification.GetTodoListByIdSpec(id);
        var todoList = await _unitOfWork.Repository<Entities.Domain.TodoList>().GetFirstAsync(todoListSpec);

        var deletedTodoList = await _unitOfWork.Repository<Entities.Domain.TodoList>().DeleteAsync(todoList);

        await _unitOfWork.SaveChangesAsync();

        return new BaseResponseModel
        {
            Id = deletedTodoList.Id
        };
    }
}
