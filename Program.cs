using PlataformaCursos.Interfaces;
using PlataformaCursos.Models;
using PlataformaCursos.Session;

namespace PlataformaCursos
{
    public class PlataformaCursos
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            ExibirBanner();

            bool executando = true;

            while (executando)
            {
                ExibirMenuPrincipal();
                string? opcao = Console.ReadLine()?.Trim();

                switch (opcao)
                {
                    case "1":
                        RealizarLogin();
                        break;
                    case "2":
                        ExibirTrilhas();
                        break;
                    case "3":
                        MatricularEmCurso();
                        break;
                    case "4":
                        ExibirMeussCursos();
                        break;
                    case "5":
                        RealizarLogout();
                        break;
                    case "0":
                        executando = false;
                        Console.WriteLine("\nAté logo! 👋\n");
                        break;
                    default:
                        Console.WriteLine("\n  Opção inválida. Tente novamente.");
                        break;
                }

                if (executando && opcao != "0")
                {
                    Console.WriteLine("\nPressione ENTER para continuar...");
                    Console.ReadLine();
                }
            }
        }

        // ─── Menus ────────────────────────────────────────────────────────────────

        static void ExibirBanner()
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════════════╗");
            Console.WriteLine("║         PLATAFORMA DE CURSOS - v1.0             ║");
            Console.WriteLine("╚══════════════════════════════════════════════════╝");
            Console.WriteLine();
        }

        static void ExibirMenuPrincipal()
        {
            var sessao = GerenciadorSessao.GetInstancia();
            Console.WriteLine();
            Console.WriteLine("┌─────────────────────────────────────────────────┐");

            if (sessao.EstaLogado())
                Console.WriteLine($"│  Usuário: {sessao.GetUsuarioAtual()!.GetNome().PadRight(38)}│");
            else
                Console.WriteLine("│  Usuário: [Não logado]                          │");

            Console.WriteLine("├─────────────────────────────────────────────────┤");
            Console.WriteLine("│  [1] Login                                      │");
            Console.WriteLine("│  [2] Ver Trilhas de Cursos                      │");
            Console.WriteLine("│  [3] Matricular-se em um Curso                  │");
            Console.WriteLine("│  [4] Meus Cursos Matriculados                   │");
            Console.WriteLine("│  [5] Logout                                     │");
            Console.WriteLine("│  [0] Sair                                       │");
            Console.WriteLine("└─────────────────────────────────────────────────┘");
            Console.Write("  Escolha uma opção: ");
        }

        // ─── Ações ────────────────────────────────────────────────────────────────

        static void RealizarLogin()
        {
            Console.WriteLine("\n── LOGIN ─────────────────────────────────────────");
            Console.Write("  Nome: ");
            string nome = Console.ReadLine()?.Trim() ?? "Usuário";

            Console.WriteLine("  Nível: [1] Iniciante  [2] Avançado");
            Console.Write("  Escolha: ");
            string? escolha = Console.ReadLine()?.Trim();
            string nivel = escolha == "2" ? "Avançado" : "Iniciante";

            var usuario = new Usuario(nome, nivel);
            GerenciadorSessao.GetInstancia().Login(usuario);
        }

        static void ExibirTrilhas()
        {
            Console.WriteLine("\n── TRILHAS DISPONÍVEIS ───────────────────────────");

            // Trilha Iniciante
            Console.WriteLine("\n  == TRILHA INICIANTE ==");
            ITrilhaFactory trilhaIniciante = new TrilhaIniciante();
            List<ICurso> cursosIniciante = trilhaIniciante.MontarTrilha();
            foreach (var curso in cursosIniciante)
            {
                curso.Exibir();
            }

            // Trilha Avançada
            Console.WriteLine("\n  == TRILHA AVANÇADA ==");
            ITrilhaFactory trilhaAvancada = new TrilhaAvancada();
            List<ICurso> cursosAvancados = trilhaAvancada.MontarTrilha();
            foreach (var curso in cursosAvancados)
            {
                curso.Exibir();
            }
        }

        static void MatricularEmCurso()
        {
            var sessao = GerenciadorSessao.GetInstancia();

            if (!sessao.EstaLogado())
            {
                Console.WriteLine("\n  Você precisa estar logado para se matricular.");
                return;
            }

            Console.WriteLine("\n── MATRÍCULA ─────────────────────────────────────");

            // Monta todas as trilhas para exibir os cursos disponíveis
            var todasAsTrilhas = new List<ITrilhaFactory>
            {
                new TrilhaIniciante(),
                new TrilhaAvancada()
            };

            var todosCursos = new List<ICurso>();
            foreach (var trilha in todasAsTrilhas)
                todosCursos.AddRange(trilha.MontarTrilha());

            Console.WriteLine("\n  Cursos disponíveis:");
            for (int i = 0; i < todosCursos.Count; i++)
            {
                Console.Write($"  [{i + 1}] ");
                todosCursos[i].Exibir();
            }

            Console.Write("\n  Número do curso para matricular (ou 0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= todosCursos.Count)
            {
                var cursoEscolhido = todosCursos[escolha - 1];
                sessao.MatricularCurso(cursoEscolhido.GetId());
            }
            else if (escolha != 0)
            {
                Console.WriteLine("  Opção inválida.");
            }
        }

        static void ExibirMeussCursos()
        {
            var sessao = GerenciadorSessao.GetInstancia();

            if (!sessao.EstaLogado())
            {
                Console.WriteLine("\n  Você precisa estar logado para ver seus cursos.");
                return;
            }

            Console.WriteLine("\n── MEUS CURSOS ───────────────────────────────────");
            var cursos = sessao.GetCursosMatriculados();

            if (cursos.Count == 0)
            {
                Console.WriteLine("  Você ainda não se matriculou em nenhum curso.");
                return;
            }

            Console.WriteLine($"  Usuário: {sessao.GetUsuarioAtual()!.GetNome()}");
            Console.WriteLine($"  Total de cursos: {cursos.Count}\n");
            foreach (var id in cursos)
            {
                Console.WriteLine($"  • Curso ID: {id}");
            }
        }

        static void RealizarLogout()
        {
            var sessao = GerenciadorSessao.GetInstancia();
            if (!sessao.EstaLogado())
            {
                Console.WriteLine("\n  Nenhum usuário está logado no momento.");
                return;
            }
            sessao.Logout();
        }
    }
}
