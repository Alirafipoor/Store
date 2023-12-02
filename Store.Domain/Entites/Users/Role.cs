using Store.Domain.Entites.Commons;

namespace Store.Domain.Entites.Users
{
    public class Role:BaseEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
