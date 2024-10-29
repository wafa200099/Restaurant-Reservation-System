using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories;

public class CustomerRepository
{
    private readonly RestaurantReservationDbContext _context;

    public CustomerRepository(RestaurantReservationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> ListAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int customerId)
    {
        // Load the customer along with their reservations
        var customer = await _context.Customers
            .Include(c => c.Reservations) // Include related Reservations
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (customer != null)
        {
            // Delete related Reservations first
            foreach (var reservation in customer.Reservations.ToList())
            {
                _context.Reservations.Remove(reservation);
            }

            // Now delete the Customer
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
    
}
