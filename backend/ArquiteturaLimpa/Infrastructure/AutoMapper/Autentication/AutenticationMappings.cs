using Application.Autentication; 
using AutoMapper; 
using Domain.Model; 

namespace Infrastructure.AutoMapper.Autentication
{
    public class AutenticationMappings : Profile
    {
        public AutenticationMappings()
        {
            CreateMap<AutenticationCommand, AutenticationModel>();
            CreateMap<AutenticationModel, AutenticationCommand>();
              
        }
    }
}
