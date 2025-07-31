using Blog.Intenal.Domains.Core.Results;

namespace Blog.Internal.Domains.Core.Entities.Posts
{
    public static class PostErrors
	{
		public static Error InvalidFields => new (
			"Invalid Fields","Dados invalidos verique.");

        public static Error NotFound => new(
            "Post Notfound", "O post não foi encontrado");
    }
}

