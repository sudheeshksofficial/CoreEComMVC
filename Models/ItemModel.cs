using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEComMVC.Models
{
    public class ItemModel
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string? Category { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Stock must be greater than zero")]
        public int Stock { get; set; }

        public string ImageUrl { get; set; } // Add this property

        public decimal Price { get; set; }

        //[DataType(DataType.Date)]

        public DateTime DateAdded { get; set; }


    }

}
