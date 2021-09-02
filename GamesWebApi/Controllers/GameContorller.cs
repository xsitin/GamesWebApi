using System.Threading.Tasks;
using GamesWebApi.Dtos;
using GamesWebApi.Infrastructure;
using GamesWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesWebApi.Controllers
{
    [ApiController]
    [Route("games")]
    public class GameContorller : Controller
    {
        private IGameRepository gameRepository;

        public GameContorller(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var game = await gameRepository.Get(id);
            if (game == null)
                return NotFound();
            return Json(game);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Json(await gameRepository.GetAll());

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            if (await gameRepository.Delete(id))
                return Ok();
            return NotFound();
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, UpdateGameDto updateGameDto)
        {
            var game = new GameModel()
            {
                Id = id,
                Name = updateGameDto.Name,
                Developer = updateGameDto.Developer,
                Genres = updateGameDto.Genres
            };
            if (await gameRepository.Update(game))
                return Ok();
            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(CreateGameDto createGameDto)
        {
            var game = new GameModel()
            {
                Name = createGameDto.Name,
                Developer = createGameDto.Developer,
                Genres = createGameDto.Genres
            };

            var id = await gameRepository.Add(game);
            return Ok($"game added with id: {id}");
        }
    }
}