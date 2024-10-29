using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories
{
    public class ReservationRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public ReservationRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }

        // Update
        public void UpdateReservation(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteReservation(int reservationId)
        {
            var reservation = _context.Reservations.Find(reservationId);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                _context.SaveChanges();
            }
        }

        // Get Reservations By Customer
        public List<Reservation> GetReservationsByCustomer(int customerId)
        {
            return _context.Reservations.Where(r => r.CustomerId == customerId).ToList();
        } 
        
        public async Task<List<ReservationWithDetails>> GetReservationsWithDetailsAsync()
        {
            return await _context.ReservationWithDetails.ToListAsync();
        }
    }
}