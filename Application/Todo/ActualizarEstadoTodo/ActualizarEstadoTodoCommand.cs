using Application.Abstractions.Messaging;

namespace Application.Todo.ActualizarEstadoTodo;

public record ActualizarEstadoTodoCommand(bool Estado,Guid UserId,Guid TodoId) : ICommand<Guid>;

