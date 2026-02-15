using GameStoreApi.Dtos;

namespace GameStoreApi.Services
{
    public interface IGameService
    {
        IEnumerable<GameDto> GetAll();
        GameDto? GetById(int id);
        GameDto Create(CreateGameDto newGame);
        bool Update(int id, UpdateGameDto updatedGame);
        bool Delete(int id);
    }
}
