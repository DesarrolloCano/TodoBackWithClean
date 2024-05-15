namespace Domain.Todos.ObjectValues;
public record  Categoria
{
    private static readonly Categoria Casa = new("Casa");
    private static readonly Categoria Personal = new("Personal");
    private static readonly Categoria Trabajo = new("Trabajo");
    private static readonly Categoria Ocio = new("Ocio");

    private Categoria(string codigo)=> Codigo = codigo;
    public string Codigo { get; init; }

    public static readonly IReadOnlyCollection<Categoria> All = new[]
    {
        Casa,
        Personal,
        Trabajo,
        Ocio
    };

    public static Categoria FromCodigo(string codigo)
    {
        return All.FirstOrDefault(c => c.Codigo == codigo) ??
            throw new Exception("La categoria no existe");
    }
}

