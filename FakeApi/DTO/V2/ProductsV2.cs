namespace FakeApi.DTO.V2
{
    public class Products
    {
        public Guid InternalId { get; set; }
        public int id { get; set; }
        public float price { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating? Rating { get; set; }
    }
}
