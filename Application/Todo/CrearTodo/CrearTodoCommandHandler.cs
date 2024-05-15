using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Todos;
using Domain.Todos.Enums;
using Domain.Todos.ObjectValues;
using Domain.Todos.Repository;

namespace Application.Todo.CrearTodo;

internal sealed class CrearTodoCommandHandler : ICommandHandler<CrearTodoCommand, Guid>
{
    private readonly ITodoRepository repository;
    private readonly IUnitOfWork _unitOfWork;
    public CrearTodoCommandHandler(ITodoRepository repository, IUnitOfWork unitOfWork)
    {
        this.repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CrearTodoCommand request, CancellationToken cancellationToken)
    {
        if (!Enum.IsDefined(typeof(TodoPrioridad), request.prioridad)) return Result.Failure<Guid>(TodoErros.ErrorPrioridad);

        var categoria = Categoria.All.FirstOrDefault(x => x.Codigo == request.Categoria);
        if (categoria is null) return Result.Failure<Guid>(TodoErros.ErrorCategoria);

        var todo = Domain.Todos.Todo.CrearTodo(
            request.Titulo,
            request.descripcion,
            request.FechaVencimiento,
            request.prioridad,
            categoria,
            request.UserId
            );

        repository.Add(todo);
        await _unitOfWork.SaveChangesAsync();
        return todo.Id;
    }
}
