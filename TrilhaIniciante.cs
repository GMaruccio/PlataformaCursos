using Microsoft.AspNetCore.Mvc;
using PlataformaCursosOnline.Services;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Controllers;

public class TrilhaController : Controller
{
    private readonly ITrilhaService _trilhaService;
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.GetInstancia();

    public TrilhaController(ITrilhaService trilhaService)
    {
        _trilhaService = trilhaService;
    }

    // GET /Trilha
    public IActionResult Index()
    {
        var trilhas = _trilhaService.ListarTrilhas().ToList();
        ViewBag.Usuario = _sessao.GetUsuarioAtual();
        return View(trilhas);
    }

    // GET /Trilha/Detalhes/{nivel}
    public IActionResult Detalhes(string nivel)
    {
        var trilha = _trilhaService.ObterTrilhaPorNivel(nivel);
        if (trilha is null) return NotFound();

        ViewBag.Logado = _sessao.EstaLogado();
        return View(trilha);
    }
}
