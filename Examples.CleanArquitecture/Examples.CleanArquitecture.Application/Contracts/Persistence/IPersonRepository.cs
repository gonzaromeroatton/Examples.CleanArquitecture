using Examples.CleanArquitecture.Domain;
using MediatR;

namespace Examples.CleanArquitecture.Application.Contracts.Persistence;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<bool> IsPersonDNIValid(string name);

    Task<Person> GetByDniAsync(string dni);
}
