using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Feedback
    {
        // Properties
        [Key]
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Date and time of creation is required")]
        public DateTime Created { get; set; } = DateTime.Now;

        [NotNull, MaxLength(50), Required(ErrorMessage = "User email is required")]
        public string UserEmail { get; set; }

        [NotNull, Required(ErrorMessage = "Feedback content is required")]
        public string Content { get; set; }


        // Relations
        public Event Event { get; set; }


        // Empty return function to prevent NullPointers
        public static Feedback Empty() {
            return new Feedback() {
                Id = -1,
                Created = DateTime.Now,
                UserEmail = "",
                Content = ""
            };
        }

        public static Feedback Mock()
        {
            return new Feedback()
            {
                Created = DateTime.Now,
                UserEmail = "",
                Content = ""
            };
        }

    }
}
