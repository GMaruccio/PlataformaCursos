using Microsoft.AspNetCore.Mvc;
using PlataformaCursosOnline.Services;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Controllers;

public class HomeController : Controller
{
    private readonly ICursoService _cursoService;
    private readonly ITrilhaService _trilhaService;
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.GetInstancia();

    public HomeController(ICursoService cursoService, ITrilhaService trilhaService)
    {
        _cursoService = cursoService;
        _trilhaService = trilhaService;
    }

    public IActionResult Index()
    {
        var cursos = _cursoService.ListarTodos().Take(6).ToList();
        var trilhas = _trilhaService.ListarTrilhas().ToList();

        ViewBag.Cursos = cursos;
        ViewBag.Trilhas = trilhas;
        ViewBag.Usuario = _sessao.GetUsuarioAtual();
        ViewBag.TotalCursos = _cursoService.ListarTodos().Count();
        ViewBag.TotalHoras = _cursoService.ListarTodos().Sum(c => c.GetCargaHoraria());

        return View();
    }
}
