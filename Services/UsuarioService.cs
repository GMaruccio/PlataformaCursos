using PlataformaCursosOnline.Models;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Services;

/// <summary>
/// Serviço de autenticação e gerenciamento de usuário.
/// Delega sessão ao Singleton GerenciadorSessao.
/// </summary>
public class UsuarioService : IUsuarioService
{
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.GetInstancia();

    private static readonly Dictionary<string, string> _usuariosCadastrados = new(StringComparer.OrdinalIgnoreCase)
    {
        { "ana",    "Iniciante"  },
        { "carlos", "Avançado"   },
        { "julia",  "Iniciante"  },
        { "marcos", "Avançado"   },
        { "admin",  "Avançado"   },
    };

    public bool Login(string nome, string nivel)
    {
        if (string.IsNullOrWhiteSpace(nome)) return false;

        // Simulação de autenticação (sem banco de dados)
        var nivelFinal = _usuariosCadastrados.TryGetValue(nome, out var nivelSalvo)
            ? nivelSalvo
            : nivel;

        var usuario = new Usuario(nome, nivelFinal);
        _sessao.Login(usuario);
        return true;
    }

    public void Logout() => _sessao.Logout();
    public bool EstaLogado() => _sessao.EstaLogado();
    public Usuario? GetUsuarioAtual() => _sessao.GetUsuarioAtual();
}
