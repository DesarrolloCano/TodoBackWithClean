﻿namespace Application.Dtos;

public sealed record CrearTodoRequest(string Titulo, string Descripcion, DateTime FechaVencimiento, int prioridad, string Categoria, Guid UserId);


