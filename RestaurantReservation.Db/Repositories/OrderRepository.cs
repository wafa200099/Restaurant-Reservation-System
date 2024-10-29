using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // Update
        public void UpdateOrder(Order order)
        {
            _context.Orders.Update(order);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.Find(orderId);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        // List Orders and Menu Items
        public void ListOrdersAndMenuItems(int reservationId)
        {
            var orders = _context.Orders.Where(o => o.ReservationId == reservationId).ToList();
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Total Amount: {order.TotalAmount}");
                var orderItems = _context.OrderItems.Where(oi => oi.OrderId == order.OrderId).ToList();
                foreach (var orderItem in orderItems)
                {
                    var menuItem = _context.MenuItems.Find(orderItem.ItemId);
                    Console.WriteLine($"Menu Item: {menuItem.Name}, Quantity: {orderItem.Quantity}");
                }
            }
        }

        // List Ordered Menu Items
        public List<MenuItem> ListOrderedMenuItems(int reservationId)
        {
            var orders = _context.Orders.Where(o => o.ReservationId == reservationId).ToList();
            var orderedMenuItems = new List<MenuItem>();
            foreach (var order in orders)
            {
                var orderItems = _context.OrderItems.Where(oi => oi.OrderId == order.OrderId).ToList();
                foreach (var orderItem in orderItems)
                {
                    var menuItem = _context.MenuItems.Find(orderItem.ItemId);
                    orderedMenuItems.Add(menuItem);
                }
            }

            return orderedMenuItems;
        }

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
        {
            // Get all orders associated with the specified employee
            var orders = await _context.Orders
                .Where(o => o.EmployeeId == employeeId) 
                .ToListAsync();

            if (orders.Count == 0)
            {
                return 0; 
            }

            decimal averageOrderAmount =
                orders.Average(o => o.TotalAmount); 
            return averageOrderAmount;
        }
    }
}