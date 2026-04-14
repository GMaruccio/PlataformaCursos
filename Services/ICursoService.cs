using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Services;

/// <summary>
/// Contrato de serviço para operações com cursos.
/// Princípio DIP: controllers dependem desta abstração, não de implementações.
/// </summary>
public interface ICursoService
{
    IEnumerable<ICurso> ListarTodos();
    ICurso? BuscarPorId(string id);
    ICurso CriarCursoVideo(string nome, int cargaHoraria);
    ICurso CriarCursoAoVivo(string nome, int cargaHoraria);
    void Matricular(string cursoId);
    void Desmatricular(string cursoId);
    bool EstaMatriculado(string cursoId);
}
