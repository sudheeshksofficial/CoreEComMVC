using CoreEComMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreEComMVC.Data
{
    public class EcommerceDbContext:DbContext
    {
        public EcommerceDbContext(DbContextOptions<EcommerceDbContext> options) : base(options) { }

        public DbSet<ItemModel> Items {  get; set; }
        public DbSet<CartModel> Cart { get; set; }
    }
}
