using FluentValidation;

namespace Application.Todo.CrearTodo;

public class CrearTodoCommandValidator: AbstractValidator<CrearTodoCommand>
{
    public CrearTodoCommandValidator()
    {
        RuleFor(c => c.Titulo.Value).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}
