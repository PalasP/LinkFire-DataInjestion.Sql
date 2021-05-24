using System;
using System.Collections.Generic;

#nullable disable

namespace DataInjestion.Sql.Models
{
    public partial class Collection
    {
        public long? ExportDate { get; set; }
        public long CollectionId { get; set; }
        public string Name { get; set; }
        public string TitleVersion { get; set; }
        public string SearchTerms { get; set; }
        public int? ParentalAdvisoryId { get; set; }
        public string ArtistDisplayName { get; set; }
        public string ViewUrl { get; set; }
        public string ArtworkUrl { get; set; }
        public DateTime? OriginalReleaseDate { get; set; }
        public DateTime? ItunesReleaseDate { get; set; }
        public string LabelStudio { get; set; }
        public string ContentProviderName { get; set; }
        public string Copyright { get; set; }
        public string PLine { get; set; }
        public string MediaTypeId { get; set; }
        public string IsCompilation { get; set; }
        public string CollectionTypeId { get; set; }
    }
}
