namespace PlataformaCursosOnline.Models;

/// <summary>
/// Representa um usuário da plataforma de cursos.
/// </summary>
public class Usuario
{
    private readonly string _nome;
    private readonly string _nivel;

    public Usuario(string nome, string nivel)
    {
        _nome = nome;
        _nivel = nivel;
    }

    public string GetNome() => _nome;
    public string GetNivel() => _nivel;
}
