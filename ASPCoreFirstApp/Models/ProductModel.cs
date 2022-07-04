using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreFirstApp.Models
{
    public class ProductModel
    {
        [DisplayName("Id number")]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost to customer")]
        public decimal Price { get; set; }
        [DisplayName("What you get...")]
        public string Description { get; set; }

        public ProductModel(int id, string name, decimal price, string description)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }
        public ProductModel()
        {

        }
    }
}
