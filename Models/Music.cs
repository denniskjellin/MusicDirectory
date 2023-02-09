using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

/*
Defining two classes representing my two tables, one for Artist and one for Album.
*/

namespace MusicDirectory.Models
{

    public class Artist
    {
        [Key] /* Attribute for showing that this is a primary key */
        public int ArtistId { get; set; }

        [Required]
        public string? Name { get; set; }
    }

    public class Album
    {
        [Key] /* Attribute for showing that this is a primary key */
        public int AlbumId { get; set; }

        [Required]
        public string? Title { get; set; }

        [ForeignKey("Artist")] /* Attribute for showing that this is a foreign-key */
        public int ArtistId { get; set; }

        public Artist? Artist { get; set; }
    }

    /* Adding rental functionality */

    public class Renting /* Class for withholding rent info */
{
    [Key]
    public int RentalId { get; set; } /* primary key*/

    [Required]
    public string? Name { get; set; }

    [ForeignKey("Album")] /* fk taken from album*/
    public int AlbumId { get; set; }

    public Album? Album { get; set; }

    [Required]
    public DateTime DateOfRent { get; set; } /*The date of the loan of album*/
}

}