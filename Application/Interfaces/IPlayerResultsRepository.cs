using Application.Dtos;

namespace Application.Interfaces
{
    /// <summary>
    /// Player Results Repository
    /// </summary>
    public interface IPlayerResultsRepository
    {
        /// <summary>
        /// Gets the PlayerResult objects that match the playerId
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns></returns>
        Task<List<PlayerResultDto>> GetAsync(int playerId);        
    }
}
