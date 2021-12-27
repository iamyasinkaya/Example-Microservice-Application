using CommandsService.Data.Abstract;
using CommandsService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommandsService.Data.Concrete
{
    public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommandRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));

                
            }

            command.PlatformId = platformId;
            _appDbContext.Commands.Add(command);
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            };
            _appDbContext.Platforms.Add(platform);
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _appDbContext.Platforms.Any(p => p.ExternalId == externalPlatformId);
        }

        public IEnumerable<Command> GetAllCommandsForPlatform(int platformId)
        {
            return _appDbContext.Commands
                .Where(c => c.PlatformId == platformId)
                .OrderBy(c => c.Platform.Name);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _appDbContext.Platforms
                 .ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _appDbContext.Commands
                .Where(c => c.PlatformId == platformId && c.Id == commandId)
                .FirstOrDefault();
        }

        public bool PlatformExist(int platformId)
        {
            return _appDbContext.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_appDbContext.SaveChanges() >= 0);
        }
    }
}
