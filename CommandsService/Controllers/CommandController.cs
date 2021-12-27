using AutoMapper;
using CommandsService.Data.Abstract;
using CommandsService.Dtos;
using CommandsService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CommandsService.Controllers
{
    [Route("api/c/platforms/{platformId}/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _mapper;

        public CommandController(ICommandRepository commandRepository, IMapper mapper)
        {
            _commandRepository = commandRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetCommandsForPlatform(int platformId, int commandId)
        {
            Console.WriteLine($"--> Hit GetCommandsForPlatform:{platformId}");

            if (!_commandRepository.PlatformExist(platformId))
            {
                return NotFound();
            }
            var command = _commandRepository.GetCommand(platformId, commandId);

            if (command == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommandForPlatform(int platformId, CommandCreateDto commandCreateDto)
        {
            Console.WriteLine($"--> Hit CreateCommandsForPlatform:{platformId}");

            if (!_commandRepository.PlatformExist(platformId))
            {
                return NotFound();
            }

            var command = _mapper.Map<Command>(commandCreateDto);

            _commandRepository.CreateCommand(platformId, command);
            _commandRepository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandsForPlatform),
                new { platformId = platformId, commandId = commandReadDto.Id, commandReadDto });
        }
    }
}
