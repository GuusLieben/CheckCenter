using System.ComponentModel.DataAnnotations;

namespace Domain.Archive
{
    public class ArchivedInfo
    {
        [Key] public int StoredId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Value { get; set; }


        //Relations
        [Required]
        public int EventId { get; set; }
    }
}
