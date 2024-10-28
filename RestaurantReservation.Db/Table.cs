namespace RestaurantReservation.Db
{
    public class Table
    {
        public int TableId { get; set; }
        public int RestaurantId { get; set; }
        public int Capacity { get; set; }

        // Navigation properties
        public Restaurant Restaurant { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}