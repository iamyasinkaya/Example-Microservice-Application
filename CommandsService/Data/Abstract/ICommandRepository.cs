using CommandsService.Models;
using System.Collections.Generic;

namespace CommandsService.Data.Abstract
{
    public interface ICommandRepository
    {
        bool SaveChanges();

        // Plaforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePlatform(Platform platform);
        bool PlatformExist(int platformId);
        bool ExternalPlatformExists(int externalPlatformId);

        // Commands
        IEnumerable<Command> GetAllCommandsForPlatform(int platformId);
        Command GetCommand(int platformId, int commandId);
        void CreateCommand(int platformId, Command command);

    }
}
