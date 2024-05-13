

using Application.Abstractions.Messaging;

namespace Application.Todo.ObtenerTodos;

public sealed record ObtenerTodosQuery(Guid UsuarioId):IQuery<IReadOnlyList<ObtenerTodosResponse>>
{
}
