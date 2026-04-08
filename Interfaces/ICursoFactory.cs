namespace PlataformaCursos.Interfaces
{
    public interface ICursoFactory
    {
        ICurso CriaCurso(string nome, int cargaHoraria);
    }
}
