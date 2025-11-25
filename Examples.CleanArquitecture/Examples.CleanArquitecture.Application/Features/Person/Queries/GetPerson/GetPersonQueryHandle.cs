using AutoMapper;
using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Application.DTO;
using MediatR;

namespace Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson;

/// <summary>
/// 
/// </summary>
public class GetPersonQueryHandle : IRequestHandler<GetPersonQuery, PersonDto>
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IPersonRepository _personRepository;

    /// <summary>
    /// 
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="leaveAllocationRepository"></param>
    /// <param name="mapper"></param>
    public GetPersonQueryHandle(IPersonRepository leaveAllocationRepository,
        IMapper mapper)
    {
        this._personRepository = leaveAllocationRepository;
        this._mapper = mapper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<PersonDto> Handle(GetPersonQuery request, CancellationToken cancellationToken = default)
    {
        var leaveAllocation = await _personRepository.GetByIdAsync(request.id);

        return this._mapper.Map<PersonDto>(leaveAllocation);
    }
}
