using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
namespace pizzaria.api01.Model
{
    public class MateriaPrimas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Estoque { get; set; }
    }
}
