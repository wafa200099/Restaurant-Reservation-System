using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.Db.Repositories
{
    public class EmployeeRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public EmployeeRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        // Create
        public void CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        // Update
        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        // Delete
        public void DeleteEmployee(int employeeId)
        {
            var employee = _context.Employees.Find(employeeId);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        // List Managers method
        public List<Employee> ListManagers()
        {
            return _context.Employees.Where(e => e.Position == "Manager").ToList();
        }  
        
        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurantAsync()
        {
            return await _context.EmployeeWithRestaurant.ToListAsync();
        }
    }
}