using Examples.CleanArquitecture.Application.DTO;
using MediatR;

namespace Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson;

public record GetPersonByIdQuery(int id) : IRequest<PersonDto>;
