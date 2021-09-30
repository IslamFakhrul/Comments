using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comments.Application.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<Domain.Comments>> GetComments();
    }
}
