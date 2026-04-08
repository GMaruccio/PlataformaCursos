using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Models
{
    public class CursoAoVivo : ICurso
    {
        private string _id;
        private string _nome;

        public CursoAoVivo(string nome)
        {
            _id = Guid.NewGuid().ToString("N")[..8].ToUpper();
            _nome = nome;
        }

        public string GetId() => _id;

        public void Exibir()
        {
            Console.WriteLine($"  [AO VIVO] ID: {_id} | Curso: {_nome}");
        }

        public override string ToString() => $"[AO VIVO] {_nome} (ID: {_id})";
    }
}
