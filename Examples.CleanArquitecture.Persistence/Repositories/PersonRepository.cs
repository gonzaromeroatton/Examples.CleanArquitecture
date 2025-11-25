using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Domain;
using Examples.CleanArquitecture.Persistence.DatabaseContext;

namespace Examples.CleanArquitecture.Persistence.Repositories;

/// <summary>
/// 
/// </summary>
public sealed class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public PersonRepository(PersonsDatabaseContext context) : base(context) { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public async Task<bool> IsPersonDNIValid(string name)
    {
        return await Task.FromResult(!this._context.Persons.Any(p => p.Name == name));
    }
}
