

using AutoMapper;
using Sge.Application.Dtos;
using Sge.Domain.Entities;

namespace Sge.Application.MapperConfiguration
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, UsuarioRegistroDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, UsuarioLoginDto>().ReverseMap();
            CreateMap<Usuario, UsuarioDetalheDto>().ReverseMap();
            CreateMap<UsuarioDocumento, UsuarioDocumentoDto>().ReverseMap();
            CreateMap<UsuarioDocumento, UsuarioDocumentoPutDto>().ReverseMap();
        }
    }
}