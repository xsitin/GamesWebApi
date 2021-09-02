using GamesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesWebApi.Infrastructure
{
    public class GameContext : DbContext, IDataContext<GameModel>
    {
        public GameContext(DbContextOptions<GameContext> options) : base(options)
        {
        }

        public DbSet<GameModel> Games { get; set; }
    }
}