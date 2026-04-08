using PlataformaCursos.Interfaces;

namespace PlataformaCursos.Models
{
    public class CursoVideo : ICurso
    {
        private string _id;
        private string _nome;

        public CursoVideo(string nome)
        {
            _id = Guid.NewGuid().ToString("N")[..8].ToUpper();
            _nome = nome;
        }

        public string GetId() => _id;

        public void Exibir()
        {
            Console.WriteLine($"  [VIDEO] ID: {_id} | Curso: {_nome}");
        }

        public override string ToString() => $"[VIDEO] {_nome} (ID: {_id})";
    }
}
