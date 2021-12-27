using PlatformService.Models;
using System.Collections;
using System.Collections.Generic;

namespace PlatformService.Data.Abstract
{
    public interface IPlatformRepository
    {
        bool SaveChanges();

        IEnumerable<Platform> GetAllPlatforms();
        Platform GetPlatformById(int id);
        void Create(Platform platform);
        void Update(Platform platform);
        void Delete(Platform platform);
    }
}
