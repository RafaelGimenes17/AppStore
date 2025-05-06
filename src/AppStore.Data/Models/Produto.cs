using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Display(Name = "Imagem do Produto")]
        public string Imagem { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? ImagemUpload { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range (1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Quantidade Estoque")]
        public int QuantidadeEstoque { get; set; }
               
        public string VendedorId { get; set; }
        public Vendedor Vendedor { get; set; }

        [DisplayName("Categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria{ get; set; }
        //public IEnumerable<Categoria> Categoria { get; set; }

    }
}
