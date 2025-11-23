using AutoMapper;
using Lucas.Api.ToDo.Models;
using Lucas.Api.ToDo.Services;
using Lucas.Api.ToDo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lucas.Api.ToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaService _service;
        private readonly IMapper _mapper;

        public TarefaController(ITarefaService service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TarefaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var clientes = _service.listarTarefas(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<TarefaViewModel>>(clientes);

            var viewModel = new TarefaPaginacaoViewModel
            {
                Tarefa = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }

        [HttpGet("{id}")]
        public ActionResult<TarefaViewModel> Get(int id)
        {
            var morador = _service.obterTarefaPorID(id);
            if (morador == null)
                return NotFound();

            var viewModel = _mapper.Map<TarefaViewModel>(morador);
            return Ok(viewModel);
        }

        [HttpPost]
        public ActionResult Post([FromBody] TarefaCreateViewModel viewModel)
        {
            var morador = _mapper.Map<TarefaModel>(viewModel);
            _service.criarTarefa(morador);
            return CreatedAtAction(nameof(Get), new { id = morador.Id }, viewModel);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TarefaUpdateViewModel viewModel)
        {
            var TarefaExiste = _service.obterTarefaPorID(id);
            if (TarefaExiste == null)
                return NotFound();

            _mapper.Map(viewModel, TarefaExiste);
            _service.atualizarTarefa(TarefaExiste);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.apagarTarefa(id);
            return NoContent();
        }

    }
}
