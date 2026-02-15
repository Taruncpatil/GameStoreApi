using Microsoft.AspNetCore.Mvc;
using GameStoreApi.Models;
using GameStoreApi.Dtos;

namespace GameStoreApi.Controllers
{
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        // Temporary in-memory list (fake database)
        private static List<Game> games = new()
        {
            new Game { Id = 1, Name = "FIFA 24", Genre = "Sports", Price = 59.99M },
            new Game { Id = 2, Name = "GTA V", Genre = "Action", Price = 39.99M }
        };

        // GET /games
        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            return games.Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Price = game.Price
            });
        }

        // GET /games/1
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(int id)
        {
            var game = games.Find(g => g.Id == id);

            if (game == null)
                return NotFound();

            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Price = game.Price
            };
        }
        [HttpPost]
    public ActionResult<GameDto> CreateGame(GameDto gameDto)
{
    Game game = new()
    {
        Id = games.Max(g => g.Id) + 1,
        Name = gameDto.Name,
        Genre = gameDto.Genre,
        Price = gameDto.Price
    };

    games.Add(game);

    return new GameDto
    {
        Id = game.Id,
        Name = game.Name,
        Genre = game.Genre,
        Price = game.Price
    };
}
    [HttpPut("{id}")]
    public IActionResult UpdateGame(int id, GameDto updatedGame)
    {
    var game = games.Find(g => g.Id == id);

    if (game == null)
        return NotFound();

    game.Name = updatedGame.Name;
    game.Genre = updatedGame.Genre;
    game.Price = updatedGame.Price;

    return NoContent();
}

    [HttpDelete("{id}")]
public IActionResult DeleteGame(int id)
{
    var game = games.Find(g => g.Id == id);

    if (game == null)
        return NotFound();

    games.Remove(game);

    return NoContent();
}

    
}
}
