using Application.Abstractions.Messaging;
using Application.Data;
using Application.Dtos;
using Dapper;
using Domain.Abstractions;

namespace Application.Todo.ObtenerTodos;

internal sealed class ObtenerTodosQueryHandler : IQueryHandler<ObtenerTodosQuery, IReadOnlyList<ObtenerTodosResponse>>
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ObtenerTodosQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<Result<IReadOnlyList<ObtenerTodosResponse>>> Handle(ObtenerTodosQuery request, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();

        const string sql = """
               SELECT
                a.id as Id,
                a.titulo as Titulo,
                a.descripcion as Descripcion,
                a.fecha_vencimiento as FechaVencimiento,
                a.completada as Completada,
                a.prioridad as Prioridad,
                a.categoria as Categoria,
                a.fecha_creacion as FechaCreacion,
                a.fecha_actualizacion as FechaActualizacion,
                a.id_usuario as IdUsuario
             FROM todos AS a
             WHERE a.id_usuario = @UsuarioId      
        """;

        var todosList = await connection.QueryAsync<ObtenerTodosResponse>
          (
              sql,
              new
              {
                  UsuarioId = request.UsuarioId
              }
          );

        return todosList.ToList();
    }
}
