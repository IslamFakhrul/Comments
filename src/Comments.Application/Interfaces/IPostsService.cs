using Comments.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comments.Application.Interfaces
{
    public interface IPostsService
    {
        Task<IEnumerable<Posts>> GetPosts();
    }
}
