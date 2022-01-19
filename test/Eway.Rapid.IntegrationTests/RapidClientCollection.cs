using Xunit;

namespace Eway.Rapid.IntegrationTests
{
    [CollectionDefinition("RapidClient collection")]
    public class RapidClientCollection : ICollectionFixture<RapidClientFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and the
        // ICollectionFixture<RapidClientFixture> interface.
    }
}
