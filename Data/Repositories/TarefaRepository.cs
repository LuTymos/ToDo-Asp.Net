using Lucas.Api.ToDo.Data.Contexts;
using Lucas.Api.ToDo.Models;

namespace Lucas.Api.ToDo.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DatabaseContext _context;

        public TarefaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(TarefaModel tarefa)
        {
            _context.Tarefa.Add(tarefa);
            _context.SaveChanges();
        }

        public void Update(TarefaModel tarefa)
        {
            _context.Tarefa.Update(tarefa);
            _context.SaveChanges();
        }

        public void Delete(TarefaModel tarefa)
        {
            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
        }

        public IEnumerable<TarefaModel> GetAll() => _context.Tarefa.ToList();

        public TarefaModel? GetById(int id) => _context.Tarefa.Find(id);

        public IEnumerable<TarefaModel> GetAll(int page, int size)
        {
            return _context.Tarefa
                           .Skip((page - 1) * size)
                           .Take(size)
                           .ToList();
        }
    }
}
