using Examples.CleanArquitecture.Application.Contracts.Persistence;
using FluentValidation;

namespace Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson;

/// <summary>
/// 
/// </summary>
public sealed class GetPersonQueryValidator : AbstractValidator<GetPersonByDniQuery>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="personRepository"></param>
    public GetPersonQueryValidator(IPersonRepository personRepository)
    {
        RuleFor(p => p.dni)
            .MustAsync(DniShouldExists);

        this._personRepository = personRepository;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dni"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    private async Task<bool> DniShouldExists(string dni, CancellationToken token)
    {
        return await _personRepository.IsPersonDNIValid(dni);
    }
}
