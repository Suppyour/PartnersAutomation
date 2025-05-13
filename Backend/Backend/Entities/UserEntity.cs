// Сеё чудо требуется для того что бы в БД не было вообще никакой логики (repeat yourself получается)

namespace Backend.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
