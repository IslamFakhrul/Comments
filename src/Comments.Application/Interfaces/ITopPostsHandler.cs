using Comments.Application.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comments.Application.Interfaces
{
    public interface ITopPostsHandler
    {
        Task<IEnumerable<CommentsRequestResponse>> Handle(int top);
    }
}
