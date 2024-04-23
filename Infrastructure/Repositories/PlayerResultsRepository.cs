using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PlayerResultsRepository(PlayerResultDbContext context) : IPlayerResultsRepository
    {
        public async Task<List<PlayerResultDto>> GetAsync(int playerId)
        {
            var data = await context.PlayerResults
                .Where(a => a.Player.Id == playerId).AsNoTracking()                
                .ProjectToType<PlayerResultDto>()
                .ToListAsync();
            return data;
        }
    }
}
