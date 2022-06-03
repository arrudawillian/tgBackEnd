using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class Pagamento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public decimal Valor { get; set; }
        //add o id do documento aqui
    }
}
