using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCoreFirstApp.Models
{
    public class MovieModel
    {
         [DisplayName("Id number")]
        public int Id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Cost to customer")]
        public decimal Price { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Movie Time")]
        public DateTime ShowTime { get; set; }

        public MovieModel(int id, string name, decimal price, DateTime showTime)
        {
            Id = id;
            Name = name;
            Price = price;
            ShowTime = showTime;
        }
        public MovieModel()
        {

        }
    }
}
