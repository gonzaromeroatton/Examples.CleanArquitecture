using AutoMapper;
using Examples.CleanArquitecture.Application.DTO;
using Examples.CleanArquitecture.Domain;

namespace Examples.CleanArquitecture.Application.Mapping.Profiles;

/// <summary>
/// 
/// </summary>
public sealed class PersonProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public PersonProfile()
    {
        CreateMap<PersonDto, Person>().ReverseMap();
    }
}
