using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Comment
    {
        // Properties
        [Key]
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Date and time of creation is required")]
        public DateTime Created { get; set; } = DateTime.Now;

        [NotNull, Required(ErrorMessage = "User email is required"), MaxLength(255)]
        public string UserEmail { get; set; }

        [NotNull, Required(ErrorMessage = "Comment content is required")]
        public string Content { get; set; }


        // Relations
        public Event Event { get; set; }


        // Empty return function to prevent NullPointers
        public static Comment Empty() {
            return new Comment() {
                Id = -1,
                Created = DateTime.Now,
                UserEmail = "",
                Content = ""
            };
        }

        public static Comment Mock()
        {
            return new Comment()
            {
                Created = DateTime.Now,
                UserEmail = "",
                Content = ""
            };
        }

    }
}
