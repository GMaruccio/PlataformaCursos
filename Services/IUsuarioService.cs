using PlataformaCursosOnline.Models;

namespace PlataformaCursosOnline.Services;

public interface IUsuarioService
{
    bool Login(string nome, string nivel);
    void Logout();
    bool EstaLogado();
    Usuario? GetUsuarioAtual();
}
