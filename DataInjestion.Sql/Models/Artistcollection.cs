using System;
using System.Collections.Generic;

#nullable disable

namespace DataInjestion.Sql.Models
{
    public partial class Artistcollection
    {
        public long? ExportDate { get; set; }
        public long? ArtistId { get; set; }
        public long CollectionId { get; set; }
        public bool? IsPrimaryArtist { get; set; }
        public int RoleId { get; set; }
    }
}
