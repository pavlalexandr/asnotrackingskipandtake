using System.ComponentModel.DataAnnotations;

namespace DotNetEfCoreDemo.Domain.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
