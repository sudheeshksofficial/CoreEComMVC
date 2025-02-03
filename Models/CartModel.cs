using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEComMVC.Models
{
    public class CartModel
    {
        [Key]
        public int CartId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [Required(ErrorMessage = "add quantity befor purchase")]
        public int Quantity { get; set; }

        [ForeignKey("ItemModel")]
        public int ItemId { get; set; }

        public ItemModel ItemModel { get; set; }
    }
}
