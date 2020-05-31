using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Archive
{
    public class ArchivedEvent
    {

        [Key] public int StoredId { get; set; }

        // Properties
        [Required]
        public int Id { get; set; }

        
        
        [Required]
        public DateTime Added { get; set; } = DateTime.Now;

        [Required]
        public DateTime Updated { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }
        
        public string Conclusion { get; set; }

        [Required]
        public int EventSeverity { get; set; } = 0;

        [Required]
        public string Shorthand { get; set; }
        
        [Required]
        public int SourceId { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int CheckTypeId { get; set; }
        
        [AllowNull]
        public DateTime Removed { get; set; }
        
        [AllowNull]
        public DateTime Finished { get; set; }
    }
}
