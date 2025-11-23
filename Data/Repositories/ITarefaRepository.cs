using Lucas.Api.ToDo.Models;

namespace Lucas.Api.ToDo.Data.Repositories
{
    public interface ITarefaRepository
    {
        IEnumerable<TarefaModel> GetAll();
        IEnumerable<TarefaModel> GetAll(int page, int size);
        TarefaModel? GetById(int id);
        void Add(TarefaModel tarefa);
        void Update(TarefaModel tarefa); 
        void Delete(TarefaModel tarefa);
    }
}
