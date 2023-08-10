using System;

namespace Lykke.Snow.Audit
{
    /// <summary>
    /// Audit filter data transfer object
    /// </summary>
    /// <typeparam name="T">The domain specific type of the audit data</typeparam>
    public class AuditTrailFilter<T>
    {
        public string CorrelationId { get; set; }
        public string UserName { get; set; }
        public AuditEventType? ActionType { get; set; }
        public string AuditEventTypeDetails { get; set; }
        public T[] DataTypes { get; set; }
        public string ReferenceId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
    }
}