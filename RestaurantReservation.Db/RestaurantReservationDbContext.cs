using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db
{
    public class RestaurantReservationDbContext : DbContext
    {
        // DbSets for each entity 

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<ReservationWithDetails> ReservationWithDetails { get; set; }
        public DbSet<EmployeeWithRestaurant> EmployeeWithRestaurant { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\MSSQLLocalDB;Database=RestaurantReservationCore;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com",
                    PhoneNumber = "123-456-7890"
                },
                new Customer
                {
                    CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com",
                    PhoneNumber = "234-567-8901"
                },
                new Customer
                {
                    CustomerId = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com",
                    PhoneNumber = "345-678-9012"
                },
                new Customer
                {
                    CustomerId = 4, FirstName = "Bob", LastName = "Brown", Email = "bob.brown@example.com",
                    PhoneNumber = "456-789-0123"
                },
                new Customer
                {
                    CustomerId = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie.davis@example.com",
                    PhoneNumber = "567-890-1234"
                }
            );

            // Seed Restaurants
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    RestaurantId = 1, Name = "Pasta Palace", Address = "123 Noodle St", PhoneNumber = "111-222-3333",
                    OpeningHours = "10:00 AM - 10:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 2, Name = "Burger Barn", Address = "456 Burger Ave", PhoneNumber = "222-333-4444",
                    OpeningHours = "11:00 AM - 11:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 3, Name = "Sushi Spot", Address = "789 Sushi Rd", PhoneNumber = "333-444-5555",
                    OpeningHours = "12:00 PM - 12:00 AM"
                },
                new Restaurant
                {
                    RestaurantId = 4, Name = "Taco Town", Address = "321 Taco Blvd", PhoneNumber = "444-555-6666",
                    OpeningHours = "9:00 AM - 9:00 PM"
                },
                new Restaurant
                {
                    RestaurantId = 5, Name = "Pizza Place", Address = "654 Pizza Ln", PhoneNumber = "555-666-7777",
                    OpeningHours = "10:00 AM - 11:00 PM"
                }
            );

            // Seed Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                    { EmployeeId = 1, RestaurantId = 1, FirstName = "Emily", LastName = "Clark", Position = "Manager" },
                new Employee
                    { EmployeeId = 2, RestaurantId = 1, FirstName = "Michael", LastName = "Wilson", Position = "Chef" },
                new Employee
                    { EmployeeId = 3, RestaurantId = 2, FirstName = "Sarah", LastName = "Moore", Position = "Server" },
                new Employee
                {
                    EmployeeId = 4, RestaurantId = 2, FirstName = "David", LastName = "Taylor", Position = "Bartender"
                },
                new Employee
                {
                    EmployeeId = 5, RestaurantId = 3, FirstName = "Laura", LastName = "Anderson",
                    Position = "Sushi Chef"
                }
            );

            // Seed MenuItems
            modelBuilder.Entity<MenuItem>().HasData(
                new MenuItem
                {
                    ItemId = 1, RestaurantId = 1, Name = "Spaghetti",
                    Description = "Classic spaghetti with marinara sauce", Price = 12.99m
                },
                new MenuItem
                {
                    ItemId = 2, RestaurantId = 1, Name = "Fettuccine Alfredo",
                    Description = "Creamy fettuccine with Alfredo sauce", Price = 14.99m
                },
                new MenuItem
                {
                    ItemId = 3, RestaurantId = 2, Name = "Cheeseburger", Description = "Juicy beef burger with cheese",
                    Price = 10.99m
                },
                new MenuItem
                {
                    ItemId = 4, RestaurantId = 2, Name = "Fries", Description = "Crispy golden fries", Price = 3.99m
                },
                new MenuItem
                {
                    ItemId = 5, RestaurantId = 3, Name = "California Roll",
                    Description = "Crab, avocado, and cucumber roll", Price = 8.99m
                }
            );

            // Seed Tables
            modelBuilder.Entity<Table>().HasData(
                new Table { TableId = 1, RestaurantId = 1, Capacity = 4 },
                new Table { TableId = 2, RestaurantId = 1, Capacity = 2 },
                new Table { TableId = 3, RestaurantId = 2, Capacity = 6 },
                new Table { TableId = 4, RestaurantId = 3, Capacity = 8 },
                new Table { TableId = 5, RestaurantId = 4, Capacity = 4 }
            );

            // Seed Reservations
            modelBuilder.Entity<Reservation>().HasData(
                new Reservation
                {
                    ReservationId = 1, CustomerId = 1, RestaurantId = 1, TableId = 1,
                    ReservationDate = new DateTime(2024, 10, 30, 19, 0, 0), PartySize = 2
                },
                new Reservation
                {
                    ReservationId = 2, CustomerId = 2, RestaurantId = 2, TableId = 2,
                    ReservationDate = new DateTime(2024, 10, 30, 20, 0, 0), PartySize = 4
                },
                new Reservation
                {
                    ReservationId = 3, CustomerId = 3, RestaurantId = 3, TableId = 3,
                    ReservationDate = new DateTime(2024, 10, 30, 18, 30, 0), PartySize = 3
                },
                new Reservation
                {
                    ReservationId = 4, CustomerId = 4, RestaurantId = 4, TableId = 4,
                    ReservationDate = new DateTime(2024, 10, 30, 19, 30, 0), PartySize = 5
                },
                new Reservation
                {
                    ReservationId = 5, CustomerId = 5, RestaurantId = 5, TableId = 5,
                    ReservationDate = new DateTime(2024, 10, 30, 21, 0, 0), PartySize = 2
                }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    OrderId = 1, ReservationId = 1, EmployeeId = 1, OrderDate = new DateTime(2024, 10, 30, 19, 5, 0),
                    TotalAmount = 30.00m
                },
                new Order
                {
                    OrderId = 2, ReservationId = 2, EmployeeId = 3, OrderDate = new DateTime(2024, 10, 30, 20, 5, 0),
                    TotalAmount = 45.00m
                },
                new Order
                {
                    OrderId = 3, ReservationId = 3, EmployeeId = 5, OrderDate = new DateTime(2024, 10, 30, 18, 35, 0),
                    TotalAmount = 25.00m
                },
                new Order
                {
                    OrderId = 4, ReservationId = 4, EmployeeId = 2, OrderDate = new DateTime(2024, 10, 30, 19, 35, 0),
                    TotalAmount = 50.00m
                },
                new Order
                {
                    OrderId = 5, ReservationId = 5, EmployeeId = 4, OrderDate = new DateTime(2024, 10, 30, 21, 5, 0),
                    TotalAmount = 20.00m
                }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ItemId = 1, Quantity = 2 },
                new OrderItem { OrderItemId = 2, OrderId = 1, ItemId = 2, Quantity = 1 },
                new OrderItem { OrderItemId = 3, OrderId = 2, ItemId = 3, Quantity = 1 },
                new OrderItem { OrderItemId = 4, OrderId = 2, ItemId = 4, Quantity = 2 },
                new OrderItem { OrderItemId = 5, OrderId = 2, ItemId = 4, Quantity = 2 });


            // Customer to Reservation relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Restaurant to Table relationship
            modelBuilder.Entity<Table>()
                .HasOne(t => t.Restaurant)
                .WithMany(r => r.Tables)
                .HasForeignKey(t => t.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Restaurant to Employee relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Restaurant)
                .WithMany(r => r.Employees)
                .HasForeignKey(e => e.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Restaurant to MenuItem relationship
            modelBuilder.Entity<MenuItem>()
                .HasOne(m => m.Restaurant)
                .WithMany(r => r.MenuItems)
                .HasForeignKey(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Reservation to Table relationship
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Table)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TableId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Order to Reservation relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Reservation)
                .WithMany(r => r.Orders)
                .HasForeignKey(o => o.ReservationId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Order to Employee relationship
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Employee)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // OrderItem to Order relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // OrderItem to MenuItem relationship
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.MenuItem)
                .WithMany(m => m.OrderItems)
                .HasForeignKey(oi => oi.ItemId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            // Define primary keys
            modelBuilder.Entity<MenuItem>()
                .HasKey(m => m.ItemId);

            modelBuilder.Entity<Table>()
                .HasKey(t => t.TableId);

            modelBuilder.Entity<Reservation>()
                .HasKey(r => r.ReservationId);

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.EmployeeId);

            modelBuilder.Entity<Order>()
                .HasKey(o => o.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.OrderItemId);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Restaurant>()
                .HasKey(r => r.RestaurantId);

            modelBuilder.Entity<MenuItem>()
                .Property(m => m.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            // Configure ReservationWithDetails view
            modelBuilder.Entity<ReservationWithDetails>()
                .HasNoKey()
                .ToView("View_ReservationWithDetails");

            // Configure EmployeeWithRestaurant view
            modelBuilder.Entity<EmployeeWithRestaurant>()
                .HasNoKey()
                .ToView("View_EmployeeWithRestaurant");
        }

        // DEV Note  
        // This configuration treats these entities as read-only because they map to database views, not actual tables.EF
        //  Core will prevent updates or inserts on these views, which is generally the intended behavior for reporting data
      
    }
}