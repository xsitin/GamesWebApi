using System.Collections.Generic;
using System.Threading.Tasks;
using GamesWebApi.Models;

namespace GamesWebApi.Infrastructure
{
    public interface IGameRepository
    {
        Task<GameModel> Get(long id);
        Task<IEnumerable<GameModel>> GetAll();
        Task<long> Add(GameModel product);
        Task<bool> Delete(long id);
        Task<bool> Update(GameModel game);
    }
}