using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class UsuarioDocumento
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Path { get; set; }
        public int DocumentoId { get; set; }
        public int StatusId { get; set; }
        public bool Excluido { get; set; }

        public Documento Documento { get; set; }
        public Status Status { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
