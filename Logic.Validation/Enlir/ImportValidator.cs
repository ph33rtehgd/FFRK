﻿using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Logic.Validation.GoogleSheets;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.Validation.Enlir
{
    public interface IImportValidator
    {
        bool TryValidateDataSource(out string failureInfo);
    }
    public class ImportValidator : IImportValidator
    {
        #region Class Variables

        private readonly CharacterImporterOptions _characterImporterOptions;
        private readonly RecordSphereImporterOptions _recordSphereImporterOptions;
        private readonly LegendSphereImporterOptions _legendSphereImporterOptions;
        private readonly RecordMateriaImporterOptions _recordMateriaImporterOptions;
        private readonly LegendMateriaImporterOptions _legendMateriaImporterOptions;
        private readonly AbilityImporterOptions _abilityImporterOptions;
        private readonly SoulBreakImporterOptions _soulBreakImporterOptions;
        private readonly LimitBreakImporterOptions _limitBreakImporterOptions;
        private readonly CommandImporterOptions _commandImporterOptions;
        private readonly SynchroCommandImporterOptions _synchroCommandImporterOptions;
        private readonly BraveActionImporterOptions _braveActionImporterOptions;
        private readonly OtherImporterOptions _otherImporterOptions;
        private readonly StatusImporterOptions _statusImporterOptions;
        private readonly RelicImporterOptions _relicImporterOptions;
        private readonly MagiciteImporterOptions _magiciteImporterOptions;
        private readonly MagiciteSkillImporterOptions _magiciteSkillImporterOptions;
        //private readonly DungeonImporterOptions _dungeonImporterOptions;
        private readonly EventImporterOptions _eventImporterOptions;
        private readonly MissionImporterOptions _missionImporterOptions;
        private readonly ExperienceImporterOptions _experienceImporterOptions;
        private readonly SheetsServiceOptions _sheetsServiceOptions;

        private readonly IGoogleSheetsDataValidator _googleSheetsDataValidator;
        private readonly ILogger<ImportValidator> _logger;
        #endregion

        #region Constants

        private const int ExpectedWorksheetCount = 21; //this includes two sheets from which we do not import: Header, Calculator

        #endregion

        #region Contructors

        public ImportValidator(IOptions<CharacterImporterOptions> characterImporterOptions, IOptions<RecordSphereImporterOptions> recordSphereImporterOptions,
            IOptions<LegendSphereImporterOptions> legendSphereImporterOptions, IOptions<RecordMateriaImporterOptions> recordMateriaImporterOptions,
            IOptions<LegendMateriaImporterOptions> legendMateriaImporterOptions, IOptions<AbilityImporterOptions> abilityImporterOptions,
            IOptions<SoulBreakImporterOptions> soulBreakImporterOptions, IOptions<LimitBreakImporterOptions> limitBreakImporterOptions, IOptions<CommandImporterOptions> commandImporterOptions,
            IOptions<SynchroCommandImporterOptions> synchroCommandImporterOptions, IOptions<BraveActionImporterOptions> braveActionImporterOptions,
            IOptions<OtherImporterOptions> otherImporterOptions, IOptions<StatusImporterOptions> statusImporterOptions,
            IOptions<RelicImporterOptions> relicImporterOptions, IOptions<MagiciteImporterOptions> magiciteImporterOptions,
            IOptions<MagiciteSkillImporterOptions> magiciteSkillImporterOptions, 
            IOptions<EventImporterOptions> eventImporterOptions, IOptions<MissionImporterOptions> missionImporterOptions,
            IOptions<ExperienceImporterOptions> experienceImporterOptions, IOptions<SheetsServiceOptions> sheetsServiceOptions,
            IGoogleSheetsDataValidator googleSheetsDataValidator, ILogger<ImportValidator> logger)
        {
            _characterImporterOptions = characterImporterOptions.Value;
            _recordSphereImporterOptions = recordSphereImporterOptions.Value;
            _legendSphereImporterOptions = legendSphereImporterOptions.Value;
            _recordMateriaImporterOptions = recordMateriaImporterOptions.Value;
            _legendMateriaImporterOptions = legendMateriaImporterOptions.Value;
            _abilityImporterOptions = abilityImporterOptions.Value;
            _soulBreakImporterOptions = soulBreakImporterOptions.Value;
            _limitBreakImporterOptions = limitBreakImporterOptions.Value;
            _commandImporterOptions = commandImporterOptions.Value;
            _synchroCommandImporterOptions = synchroCommandImporterOptions.Value;
            _braveActionImporterOptions = braveActionImporterOptions.Value;
            _otherImporterOptions = otherImporterOptions.Value;
            _statusImporterOptions = statusImporterOptions.Value;
            _relicImporterOptions = relicImporterOptions.Value;
            _magiciteImporterOptions = magiciteImporterOptions.Value;
            _magiciteSkillImporterOptions = magiciteSkillImporterOptions.Value;
            //_dungeonImporterOptions = dungeonImporterOptions.Value;
            _eventImporterOptions = eventImporterOptions.Value;
            _missionImporterOptions = missionImporterOptions.Value;
            _experienceImporterOptions = experienceImporterOptions.Value;
            _sheetsServiceOptions = sheetsServiceOptions.Value;

            _googleSheetsDataValidator = googleSheetsDataValidator;
            _logger = logger;
        }
        #endregion

        #region IImportValidator Implementation
        public bool TryValidateDataSource(out string failureInfo)
        {
            bool isValid = true;
            StringBuilder builder = new StringBuilder();

            LoggerExtensions.LogInformation(_logger, "Starting validation of source spreadsheet.");

            //use the first worksheet; they all have the same spreadsheetId
            _googleSheetsDataValidator.LoadSpreadsheetMetadata(_characterImporterOptions.SpreadsheetId);


            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_characterImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(CharacterImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _characterImporterOptions.WorkSheetName);
            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_recordSphereImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(RecordSphereImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _recordSphereImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_legendSphereImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(LegendSphereImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _legendSphereImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_recordMateriaImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(RecordMateriaImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _recordMateriaImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_legendMateriaImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(LegendMateriaImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _legendMateriaImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_abilityImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(AbilityImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _abilityImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_soulBreakImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(SoulBreakImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _soulBreakImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_limitBreakImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(LimitBreakImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _limitBreakImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_commandImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(CommandImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _commandImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_synchroCommandImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(SynchroCommandImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _synchroCommandImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_braveActionImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(BraveActionImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _braveActionImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_otherImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(OtherImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _otherImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_statusImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(StatusImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _statusImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_relicImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(RelicImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _relicImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_magiciteImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(MagiciteImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _magiciteImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_magiciteSkillImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(MagiciteSkillImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _magiciteSkillImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_eventImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(EventImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _eventImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_missionImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(MissionImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _missionImporterOptions.WorkSheetName);

            }
            if (!_googleSheetsDataValidator.ValidateWorksheetMetadata(_experienceImporterOptions))
            {
                isValid = false;
                builder.AppendLine(nameof(ExperienceImporterOptions));
                LoggerExtensions.LogWarning(_logger, "Actual worksheet Structure does not match the expected structure for worksheet {WorksheetName}.", _experienceImporterOptions.WorkSheetName);

            }

            failureInfo = builder.ToString();
            return isValid;
        }
        #endregion

        #region Private Methods

      
        #endregion
    }
}
