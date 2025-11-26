using AutoMapper;
using Examples.CleanArquitecture.Application.Contracts.Persistence;
using Examples.CleanArquitecture.Application.DTO;
using Examples.CleanArquitecture.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.CleanArquitecture.Application.Features.Person.Queries.GetPerson
{
    public class GetPersonByDniQueryHandle : IRequestHandler<GetPersonByDniQuery, PersonDto>
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
        public GetPersonByDniQueryHandle(IPersonRepository leaveAllocationRepository,
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
        public async Task<PersonDto> Handle(GetPersonByDniQuery request, CancellationToken cancellationToken = default)
        {
            var validator = new GetPersonQueryValidator(_personRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid DNI value", validationResult);

            var person = await _personRepository.GetByDniAsync(request.dni);

            return this._mapper.Map<PersonDto>(person);
        }
    }

}
