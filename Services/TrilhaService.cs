using PlataformaCursosOnline.Factories;
using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Services;

/// <summary>
/// Serviço que monta e gerencia trilhas de aprendizagem.
/// Princípio OCP: novas trilhas podem ser adicionadas sem alterar este serviço.
/// </summary>
public class TrilhaService : ITrilhaService
{
    // Registro de factories de trilha - aberto para extensão (OCP)
    private readonly IEnumerable<ITrilhaFactory> _trilhaFactories;

    public TrilhaService(IEnumerable<ITrilhaFactory> trilhaFactories)
    {
        _trilhaFactories = trilhaFactories;
    }

    public IEnumerable<Trilha> ListarTrilhas()
        => _trilhaFactories.Select(f => new Trilha
        {
            Nome = f.GetNomeTrilha(),
            Descricao = f.GetDescricaoTrilha(),
            NivelAlvo = f.GetNivelAlvo(),
            Cursos = f.MontarTrilha()
        });

    public Trilha? ObterTrilhaPorNivel(string nivel)
    {
        var factory = _trilhaFactories
            .FirstOrDefault(f => f.GetNivelAlvo().Equals(nivel, StringComparison.OrdinalIgnoreCase));

        return factory is null ? null : new Trilha
        {
            Nome = factory.GetNomeTrilha(),
            Descricao = factory.GetDescricaoTrilha(),
            NivelAlvo = factory.GetNivelAlvo(),
            Cursos = factory.MontarTrilha()
        };
    }
}
