using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Factories;

/// <summary>
/// Interface para factories de trilhas de aprendizagem.
/// Padrão Abstract Factory + princípio ISP do SOLID.
/// </summary>
public interface ITrilhaFactory
{
    List<ICurso> MontarTrilha();
    string GetNomeTrilha();
    string GetDescricaoTrilha();
    string GetNivelAlvo();
}
