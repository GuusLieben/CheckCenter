using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class User
    {
        // Properties
        [Key, Required(ErrorMessage = "Email is required"), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", 
             ErrorMessage = "Email is incorrect")] 
        public string UserEmail { get; set; }

        [NotNull, Required(ErrorMessage = "First name is required")] 
        public string FirstName { get; set; }

        [NotNull, Required(ErrorMessage = "Last name is required")] 
        public string LastName { get; set; }

        [NotNull, Required(ErrorMessage = "Password is required")] 
        public string Password { get; set; }


        // Empty return function to prevent NullPointers
        public static User Empty() {
            return new User() {
                UserEmail = "",
                FirstName = "",
                LastName = "",
                Password = ""
            };
        }

    }
}