﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ICommandsLogic
    {
        IEnumerable<Command> GetAllCommands();
        IEnumerable<Command> GetCommandsById(int commandId);
        IEnumerable<Command> GetCommandsByAbilityType(int abilityType);
        IEnumerable<Command> GetCommandsByCharacter(int characterId);
        IEnumerable<Command> GetCommandBySchool(int schoolType);
        IEnumerable<Command> GetCommandByElement(int elementType);
        IEnumerable<Command> GetCommandsBySearch(Command searchPrototype);
    }

    public class CommandsLogic : ICommandsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<CommandsLogic> _logger;
        #endregion

        #region Constructors

        public CommandsLogic(IEnlirRepository enlirRepository, ILogger<CommandsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region ICommandsLogic Implementation

        public IEnumerable<Command> GetAllCommands()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllCommands)}");

            return _enlirRepository.GetMergeResultsContainer().Commands;
        }

        public IEnumerable<Command> GetCommandsById(int commandId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandsById)}");

            return _enlirRepository.GetMergeResultsContainer().Commands.Where(c => c.Id == commandId);
        }

        public IEnumerable<Command> GetCommandsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandsByAbilityType)}");

            return _enlirRepository.GetMergeResultsContainer().Commands.Where(c => c.AbilityType == abilityType);
        }

        public IEnumerable<Command> GetCommandsByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandsByCharacter)}");

            return _enlirRepository.GetMergeResultsContainer().Commands.Where(c => c.CharacterId == characterId);
        }

        public IEnumerable<Command> GetCommandBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandBySchool)}");

            return _enlirRepository.GetMergeResultsContainer().Commands.Where(c => c.School == schoolType);
        }

        public IEnumerable<Command> GetCommandByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetCommandByElement)}");

            return _enlirRepository.GetMergeResultsContainer().Commands.Where(c => c.Elements.Contains(elementType));
        }

        public IEnumerable<Command> GetCommandsBySearch(Command searchPrototype)
        {
            //ignore: CharacterName, Description, SourceSoulBreakName, ImagePath, EnlirId, Id, ImagePath, IsChecked, IsCounterable, JapaneseName, SoulBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().Commands;

            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(c => c.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.AbilityType != 0)
            {
                query = query.Where(c => c.AbilityType == searchPrototype.AbilityType);
            }
            if (searchPrototype.School != 0)
            {
                query = query.Where(c => c.School == searchPrototype.School);
            }
            if (searchPrototype.Elements != null && searchPrototype.Elements.Any())
            {
                query = query.Where(c => c.Elements.Contains(searchPrototype.Elements.First()));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.CommandName))
            {
                query = query.Where(c => c.CommandName.Contains(searchPrototype.CommandName));
            }
            if (searchPrototype.AutoTargetType != 0)
            {
                query = query.Where(c => c.AutoTargetType == searchPrototype.AutoTargetType);
            }
            if (searchPrototype.CastTime != 0)
            {
                query = query.Where(c => c.CastTime <= searchPrototype.CastTime);
            }
            if (searchPrototype.DamageFormulaType != 0)
            {
                query = query.Where(c => c.DamageFormulaType == searchPrototype.DamageFormulaType);
            }
            if (searchPrototype.Multiplier != 0)
            {
                query = query.Where(c => c.Multiplier >= searchPrototype.Multiplier);
            }
            if (searchPrototype.SoulBreakPointsGained != 0)
            {
                query = query.Where(c => c.SoulBreakPointsGained >= searchPrototype.SoulBreakPointsGained);
            }
            if (searchPrototype.TargetType != 0)
            {
                query = query.Where(c => c.TargetType == searchPrototype.TargetType);
            }

            return query;
        }
        #endregion
    }
}
