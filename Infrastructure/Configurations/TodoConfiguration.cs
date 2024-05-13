using Domain.Todos;
using Domain.Todos.ObjectValues;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

internal sealed class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
        builder.ToTable("todos");
        builder.HasKey(t => t.Id);

        builder.Property(user => user.Titulo)
         .HasMaxLength(200)
         .HasConversion(nombre => nombre!.Value, value => new Titulo(value));

        builder.Property(user => user.Descripcion)
         .HasMaxLength(400)
         .HasConversion(nombre => nombre!.Value, value => new Descripcion(value));

        builder.Property(user => user.Categoria)
        .HasMaxLength(400)
        .HasConversion(nombre => nombre!.Codigo, value => Categoria.FromCodigo(value!));
    }
}
