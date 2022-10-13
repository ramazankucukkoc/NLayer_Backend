using NLayer_Backend_Core.Entities;

namespace NLayer_BackendEntities.Dtos
{
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
