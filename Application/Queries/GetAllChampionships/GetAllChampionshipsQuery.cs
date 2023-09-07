
using Application.Context;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetAllChampionships
{
    public class GetAllChampionshipsQuery : IRequest<AllChampionshipsVm>
    {
    }

    public class GetAllChampionshipsQueryHandler : IRequestHandler<GetAllChampionshipsQuery, AllChampionshipsVm>
    {
        private readonly IAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllChampionshipsQueryHandler(IAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<AllChampionshipsVm> Handle(GetAllChampionshipsQuery request, CancellationToken cancellationToken)
        {
            AllChampionshipsVm vm = new();

            vm.AllChampionships = await _dbContext.Championships.ProjectTo<AllChampionshipsDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return vm;
        }
    }
}
