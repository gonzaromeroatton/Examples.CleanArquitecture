using Examples.CleanArquitecture.Domain;

namespace Examples.CleanArquitecture.Application.Contracts.Persistence;

public interface IPersonRepository : IGenericRepository<Person>
{
    Task<bool> IsPersonDNIValid(string name);
}
