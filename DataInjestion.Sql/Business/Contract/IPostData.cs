using DataInjestion.Sql.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataInjestion.Sql.Business.Contract
{
    interface IPostData
    {
        Task PostDataToElasticSearch(List<ElasticModel> elasticModelsList);
    }
}
