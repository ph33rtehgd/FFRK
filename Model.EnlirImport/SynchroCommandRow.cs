using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum SynchroCommandColumn
    {
        //General
        Character = 0,
        Source = 1,
        ImagePath = 2,
        CommandName = 3,
        SynchroAbilitySlot = 4,
        SynchroCondition = 5,
        Type = 6,
        Target = 7,
        Formula = 8,
        Multiplier = 9,
        Element = 10,
        Time = 11,
        Effects = 12,
        Counter = 13,
        AutoTarget = 14,
        SB = 15,
        School = 16,
        JapaneseName = 17,
        ID = 18,
        SynchroConditionId = 19,
        IsInGlobal = 20,
        Checked = 21
    }

    public class SynchroCommandRow
    {
        //General
        public string Character { get; set; }
        public string Source { get; set; }
        public string ImagePath { get; set; }
        public string CommandName { get; set; }
        public string SynchroAbilitySlot { get; set; }
        public string SynchroCondition { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string Element { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string AutoTarget { get; set; }
        public string SB { get; set; }
        public string School { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string SynchroConditionId { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
