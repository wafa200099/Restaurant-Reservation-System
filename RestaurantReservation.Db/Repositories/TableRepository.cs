using System.Collections.Generic;
using System.Linq;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateTable(Table table)
        {
            _context.Tables.Add(table);
            _context.SaveChanges();
        }

        // Update
        public void UpdateTable(Table table)
        {
            _context.Tables.Update(table);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteTable(int tableId)
        {
            var table = _context.Tables.Find(tableId);
            if (table != null)
            {
                _context.Tables.Remove(table);
                _context.SaveChanges();
            }
        }

        // List Tables by Restaurant
        public List<Table> GetTablesByRestaurant(int restaurantId)
        {
            return _context.Tables.Where(t => t.RestaurantId == restaurantId).ToList();
        }
    }
}