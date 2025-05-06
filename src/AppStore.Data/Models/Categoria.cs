using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Data.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
                
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Categoria")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Ativo { get; set; }

        public IEnumerable<Produto> Produtos { get; set; }

    }
}
