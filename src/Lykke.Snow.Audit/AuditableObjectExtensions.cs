using System;
using JsonDiffPatchDotNet;
using Lykke.Snow.Audit.Abstractions;

namespace Lykke.Snow.Audit
{
    public static class AuditableObjectExtensions
    {
        private const string EmptyJson = "{}";

        public static IAuditModel<T> GetAuditModelForInsertion<T>(this IAuditableObject<T> source, string correlationId, string userName)
        {
            (string current, string original) json = (source.ToAuditJson(), EmptyJson);

            var diffResult = new JsonDiffPatch().Diff(json.original, json.current);
            
            if (string.IsNullOrEmpty(diffResult))
                return null;

            return new AuditModel<T>
            {
                Timestamp = DateTime.UtcNow,
                CorrelationId = correlationId,
                UserName = userName,
                Type = AuditEventType.Creation,
                DataType = source.GetAuditDataType(),
                DataReference = source.GetAuditReference(),
                DataDiff = diffResult
            };
        }
        
        public static IAuditModel<T> GetAuditModelForDeletion<T>(this IAuditableObject<T> source, string correlationId, string userName)
        {
            (string current, string original) json = (EmptyJson, source.ToAuditJson());
            
            var diffResult = new JsonDiffPatch().Diff(json.original, json.current);
            
            if (string.IsNullOrEmpty(diffResult))
                return null;

            return new AuditModel<T>
            {
                Timestamp = DateTime.UtcNow,
                CorrelationId = correlationId,
                UserName = userName,
                Type = AuditEventType.Deletion,
                DataType = source.GetAuditDataType(),
                DataReference = source.GetAuditReference(),
                DataDiff = diffResult
            };
        }
        
        public static IAuditModel<T> GetAuditModelForEdition<T>(this IAuditableObject<T> source, IAuditableObject<T> before, string correlationId, string userName)
        {
            (string current, string original) json = (source.ToAuditJson(), before.ToAuditJson());
            
            var diffResult = new JsonDiffPatch().Diff(json.original, json.current);
            
            if (string.IsNullOrEmpty(diffResult))
                return null;
            
            return new AuditModel<T>
            {
                Timestamp = DateTime.UtcNow,
                CorrelationId = correlationId,
                UserName = userName,
                Type = AuditEventType.Edition,
                DataType = source.GetAuditDataType(),
                DataReference = source.GetAuditReference(),
                DataDiff = diffResult
            };
        }
    }
}