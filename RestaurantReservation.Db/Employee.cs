namespace RestaurantReservation.Db
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int RestaurantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        // Navigation property
        public Restaurant Restaurant { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}