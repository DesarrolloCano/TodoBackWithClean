using Application.Todo;
using Application.Todo.CrearTodo;
using Application.Todo.ObtenerTodos;
using Domain.Abstractions;
using Domain.Todos;
using Domain.Todos.Enums;
using Domain.Todos.ObjectValues;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ISender _sender;

        public TodoController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> CrearTodo(CrearTodoRequest crearTodoRequest, CancellationToken cancellationToken)
        {
            

            var titulo = new Titulo(crearTodoRequest.Titulo);
            var descripcion = new Descripcion(crearTodoRequest.Descripcion);
            var prioridad = (TodoPrioridad)crearTodoRequest.prioridad;
            var categoria = crearTodoRequest.Categoria;
            var todoCommand = new CrearTodoCommand(titulo, descripcion, crearTodoRequest.FechaVencimiento, prioridad, categoria, crearTodoRequest.UserId);

            var resultado = await _sender.Send(todoCommand, cancellationToken);

            if (resultado.IsFailure)
            {
                return BadRequest(resultado.Error);
            }

            return Ok(resultado);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerTodosByIdUser(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new ObtenerTodosQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado.Value) : NotFound();
        }
    }
}
