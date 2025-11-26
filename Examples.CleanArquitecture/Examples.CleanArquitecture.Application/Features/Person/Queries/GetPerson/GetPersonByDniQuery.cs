using Examples.CleanArquitecture.Application.DTO;
using MediatR;

namespace Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson;

public record GetPersonByDniQuery(string dni) : IRequest<PersonDto>;
