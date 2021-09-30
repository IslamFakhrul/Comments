using Comments.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Comments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ITopPostsHandler _topPostsHandler;

        public PostsController(ITopPostsHandler topPostsHandler)
        {
            _topPostsHandler = topPostsHandler;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAsync(int top)
        {
            return Ok(await _topPostsHandler.Handle(top));
        }
    }
}
