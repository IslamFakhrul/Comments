using Comments.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Comments.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ISearchCommentsHandler _searchCommentsHandler;

        public CommentsController(ISearchCommentsHandler searchCommentsHandler)
        {
            _searchCommentsHandler = searchCommentsHandler;
        }

        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SearchAsync(string searchText)
        {
            return Ok(await _searchCommentsHandler.Handle(searchText));
        }
    }
}
