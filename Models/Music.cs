using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; /*Makes code easier to read/understand*/

namespace MusicDirectory.Models
{
    /* Artist table: Id + Name*/
    public class Artist
    {
        [Key] /* Attribute for showing that this is a primary key */
        public int ArtistId { get; set; }

        [Required]
        public string? Name { get; set; }
    }

    /* Album table:
    AlbumId - Primary Key
    Title - req
    ForeignKey - Artist(ArtistId)
     */
    public class Album
    {
        [Key] /* Attribute for showing that this is a primary key */
        public int AlbumId { get; set; }

        [Required]
        public string? Title { get; set; }

        [ForeignKey("Artist")] /* Attribute for showing that this is a foreign-key */
        public int ArtistId { get; set; }

        /* instance of Artist class */
        public Artist? Artist { get; set; }
    }

  /*
  Member table:
  MemberId - primary key
  Name - required
  PhoneNumber (Type phone) required
  Email (Type e-mail) required
  */
        public class Member
    {
        [Key]
        public int MemberId { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }

  /*
  Loan table:
  LoanId - primary key
  ForeignKey from class of Album (AlbumId)  
  ForeignKey from class of Member (MemberId)
  DateTime (Required) Date of loan
  DateTime - Date of return

  */
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        [ForeignKey("Album")]
        public int AlbumId { get; set; }

        public Album? Album { get; set; } /*Instance of Album*/

        [ForeignKey("Member")]
        public int MemberId { get; set; }

        public Member? Member { get; set; } /*Instance of Member*/

        [Required]
        public DateTime LoanDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}

