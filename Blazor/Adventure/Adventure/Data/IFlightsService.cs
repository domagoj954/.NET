namespace Adventure.Data
{
    public interface IFlightsService
    {
        List<Flight> GetFlights();

        Flight GetFlight(Guid id);

        void UpdateFlight(Flight flight);

        void AddFlight(Flight flight);

        void DeleteFlight (Guid id);
    }
}
