using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Data.Models
{
    public class Vendedor
    {
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(60, ErrorMessage = "O campo {0} precisa ter no máximo {1} caracteres")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "O campo {0} está em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }
    }
}
