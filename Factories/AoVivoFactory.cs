using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Factory responsável por criar cursos no formato ao vivo.
/// Segue o princípio SRP (Single Responsibility).
/// </summary>
public class AoVivoFactory : ICursoFactory
{
    public ICurso CriaCurso(string nome, int cargaHoraria)
        => new CursoAoVivo(nome, cargaHoraria);
}
