using Newtonsoft.Json;

namespace Lykke.Snow.Audit.Abstractions
{
    /// <summary>
    /// Interface to be implemented by the object that is auditable
    /// </summary>
    /// <typeparam name="T">The type of the audit data</typeparam>
    public interface IAuditableObject<out T>
    {
        /// <summary>
        /// The domain specific audit data type, usually enum
        /// </summary>
        /// <returns></returns>
        T GetAuditDataType();

        /// <summary>
        /// The unique identifier of the object
        /// </summary>
        /// <returns></returns>
        string GetAuditReference();

        /// <summary>
        /// The JSON representation of the object for audit purposes.
        /// The default implementation returns the JSON representation of the object.
        /// </summary>
        /// <returns>JSON text</returns>
        string ToAuditJson() => JsonConvert.SerializeObject(this,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Include });
    }
}