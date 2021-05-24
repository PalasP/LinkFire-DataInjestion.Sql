using System;
using System.Collections.Generic;

#nullable disable

namespace DataInjestion.Sql.Models
{
    public partial class Artist
    {
        public long? ExportDate { get; set; }
        public long? ArtistId { get; set; }
        public string Name { get; set; }
        public bool? IsActualArtist { get; set; }
        public string ViewUrl { get; set; }
        public int? ArtistTypeId { get; set; }
    }
}
