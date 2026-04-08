using PlataformaCursos.Models;

namespace PlataformaCursos.Session
{
    public class GerenciadorSessao
    {
        // Singleton
        private static GerenciadorSessao? _instancia;

        private Usuario? _usuarioAtual;
        private List<string> _cursosMatriculados = new List<string>();

        // Construtor privado para garantir o Singleton
        private GerenciadorSessao() { }

        public static GerenciadorSessao GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new GerenciadorSessao();
            }
            return _instancia;
        }

        public void Login(Usuario usuario)
        {
            _usuarioAtual = usuario;
            _cursosMatriculados.Clear();
            Console.WriteLine($"\n  Login realizado com sucesso! Bem-vindo(a), {usuario.GetNome()}.");
        }

        public Usuario? GetUsuarioAtual() => _usuarioAtual;

        public List<string> GetCursosMatriculados() => _cursosMatriculados;

        public void MatricularCurso(string cursoId)
        {
            if (_usuarioAtual == null)
            {
                Console.WriteLine("  Erro: Nenhum usuário logado.");
                return;
            }

            if (_cursosMatriculados.Contains(cursoId))
            {
                Console.WriteLine($"  Você já está matriculado no curso ID: {cursoId}.");
                return;
            }

            _cursosMatriculados.Add(cursoId);
            Console.WriteLine($"  Matrícula no curso ID: {cursoId} realizada com sucesso!");
        }

        public bool EstaLogado() => _usuarioAtual != null;

        public void Logout()
        {
            Console.WriteLine($"\n  Logout de {_usuarioAtual?.GetNome()} realizado.");
            _usuarioAtual = null;
            _cursosMatriculados.Clear();
        }
    }
}
