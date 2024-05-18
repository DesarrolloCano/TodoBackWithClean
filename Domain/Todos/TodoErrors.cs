using Domain.Abstractions;

namespace Domain.Todos;

public static class TodoErros
{
    public static Error ErrorCategoria = new("Todo.Categoria", "La categoria ingresada no existe");
    public static Error ErrorPrioridad = new("Todo.Prioridad", "La prioridad ingresada no existe");
    public static Error ErrorNotFound = new("Todo.NotFound", "EL todo no se encuentra en la base de datos");

}