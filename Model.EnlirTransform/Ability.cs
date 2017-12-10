﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FFRKApi.Model.EnlirTransform
{
    public class Ability : IModelDescriptor
    {
        #region IModelDescriptor Implementation
        public int Id { get; set; }
        public string Description { get; set; }
        #endregion

        //General
        public string AbilityName { get; set; }
        public string ImagePath { get; set; }
        
        public int Rarity { get; set; }
        public int MinUses { get; set; }
        public int MaxUses { get; set; }

        public int AbilityType { get; set; }
        public int TargetType { get; set; }
        public int AutoTargetType { get; set; }
        public int DamageFormulaType { get; set; }
        public double Multiplier { get; set; }
        public IEnumerable<int> Elements { get; set; }
        public double CastTime { get; set; }
        public string Effects { get; set; }
        public bool IsCounterable { get; set; }
        public bool IsChecked { get; set; }
        public int SoulBreakPointsGained { get; set; }

        public string IntroducingEventName { get; set; }
        public int IntroducingEventId { get; set; } //filled in during merge phase

        public string EnlirId { get; set; }

        public IEnumerable<OrbRequirementsByRankInfo>OrbRequirements { get; set; }

    }

    public class OrbRequirementsByRankInfo
    {
        public int HoneRank { get; set; }

        public string OrbName { get; set; }

        public int OrbId { get; set; }

        public int OrbCount { get; set; }

    }
}
