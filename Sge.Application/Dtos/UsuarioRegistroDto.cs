using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sge.Application.Dtos
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "O {0} é obrigatório", AllowEmptyStrings = false)]
        [StringLength(200, ErrorMessage = "O {0} deve conter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 4)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O {0} é obrigatório", AllowEmptyStrings = false)]
        [EmailAddress(ErrorMessage = "O {0} deve ser em formato válido.")]
        [StringLength(100, ErrorMessage = "O Email deve conter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 4)]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "A {0} é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "A {0} deve conter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 4)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatória", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "A {0} deve conter no máximo {1} e no mínimo {2} caracteres.", MinimumLength = 4)]
        [Compare("Senha", ErrorMessage = "senhas informadas não conferem.")]
        [Display(Name = "Confirmação da senha")]
        public string ConfirmaSenha { get; set; }
    }
}
