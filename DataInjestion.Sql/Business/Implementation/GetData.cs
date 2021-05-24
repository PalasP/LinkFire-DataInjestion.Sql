using DataInjestion.Sql.Models;
using DataInjestion.Sql.OutputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataInjestion.Sql.OutputModel;
using DataInjestion.Sql.Business.Contract;
using Microsoft.Extensions.Options;

namespace DataInjestion.Sql.Business.Implementation
{
    public class GetData : IGetData
    {
        private readonly LinkFireDBContext _context;
        public readonly IOptions<UrlConfiguration> _config;

        public GetData(LinkFireDBContext context, IOptions<UrlConfiguration> config)
        {
            _context = context;
            _config = config;
        }

        public async Task GetCollection()
        {
            //int total = endRange - startRange;

            List<ElasticModel> elasticModelsList = new List<ElasticModel>();
            PostData postData = new PostData(_config);



            var tempList = (from a in _context.Collections
                            join b in _context.Artistcollections
                           on a.CollectionId equals b.CollectionId into gj
                            from artistCollection in gj.DefaultIfEmpty()
                                //where a.CollectionId >= startRange && a.CollectionId <= endRange
                            select new
                            {
                                a.CollectionId,
                                a.Name,
                                a.ViewUrl,
                                a.OriginalReleaseDate,
                                a.IsCompilation,
                                a.LabelStudio,
                                a.ArtworkUrl,
                                artistCollection.ArtistId
                            }).Distinct().ToList();

            var abc = (from a in tempList
                       join b in _context.Artists
                       on a.ArtistId equals b.ArtistId into gj
                       from artist in gj.DefaultIfEmpty()
                       join c in _context.Collectionmatches
                       on a.CollectionId equals c.CollectionId into ab
                       from collectionMatch in ab.DefaultIfEmpty()
                       select new
                       {
                           a.CollectionId,
                           a.Name,
                           a.ViewUrl,
                           a.OriginalReleaseDate,
                           a.IsCompilation,
                           a.LabelStudio,
                           a.ArtworkUrl,
                           artistId = (artist == null) ? null : artist.ArtistId,
                           artistName = (artist == null) ? null : artist.Name,
                           collectionMatch.Upc
                       }).Distinct().ToList().OrderBy(x => x.CollectionId).ToList();

            var multipleArtist = abc.GroupBy(x => x.CollectionId)/*.Where(a => a.Count() > 1)*/.ToList();
            //var multipleArtist = abc.GroupBy(x => x.CollectionId).Where(a => a.Count() > 1).ToList();
            var i = abc.First();
            foreach (var item in multipleArtist)
            {
                i = item.First();
                ElasticModel elasticModel = new ElasticModel();
                elasticModel.artists = new List<ElasticArtistModel>();

                elasticModel.id = i.CollectionId;
                elasticModel.name = i.Name;
                elasticModel.url = i.ViewUrl;
                elasticModel.upc = i.Upc;
                elasticModel.releaseDate = i.OriginalReleaseDate;
                elasticModel.isCompilation = i.IsCompilation;
                elasticModel.label = i.LabelStudio;
                elasticModel.imageUrl = i.ArtworkUrl;

                foreach (var keyValue in item)
                {
                    if (keyValue.artistId != null)
                    {
                        elasticModel.artists.Add(new ElasticArtistModel { id = keyValue.artistId, name = keyValue.artistName });
                    }
                }
                elasticModelsList.Add(elasticModel);
            }

            await postData.PostDataToElasticSearch(elasticModelsList);
        }
    }
}
