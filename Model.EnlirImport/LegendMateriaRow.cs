using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirImport
{
    public enum LegendMateriaColumn
    {
        Realm = 0,
        Character = 1,
        ImagePath = 2,
        LegendMateriaName = 3,
        Tier = 4,
        Effect = 5,
        Master = 6,
        Relic = 7,
        JapaneseName = 8,
        ID = 9,
        Anima = 10,
        IsInGlobal = 11,
        Checked = 12
    }


    public class LegendMateriaRow
    {
    
        //General
        public string Realm { get; set; }
        public string Character { get; set; }
        public string ImagePath { get; set; }
        public string LegendMateriaName { get; set; }
        public string Tier { get; set; }
        public string Effect { get; set; }
        public string Master { get; set; }
        public string Relic { get; set; }
        public string JapaneseName { get; set; }
        public string ID { get; set; }
        public string Anima { get; set; }
        public string IsInGlobal { get; set; }
        public string Checked { get; set; }

    }
}
