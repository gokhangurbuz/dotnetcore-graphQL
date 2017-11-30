namespace aspnetcoregraphql.Models
{
    public class News
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        Category Category { get; set; }
    }
}
