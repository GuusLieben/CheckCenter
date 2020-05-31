using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Domain
{
    public class Source
    {
        // Properties
        [Key] 
        public int Id { get; set; }

        [NotNull, Required(ErrorMessage = "Display name is required"), MaxLength(50)]
        public string DisplayName { get; set; }

        [NotNull, Required(ErrorMessage = "Source severity is required")]
        public int SourceSeverity { get; set; }

        [AllowNull, MaxLength(1000)] 
        public string ConnectionString { get; set; }

        [NotNull, Required(ErrorMessage = "Please declare if the events from the source should be displayed")]
        public bool Active { get; set; } = true;

        [NotNull] 
        public int Order { get; set; } = 0;

        [NotNull, Required(ErrorMessage = "Please declare if a log action on completion is mandatory")]
        public bool LogActionMandatory { get; set; } = false;

        [AllowNull]
        public int ComebackDelay { get; set; } = 24;

        [NotNull] 
        public int CheckCenterServiceId { get; set; }

        [NotNull, Required(ErrorMessage = "Please declare if the events from this source should be stacked/grouped together")]
        public bool IsStacked { get; set; }

        [AllowNull]
        public string Color { get; set; }

        [AllowNull]
        public bool IsCustomerSource { get; set; }


        // Relations
        [NotNull, Required(ErrorMessage = "The check type is missing")]
        public CheckType CheckType { get; set; }

        [NotNull, Required(ErrorMessage = "The current state of the source is missing")]
        public IEnumerable<State> States { get; set; } = new List<State>();


        // Empty return function to prevent NullPointers
        public static Source Empty() {
            return new Source() {
                Id = -1,
                DisplayName = "",
                States = new List<State>(),
                SourceSeverity = 0,
                ConnectionString = "",
                Active = false,
                CheckCenterServiceId = 0,
                CheckType = CheckType.Empty(),
                Color = "",
                ComebackDelay = 0
            };
        }

        public static Source Mock(CheckType checkType, State state)
        {
            var states = new List<State>();
            states.Add(state);

            return new Source()
            {
                DisplayName = "Source Test",
                States = states,
                SourceSeverity = 0,
                ConnectionString = "",
                Active = false,
                CheckCenterServiceId = 0,
                CheckType = checkType,
                Color = "",
                ComebackDelay = 0
            };
        }

        public void SetDisplayName(string displayName) {
            this.DisplayName = displayName;
        }

    }
}
