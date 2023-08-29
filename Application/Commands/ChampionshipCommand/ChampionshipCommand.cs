using Application.Context;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Commands.ChampionshipCommand
{
    public class ChampionshipCommand : IRequest<int>
    {
        public Actions Action { get; set; }

        public int ChampionshipId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }

    public class ChampionshipCommandHandler : IRequestHandler<ChampionshipCommand, int> 
    {
        IAppDbContext _dbContext;

        public ChampionshipCommandHandler(IAppDbContext dbContext)
        {
            _dbContext = dbContext;    
        }

        public async Task<int> Handle(ChampionshipCommand request, CancellationToken cancellationToken)
        {
            if (request.Action == Actions.Create) 
            {
                Championship champ = new() { Name = request.Name, };  

                _dbContext.Championships.Add(champ);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return champ.ChampionshipId;
            }
            else if (request.Action == Actions.Delete) 
            {
                Championship champ = _dbContext.Championships.FirstOrDefault(c => c.ChampionshipId == request.ChampionshipId) ?? null!;

                if (champ != null)
                {
                    _dbContext.Championships.Remove(champ);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return champ.ChampionshipId;
                }
                else throw new KeyNotFoundException();
            }
            else if (request.Action == Actions.Update) 
            {
                Championship champ = _dbContext.Championships.FirstOrDefault(c => c.ChampionshipId == request.ChampionshipId) ?? null!;

                if (champ != null)
                {
                    champ.Name = request.Name;
                    _dbContext.Championships.Update(champ);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return champ.ChampionshipId;
                }
                else throw new KeyNotFoundException();
            }
            else
                throw new InvalidOperationException();
        }
    }
}
