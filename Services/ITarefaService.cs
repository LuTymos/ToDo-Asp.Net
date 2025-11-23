using Lucas.Api.ToDo.Models;

namespace Lucas.Api.ToDo.Services
{
    public interface ITarefaService
    {
        IEnumerable<TarefaModel> listarTarefas();
        IEnumerable<TarefaModel> listarTarefas(int page, int size);
        TarefaModel? obterTarefaPorID(int id);
        void criarTarefa(TarefaModel tarefa);
        void atualizarTarefa(TarefaModel tarefa);
        void apagarTarefa(int id);

    }
}
