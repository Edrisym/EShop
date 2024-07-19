using BuildingBlocks.Core.Interfaces;

namespace BuildingBlocks.Core.Providers;
public class DefaultGuidProvider : IGuidProvider
{
    public Guid CreateGuid()
    {
        return Guid.NewGuid();
    }
}
