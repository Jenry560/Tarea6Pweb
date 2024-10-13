using AutoMapper;
using Tarea6Pweb.Models;
using Tarea6Pweb.Models.Dtos;

namespace Tarea6Pweb.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {

            CreateMap<AgenteDto, Agente>().ReverseMap();
            CreateMap<IncidenciasDto,Incidencia>().ReverseMap();
        }
                
    }
}
