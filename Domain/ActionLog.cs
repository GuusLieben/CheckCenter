using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class ActionLog
    {
        // Properties
        [Key] 
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "User email is required"), MaxLength(50),
         RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email is incorrect")]
        public string UserEmail { get; set; }

        [NotNull, Required(ErrorMessage = "Date and time of creation is required")]
        public DateTime Created { get; set; } = DateTime.Now;


        //Relations
        public Event Event { get; set; }

        [AllowNull]
        public State OldState { get; set; }

        [NotNull, Required(ErrorMessage = "New state is required")]
        public State NewState { get; set; }


        // Empty return function to prevent NullPointers
        public static ActionLog Empty() {
            return new ActionLog() {
                Id = -1,
                UserEmail = "",
                Created = DateTime.Now
            };
        }

        public static ActionLog Mock(Event @event, State newState) {
            return new ActionLog() {
                Created = DateTime.Now,
                UserEmail = "Test Actionlog",
                Event = @event,
                NewState = newState
            };
        }
    }
}
