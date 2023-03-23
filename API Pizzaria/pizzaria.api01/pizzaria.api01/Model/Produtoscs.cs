using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
namespace pizzaria.api01.Model
{
    public class Produtos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Codigo { get; set; }

        public string Descricao { get; set; }
        public int Estoque { get; set; }
    }
}
