using NLayer_Backend_Core.Entities;

namespace NLayer_BackendEntities.Dtos
{
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
