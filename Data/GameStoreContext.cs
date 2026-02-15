using Microsoft.EntityFrameworkCore;
using GameStoreApi.Entities;

namespace GameStoreApi.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }
    }
}
