﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IMissionsLogic
    {
        IEnumerable<Mission> GetAllMissions();
        IEnumerable<Mission> GetMissionsById(int missionId);
        IEnumerable<Mission> GetMissionsByMissionType(string missionType); //todo change to int
        IEnumerable<Mission> GetMissionsByEventId(string eventId); //todo change to int
        IEnumerable<Mission> GetMissionsByDescription(string description);
        IEnumerable<Mission> GetMissionsByReward(string rewardName);
    }

    public class MissionsLogic : IMissionsLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<MissionsLogic> _logger;
        #endregion

        #region Constructors

        public MissionsLogic(IEnlirRepository enlirRepository, ILogger<MissionsLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IMissionsLogic Implementation

        public IEnumerable<Mission> GetAllMissions()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllMissions)}");

            return _enlirRepository.GetMergeResultsContainer().Missions;
        }

        public IEnumerable<Mission> GetMissionsById(int missionId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsById)}");

            return _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Id == missionId);
        }

        public IEnumerable<Mission> GetMissionsByMissionType(string missionType)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByMissionType)}");

            IEnumerable<Mission> results = new List<Mission>();

            if (!String.IsNullOrWhiteSpace(missionType))
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.MissionType.ToLower().Contains(missionType.ToLower()));
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByEventId(string eventId)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByEventId)}");

            IEnumerable<Mission> results = new List<Mission>();

            if (!String.IsNullOrWhiteSpace(eventId))
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.AssociatedEvent.ToLower().Contains(eventId.ToLower()));
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByDescription(string description)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByDescription)}");

            IEnumerable<Mission> results = new List<Mission>();

            if (!String.IsNullOrWhiteSpace(description))
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Description.ToLower().Contains(description.ToLower()));
            }

            return results;
        }

        public IEnumerable<Mission> GetMissionsByReward(string rewardName)
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetMissionsByReward)}");

            IEnumerable<Mission> results = new List<Mission>();

            if (!String.IsNullOrWhiteSpace(rewardName))
            {
                results = _enlirRepository.GetMergeResultsContainer().Missions.Where(e => e.Rewards.Any(r => r.ItemName.ToLower().Contains(rewardName.ToLower())));
            }

            return results;
        }
        #endregion
    }
}
