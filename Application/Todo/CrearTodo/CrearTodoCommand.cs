using Application.Abstractions.Messaging;
using Domain.Todos.Enums;
using Domain.Todos.ObjectValues;

namespace Application.Todo.CrearTodo;

public record CrearTodoCommand(Titulo Titulo, Descripcion descripcion, DateTime FechaVencimiento, TodoPrioridad prioridad, Categoria Categoria, Guid UserId) : ICommand<Guid>;

