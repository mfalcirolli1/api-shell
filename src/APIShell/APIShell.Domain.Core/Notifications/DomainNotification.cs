using MediatR;

namespace APIShell.Domain.Core.Notifications
{
    public class DomainNotification : INotification
    {
        public DomainNotification(string key, string value, string group = null, string result = null)
        {
            Group = group;
            Key = key;
            Value = value;
            Result = result;
        }

        public string Group { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }
    }
}
