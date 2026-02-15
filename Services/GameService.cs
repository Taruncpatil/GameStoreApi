using GameStoreApi.Data;
using GameStoreApi.Entities;
using GameStoreApi.Dtos;

namespace GameStoreApi.Services
{
    public class GameService : IGameService
    {
        private readonly GameStoreContext context;
        private readonly ILogger<GameService> logger;

        public GameService(GameStoreContext context, ILogger<GameService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // Get all games
        public IEnumerable<GameDto> GetAll()
        {
            logger.LogInformation("Fetching all games from database");

            return context.Games.Select(game => new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            });
        }

        // Get game by ID
        public GameDto? GetById(int id)
        {
            logger.LogInformation("Fetching game with ID {GameId}", id);

            var game = context.Games.Find(id);
            if (game == null)
            {
                logger.LogWarning("Game with ID {GameId} not found", id);
                return null;
            }

            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        // Create a new game
        public GameDto Create(CreateGameDto newGame)
        {
            logger.LogInformation("Creating new game: {GameName}", newGame.Name);

            Game game = new()
            {
                Name = newGame.Name,
                Genre = newGame.Genre,
                Price = newGame.Price,
                ReleaseDate = newGame.ReleaseDate
            };

            context.Games.Add(game);
            context.SaveChanges();

            return new GameDto
            {
                Id = game.Id,
                Name = game.Name,
                Genre = game.Genre,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        // Update an existing game
        public bool Update(int id, UpdateGameDto updatedGame)
        {
            logger.LogInformation("Updating game with ID {GameId}", id);

            var game = context.Games.Find(id);
            if (game == null)
            {
                logger.LogWarning("Game with ID {GameId} not found", id);
                return false;
            }

            game.Name = updatedGame.Name;
            game.Genre = updatedGame.Genre;
            game.Price = updatedGame.Price;
            game.ReleaseDate = updatedGame.ReleaseDate;

            context.SaveChanges();
            return true;
        }

        // Delete a game
        public bool Delete(int id)
        {
            logger.LogInformation("Deleting game with ID {GameId}", id);

            var game = context.Games.Find(id);
            if (game == null)
            {
                logger.LogWarning("Game with ID {GameId} not found", id);
                return false;
            }

            context.Games.Remove(game);
            context.SaveChanges();
            return true;
        }
    }
}
