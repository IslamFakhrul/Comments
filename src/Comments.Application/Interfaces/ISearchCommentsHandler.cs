using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comments.Application.Interfaces
{
    public interface ISearchCommentsHandler
    {
        Task<IEnumerable<Domain.Comments>> Handle(string searchText);
    }
}
