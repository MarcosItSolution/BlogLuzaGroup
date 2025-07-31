using Blog.Internal.Domains.Core.Abstractions;
using Blog.Internal.Domains.Core.Entities.Posts;

namespace Blog.Internal.Domains.Core.Entities.Users
{
    public class User : BaseEntity
    {
        protected User() { }

        public User(string username, string password)
        {
            Create(username, password);
        }

        public int Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;

        public ICollection<Post>? Posts { get; private set; }

        private void Create(string username, string password)
        {
            // Todo: Implementar validações

            Username = username;
            Password = password;
        }
    }
}

