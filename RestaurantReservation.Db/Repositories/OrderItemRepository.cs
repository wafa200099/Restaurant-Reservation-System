using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Db.Repositories
{
    public class OrderItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public OrderItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Add(orderItem);
            _context.SaveChanges();
        }

        // Update
        public void UpdateOrderItem(OrderItem orderItem)
        {
            _context.OrderItems.Update(orderItem);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteOrderItem(int orderItemId)
        {
            var orderItem = _context.OrderItems.Find(orderItemId);
            if (orderItem != null)
            {
                _context.OrderItems.Remove(orderItem);
                _context.SaveChanges();
            }
        }
    }
}