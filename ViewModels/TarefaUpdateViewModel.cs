namespace Lucas.Api.ToDo.ViewModels
{
    public class TarefaUpdateViewModel
    {
        public required string Titulo { get; set; }
        public string? Descricao { get; set; }
        public Boolean Concluida { get; set; }
    }
}
