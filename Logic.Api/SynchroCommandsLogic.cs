using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface ISynchroCommandsLogic
    {
        IEnumerable<SynchroCommand> GetAllSynchroCommands();
        IEnumerable<SynchroCommand> GetSynchroCommandsById(int synchroCommandId);
        IEnumerable<SynchroCommand> GetSynchroCommandsByAbilityType(int abilityType);
        IEnumerable<SynchroCommand> GetSynchroCommandsByCharacter(int characterId);
        IEnumerable<SynchroCommand> GetSynchroCommandsBySchool(int schoolType);
        IEnumerable<SynchroCommand> GetSynchroCommandsByElement(int elementType);
        IEnumerable<SynchroCommand> GetSynchroCommandsBySearch(SynchroCommand searchPrototype);
    }

    public class SynchroCommandsLogic : ISynchroCommandsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<SynchroCommandsLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public SynchroCommandsLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<SynchroCommandsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ISynchroCommandsLogic Implementation
        public IEnumerable<SynchroCommand> GetAllSynchroCommands()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllSynchroCommands)}");

            string cacheKey = $"{nameof(GetAllSynchroCommands)}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsById(int synchroCommandId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSynchroCommandsById)}");

            string cacheKey = $"{nameof(GetSynchroCommandsById)}:{synchroCommandId}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands.Where(c => c.Id == synchroCommandId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSynchroCommandsByAbilityType)}");

            string cacheKey = $"{nameof(GetSynchroCommandsByAbilityType)}:{abilityType}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands.Where(c => c.AbilityType == abilityType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSynchroCommandsByCharacter)}");

            string cacheKey = $"{nameof(GetSynchroCommandsByCharacter)}:{characterId}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands.Where(c => c.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsBySchool(int schoolType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSynchroCommandsBySchool)}");

            string cacheKey = $"{nameof(GetSynchroCommandsBySchool)}:{schoolType}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands.Where(c => c.School == schoolType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetSynchroCommandsByElement)}");

            string cacheKey = $"{nameof(GetSynchroCommandsByElement)}:{elementType}";
            IEnumerable<SynchroCommand> results = _cacheProvider.ObjectGet<IList<SynchroCommand>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().SynchroCommands.Where(c => c.Elements.Contains(elementType));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<SynchroCommand> GetSynchroCommandsBySearch(SynchroCommand searchPrototype)
        {
            //ignore: CharacterName, Description, SourceSoulBreakName, ImagePath, EnlirId, Id, ImagePath, IsChecked, IsCounterable, JapaneseName, SoulBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().SynchroCommands;

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
