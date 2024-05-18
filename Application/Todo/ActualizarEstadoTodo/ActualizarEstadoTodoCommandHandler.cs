using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Todos;
using Domain.Todos.Repository;

namespace Application.Todo.ActualizarEstadoTodo;

public sealed class ActualizarEstadoTodoCommandHandler : ICommandHandler<ActualizarEstadoTodoCommand, Guid>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarEstadoTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
    {
        _todoRepository = todoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(ActualizarEstadoTodoCommand request, CancellationToken cancellationToken)
    {
        var todoById = await _todoRepository.GetById(request.TodoId, request.UserId, cancellationToken);
        if (todoById == null) return Result.Failure<Guid>(TodoErros.ErrorNotFound);

        todoById.ActualizarEstadoTodo(request.Estado, request.UserId);

        _todoRepository.Update(todoById);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success<Guid>(todoById.Id);
    }
}
