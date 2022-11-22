namespace FakeApi.DTO.V1
{
    public class Products
    {
        public int id { get; set; }
        public float price { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? category { get; set; }
        public string? image { get; set; }
        public Rating? Rating { get; set; }
    }
}
