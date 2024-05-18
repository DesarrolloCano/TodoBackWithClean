using Domain.Todos;
using Domain.Todos.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal sealed class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Todo?> GetById(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var todo = await DbContext.Set<Todo>().FirstOrDefaultAsync(x => x.Id == id && x.IdUsuario == userId, cancellationToken);
        return todo;
    }

    public async Task<bool> EliminarTodo(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var todo = await DbContext.Set<Todo>().FirstOrDefaultAsync(x => x.Id == id && x.IdUsuario == userId, cancellationToken);
        if (todo == null) return false;
        DbContext.Set<Todo>().Remove(todo);
        return true;
    }
}
