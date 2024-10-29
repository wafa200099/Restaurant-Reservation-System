using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Db.Repositories
{
    public class RestaurantRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public RestaurantRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
        }

        // Update
        public void UpdateRestaurant(Restaurant restaurant)
        {
            _context.Restaurants.Update(restaurant);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteRestaurant(int restaurantId)
        {
            var restaurant = _context.Restaurants.Find(restaurantId);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
                _context.SaveChanges();
            }
        }

        // List all restaurants
        public List<Restaurant> GetAllRestaurants()
        {
            return _context.Restaurants.ToList();
        }
    }
}