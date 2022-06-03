using Sge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sge.Application.Dtos
{
    public class UsuarioDetalheDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int? UnidadeId { get; set; }
        public int? UnidadePacoteId { get; set; }
        public int? CursoId { get; set; }
        public string Identidade { get; set; }
        public string Celular { get; set; }
        public string Sexo { get; set; }
        public string Img { get; set; }
        public string RA { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Codigo { get; set; }

        public Curso Curso { get; set; }
        public Unidade Unidade { get; set; }
        public UnidadePacote UnidadePacote { get; set; }
    }
}
