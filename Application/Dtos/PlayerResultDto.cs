namespace Application.Dtos
{
    /// <summary>
    /// Dto containg stats of player information
    /// </summary>
    /// <param name="PlayerId"></param>
    /// <param name="Headshots"></param>
    /// <param name="Kills"></param>
    /// <param name="Deaths"></param>
    /// <param name="WonGame"></param>
    /// <param name="KillStreak"></param>
    /// <param name="GameDuration"></param>
    /// <param name="StartTime"></param>
    /// <param name="MapName"></param>
    public record PlayerResultDto(int PlayerId, int Headshots, int Kills, int Deaths, bool WonGame, int KillStreak, int GameDuration, DateTime StartTime, string MapName);    
}
