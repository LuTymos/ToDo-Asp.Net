using Lucas.Api.ToDo.Data.Repositories;
using Lucas.Api.ToDo.Models;

namespace Lucas.Api.ToDo.Services
{
    public class TarefaService : ITarefaService
    {

        private readonly ITarefaRepository _repository;

        public TarefaService(ITarefaRepository repository)
        {
            _repository = repository;
        }
        public TarefaModel? obterTarefaPorID(int id) => _repository.GetById(id);

        public void atualizarTarefa(TarefaModel tarefa) => _repository.Update(tarefa);

        public void criarTarefa(TarefaModel tarefa) => _repository.Add(tarefa);

        public IEnumerable<TarefaModel> listarTarefas() => _repository.GetAll();

        public IEnumerable<TarefaModel> listarTarefas(int pagina = 0, int tamanho = 10)
        {
            return _repository.GetAll(pagina, tamanho);
        }

        public void apagarTarefa(int id)
        {
            var tarefa = _repository.GetById(id);
            if (tarefa != null)
            {
                _repository.Delete(tarefa);
            }
        }


    }
}
