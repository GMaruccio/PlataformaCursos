using Microsoft.AspNetCore.Mvc;
using PlataformaCursosOnline.Services;
using PlataformaCursosOnline.Singleton;

namespace PlataformaCursosOnline.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioService _usuarioService;
    private readonly ICursoService _cursoService;
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.GetInstancia();

    public UsuarioController(IUsuarioService usuarioService, ICursoService cursoService)
    {
        _usuarioService = usuarioService;
        _cursoService = cursoService;
    }

    // GET /Usuario/Login
    public IActionResult Login(string? returnUrl)
    {
        if (_sessao.EstaLogado()) return RedirectToAction("Index", "Home");
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }

    // POST /Usuario/Login
    [HttpPost]
    public IActionResult Login(string nome, string nivel, string? returnUrl)
    {
        if (_usuarioService.Login(nome, nivel))
        {
            TempData["Mensagem"] = $"Bem-vindo(a), {nome}!";
            TempData["Tipo"] = "sucesso";
            return Redirect(returnUrl ?? "/");
        }
        ViewBag.Erro = "Não foi possível realizar o login.";
        return View();
    }

    // POST /Usuario/Logout
    [HttpPost]
    public IActionResult Logout()
    {
        _usuarioService.Logout();
        return RedirectToAction("Index", "Home");
    }

    // GET /Usuario/Perfil
    public IActionResult Perfil()
    {
        if (!_sessao.EstaLogado())
            return RedirectToAction(nameof(Login));

        var ids = _sessao.GetCursosMatriculados();
        var meusCursos = _cursoService.ListarTodos()
            .Where(c => ids.Contains(c.GetId()))
            .ToList();

        ViewBag.Usuario = _sessao.GetUsuarioAtual();
        ViewBag.MeusCursos = meusCursos;
        ViewBag.TotalHoras = meusCursos.Sum(c => c.GetCargaHoraria());
        return View();
    }
}
