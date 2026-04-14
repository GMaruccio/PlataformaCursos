using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Factory responsável por criar cursos em formato de vídeo.
/// Segue o princípio SRP (Single Responsibility).
/// </summary>
public class VideoFactory : ICursoFactory
{
    public ICurso CriaCurso(string nome, int cargaHoraria)
        => new CursoVideo(nome, cargaHoraria);
}
