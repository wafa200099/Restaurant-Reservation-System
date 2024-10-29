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
        var customer = await _context.Customers.FindAsync(customerId);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}
