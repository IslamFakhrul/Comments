using Comments.Application.Interfaces;
using Comments.Domain;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Comments.Application.Services
{
    public class PostsService : IPostsService
    {
        private readonly ApiSettings _apiSettings;
        private readonly ILogger<PostsService> _logger;

        public PostsService(ILogger<PostsService> logger, IOptions<ApiSettings> apiSettingsAccessor)
        {
            _logger = logger;
            _apiSettings = apiSettingsAccessor.Value;
        }

        public async Task<IEnumerable<Posts>> GetPosts()
        {
            var client = new RestClient();
            RestRequest request = new RestRequest(_apiSettings.PostApiUrl);
            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Posts>>(response.Content);
            }

            return new List<Posts>();
        }
    }
}
