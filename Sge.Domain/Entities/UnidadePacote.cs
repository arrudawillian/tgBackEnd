using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class UnidadePacote
    {
        public int Id { get; set; }
        public int UnidadeId { get; set; }
        public int PacoteId { get; set; }
        public decimal Valor { get; set; }

        public Pacote Pacote { get; set; }
    }
}
