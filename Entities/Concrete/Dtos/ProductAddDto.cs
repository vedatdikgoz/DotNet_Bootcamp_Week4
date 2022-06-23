using Core.Entities;

namespace Entities.Concrete.Dtos
{
    public class ProductAddDto:IDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Barcode { get; set; }
        public int CategoryId { get; set; }
    }
}
