using Application.Dtos;

namespace Application.Interfaces
{
    /// <summary>
    /// Player Repository
    /// </summary>
    public interface IPlayerRepository
    {
        /// <summary>
        /// Returns the player matching the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<PlayerDto> GetByPlayerName(string name);        
    }
}
