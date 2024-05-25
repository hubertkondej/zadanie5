namespace Zadanie7.Models.DTOs
{
    public class TripDTO
    {
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public int MaxPeople { get; set; }
        public ICollection<ClientTripDTO> ClientTrips { get; set; }
    }
}