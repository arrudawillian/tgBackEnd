using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int UnidadeId { get; set; }
        public Unidade Unidade { get; set; }
    }
}
