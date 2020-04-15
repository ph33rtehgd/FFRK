using System;
using System.Collections.Generic;
using System.Text;
using FFRKApi.Model.EnlirImport;
using FFRKApi.Model.EnlirTransform;
using FFRKApi.Model.EnlirTransform.Converters;
using FFRKApi.Model.EnlirTransform.IdLists;
using Microsoft.Extensions.Logging;

namespace FFRKApi.Logic.EnlirTransform
{
    public class LimitBreakTransformer : RowTransformerBase<LimitBreakRow, LimitBreak>
    {
        #region Class Variables
        private readonly IntConverter _intConverter;
        private readonly DoubleConverter _doubleConverter;
        private readonly StringToBooleanConverter _stringToBooleanConverter;
        private readonly TypeListConverter _abilityTypeConverter;
        private readonly TypeListConverter _targetTypeConverter;
        private readonly TypeListConverter _autoTargetTypeConverter;
        private readonly TypeListConverter _damageFormulaTypeConverter;
        private readonly TypeListConverter _elementConverter;
        private readonly TypeListConverter _schoolConverter;
        private readonly TypeListConverter _realmConverter;
        private readonly TypeListConverter _limitBreakTierConverter;

        #endregion

        #region Constructors
        public LimitBreakTransformer(ILogger<RowTransformerBase<LimitBreakRow, LimitBreak>> logger) : base(logger)
        {
            //prepare converters so we only need one instance no matter how many rows are processed
            _intConverter = new IntConverter();
            _doubleConverter = new DoubleConverter();
            _stringToBooleanConverter = new StringToBooleanConverter();
            _abilityTypeConverter = new TypeListConverter(new AbilityTypeList());
            _targetTypeConverter = new TypeListConverter(new TargetTypeList());
            _autoTargetTypeConverter = new TypeListConverter(new AutoTargetTypeList());
            _damageFormulaTypeConverter = new TypeListConverter(new DamageFormulaTypeList());
            _elementConverter = new TypeListConverter(new ElementList());
            _schoolConverter = new TypeListConverter(new SchoolList());
            _realmConverter = new TypeListConverter(new RealmList());
            _limitBreakTierConverter = new TypeListConverter(new LimitBreakTierList());
        }
        #endregion

        #region RowTransformerBase Implementation
        protected override LimitBreak ConvertRowToModel(int generatedId, LimitBreakRow row)
        {
            LimitBreak model = new LimitBreak();

            model.Id = generatedId;
            model.Description = row.LimitBreakName;

            model.LimitBreakName = row.LimitBreakName;
            model.JapaneseName = row.JapaneseName;
            model.ImagePath = row.ImagePath;

            model.CharacterName = row.Character.Replace(DashCharacter, String.Empty); ;
            model.CharacterId = 0; //fill in during merge phase

            model.RelicName = row.Relic;
            model.RelicId = 0; //fill in during merge phase

            model.Realm = _realmConverter.ConvertFromNameToId(row.Realm);

            model.Statuses = null; //fill in during merge phase
            model.OtherEffects = null; //fill in during merge phase

            model.AbilityType = _abilityTypeConverter.ConvertFromNameToId(row.Type);
            model.TargetType = _targetTypeConverter.ConvertFromNameToId(row.Target);
            model.AutoTargetType = _autoTargetTypeConverter.ConvertFromNameToId(row.AutoTarget);
            model.DamageFormulaType = _damageFormulaTypeConverter.ConvertFromNameToId(row.Formula);
            model.Multiplier = _doubleConverter.ConvertFromStringToDouble(row.Multiplier);
            model.Elements = _elementConverter.ConvertFromCommaSeparatedListToIds(row.Element);
            model.CastTime = _doubleConverter.ConvertFromStringToDouble(row.Time);
            model.Effects = row.Effects;
            model.IsCounterable = _stringToBooleanConverter.ConvertFromStringToBool(row.Counter);
            model.IsInGlobal = _stringToBooleanConverter.ConvertFromStringToBool(row.IsInGlobal);
            model.IsChecked = _stringToBooleanConverter.ConvertFromStringToBool(row.Checked);

            model.MinimumLBPoints = _intConverter.ConvertFromStringToInt(row.MinimumLBPoints);
            model.LimitBreakTier = _limitBreakTierConverter.ConvertFromNameToId(row.Tier);
            model.LimitBreakBonus = row.LimitBreakBonus;

            model.EnlirId = row.ID;


            _logger.LogDebug("Converted LimitBreakRow to LimitBreak: {Id} - {Description}", model.Id, model.Description);

            return model;
        } 
        #endregion
    }
}
