using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace VendasMVC.Services
{
    public class SalesRecordService
    {
        //Dependencia para o _context do entityFramework
        private readonly VendasMVCContext _context;

        public SalesRecordService(VendasMVCContext context)
        {
            _context = context;
        }
        public async Task<List<SalesRecord>> FindByDateAsync( DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            //Join de tabelas e ordenar usando LINQ e Entity
            return await result
                .Include(x=>x.Seller)
                .Include(x=>x.Seller.Department)
                .OrderByDescending(x=>x.Date)
                .ToListAsync();
        }
        public async Task<List<IGrouping<Department,SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            //Join de tabelas e ordenar usando LINQ e Entity
            return await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .GroupBy(x=> x.Seller.Department)
                .ToListAsync();
        }
    }
}
