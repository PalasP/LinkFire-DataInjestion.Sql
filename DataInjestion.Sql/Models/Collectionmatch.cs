using System;
using System.Collections.Generic;

#nullable disable

namespace DataInjestion.Sql.Models
{
    public partial class Collectionmatch
    {
        public long? ExportDate { get; set; }
        public long CollectionId { get; set; }
        public string Upc { get; set; }
        public string Grid { get; set; }
        public string AmgAlbumId { get; set; }
    }
}
