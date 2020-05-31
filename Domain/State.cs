using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class State
    {
        // Properties
        [Key] 
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [NotNull] 
        public string Description { get; set; } = "";


        // Empty return function to prevent NullPointers
        public static State Empty() {
            return new State() {
                Id = -1,
                Title = "",
                Description = ""
            };
        }

        public static State Mock()
        {
            return new State()
            {
                Title = "State Test",
                Description = "Test object for test"
            };
        }

    }
}
