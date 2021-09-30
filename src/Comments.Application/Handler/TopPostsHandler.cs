using Comments.Application.Interfaces;
using Comments.Application.Response;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comments.Application.Handler
{
    public class TopPostsHandler : ITopPostsHandler
    {
        private readonly ILogger<TopPostsHandler> _logger;
        private readonly IPostsService _postService;
        private readonly ICommentsService _commentsService;

        public TopPostsHandler(IPostsService postService,
            ICommentsService commentsService,
            ILogger<TopPostsHandler> logger)
        {
            _postService = postService;
            _commentsService = commentsService;
            _logger = logger;
        }


        public async Task<IEnumerable<CommentsRequestResponse>> Handle(int top)
        {
            var response = new List<CommentsRequestResponse>();

            var comments = await _commentsService.GetComments();
            var posts = await _postService.GetPosts();

            response.AddRange(from post in posts
                              let commentsRequestResponse = new CommentsRequestResponse
                              {
                                  PostId = post.Id,
                                  PostTitle = post.Title,
                                  PostBody = post.Body,
                                  TotalNumberOfComments = comments.Count(x => x.PostId == post.Id)
                              }
                              select commentsRequestResponse);

            return response
                .OrderByDescending(x => x.TotalNumberOfComments)
                .Take(top)
                .ToList();
        }
    }
}
