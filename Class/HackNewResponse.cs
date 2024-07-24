namespace WebApplicationHacker.Class
{
    // Define a class that matches the JSON structure you expect to receive
    public class HackNewResponse
    {
        public string? By { get; set; }
        public int? Descendants { get; set; }
        public int? Id { get; set; }
        public int[]? Kids { get; set; }
        public int? Score { get; set; }
        public long Time { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
    }
}
