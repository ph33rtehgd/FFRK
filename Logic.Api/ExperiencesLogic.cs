﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Api;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.Api
{
    public interface IExperiencesLogic
    {
        IEnumerable<Experience> GetAllExperiences();
    }

    public class ExperiencesLogic : IExperiencesLogic
    {
        #region Class Variables
        private readonly IEnlirRepository _enlirRepository;
        private readonly ILogger<ExperiencesLogic> _logger;
        #endregion

        #region Constructors

        public ExperiencesLogic(IEnlirRepository enlirRepository, ILogger<ExperiencesLogic> logger)
        {
            _enlirRepository = enlirRepository;
            _logger = logger;
        }
        #endregion

        #region IExperiencesLogic Implementation
        public IEnumerable<Experience> GetAllExperiences()
        {
            _logger.LogInformation($"Logic Method invoked: {nameof(GetAllExperiences)}");

            return _enlirRepository.GetMergeResultsContainer().Experiences;
        }
        #endregion


    }
}