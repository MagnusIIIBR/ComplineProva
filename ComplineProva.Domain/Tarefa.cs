using System;

namespace ComplineProva.Domain
{
    public class Tarefa
    {
        protected Tarefa() { }

        public Tarefa(int id = 0, string titulo = "", Int16 prioridade = 0, bool importante = false)
        {
            if (titulo.Length < 3)
                throw new Exception("O título da tarefa deve conter mais que 3 caracteres");

            this.Id = id;
            this.Titulo = titulo;
            this.Prioridade = prioridade;
            this.Importante = importante;
        }

        public int Id { get; protected set; }
        public string Titulo { get; protected set; }
        public Int16 Prioridade { get; protected set; }
        public bool Importante { get; protected set; }

    }
}
