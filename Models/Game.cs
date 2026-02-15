namespace GameStoreApi.Models
{
    public class Game
    {
        public int Id { get; set; }       // Unique identifier
        public required string Name { get; set; }  // Game name
        public string Genre { get; set; } // Game type
        public decimal Price { get; set; }// Game price
    }
}
