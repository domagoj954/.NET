namespace Adventure.Data
{
    public class Flight
    {
        public Guid Id { get; set; }

        public string? NameOfAirplane { get; set; }

        public string? Company { get; set; }
        public string? Seat { get; set; }

        public string? From { get; set; }

        public string? To { get; set; }

        public string? TakeOffTime { get; set; }

        public string? LandingTime { get; set; }

    }
}
