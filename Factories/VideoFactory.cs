using PlataformaCursos.Interfaces;
using PlataformaCursos.Models;

namespace PlataformaCursos.Factories
{
    public class VideoFactory : ICursoFactory
    {
        public ICurso CriaCurso(string nome, int cargaHoraria)
        {
            Console.WriteLine($"    Criando curso em vídeo: '{nome}' | Carga horária: {cargaHoraria}h");
            return new CursoVideo(nome);
        }
    }
}
