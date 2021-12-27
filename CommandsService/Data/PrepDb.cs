using CommandsService.Data.Abstract;
using CommandsService.Models;
using CommandsService.SyncDataServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace CommandsService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();
                var platforms = grpcClient.ReturnAllPlatforms();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepository>(), platforms);
            }
        }

        private static void SeedData(ICommandRepository commandRepository, IEnumerable<Platform> platforms)
        {
            Console.WriteLine("--> Seeding new platforms");

            foreach (var platform in platforms)
            {
                if (!commandRepository.ExternalPlatformExists(platform.ExternalId))
                {
                    commandRepository.CreatePlatform(platform);
                }
                commandRepository.SaveChanges();
            }
        }
    }
}
