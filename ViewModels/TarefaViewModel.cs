namespace Lucas.Api.ToDo.ViewModels
{
    public class TarefaViewModel
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }
        public DateTime DataCriada { get; set; }
    }
}
