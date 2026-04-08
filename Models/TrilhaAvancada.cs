using PlataformaCursos.Factories;
using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Models
{
    public class TrilhaAvancada : ITrilhaFactory
    {
        private readonly AoVivoFactory _aoVivoFactory = new AoVivoFactory();

        public List<ICurso> MontarTrilha()
        {
            Console.WriteLine("  Montando Trilha Avançada...");
            var cursos = new List<ICurso>
            {
                _aoVivoFactory.CriaCurso("Design Patterns com C#", 20),
                _aoVivoFactory.CriaCurso("Arquitetura de Microsserviços", 30),
                _aoVivoFactory.CriaCurso("Machine Learning Aplicado", 40)
            };
            return cursos;
        }
    }
}
