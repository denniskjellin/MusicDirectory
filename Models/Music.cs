using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Defining two classes representing my two tables, one for Artist and one for Album.
*/

namespace MusicDirectory.Models
{

    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public string? Name { get; set; }
    }

    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required]
        public string? Title { get; set; }

        [ForeignKey("Artist")]
        public int ArtistId { get; set; }

        public Artist? Artist { get; set; }
    }


}