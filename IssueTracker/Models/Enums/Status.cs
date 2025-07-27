using System.ComponentModel;

namespace IssueTracker.Models.Enums
{
    [TypeConverter(typeof(EnumStatusTypeConverter))]
    public enum Status
    {
        [Description("To Do")]
        ToDo,

        [Description("In Progress")]
        InProgress,

        [Description("On Hold")]
        OnHold,

        [Description("Done")]
        Done,

        [Description("Cancelled")]
        Cancelled,

        [Description("Reassigned")]
        Reassigned,

        [Description("Planned")]
        Planned,

        [Description("Waiting for Client")]
        WaitingForClient,

        [Description("Waiting on Internal Team")]
        WaitingOnInternalTeam
    }
}
