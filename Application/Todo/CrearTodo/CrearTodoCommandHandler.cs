using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Todos;
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
        try
        {
            var todo = Domain.Todos.Todo.CrearTodo(request.Titulo, request.descripcion, request.FechaVencimiento, request.prioridad, request.Categoria, request.UserId);
            repository.Add(todo);
            await _unitOfWork.SaveChangesAsync();
            return todo.Id;
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
