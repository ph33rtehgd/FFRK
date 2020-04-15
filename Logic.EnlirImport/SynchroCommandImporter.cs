using System;
using System.Collections.Generic;
using System.Text;
using FFRK.Api.Infra.Options.EnlirETL;
using FFRKApi.Model.EnlirImport;
using FFRKApi.SheetsApiHelper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FFRKApi.Logic.EnlirImport
{
    public class SynchroCommandImporter : RowImporterBase<SynchroCommandRow>
    {
        public SynchroCommandImporter(ISheetsApiHelper sheetsApiHelper, IOptions<SynchroCommandImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<SynchroCommandRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override SynchroCommandRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            SynchroCommandRow importedRow = new SynchroCommandRow();

            importedRow.Character = ResolveColumnContents(columnCount, SynchroCommandColumn.Character, row);
            importedRow.Source = ResolveColumnContents(columnCount, SynchroCommandColumn.Source, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, SynchroCommandColumn.ImagePath, row);
            importedRow.CommandName = ResolveColumnContents(columnCount, SynchroCommandColumn.CommandName, row);
            importedRow.SynchroAbilitySlot = ResolveColumnContents(columnCount, SynchroCommandColumn.SynchroAbilitySlot, row);
            importedRow.SynchroCondition = ResolveColumnContents(columnCount, SynchroCommandColumn.SynchroCondition, row);
            importedRow.Type = ResolveColumnContents(columnCount, SynchroCommandColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, SynchroCommandColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, SynchroCommandColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, SynchroCommandColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, SynchroCommandColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, SynchroCommandColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, SynchroCommandColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, SynchroCommandColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, SynchroCommandColumn.AutoTarget, row);
            importedRow.SB = ResolveColumnContents(columnCount, SynchroCommandColumn.SB, row);
            importedRow.School = ResolveColumnContents(columnCount, SynchroCommandColumn.School, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, SynchroCommandColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, SynchroCommandColumn.ID, row);
            importedRow.SynchroConditionId = ResolveColumnContents(columnCount, SynchroCommandColumn.SynchroConditionId, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, SynchroCommandColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, SynchroCommandColumn.Checked, row);

            return importedRow;
        }
    }
}
