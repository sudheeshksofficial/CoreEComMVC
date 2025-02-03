using CoreEComMVC.Data;
using CoreEComMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEComMVC.Services
{
    public class StockService : IStockService
    {
        private readonly EcommerceDbContext _context;

        public StockService(EcommerceDbContext stockService)
        {
            _context = stockService;
        }
        public async Task<ItemModel> AddStocking(ItemModel item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<IEnumerable<ItemModel>> GetStockAsync()
        {
            try
            {
                var item = await _context.Items.ToListAsync();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
