using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NTierArchitecture.Common;
using NTierArchitecture.Modules.TodoItem.Models;
using NTierArchitecture.Modules.TodoItem.Services;
using NTierArchitecture.Modules.TodoList.Models;
using NTierArchitecture.Modules.TodoList.Services;

namespace NTierArchitecture.Modules.TodoList;

[Authorize]
public class TodoListsController : ApiController
{
    private readonly ITodoItemService _todoItemService;
    private readonly ITodoListService _todoListService;

    public TodoListsController(ITodoListService todoListService, ITodoItemService todoItemService)
    {
        _todoListService = todoListService;
        _todoItemService = todoItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(ApiResult<IEnumerable<TodoListResponseModel>>.Success(StatusCodes.Status200OK,
            await _todoListService.GetAllAsync()));
    }

    [HttpGet("{id:guid}/todoItems")]
    public async Task<IActionResult> GetAllTodoItemsAsync(Guid id)
    {
        return Ok(ApiResult<IEnumerable<TodoItemResponseModel>>.Success(StatusCodes.Status200OK,
            await _todoItemService.GetAllByListIdAsync(id)));
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTodoListModel createTodoListModel)
    {
        return Ok(ApiResult<CreateTodoListResponseModel>.Success(StatusCodes.Status201Created,
            await _todoListService.CreateAsync(createTodoListModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTodoListModel updateTodoListModel)
    {
        return Ok(ApiResult<UpdateTodoListResponseModel>.Success(StatusCodes.Status200OK,
            await _todoListService.UpdateAsync(id, updateTodoListModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(StatusCodes.Status200OK,
            await _todoListService.DeleteAsync(id)));
    }
}
