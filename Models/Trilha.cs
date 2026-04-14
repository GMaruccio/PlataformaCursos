namespace PlataformaCursosOnline.Models;

/// <summary>
/// Representa uma trilha de aprendizagem com seus cursos.
/// </summary>
public class Trilha
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string NivelAlvo { get; set; } = string.Empty;
    public List<ICurso> Cursos { get; set; } = new();
    public int TotalHoras => Cursos.Sum(c => c.GetCargaHoraria());
}
