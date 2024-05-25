namespace Zadanie7.Models.DTOs

{
    public class AddTripToClientRequestDTO
    {
        public int IdClient { get; set; }
        public int IdTrip { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}