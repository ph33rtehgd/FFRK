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
    public class LimitBreakImporter : RowImporterBase<LimitBreakRow>
    {
        public LimitBreakImporter(ISheetsApiHelper sheetsApiHelper, IOptions<LimitBreakImporterOptions> importerOptionsAccessor, ILogger<RowImporterBase<LimitBreakRow>> logger) 
            : base(sheetsApiHelper, importerOptionsAccessor, logger)
        {
        }

        protected override LimitBreakRow AssignColumnToProperty(int columnCount, IList<object> row)
        {
            LimitBreakRow importedRow = new LimitBreakRow();

            importedRow.Realm = ResolveColumnContents(columnCount, LimitBreakColumn.Realm, row);
            importedRow.Character = ResolveColumnContents(columnCount, LimitBreakColumn.Character, row);
            importedRow.ImagePath = ResolveColumnContents(columnCount, LimitBreakColumn.ImagePath, row);
            importedRow.LimitBreakName = ResolveColumnContents(columnCount, LimitBreakColumn.LimitBreakName, row);
            importedRow.Type = ResolveColumnContents(columnCount, LimitBreakColumn.Type, row);
            importedRow.Target = ResolveColumnContents(columnCount, LimitBreakColumn.Target, row);
            importedRow.Formula = ResolveColumnContents(columnCount, LimitBreakColumn.Formula, row);
            importedRow.Multiplier = ResolveColumnContents(columnCount, LimitBreakColumn.Multiplier, row);
            importedRow.Element = ResolveColumnContents(columnCount, LimitBreakColumn.Element, row);
            importedRow.Time = ResolveColumnContents(columnCount, LimitBreakColumn.Time, row);
            importedRow.Effects = ResolveColumnContents(columnCount, LimitBreakColumn.Effects, row);
            importedRow.Counter = ResolveColumnContents(columnCount, LimitBreakColumn.Counter, row);
            importedRow.AutoTarget = ResolveColumnContents(columnCount, LimitBreakColumn.AutoTarget, row);
            importedRow.MinimumLBPoints = ResolveColumnContents(columnCount, LimitBreakColumn.MinimumLBPoints, row);
            importedRow.Tier = ResolveColumnContents(columnCount, LimitBreakColumn.Tier, row);
            importedRow.LimitBreakBonus = ResolveColumnContents(columnCount, LimitBreakColumn.LimitBreakBonus, row);
            importedRow.MasteryBonus = ResolveColumnContents(columnCount, LimitBreakColumn.MasteryBonus, row);
            importedRow.Relic = ResolveColumnContents(columnCount, LimitBreakColumn.Relic, row);
            importedRow.JapaneseName = ResolveColumnContents(columnCount, LimitBreakColumn.JapaneseName, row);
            importedRow.ID = ResolveColumnContents(columnCount, LimitBreakColumn.ID, row);
            importedRow.IsInGlobal = ResolveColumnContents(columnCount, LimitBreakColumn.IsInGlobal, row);
            importedRow.Checked = ResolveColumnContents(columnCount, LimitBreakColumn.Checked, row);


            return importedRow;
        }
    }
}
