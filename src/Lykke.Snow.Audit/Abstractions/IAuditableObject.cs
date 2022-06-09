namespace Lykke.Snow.Audit.Abstractions
{
    /// <summary>
    /// Interface to be implemented by the object that is auditable
    /// </summary>
    /// <typeparam name="T">The type of the audit data</typeparam>
    public interface IAuditableObject<out T>
    {
        T GetAuditDataType();

        string GetAuditReference();

        string ToAuditJson();
    }
}