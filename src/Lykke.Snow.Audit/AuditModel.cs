using System;
using Lykke.Snow.Audit.Abstractions;

namespace Lykke.Snow.Audit
{
    public class AuditModel<T> : IAuditModel<T>
    {
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        public string CorrelationId { get; set; }

        public string UserName { get; set; }

        public AuditEventType Type { get; set; }

        public T DataType { get; set; }

        public string DataReference { get; set; }

        public string DataDiff { get; set; }
    }
}