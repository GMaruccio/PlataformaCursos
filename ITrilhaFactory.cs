using Microsoft.AspNetCore.Mvc;
using PlataformaCursosOnline.Services;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Controllers;

public class CursoController : Controller
{
    private readonly ICursoService _cursoService;
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.GetInstancia();

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    // GET /Curso
    public IActionResult Index(string? tipo, string? busca)
    {
        var cursos = _cursoService.ListarTodos();

        if (!string.IsNullOrWhiteSpace(tipo))
            cursos = cursos.Where(c => c.GetTipo().Equals(tipo, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrWhiteSpace(busca))
            cursos = cursos.Where(c => c.GetNome().Contains(busca, StringComparison.OrdinalIgnoreCase));

        ViewBag.Tipo = tipo;
        ViewBag.Busca = busca;
        ViewBag.Sessao = _sessao;
        return View(cursos.ToList());
    }

    // GET /Curso/Detalhes/{id}
    public IActionResult Detalhes(string id)
    {
        var curso = _cursoService.BuscarPorId(id);
        if (curso is null) return NotFound();

        ViewBag.Matriculado = _cursoService.EstaMatriculado(id);
        ViewBag.Logado = _sessao.EstaLogado();
        return View(curso);
    }

    // POST /Curso/Matricular
    [HttpPost]
    public IActionResult Matricular(string id)
    {
        if (!_sessao.EstaLogado())
            return RedirectToAction("Login", "Usuario", new { returnUrl = $"/Curso/Detalhes/{id}" });

        _cursoService.Matricular(id);
        TempData["Mensagem"] = "Matrícula realizada com sucesso!";
        TempData["Tipo"] = "sucesso";
        return RedirectToAction(nameof(Detalhes), new { id });
    }

    // POST /Curso/Desmatricular
    [HttpPost]
    public IActionResult Desmatricular(string id)
    {
        _cursoService.Desmatricular(id);
        TempData["Mensagem"] = "Desmatrícula realizada.";
        TempData["Tipo"] = "info";
        return RedirectToAction(nameof(Detalhes), new { id });
    }

    // GET /Curso/MeusCursos
    public IActionResult MeusCursos()
    {
        if (!_sessao.EstaLogado())
            return RedirectToAction("Login", "Usuario");

        var ids = _sessao.GetCursosMatriculados();
        var meusCursos = _cursoService.ListarTodos()
            .Where(c => ids.Contains(c.GetId()))
            .ToList();

        return View(meusCursos);
    }
}
