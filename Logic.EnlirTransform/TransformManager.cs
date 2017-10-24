﻿using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Data.Storage;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public interface ITransformManager
    {
        TransformResultsContainer TransformAll();
    }

    public class TransformManager: ITransformManager
    {
        #region Class Variables

        private readonly IRowTransformer<MissionRow, Mission> _missionRowTransformer;

        private readonly IImportStorageProvider _importStorageProvider;
        private readonly ILogger<TransformManager> _logger;

        #endregion

        #region Constructors

        public TransformManager(IRowTransformer<MissionRow, Mission> missionRowTransformer,
            IImportStorageProvider importStorageProvider, ILogger<TransformManager> logger)
        {
            _missionRowTransformer = missionRowTransformer;

            _importStorageProvider = importStorageProvider;
            _logger = logger;
        }
        #endregion

        public TransformResultsContainer TransformAll()
        {
            TransformResultsContainer transformResultsContainer = new TransformResultsContainer();

            ImportResultsContainer importResults = _importStorageProvider.RetrieveImportResults();


            transformResultsContainer.Missions = _missionRowTransformer.Transform(importResults.MissionRows);
            _logger.LogInformation("finished transforming MissionRows to Missions");

            return transformResultsContainer;
        }
    }
}
