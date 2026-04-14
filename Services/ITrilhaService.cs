using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Services;

public interface ITrilhaService
{
    IEnumerable<Trilha> ListarTrilhas();
    Trilha? ObterTrilhaPorNivel(string nivel);
}
