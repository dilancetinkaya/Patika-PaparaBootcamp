using System.ComponentModel.DataAnnotations;

namespace Product.Data.Dtos
{
    public class ProductDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name cannot be blank.")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }

    }
}
