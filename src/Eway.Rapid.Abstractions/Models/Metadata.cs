using System.Collections.Generic;

namespace Eway.Rapid.Abstractions.Models
{
    /// <summary>
    /// Arbitrary key value data saved with an object for later retrieval
    /// </summary>
#pragma warning disable S3925 // "ISerializable" should be implemented correctly
    public class Metadata : Dictionary<string, string>
#pragma warning restore S3925 // "ISerializable" should be implemented correctly
    {

    }
}
