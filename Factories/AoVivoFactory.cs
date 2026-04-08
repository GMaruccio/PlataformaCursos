using PlataformaCursos.Interfaces;
using PlataformaCursos.Models;

namespace PlataformaCursos.Factories
{
    public class AoVivoFactory : ICursoFactory
    {
        public ICurso CriaCurso(string nome, int cargaHoraria)
        {
            Console.WriteLine($"    Criando curso ao vivo: '{nome}' | Carga horária: {cargaHoraria}h");
            return new CursoAoVivo(nome);
        }
    }
}
