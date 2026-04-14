using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Monta a trilha de aprendizagem para usuários iniciantes.
/// Usa VideoFactory para criar cursos introdutórios.
/// </summary>
public class TrilhaIniciante : ITrilhaFactory
{
    private readonly ICursoFactory _videoFactory = new VideoFactory();
    private readonly ICursoFactory _aoVivoFactory = new AoVivoFactory();

    public string GetNomeTrilha() => "Trilha Iniciante";
    public string GetDescricaoTrilha() => "Comece do zero e domine os fundamentos da programação com projetos práticos e aulas ao vivo.";
    public string GetNivelAlvo() => "Iniciante";

    public List<ICurso> MontarTrilha() => new()
    {
        _videoFactory.CriaCurso("Lógica de Programação", 12),
        _videoFactory.CriaCurso("HTML e CSS do Zero", 20),
        _videoFactory.CriaCurso("JavaScript Essencial", 30),
        _aoVivoFactory.CriaCurso("Resolução de Exercícios ao Vivo", 4),
        _videoFactory.CriaCurso("Git e GitHub para Iniciantes", 10),
        _aoVivoFactory.CriaCurso("Mentoria: Primeiro Projeto", 2),
    };
}
