using System;
using System.Collections.Generic;

namespace Domain.Archive
{
    public class ReturnableEvent : IGenericEvent
    {
        // Properties
                public int Id { get; set; }

                public DateTime Added { get; set; } = DateTime.Now;

                public DateTime Updated { get; set; }

                public string Title { get; set; }

                public string Description { get; set; }
                
                public string Conclusion { get; set; }

                public int EventSeverity { get; set; } = 0;

                public string Shorthand { get; set; }
                
                public string Finished { get; set; }
                
                public string Removed { get; set; }


        // Relations
                public Source Source { get; set; }

                public State State { get; set; }

                public CheckType CheckType { get; set; }

                public IEnumerable<ArchivedComment> Comments { get; set; } = new List<ArchivedComment>();

                public IEnumerable<ArchivedFeedback> Feedback { get; set; } = new List<ArchivedFeedback>();

                public IEnumerable<ArchivedActionLog> ActionLogs { get; set; } = new List<ArchivedActionLog>();

                public IEnumerable<ArchivedInfo> AdditionalInfo { get; set; } = new List<ArchivedInfo>();


                public void SetTitle(string title)
                {
                    throw new NotImplementedException();
                }
    }
}
