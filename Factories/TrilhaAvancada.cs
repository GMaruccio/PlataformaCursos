using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Monta a trilha de aprendizagem para usuários avançados.
/// Combina vídeos aprofundados e sessões ao vivo especializadas.
/// </summary>
public class TrilhaAvancada : ITrilhaFactory
{
    private readonly ICursoFactory _videoFactory = new VideoFactory();
    private readonly ICursoFactory _aoVivoFactory = new AoVivoFactory();

    public string GetNomeTrilha() => "Trilha Avançada";
    public string GetDescricaoTrilha() => "Aprofunde seus conhecimentos com arquitetura de software, design patterns e tecnologias de ponta.";
    public string GetNivelAlvo() => "Avançado";

    public List<ICurso> MontarTrilha() => new()
    {
        _videoFactory.CriaCurso("Design Patterns com C#", 40),
        _videoFactory.CriaCurso("Arquitetura de Microsserviços", 35),
        _aoVivoFactory.CriaCurso("Code Review ao Vivo", 6),
        _videoFactory.CriaCurso("DevOps e CI/CD com Docker", 30),
        _videoFactory.CriaCurso("Testes Automatizados (TDD)", 25),
        _aoVivoFactory.CriaCurso("Workshop: System Design", 8),
        _videoFactory.CriaCurso("Cloud com Azure/AWS", 45),
    };
}
