using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;
namespace pizzaria.api01.Model
{
    public class Usuarios
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }
    }
}
