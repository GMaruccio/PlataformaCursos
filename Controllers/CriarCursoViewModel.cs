namespace PlataformaCursosOnline.Models;

/// <summary>
/// ViewModel para o formulário de criação de curso.
/// Separa os dados da view do modelo de domínio (princípio SRP).
/// </summary>
public class CriarCursoViewModel
{
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }

    /// <summary>
    /// Tipo do curso: "Video" ou "AoVivo".
    /// Determina qual Factory será usada (Factory Method).
    /// </summary>
    public string Tipo { get; set; } = "Video";
}
