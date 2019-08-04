using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Services
{
    public class DepartmentService
    {
        private readonly VendasMVCContext _context;

        public DepartmentService(VendasMVCContext context)
        {
            _context = context;
        }
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
