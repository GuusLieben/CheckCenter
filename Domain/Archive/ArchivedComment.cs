using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Archive
{
    public class ArchivedComment
    {
        [Key] public int StoredId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}
