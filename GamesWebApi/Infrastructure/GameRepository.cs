using System.Collections.Generic;
using System.Threading.Tasks;
using GamesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesWebApi.Infrastructure
{
    public class GameRepository : IGameRepository
    {
        private IDataContext<GameModel> context;

        public GameRepository(IDataContext<GameModel> context)
        {
            this.context = context;
        }


        public async Task<GameModel> Get(long id) => await context.Games.FindAsync(id);

        public async Task<IEnumerable<GameModel>> GetAll() => await context.Games.ToListAsync();

        public async Task<long> Add(GameModel game)
        {
            var entityEntry = context.Games.Add(game);
            await context.SaveChangesAsync();
            return entityEntry.Entity.Id;
        }

        public async Task<bool> Delete(long id)
        {
            var itemToRemove = await context.Games.FindAsync(id);
            if (itemToRemove == null)
                return false;

            context.Games.Remove(itemToRemove);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(GameModel game)
        {
            var itemToUpdate = await context.Games.FindAsync(game.Id);
            if (itemToUpdate == null)
                return false;
            itemToUpdate.Name = game.Name;
            itemToUpdate.Developer = game.Developer;
            itemToUpdate.Genres = game.Genres;
            await context.SaveChangesAsync();
            return true;
        }
    }
}