using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PlayerResultDbContext : DbContext
    {
        public PlayerResultDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerResults> PlayerResults { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Game> Games { get; set; }

        /// <summary>
        /// Called when the service stats so that test data is seeded
        /// </summary>
        public void SeedData()
        {
            SeedMaps();
            SeedGames();
            SeedPlayers();
            SeedPlayerResults();
        }

        private void SeedGames()
        {            
            using (var transaction = Database.BeginTransaction())
            {
                Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Games] ON");

                var games = new[]
                {
                    new Game { Id = 1, MapId = 1 },
                    new Game { Id = 2, MapId = 2 },
                };

                Games.AddRange(games);
                SaveChanges();
                Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Games] Off");
                transaction.Commit();
            }

        }

            private void SeedPlayerResults()
            {
                using (var transaction = Database.BeginTransaction())
                {
                    Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[PlayerResults] ON");

                    var playerResults = new[]
                    {
                    new PlayerResults
                    {
                        Id = 1,
                        PlayerId = 2,
                        GameId = 1,
                        Kills = 5,
                        Deaths = 10,
                        WonGame = true,
                        GameDuration = 300,
                        KillStreak = 10,
                        StartTime = DateTime.Now,
                        Headshots = 10,
                    }
                };

                    PlayerResults.AddRange(playerResults);
                    SaveChanges();
                    Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[PlayerResults] OFF");
                    transaction.Commit();
                }

            }

            private void SeedPlayers()
            {
                using (var transaction = Database.BeginTransaction())

                {
                    Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Players] ON");

                    var players = new[]
                    {
                    new Player { Id = 1, Name = "Player1", Level = 5 },
                    new Player { Id = 2, Name = "Player2", Level = 10 }
                };

                    Players.AddRange(players);
                    SaveChanges();
                    Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Players] OFF");
                    transaction.Commit();
                }
            }

            private void SeedMaps()
            {
                using (var transaction = Database.BeginTransaction())
                {
                    Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Maps] ON");
                    var maps = new[]
                    {
                    new Map{Id=1, Name = "The Capital"},
                    new Map{Id=2, Name = "Arcadia"}
                };

                    Maps.AddRange(maps);
                    SaveChanges();
                    this.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Maps] OFF");
                    transaction.Commit();
                }
            }
        }
    }
