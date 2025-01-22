using EVOffice_BE.Entities.Domain;

namespace EVOffice_BE.Infrastructures.Specifications.Impl;

public class TodoListSpecification
{
    public static BaseSpecification<TodoList> GetTodoListByIdSpec(Guid id)
    {
        return new BaseSpecification<TodoList>(x => x.Id == id);
    }

    public static BaseSpecification<TodoList> GetTodoListByUserIdSpec(Guid userId)
    {
        return new BaseSpecification<TodoList>(x => x.CreatedBy == userId);
    }
}
