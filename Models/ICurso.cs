namespace PlataformaCursosOnline.Models;

/// <summary>
/// Interface que define o contrato para todos os tipos de curso.
/// Princípio ISP (Interface Segregation) do SOLID.
/// </summary>
public interface ICurso
{
    string GetId();
    string GetNome();
    int GetCargaHoraria();
    string GetTipo();
    void Exibir();
}
