namespace Backend
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; } = string.Empty;
        public int Year { get; set; }
        public string Transmission { get; set; } = "Manual"; // or "Automatic"
        public string ImageUrl { get; set; } = string.Empty;
    }

}
