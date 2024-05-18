using Application.Abstractions.Messaging;

namespace Application.Todo.DeleteTodo;

public record DeleteTodoCommand(Guid id, Guid userId) : ICommand<bool>;

