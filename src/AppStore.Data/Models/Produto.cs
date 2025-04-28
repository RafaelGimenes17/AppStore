using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Data.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Descricao { get; set; }
        public string Imagem { get; set; }

        [Range (0, 100.000, ErrorMessage = "O valor do campo preço deve estar entre {0} and {1}.")]
        [RegularExpression(@"^(?=.*[1-9])([0-9]{0,3}(?:,[0-9]{1,2})?)$", ErrorMessage = "O campo {0} está em formato inválido.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeEstoque { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public Vendedor Vendedor { get; set; }

        [DisplayName("Categoria")]
        public Guid CategoriaId { get; set; }
        
        public Guid VendedorId { get; set; }
    }
}
