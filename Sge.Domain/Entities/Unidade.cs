using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        //public ICollection<UnidadePacote> UnidadePacotes { get; set; }
        //public ICollection<Usuario> Usuarios { get; set; }
    }
}
