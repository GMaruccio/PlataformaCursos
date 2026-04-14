using PlataformaCursosOnline.Factories;
using PlataformaCursosOnline.Models;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Services;

/// <summary>
/// Implementação do serviço de cursos.
/// Usa factories para criação e GerenciadorSessao para matrículas.
/// Princípios SRP e OCP do SOLID.
/// </summary>
public class CursoService : ICursoService
{
    private readonly ICursoFactory _videoFactory;
    private readonly ICursoFactory _aoVivoFactory;
    private readonly GerenciadorSessao _sessao;

    // Catálogo em memória (substituível por repositório com DB)
    private static readonly List<ICurso> _catalogo = new();

    public CursoService(ICursoFactory videoFactory, ICursoFactory aoVivoFactory)
    {
        _videoFactory = videoFactory;
        _aoVivoFactory = aoVivoFactory;
        _sessao = GerenciadorSessao.GetInstancia();
        SeedCatalogo();
    }

    private static bool _seeded = false;
    private void SeedCatalogo()
    {
        if (_seeded) return;
        _seeded = true;

        // Seed com dados de exemplo usando as factories
        var cursos = new List<(string nome, int ch, bool aoVivo)>
        {
            ("C# do Zero ao Avançado", 60, false),
            ("ASP.NET Core MVC", 40, false),
            ("Entity Framework Core", 30, false),
            ("React com TypeScript", 45, false),
            ("Docker e Kubernetes", 35, false),
            ("Python para Data Science", 50, false),
            ("SQL Server e T-SQL", 25, false),
            ("Arquitetura de Software SOLID", 20, false),
            ("Live Coding: API REST", 4, true),
            ("Workshop: Clean Code na Prática", 6, true),
            ("Mentoria: Code Review ao Vivo", 3, true),
            ("Live: Preparação para Entrevistas", 5, true),
        };

        foreach (var (nome, ch, aoVivo) in cursos)
        {
            var curso = aoVivo
                ? _aoVivoFactory.CriaCurso(nome, ch)
                : _videoFactory.CriaCurso(nome, ch);
            _catalogo.Add(curso);
        }
    }

    public IEnumerable<ICurso> ListarTodos() => _catalogo.AsReadOnly();

    public ICurso? BuscarPorId(string id)
        => _catalogo.FirstOrDefault(c => c.GetId() == id);

    public ICurso CriarCursoVideo(string nome, int cargaHoraria)
    {
        var curso = _videoFactory.CriaCurso(nome, cargaHoraria);
        _catalogo.Add(curso);
        return curso;
    }

    public ICurso CriarCursoAoVivo(string nome, int cargaHoraria)
    {
        var curso = _aoVivoFactory.CriaCurso(nome, cargaHoraria);
        _catalogo.Add(curso);
        return curso;
    }

    public void Matricular(string cursoId) => _sessao.MatricularCurso(cursoId);
    public void Desmatricular(string cursoId) => _sessao.DesmatricularCurso(cursoId);
    public bool EstaMatriculado(string cursoId) => _sessao.EstaMatriculado(cursoId);
}
