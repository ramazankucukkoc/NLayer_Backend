using NLayer_Backend_Core.Entities;

namespace NLayer_BackendEntities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}
