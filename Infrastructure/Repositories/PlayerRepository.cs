using Application.Dtos;
using Application.Interfaces;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PlayerRepository(PlayerResultDbContext context) : IPlayerRepository
    {
        public async Task<PlayerDto> GetByPlayerName(string name)
        {
            var query = await context.Players                
                .FirstOrDefaultAsync(a => a.Name.ToLower() == name.ToLower());
            var player = query.Adapt<PlayerDto>();
            return player;
        }
    }
}
