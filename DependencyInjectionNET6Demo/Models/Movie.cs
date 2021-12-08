namespace DependencyInjectionNET6Demo.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateOnly ReleaseDate { get; set; }
        public int RuntimeMinutes { get; set; }
        public string Director { get; set; }
    }
}
