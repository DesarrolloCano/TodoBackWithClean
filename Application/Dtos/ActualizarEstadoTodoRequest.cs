namespace Application.Dtos;

public record ActualizarEstadoTodoRequest(bool Estado, Guid UserId,Guid TodoId);

