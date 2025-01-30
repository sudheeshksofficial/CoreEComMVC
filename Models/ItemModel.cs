using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreEComMVC.Models
{
    public class ItemModel
    {
        [Key]

        public int ItemId { get; set; }
        [Required]
        public string? Name { get; set; }
        
        public string? Category { get; set; }

        public int Stock { get; set; }

        public int DateAdded { get; set; }
        

    }
}
