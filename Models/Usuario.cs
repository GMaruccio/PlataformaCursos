namespace PlataformaCursos.Models
{
    public class Usuario
    {
        private string _nome;
        private string _nivel;

        public Usuario(string nome, string nivel)
        {
            _nome = nome;
            _nivel = nivel;
        }

        public string GetNome() => _nome;
        public string GetNivel() => _nivel;

        public override string ToString() => $"{_nome} (Nível: {_nivel})";
    }
}
