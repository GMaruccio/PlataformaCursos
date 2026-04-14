using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Singleton;

/// <summary>
/// Gerencia a sessão do usuário logado na plataforma.
/// Padrão Singleton thread-safe com Lazy initialization.
/// Princípio SRP: responsável somente pela sessão.
/// </summary>
public sealed class GerenciadorSessao
{
    // Lazy<T> garante thread-safety e inicialização sob demanda
    private static readonly Lazy<GerenciadorSessao> _instancia =
        new(() => new GerenciadorSessao());

    private Usuario? _usuarioAtual;
    private readonly List<string> _cursosMatriculados = new();

    // Construtor privado: impede instanciação externa
    private GerenciadorSessao() { }

    public static GerenciadorSessao GetInstancia() => _instancia.Value;

    public void Login(Usuario u)
    {
        _usuarioAtual = u;
        _cursosMatriculados.Clear();
    }

    public void Logout()
    {
        _usuarioAtual = null;
        _cursosMatriculados.Clear();
    }

    public void MatricularCurso(string cursoId)
    {
        if (!_cursosMatriculados.Contains(cursoId))
            _cursosMatriculados.Add(cursoId);
    }

    public void DesmatricularCurso(string cursoId)
        => _cursosMatriculados.Remove(cursoId);

    public bool EstaMatriculado(string cursoId)
        => _cursosMatriculados.Contains(cursoId);

    public Usuario? GetUsuarioAtual() => _usuarioAtual;
    public bool EstaLogado() => _usuarioAtual is not null;
    public List<string> GetCursosMatriculados() => new(_cursosMatriculados);
}
