using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;

namespace Modul10_103022400026.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static readonly List<Game> games = new List<Game>
        {
            new Game { Nama = "Valorant", Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, 
                Platform = new List<string> {"PC"}, Mode = new List<string> {"Multiplayer"}, IsOnline = true, Harga = 0 },
            new Game { Nama = "GTA", Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, 
                Platform = new List<string> {"PC", "PS4", "PS5", "Xbox"}, Mode = new List<string> {"Singleplayer", "Multiplayer"}, IsOnline = true, Harga = 30000 },
            new Game { Nama = "The Witcher 3", Developer = "“CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, 
                Platform = new List<string> {"PC", "PS4", "PS5", "Xbox", "Switch"}, Mode = new List<string> {"Singleplayer"}, IsOnline = true, Harga = 250000 }
        };

        [HttpGet]

        public ActionResult<List<Game>> GetAll()
        {
            return games;
        }

        [HttpGet("{index}")]
        public ActionResult<Game> GetByIndex(int index)
        {
            if (index < 0 || index >= games.Count)
                return NotFound();
            return games[index];
        }

        [HttpPost]
        public ActionResult AddGame([FromBody] Game game)
        {
            games.Add(game);
            return Ok(games);
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteGame(int index) 
        { 
            if (index < 0 || index >= games.Count)
                return NotFound();

            games.RemoveAt(index);
            return Ok(games);
        }
        [HttpPut("{index}")]
        public ActionResult PutGame(int index, [FromBody] Game game)
        {
            games[index] = game;
            return Ok(games[index]);
        }
    }
}
