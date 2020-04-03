using Microsoft.ReactNative.Managed;
using Microsoft.ReactNative;

namespace RNPDFvnext
{
    public sealed class ReactPackageProvider : IReactPackageProvider
    {
        public void CreatePackage(IReactPackageBuilder packageBuilder)
        {
            packageBuilder.AddViewManagers();
        }
    }
}
