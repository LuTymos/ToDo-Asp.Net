using AutoMapper;
using Lucas.Api.ToDo.Models;
using Lucas.Api.ToDo.ViewModels;

namespace Lucas.Api.ToDo.Mappers
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<TarefaModel, TarefaViewModel>();

            CreateMap<TarefaCreateViewModel, TarefaModel>();

            CreateMap<TarefaViewModel, TarefaModel>();

            CreateMap<TarefaUpdateViewModel, TarefaModel>();
        }
    }
}