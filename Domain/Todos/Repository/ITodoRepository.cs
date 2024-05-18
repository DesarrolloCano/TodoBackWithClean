namespace Domain.Todos.Repository;

public interface ITodoRepository
{
    void Add(Todo todo);
    void Update(Todo todo);
    void Delete(Todo todo);
    Task<Todo?> GetById(Guid id, Guid userId, CancellationToken cancellationToken);
    Task<bool> EliminarTodo(Guid id, Guid userId, CancellationToken cancellationToken);
}
