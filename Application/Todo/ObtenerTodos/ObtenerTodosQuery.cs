

using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Todo.ObtenerTodos;

public sealed record ObtenerTodosQuery(Guid UsuarioId):IQuery<IReadOnlyList<ObtenerTodosResponse>>
{
}
