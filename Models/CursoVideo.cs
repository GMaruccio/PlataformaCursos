namespace PlataformaCursosOnline.Models;

/// <summary>
/// Representa um curso no formato de vídeo gravado.
/// Implementa ICurso seguindo o princípio OCP (Open/Closed).
/// </summary>
public class CursoVideo : ICurso
{
    private readonly string _id;
    private readonly string _nome;
    private readonly int _cargaHoraria;

    public CursoVideo(string nome, int cargaHoraria)
    {
        _id = Guid.NewGuid().ToString();
        _nome = nome;
        _cargaHoraria = cargaHoraria;
    }

    public string GetId() => _id;
    public string GetNome() => _nome;
    public int GetCargaHoraria() => _cargaHoraria;
    public string GetTipo() => "Vídeo";

    public void Exibir()
    {
        Console.WriteLine($"[Curso em Vídeo] {_nome} | {_cargaHoraria}h | ID: {_id}");
    }
}
