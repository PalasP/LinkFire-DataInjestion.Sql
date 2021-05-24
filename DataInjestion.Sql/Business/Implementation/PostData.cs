using DataInjestion.Sql.Business.Contract;
using DataInjestion.Sql.OutputModel;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataInjestion.Sql.Business.Implementation
{
    public class PostData : IPostData
    {
        private readonly IOptions<UrlConfiguration> _config;

        public PostData(IOptions<UrlConfiguration> config)
        {
            _config = config;
        }

        public async Task PostDataToElasticSearch(List<ElasticModel> elasticModelsList)
        {
            using (var client = new HttpClient())
            {
                var serRequest = JsonConvert.SerializeObject(elasticModelsList);
                string requestUrl = _config.Value.elasticSearchUrl;//"https://localhost:44357/api/PostElasticsearchData";
                HttpRequestMessage requestMsg = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                requestMsg.Content = new StringContent(serRequest, Encoding.UTF8, "application/json");
                var result = await client.SendAsync(requestMsg);

            }            
        }
    }
}
