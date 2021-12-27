using CommandsService.Models;
using System.Collections.Generic;

namespace CommandsService.SyncDataServices
{
    public interface IPlatformDataClient
    {
        IEnumerable<Platform> ReturnAllPlatforms();
    }
}
