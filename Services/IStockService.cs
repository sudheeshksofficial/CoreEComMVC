using CoreEComMVC.Models;

namespace CoreEComMVC.Services
{
    public interface IStockService
    {
        public Task<IEnumerable<ItemModel>> GetStockAsync();

        public Task<ItemModel>  AddStocking(ItemModel item);
    }
}
