using Domain.Abstractions;
using Domain.Todos.Enums;
using Domain.Todos.ObjectValues;

namespace Domain.Todos;

public sealed class Todo : Entity
{
    private Todo()
    {
        Titulo = new Titulo(string.Empty);
        Descripcion = new Descripcion(string.Empty);
        FechaVencimiento = DateTime.MinValue;
        Categoria = Categoria.FromCodigo("Casa"); // O cualquier valor por defecto que tenga sentido
        Prioridad = TodoPrioridad.Baja; // Asignar un valor por defecto
    }

    private Todo(
        Guid id,
        Titulo titulo,
        Descripcion descripcion,
        DateTime fechaVencimiento,
        bool completada,
        TodoPrioridad prioridad,
        Categoria categoria,
        DateTime fechaCreacion,
        DateTime fechaActualizacion,
        Guid idUsuario
    ) : base(id)
    {
        Titulo = titulo;
        Descripcion = descripcion;
        FechaVencimiento = fechaVencimiento;
        Completada = completada;
        Prioridad = prioridad;
        Categoria = categoria;
        FechaCreacion = fechaCreacion;
        FechaActualizacion = fechaActualizacion;
        IdUsuario = idUsuario;
    }

    public Titulo Titulo { get; set; }
    public Descripcion Descripcion { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public bool Completada { get; set; }
    public TodoPrioridad Prioridad { get; set; }
    public Categoria Categoria { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public Guid IdUsuario { get; set; }

    public static Todo CrearTodo(Titulo titulo, Descripcion descripcion, DateTime fechaVencimiento, TodoPrioridad prioridad, Categoria categoria, Guid idUsuario)
    {
        var todo = new Todo(Guid.NewGuid(), titulo, descripcion, fechaVencimiento, false, prioridad, categoria, DateTime.UtcNow, DateTime.UtcNow, idUsuario);
        return todo;
    }

    public void ActualizarEstadoTodo(bool status, Guid userId)
    {
        if (IdUsuario == userId) Completada = status;
    }
}
