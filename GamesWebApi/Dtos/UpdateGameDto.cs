using GamesWebApi.Models;

namespace GamesWebApi.Dtos
{
    public class UpdateGameDto
    {
        public string Name { get; set; }
        public string Developer { get; set; }
        public Genre[] Genres { get; set; }
    }
}