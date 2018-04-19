using System;

namespace ComplineProva.Web.Models
{
    public class TarefaVM
    {
        public int Id { get;  set; }
        public string Titulo { get;  set; }
        public Int16 Prioridade { get;  set; }
        public bool Importante { get;  set; }
    }
}