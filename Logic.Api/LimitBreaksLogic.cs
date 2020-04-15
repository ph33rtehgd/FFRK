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
    public interface ILimitBreaksLogic
    {
        IEnumerable<LimitBreak> GetAllLimitBreaks();
        IEnumerable<LimitBreak> GetLimitBreaksById(int LimitBreakId);
        IEnumerable<LimitBreak> GetLimitBreaksByAbilityType(int abilityType);
        IEnumerable<LimitBreak> GetLimitBreaksByName(string LimitBreakName);
        IEnumerable<LimitBreak> GetLimitBreaksByRealm(int realmType);
        IEnumerable<LimitBreak> GetLimitBreaksByCharacter(int characterId);
        IEnumerable<LimitBreak> GetLimitBreaksByMultiplier(int multiplier);
        IEnumerable<LimitBreak> GetLimitBreaksByElement(int elementType);
        IEnumerable<LimitBreak> GetLimitBreaksByEffect(string effectText);
        IEnumerable<LimitBreak> GetLimitBreaksByTier(int LimitBreakTier);
        IEnumerable<LimitBreak> GetLimitBreaksByLimitBreakBonus(string masteryBonusText);
        IEnumerable<LimitBreak> GetLimitBreaksByStatus(int statusId);
        IEnumerable<LimitBreak> GetLimitBreaksBySearch(LimitBreak searchPrototype);
    }

    public class LimitBreaksLogic : ILimitBreaksLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<LimitBreaksLogic> _logger;
        private readonly ICacheProvider _cacheProvider;
        #endregion

        #region Constructors

        public LimitBreaksLogic(IEnlirRepository enlirRepository, ICacheProvider cacheProvider, ILogger<LimitBreaksLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
            _cacheProvider = cacheProvider;
        }
        #endregion

        #region ILimitBreaksLogic Implementation

        public IEnumerable<LimitBreak> GetAllLimitBreaks()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllLimitBreaks)}");

            string cacheKey = $"{nameof(GetAllLimitBreaks)}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks;

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksById(int LimitBreakId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksById)}");

            string cacheKey = $"{nameof(GetLimitBreaksById)}:{LimitBreakId}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(s => s.Id == LimitBreakId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByAbilityType(int abilityType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByAbilityType)}");

            string cacheKey = $"{nameof(GetLimitBreaksByAbilityType)}:{abilityType}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(s => s.AbilityType == abilityType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByName(string LimitBreakName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByName)}");

            string cacheKey = $"{nameof(GetLimitBreaksByName)}:{LimitBreakName}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<LimitBreak>();

                if (!String.IsNullOrWhiteSpace(LimitBreakName))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(e => e.LimitBreakName.ToLower().Contains(LimitBreakName.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByRealm(int realmType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByRealm)}");

            string cacheKey = $"{nameof(GetLimitBreaksByRealm)}:{realmType}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(s => s.Realm == realmType);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByCharacter(int characterId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByCharacter)}");

            string cacheKey = $"{nameof(GetLimitBreaksByCharacter)}:{characterId}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(s => s.CharacterId == characterId);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByMultiplier(int multiplier)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByMultiplier)}");

            return _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(s => s.Multiplier >= multiplier);
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByElement(int elementType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByElement)}");

            string cacheKey = $"{nameof(GetLimitBreaksByElement)}:{elementType}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where
                    (a => a.Elements.Contains(elementType) ||
                      a.OtherEffects.Any(e => e.Elements.Contains(elementType)));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByEffect(string effectText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByEffect)}");

            string cacheKey = $"{nameof(GetLimitBreaksByEffect)}:{effectText}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<LimitBreak>();

                if (!String.IsNullOrWhiteSpace(effectText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(e => e.Effects.ToLower().Contains(effectText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByTier(int LimitBreakTier)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByTier)}");

            string cacheKey = $"{nameof(GetLimitBreaksByTier)}:{LimitBreakTier}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(a => a.LimitBreakTier == LimitBreakTier);

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByLimitBreakBonus(string masteryBonusText)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByLimitBreakBonus)}");

            string cacheKey = $"{nameof(GetLimitBreaksByLimitBreakBonus)}:{masteryBonusText}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = new List<LimitBreak>();

                if (!String.IsNullOrWhiteSpace(masteryBonusText))
                {
                    results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(e => e.LimitBreakBonus.ToLower().Contains(masteryBonusText.ToLower()));

                    _cacheProvider.ObjectSet(cacheKey, results);
                }
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksByStatus(int statusId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksByStatus)}");

            string cacheKey = $"{nameof(GetLimitBreaksByStatus)}:{statusId}";
            IEnumerable<LimitBreak> results = _cacheProvider.ObjectGet<IList<LimitBreak>>(cacheKey);

            if (results == null)
            {
                results = _enlirRepository.GetMergeResultsContainer().LimitBreaks.Where(a => a.Statuses.Any(s => s.Id == statusId));

                _cacheProvider.ObjectSet(cacheKey, results);
            }

            return results;
        }

        public IEnumerable<LimitBreak> GetLimitBreaksBySearch(LimitBreak searchPrototype)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetLimitBreaksBySearch)}");


            //ignore: Description, Effects, EnlirId, Id, ImagePath, IntroducingEventId, IntroducingEventName, IsChecked, IsCounterable, LimitBreakPointsGainedJapan
            var query = _enlirRepository.GetMergeResultsContainer().LimitBreaks;

            if (searchPrototype.AbilityType != 0)
            {
                query = query.Where(a => a.AbilityType == searchPrototype.AbilityType);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.LimitBreakName))
            {
                query = query.Where(a => a.LimitBreakName.ToLower().Contains(searchPrototype.LimitBreakName.ToLower()));
            }
            if (searchPrototype.Realm != 0)
            {
                query = query.Where(a => a.Realm == searchPrototype.Realm);
            }
            if (searchPrototype.CharacterId != 0)
            {
                query = query.Where(a => a.CharacterId == searchPrototype.CharacterId);
            }
            if (searchPrototype.Multiplier != 0)
            {
                query = query.Where(a => a.Multiplier >= searchPrototype.Multiplier);
            }           
            if (searchPrototype.Elements != null && searchPrototype.Elements.Any())
            {
                query = query.Where(a => a.Elements.Contains(searchPrototype.Elements.First()) ||
                                         a.OtherEffects.Any(e => e.Elements.Contains(searchPrototype.Elements.First())));
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.Effects))
            {
                query = query.Where(a => a.Effects.ToLower().Contains(searchPrototype.Effects.ToLower()));
            }
            if (searchPrototype.LimitBreakTier != 0)
            {
                query = query.Where(a => a.LimitBreakTier == searchPrototype.LimitBreakTier);
            }
            if (!string.IsNullOrWhiteSpace(searchPrototype.LimitBreakBonus))
            {
                query = query.Where(a => a.LimitBreakBonus.ToLower().Contains(searchPrototype.LimitBreakBonus.ToLower()));
            }
            if (searchPrototype.Statuses != null && searchPrototype.Statuses.Any())
            {
                query = query.Where(a => a.Statuses.Any(s => s.Id == searchPrototype.Statuses.First().Id));
            }
            if (searchPrototype.AutoTargetType != 0)
            {
                query = query.Where(a => a.AutoTargetType == searchPrototype.AutoTargetType);
            }
            if (searchPrototype.CastTime != 0)
            {
                query = query.Where(a => a.CastTime <= searchPrototype.CastTime);
            }
            if (searchPrototype.DamageFormulaType != 0)
            {
                query = query.Where(a => a.DamageFormulaType == searchPrototype.DamageFormulaType);
            }           
            if (searchPrototype.TargetType != 0)
            {
                query = query.Where(a => a.TargetType == searchPrototype.TargetType);
            }


            return query;
        }
        #endregion
    }
}
