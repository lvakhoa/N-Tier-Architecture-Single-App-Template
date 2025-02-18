using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using NTierArchitecture.Common;
using NTierArchitecture.Modules.TodoItem.Models;
using NTierArchitecture.Modules.TodoItem.Services;

namespace NTierArchitecture.Modules.TodoItem;

[Authorize]
public class TodoItemsController : ApiController
{
    private readonly ITodoItemService _todoItemService;

    public TodoItemsController(ITodoItemService todoItemService)
    {
        _todoItemService = todoItemService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateTodoItemModel createTodoItemModel)
    {
        return Ok(ApiResult<CreateTodoItemResponseModel>.Success(StatusCodes.Status201Created,
            await _todoItemService.CreateAsync(createTodoItemModel)));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateAsync(Guid id, UpdateTodoItemModel updateTodoItemModel)
    {
        return Ok(ApiResult<UpdateTodoItemResponseModel>.Success(StatusCodes.Status200OK,
            await _todoItemService.UpdateAsync(id, updateTodoItemModel)));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return Ok(ApiResult<BaseResponseModel>.Success(StatusCodes.Status200OK, await _todoItemService.DeleteAsync(id)));
    }
}
