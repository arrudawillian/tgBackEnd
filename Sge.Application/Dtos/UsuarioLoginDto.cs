using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sge.Application.Dtos
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "O {0} é obrigatório", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "O {0} deve ser em formato válido.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "A {0} é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
