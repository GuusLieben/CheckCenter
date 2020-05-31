using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class AdditionalInfo
    {
        // Properties
        [Key] 
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Key is required")]
        public string Key { get; set; }

        [NotNull, Required(ErrorMessage = "Value is required")]
        public string Value { get; set; }


        //Relations
        public Event Event { get; set; }


        // Empty return function to prevent NullPointers
        public static AdditionalInfo Empty() {
            return new AdditionalInfo() {
                Id = -1,
                Key = "",
                Value = ""
            }; 
        }

        public static AdditionalInfo Mock()
        {
            return new AdditionalInfo()
            {
                Key = "",
                Value = ""
            };
        }
    }
}
