using System;
using System.Collections.Generic;
namespace Adventure.Data
{
    public class FlightsService : IFlightsService
    {
        private List<Flight> flights = new List<Flight>()
        {
            new Flight
            {
                Id = Guid.NewGuid(),
                NameOfAirplane = "Airbus 880",
                Company = "Emirates",
                Seat = "1",
                From = "Paris",
                To = "New York",
                TakeOffTime = "12 PM",
                LandingTime = "12 AM"

            }
        };


        public Flight GetFlight(Guid id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return flights.SingleOrDefault(x => x.Id == id);
#pragma warning restore CS8603 // Possible null reference return.

        }

        public List<Flight> GetFlights()
        {
            return flights;
        }

        public void AddFlight(Flight flight)
        {
            var id = Guid.NewGuid();
            flight.Id = id;
            flights.Add(flight);
        }

        public void UpdateFlight(Flight flight)
        {
            var getOldFlight = GetFlight(flight.Id);
            getOldFlight.NameOfAirplane = flight.NameOfAirplane; 
        }

        public void DeleteFlight(Guid id)
        {
            var flight = GetFlight(id);
            flights.Remove(flight);
        }
    }
}
