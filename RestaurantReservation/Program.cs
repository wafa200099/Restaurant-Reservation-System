using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            using (var context = new RestaurantReservationDbContext())
            {
                // Initialize repositories
                var customerRepo = new CustomerRepository(context);
                var restaurantRepo = new RestaurantRepository(context);
                var employeeRepo = new EmployeeRepository(context);
                var reservationRepo = new ReservationRepository(context);
                var orderRepo = new OrderRepository(context);
                var menuItemRepo = new MenuItemRepository(context);
                var tableRepo = new TableRepository(context);
                var orderItemRepo = new OrderItemRepository(context);

                // Sample Data Creation  
                //Restaurant
                var restaurant = new Restaurant
                {
                    Name = "Pasta Palace", Address = "123 Noodle St", PhoneNumber = "111-222-3333",
                    OpeningHours = "10:00 AM - 10:00 PM"
                };
                restaurantRepo.CreateRestaurant(restaurant);
                Console.WriteLine("Restaurant created: " + restaurant.Name);
                //Customer
                var customer = new Customer
                {
                    FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PhoneNumber = "123-456-7890"
                };
                await customerRepo.AddAsync(customer);
                Console.WriteLine("Customer created: " + customer.FirstName + " " + customer.LastName);
                //Employee
                var employee = new Employee
                {
                    RestaurantId = restaurant.RestaurantId, FirstName = "Emily", LastName = "Clark",
                    Position = "Manager"
                };
                employeeRepo.CreateEmployee(employee);
                Console.WriteLine("Employee created: " + employee.FirstName + " " + employee.LastName);
                //Table
                var table = new Table { RestaurantId = restaurant.RestaurantId, Capacity = 4 };
                tableRepo.CreateTable(table);
                Console.WriteLine("Table created with Capacity: " + table.Capacity);
                //Reservation
                var reservation = new Reservation
                {
                    CustomerId = customer.CustomerId, RestaurantId = restaurant.RestaurantId, TableId = table.TableId,
                    ReservationDate = DateTime.Now.AddHours(2), PartySize = 4
                };
                reservationRepo.CreateReservation(reservation);
                Console.WriteLine("Reservation created for " + customer.FirstName + " at " + restaurant.Name);
                //MenuItem
                var menuItem = new MenuItem
                {
                    RestaurantId = restaurant.RestaurantId, Name = "Spaghetti",
                    Description = "Classic spaghetti with marinara sauce", Price = 12.99m
                };
                menuItemRepo.CreateMenuItem(menuItem);
                Console.WriteLine("Menu item created: " + menuItem.Name);

                // Demonstrate Update customer
                customer.LastName = "Smith";
                await customerRepo.UpdateAsync(customer);
                Console.WriteLine("Customer updated to: " + customer.FirstName + " " + customer.LastName);

                // Demonstrate Delete customer
                await customerRepo.DeleteAsync(customer.CustomerId);
                Console.WriteLine("Customer deleted.");

                // List Managers
                var managers = employeeRepo.ListManagers();
                Console.WriteLine("List of Managers:");
                foreach (var manager in managers)
                {
                    Console.WriteLine($"{manager.FirstName} {manager.LastName}");
                }

                // Get Reservations By Customer
                var reservations = reservationRepo.GetReservationsByCustomer(customer.CustomerId);
                Console.WriteLine($"Reservations for Customer {customer.CustomerId}:");
                foreach (var res in reservations)
                {
                    Console.WriteLine($"Reservation ID: {res.ReservationId}, Party Size: {res.PartySize}");
                }

                // List Orders and Menu Items
                Console.WriteLine($"Orders and Menu Items for Reservation {reservation.ReservationId}:");
                orderRepo.ListOrdersAndMenuItems(reservation.ReservationId);

                // List Ordered Menu Items
                var orderedMenuItems = orderRepo.ListOrderedMenuItems(reservation.ReservationId);
                Console.WriteLine("Ordered Menu Items:");
                foreach (var item in orderedMenuItems)
                {
                    Console.WriteLine(item.Name);
                }

                // Calculate Average Order Amount
                var averageOrderAmount = await orderRepo.CalculateAverageOrderAmountAsync(employee.EmployeeId);
                Console.WriteLine($"Average Order Amount for Employee {employee.EmployeeId}: {averageOrderAmount:C}");


                // View_ReservationWithDetails
                var reservationDetails = await reservationRepo.GetReservationsWithDetailsAsync();
                Console.WriteLine("Reservation Details:");

                foreach (var detail in reservationDetails)
                {
                    Console.WriteLine(
                        $"{detail.CustomerFirstName} {detail.CustomerLastName} - {detail.RestaurantName} on {detail.ReservationDate}");
                }
                //View_EmployeeWithRestaurant

                var employeeWithRestaurantDetails = await employeeRepo.GetEmployeesWithRestaurantAsync();
                Console.WriteLine("EmployeeWithRestaurantDetails:");

                foreach (var detail in employeeWithRestaurantDetails)
                {
                    Console.WriteLine(
                        $"{detail.FirstName} {detail.LastName} - {detail.RestaurantName} on {detail.RestaurantAddress}");
                }
            }
        }
    }
}