using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Todos.Repository;

namespace Application.Todo.DeleteTodo;

public sealed class DeleteTodoCommandHandler : ICommandHandler<DeleteTodoCommand, bool>
{
    private readonly ITodoRepository _todoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork)
    {
        _todoRepository = todoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<bool>> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {

        var resp = await _todoRepository.EliminarTodo(request.id, request.userId, cancellationToken);
        if (!resp) return Result.Success<bool>(false);
        await _unitOfWork.SaveChangesAsync();
        return Result.Success<bool>(true);
    }
}
