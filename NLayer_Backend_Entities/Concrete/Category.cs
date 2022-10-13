using NLayer_Backend_Core.Entities;

namespace NLayer_BackendEntities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
