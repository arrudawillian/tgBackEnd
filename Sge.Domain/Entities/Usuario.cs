using System;
using System.Collections.Generic;

#nullable disable

namespace Sge.Domain.Entities
{
    public class Usuario
    {
        //public Usuario()
        //{
        //    Pagamentos = new HashSet<Pagamento>();
        //    UsuarioDocumentos = new HashSet<UsuarioDocumento>();
        //}

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
        public string Senha { get; set; }
        public int? PerfilId { get; set; }
        public string RA { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Codigo { get; set; }

        public Curso Curso { get; set; }
        public Unidade Unidade { get; set; }
        public UnidadePacote UnidadePacote { get; set; }
        public virtual ICollection<Pagamento> Pagamentos { get; set; }
        public virtual ICollection<UsuarioDocumento> UsuarioDocumentos { get; set; }
    }
}
