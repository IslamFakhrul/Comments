using Comments.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments.Application.Handler
{
    public class SearchCommentsHandler : ISearchCommentsHandler
    {
        private readonly ILogger<SearchCommentsHandler> _logger;
        private readonly ICommentsService _commentsService;

        public SearchCommentsHandler(ICommentsService commentsService,
            ILogger<SearchCommentsHandler> logger)
        {
            _commentsService = commentsService;
            _logger = logger;
        }


        public async Task<IEnumerable<Domain.Comments>> Handle(string searchText)
        {
            var response = new List<Domain.Comments>();
            var comments = await _commentsService.GetComments();

            if (string.IsNullOrWhiteSpace(searchText))
                return response;

            searchText = searchText.Trim().ToLower();

            response = comments
                 .Where(x =>
                            x.Body.ToLower().Contains(searchText) ||
                            x.Email.ToLower().Contains(searchText) ||
                            x.Name.ToLower().Contains(searchText))
                 .ToList();

            return response;
        }
    }

}
