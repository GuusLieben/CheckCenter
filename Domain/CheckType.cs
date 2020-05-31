using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class CheckType
    {
        // Properties
        [Key] 
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [NotNull] 
        public string Description { get; set; } = "";


        // Empty return function to prevent NullPointers
        public static CheckType Empty() {
            return new CheckType() {
                Id = -1,
                Title = "",
                Description = ""
            };
        }

        public static CheckType Mock()
        {
            return new CheckType()
            {
                Title = "CheckType Test",
                Description = "Test object for CheckType"
            };
        }

    }
}