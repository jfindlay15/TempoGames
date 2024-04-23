using Application.Dtos;

namespace DashboardApp.UserState
{
    public class PlayerStatsState
    {
        public PlayerDashboardDto PlayerDashboardDto { get; set; }

        public void SetDashboardState(PlayerDashboardDto playerDashboardDto)
        {
            PlayerDashboardDto = playerDashboardDto;
        }

        public void ClearDashboardState()
        {
            PlayerDashboardDto = new PlayerDashboardDto();
        }
    }
}
