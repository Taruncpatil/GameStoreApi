using Microsoft.AspNetCore.Mvc;
using GameStoreApi.Services;
using GameStoreApi.Dtos;

namespace GameStoreApi.Controllers
{
    [ApiController]
    [Route("games")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService service;

        public GamesController(IGameService service)
        {
            this.service = service;
        }

        // GET /games
        [HttpGet]
        public IEnumerable<GameDto> GetGames()
        {
            return service.GetAll();
        }

        // GET /games/{id}
        [HttpGet("{id}")]
        public ActionResult<GameDto> GetGame(int id)
        {
            var game = service.GetById(id);

            if (game == null)
                return NotFound();

            return game;
        }

        // POST /games
        [HttpPost]
        public ActionResult<GameDto> CreateGame(CreateGameDto newGame)
        {
            var game = service.Create(newGame);

            return CreatedAtAction(
                nameof(GetGame),
                new { id = game.Id },
                game
            );
        }

        // PUT /games/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, UpdateGameDto updatedGame)
        {
            var success = service.Update(id, updatedGame);

            if (!success)
                return NotFound();

            return NoContent();
        }

        // DELETE /games/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            var success = service.Delete(id);

            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
