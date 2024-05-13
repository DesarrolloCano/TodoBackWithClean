using Domain.Todos;
using Domain.Todos.Repository;

namespace Infrastructure.Repositories;

internal sealed class TodoRepository : Repository<Todo>, ITodoRepository
{
    public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
