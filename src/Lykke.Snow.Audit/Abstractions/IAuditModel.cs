using System;

namespace Lykke.Snow.Audit.Abstractions
{
    /// <summary>
    /// An audit log entry interface.
    /// </summary>
    /// <typeparam name="T">The type of the audit data</typeparam>
    public interface IAuditModel<T>
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