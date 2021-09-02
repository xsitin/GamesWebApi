using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GamesWebApi.Models
{
    public class GameModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Developer { get; set; }
        public Genre[] Genres { get; set; }
    }
}