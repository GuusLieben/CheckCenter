using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain.Archive
{
    public class ArchivedActionLog
    {
        [Key] public int StoredId { get; set; }

        [Required] public int Id { get; set; }

        [Required] public string UserEmail { get; set; }

        [Required] public DateTime Created { get; set; }

        [Required] public int EventId { get; set; }

        [AllowNull]
        public int OldStateId { get; set; }

        [AllowNull]
        public int NewStateId { get; set; }
    }
}
