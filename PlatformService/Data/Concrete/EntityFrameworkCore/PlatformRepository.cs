using PlatformService.Data.Abstract;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlatformService.Data.Concrete.EntityFrameworkCore
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _dbContext;

        public PlatformRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            _dbContext.Platforms.Add(platform);
        }

        public void Delete(Platform platform)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _dbContext.Platforms.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_dbContext.SaveChanges() >= 0);
        }

        public void Update(Platform platform)
        {
            throw new System.NotImplementedException();
        }
    }
}
