namespace GameStoreApi.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
}
