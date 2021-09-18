using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Utils
{
    public static class UriProvider
    {
        public static class Post
        {
            public const string GET_LIST = "posts";
            public static string GetById(Guid id) => $"posts/{id}";
        }

        public static class Category
        {
            public const string GET_LIST = "categories";
            public static string GetById(Guid id) => $"categories/{id}";
            public static string GetPostsbyId(Guid id) => $"categories/{id}/posts";
        }
    }
}
