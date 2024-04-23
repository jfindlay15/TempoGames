using Application.Dtos;
using Domain.Entities;
using Mapster;

namespace Infrastructure.Mappings
{
    public class MapsterConfig : IRegister
    {
        /// <summary>
        /// Custom mapings for Mapster
        /// </summary>
        /// <param name="config"></param>
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<PlayerResults, PlayerResultDto>()
                .Map(dest => dest.MapName, src => src.Game.Map.Name);

            config.NewConfig<PlayerResultDto, PlayedGamesDto>()
                .Map(dest => dest.KDRatio, src => src.Deaths == 0 ? src.Kills : ((decimal)src.Kills / src.Deaths));
        }
    }
}
