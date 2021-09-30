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
    public class CommentsService : ICommentsService
    {
        private readonly ApiSettings _apiSettings;
        private readonly ILogger<CommentsService> _logger;

        public CommentsService(ILogger<CommentsService> logger, IOptions<ApiSettings> apiSettingsAccessor)
        {
            _logger = logger;
            _apiSettings = apiSettingsAccessor.Value;
        }

        public async Task<IEnumerable<Domain.Comments>> GetComments()
        {
            var client = new RestClient();
            RestRequest request = new RestRequest(_apiSettings.CommentsApiUrl);
            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteAsync(request, cancellationTokenSource.Token);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IEnumerable<Domain.Comments>>(response.Content);
            }

            return new List<Domain.Comments>();
        }
    }
}
