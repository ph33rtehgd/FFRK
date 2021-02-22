using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum LimitBreakColumn
    {
        //General
        Realm = 0,
        Character = 1,
        ImagePath = 2,
        LimitBreakName = 3,
        Tier = 4,
        Type = 5,
        Target = 6,
        Formula = 7,
        Multiplier = 8,
        Element = 9,
        Time = 10,
        Effects = 11,
        Counter = 12,
        AutoTarget = 13,
        MinimumLBPoints = 14,
        LimitBreakBonus = 15,
        MasteryBonus = 16,
        Relic = 17,
        JapaneseName = 18,
        ID = 19,
        IsInGlobal = 20,
        Checked = 21

    }

    public class LimitBreakRow
    {
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string ImagePath { get; set; }
        public string LimitBreakName { get; set; }
        public string Type { get; set; }
        public string Target { get; set; }
        public string Formula { get; set; }
        public string Multiplier { get; set; }
        public string Element { get; set; }
        public string Time { get; set; }
        public string Effects { get; set; }
        public string Counter { get; set; }
        public string AutoTarget { get; set; }
        public string MinimumLBPoints { get; set; }
        public string Tier { get; set; }
        public string LimitBreakBonus { get; set; }
        public string MasteryBonus { get; set; }
        public string Relic { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }
    }
}
