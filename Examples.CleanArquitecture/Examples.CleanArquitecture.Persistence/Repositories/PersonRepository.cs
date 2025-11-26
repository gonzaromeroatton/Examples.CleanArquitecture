using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Domain;
using Examples.CleanArquitecture.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

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
    /// <param name="dni"></param>
    /// <returns></returns>
    public async Task<bool> IsPersonDNIValid(string dni)
    {
        // TODO later replace with a module 11 algorithm to validate DNI
        return await Task.FromResult(dni == "134416327");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dni"></param>
    /// <returns></returns>
    public async Task<Person> GetByDniAsync(string dni)
    {
        return await this._context.Set<Person>().AsNoTracking().FirstOrDefaultAsync(q => q.DNI == dni);
    }
}
