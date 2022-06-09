using System.Threading.Tasks;

namespace Lykke.Snow.Audit.Abstractions
{
    /// <summary>
    /// An interface to be implemented and/or extended by auditor
    /// </summary>
    /// <typeparam name="T">The domain specific data type of the auditable object</typeparam>
    public partial interface IAuditService<T>
    {
        Task<bool> TryAudit(string correlationId,
            string userName,
            IAuditableObject<T> newState,
            IAuditableObject<T> oldState = null);
    }
}