namespace Application.Dtos;


public sealed class ObtenerTodosResponse
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public bool Completada { get; set; }
    public int Prioridad { get; set; }
    public string? Categoria { get; set; }
    public DateTime FechaCreacion { get; set; }
    public DateTime FechaActualizacion { get; set; }
    public Guid IdUsuario { get; set; }


}
