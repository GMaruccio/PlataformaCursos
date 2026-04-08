using PlataformaCursos.Factories;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Models
{
    public class TrilhaIniciante : ITrilhaFactory
    {
        private readonly VideoFactory _videoFactory = new VideoFactory();

        public List<ICurso> MontarTrilha()
        {
            Console.WriteLine("  Montando Trilha Iniciante...");
            var cursos = new List<ICurso>
            {
                _videoFactory.CriaCurso("Introdução à Programação", 10),
                _videoFactory.CriaCurso("Lógica de Programação", 15),
                _videoFactory.CriaCurso("Git e GitHub para Iniciantes", 8)
            };
            return cursos;
        }
    }
}
