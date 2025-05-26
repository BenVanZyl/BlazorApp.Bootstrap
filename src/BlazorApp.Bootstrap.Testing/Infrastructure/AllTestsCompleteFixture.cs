
using BlazorApp.Bootstrap.Testing.Infrastructure.Database;

namespace BlazorApp.Bootstrap.Testing.Infrastructure
{
    public class AllTestsCompleteFixture : IDisposable
    {
        public void Dispose()
        {
            // Your cleanup code goes here
            DbManager.Cleanup();
        }
    }

    [CollectionDefinition("All Tests Complete")]
    public class AllTestsCompleteCollection : ICollectionFixture<AllTestsCompleteFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
