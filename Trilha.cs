using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Interface Factory para criação de cursos.
/// Padrão Factory Method + princípio DIP (Dependency Inversion) do SOLID.
/// </summary>
public interface ICursoFactory
{
    ICurso CriaCurso(string nome, int cargaHoraria);
}
