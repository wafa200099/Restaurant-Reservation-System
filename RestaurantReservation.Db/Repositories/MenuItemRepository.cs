using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Db.Repositories
{
    public class MenuItemRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public MenuItemRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Add(menuItem);
            _context.SaveChanges();
        }

        // Update
        public void UpdateMenuItem(MenuItem menuItem)
        {
            _context.MenuItems.Update(menuItem);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteMenuItem(int menuItemId)
        {
            var menuItem = _context.MenuItems.Find(menuItemId);
            if (menuItem != null)
            {
                _context.MenuItems.Remove(menuItem);
                _context.SaveChanges();
            }
        }

        // List Menu Items by Restaurant
        public List<MenuItem> GetMenuItemsByRestaurant(int restaurantId)
        {
            return _context.MenuItems.Where(m => m.RestaurantId == restaurantId).ToList();
        }
    }
}