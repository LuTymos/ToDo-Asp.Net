using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lucas.Api.ToDo.Models
{
    [Table("tarefas")]
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriada { get; set; }

    }
}
