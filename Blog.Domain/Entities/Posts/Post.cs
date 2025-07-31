using Blog.Internal.Domains.Core.Abstractions;
using Blog.Internal.Domains.Core.Entities.Users;

namespace Blog.Internal.Domains.Core.Entities.Posts
{
    public class Post : BaseEntity
    {
        protected Post() { }

        public Post(string title, string content, int userId)
        {
            Create(title, content, userId);
        }

        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public int UserId { get; private set; }

        public User? User { get; private set; }

        private void Create(string title, string content, int userId)
        {
            // Todo: Implementar validações e regras de negocio
            ChangeTile(title, userId);
            ChangeContent(content, userId);

            Create(UserId);
        }

        public void ChangeTile(string title, int userId)
        {
            // Todo: Implementar validações e regras de negocio

            Title = title;

            Update(userId);
        }

        public void ChangeContent(string content, int userId)
        {
            // Todo: Implementar validações e regras de negocio

            Content = content;

            Update(userId);
        }

        public void ChangeUser(int userId)
        {
            // Todo: Implementar validações e regras de negocio

            UserId = userId;
        }
    }
}