using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Domain {
    public class Event : IGenericEvent {
        // Properties
        [Key] public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Date and time of creation is required")]
        public DateTime Added { get; set; } = DateTime.Now;

        [NotNull, Required(ErrorMessage = "Date and time of last update is required")]
        public DateTime Updated { get; set; }

        [NotNull, Required(ErrorMessage = "Title is required"), MaxLength(150)]
        public string Title { get; set; }

        [AllowNull, MaxLength(500)] public string Description { get; set; }

        [NotNull, Required(ErrorMessage = "Event severity is required")]
        public int EventSeverity { get; set; }

        [Index(IsUnique = true), NotNull, Required(ErrorMessage = "The unique event identifier is missing")]
        public string Shorthand { get; set; }

        // Relations
        [NotNull, Required(ErrorMessage = "The source is missing")]
        public Source Source { get; set; }

        [NotNull, Required(ErrorMessage = "The current state of the event is required")]
        public State State { get; set; }

        [NotNull, Required(ErrorMessage = "The check type is missing")]
        public CheckType CheckType { get; set; }

        [NotMapped] public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        [NotMapped] public IEnumerable<Feedback> Feedback { get; set; } = new List<Feedback>();

        [NotMapped] public IEnumerable<ActionLog> ActionLogs { get; set; } = new List<ActionLog>();

        [NotMapped] public IEnumerable<AdditionalInfo> AdditionalInfo { get; set; } = new List<AdditionalInfo>();

        // Empty return function to prevent NullPointers
        public static Event Empty() {
            return new Event() {
                Id = -1,
                Added = DateTime.Now,
                Title = "",
                Description = "",
                EventSeverity = 0,
                Shorthand = "",
                Source = Source.Empty(),
                State = State.Empty(),
                CheckType = CheckType.Empty()
            };
        }

        public static Event Mock(CheckType checkType, State state, Source source) {
            return new Event() {
                Added = DateTime.Now,
                Title = "Test Event",
                Description = "This is a test object",
                EventSeverity = 0,
                Shorthand = "This is a test ShortHand",
                Source = source,
                State = state,
                CheckType = checkType
            };
        }

        public void SetTitle(string title) {
            this.Title = title;
        }
    }
}
