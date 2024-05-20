using Application.Dtos;
using Application.Todo.ActualizarEstadoTodo;
using Application.Todo.CrearTodo;
using Application.Todo.DeleteTodo;
using Application.Todo.ObtenerTodos;
using Domain.Todos.Enums;
using Domain.Todos.ObjectValues;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
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
                return BadRequest(resultado);
            }

            return Ok(resultado);
        }

        [HttpGet("TodoByIdUser{id}")]
        public async Task<IActionResult> ObtenerTodosByIdUser(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new ObtenerTodosQuery(id);
            var resultado = await _sender.Send(query, cancellationToken);
            return resultado.IsSuccess ? Ok(resultado) : NotFound(resultado);
        }

        [HttpPost("ActualizarEstadoTodo")]
        public async Task<IActionResult> ActualizarEstadoTodo(ActualizarEstadoTodoRequest request, CancellationToken cancellationToken = default)
        {
            var command = new ActualizarEstadoTodoCommand(request.Estado, request.UserId, request.TodoId);
            var resultado = await _sender.Send(command, cancellationToken);
            return !resultado.IsFailure ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpDelete("DeleteTodo{id}/{idUser}")]
        public async Task<IActionResult> EliminarTodo(Guid id, Guid idUser, CancellationToken cancellationToken = default)
        {
            var command = new DeleteTodoCommand(id, idUser);
            var resultado = await _sender.Send(command, cancellationToken);
            return Ok(resultado);
        }

    }
}
